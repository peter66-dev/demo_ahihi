using MyLib.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MyLib.Models
{
    public partial class AccountUser
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }

        [Required(ErrorMessage ="this field is requried!")]
        [NameValidation]
        public string UserFullName { get; set; }
        public int? UserRole { get; set; }
    }
}
