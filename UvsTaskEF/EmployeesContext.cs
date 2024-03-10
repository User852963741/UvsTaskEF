using Microsoft.EntityFrameworkCore;
public class EmployeesContext : DbContext
{
    public DbSet<Employee>? employees { get; set; }
    private static readonly string? ConnectionString = Environment.GetEnvironmentVariable("connectionString");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString: ConnectionString ??
           "Server=localhost;Port=7777;User Id=postgres;Password=guest;Database=uvsproject;");
        base.OnConfiguring(optionsBuilder);
    }

    public class Employee
    {
        public int employeeid { get; set; }
        public string employeename { get; set; }
        public int employeesalary { get; set; }
    }
}
