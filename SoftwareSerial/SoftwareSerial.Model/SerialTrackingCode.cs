using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Model
{
    public class SerialTrackingCode
    {
        public int SerialTrackingCodeId { get; set; }
        [ForeignKey("SoftwareInfo")]
        public int SoftwareInfoId { get; set; }
        
        public int SerialUsingCount { get; set; }        
        public DateTime CreatedDate { get; set; }

        [ForeignKey("SoftwareInfoId")]
        public SoftwareInfo SoftwareInfo { get; set; }

        public virtual List<UserSerial> UserSerials { get; set; }
    }
}
