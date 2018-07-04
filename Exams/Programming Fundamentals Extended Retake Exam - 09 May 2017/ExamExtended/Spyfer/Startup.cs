namespace Spyfer
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
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            for (int i = 1; i < arr.Count - 1; i++)
            {
                if (i == 1 && arr[i] == arr[i - 1])
                {
                    arr.RemoveAt(0);
                    i = 0;
                }
                else if (i == arr.Count - 2 && arr[i] == arr[i + 1])
                {
                    arr.RemoveAt(arr.Count - 1);
                    i = 0;
                }
                else if (arr[i] == arr[i - 1] + arr[i + 1])
                {
                    arr.RemoveAt(i + 1);
                    arr.RemoveAt(i - 1);
                    i = 0;
                }
            }

            if (arr.Count > 0)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
