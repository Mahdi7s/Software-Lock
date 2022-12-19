using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareSerial.Contracts;

namespace SoftwareSerial.Client
{
    internal sealed class EnablingSerialValidator : ISerialValidator
    {
        public IAlgorithm Algorithm
        {
            get { throw new NotImplementedException(); }
        }

        public bool Validate(string orginal, string serial)
        {
            throw new NotImplementedException();
        }
    }
}
