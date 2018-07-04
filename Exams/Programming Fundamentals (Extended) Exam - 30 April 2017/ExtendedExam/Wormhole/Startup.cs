namespace Wormhole
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var res = 0;
            var index = 0;

            while (index < arr.Length)
            {
                if (arr[index] != 0)
                {
                    var temp = arr[index];
                    arr[index] = 0;
                    index = temp;

                }
                res++;
                index++;
            }

            Console.WriteLine(res);
        }
    }
}