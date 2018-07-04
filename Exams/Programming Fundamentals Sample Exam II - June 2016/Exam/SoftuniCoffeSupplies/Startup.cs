namespace SoftuniCoffeSupplies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var delimeters = Console.ReadLine().Split(' ');
            var personCoffe = new Dictionary<string, string>();
            var coffeCapacity = new Dictionary<string, int>();
            var args = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("end of info"))
            {
                var capacity = 0;
                var first = args[0];
                var second = args[1];
                if (int.TryParse(second, out capacity))
                {
                    if (!coffeCapacity.ContainsKey(first))
                    {
                        coffeCapacity.Add(first, 0);
                    }
                    coffeCapacity[first] += capacity;
                }
                else
                {
                    personCoffe.Add(first, second);
                    if (!coffeCapacity.ContainsKey(second))
                    {
                        coffeCapacity.Add(second, 0);
                    }
                }
                args = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            }

            var toRemove = new HashSet<string>();
            foreach (var person in personCoffe)
            {
                if (coffeCapacity[person.Value] == 0)
                {
                    toRemove.Add(person.Key);
                }
            }

            foreach (var person in toRemove)
            {
                Console.WriteLine("Out of {0}", personCoffe[person]);
                if (coffeCapacity.ContainsKey(personCoffe[person]))
                {
                    coffeCapacity.Remove(personCoffe[person]);
                }
                personCoffe.Remove(person);
            }

            args = Console.ReadLine().Split(' ');
            while (!string.Join(" ", args).Equals("end of week"))
            {
                var first = args[0];
                var second = int.Parse(args[1]);
                if (personCoffe.ContainsKey(first))
                {
                    var coffe = personCoffe[first];
                    var capacity = coffeCapacity[coffe];
                    if (second >= capacity) //>=
                    {
                        coffeCapacity.Remove(coffe);
                        personCoffe.Remove(first);
                        Console.WriteLine("Out of {0}", coffe);
                    }
                    else
                    {
                        coffeCapacity[coffe] -= second;
                    }
                }

                args = Console.ReadLine().Split(' ');
            }

            coffeCapacity = coffeCapacity.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            personCoffe = personCoffe.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Coffee Left:");
            foreach (var coffe in coffeCapacity)
            {
                Console.WriteLine("{0} {1}", coffe.Key, coffe.Value);
            }

            Console.WriteLine("For:");
            foreach (var person in personCoffe)
            {
                Console.WriteLine("{0} {1}", person.Key, person.Value);
            }
        }
    }
}