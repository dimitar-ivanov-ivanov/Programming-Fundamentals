namespace EnduranceRally
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var fuel = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => -decimal.Parse(x)).ToArray();

            var n = fuel.Length;
            var checkpoints = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x))
                              .Where(x => x >= 0 && x < n).ToArray();

            for (int i = 0; i < checkpoints.Length; i++)
            {
                var val = checkpoints[i];
                fuel[val] = -fuel[val];
            }

            for (int i = 0; i < names.Length; i++)
            {
                decimal sum = names[i][0];
                int j = 0;
                for (j = 0; j < n; j++)
                {
                    sum += fuel[j];
                    if (sum <= 0)
                    {
                        break;
                    }
                }

                if (sum <= 0)
                {
                    Console.WriteLine("{0} - reached {1}", names[i], j);
                }
                else
                {
                    Console.WriteLine("{0} - fuel left {1:F2}", names[i], sum);
                }
            }
        }
    }
}