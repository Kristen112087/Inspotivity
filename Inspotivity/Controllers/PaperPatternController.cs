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

        // GET: PaperPattern/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaperPattern/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PaperPattern/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaperPattern/Edit/5
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

        // GET: PaperPattern/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaperPattern/Delete/5
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

        private PaperPatternService CreatePaperPatternService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PaperPatternService(userId);
            return service;
        }
    }
}
