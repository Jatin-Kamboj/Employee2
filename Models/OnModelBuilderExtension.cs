using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class OnModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                           new Employee
                           {
                               id = 11,
                               Name = "Prakash",
                               Email = "Prakash@gamisl.com",
                               Department = Dept.Hr
                           },
                           new Employee
                           {
                               id = 12,
                               Name = "Pramodh",
                               Email = "Pramodh@gamisl.com",
                               Department = Dept.It
                           }
                           );
        }
    }
}
