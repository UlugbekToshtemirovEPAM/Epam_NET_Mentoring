using Modul5.Task3.DoNotChange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5.Task3.Tests.Stubs
{
    internal class UserDaoStub : IUserDao
    {
        private readonly IDictionary<int, IUser> _data = new Dictionary<int, IUser>
        {
            { 1, new UserStab() }
        };

        public IUser GetUser(int id)
        {
            if (_data.ContainsKey(id))
                return _data[id];
            return null;
        }
    }
}
