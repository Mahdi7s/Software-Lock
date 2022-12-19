using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SabaSoftwareLock.DataModel;
using SabaSoftwareLock.Web.Membership;

namespace SabaSoftwareLock.Web
{
    [ServiceBehavior(IncludeExceptionDetailInFaults=true, InstanceContextMode= InstanceContextMode.PerSession, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class SiteService : ISiteService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public bool CanLogin(string username, string password)
        {
            var user = _unitOfWork.MemberRep.GetByUserName(username);
            return (user != null && user.IsPasswordEqualsTo(password));            
        }

        public bool IsSoftwareUniqueNameValid(string username, string password, string uniqueName)
        {
            var user = _unitOfWork.MemberRep.GetByUserName(username, true);
            return ((user != null && user.IsPasswordEqualsTo(password)) && (user.SoftwareInfoes.Any(x => x.SoftwareUniqueName.Equals(uniqueName))));
        }
    }
}
