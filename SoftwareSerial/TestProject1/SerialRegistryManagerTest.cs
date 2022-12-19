using Microsoft.Win32;
using SoftwareSerial.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    /// <summary>
    ///This is a test class for SerialRegistryManagerTest and is intended
    ///to contain all SerialRegistryManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SerialRegistryManagerTest
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
            string registryKeyName = Registry.CurrentUser.Name;
            string valueName = "SoftwareSerial";
            var regMgr = new SerialRegistryManager(registryKeyName, valueName);
            var packages = new[] {"Pak1", "Pak2", "Pak3", "Pak4"};
            string packageName = packages[0];
            string hardwareName = Hardware.HardDisk;
            string password = "thePassword";
            //regMgr.InitializeRegValue(hardwareName, password, packages);
            bool expected = true; // TODO: Initialize to an appropriate value
            var retPacks = regMgr.GetNamesOfPackages(hardwareName, password);
            bool actual = regMgr.Validate(retPacks[retPacks.Length-1], hardwareName, password);

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemovePackages
        ///</summary>
        [TestMethod()]
        public void RemovePackagesTest()
        {
            string softwareName = "mySoftware";            
            SerialRegistryManager serialRegistryManager = new SerialRegistryManager(softwareName);
            string hardwareName = Hardware.CPU;
            string password = "2456fdhgfj";         
            serialRegistryManager.InitializeRegValue(hardwareName, password, "pak1", "pak2");
            serialRegistryManager.AddPackages(hardwareName, password, "pak3");
            var paks0 = serialRegistryManager.GetNamesOfPackages(hardwareName, password);
            serialRegistryManager.RemovePackages(hardwareName, password, "pak2");
            var packs = serialRegistryManager.GetNamesOfPackages(hardwareName, password);

            Assert.AreEqual(packs[1], "pak3");
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
