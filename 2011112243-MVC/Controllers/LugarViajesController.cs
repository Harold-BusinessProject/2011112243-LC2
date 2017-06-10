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
    public class LugarViajesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public LugarViajesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public LugarViajesController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.LugarViaje.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LugarViaje lugarViaje = _UnityOfWork.LugarViaje.Get(id);
            if (lugarViaje == null)
            {
                return HttpNotFound();
            }
            return View(lugarViaje);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idLugarViaje, ciudad")] LugarViaje lugarViaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.LugarViaje.Add(lugarViaje);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lugarViaje);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LugarViaje lugarViaje = _UnityOfWork.LugarViaje.Get(id);
            if (lugarViaje == null)
            {
                return HttpNotFound();
            }
            return View(lugarViaje);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idLugarViaje, ciudad")] LugarViaje lugarViaje)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(lugarViaje);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(lugarViaje);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LugarViaje lugarViaje = _UnityOfWork.LugarViaje.Get(id);
            if (lugarViaje == null)
            {
                return HttpNotFound();
            }
            return View(lugarViaje);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LugarViaje lugarViaje = _UnityOfWork.LugarViaje.Get(id);
            _UnityOfWork.LugarViaje.Remove(lugarViaje);
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
