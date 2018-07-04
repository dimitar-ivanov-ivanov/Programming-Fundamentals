namespace Largest_3_Numbers
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).Take(3)));
        }
    }
}