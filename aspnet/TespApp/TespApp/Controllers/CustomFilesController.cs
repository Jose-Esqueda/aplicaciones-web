using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
    public class CustomFilesController : BaseController
    {
        private readonly ILogger<CustomFilesController> _logger;
        private readonly TestAppEntities _ctx;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CustomFilesController(ILogger<CustomFilesController> logger, TestAppEntities ctx, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _ctx = ctx;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await CustomFiles.GetList(_ctx);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomFilesCreateViewModel();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await CustomFiles.Delete(_ctx, id);
            return RedirectToAction(nameof(CustomFilesController.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var modelOld = await CustomFilesCreateViewModel.GetItem(_ctx,id);
            var model = new CustomFilesCreateViewModel();
            model.description = modelOld.description;
            model.customfile_id = modelOld.customfile_id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomFilesCreateViewModel model, int id)
        {
            if (model.file != null && model.file.Length > 0)
            {
                string fileName = String.Empty;
                string filePath = String.Empty;
                byte[] bytes;
                var fileExtension = "pdf";

                fileName = String.Format("CustomFile_{0}.{1}", Guid.NewGuid().ToString(), fileExtension);
                filePath = Path.Combine(
                    Path.Combine(
                        _hostingEnvironment.ContentRootPath,
                        "customfiles"),
                    fileName);

                using (var ms = new MemoryStream())
                {
                    model.file.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                var modelToEdit = await CustomFiles.GetItem(_ctx, id);
                modelToEdit.description = model.description;


                await CustomFiles.Update(_ctx, modelToEdit);
                //{
                //    customfile_id = model.customfile_id,
                //    description = model.description,
                //    path = filePath
                //});

                return RedirectToAction(nameof(CustomFilesController.Index));
            }
            else
            {
                ModelState.AddModelError(String.Empty, "File is required.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomFilesCreateViewModel model)
        {
            if (model.file != null && model.file.Length > 0)
            {
                string fileName = String.Empty;
                string filePath = String.Empty;
                byte[] bytes;
                var fileExtension = "pdf";

                fileName = String.Format("CustomFile_{0}.{1}", Guid.NewGuid().ToString(), fileExtension);
                filePath = Path.Combine(
                    Path.Combine(
                        _hostingEnvironment.ContentRootPath, 
                        "customfiles"), 
                    fileName);

                using (var ms = new MemoryStream())
                {
                    model.file.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                await CustomFiles.Add(_ctx, new CustomFiles()
                {
                    description = model.description,
                    path = filePath
                });

                return RedirectToAction(nameof(CustomFilesController.Index));
            }
            else
            {
                ModelState.AddModelError(String.Empty, "File is required.");
                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var item = await CustomFiles.GetItem(_ctx, id);
            //System.IO.File.Delete(item.path);

            if (System.IO.File.Exists(item.path))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(item.path);
                return File(fileBytes, "application/pdf", String.Format("{0}.pdf", item.description));
            }
            else
            {
                //
            }

            return View("Index");
        }
    }
}
