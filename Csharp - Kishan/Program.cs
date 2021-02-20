using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

// to run the program, dotnet run and then the directory you want to see, e.g. dotnet run c:\

namespace Csharp
{
    class Program
    {
        private static String directoryPath;

        static void Main(string[] args)
        {
            Program.directoryPath = args[0]; // initalising in a command-line arguement

            // a timer/schedule which itterates the program ever x seconds
            int seconds = 5 * 1000;
            var timer =
            new Timer(LogDetails, null, 0, seconds);
            Console.ReadKey();
        }


        private static String[] GetFileDetails(string directoryToSearch)
        {

            StringBuilder sb = new StringBuilder();
            //using a string builder which allow us to expand the number of characters in a string

            string[] filepaths = Directory.GetFiles(directoryToSearch, ".", SearchOption.AllDirectories);
            //An array of the full names (including paths) for the files in the specified directory

            foreach (string filepath in filepaths)// itterates through each element/file
            {
                FileInfo info = new FileInfo(filepath);
                Console.WriteLine(info.Name);
                sb.Append(info.Name); // appends the file names to string builder
                sb.Append("\n");
            }
            return new string[] { sb.ToString() };
        }

        public static void WriteToFile(String[] fileContents)
        {
            File.WriteAllLines("directory-details.txt", fileContents);
            // creates a file where the path is chosen as well the file contents
        }

        public static void LogDetails(object o)
        {
            Console.WriteLine("your dir path is" + directoryPath);
            GetFileDetails(directoryPath);
            Console.WriteLine("-------------------done--------------------");
            String[] files = GetFileDetails(directoryPath);
            //references the directory path via the argument we pass in the command-line
            Program.WriteToFile(files); // stores all the files from the specified directory into a text file


        }
    }

}
