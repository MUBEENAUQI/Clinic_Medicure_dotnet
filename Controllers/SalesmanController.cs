using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{

    [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
    [Authorize]
    public class SalesmanController : Controller
    {
        // GET: Salesman
        public ActionResult Salesman()
        {
            return View("SalesmanPage");
        }
    }
}