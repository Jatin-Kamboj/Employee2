using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public String Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password),Display(Name ="Confirm Password")]  // This is to Compare the Password and Confirm Passwords In the Model for the Validations
        [Compare("Password",ErrorMessage ="Password and Confirmation Passwords Donot Match")]
        public String ConfirmPassword { get; set; }

    }
}
