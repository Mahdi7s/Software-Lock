using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SabaSoftwareLock.Web.Models
{
    public class SmsReport
    {
        public int SmsReportId { get; set; }

        public string PhoneNumber { get; set; }
        public int InvalidSmsCount { get; set; }
    }
}