using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public class SerialTrackingCodeRepository : Repository<SerialTrackingCode>
    {
        public SerialTrackingCodeRepository(DbContext dbContext):base(dbContext){}

        public override void Insert(SerialTrackingCode entity)
        {
            entity.CreatedDate = DateTime.Now;
            base.Insert(entity);
        }
    }
}
