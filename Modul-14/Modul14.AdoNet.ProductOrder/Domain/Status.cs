using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul14.AdoNet.ProductOrder.Domain
{
    public enum Status
    {
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Canceled,
        Done
    }
}
