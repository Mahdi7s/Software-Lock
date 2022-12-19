using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SoftwareSerial.DataModel;
using SoftwareSerial.Model;

namespace SoftwareSerial.Server
{
    public sealed class SoftwareSerialServer //: IDisposable
    {
        private static SoftwareSerialServer _softwareSerialServer;
        private readonly AutoHardwareSerialCatcher _autoHardwareSerialCatcher;        

        private SoftwareSerialServer(string nameOrConnectionString, DbInitializationType dbInitializationType, string password)
        {
            UnitOfWork.Initialize(nameOrConnectionString, dbInitializationType);

            PackageSerialMacker = new PackageSerialManager();
            EnablingSerialMaker = new EnablingSerialMaker();
            PackageAndHardwareOrginalCatcher= new PackageAndHardwareOrginalCatcher();
            _autoHardwareSerialCatcher = new AutoHardwareSerialCatcher(password);
            AutoEnablingSerialMaker = new AutoEnablingSerialMaker(password);
        }
        static SoftwareSerialServer() {}

        public static void Initialize(string nameOrConnectionString = null, DbInitializationType dbInitializationType = DbInitializationType.CreateIfNotExists, string password = "password")
        {
            if (_softwareSerialServer == null)
            {
                _softwareSerialServer = new SoftwareSerialServer(nameOrConnectionString, dbInitializationType, password);
            }
        }

        public static SoftwareSerialServer Shared
        {
            get
            {
                if (_softwareSerialServer == null)
                {
                    throw new Exception("You must first initialize before using SoftwareSerialServer.Shared .");
                }
                return _softwareSerialServer;
            }
        }

        public UnitOfWorkBase Repositories
        {
            get { return UnitOfWork.Shared; }
        }

        public PackageSerialManager PackageSerialMacker { get; private set; }
        public EnablingSerialMaker EnablingSerialMaker { get; private set; }
        public PackageAndHardwareOrginalCatcher PackageAndHardwareOrginalCatcher { get; private set; }
        public AutoEnablingSerialMaker AutoEnablingSerialMaker { get; set; }

        public UserSerialValidationResult ValidateUserSerial(string softwareName, string packageSerial, string automatedHardwareSerial)
        {
            var hardwareSerial = _autoHardwareSerialCatcher.Catch(automatedHardwareSerial);
            return UnitOfWork.Shared.UserSerialRep.ValidateSerial(softwareName, packageSerial, hardwareSerial);
        }

        //public void Dispose()
        //{            
        //    GC.SuppressFinalize(this);
        //}
    }
}
