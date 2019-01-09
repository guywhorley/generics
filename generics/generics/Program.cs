using System;
using System.Collections.Generic;

namespace generics {

    class Program
    {
        static void Main(string[] args)
        {
            //ThingExample();
            //ListExample();
            //QueueExample();
            //StackExample();
            //HashSetExample();
            //LinkedListExample();
            DictionaryExample();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static void DictionaryExample()
        {
            // NOTE: Dictionary key/val pairs; SortedDictionary will keep it all sorted :)
            var config = new SortedDictionary<string, string>
            //Dictionary<string, string> config = new Dictionary<string, string>
            {
                { "unicorn", "beasty" }, 
                { "name", "Chris" },
                { "dog", "Moka" },
                { "cat", "Bella" },
                { "Apple", "Granny Smith" }
            };

            var name = config.GetValueOrDefault("super");
            Console.WriteLine($"Missing key: {name}");
            Console.WriteLine($"{config["name"]}");

            foreach (var item in config)
            {
                Console.WriteLine($"Key:{item.Key} value:{item.Value}");
            }
        }

        private static void LinkedListExample()
        {
            // NOTE: LinkedList in constant time
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1024);
            list.AddFirst(21);
            list.AddLast(812);
            Console.WriteLine("Check the linked list...");
        }

        private static void HashSetExample()
        {
            // NOTE: HashSet - no duplicates allowed; unsorted; quick lookup (by hash); no index positions; SortedSet - keeps sorted
            HashSet<int> set = new HashSet<int>() {1024, 21, 5, 812, 21};
            SortedSet<int> sorted = new SortedSet<int> {1024, 21, 5, 812, 21};
            Console.WriteLine("Check the hashset for dups...");
        }

        private static void StackExample()
        {
            // NOTES: FILO
            Stack<string> plates = new Stack<string>();
            plates.Push("red");
            plates.Push("white");
            plates.Push("blue");
            Console.WriteLine("Examine stack now...");
        }

        private static void QueueExample()
        {
            // NOTE: Using a FIFO Queue<string> to manage a number of requests (FIFO)
            Queue<string> calls = new Queue<string>();
            calls.Enqueue("Steve: calling from Seattle");
            calls.Enqueue("Mary: calling from Tukwila");
            calls.Enqueue("Chris: calling from Renton");

            while (calls.Count > 0)
            {
                Console.WriteLine("Check calls...");
                // remove the top of the queue
                calls.Dequeue();
            }
        }

        private static void ListExample()
        {
            // NOTE: initializer syntax for instantiating a List<>
            List<int> intList = (new List<int> {1, 2, 3});
            // NOTE: one line LINQ for printing out an inumerable
            intList.ForEach(i => Console.WriteLine($"List<i>: {i}"));
        }

        private static void ThingExample()
        {
            Thing<int> intThing = new Thing<int>("Thing-2");
            intThing.Value = 123;
            Console.WriteLine($"Object={nameof(intThing)} Name={intThing.Name} Value=\"{intThing.Value}\"");

            Thing<string> stringThing = new Thing<string>("Thing-1");
            stringThing.Value = "Thing string value.";
            Console.WriteLine($"Object={nameof(stringThing)} Name={stringThing.Name} Value=\"{stringThing.Value}\"");
        }
    }

    // Generic THING class whereby I store a name and value.
    class Thing<T>
    {
       public Thing(String name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public T Value { get; set; }
    }
}
