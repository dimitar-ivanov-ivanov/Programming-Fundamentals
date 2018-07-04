namespace VechilePark
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
            var list = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var sold = 0;
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("End of customers!"))
            {
                var type = args[0][0].ToString().ToLower()[0];
                var seats = int.Parse(args[2]);
                var toRemove = type.ToString() + seats.ToString();

                var originalCount = list.Count;
                list.Remove(toRemove);
                if (list.Count != originalCount)
                {
                    sold++;
                    Console.WriteLine("Yes, sold for {0}$", type * seats);
                }
                else
                {
                    Console.WriteLine("No");
                }
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Vehicles left: {0}", string.Join(", ", list));
            Console.WriteLine("Vehicles sold: {0}", sold);
        }
    }
}