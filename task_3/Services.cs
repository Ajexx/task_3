using Microsoft.EntityFrameworkCore;
using DepartmentApp.Context;

namespace DepartmentApp.Services
{
    public static class EmployeeService
    {
        public static async Task UpdateEmployeeSalaryAsync(AppDbContext context, int employeeId, decimal newSalary)
        {
            await context.Database.ExecuteSqlInterpolatedAsync($"EXEC UpdateEmployeeSalary {employeeId}, {newSalary}");
        }
    }
}