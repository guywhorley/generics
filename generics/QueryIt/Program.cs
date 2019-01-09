using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());

            using (IRepository<Employee> employeeRepository
                = new SqlRepository<Employee>(new EmployeeDb()))
            {
                AddEmployees(employeeRepository);
                CountEmployees(employeeRepository);
            }
        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine($"Employee Count: {employeeRepository.FindAll().Count()}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee {Name = "Chris"});
            employeeRepository.Add(new Employee {Name = "Scott"});
            employeeRepository.Commit();
        }
    }
}
