namespace Modul5.Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter a line (type exit to quit): ");
            while (true)
            {
                string line = Console.ReadLine();

                if (line.ToLower().Trim() == "exit") break;

                try
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        throw new ArgumentException("The input line cannot be empty.");
                    }

                    Console.WriteLine(line[0]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
