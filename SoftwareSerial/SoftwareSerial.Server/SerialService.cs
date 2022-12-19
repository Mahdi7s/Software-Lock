using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Hosting;
using System.Xml.Serialization;
using SoftwareSerial.Contracts;
using SoftwareSerial.DataModel;
using SoftwareSerial.Model;

namespace SoftwareSerial.Server
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SerialService : ISerialService
    {
        public SerialValidationContract Validate(string softwareName, string packageSerial, string automatedHardwareSerial)
        {
            SoftwareSerial.Server.SoftwareSerialServer.Initialize();
            var retval = new SerialValidationContract();
            try
            {
                retval.Validation = SoftwareSerialServer.Shared.ValidateUserSerial(softwareName, packageSerial, automatedHardwareSerial);
                if(retval.Validation == UserSerialValidationResult.IsValid)
                {
                    retval.EnablingSerial =
                        SoftwareSerialServer.Shared.AutoEnablingSerialMaker.Generate(softwareName, automatedHardwareSerial);
                }
                return retval;
            }
            catch (Exception ex)
            {
                var innerMsg = string.Empty;
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    innerMsg += inner.Message + "\r\n";
                }

                var tEx = new FaultException("Error: " + ex.Message + "\r\nInner Exception: " + innerMsg);
                //LogToXml(tEx.Message);
                throw tEx;
            }
        }

        private void LogToXml(string message)
        {
            var xmToSave = new xmodel { Msg = message };

            var serialer = new XmlSerializer(typeof(xmodel));
            var path = HostingEnvironment.MapPath("~/logs.xml");
            using(var strm = File.OpenWrite(path))
            {
                serialer.Serialize(strm, xmToSave);
            }
        }

        public class xmodel
        {
            public string Msg { get; set; }
        }
    }
}
