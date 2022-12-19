using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SabaSoftwareLock.Web;
using SabaSoftwareLock.Web.DataModel;

namespace SabaSoftwareLock.DataModel
{
    public sealed class UnitOfWork : SoftwareSerial.DataModel.UnitOfWorkBase, IDisposable
    {
        private readonly LockWebDbContext _dbContext;

        private MemberRepository _memberRepository;
        private SettingRepository _settingRepository;
        private MemberSoftwareNameRepository _memberSoftwareNameRep;
        private SmsReportRepository _smsReportRepository;

        public UnitOfWork()
        {
            _serialDbContext = _dbContext = new LockWebDbContext();
        }

        public MemberRepository MemberRep
        {
            get { return (_memberRepository = _memberRepository ?? new MemberRepository(_dbContext)); }
        }

        public SettingRepository SettingRep
        {
            get { return (_settingRepository = _settingRepository ?? new SettingRepository(_dbContext)); }
        }

        public MemberSoftwareNameRepository MemberSoftwareNameRep
        {
            get { return (_memberSoftwareNameRep = _memberSoftwareNameRep ?? new MemberSoftwareNameRepository(_dbContext)); }
        }

        public SmsReportRepository SmsReportRep
        {
            get { return (_smsReportRepository = _smsReportRepository ?? new SmsReportRepository(_dbContext)); }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
