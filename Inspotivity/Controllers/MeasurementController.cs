using Inspotivity.Model.MeasurementModels;
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
    public class MeasurementController : Controller
    {
        private MeasurementService CreateMeasurement()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new MeasurementService(userid);
            return service;
        }

        private MeasurementService CreateMeasurementService()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new MeasurementService(userid);
            return service;
        }





        // GET: Measurement
        public ActionResult Index()
        {
            var service = CreateMeasurementService();
            var model = service.GetAllMeasurements();
            return View(model);
        }





        //Get Measurement/Create
        public ActionResult Create()
        {
            return View();
        }
        //Post Measurement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeasurementCreate model)
        {
            if(!ModelState.IsValid) return View(model);

            var service = CreateMeasurementService();

            if (service.CreateMeasurement(model))
            {
                TempData["SaveResult"] = "Your measurements were created";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Measurements could not be created");
            return View(model);
        }





        //Get Measurement/Detail/1
        public ActionResult Details(int id)
        {
            var service = CreateMeasurementService();
            var model = service.GetMeasurementById(id);

            return View(model);
        }
    }
}