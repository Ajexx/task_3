using DepartmentApp.Context;
using DepartmentApp.Printers;
using DepartmentApp.Queries;
using DepartmentApp.Seed;
using DepartmentApp.Services;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

await DataSeeder.SeedAsync(context);
Console.WriteLine("Data added successfully!");

var details = await EmployeeQueries.GetEmployeeDetailsAsync(context); // Fetch employee details from the database
EmployeePrinter.PrintEmployeeDetails(details);

//----------
var departmentsId = await context.Departments.Select(d => d.Id).ToListAsync();
foreach (var item in departmentsId)
{
    var employeeResults = await EmployeeQueries.GetEmployeesByDepartmentAsync(context, item); // Fetch employees by department
    Console.WriteLine($"Departments: {item}");
    EmployeePrinter.PrintEmployeeResults(employeeResults);
}
//----------

var beforeEmployee = await EmployeeQueries.GetEmployeeByIdAsync(context, 1); // Fetch a specific employee by ID (e.g., employeeId = 1)
if (beforeEmployee != null)
{
    Console.WriteLine($"Found employee: {beforeEmployee.Name}, Salary: {beforeEmployee.Salary}");
}
else
{
    Console.WriteLine("Employee not found.");
}

await EmployeeService.UpdateEmployeeSalaryAsync(context, employeeId: 1, newSalary: 6000); // Update the salary of the employee with ID 1 to 6000

var AfterEmployee = await EmployeeQueries.GetEmployeeByIdNoTrackingAsync(context, 1);
if (AfterEmployee is not null)
{
    Console.WriteLine($"Updated: {AfterEmployee.Name}, Salary: {AfterEmployee.Salary}");
}
//-----------