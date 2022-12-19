using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SoftwareSerial.Contracts
{
    [DataContract]
    public class SerialServiceDataContract
    {
        [DataMember]
        public string PackageSerial { get; set; }
        [DataMember]
        public string AutomatedHardwareSerial { get; set; }
    }
}
