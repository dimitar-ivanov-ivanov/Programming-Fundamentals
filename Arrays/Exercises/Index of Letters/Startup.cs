namespace Index_of_letters
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
            var arr = Console.ReadLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0} -> {1}", arr[i], 25 - ('z' - arr[i]));
            }
        }
    }
}