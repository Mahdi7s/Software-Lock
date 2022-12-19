using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SoftwareSerial.Contracts;
using SoftwareSerial.DataModel;
using SoftwareSerial.Model;
using SoftwareSerial.Server;

namespace SoftwareSerial.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class SerialService : ISerialService
    {
        public UserSerialValidationResult Validate(SerialValidationData serialValidationData)
        {
            if(string.IsNullOrEmpty(serialValidationData.ConnectionString))
                throw new FaultException(new FaultReason("ConnectionString is null or empty."));
            if(string.IsNullOrEmpty(serialValidationData.GeneratedSerial))
                throw new FaultException(new FaultReason("GeneratedSerial is null or empty."));
            if(string.IsNullOrEmpty(serialValidationData.PackageSerial))
                throw new FaultException(new FaultReason("PackageSerial is null or empty."));
            if(string.IsNullOrEmpty(serialValidationData.EncryptionPassword))
                throw new FaultException(new FaultReason("EncryptionPassword is null or empty."));

            try
            {                
                SoftwareSerialServer.Initialize(serialValidationData.ConnectionString, DbInitializationType.CreateIfNotExists, serialValidationData.EncryptionPassword);
                    return
                        SoftwareSerialServer.Shared.ValidateUserSerial(serialValidationData.SoftwareName, serialValidationData.PackageSerial,
                                                                       serialValidationData.GeneratedSerial);
            }
            catch(Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
    }
}
