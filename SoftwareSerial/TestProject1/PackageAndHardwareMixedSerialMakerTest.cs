using System.Text;
using SoftwareClient.Utility;
using SoftwareSerial.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SoftwareSerial.Contracts;
using SoftwareSerial.Server;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for PackageAndHardwareMixedSerialMakerTest and is intended
    ///to contain all PackageAndHardwareMixedSerialMakerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PackageAndHardwareMixedSerialMakerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GenerateSerial
        ///</summary>
    

        /// <summary>
        ///A test for GenerateNewSerial
        ///</summary>
        [TestMethod()]
        public void GenerateNewSerialTest()
        {
            IAlgorithm algorithm = new SerialAlgorithm("[o][o][r][o][o][r][o][o][r][o][o][r][o][o][r][o][o][r][o][o][r][o][o]");
            var packageSerial = "23a5t327";
            var maker = new PackageAndHardwareMixedSerialMaker();
            maker.Algorithm = algorithm;
            var catcher = new PackageAndHardwareOrginalCatcher();
            catcher.Algorithm = algorithm;
            string serial = maker.GenerateNewSerial(packageSerial);
            string catchedPackage, catchedCpuHdd;
            catcher.CatchPackageAndHardwareSerials(serial, out catchedPackage, out catchedCpuHdd);

            Assert.AreEqual(packageSerial, catchedPackage);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod]
        public void AnotherTest()
        {
            var bytes = Encoding.UTF8.GetBytes("Mahdi");
            var randByte = (byte) (new Random()).Next(2, Byte.MaxValue);
            for(int i = 0;i<bytes.Length;i++)
            {
                bytes[i] = (byte) Math.Pow(bytes[i], randByte);
            }
            var createdName = StringUtils.ToBase32String(bytes);

            Assert.Fail(createdName);
        }
    }
}
