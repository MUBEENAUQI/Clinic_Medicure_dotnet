using Clinic_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Clinic_Automation.Controllers
{
    [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Admin()
        {
            
                return View("AdminPage");
           
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            LoginModel model = new LoginModel();
            model.Account_List = Account_list_get.GetAccountList();
            return RedirectToAction("Login","Login", model);
            

        }
    }
}