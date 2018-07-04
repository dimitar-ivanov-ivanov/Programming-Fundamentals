namespace CriticalShake
{
    using System;
    using System.Numerics;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var count = 0;
            long criticalBreakpoint = 0;

            var output = new StringBuilder();
            while (args[0] != "Break")
            {
                count++;
                var a = long.Parse(args[0]);
                var b = long.Parse(args[1]);
                var c = long.Parse(args[2]);
                var d = long.Parse(args[3]);
                var current = Math.Abs(a + b - c - d);

                if (criticalBreakpoint == 0)
                {
                    criticalBreakpoint = current;
                }
                else if (current != 0 && current != criticalBreakpoint)
                {
                    Console.WriteLine("Critical breakpoint does not exist.");
                    return;
                }


                output.Append(string.Format("Line: [{0}, {1}, {2}, {3}]\n", a, b, c, d));
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }


            if (output.Length != 0)
            {
                output = output.Remove(output.Length - 1, 1);
            }

            Console.WriteLine(output);
            Console.WriteLine("Critical Breakpoint: " + BigInteger.Pow(criticalBreakpoint, count) % count);
        }
    }
}