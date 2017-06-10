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
    public class VentasController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public VentasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public VentasController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.Venta.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venta venta = _UnityOfWork.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,Costo")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Venta.Add(venta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venta);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venta venta = _UnityOfWork.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,Costo")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(venta);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(venta);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venta venta = _UnityOfWork.Venta.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = _UnityOfWork.Venta.Get(id);
            _UnityOfWork.Venta.Remove(venta);
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
