using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SabaSoftwareLock.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISiteService" in both code and config file together.
    [ServiceContract]
    public interface ISiteService
    {
        [OperationContract]
        bool CanLogin(string username, string password);

        [OperationContract]
        bool IsSoftwareUniqueNameValid(string username, string password, string uniqueName);
    }
}
