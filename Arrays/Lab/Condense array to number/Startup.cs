namespace Condense_array_to_number
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
            var list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (list.Count != 1)
            {
                var newList = new List<int>(list.Count);

                for (int i = 0; i < list.Count - 1; i++)
                {
                    newList.Add(list[i] + list[i + 1]);
                }
                list = newList.ToList();
            }
            Console.WriteLine(list[0]);
        }
    }
}