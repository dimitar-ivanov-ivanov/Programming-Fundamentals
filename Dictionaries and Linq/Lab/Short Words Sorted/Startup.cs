namespace Short_Words_Sorted
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Execute();
        }

        private static void Execute()
        {
            var delimeters = new char[] { '\"', '\'', '.', ',', ' ', '\\', '/', ':', ';', '(', ')', ']', '[', '!', '?' };
            var words = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5)
                .Select(x => x.ToLower())
                .Distinct()
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", words));
        }
    }
}