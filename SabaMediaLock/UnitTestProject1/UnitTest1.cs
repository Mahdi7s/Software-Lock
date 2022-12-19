using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SabaMediaLock.Contracts;
using SoftwareSerial.Client;
using SoftwareSerial.Contracts;
using TS7S.Base.Encryption;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var url = "http://localhost:8080/ourlockserver/ps=Pz9zMj9rPz9XOz8%2fEXg%2fPz9CLD8kPz8ZUT8%2fPz8%2fFz8%2fRj8%2fTD8%2fSj8uK21LYT96P1g%3d/lockTst.swf";
            
            var regPattern = @"/ps=(.*?)/";
            var match = Regex.Match(url, regPattern);

            Assert.AreEqual("", match.Value);
        }

        [TestMethod]
        public void TestMethodN()
        {
            SoftwareSerial.Client.SoftwareSerialClient.Initialize("http://www.pcfarda.com/lockservice.svc", "7", SerialLengthEnum.Len13, "password", Hardware.CPU, Hardware.HardDisk);
            var tempSerial = SoftwareSerial.Client.SoftwareSerialClient.Shared.AutoHardwareSerialMaker.Generate("7");

            var res = SoftwareSerial.Client.SoftwareSerialClient.Shared.ValidateSerial("7", "75fe242b", "A4FC2LEJCRXLE");

            Assert.IsTrue(res.Validation == SoftwareSerial.Model.UserSerialValidationResult.IsValid);
        }

        [Serializable]
        public class tstSeri
        {
            public string N { get; set; }
            public string M { get; set; }
        }

        [TestMethod]
        public void EnDecryptTest()
        {
            var fEn = new FileEncryptor("password");

            var fPath =Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tstEn.dat");
            using (var fstrm = new FileStream(fPath, FileMode.Create, FileAccess.Write))
            {
                fEn.EncryptOrDecryptObject(fEn.GetCryptoTransform(CryptoAlgorithm.RijndaelManaged), fstrm, new tstSeri { N = "Mahdi7$" });
            }
            using (var rStrm = File.OpenRead(fPath))
            {
                var deString = fEn.EncryptOrDecryptObject<tstSeri>(fEn.GetCryptoTransform(CryptoAlgorithm.RijndaelManaged, false), rStrm);

                Assert.AreEqual(deString.N, "Mahdi7$");
            }
            fEn.AesEncrypt(@"C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg", @"C:\Users\Public\Pictures\Sample Pictures\PenguinsEn.jpg");
            fEn.AesDecrypt(@"C:\Users\Public\Pictures\Sample Pictures\PenguinsEn.jpg", @"C:\Users\Public\Pictures\Sample Pictures\Penguins1.jpg");

            fEn.DesEncrypt(@"C:\Users\Public\Videos\Sample Videos\demo.swf", @"C:\Users\Public\Videos\Sample Videos\dec\demo.swf");
            fEn.DesDecrypt(@"C:\Users\Public\Videos\Sample Videos\dec\demo.swf", @"C:\Users\Public\Videos\Sample Videos\demo1.swf");
        }
    }
}
