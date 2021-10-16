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
            return View();
        }

        // POST: Fabric/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }







        // GET: Fabric/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fabric/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
