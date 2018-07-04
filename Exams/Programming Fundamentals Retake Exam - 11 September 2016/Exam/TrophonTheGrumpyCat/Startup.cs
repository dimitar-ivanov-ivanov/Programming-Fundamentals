namespace TrophonTheGrumpyCat
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
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();
            var entryPoint = int.Parse(Console.ReadLine());
            var typePrice = Console.ReadLine();
            var typeNumber = Console.ReadLine();

            var left = GetSum(-1, typePrice, typeNumber, entryPoint, arr);
            var right = GetSum(1, typePrice, typeNumber, entryPoint, arr);

            if (left >= right)
            {
                Console.WriteLine("Left - {0}", left);
            }
            else
            {
                Console.WriteLine("Right - {0}", right);
            }
        }

        private static long GetSum(int val, string typePrice, string typeNumber, int entryPoint, int[] arr)
        {
            long sum = 0;

            for (int i = entryPoint + val; i >= 0 && i < arr.Length; i += val)
            {
                if (typePrice == "cheap" && arr[i] < arr[entryPoint])
                {
                    if ((typeNumber == "positive" && arr[i] > 0) ||
                        (typeNumber == "negative" && arr[i] < 0) ||
                        (typeNumber == "all"))
                    {
                        sum += arr[i];
                    }
                }
                else if (typePrice == "expensive" && arr[i] >= arr[entryPoint])
                {
                    if ((typeNumber == "positive" && arr[i] > 0) ||
                        (typeNumber == "negative" && arr[i] < 0) ||
                        (typeNumber == "all"))
                    {
                        sum += arr[i];
                    }
                }
            }
            return sum;
        }
    }
}