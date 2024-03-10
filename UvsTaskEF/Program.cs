using static EmployeesContext;

namespace UvsTask
{
    class Program
    {
        private static readonly EmployeesContext db = new();
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 0)
                {
                    if (args[0] == "set-employee")
                    {
                        if (args[1] == "--employeeId" && args[3] == "--employeeName" && args[5] == "--employeeSalary")
                        {
                            Set(int.Parse(args[2]), args[4], int.Parse(args[6]));
                        }
                    }
                    else if (args[0] == "get-employee")
                    {
                        if (args[1] == "--employeeId")
                        {
                            Get(int.Parse(args[2]));
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Provided arguments are incorrect");
            }
        }

        private static void Set(int employeeId, string employeeName, int employeeSalary)
        {
            // Checking if the employee already exists and if it does updating the employee
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
                Console.WriteLine($"Updated employee : \n" +
                    $"ID - {employee.employeeid}, NAME - {employee.employeename}, SALARY - {employee.employeesalary}");
            }
            else
            {
                Console.WriteLine("Inserting a new employee");
                db.Add(new Employee { employeeid = employeeId, employeename = employeeName, employeesalary = employeeSalary });
                db.SaveChanges();
            }
        }

        private static void Get(int employeeId)
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