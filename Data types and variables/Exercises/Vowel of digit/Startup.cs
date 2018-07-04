namespace Vowel_of_digit
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
            var vowels = "aeiou";
            var a = Console.ReadLine().ToLower();
            if (a[0] >= 'a' && a[0] <= 'z' && vowels.Contains(a[0]))
            {
                Console.WriteLine("vowel");
            }
            else if (a[0] >= '0' && a[0] <= '9')
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
