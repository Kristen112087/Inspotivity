using Inspotivity.Model.PaperPatternModels;
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
    public class PaperPatternController : Controller
    {
        private PaperPatternService CreatePaperPattern()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var service = new PaperPatternService(userid);
            return service;
        }




        // GET: PaperPattern/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: PaperPattern/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaperPatternCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePaperPatternService();

            if (service.CreatePaperPattern(model))
            {
                TempData["SaveResult"] = "Your pattern was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Pattern could not be created");
            return View(model);
        }




        // GET: PaperPattern
        public ActionResult Index()
        {
            var service = CreatePaperPatternService();
            var model = service.GetPaperPatterns();
            return View();
        }





        // GET: PaperPattern/Details/1
        public ActionResult Details(int id)
        {
            var service = CreatePaperPatternService();
            var model = service.GetPaperPatternById(id);

            return View(model);
        }







        // GET: PaperPattern/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreatePaperPatternService();
            var detail = service.GetPaperPatternById(id);
            var model = new PaperPatternEdit
            {
                Designer = detail.Designer,
                PatternName = detail.PatternName,
                ReleaseDate = detail.ReleaseDate,
                PurchaseDate = detail.PurchaseDate,
                PatternURL = detail.PatternURL,
                PatternNumber = detail.PatternNumber,
                Category = detail.Category,
                FabricTypeNeeded = detail.FabricTypeNeeded,
                FabricRequirementInYards = detail.FabricRequirementInYards,
                NotionsNeeded = detail.NotionsNeeded,
                WhereStored = detail.WhereStored,
                HaveMade = detail.HaveMade
            };
            return View(model);
        }
        // POST: PaperPattern/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PaperPatternEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PaperPatternId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePaperPatternService();
            if (service.UpdatePaperPattern(model))
            {
                TempData["SaveResult"] = "Your pattern was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your pattern could not be updated");
            return View(model);
        }








        // GET: PaperPattern/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreatePaperPatternService();
            var model = service.GetPaperPatternById(id);

            return View(model);
        }

        // POST: PaperPattern/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePaperPattern(int id, FormCollection collection)
        {
            var service = CreatePaperPatternService();
            service.DeletePaperPattern(id);

            TempData["SaveResult"] = "Your pattern was deleted";

            return RedirectToAction("Index");
        }







        private PaperPatternService CreatePaperPatternService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PaperPatternService(userId);
            return service;
        }
    }
}