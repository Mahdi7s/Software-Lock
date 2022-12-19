using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SabaSoftwareLock.Web.Models;
using Mvc7S;

namespace SabaSoftwareLock.Web.DataModel
{
    public class SettingRepository : Repository<Setting>
    {
        public SettingRepository(LockWebDbContext dbContext) : base(dbContext) { }

        public Setting GetSetting()
        {
            var setting = _dbSet.Include("PriceDetails").FirstOrDefault();
            if (setting == null)
            {
                setting = new Setting();

                Insert(setting);
                _dbContext.SaveChanges();
            }
            return setting;
        }
    }
}