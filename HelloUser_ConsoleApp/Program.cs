using HelloUser_ClassLibrary;

namespace HelloUser_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your name: ");
            var username = Console.ReadLine();

            string result = UserGreeting.HelloUser(username);
            Console.WriteLine(result);
        }
    }
}
