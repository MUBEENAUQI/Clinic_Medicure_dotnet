using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Controllers
{

    [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
    [Authorize]
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult Supplier()
        {
            return View("SupplierPage");
        }
    }
}