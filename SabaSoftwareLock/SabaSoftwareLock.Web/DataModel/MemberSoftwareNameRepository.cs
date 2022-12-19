using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SabaSoftwareLock.Web.Models;
using Mvc7S;
using SoftwareSerial.Model;

namespace SabaSoftwareLock.Web.DataModel
{
    public class MemberSoftwareNameRepository : Repository<MemberSoftwareName>
    {
        public MemberSoftwareNameRepository(LockWebDbContext dbContext) : base(dbContext) { }

        

        //public MemberSoftwareName GetForCurrentUser()
        //{

        //}
    }
}