using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ViewModel;

namespace EmployeeManagement.ViewModel
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {

        public int id { get; set; }
        public String ExistingPhotoPath { get; set; }

    }
    
}
