namespace RageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var str = Console.ReadLine();
            var builder = new StringBuilder();
            var regex = new Regex(@"\d+");
            var matches = regex.Matches(str);
            var arr = regex.Split(str).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                var upper = arr[i].ToUpper();
                var count = int.Parse(matches[i].Value);
                for (int j = 0; j < count; j++)
                {
                    builder.Append(upper);
                }
            }

            var distinct = builder.ToString().Distinct().Count();
            Console.WriteLine("Unique symbols used: {0}", distinct);
            Console.WriteLine(builder);
        }
    }
}
