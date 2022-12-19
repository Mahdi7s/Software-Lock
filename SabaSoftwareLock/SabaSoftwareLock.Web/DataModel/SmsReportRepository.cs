using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc7S;
using SabaSoftwareLock.Web.Models;

namespace SabaSoftwareLock.Web.DataModel
{
    public class SmsReportRepository : Repository<SmsReport>
    {
        public SmsReportRepository(LockWebDbContext dbContext)
            : base(dbContext)
        {

        }

        public SmsReport GetByNumber(string phoneNumber)
        {
            return _dbSet.FirstOrDefault(x => x.PhoneNumber.Equals(phoneNumber));
        }

        public int AddInvalids(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return -1;

            var smsRep = GetByNumber(phoneNumber);
            if (smsRep != null)
            {
                ++smsRep.InvalidSmsCount;
                Update(smsRep);
            }
            else
            {
                Insert(new SmsReport { PhoneNumber = phoneNumber, InvalidSmsCount = 1 });
            }
            _dbContext.SaveChanges();

            return smsRep.InvalidSmsCount;
        }
    }
}