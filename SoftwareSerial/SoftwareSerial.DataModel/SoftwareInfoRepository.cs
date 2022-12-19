using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public class SoftwareInfoRepository : Repository<SoftwareInfo>
    {
        public SoftwareInfoRepository(SerialDbContext context) : base(context) { }

        public override SoftwareInfo GetByID(object id)
        {
            return _dbSet.Include("SerialTrackingCodes").FirstOrDefault(x => x.SoftwareInfoId.Equals((int)id));
        }

        //public SoftwareInfo GetBySoftUniqueName(string softUniqueName)
        //{
        //    var software = _dbSet.FirstOrDefault(x => x.SoftwareName.Equals(softUniqueName));
        //    if (software == null)
        //    {
        //        software = new SoftwareInfo { SoftwareName = softName };
        //        Insert(software);
        //        _dbContext.SaveChanges();
        //    }
        //    return software;
        //}

        public void DeleteWithAllSerials(SoftwareInfo toDel)
        {
            foreach (var track in toDel.SerialTrackingCodes.ToList())
            {
                foreach (var userserial in track.UserSerials.ToList())
                {
                    _dbContext.Entry<UserSerial>(userserial).State = System.Data.EntityState.Deleted;    
                }
                _dbContext.Entry<SerialTrackingCode>(track).State = System.Data.EntityState.Deleted;
            }
            Delete(toDel);
        }

        public SoftwareInfo GetForDeleteByID(int id)
        {
            return _dbSet.Include("SerialTrackingCodes").Include("SerialTrackingCodes.UserSerials").Include("SerialTrackingCodes.UserSerials.HardwareSerials").FirstOrDefault(x => x.SoftwareInfoId.Equals(id));
        }
    }
}
