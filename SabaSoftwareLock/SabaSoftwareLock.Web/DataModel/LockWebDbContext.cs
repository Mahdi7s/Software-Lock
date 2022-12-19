using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabaSoftwareLock.Model;
using SabaSoftwareLock.Web.Models;
using SoftwareSerial.DataModel;

namespace SabaSoftwareLock.Web.DataModel
{
    public class LockWebDbContext : SerialDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<PriceDetail> PriceDetails { get; set; }
        public DbSet<SmsReport> SmsReports { get; set; }

        public LockWebDbContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
