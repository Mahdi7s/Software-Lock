using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftwareSerial.Contracts
{
    public interface IAlgorithm
    {
        string Algorithm { get; }
        bool[] FormatedAlgorithm { get; }

        int RandomsCount { get; }
        int OrginalsCount { get; }
    }
}
