using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BanHangAPI.Data;
using BanHangAPI.Model;
using Newtonsoft.Json;
using BanHangAPI.Entities;
using System.Text;

namespace BanHangAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDBContext _context;

        public CategoriesController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _context.Categories.Select(s => new { s.CategoryID, s.CategoryName, s.Slug})
                            .OrderBy(s => s.CategoryID).ToList();
                return Ok(categories);
            }
            catch
            {

                return BadRequest();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(s => s.CategoryID == id);
                if (category == null)
                {
                    return NotFound();
                }
                var data =  new CategoryViewModel { 
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                };
                return StatusCode(StatusCodes.Status200OK, data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        private static string ConvertToUnSign2(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        // GET: api/Categories/5
        [HttpPost]
        [Route("create-category")]
        public IActionResult CreateCategory(CategoryViewModel model)
        {

            try
            {
                var cate = new Category
                {
                    CategoryName = model.CategoryName,
                    Slug = ConvertToUnSign2(model.CategoryName).ToLower().Replace(" ", "-")
                };

                _context.Categories.Add(cate);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new CategoryViewModel { CategoryID = cate.CategoryID, CategoryName = cate.CategoryName});
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        
        [HttpPut]
        [Route("edit-category/{id}")]
        public IActionResult EditCategory(int id, CategoryViewModel model)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(s => s.CategoryID == id);
                if (category == null)
                {
                    return NotFound();
                }
                category.CategoryName = model.CategoryName;
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, category);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpDelete]
        [Route("delete-category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _context.Categories.SingleOrDefault(s => s.CategoryID == id);
                if (category == null)
                {
                    return NotFound();
                }
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
