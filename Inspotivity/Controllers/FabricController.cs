using Inspotivity.Model.FabricModels;
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
    public class FabricController : Controller
    {
        private FabricService CreateFabric()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new FabricService(userid);
            return service;
        }
        private FabricService CreateFabricService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FabricService(userId);
            return service;
        }



        // GET: Fabric
        public ActionResult Index()
        {
            var service = CreateFabricService();
            var model = service.GetAllFabric();
            return View(model);
        }





        // GET: Fabric/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabric/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FabricCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFabricService();

            if (service.CreateFabric(model))
            {
                TempData["SaveResult"] = "Your fabric was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Fabric could not be added");
            return View(model);
        }





        // GET: Fabric/Details/5
        public ActionResult Details(int id)
        {
            var service = CreateFabricService();
            var model = service.GetFabricById(id);

            return View(model);
        }







        // GET: Fabric/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateFabricService();
            var detail = service.GetFabricById(id);
            var model = new FabricEdit
            {
                FabricId = detail.FabricId,
                FabricType = detail.FabricType,
                FiberContent = detail.FiberContent,
                WeightPerYard = detail.WeightPerYard,
                DatePurchased = detail.DatePurchased,
                PricePerYard = detail.PricePerYard,
                StretchPercentage = detail.StretchPercentage,
                YardsOnHand = detail.YardsOnHand
            };
            return View(model);
        }

        // POST: Fabric/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FabricEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FabricId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateFabricService();
            if (service.UpdateFabric(model))
            {
                TempData["SaveResult"] = "Your fabric was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your fabric could not be updated");
            return View(model);
        }







        // GET: Fabric/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateFabricService();
            var model = service.DeletebyId(id);

            return View(model);
        }

        // POST: Fabric/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFabric(int id, FormCollection collection)
        {
            var service = CreateFabricService();
            service.DeleteFabric(id);

            TempData["SaveResult"] = "Your fabric was deleted";

            return RedirectToAction("Index");
        }
    }
}
