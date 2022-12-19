using SoftwareSerial.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for SerialMakerTest and is intended
    ///to contain all SerialMakerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SerialMakerTest
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
        [TestMethod()]
        public void GenerateSerialTest()
        {
            IAlgorithm algorithm = new SerialAlgorithm("[r][o][r][o][r][o][r][r][o][r][o][r][o][r][r][o][r][o][r][o][r]");
            string actual = "23a5t327";
            SerialMaker maker = new SerialMaker();
            maker.Algorithm = algorithm;
            OrginalCatcher catcher =new OrginalCatcher();
            catcher.Algorithm = algorithm;
            string generated = maker.GenerateSerial(actual);
            string expected = catcher.CatchOrginal(generated);

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
