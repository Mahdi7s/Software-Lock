using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public sealed class HardwareSerialRepository : Repository<HardwareSerial>
    {
        public HardwareSerialRepository(DbContext dbContext) : base(dbContext) { }
    }
}
