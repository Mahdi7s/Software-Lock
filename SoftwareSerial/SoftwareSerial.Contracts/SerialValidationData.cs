using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SoftwareSerial.Contracts
{
    [DataContract(IsReference = true)]
    public class SerialValidationData
    {
        [DataMember]
        public string ConnectionString { get; set; }
        [DataMember]
        public string PackageSerial { get; set; }
        [DataMember]
        public string GeneratedSerial { get; set; }
        [DataMember]
        public string EncryptionPassword { get; set; }
        [DataMember]
        public string SoftwareName { get; set; }
    }
}
