using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using SoftwareSerial.Model;

namespace SoftwareSerial.Contracts
{
    [ServiceContract(Namespace = "http://www.sabapardaz.com/services/ISerialService")]
    public interface ISerialService
    {
        [OperationContract(IsOneWay = false)]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "GET", UriTemplate = "Validate?packageSerial={packageSerial}&automatedHardwareSerial={automatedHardwareSerial}")]
        SerialValidationContract Validate(string softwareName, string packageSerial, string automatedHardwareSerial);
    }
}
