using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flattenphotos
{
    class Program
    {
        static List<string> copiedFiles = new List<string>();
        static List<string> ignoredFiles = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);

            if (args.Length < 2)
                Console.WriteLine("Need two directories!");

            DirectoryInfo source = new DirectoryInfo(args[0]);
            DirectoryInfo destination = new DirectoryInfo(args[1]);
            string rootPath = source.FullName;
            ProcessDirectory(rootPath, source, destination);
            Console.WriteLine("Copied Files : {0}", copiedFiles.Count);
            Console.WriteLine("Ignored Files : {0}", ignoredFiles.Count);
        }

        static void ProcessDirectory(string rootPath, DirectoryInfo source, DirectoryInfo destination)
        {
            foreach (DirectoryInfo directory in source.GetDirectories())
            {
                ProcessDirectory(rootPath, directory, destination);
            }

            foreach(FileInfo file in source.GetFiles())
            {
                string fullName = file.FullName;
                string simpleDestinationName = fullName.Replace(rootPath, "").Substring(1).Replace(@"\", "-");
                string fullDestinationName = Path.Combine(destination.FullName, simpleDestinationName);

                if (fullDestinationName.Contains(".jpg") || fullDestinationName.Contains(".jpeg") || fullDestinationName.Contains(".png"))
                {
                    if (File.Exists(fullDestinationName))
                    {
                        ignoredFiles.Add(fullDestinationName);
                    }
                    else
                    {
                        file.CopyTo(fullDestinationName);
                        copiedFiles.Add(fullDestinationName);
                    }
                }
            }
        }
    }
}
