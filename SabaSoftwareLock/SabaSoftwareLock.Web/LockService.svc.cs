using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SabaSoftwareLock.DataModel;
using SoftwareSerial.Contracts;
using SoftwareSerial.Server;
using UnitOfWork = SabaSoftwareLock.DataModel.UnitOfWork;

namespace SabaSoftwareLock.Web
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class LockService : ISerialService
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public SerialValidationContract Validate(string softwareName, string packageSerial, string automatedHardwareSerial)
        {
            var password = "password";
            var retval = new SerialValidationContract();

            try
            {
                var hardwareSerialCatcher = new SoftwareSerial.Server.AutoHardwareSerialCatcher(password);
                var hardwareSerial = hardwareSerialCatcher.Catch(automatedHardwareSerial);

                retval.Validation = _unitOfWork.UserSerialRep.ValidateSerial(softwareName, packageSerial, hardwareSerial);
                if (retval.Validation == SoftwareSerial.Model.UserSerialValidationResult.IsValid)
                {
                    var enablingSerialMaker = new AutoEnablingSerialMaker(password);
                    retval.EnablingSerial = enablingSerialMaker.Generate(softwareName, automatedHardwareSerial);                        
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

                throw new FaultException("Error: " + ex.Message + "\r\nInner Exception: " + innerMsg);
            }
        }
    }
}
