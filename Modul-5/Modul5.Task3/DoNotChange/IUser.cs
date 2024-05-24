using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5.Task3.DoNotChange
{
    public interface IUser
    {
        IList<UserTask> Tasks { get; }
    }
}
