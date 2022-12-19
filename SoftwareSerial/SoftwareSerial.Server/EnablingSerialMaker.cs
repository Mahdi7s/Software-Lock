using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareSerial.Contracts;

namespace SoftwareSerial.Server
{
    public sealed class EnablingSerialMaker : ISerialMaker
    {
        public IAlgorithm Algorithm { get; internal set; }
        public string GenerateSerial(string orginal)
        {
            throw new NotImplementedException();
        }
    }
}
