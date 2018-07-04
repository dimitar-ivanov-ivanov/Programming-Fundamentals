namespace WormIpsum
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var line = Console.ReadLine();
            var regex = new Regex(@"([A-z][a-zA-Z .,?!-]+\.)");
            while (line != "Worm Ipsum")
            {
                var args = line.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

                if (args.Length == 1)
                {
                    args = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < args.Length; i++)
                    {
                        var count = new int['z' + 1];
                        for (int j = 0; j < args[i].Length; j++)
                        {
                            count[args[i][j]]++;
                        }
                        var found = false;
                        var res = '\0';
                        for (int j = 'A'; j <= 'z'; j++)
                        {
                            if (count[j] > 1)
                            {
                                found = true;
                                res = (char)j;
                                break;
                            }
                        }
                        if (found)
                        {
                            args[i] = new string(res, i == args.Length - 1 ? args[i].Length - 1 : args[i].Length);
                        }
                    }

                    var output = new StringBuilder(string.Join(" ", args));
                    if (output[output.Length - 1] != '.')
                    {
                        output.Append('.');
                    }
                    Console.WriteLine(output);
                }

                line = Console.ReadLine();
            }
        }
    }
}