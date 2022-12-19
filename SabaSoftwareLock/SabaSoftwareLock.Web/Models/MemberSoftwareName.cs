using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabaSoftwareLock.Web.Models
{
    public class MemberSoftwareName
    {
        public int MemberSoftwareNameId { get; set; }

        public int MemberId { get; set; }
        public int TrackingId { get; set; }
        public string SoftwareName { get; set; }
    }
}