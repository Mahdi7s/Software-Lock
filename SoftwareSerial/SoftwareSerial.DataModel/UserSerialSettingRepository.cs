using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public sealed class UserSerialSettingRepository : Repository<UserSerialSetting>
    {
        public UserSerialSettingRepository(DbContext dbContext):base(dbContext){}

        public UserSerialSetting GetSettings()
        {
            var retVal = _dbSet.FirstOrDefault();
            if(retVal == null)
            {
                retVal = new UserSerialSetting();
                _dbSet.Add(retVal);
                _dbContext.SaveChanges();
            }
            return retVal;
        }
    }
}
