using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2011112243.MVC;
using _2011112243;

namespace _2011112243.MVC
{
    public class BusesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public BusesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public BusesController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.Bus.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _UnityOfWork.Bus.Get(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "_idBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Bus.Add(bus);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bus);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _UnityOfWork.Bus.Get(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusId")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(bus);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(bus);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Bus bus = _UnityOfWork.Bus.Get(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bus bus = _UnityOfWork.Bus.Get(id);
            _UnityOfWork.Bus.Remove(bus);
            _UnityOfWork.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
