using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Login.Shared.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a valid email address", AllowEmptyStrings = false)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid password (min. 6 characters, max. 255)", AllowEmptyStrings = false)]
        [Display(Name = "Password")]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter a valid screen name (min. 3 characters, max. 20)", AllowEmptyStrings = false)]
        [Display(Name = "Screen name")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        // No need for tags because it will always have 0 (zero) as default
        public int LuckyNumber { get; set; }

        // Roles:
        //    1 - Admin
        //    2 - Power User
        //    3 - Normal User
        public int Role { get; set; }
    }
}
