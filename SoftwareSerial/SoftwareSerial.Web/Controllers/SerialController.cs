using System;
using System.Web.Mvc;
using System.Linq;
using SoftwareSerial.Model;
using SoftwareSerial.Server;
using SoftwareSerial.Web.ViewModels;

namespace SoftwareSerial.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class SerialController : Controller
    {
        public ActionResult Index(string skey = "", string sval = "", int pageSize = 60, int page = 1)
        {
            var query = SoftwareSerialServer.Shared.Repositories.UserSerialRep.Search(skey, sval);
            return
                View(
                    new
                        SerialReportViewModel
                        {
                            Result =
                                query.OrderBy(x => x.UserSerialId).Skip((page - 1)*pageSize).Take(pageSize).ToList(),
                            Search =
                                new SerialReportViewModel.ReportSearch
                                    {skey = skey, sval = sval, pageSize = pageSize, page = page}
                        });
        }

        public ActionResult Generate(string softwareName, int usingCount, int count = 0)
        {
            string[] model = null;
            int trackingCode;
            if (count > 0)
            {
                model = SoftwareSerialServer.Shared.PackageSerialMacker.GenerateSerials(softwareName, usingCount, count, out trackingCode, onHardGenerating: () =>
                                                                                                                     {
                                                                                                                         ModelState
                                                                                                                             .
                                                                                                                             AddModelError
                                                                                                                             ("",
                                                                                                                              "The Serial Maker Have Hard working for creating serials !");
                                                                                                                         return
                                                                                                                             false;
                                                                                                                     });
            }
            
            return View(model);
        }
    }
}
