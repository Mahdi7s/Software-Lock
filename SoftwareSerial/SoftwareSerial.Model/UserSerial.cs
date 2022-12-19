using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftwareSerial.Model
{
    public class UserSerial
    {
        public UserSerial()
        {
            UsedCount = 0;            
        }

        public int UserSerialId { get; set; }

        public int PackageSerialId { get; set; }
        public int UserSerialStateId { get; set; }
        public int SerialTrackingCodeId { get; set; }

        public int UsedCount { get; set; }

        public PackageSerial PackageSerial { get; set; }
        public UserSerialState UserSerialState { get; set; }

        public virtual List<HardwareSerial> HardwareSerials { get; set; }        
        public virtual SerialTrackingCode SerialTrackingCode { get; set; }
    }
}
