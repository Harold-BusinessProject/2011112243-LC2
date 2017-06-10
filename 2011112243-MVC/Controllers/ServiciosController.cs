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
    public class ServiciosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public ServiciosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public ServiciosController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.Servicio.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Servicio servicio = _UnityOfWork.Servicio.Get(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicio, tipoServicio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Servicio.Add(servicio);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicio);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Servicio servicio = _UnityOfWork.Servicio.Get(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicio, tipoServicio")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(servicio);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(servicio);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Servicio servicio = _UnityOfWork.Servicio.Get(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = _UnityOfWork.Servicio.Get(id);
            _UnityOfWork.Servicio.Remove(servicio);
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
