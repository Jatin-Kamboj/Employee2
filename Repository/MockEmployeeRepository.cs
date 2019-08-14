using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    // This Repository Stores the Data in the LIST Data Structure AND IS NAME AS [ MEMORY REPOSITORY ]

    public class MockEmployeeRepository : IEmployeeRepository
    {
        // This Class will provide the implementation of the Class IEmployeerepository
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            try
            {
                _employeeList = new List<Employee>()
        {
            new Employee() { id = 1, Name = "Mary", Department = Dept.Hr, Email = "mary@pragimtech.com" },
            new Employee() { id = 2, Name = "John", Department = Dept.It, Email = "john@pragimtech.com" },
            new Employee() { id = 3, Name = "Sam", Department = Dept.Payroll, Email = "sam@pragimtech.com" },
        };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee AddEmploye(Employee employee)
        {
            employee.id = _employeeList.Max(e => e.id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllList()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.id == id);
            if(emp != null)
            {
                _employeeList.Remove(emp);
            }
            return emp;
        }

        public Employee Update(Employee UpdateChanges)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.id == UpdateChanges.id);
            if (emp != null)
            {
                emp.Name = UpdateChanges.Name;
                emp.Email = UpdateChanges.Email;
                emp.Department = UpdateChanges.Department;
            }
            return emp;
        }
    }
    }

