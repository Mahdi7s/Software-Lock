using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareSerial.Client;
using SoftwareSerial.Contracts;
using SoftwareSerial.DataModel;
using SoftwareSerial.Model;
using SoftwareSerial.Server;

namespace TestProject1
{
    [TestClass]
    public class SerialServiceTest
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

        //[TestMethod]
        //public void ValidateUserSerialTest()
        //{
        //    var serialService = new SerialService();
        //    var alg = new SerialAlgorithm("[r][r][o][r][o][o]");
        //    SoftwareSerialClient.Initialize("rtretret","theSoftware","ertwertwer","Ertwer");
        //    SoftwareSerialClient.Shared.PackageAndHardwareMixedSerialMaker.Algorithm = alg;
        //    var generateSerial = SoftwareSerialClient.Shared.PackageAndHardwareMixedSerialMaker.GenerateNewSerial("aae2b2ea");
        //    SoftwareSerialServer.Initialize("SoftwareSerialDbConStr");
        //    SoftwareSerialServer.Shared.PackageAndHardwareOrginalCatcher.Algorithm =alg;
        //    //var res = serialService.ValidateUserSerial(TODO, TODO);
        //    //Assert.IsTrue(res == UserSerialValidationResult.IsValid);
        //}

        [TestMethod]
        public void ValidateUserSerialWithNetworkTest()
        {
            
        }
    }
}
