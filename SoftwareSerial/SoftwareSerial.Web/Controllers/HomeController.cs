using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareSerial.Client;
using SoftwareSerial.Contracts;
using SoftwareSerial.Model;
using SoftwareSerial.Server;

namespace SoftwareSerial.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //TEST();
            return RedirectToAction("Index", "Serial");
        }  
      
        //private void TEST()
        //{
        //    var serialService = new SerialService();
        //    var alg = new SerialAlgorithm("[r][r][o][r][o][o]");
        //    SoftwareSerialClient.Initialize("", "theSoftware");
        //    SoftwareSerialClient.Shared.PackageAndHardwareMixedSerialMaker.Algorithm = alg;
        //    var generateSerial = SoftwareSerialClient.Shared.PackageAndHardwareMixedSerialMaker.GenerateNewSerial("88d56a7f");
        //    SoftwareSerialServer.Initialize("SoftwareSerialDbConStr");
        //    SoftwareSerialServer.Shared.PackageAndHardwareOrginalCatcher.Algorithm = alg;
        //    var res = serialService.ValidateUserSerial(TODO, TODO);
        //    Assert.IsTrue(res == UserSerialValidationResult.IsValid);
        //}
    }
}
