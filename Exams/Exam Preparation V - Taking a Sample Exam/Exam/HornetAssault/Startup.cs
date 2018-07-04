namespace HornetAssault
{
    using System;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var hives = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var hornets = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).Reverse().ToList();

            long hornetSum = hornets.Sum();
            long original = hornetSum;

            for (int i = 0; i < hives.Count; i++)
            {
                if (hives[i] >= hornetSum)
                {
                    hives[i] -= hornetSum;
                    original -= hornets[hornets.Count - 1];
                    hornetSum = original;
                    hornets.RemoveAt(hornets.Count - 1);
                    if (hornets.Count == 0)
                    {
                        break;
                    }
                }
                else
                {
                    hives[i] = 0;
                }
            }

            var res = new StringBuilder();
            for (int i = 0; i < hives.Count; i++)
            {
                if (hives[i] != 0)
                {
                    res.Append(hives[i] + " ");
                }
            }

            if (res.Length == 0)
            {
                for (int i = hornets.Count - 1; i >= 0; i--)
                {
                    res.Append(hornets[i] + " ");
                }
            }

            if (res.Length != 0)
            {
                res = res.Remove(res.Length - 1, 1);
            }
            Console.WriteLine(res);
        }
    }
}