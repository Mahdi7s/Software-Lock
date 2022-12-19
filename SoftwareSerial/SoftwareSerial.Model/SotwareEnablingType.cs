using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SoftwareSerial.Model
{
    [DataContract]
    public enum SotwareEnablingType
    {
        [EnumMember]
        Internet,
        [EnumMember]
        SMS,
        [EnumMember]
        IVR
    }
}
