using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassesAndInterfaces
{

    // this would be the base interface
    interface IDoThings<T> // : IEnumerable<T>
    {
        bool IsValid { get; }

        void DoIt(T value);

        bool DoItAndLetMeKnow(T value);
    }

    // this class could be one of many repositories
    public class DoOtherThings<T> : IDoThings<T>
    {
        public bool IsValid { get; }
        public void DoIt(T value)
        {
            Console.WriteLine($"Doing OTHER things now... [{value}]");
        }

        public bool DoItAndLetMeKnow(T value)
        {
            Console.WriteLine($"Doing OTHER things now and returning true [{value}]");
            return true;
        }
    }

    // another repository
    public class DoThings<T> : IDoThings<T>
    {
        public bool IsValid { get; }
        public void DoIt(T value)
        {
            Console.WriteLine($"Doing things now... [{value}]");
        }

        public bool DoItAndLetMeKnow(T value)
        {
            Console.WriteLine($"Doing things now and returning true [{value}]");
            return true;
        }
    }
}
