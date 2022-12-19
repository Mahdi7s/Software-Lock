using SoftwareSerial.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{


    /// <summary>
    ///This is a test class for SerialValidatorTest and is intended
    ///to contain all SerialValidatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SerialValidatorTest
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
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTest()
        {
            IAlgorithm algorithm = new SerialAlgorithm("[r][o][r][r][r][o][r][r][r][o]");
            var orginalCatcher = new OrginalCatcher();
            orginalCatcher.Algorithm = algorithm;
            string orginal = "108566DE4264-223a15t6327";
            SerialMaker serialMaker = new SerialMaker();
            serialMaker.Algorithm = algorithm;
            string randomAndOrginal = serialMaker.GenerateSerial(orginal);
            var actual = orginalCatcher.CatchOrginal(randomAndOrginal);

            Assert.IsTrue(orginal.Equals(actual), "hey bad coding!");
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
