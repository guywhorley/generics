using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassesAndInterfaces
{
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
            var departments = new SortedDictionary<string, List<Employee>>();
            departments.Add("Engineering", new List<Employee>());
            departments["Engineering"].Add(new Employee() { Name = "Chris", PayCode = "Salary" });
            departments["Engineering"].Add(new Employee() {Name = "Mike", PayCode = "Hourly"});
            departments["Engineering"].Add(new Employee() {Name = "Scott", PayCode = "Executive"});

            departments.Add("Sales", new List<Employee>());
            departments["Sales"].Add(new Employee() { Name = "Tom", PayCode = "Salary" });
            departments["Sales"].Add(new Employee() { Name = "Susan", PayCode = "Salary" });

            foreach (var department in departments)
            {
                Console.WriteLine($"Department: {department.Key}");
                foreach (var e in department.Value)
                {
                    Console.WriteLine($"\tEmployee: {e.Name} ");
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
