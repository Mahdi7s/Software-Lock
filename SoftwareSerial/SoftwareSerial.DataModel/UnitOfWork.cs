using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AssemblyLicense.License;

namespace SoftwareSerial.DataModel
{
    public enum DbInitializationType
    {
        CreateAlways,
        CreateIfNotExists,
        Migrate
    }

    public class UnitOfWork : UnitOfWorkBase
    {
        private static UnitOfWorkBase _unitOfWork = null;

        private UnitOfWork(SerialDbContext serialDbContext = null) : base(serialDbContext) { }

        public static UnitOfWorkBase Shared
        {
            get
            {
                if (_unitOfWork == null)
                {
                    throw new Exception("You must initialize UnitOfWork before calling UnitOfWork.Shared .");
                }
                lock (typeof (UnitOfWork))
                {
                    return _unitOfWork;
                }
            }
        }

        public static void Initialize(string nameOrConnectionString = null,
                                      DbInitializationType initializationType = DbInitializationType.CreateIfNotExists)
        {
            if (_unitOfWork == null)
            {
                if (!string.IsNullOrEmpty(nameOrConnectionString))
                {
                    _unitOfWork = new UnitOfWork(new SerialDbContext(nameOrConnectionString));
                }
                else
                {
                    _unitOfWork = new UnitOfWork(new SerialDbContext());
                }
                switch (initializationType)
                {
                    case DbInitializationType.CreateAlways:
                        Database.SetInitializer(new SerialDbDevelopmentInitializer());
                        break;
                    case DbInitializationType.CreateIfNotExists:
                        Database.SetInitializer(new SerialDbDeploymentInitializer());
                        break;
                    case DbInitializationType.Migrate:
                        Database.SetInitializer(new SerialDbDevelopmentInitializer());
                    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SerialDbContext, Configuration>());
                        break;
                }
            }
        }

        public static void Initialize(UnitOfWorkBase instance)
        {
            _unitOfWork = instance;
        }
    }
}
