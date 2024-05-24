using Modul5.Task3.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5.Task3.Tests.Stubs
{
    internal class UserStab : IUser
    {
        public IList<UserTask> Tasks { get; } = new List<UserTask>
        {
            new UserTask("task1"),
            new UserTask("task2"),
            new UserTask("task3")
        };
    }
}
