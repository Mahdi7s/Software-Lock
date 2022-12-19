using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Contracts
{
    public class OrginalCatcher : IOrginalCatcher
    {
        public OrginalCatcher()
        {
        }
        public IAlgorithm Algorithm { get; set; }

        public string CatchOrginal(string randomAndOrginal)
        {
            if (string.IsNullOrEmpty(randomAndOrginal))
                throw new ArgumentNullException("randomAndOrginal");

            var orginalLen = randomAndOrginal.Length - Algorithm.RandomsCount;
            var eachOrgLen = orginalLen/Algorithm.OrginalsCount;
            var lastOrgLen = eachOrgLen + (orginalLen%Algorithm.OrginalsCount);

            var orginal = string.Empty;
            var randAndOrgTmp = randomAndOrginal;
            int indexer = 0, readedOrgs = 0;
            while (randAndOrgTmp.Length > 0)
            {
                var isOrg = Algorithm.FormatedAlgorithm[indexer++];
                if (isOrg)
                {
                    var orgSubLen = (readedOrgs == Algorithm.OrginalsCount - 1) ? lastOrgLen : eachOrgLen;
                    orginal += randAndOrgTmp.Substring(0, orgSubLen);
                    randAndOrgTmp = randAndOrgTmp.Substring(orgSubLen);

                    ++readedOrgs;
                }
                else
                {
                    randAndOrgTmp = randAndOrgTmp.Substring(1);
                }
            }
            return orginal;
        }
    }
}
