namespace CompanyDB.ConsoleClient
{
    using System;
    using System.Linq;

    using Models;
    using RandomGeneration;

    public class CompanyDbFeeder
    {
        private CompanyEntities context;
        private RandomValueGenerator generator;

        public CompanyDbFeeder(CompanyEntities context)
        {
            this.context = context;
            this.generator = RandomValueGenerator.Instance();
        }

        public void Feed()
        {
            this.FeedDepartments(100);
            this.FeedEmployees(5000);
            this.FeedProjects(1000);
        }

        private void FeedDepartments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string name = this.generator.GenerateString(30);
                Department department = new Department
                {
                    Name = name
                };

                this.context.Departments.Add(department);
                if ((i & 511) == 0)
                {
                    this.context.SaveChanges();
                }
            }

            this.context.SaveChanges();
        }

        private void FeedProjects(int count)
        {
            int employeeCount = this.context.Employees.Count() - 1;
            for (int i = 0; i < count; i++)
            {
                string name = this.generator.GenerateString(30);
                Project project = new Project
                {
                    Name = name
                };

                for (int j = 0; j < 5; j++)
                {
                    int employeeId = this.generator.GenerateInteger(1, employeeCount);
                    Employee projectEmployee = this.context.Employees.Find(employeeId); 
                    int dayDifference = this.generator.GenerateInteger(1, 500);
                    DateTime start = DateTime.Now.AddDays(-dayDifference);
                    DateTime end = DateTime.Now.AddDays(dayDifference);

                    project.EmployeesProjects.Add(new EmployeesProject
                    {
                        Employee = projectEmployee,
                        StartDate = start,
                        EndDate = end
                    });
                }

                this.context.Projects.Add(project);
                if ((i & 511) == 0)
                {
                    this.context.SaveChanges();
                }
            }

            this.context.SaveChanges();
        }

        private void FeedEmployees(int count)
        {
            int employeesNoManager = (int)(count * 0.05);
            int departmentCount = this.context.Departments.Count() - 1;

            for (int i = 0; i < count; i++)
            {
                string firstName = this.generator.GenerateString(20);
                string lastName = this.generator.GenerateString(20);
                decimal salary = this.generator.GenerateInteger(50000, 200000);
                int departmentId = this.generator.GenerateInteger(1, departmentCount);
                Department employeeDepartment = this.context.Departments.Find(departmentId);

                Employee employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    YearSalary = salary,
                    Department = employeeDepartment
                };

                if (i > employeesNoManager)
                {
                    int manager = this.generator.GenerateInteger(1, employeesNoManager - 1);
                    employee.ManagerID = manager;
                }

                this.FeedReports(50, employee);
                this.context.Employees.Add(employee);
                if ((i & 511) == 0)
                {
                    this.context.SaveChanges();
                }
            }

            this.context.SaveChanges();
        }

        private void FeedReports(int count, Employee employee)
        {
            for (int i = 0; i < count; i++)
            {
                int dayDifference = this.generator.GenerateInteger(1, 500);
                if ((i & 1) == 0)
                {
                    dayDifference = -dayDifference;
                }

                DateTime reportTime = DateTime.Now.AddDays(dayDifference);
                employee.Reports.Add(new Report
                {
                    Time = reportTime
                });
            }
        }
    }
}