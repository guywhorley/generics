using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassesAndInterfaces
{

    // NOTE: example of creating a custom comparer. Two methods must be implmented.
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name + x.PayCode, y.Name+y.PayCode);
        }

        public int GetHashCode(Employee obj)
        {
            return (obj.Name + obj.PayCode).GetHashCode();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ComparingExample();
            //DoThingsExample();

            Console.WriteLine("Press the enter key");
            Console.ReadLine();
        }

        private static void ComparingExample()
        {
            var departments = new SortedDictionary<string, HashSet<Employee>>();

            // NOTE: Passing in a custom comparer
            departments.Add("Engineering", new HashSet<Employee>(new EmployeeComparer()));
            departments["Engineering"].Add(new Employee() { Name = "Chris", PayCode = "Salary" });
            departments["Engineering"].Add(new Employee() {Name = "Mike", PayCode = "Hourly"});
            departments["Engineering"].Add(new Employee() {Name = "Scott", PayCode = "Executive"});
            departments["Engineering"].Add(new Employee() {Name = "Scott", PayCode = "Executive"});

            departments.Add("Sales", new HashSet<Employee>(new EmployeeComparer()));
            departments["Sales"].Add(new Employee() { Name = "Tom", PayCode = "Salary" });
            departments["Sales"].Add(new Employee() { Name = "Susan", PayCode = "Salary" });
            departments["Sales"].Add(new Employee() { Name = "Susan", PayCode = "Salary" });
            departments["Sales"].Add(new Employee() { Name = "Susan", PayCode = "Hourly" });



            foreach (var department in departments)
            {
                Console.WriteLine($"Department: {department.Key}");
                foreach (var e in department.Value)
                {
                    Console.WriteLine($"\tEmployee: {e.Name} : {e.PayCode}");
                }
            }


        }

        private static void DoThingsExample()
        {
            IDoThings<string> dt = new DoOtherThings<string>();
            dt.DoIt("do it now...");
            dt.DoItAndLetMeKnow("do it and return a bool");
        }
    }
}
