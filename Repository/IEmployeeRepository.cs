using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
   public interface IEmployeeRepository
    {
        // Interface to Maintain the data from the Database here
        Employee GetEmployee(int id);
       IEnumerable<Employee> GetAllList();// For all The Data to be Fetched from the database
        Employee AddEmploye( Employee employee);
        Employee Update(Employee UpdateChanges);
        Employee Delete(int id);

    }
}
