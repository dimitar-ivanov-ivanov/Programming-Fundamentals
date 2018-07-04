namespace TheaThePhotographer
{
    using System;
    using System.Globalization;
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
            var n = double.Parse(Console.ReadLine());
            var filterTime = double.Parse(Console.ReadLine());
            var filterFactor = double.Parse(Console.ReadLine());

            var uploadTime = double.Parse(Console.ReadLine());
            var filteredPictures = Math.Ceiling(n * filterFactor / 100);
            var totalTime = Math.Ceiling(n * filterTime) + Math.Ceiling(filteredPictures * uploadTime);
            var timespan = TimeSpan.FromSeconds(totalTime);
            Console.WriteLine("{0}:{1:D2}:{2:D2}:{3:D2}", timespan.Days, timespan.Hours, timespan.Minutes, timespan.Seconds);
        }
    }
}