using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUser_ClassLibrary
{
    public class UserGreeting
    {
        public static string HelloUser(string username)
        {
            string date = DateTime.Now.ToString();

            return $"{date} Hello, {username}";
        }
    }
}
