namespace Middle_Nums
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            if (list.Count == 1)
            {
                Console.WriteLine(list[0]);
            }
            else if (list.Count % 2 != 0)
            {
                Console.WriteLine("{ " + list[list.Count / 2 - 1] + ", " + list[list.Count / 2] + ", " + list[list.Count / 2 + 1] + " }");
            }
            else
            {
                Console.WriteLine("{ " + list[list.Count / 2 - 1] + ", " + list[list.Count / 2] + " }");
            }
        }
    }
}