using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Library.DAL.Models;

namespace TespApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ILogger<CarsController> _logger;
        private readonly TestAppEntities _ctx;

        public CarsController(ILogger<CarsController> logger, TestAppEntities ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await Cars.GetList(_ctx);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cars carsModel)
        {
            carsModel.is_active = true;
            carsModel.created_at = DateTime.Now;

            carsModel = await Cars.Add(_ctx, carsModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await Cars.GetItem(_ctx, id);
            model.isActive = model.is_active ?? false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cars carsModel)
        {
            carsModel.is_active = carsModel.isActive;
            var result = await Cars.Update(_ctx, carsModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Cars.GetItem(_ctx, id);
            model.isActive = model.is_active ?? false;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cars carsModel)
        {
            var result = await Cars.Delete(_ctx, carsModel.car_id);

            return RedirectToAction(nameof(Index));
        }
    }
}
