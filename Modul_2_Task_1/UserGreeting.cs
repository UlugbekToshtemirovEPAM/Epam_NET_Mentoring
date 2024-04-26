using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_2_Task_1
{
    internal static class UserGreeting
    {
        public static string HelloUser()
        {
            Console.Write("Please enter your name: ");
            var username = Console.ReadLine();

            return $"Hello, {username}";
        }
    }
}
