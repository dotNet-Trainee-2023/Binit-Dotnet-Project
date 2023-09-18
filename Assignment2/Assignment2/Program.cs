﻿using System.Threading.Tasks.Dataflow;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  First Name, Last Name,Email,Phone,Gender,Age,Job Title, Years Of Experience, Salary, Department

            List<Employee> employees = new();
            var csvFileText = File.ReadAllLines(@"D:\employees.csv").ToList();
            foreach (var csvEmployee in csvFileText
                .Select((x, i) => new { Value = x, Index = i }))
            // workaround for foreach loop not having an index
            // https://stackoverflow.com/a/521705
            {
                if (csvEmployee.Index == 0)
                {
                    continue;
                }
                string[] values = csvEmployee.Value.Split(',');
                if (values.Length == 10)
                {
                    Employee employee = new Employee
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        Email = values[2],
                        Phone = values[3],
                        Gender = values[4],
                        Age = values[5],
                        JobTitle = values[6],
                        YoE = values[7],
                        Salary = values[8],
                        Department = values[9]
                    };
                    employees.Add(employee);
                }
                else
                {
                    Console.WriteLine("Employee columns mismatch");
                }

            }

            // LINQ Expressions
            // Group By Department
            var groupByDepartment = employees.GroupBy(e => e.Department);
            foreach (var group in groupByDepartment)
            {
                Console.WriteLine($"Department:  {group.Key}");
                foreach (var employee in group)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} | {employee.JobTitle} | {employee.Department} ");
                }
                Console.WriteLine();

            }
            Console.WriteLine();

            // Highest Salary earning project manager
            var projectManager = employees.Where(e => e.JobTitle == "Project Manager")
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();
            Console.WriteLine($"Highest salary earning Project Manager is {projectManager.FirstName} {projectManager.LastName} with salary {projectManager.Salary}");
            Console.WriteLine();

            // Most Experienced Web developer
            var webDeveloper = employees.Where(e => e.JobTitle == "Web Developer")
                .OrderByDescending(e=>e.YoE) .FirstOrDefault();
            Console.WriteLine($"Most Experienced web Developer is {webDeveloper.FirstName} {webDeveloper.LastName} with {webDeveloper.YoE} years of experience");
            Console.WriteLine();

            // Average Salary of all job title
            var jobGroup = employees.GroupBy(e => e.JobTitle);
            foreach(var group in jobGroup)
            {
                string jobTitle = group.Key;
                decimal averageSalary = group.Average(e => (decimal.Parse(e.Salary)));

                Console.WriteLine($"Job Title: {jobTitle}");
                Console.WriteLine($"Average Salary: {averageSalary}");
                Console.WriteLine();
            }

            // Total number of male and female employees
            var employeeCount = employees.GroupBy(e => e.Gender);
            foreach(var group in employeeCount)
            {
                var count = group.Count();
                Console.WriteLine($"Number of {group.Key} Employees: {count} ");
            }
        }

    }
}
