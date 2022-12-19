using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Contracts
{
    public class SerialMaker : ISerialMaker
    {
        public IAlgorithm Algorithm { get; set; }

        public virtual string GenerateSerial(string orginal)
        {
            if(string.IsNullOrEmpty(orginal))
                throw new ArgumentNullException("orginal");
            if(Algorithm == null || string.IsNullOrEmpty(Algorithm.Algorithm))
                throw new ArgumentNullException("Algorithm");
            if(Algorithm.FormatedAlgorithm==null||Algorithm.FormatedAlgorithm.Length<=0)
                throw new ArgumentNullException("FormatedAlgorithm");

            var randmos = GetRandoms();
            var orginals = GetOrginals(orginal);
            var retVal = string.Empty;
            int randsIndexer = 0, orgsIndexer = 0;

            foreach (var isOrg in Algorithm.FormatedAlgorithm)
            {
                retVal += isOrg ? orginals[orgsIndexer++] : randmos[randsIndexer++].ToString();
            }
            return retVal;
        }

        private string[] GetOrginals(string orginal)
        {
            if ((orginal.Length%Algorithm.OrginalsCount) < 0)
                throw new Exception("the indices of orginal value are too many!");

            var eachOrgLen = orginal.Length / Algorithm.OrginalsCount;
            var lastOrgLen = eachOrgLen + (orginal.Length % Algorithm.OrginalsCount);

            var retVal = new string[Algorithm.OrginalsCount];
            for (int i = 0; i < Algorithm.OrginalsCount; i++)
            {
                int skipLen = i*eachOrgLen;
                int takingLen = (i == (Algorithm.OrginalsCount - 1)) ? lastOrgLen : eachOrgLen;
                retVal[i] = new string(orginal.Skip(skipLen).Take(takingLen).ToArray());
            }   
            return retVal;
        }

        private int[] GetRandoms()
        {
            var retVal = new int[Algorithm.RandomsCount];
            var random = new Random();
            for(int i = 0;i<retVal.Length;i++)
            {
                var nRand = random.Next(0, 9);
                retVal[i] = nRand;
            }
            return retVal;
        }
    }
}
