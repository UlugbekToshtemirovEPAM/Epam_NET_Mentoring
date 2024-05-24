using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5.Task3.DoNotChange
{
    public interface IResponseModel
    {
        void AddAttribute(string key, string value);

        string GetAttribute(string key);
    }
}
