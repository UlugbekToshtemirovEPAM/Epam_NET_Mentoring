using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul12.Task
{
    public interface ICache
    {
        void Store(string key, IDocument item);
        IDocument Retrieve(string key);
        bool Has(string key);
        void Remove(string key);
    }
}
