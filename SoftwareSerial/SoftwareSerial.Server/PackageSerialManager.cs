using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssemblyLicense.License;
using SoftwareSerial.Contracts;
using SoftwareSerial.DataModel;
using SoftwareSerial.Model;

namespace SoftwareSerial.Server
{
    public sealed class PackageSerialManager
    {
        //private readonly SerialMaker _serialMaker;
        //private readonly OrginalCatcher _orginalCatcher;

        public PackageSerialManager()
        {
            //LicManager.Validate(() => typeof (SoftwareSerialServer).Assembly.FullName);
        }

        //public PackageSerialManager(IAlgorithm algorithm)
        //{
        //    _serialMaker =new SerialMaker(algorithm);
        //    _orginalCatcher = new OrginalCatcher(algorithm);
        //    Algorithm = algorithm;
        //}
        //public IAlgorithm Algorithm { get; private set; }

        /// <summary>
        /// TODO! : Make sure you a have matching softwareInfo record in your db, then call this!
        /// </summary>
        /// <param name="usingCount"> </param>
        /// <param name="count"></param>
        /// <param name="trackingCode"></param>
        /// <param name="serialLen"></param>
        /// <param name="onHardGenerating">return false for canceling the generating more.</param>
        /// <param name="sofwareUniqueName"> </param>
        /// <returns></returns>
        public string[] GenerateSerials(string sofwareUniqueName, int usingCount, int count, out SerialTrackingCode trackingCode, int serialLen = 8, Func<bool> onHardGenerating=null)
        {
            onHardGenerating = onHardGenerating ?? (() => false);
            int duplicatesCount = 0;
            var retVal = new List<string>();

            var softwareInfo = UnitOfWork.Shared.SoftwareInfoRep.GetAll().FirstOrDefault(x => x.SoftwareUniqueName.Equals(sofwareUniqueName));
            if(softwareInfo == null)
                throw new Exception("There is not any record with the uniqueSoft name of: " + sofwareUniqueName);

            var nTrackingCode = new SerialTrackingCode { SoftwareInfo = softwareInfo, SerialUsingCount = usingCount};
            UnitOfWork.Shared.SerialTrackingCodeRep.Insert(nTrackingCode);
            UnitOfWork.Shared.SaveChanges();

            while (retVal.Count() < count)
            {
                foreach (var nSerial in GetSplitedStringsOfGuid(serialLen))
                {
                    if(!IsSerialInDb(nSerial))
                    {
                        UnitOfWork.Shared.UserSerialRep.Insert(nSerial, nTrackingCode);
                        retVal.Add(nSerial);

                        if(retVal.Count() >= count) break;
                    }
                    else if((++duplicatesCount)>=5)
                    {
                        if(!onHardGenerating()) break;
                        duplicatesCount = 0;
                    }
                }
            }
            UnitOfWork.Shared.SaveChanges();

            trackingCode = nTrackingCode;
            return retVal.ToArray();
        }

        private bool IsSerialInDb(string serial)
        {
            return
                UnitOfWork.Shared.PackageSerialRep.GetAll().Any(
                    x => x.Serial.Equals(serial, StringComparison.OrdinalIgnoreCase));
        }

        private IEnumerable<string> GetSplitedStringsOfGuid(int strLen)
        {
            var guid = Guid.NewGuid();
            var guidStr = guid.ToString();
            var spltedGuid = guidStr.Split(new[] {'-'});
            guidStr = string.Empty;
            foreach (var s in spltedGuid)
            {
                guidStr += s;
            }

            while (guidStr.Length >= strLen)
            {
                var retVal = guidStr.Substring(0, strLen);
                guidStr = guidStr.Substring(strLen);

                yield return retVal;
            }
        }
    }
}
