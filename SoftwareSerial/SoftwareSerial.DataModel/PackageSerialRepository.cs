using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public sealed class PackageSerialRepository : Repository<PackageSerial>
    {
        public PackageSerialRepository(DbContext dbContext):base(dbContext){}
    }
}
