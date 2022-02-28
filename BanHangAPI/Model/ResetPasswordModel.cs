using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Model
{
    public class ResetPasswordModel
    {
        
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "NewPassword is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

    }
}
