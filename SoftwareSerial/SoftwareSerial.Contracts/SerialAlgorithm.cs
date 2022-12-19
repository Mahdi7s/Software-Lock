using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Contracts
{
    public class SerialAlgorithm : IAlgorithm
    {
        //private string _algorithm = string.Empty;

        /// <summary>
        /// "[r][r][o][o][r][o][o][r]"
        /// </summary>
        ///<param name="algorithm"></param>
        public SerialAlgorithm(string algorithm)
        {
            OnSettingAlgorithm(algorithm);
        }

        public string Algorithm { get; protected set; }

        //public string Algorithm
        //{
        //    get { return _algorithm; }
        //    set
        //    {
        //        OnSettingAlgorithm(value);
        //        _algorithm = value;
        //    }
        //}

        public bool[] FormatedAlgorithm { get; protected set; }

        public int RandomsCount { get; protected set; }
        public int OrginalsCount { get; protected set; }

        protected virtual void OnSettingAlgorithm(string algorithm)
        {
            if (string.IsNullOrEmpty(algorithm))
                throw new ArgumentNullException("algorithm");
            if (algorithm.Length%3 != 0)
                throw new Exception("algorithm is not in correct format.");

            FormatedAlgorithm = new bool[algorithm.Length/3];
            RandomsCount = OrginalsCount = 0;
            var algTmpStr = algorithm;
            int indexer = 0;

            while (algTmpStr.Length>0)
            {
                var subStr = algTmpStr.Substring(0, 3);
                algTmpStr = algTmpStr.Substring(3);
                if (subStr.Equals("[o]", StringComparison.OrdinalIgnoreCase))
                {
                    FormatedAlgorithm[indexer++] = true;
                    ++OrginalsCount;
                }
                else if (subStr.Equals("[r]", StringComparison.OrdinalIgnoreCase))
                {
                    FormatedAlgorithm[indexer++] = false;
                    ++RandomsCount;
                }
                else
                {
                    throw new Exception("algorithm is not in correct format.");
                }
            }

            Algorithm = algorithm;
        }
    }
}
