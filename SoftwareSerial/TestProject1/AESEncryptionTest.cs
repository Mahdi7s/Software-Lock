using SoftwareClient.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SoftwareSerial.Client;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AESEncryptionTest and is intended
    ///to contain all AESEncryptionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AESEncryptionTest
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
        ///A test for Decrypt
        ///</summary>
        [TestMethod()]
        public void DecryptTest()
        {
            string password = "13";
            var strForEncryption = "1234پ56789097";
            string encryptedStr = AESEncryption.Encrypt(strForEncryption, password);
            string expected = strForEncryption;
            string actual = AESEncryption.Decrypt(encryptedStr, password);
            Assert.IsTrue(encryptedStr.Length <= (strForEncryption.Length+2));
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
