using Inspotivity.Model.MakeModels;
using Inspotivity.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspotivity.Controllers
{
    [Authorize]
    public class MakeController : Controller
    {
        private MakeService CreateMake()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new MakeService(userid);
            return service;
        }
        private MakeService CreateMakeService()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new MakeService(userid);
            return service;
        }

        private PaperPatternService CreatePaperPatternService()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new PaperPatternService(userid);
            return service;
        }

        private FabricService CreateFabricService()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new FabricService(userid);
            return service;
        }

        private MeasurementService CreateMeasurementsService()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new MeasurementService(userid);
            return service;
        }



        // GET: Make
        public ActionResult Index()
        {
            var service = CreateMakeService();
            var model = service.GetAllMakes();
            return View(model);
        }


        //Get Make/Create
        public ActionResult Create()
        {
            var paperService = CreatePaperPatternService();
            ViewData["PaperPatterns"] = paperService.GetPaperPatterns();

            var fabricService = CreateFabricService();
            ViewData["Fabrics"] = fabricService.GetAllFabric();

            var measurementsService = CreateMeasurementsService();
            ViewData["Measurements"] = measurementsService.GetAllMeasurements();

            return View();
        }
        //Post make/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MakeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            model.PaperPatternId = Convert.ToInt32(Request.Form["ddlPaperPattern"]);
            model.FabricId = Convert.ToInt32(Request.Form["ddlFabrics"]);
            model.MeasurementsId = Convert.ToInt32(Request.Form["ddlMeasurements"]);

            var service = CreateMakeService();

            if (service.CreateMake(model))
            {
                TempData["SaveResult"] = "You made something!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You did not make anything");
            return View(model);
        }

        //Get Make/Details/1
        public ActionResult Details(int id)
        {
            var service = CreateMakeService();
            var model = service.GetMakeById(id);
            return View(model);
        }



        //Get Make/Edit/1
        public ActionResult Edit(int id)
        {
            

            var paperService = CreatePaperPatternService();
            ViewData["PaperPatterns"] = paperService.GetPaperPatterns();

            var fabricService = CreateFabricService();
            ViewData["Fabrics"] = fabricService.GetAllFabric();

            var measurementsService = CreateMeasurementsService();
            ViewData["Measurements"] = measurementsService.GetAllMeasurements();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MakeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            //model.PaperPatternId = Convert.ToInt32(Request.Form["ddlPaperPattern"]);
            //model.FabricId = Convert.ToInt32(Request.Form["ddlFabrics"]);
            //model.MeasurementsId = Convert.ToInt32(Request.Form["ddlMeasurements"]);

            var service = CreateMakeService();

            if (service.UpdateMake(model))
            {
                TempData["SaveResult"] = "Your make was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You did not update your make");
            return View(model);
        }
    }
}