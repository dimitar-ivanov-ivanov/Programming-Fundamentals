namespace Print_part_of_ascii_table
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}