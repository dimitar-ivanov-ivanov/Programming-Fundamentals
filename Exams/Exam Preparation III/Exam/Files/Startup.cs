
namespace Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            string extension = string.Empty;
            var dict = new Dictionary<string, Dictionary<string, HashSet<File>>>();
            string folder = string.Empty;
            string[] args;

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                var last = args[args.Length - 1].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                folder = args[0];
                extension = last[0];
                var size = long.Parse(last[1]);

                last = extension.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                var type = last[1];

                if (!dict.ContainsKey(folder))
                {
                    dict.Add(folder, new Dictionary<string, HashSet<File>>());
                }
                if (!dict[folder].ContainsKey(type))
                {
                    dict[folder].Add(type, new HashSet<File>());
                }

                var file = new File(size, extension);
                if (dict[folder][type].Contains(file))
                {
                    dict[folder][type].Remove(file);
                }

                dict[folder][type].Add(file);
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            extension = args[0];
            folder = args[2];

            if (!dict.ContainsKey(folder) || !dict[folder].ContainsKey(extension) || dict[folder][extension].Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                var sorted = dict[folder][extension].OrderByDescending(x => x.size).ThenBy(x => x.folder).ToList();
                foreach (var item in sorted)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

    public class File
    {
        public long size;
        public string folder;
        public int sum;

        public File(long size, string folder)
        {
            this.size = size;
            this.folder = folder;
            sum = 0;
            for (int i = 0; i < folder.Length; i++)
            {
                sum += folder[i];
            }
        }

        public override bool Equals(object obj)
        {
            var th = (File)obj;
            return th.folder.Equals(this.folder);
        }
        public override int GetHashCode()
        {
            return sum;
        }
        public override string ToString()
        {
            return string.Format("{0} - {1} KB", folder, size);
        }
    }
}
