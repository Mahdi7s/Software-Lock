using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public class SerialDbContext : DbContext
    {
        public DbSet<HardwareSerial> HardwareSerials { get; set; }
        public DbSet<UserSerial> UserSerials { get; set; }
        public DbSet<PackageSerial> PackageSerials { get; set; }
        public DbSet<UserSerialState> UserSerialStates { get; set; }
        public DbSet<UserSerialSetting> UserSerialSettings { get; set; }
        public DbSet<SoftwareInfo> SoftwareInfoes { get; set; }
        public DbSet<User> Users { get; set; } 

        public SerialDbContext()
        {
            Configuration.LazyLoadingEnabled = true;        
        }

        public SerialDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
