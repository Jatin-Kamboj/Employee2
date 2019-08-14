using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DataContext
{
    public class EmployeeContext :IdentityDbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }
      public DbSet<Employee> Employee { get; set; }
       //public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);


        }
    }
}
/* modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DeptId = 1,
                    DeptName = "Hr"
                },
                new Department
                {
                    DeptId = 2,
                    DeptName = "Payroll"
                },
                new Department
                {
                    DeptId = 3,
                    DeptName = "IT"
                }
                ) ;*/