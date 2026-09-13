using DepartmentApp.Context;
using DepartmentApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace DepartmentApp.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Departments.AnyAsync()) 
            { 
                return; 
            }

            var it      = new Department { Name = "IT" };
            var hr      = new Department { Name = "HR" };
            var finance = new Department { Name = "Finance" };

            context.Departments.AddRange(it, hr, finance);

            var employees = new List<Employee>
            {
                new() { Name = "Alice",   Salary = 3500, Department = it,      IsActive = true },
                new() { Name = "Bob",     Salary = 2800, Department = it,      IsActive = true },
                new() { Name = "Charlie", Salary = 4200, Department = it,      IsActive = false }, // Non-active employee
                new() { Name = "Diana",   Salary = 3100, Department = hr,      IsActive = true },
                new() { Name = "Ethan",   Salary = 2500, Department = hr,      IsActive = true },
                new() { Name = "Fiona",   Salary = 3800, Department = finance, IsActive = true },
                new() { Name = "George",  Salary = 2700, Department = finance, IsActive = true },
                new() { Name = "Hannah",  Salary = 3200, Department = finance, IsActive = true },
            };

            context.Employees.AddRange(employees);

            await context.SaveChangesAsync();
        }
    }
}