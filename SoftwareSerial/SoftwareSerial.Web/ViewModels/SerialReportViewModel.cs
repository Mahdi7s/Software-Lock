using System.Collections.Generic;
using SoftwareSerial.Model;

namespace SoftwareSerial.Web.ViewModels
{
    public class SerialReportViewModel
    {
        public IEnumerable<UserSerial> Result { get; set; }
        public ReportSearch Search { get; set; }

        public sealed class ReportSearch
        {
            public string skey { get; set; }
            public string sval { get; set; }
            public int pageSize { get; set; }
            public int page { get; set; }
        }
    }
}