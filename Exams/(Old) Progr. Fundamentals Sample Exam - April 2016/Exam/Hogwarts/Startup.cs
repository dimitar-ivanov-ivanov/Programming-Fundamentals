namespace Hogwarts
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var dict = new Dictionary<string, int>();
            dict.Add("Gryffindor", 0);
            dict.Add("Slytherin", 0);
            dict.Add("Ravenclaw", 0);
            dict.Add("Hufflepuff", 0);

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var sum = 0;
                for (int j = 0; j < args[0].Length; j++)
                {
                    sum += args[0][j];
                }
                for (int j = 0; j < args[1].Length; j++)
                {
                    sum += args[1][j];
                }

                var res = "";
                switch (sum % 4)
                {
                    case 0:
                        res = "Gryffindor";
                        dict["Gryffindor"]++;
                        break;
                    case 1:
                        res = "Slytherin";
                        dict["Slytherin"]++;
                        break;
                    case 2:
                        res = "Ravenclaw";
                        dict["Ravenclaw"]++;
                        break;
                    case 3:
                        res = "Hufflepuff";
                        dict["Hufflepuff"]++;
                        break;
                }

                Console.WriteLine("{0} {1}{2}{3}", res, sum, args[0][0], args[1][0]);
            }

            Console.WriteLine();
            Console.WriteLine("Gryffindor: {0}", dict["Gryffindor"]);
            Console.WriteLine("Slytherin: {0}", dict["Slytherin"]);
            Console.WriteLine("Ravenclaw: {0}", dict["Ravenclaw"]);
            Console.WriteLine("Hufflepuff: {0}", dict["Hufflepuff"]);
        }
    }
}