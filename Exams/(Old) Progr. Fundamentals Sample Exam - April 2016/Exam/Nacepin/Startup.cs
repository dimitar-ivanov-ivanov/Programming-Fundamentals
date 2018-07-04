using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nacepin
{
   public class Startup
    {
       public static void Main(string[] args)
        {
            Execute();
        }
		
		public static void Execute()
        {
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var usPrice = double.Parse(Console.ReadLine());
            var usWeight = double.Parse(Console.ReadLine());
            var ukPrice = double.Parse(Console.ReadLine());
            var ukWeight = double.Parse(Console.ReadLine());
            var chPrice = double.Parse(Console.ReadLine());
            var chWeight = double.Parse(Console.ReadLine());


            var us = usPrice / 0.58 / usWeight;
            var uk = ukPrice / 0.41 / ukWeight;
            var ch = chPrice * 0.27 / chWeight;

            var max = Math.Max(us, Math.Max(uk, ch));
            var min = Math.Min(us, Math.Min(uk, ch));
            var store = "";

            if (min == us)
            {
                store = "United States";
            }
            else if (min == uk)
            {
                store = "United Kingdom";
            }
            else
            {
                store = "Chinese";
            }

            Console.WriteLine("{0} store. {1:F2} lv/kg", store, min);
            Console.WriteLine("Difference {0:F2} lv/kg", max - min);
        }
    }
}
