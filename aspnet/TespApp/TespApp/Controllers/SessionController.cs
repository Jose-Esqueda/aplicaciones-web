using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TespApp.Models;
using TestApp.Library.BLL;
using TestApp.Library.DAL.Models;

namespace TespApp.Controllers
{
    public class SessionController : Controller
    {
        private readonly ILogger<SessionController> _logger;
        private readonly TestAppEntities _ctx;

        public SessionController(ILogger<SessionController> logger, TestAppEntities ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await Session.ValidateCredentials(_ctx, model.Email, model.Password);
            if(String.IsNullOrWhiteSpace(result.Item2))
            {
                var sessionObject = new SessionViewModel()
                {
                    UserId = result.Item1.user_id,
                    FirstName = result.Item1.first_names
                };

                HttpContext.Session.SetJson("SessionObject", sessionObject);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
                ModelState.AddModelError(String.Empty, result.Item2);


            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

    }
}
