using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.Contracts
{
    [DataContract(Namespace = "www.SabaPardaz.com/contracts/SerialValidationContract")]
    public class SerialValidationContract
    {
        public SerialValidationContract()
        {
            EnablingSerial = string.Empty;
        }

        [DataMember]
        public UserSerialValidationResult Validation { get; set; }

        [DataMember]
        public string EnablingSerial { get; set; }
    }
}
