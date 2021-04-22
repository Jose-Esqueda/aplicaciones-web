using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TespApp.Models;
using TestApp.Library.DAL.Models;

namespace TespApp.Controllers
{
    public class UsersExtendedController : BaseController
    {
        private readonly ILogger<UsersExtendedController> _logger;
        private readonly TestAppEntities _ctx;

        public UsersExtendedController(ILogger<UsersExtendedController> logger, TestAppEntities ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await UsersExtended.GetListExtended(_ctx);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var list = await Roles.GetList(_ctx);
            ViewBag.listRoles = new SelectList(list, "role_id", "description");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsersExtended model)
        {
            model.is_active = true;
            model.created_at = DateTime.Now;

            model = await UsersExtended.Add(_ctx, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await UsersExtended.GetItem(_ctx, id);
            model.isActive = model.is_active ?? false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsersExtended model)
        {
            model.is_active = model.isActive;
            var result = await UsersExtended.Update(_ctx, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await UsersExtended.GetItem(_ctx, id);
            model.isActive = model.is_active ?? false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UsersExtended model)
        {
            var result = await UsersExtended.Delete(_ctx, model.user_id);

            return RedirectToAction(nameof(Index));
        }
    }
}
