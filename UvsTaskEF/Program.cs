using System;
using System.Linq;
using System.Reflection.Metadata;
using static EmployeesContext;

namespace UvsTask
{
    class Program
    {
        private static EmployeesContext db = new EmployeesContext();
        static async Task Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (args[0] == "set-employee")
                {
                    if (args[1] == "--employeeId" && args[3] == "--employeeName" && args[5] == "--employeeSalary")
                    {
                        await Set(int.Parse(args[2]), args[4], int.Parse(args[6]));
                    }
                }
                else if (args[0] == "get-employee")
                {
                    if (args[1] == "--employeeId")
                    {
                        await Get(int.Parse(args[2]));
                    }
                }      
            }

            //Console.WriteLine("Inserting a new employee");
            //db.Add(new Employee { employeeid = 5, employeename = "Jane", employeesalary = 1000 });
            //db.SaveChanges();

            ////Read
            //Console.WriteLine("Querying for an employee");
            //var employee = db.employees
            //    .OrderBy(b => b.employeeid)
            //    .First();

            //// Update
            //Console.WriteLine("Updating the employee");
            //employee.employeesalary = 1100;
            //db.SaveChanges();

            //// Delete
            //Console.WriteLine("Delete the employee");
            //db.Remove(employee);
            //db.SaveChanges();
        }

        private static async Task Set(int employeeId, string employeeName, int employeeSalary)
        {
            var employee = db.employees
                .Where(employee => employee.employeeid == employeeId)
                .FirstOrDefault();
            
            if (employee != null)
            {
                Console.WriteLine($"Employee with ID {employeeId} already exists \n " +
                    $"ID - {employee.employeeid}, NAME - {employee.employeename}, SALARY - {employee.employeesalary} \n" +
                    $"Updating the employee");
                employee.employeename = employeeName;
                employee.employeesalary = employeeSalary;
                db.SaveChanges();
                Console.WriteLine($"Updated employee : " +
                    $"ID - {employee.employeeid}, NAME - {employee.employeename}, SALARY - {employee.employeesalary}");
            }
            else
            {
                Console.WriteLine("Inserting a new employee");
                db.Add(new Employee { employeeid = employeeId, employeename = employeeName, employeesalary = employeeSalary });
                db.SaveChanges();
            }
        }

        private static async Task Get(int employeeId)
        {
            Console.WriteLine("Querying for an employee");
            var employee = db.employees
                .Where(employee => employee.employeeid == employeeId)
                .FirstOrDefault();
            
            Console.Write(employee is null ? 
                $"Employee with ID {employeeId} doesn't exist" 
                : $"ID - {employee.employeeid}, NAME - {employee.employeename}, SALARY - {employee.employeesalary} \n");
        }
    }
}