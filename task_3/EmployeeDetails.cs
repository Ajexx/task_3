using DepartmentApp.Entity;
using Microsoft.EntityFrameworkCore;
[Keyless]
public class EmployeeDetails
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
}
