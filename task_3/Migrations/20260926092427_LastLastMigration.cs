using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartmentApp.Migrations
{
    /// <inheritdoc />
    public partial class LastLastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE OR ALTER VIEW EmployeeDetails AS
        SELECT 
            e.Id AS EmployeeId,
            e.Name AS EmployeeName,
            e.Salary,
            d.Name AS DepartmentName
        FROM Employees e
        INNER JOIN Departments d ON e.DepartmentId = d.Id
        WHERE e.IsActive = 1;
    ");

            migrationBuilder.Sql(@"
        CREATE OR ALTER PROCEDURE GetEmployeesByDepartment
            @DepartmentId INT
        AS
        BEGIN
            SELECT Id, Name, Salary
            FROM Employees
            WHERE DepartmentId = @DepartmentId;
        END
    ");

            migrationBuilder.Sql(@"
        CREATE OR ALTER PROCEDURE UpdateEmployeeSalary
            @EmployeeId INT,
            @NewSalary DECIMAL(18,2)
        AS
        BEGIN
            UPDATE Employees
            SET Salary = @NewSalary
            WHERE Id = @EmployeeId;
        END
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('EmployeeDetails', 'V') IS NOT NULL DROP VIEW EmployeeDetails;");
            migrationBuilder.Sql("IF OBJECT_ID('GetEmployeesByDepartment', 'P') IS NOT NULL DROP PROCEDURE GetEmployeesByDepartment;");
            migrationBuilder.Sql("IF OBJECT_ID('UpdateEmployeeSalary', 'P') IS NOT NULL DROP PROCEDURE UpdateEmployeeSalary;");
        }
    }
}
