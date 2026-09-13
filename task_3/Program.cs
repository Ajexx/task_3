using DepartmentApp.Context;
using DepartmentApp.Printers;
using DepartmentApp.Queries;
using DepartmentApp.Seed;
using DepartmentApp.Services;

using var context = new AppDbContext();

var details = await EmployeeQueries.GetEmployeeDetailsAsync(context); // Fetch employee details from the database
EmployeePrinter.PrintEmployeeDetails(details);

var employeeResults = await EmployeeQueries.GetEmployeesByDepartmentAsync(context, 1); // Fetch employees by department (e.g., departmentId = 1)
EmployeePrinter.PrintEmployeeResults(employeeResults);

var employee = await EmployeeQueries.GetEmployeeByIdAsync(context, 1); // Fetch a specific employee by ID (e.g., employeeId = 1)
if (employee != null)
{
    Console.WriteLine($"Found employee: {employee.Name}, Salary: {employee.Salary}");
}
else
{
    Console.WriteLine("Employee not found.");
}

await EmployeeService.UpdateEmployeeSalaryAsync(context, employeeId: 1, newSalary: 6000); // Update the salary of the employee with ID 1 to 6000

var updatedEmployee = await EmployeeQueries.GetEmployeeByIdAsync(context, 1);
if (updatedEmployee is not null)
{
    Console.WriteLine($"Updated: {updatedEmployee.Name}, Salary: {updatedEmployee.Salary}");
}

await DataSeeder.SeedAsync(context);
Console.WriteLine("Data added successfully!");