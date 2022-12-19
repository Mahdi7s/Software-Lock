using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Contracts
{
    public interface IOrginalCatcher
    {
        IAlgorithm Algorithm { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="randomAndOrginal">a string that contains both random & orginal values together.</param>
        /// <returns></returns>
        string CatchOrginal(string randomAndOrginal);
    }
}
