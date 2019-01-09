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
                //CountEmployees(employeeRepository);
                QueryEmployees(employeeRepository);
                DumpPeople(employeeRepository);

                //IEnumerable<Person> temp = employeeRepository.FindAll();

            }
        }

        // Using a read-only-repo technique for covariance which allows base types to be used instead
        // of the more derived type.
        private static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee: {employee.Name}");
            }
        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine($"Employee #1: {employee.Name}");
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
