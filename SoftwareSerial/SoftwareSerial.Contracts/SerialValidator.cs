using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Contracts
{
    public class SerialValidator : ISerialValidator
    {
        public SerialValidator(IAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }
        public IAlgorithm Algorithm { get; protected set; }

        public virtual bool Validate(string orginal, string randomAndOrginal)
        {
            var actOrginal = GetSerial(randomAndOrginal);
            return orginal.Equals(actOrginal);
        }

        protected virtual string GetSerial(string randomAndOrginal)
        {
            if (string.IsNullOrEmpty(randomAndOrginal))
                throw new ArgumentNullException("randomAndOrginal");

            var orginalLen = randomAndOrginal.Length - Algorithm.RandomsCount;
            var eachOrgLen = orginalLen / Algorithm.OrginalsCount;
            var lastOrgLen = eachOrgLen + (orginalLen % Algorithm.OrginalsCount);

            var orginal = string.Empty;
            var orginalIndices = GetOrginalIndices().ToArray();
            for (int i = 0; i < orginalIndices.Length; i++)
            {
                var orgIndex = orginalIndices[i];
                var takingLen = (i == orginalIndices.Length - 1) ? lastOrgLen : eachOrgLen;
                orginal += new string(randomAndOrginal.Skip(orgIndex).Take(takingLen).ToArray());
            }
            return orginal;
        }

        private IEnumerable<int> GetOrginalIndices()
        {
            for (int i = 0; i < Algorithm.FormatedAlgorithm.Length; i++)
            {
                if (Algorithm.FormatedAlgorithm[i])
                {
                    yield return i;
                }
            }
        }
    }
}
