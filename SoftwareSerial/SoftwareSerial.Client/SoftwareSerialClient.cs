using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using AssemblyLicense.License;
using SoftwareSerial.Client.SerialServiceReference;
using SoftwareSerial.Contracts;
using SerialValidationContract = SoftwareSerial.Contracts.SerialValidationContract;

namespace SoftwareSerial.Client
{
    public sealed class SoftwareSerialClient
    {
        private static SoftwareSerialClient _softwareSerialClient;
        private readonly SerialServiceClient _serialServiceClient;

        private SoftwareSerialClient(string serialServiceAddress, string softwareName,SerialLengthEnum serialLengthEnum, string password, params string[] hardwares)
        {
            LicManager.Validate(() => typeof (AutoEnablingSerialValidtor).Assembly.FullName);

            var timeout = TimeSpan.FromMinutes(0.5);
            _serialServiceClient = new SerialServiceClient(new BasicHttpBinding() { MaxReceivedMessageSize = 32678,CloseTimeout =timeout,SendTimeout=timeout,ReceiveTimeout=timeout},
                                                           new EndpointAddress(serialServiceAddress));
            //_serialServiceClient.Endpoint.Behaviors.Add(new WebHttpBehavior() { DefaultBodyStyle = WebMessageBodyStyle.Wrapped, FaultExceptionEnabled = true });

            RegistryManager = new SerialRegistryManager(softwareName);
            PackageAndHardwareMixedSerialMaker = new PackageAndHardwareMixedSerialMaker();
            AutoHardwareSerialMaker = new AutoHardwareSerialMaker(password, serialLengthEnum, hardwares);
            AutoEnablingSerialValidtor = new AutoEnablingSerialValidtor(password);
        }
        static SoftwareSerialClient(){}

        public static void Initialize(string serialServiceAddress, string softwareName, SerialLengthEnum serialLengthEnum, string password, params string[] hardwares)
        {
            if (_softwareSerialClient == null)
            {
                _softwareSerialClient = new SoftwareSerialClient(serialServiceAddress, softwareName, serialLengthEnum,password, hardwares);
            }
        }

        public static SoftwareSerialClient Shared
        {
            get
            {
                if(_softwareSerialClient==null)
                {
                    throw new Exception("You must initialize SoftwareSerialClient before calling SoftwareSerialClient.Shared .");
                }
                lock (typeof(SoftwareSerialClient))
                {
                    return _softwareSerialClient;
                }
            }
        }

        public SerialRegistryManager RegistryManager { get; private set; }
        public PackageAndHardwareMixedSerialMaker PackageAndHardwareMixedSerialMaker { get; private set; }
        public AutoHardwareSerialMaker AutoHardwareSerialMaker { get; private set; }
        public AutoEnablingSerialValidtor AutoEnablingSerialValidtor { get; private set; }

        public SerialValidationContract ValidateSerial(string softwareName, string packageSerial, string automatedSerial)
        {
            return
                _serialServiceClient.Validate(softwareName, packageSerial, automatedSerial);
        }
    }
}
