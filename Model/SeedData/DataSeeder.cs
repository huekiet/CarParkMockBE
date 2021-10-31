using CoreApp.Model.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Model.SeedData
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<Employee>();
            var sampleEmployee = new Employee();
            sampleEmployee.EmployeeId = 1;
            sampleEmployee.Account = "admin";
            sampleEmployee.Department = "employee";
            sampleEmployee.EmployeeAddress = "Hanoi";
            sampleEmployee.EmployeeEmail = "admin@carpark.com";
            sampleEmployee.EmployeeName = "Admin";
            sampleEmployee.EmployeePhone = "0812345567";
            sampleEmployee.Sex = "0";
            sampleEmployee.Password = hasher.HashPassword(null, "123456");
            modelBuilder.Entity<Employee>().HasData(sampleEmployee);
        }
    }
}
