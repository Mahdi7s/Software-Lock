using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using SoftwareSerial.Model;

namespace SoftwareSerial.DataModel
{
    public sealed class UserSerialRepository : Repository<UserSerial>
    {
        private readonly SerialDbContext _serialDbContext;

        public UserSerialRepository(DbContext dbContext)
            : base(dbContext)
        {
            _serialDbContext = dbContext as SerialDbContext;
        }

        public override void Insert(UserSerial entity)
        {
            if (entity.PackageSerial == null)
            {
                var nPackageSerial = new PackageSerial();

                _serialDbContext.PackageSerials.Add(nPackageSerial);

                entity.PackageSerial = nPackageSerial;
            }
            if (entity.UserSerialState == null)
            {
                var nUserSerialState = new UserSerialState();

                _serialDbContext.UserSerialStates.Add(nUserSerialState);

                entity.UserSerialState = nUserSerialState;
            }
            base.Insert(entity);
        }

        public void Insert(string packageSerial, SerialTrackingCode trackingCode)
        {
            var nUserSerial = new UserSerial();
            var nPackageSerial = new PackageSerial {Serial = packageSerial};

            _serialDbContext.PackageSerials.Add(nPackageSerial);

            nUserSerial.PackageSerial = nPackageSerial;
            nUserSerial.SerialTrackingCode = trackingCode;
            nUserSerial.UserSerialState = new UserSerialState { LastEnablingState = "NotUsed" };

            Insert(nUserSerial);
        }

        public IQueryable<UserSerial> Search(string key, string value)
        {
            var query = _dbSet.AsQueryable();

            switch (key)
            {
                case "PackageSerial":
                    query =
                        query.Where(x => x.PackageSerial.Serial.Equals(value, StringComparison.OrdinalIgnoreCase));
                    break;
                case "HardwareSerial":
                    query =
                        query.Where(x => x.HardwareSerials.Any(hs => hs.Serial.Equals(value, StringComparison.OrdinalIgnoreCase)));
                    break;
                case "LastEnablingState":
                    query =
                        query.Where(
                            x => x.UserSerialState.LastEnablingState.Equals(value, StringComparison.OrdinalIgnoreCase));
                    break;
                case "UsedCount":
                    int usedCount;
                    if (int.TryParse(value, out usedCount))
                    {
                        query = query.Where(x => x.UsedCount.Equals(usedCount));
                    }
                    break;
                case "TrackingCode":
                    int trackingCode;
                    if (int.TryParse(value, out trackingCode))
                    {
                        query = query.Where(x => x.SerialTrackingCode.SerialTrackingCodeId.Equals(trackingCode));
                    }
                    break;
                case "SoftwareName":
                    query =
                        query.Where(
                            x =>
                            !string.IsNullOrEmpty(x.SerialTrackingCode.SoftwareInfo.SoftwareName) &&
                            x.SerialTrackingCode.SoftwareInfo.SoftwareName.Equals(value, StringComparison.OrdinalIgnoreCase));
                    break;
            }

            return query.Include(x => x.UserSerialState);
        }

        public override void Update(UserSerial entityToUpdate)
        {
            if (entityToUpdate.PackageSerial != null)
                _dbContext.Entry(entityToUpdate.PackageSerial).State = EntityState.Modified;
            if (entityToUpdate.UserSerialState != null)
                _dbContext.Entry(entityToUpdate.UserSerialState).State = EntityState.Modified;

            base.Update(entityToUpdate);
        }

        public UserSerialValidationResult ValidateSerial(string softwareUniqName, string packageSerial, string hardwareSerial)
        {
            if (string.IsNullOrEmpty(softwareUniqName))
                throw new ArgumentNullException("softwareUniqName");
            if (string.IsNullOrEmpty(packageSerial))
                throw new ArgumentNullException("packageSerial");
            if (string.IsNullOrEmpty(hardwareSerial))
                throw new ArgumentNullException("hardwareSerial");

            var userSerial = _dbSet.Include(x=>x.PackageSerial).Where(x => x.PackageSerial.Serial.Equals(packageSerial)).Include(x => x.SerialTrackingCode).Include(x => x.UserSerialState).Include(x => x.SerialTrackingCode.SoftwareInfo).FirstOrDefault();

            var retVal = UserSerialValidationResult.IsValid;

            if (userSerial == null)
            {
                retVal = UserSerialValidationResult.PackageSerialIsNotInDb;
            }
            else if(string.IsNullOrEmpty(userSerial.SerialTrackingCode.SoftwareInfo.SoftwareUniqueName) || !userSerial.SerialTrackingCode.SoftwareInfo.SoftwareUniqueName.Equals(softwareUniqName, StringComparison.OrdinalIgnoreCase))
            {
                retVal = UserSerialValidationResult.SoftwareNameNotMatchesPackageSerial;
            }
            else if (userSerial.HardwareSerials == null || !userSerial.HardwareSerials.Any())
            {
                if (userSerial.UsedCount < userSerial.SerialTrackingCode.SerialUsingCount)
                {
                    var nHSerial = new HardwareSerial { Serial = hardwareSerial, UserSerial = userSerial };
                    userSerial.HardwareSerials = new List<HardwareSerial> { nHSerial };

                    _serialDbContext.HardwareSerials.Add(nHSerial);

                    userSerial.UsedCount = 1;
                }
                else
                {
                    retVal = UserSerialValidationResult.IsUsedMoreThan;
                }
            }
            else if (!userSerial.HardwareSerials.Any(x => x.Serial.Equals(hardwareSerial)))
            {
                if (userSerial.UsedCount < userSerial.SerialTrackingCode.SerialUsingCount)
                {
                    var nHSerial = new HardwareSerial { Serial = hardwareSerial, UserSerial = userSerial };
                    userSerial.HardwareSerials.Add(nHSerial);

                    _serialDbContext.HardwareSerials.Add(nHSerial);

                    ++userSerial.UsedCount;
                }
                else
                {
                    retVal = UserSerialValidationResult.IsUsedMoreThan;
                }
            }

            if (userSerial != null)
            {
                userSerial.UserSerialState.LastEnablingState = retVal.ToReadableString();
                Update(userSerial);
                _serialDbContext.Entry<UserSerialState>(userSerial.UserSerialState).State = EntityState.Modified;

                _serialDbContext.SaveChanges();
            }
            return retVal;
        }
    }
}
