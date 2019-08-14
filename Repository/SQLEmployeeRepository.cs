using EmployeeManagement.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        // This is the Constructor Injection Here for the Context class to do Sql Queries
        private readonly EmployeeContext context;
        public SQLEmployeeRepository(EmployeeContext employeeContext)
        {
            this.context = employeeContext;
        }
        public Employee AddEmploye(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public  Employee Delete(int id)
        {
           Employee employee=  context.Employee.Find(id);
            if(employee != null)
            {
                context.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllList()
        {
            var EmployeeList = context.Employee.ToList();
            return EmployeeList;
        }

        public Employee GetEmployee(int id)
        {
           Employee employee = context.Employee.Find(id);
            return employee; 
        }


        public Employee Update(Employee UpdateChanges)
        {
            var id = context.Employee.Find(UpdateChanges.id);
            var employee = context.Employee.Attach(UpdateChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return UpdateChanges;
        }
    }
}
