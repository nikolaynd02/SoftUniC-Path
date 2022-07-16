
namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(dbContext));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(dbContext));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));
            //Console.WriteLine(AddNewAddressToEmployee(dbContext));
            //Console.WriteLine(GetEmployeesInPeriod(dbContext));
            //Console.WriteLine(GetAddressesByTown(dbContext));
            //Console.WriteLine(GetEmployee147(dbContext));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(dbContext));
            //Console.WriteLine(GetLatestProjects(dbContext));
            //Console.WriteLine(IncreaseSalaries(dbContext));
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(dbContext));
            //Console.WriteLine(DeleteProjectById(dbContext));
            Console.WriteLine(RemoveTown(dbContext));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employeeInfo = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.MiddleName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.EmployeeId)
                .ToArray();

            StringBuilder output = new StringBuilder();
            foreach (var employee in employeeInfo)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return output.ToString().Trim();

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var emplyeeInfo = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToArray();

            StringBuilder output = new StringBuilder();
            foreach(var employee in emplyeeInfo)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return output.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employeeInfo = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department,
                    x.Salary
                })
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach (var employee in employeeInfo)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return output.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            Employee nakovEmployee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            context.Addresses.Add(address);

            nakovEmployee.Address = address;

            context.SaveChanges();

            string[] employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => x.Address.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder output = new StringBuilder();
            foreach (string employeeAddress in employees)
            {
                output.AppendLine(employeeAddress);
            }

            return output.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(db => db.EmployeesProjects)
                .ThenInclude(db => db.Project)
                .Where(x => x.EmployeesProjects
                    .Select(x => x.Project)
                    .Any(x => x.StartDate.Year >= 2001 && x.StartDate.Year <= 2003))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects
                        .Select(x => x.Project)
                })
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach(var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string endDate = project.EndDate != null
                        ? $"{project.EndDate:M/d/yyyy h:mm:ss tt}"
                        : "not finished";

                    output.AppendLine($"--{project.Name} - {project.StartDate} - {endDate}");
                }
            }

            return output.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(x => x.Town)
                .Include(x => x.Employees)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    x.Employees
                })
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach(var address in addresses)
            {
                output.AppendLine($"{address.AddressText}, {address.TownName} - {address.Employees.Count} employees");
            }

            return output.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            Employee employee = context.Employees
                .Include(db => db.EmployeesProjects)
                .ThenInclude(db => db.Project)
                .FirstOrDefault(x => x.EmployeeId == 147);

            string[] projectNames = employee.EmployeesProjects
                .Select(x => x.Project.Name)
                .OrderBy(name => name)
                .ToArray();

            StringBuilder output = new StringBuilder();
            output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var projectName in projectNames)
            {
                output.AppendLine($"{projectName}");
            }

            return output.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(x => x.Employees)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    x.Manager,
                    x.Employees,
                })
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.DepartmentName)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach(var department in departments)
            {
                output.AppendLine($"{department.DepartmentName} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach(var employee in department.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return output.ToString().Trim();

        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .OrderBy(x => x.Name)
                .ToArray();

            StringBuilder output = new StringBuilder();

            foreach(var project in projects)
            {
                output.AppendLine($"{project.Name}");
                output.AppendLine($"{project.Description}");
                output.AppendLine($"{project.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return output.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {

            string[] departmentNames = new string[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            Employee[] employees = context.Employees
                .Where(x => departmentNames.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (Employee employee in employees)
            {
                employee.Salary *= 1.12m;
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle,
                        x.Salary
                    })
                    .Where(x => x.FirstName.ToLower().StartsWith("sa"))
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToArray();

            StringBuilder output = new StringBuilder();

                foreach (var employee in employees)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
                }

                return output.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            EmployeeProject[] rowsWithProjectTwo = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToArray();
            context.EmployeesProjects.RemoveRange(rowsWithProjectTwo);

            Project projectToDelete = context.Projects.Find(2);
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            Project[] projectList = context.Projects
                .Take(10)
                .ToArray();

            StringBuilder output = new StringBuilder();
            foreach (Project project in projectList)
            {
                output.AppendLine(project.Name);
            }

            return output.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            int[] addressesToDelete = context.Addresses
                .Where(x => x.Town.Name == "Seattle")
                .Select(x => x.AddressId)
                .ToArray();

            int[] employeesAddressesToNull = context.Employees
                .Where(x => x.AddressId.HasValue
                        && addressesToDelete.Contains(x.AddressId.Value))
                .Select(x => x.EmployeeId)
                .ToArray();

            foreach (Employee employee in context.Employees)
            {
                if (employeesAddressesToNull.Contains(employee.EmployeeId))
                {
                    employee.AddressId = null;
                }
            }

            Town townToDelete = context.Towns
                .FirstOrDefault(x => x.Name == "Seattle");
            context.Towns.Remove(townToDelete);
            context.Addresses.RemoveRange(context.Addresses.Where(x => x.Town.Name == "Seattle").ToList());

            context.SaveChanges();

            return $"{addressesToDelete.Length} addresses in Seattle were deleted";
        }
    }
}
