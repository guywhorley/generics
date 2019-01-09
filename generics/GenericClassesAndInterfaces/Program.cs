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
            IDoThings<string> dt = new DoOtherThings<string>();
            dt.DoIt("do it now...");
            dt.DoItAndLetMeKnow("do it and return a bool");

            Console.WriteLine("Press the enter key");
            Console.ReadLine();
        }
    }
}
