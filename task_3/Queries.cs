using DepartmentApp.Context;
using DepartmentApp.Entity;
using Microsoft.EntityFrameworkCore;
namespace DepartmentApp.Queries
{
    public static class EmployeeQueries
    {
        public static async Task<List<EmployeeDetails>> GetEmployeeDetailsAsync(AppDbContext context)
        {
            return await context.EmployeeDetails.ToListAsync();
        }
        public static async Task<List<EmployeeResult>> GetEmployeesByDepartmentAsync(AppDbContext context, int departmentId)
        {
            return await context.EmployeeResults
                .FromSqlInterpolated($"EXEC GetEmployeesByDepartment {departmentId}")
                .ToListAsync();
        }
        public static async Task<Employee?> GetEmployeeByIdAsync(AppDbContext context, int employeeId)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public static async Task<Employee?> GetEmployeeByIdNoTrackingAsync(AppDbContext context, int employeeId)
        {
            return await context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == employeeId);
        }
    }
}