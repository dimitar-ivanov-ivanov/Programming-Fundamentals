namespace Odd_Occurances
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
            var arr = Console.ReadLine().Split(' ');
            var a = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!a.ContainsKey(arr[i]))
                {
                    if (a.ContainsKey(arr[i].ToLower()))
                    {
                        a[arr[i].ToLower()]++;
                    }
                    else if (a.ContainsKey(arr[i].ToUpper()))
                    {
                        a[arr[i].ToUpper()]++;
                    }
                    else
                    {
                        a.Add(arr[i], 1);
                    }
                }
                else
                {
                    a[arr[i]]++;
                }
            }

            Console.WriteLine(string.Join(", ", a.Where(x => x.Value % 2 != 0).ToDictionary(x => x.Key, x => x.Value).Keys).ToLower());
        }
    }
}