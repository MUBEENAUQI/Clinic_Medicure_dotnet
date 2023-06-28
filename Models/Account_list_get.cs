using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinic_Automation.Models
{
    public class Account_list_get
    {
        public static List<SelectListItem> GetAccountList()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            using (MedicareEntities db = new MedicareEntities())
            {
                var getdata = db.Get_Account_Type();
                foreach (var item in getdata)
                {
                    lst.Add(new SelectListItem { Text = item.Account_name, Value = item.Account_ID.ToString() });
                }
            }
            return lst;

        }
    }
}