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
                DumpPeople(employeeRepository); // covariance - get more generic 
                AddManager(employeeRepository); // contravariance - get more explicit
                DumpPeople(employeeRepository); // covariance - get more generic 

                //IEnumerable<Person> temp = employeeRepository.FindAll();
                Console.WriteLine("Enter to continue");
                Console.ReadLine();

            }
        }

        private static void AddManager(IWriteOnlyRepository<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager {Name = "Jakob"});
            employeeRepository.Commit();
        }

        // NOTE: Covariance Example (using base class)
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
