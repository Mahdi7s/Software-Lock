using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SabaMediaLock.Locker.Controllers
{
    public interface IWich
    {        
        string WichValue { get; set; }
        object Others { get; set; }
    }
}
