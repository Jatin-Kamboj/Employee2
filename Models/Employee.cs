using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        //A Model is a Set of classes that Represent the data and Another class which Have logic to Manuplate the dat
        // Eg:- save,retrieve the data from the Database
        //This is a Model Classs which represent the data nad holds the Data here
        // For the Id
        [Key]
        public int id { get; set; }
        [Required, MaxLength(10, ErrorMessage = "MaxLength Limit Reached")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String Name { get; set; }
        // Validtion for the Email
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format") ,Required, Display(Name ="Office Email")]
        public String Email { get; set; }
        //Validation for the Department
        [Required]
        public Dept? Department { get; set; }

        // As in the Database we will only the Store the Location of the Image Uploaded
        public String PhotoPath { get; set; }

    }
}
