using DepartmentApp.Entity;

namespace DepartmentApp.Printers
{
    public static class EmployeePrinter
    {
        public static void PrintEmployeeDetails(List<EmployeeDetails> details)
        {
            foreach (var d in details)
                Console.WriteLine($"{d.EmployeeId} | {d.EmployeeName} | {d.Salary} | {d.DepartmentName}");
        }

        public static void PrintEmployeeResults(List<EmployeeResult> results)
        {
            foreach (var r in results)
                Console.WriteLine($"{r.Id} | {r.Name} | {r.Salary}");
        }
    }
}