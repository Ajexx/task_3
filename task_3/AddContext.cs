using DepartmentApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace DepartmentApp.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; } = null!;
        public DbSet<EmployeeResult> EmployeeResults { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ElxanRasulov;Database=DepartmentApp;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetails>(e =>
            {
                e.HasNoKey()
                .ToView("EmployeeDetails")
                .Property(x => x.Salary)
                .HasPrecision(18, 2);
            });

            modelBuilder.Entity<Employee>(e => 
            { 
                e.Property(x => x.Salary)
                .HasPrecision(18, 2);
            });
            modelBuilder.Entity<EmployeeResult>(e =>
            {
                e.HasNoKey()
                .ToView(null)
                .Property(x => x.Salary)
                .HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}