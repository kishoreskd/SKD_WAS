using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAS.Model
{
    public class Login
    {
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [ValidateNever]
        public string Role { get; set; }

        [ValidateNever]
        public int IsRemember { get; set; } = 1;
    }
}
