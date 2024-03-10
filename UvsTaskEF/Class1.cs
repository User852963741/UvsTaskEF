using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class EmployeesContext : DbContext
{
    public DbSet<Employee> employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString:
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
