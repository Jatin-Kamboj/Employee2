using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeCreateViewModel
    {
        // This File Is Created
        public String Name { get; set; }
        // Validtion for the Email
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format"), Required, Display(Name = "Office Email")]
        public String Email { get; set; }
        //Validation for the Department
        [Required]
        public Dept? Department { get; set; }

        // IFormFile to upload the Image of the file on the Server
        public IFormFile Photo { get; set; }
    }
}
