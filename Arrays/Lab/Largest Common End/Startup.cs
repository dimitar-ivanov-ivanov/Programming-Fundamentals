namespace Largest_Common_End
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine().Split(' ');
            var arr2 = Console.ReadLine().Split(' ');

            var beginning = new List<string>();
            var end = new List<string>();

            for (int i = 0; i < arr.Length && i < arr2.Length; i++)
            {
                if (arr[i] == arr2[i])
                {
                    beginning.Add(arr[i]);
                }
                else
                {
                    break;
                }
            }

            for (int i = arr.Length - 1, j = arr2.Length - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (arr[i] == arr2[j])
                {
                    end.Add(arr[i]);
                }
                else
                {
                    break;
                }
            }

            if (beginning.Count >= end.Count)
            {
                Console.WriteLine(beginning.Count);
            }
            else if (end.Count > beginning.Count)
            {
                Console.WriteLine(end.Count);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
