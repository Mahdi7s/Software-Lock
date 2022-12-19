using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Model
{
    public class SoftwareInfo
    {
        [Key]
        [Browsable(false)]
        public int SoftwareInfoId { get; set; }

        [DisplayName("نام کامل برنامه")]
        public string SoftwareName { get; set; }
        [DisplayName("نام مختصر برنامه")]
        public string SoftwareUniqueName { get; set; }

        public virtual List<SerialTrackingCode> SerialTrackingCodes { get; set; }
    }
}
