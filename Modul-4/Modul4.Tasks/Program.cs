namespace Modul4.Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var folderPath = @"C:\";
            var filterFunc = new Func<FileSystemInfo, bool>(fsInfo =>
            {
               
                return (fsInfo.Attributes & FileAttributes.Directory) == 0;
            });

            var visitor = new FileSystemVisitor(folderPath, filterFunc);

            foreach (var fsInfo in visitor.Traverse())
            {
                Console.WriteLine(fsInfo.FullName);
            }

            Console.ReadLine();
        }
    }
}
