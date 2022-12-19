using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareSerial.Contracts
{
    public interface ISerialMaker
    {
        IAlgorithm Algorithm { get; }

        string GenerateSerial(string orginal);
    }
}
