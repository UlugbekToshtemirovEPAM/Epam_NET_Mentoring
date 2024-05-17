using System.Threading.Channels;

namespace Modul4.Task2vs3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"C:\";

                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Please provide a valid directory path.");
                    return;
                }

                var visitor = new FileSystemVisitor(path, fsInfo => fsInfo.Extension == ".cs");

                visitor.Start += (s, e) => Console.WriteLine("Search started...");
                visitor.Finish += (s, e) => Console.WriteLine("Search finished.");
                visitor.FileFound += (s, e) =>
                {
                    Console.WriteLine($"File found: {e.FileSystemInfo.FullName}");
                    // e.Abort = true;
                };

                visitor.DirectoryFound += (s, e) =>
                {
                    Console.WriteLine($"Directory found: {e.FileSystemInfo.FullName}");
                    // e.Exclude = true;
                };

                visitor.FilteredFileFound += (s, e) => Console.WriteLine($"Filtered file found: {e.FileSystemInfo.FullName}");
                visitor.FilteredDirectoryFound += (s, e) => Console.WriteLine($"Filtered directory found: {e.FileSystemInfo.FullName}");

                foreach (var fileSystem in visitor.Traverse())
                {
                    Console.WriteLine(fileSystem.FullName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
