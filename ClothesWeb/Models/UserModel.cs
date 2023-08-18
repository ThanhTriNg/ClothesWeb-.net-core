using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesWeb.Models
{
    public class UserModel
    {
        public class LoginModel
        {
            [Required(ErrorMessage = "Không được để trống !")]
            [EmailAddress(ErrorMessage = "Không đúng định dạng email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Không được để trống !")]
            [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
            [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
            public string Password { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
            [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
            public string Name { get; set; }

            public string Phone { get; set; }

            public string Adress { get; set; }

            [Required]
            [EmailAddress(ErrorMessage = "Không đúng định dạng email")]
            public string Email { get; set; }

            [Required]
            [MinLength(4, ErrorMessage = "Chiều dài tối thiểu là 4 ký tự")]
            [MaxLength(60, ErrorMessage = "Chiều dài tối đa là 60 ký tự")]
            public string Password { get; set; }

            [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
            public string CofirmPassword { get; set; }
        }
    }
}
