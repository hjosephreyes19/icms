using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static ICMS.Commons.Enum.ICMSEnum;
using ICMS.Web.Extension;
using ICMS.Entities.Main;
using ICMS.Web.Models;
using System.Collections.Generic;
using ICMS.Commons.Helper;
using ICMS.Web.Models.Module;

namespace ICMS.Web.Attribute
{
    public class SharedDataAttribute : ActionFilterAttribute
    {
        public SharedDataAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //if (filterContext.HttpContext.Session.GetString(UserSessionHelper.USER_NAME) != null)
            //{
                var controller = filterContext.Controller as Controller;
                if (controller != null)
                {
                    controller.ViewData.Add("modules", filterContext.HttpContext.Session.GetObjectFromJson<List<ModuleViewModel>>(UserSessionHelper.MODULES));
                    //controller.ViewData.Add("userRole", filterContext.HttpContext.Session.GetString(SessionHelper.ROLES));
                    //controller.ViewData.Add("user", filterContext.HttpContext.Session.GetString(SessionHelper.USER_NAME));

                    var user = filterContext.HttpContext.Session.GetObjectFromJson<User>(UserSessionHelper.USER);
                    if (user != null)
                    {
                        controller.ViewData.Add("firstName", user.firstName);
                        controller.ViewData.Add("lastName", user.lastName);
                    }
                }
            //}
        }
    }
}