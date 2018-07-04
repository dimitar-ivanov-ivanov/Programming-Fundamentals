using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_average_etc
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new decimal[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine("Sum = {0}", arr.Sum());
            Console.WriteLine("Min = {0}", arr.Min());
            Console.WriteLine("Max = {0}", arr.Max());
            Console.WriteLine("Average = {0}", arr.Sum() / arr.Length);
        }
    }
}
