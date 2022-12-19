using SoftwareClient.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SoftwareSerial.Client;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for UserDataProtectionTest and is intended
    ///to contain all UserDataProtectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserDataProtectionTest
    {
        private TestContext testContextInstance;

        private readonly string _hardwareName = Hardware.CPU;
        private readonly string _password = "98765";

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
        ///A test for Protect
        ///</summary>
        [TestMethod()]
        public void ProtectTest()
        {
            string data = HardwareSerialManager.GetHardwareSerial(_hardwareName); // TODO: Initialize to an appropriate value
            string password = _password; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = UserDataProtection.Protect(data, password);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void ProtectSerialLengthTest()
        {
            //string actual = 
            //string expected = UserDataProtection.Protect(actual, "!");
            
            //Assert.AreEqual(actual, expected,
            //                string.Format("{0} != {1}", actual , expected));
        }



        /// <summary>
        ///A test for Unprotect
        ///</summary>
        [TestMethod()]
        public void UnprotectTest()
        {
            var actual = HardwareSerialManager.GetHardwareSerial(_hardwareName);
            string encryptedData = UserDataProtection.Protect(actual, _password);
            string expected = UserDataProtection.Unprotect(encryptedData, _password);

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
