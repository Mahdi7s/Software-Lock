using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using SoftwareSerial.Contracts;
using SoftwareSerial.Model;

namespace SoftwareSerial.Service
{
    [ServiceContract(Namespace = "www.virtualworld.com", SessionMode = SessionMode.Required)]
    public interface ISerialService
    {
        [OperationContract(IsOneWay = false)]        
        UserSerialValidationResult Validate(SerialValidationData serialValidationData);
    }
}
