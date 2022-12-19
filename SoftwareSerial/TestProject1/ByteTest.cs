using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareClient.Utility;

namespace TestProject1
{
    [TestClass]
    public class ByteTest
    {
        [TestMethod]
        public void AddSubByteTest()
        {
            var bytes = new byte[] {0, 34, 256-45, 255-45, 255};

            var addRes = StringUtils.AddByte(bytes, 45);
            var subRes = StringUtils.SubByte(addRes, 45);

            Assert.IsTrue(StringUtils.ToBase32String(bytes).Equals(StringUtils.ToBase32String(subRes)));
        }
    }
}
