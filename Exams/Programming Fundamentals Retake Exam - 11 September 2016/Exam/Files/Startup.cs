namespace Files
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
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, SortedSet<File>>>();
            string folder;
            string extension;
            string[] args;

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                folder = args[0];
                var extensionAndSize = args[args.Length - 1].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                extension = extensionAndSize[0];

                var size = long.Parse(extensionAndSize[1]);
                args = extension.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                var end = args[args.Length - 1];

                var file = new File(extension, size);

                if (!dict.ContainsKey(folder))
                {
                    dict.Add(folder, new Dictionary<string, SortedSet<File>>());
                }
                if (!dict[folder].ContainsKey(end))
                {
                    dict[folder].Add(end, new SortedSet<File>());
                }

                if (dict[folder][end].Contains(file))
                {
                    dict[folder][end].Remove(file);
                }
                dict[folder][end].Add(file);
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            folder = args[2];
            extension = args[0];
            if (!dict.ContainsKey(folder) || !dict[folder].ContainsKey(extension) || dict[folder][extension].Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var item in dict[folder][extension])
                {
                    Console.WriteLine(item);
                }
            }
        }
    }

    public class File : IComparable<File>
    {
        public string name { get; set; }
        public int sum { get; set; }
        public long size { get; set; }

        public File(string name, long size)
        {
            this.name = name;
            this.size = size;
            for (int i = 0; i < name.Length; i++)
            {
                sum += name[i];
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} KB", name, size);
        }
        public override bool Equals(object obj)
        {
            var item = (File)obj;
            return this.Equals(item);
        }
        public override int GetHashCode()
        {
            return sum;
        }

        public int CompareTo(File other)
        {
            var byName = this.name.CompareTo(other.name);
            var bySize = other.size.CompareTo(this.size);
            if (bySize != 0)
            {
                return bySize;
            }
            return byName;
        }
    }
}