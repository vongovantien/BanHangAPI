using BanHangAPI.Entities;
using BanHangAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BanHangAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "400", Message = "User ton tai" });
            ApplicationUser user = new()
            {
                FirstName = model.Firstname,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "500", Message = result.ToString() });

            }
            return Ok(new Response { Status = "201", Message = "Tao moi thanh cong" });
        }

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        //{
        //    var userExist = await _userManager.FindByNameAsync(model.UserName);
        //    if (userExist != null)
        //        return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "400", Message = "User ton tai" });
        //    User user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.UserName
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "500", Message = "Loi" });
        //    return Ok(new Response { Status = "201", Message = "Tao moi thanh cong" });
        //}
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var userExist = await _userManager.FindByNameAsync(model.UserName);
            if (userExist != null && await _userManager.CheckPasswordAsync(userExist, model.Password)){
                var userRoles = await _userManager.GetRolesAsync(userExist);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userExist.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

                var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.UtcNow.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if(user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);

            }
            if(string.Compare(model.NewPassword, model.ConfirmNewPassword) != 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);

            }
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                var errors = new List<string>();
                foreach(var error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();

        }
    }
}
