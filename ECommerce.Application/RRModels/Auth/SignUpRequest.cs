using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ECommerce.Domain;

namespace ECommerce.Application.RRModels.Auth
{
    public class SignUpRequest
    {
        [Required(ErrorMessage ="Email is Required")]
       // [RegularExpression("/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$/", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        public string PhoneNo { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm is Required")]
        [Compare(nameof(Password),ErrorMessage ="Password and confirm password doesnot match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "UserRole is Required is Required")]
        public UserRole UserRole { get; set; }
    }
}
