namespace DebugginExamProblems
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
            var str = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                if (str == string.Empty || str.Length < pattern.Length)
                {
                    Console.WriteLine("No shake.");
                    break;
                }
                var first = str.IndexOf(pattern);
                var last = str.LastIndexOf(pattern);
                if (first == last) // we have only one occurance or both are -1
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                str = str.Remove(first, pattern.Length);
                if (str == string.Empty)
                {
                    Console.WriteLine("No shake.");
                    break;
                }
                str = str.Remove(last - pattern.Length, pattern.Length);
                Console.WriteLine("Shaked it.");
                pattern = pattern.Remove(pattern.Length / 2, 1);
            }

            Console.WriteLine(str);
        }
    }
}