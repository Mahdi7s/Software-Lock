using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SoftwareSerial.Model
{
    [DataContract]
    public enum UserSerialValidationResult
    {
        [EnumMember]
        IsValid,
        [EnumMember]
        IsUsedMoreThan,
        [EnumMember]
        PackageSerialIsNotInDb,
        [EnumMember]
        HardwareSerialNotMatches,
        [EnumMember]
        SoftwareNameNotMatchesPackageSerial
    }

    public static class UserSerialValidationResultExtensions
    {
        public static string ToReadableString(this UserSerialValidationResult validationResult)
        {
            return validationResult.ToString();
        }
    }
}
