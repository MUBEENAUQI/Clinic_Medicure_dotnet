using Clinic_Automation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Clinic_Automation.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [OutputCache(NoStore = true, Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();
            model.Account_List = Account_list_get.GetAccountList();
            return View("LoginPage", model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                    using (MedicareEntities db = new MedicareEntities())
                    {
                        var getdata = db.Login_Check(model.User_name, model.Password,model.Account_id).FirstOrDefault();
                        if (getdata != null)
                        {
                            //var loginids = Convert.ToInt32(getdata.Login_ID);
                            FormsAuthentication.SetAuthCookie(model.User_name, true);
                            var ticket = new FormsAuthenticationTicket(1, model.User_name, DateTime.Now, DateTime.Now.AddHours(1), true, model.User_name);
                            string encryptTicket = FormsAuthentication.Encrypt(ticket);
                            var authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                            HttpContext.Response.Cookies.Add(authcookie);
                            if (model.Account_id == 1)
                            {
                                return RedirectToAction("Patient", "Patient");
                            }
                            else if (model.Account_id == 2)
                            {
                                if (model.User_name == "Admin" && model.Password == "Admin")
                                {
                                    return RedirectToAction("Doctor", "Admin");
                                }
                                else
                                {
                                Session["LoginId"] = getdata.Login_ID;
                                return RedirectToAction("Doctor", "Doctor");
                                }
                            }
                            else if (model.Account_id == 3)
                            {
                                return RedirectToAction("Supplier", "Supplier");
                            }
                            else if (model.Account_id == 4)
                            {
                            Session["LoginId"] = getdata.Login_ID;
                            return RedirectToAction("Salesman", "Salesman");
                            }
                            else
                            {
                                ViewBag.Message = "Invalid Username or Password";
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Username or Password";
                        }
                    }
                }
               
            

            model.Account_List = Account_list_get.GetAccountList();
            return View("LoginPage", model);
        }

        public ActionResult UnauthorizedAccess()
        {
            return View();
        }
    }
}
