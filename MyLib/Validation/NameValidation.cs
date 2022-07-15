using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Validation
{
    public class NameValidation : ValidationAttribute
    {
        public NameValidation()
        {
            ErrorMessage = "*** Sorry, your name must be more than 5 characters, please!";
        }

        public override bool IsValid(object value)
        {
            return value != null && value.ToString().Trim().Length >= 5;
        }
    }
}
