using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPROJEDB.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute :  ActionFilterAttribute
    {
        List<string> allowedScopes = new List<string>()
        {
            "/Login/Index",
            "/Login/Logout"
        };

        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["Tbl_kullanıcı"];
            if(!allowedScopes.Any(f=>f == filterContext.HttpContext.Request.Url.LocalPath))
            {
                if (user == null)
                {
                    filterContext.HttpContext.Response.Redirect("/Login/Index");
                    filterContext.HttpContext.Response.End();
                }
            }
            else
            {
                if(user != null)
                {
                    filterContext.HttpContext.Response.Redirect("/");
                    filterContext.HttpContext.Response.End();
                }
            }
        }
    }
}