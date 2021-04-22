using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TespApp.Models;
using TestApp.Library.DAL.Models;

namespace TespApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            SessionViewModel sessionObject = HttpContext.Session.GetJson<SessionViewModel>("SessionObject") ?? new SessionViewModel();
            if(sessionObject == null || sessionObject.UserId == 0)
            {
                HttpContext.Session.Clear();
                context.Result = RedirectToAction(nameof(SessionController.Login), "Session");
            }

            //base.OnActionExecuting(context);
        }
    }
}
