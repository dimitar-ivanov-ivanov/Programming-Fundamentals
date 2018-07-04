namespace Max_Sequence_Of_Increasing_Elements
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
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var maxList = new List<int>();
            var currentList = new List<int>();
            maxList.Add(arr[0]);
            currentList.Add(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > currentList[currentList.Count - 1])
                {
                    currentList.Add(arr[i]);
                }
                else
                {
                    if (currentList.Count > maxList.Count)
                    {
                        maxList = new List<int>(currentList);
                    }
                    currentList = new List<int>();
                    currentList.Add(arr[i]);
                }
            }
            if (currentList.Count > maxList.Count)
            {
                maxList = new List<int>(currentList);
            }

            Console.WriteLine(string.Join(" ", maxList));
        }
    }
}