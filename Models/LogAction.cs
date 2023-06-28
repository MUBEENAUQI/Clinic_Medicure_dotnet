using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Clinic_Automation.Models
{

    public class LogAction : ActionFilterAttribute 
    { 
        public override void OnActionExecuted(ActionExecutedContext filterContext) 
        { 
            LogData("OnActionExecuted", filterContext.RouteData); 
        } 
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        { 
            LogData("OnResultExecuting", filterContext.RouteData); 
        } 
        private void LogData(string methodname, RouteData routeData) 
        { var controllername = routeData.Values["controller"]; 
            var actionname = routeData.Values["action"];
            Debug.WriteLine($"Method Name: {methodname}, Controller: {controllername}, Action: {actionname}"); 
        }
    }
}
