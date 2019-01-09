using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassesAndInterfaces
{

    // NOTE: example of creating a custom comparer. Two methods must be implmented.
    public class EmployeeComparer : IEqualityComparer<Employee>,
                                    IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name + x.PayCode, y.Name+y.PayCode);
        }

        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name + x.PayCode, y.Name+y.PayCode);
        }

        public int GetHashCode(Employee obj)
        {
            return (obj.Name + obj.PayCode).GetHashCode();
        }
    }

    // creating a custom collection to help clean up program class
    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName,  new SortedSet<Employee>(new EmployeeComparer()));
            }

            this[departmentName].Add(employee);
            return this; // return self for fluent syntax
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
            // SortedSet sorts by KEY
            var departments = new DepartmentCollection();

            departments
                .Add("Engineering", new Employee() { Name = "Chris", PayCode = "Salary" })
                .Add("Engineering", new Employee() {Name = "Mike", PayCode = "Hourly"})
                .Add("Engineering", new Employee() {Name = "Scott", PayCode = "Executive"})
                .Add("Engineering", new Employee() {Name = "Scott", PayCode = "Executive"})
                .Add("Sales", new Employee() { Name = "Tom", PayCode = "Salary" })
                .Add("Sales", new Employee() { Name = "Susan", PayCode = "Salary" })
                .Add("Sales", new Employee() { Name = "Susan", PayCode = "Salary" })
                .Add("Sales", new Employee() { Name = "Susan", PayCode = "Hourly" });

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
