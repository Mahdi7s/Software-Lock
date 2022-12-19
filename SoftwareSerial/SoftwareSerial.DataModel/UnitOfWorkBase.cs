using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.DataModel
{
    public abstract class UnitOfWorkBase
    {
        protected SerialDbContext _serialDbContext;

        private HardwareSerialRepository _hardwareSerialRepository;
        private PackageSerialRepository _packageSerialRepository;
        private UserSerialRepository _userSerialRepository;
        private UserSerialSettingRepository _userSerialSettingRep;
        private UserSerialStateRepository _userSerialStateRep;
        private SerialTrackingCodeRepository _serialTrackingCodeRep;
        private SoftwareInfoRepository _softwareInfoRep;
        private UserRepository _userRepository;

        public UnitOfWorkBase(SerialDbContext serialDbContext = null)
        {
            _serialDbContext = serialDbContext;
        }

        public SoftwareInfoRepository SoftwareInfoRep
        {
            get
            {
                return _softwareInfoRep ?? (_softwareInfoRep = new SoftwareInfoRepository(_serialDbContext));
            }
        }

        public HardwareSerialRepository HardwareSerialRep
        {
            get
            {
                return _hardwareSerialRepository ??
                       (_hardwareSerialRepository = new HardwareSerialRepository(_serialDbContext));
            }
        }

        public PackageSerialRepository PackageSerialRep
        {
            get
            {
                return _packageSerialRepository ??
                       (_packageSerialRepository = new PackageSerialRepository(_serialDbContext));
            }
        }

        public UserSerialRepository UserSerialRep
        {
            get
            {
                return _userSerialRepository ??
                       (_userSerialRepository = new UserSerialRepository(_serialDbContext));
            }
        }

        public UserSerialSettingRepository UserSerialSettingRep
        {
            get
            {
                return _userSerialSettingRep ??
                       (_userSerialSettingRep = new UserSerialSettingRepository(_serialDbContext));
            }
        }

        public UserSerialStateRepository UserSerialStateRep
        {
            get { return _userSerialStateRep ?? (_userSerialStateRep = new UserSerialStateRepository(_serialDbContext)); }
        }

        public SerialTrackingCodeRepository SerialTrackingCodeRep
        {
            get
            {
                return _serialTrackingCodeRep ??
                       (_serialTrackingCodeRep = new SerialTrackingCodeRepository(_serialDbContext));
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                return _userRepository ??
                       (_userRepository = new UserRepository(_serialDbContext));
            }
        }

        public void SaveChanges()
        {
            _serialDbContext.SaveChanges();
        }
    }
}
