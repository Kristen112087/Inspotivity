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



        //Get Measurement/Edit/1
        public ActionResult Edit(int id)
        {
            var service = CreateMeasurementService();
            var detail = service.GetMeasurementById(id);
            var model = new MeasurementEdit
            {
                MeasurementsId = detail.MeasurementsId,
                Who = detail.Who,
                Height = detail.Height,
                HeadCircumference = detail.HeadCircumference,
                UpperBust = detail.UpperBust,
                FullBust = detail.FullBust,
                UnderBust = detail.UnderBust,
                Waist = detail.Waist,
                Hips = detail.Hips,
                OneThigh = detail.OneThigh,
                OneCalf = detail.OneCalf,
                OneUpperArm = detail.OneUpperArm,
                OneLowerArm = detail.OneLowerArm
            };
            return View(model);
        }

        //Post Measurement/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MeasurementEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MeasurementsId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateMeasurementService();
            if (service.UpdateMeasurement(model))
            {
                TempData["SaveResult"] = "Your measurements have been updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your measurements could not be updated");
            return View(model);
        }



        //Get Measurement/Delete/1
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateMeasurementService();
            var model = service.DeleteById(id);

            return View(model);
        }

        //Post Measurement/Delete/1
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeasurement(int id, FormCollection collection)
        {
            var service = CreateMeasurementService();
            service.DeleteMeasurement(id);

            TempData["SaveResult"] = "Your measurements were deleted";

            return RedirectToAction("Index");
        }
    }
}