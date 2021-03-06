using Microsoft.AspNetCore.Mvc;
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
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly TestAppEntities _ctx;

        public UsersController(ILogger<UsersController> logger, TestAppEntities ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await Users.GetList(_ctx);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Users model)
        {
            model.is_active = true;
            model.created_at = DateTime.Now;

            model = await Users.Add(_ctx, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Users.GetItem(_ctx, id);
            model.isActive = model.is_active ?? false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Users model)
        {
            model.is_active = model.isActive;
            var result = await Users.Update(_ctx, model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Users.GetItem(_ctx, id);
            model.isActive = model.is_active ?? false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Users model)
        {
            var result = await Users.Delete(_ctx, model.user_id);

            return RedirectToAction(nameof(Index));
        }
    }
}
