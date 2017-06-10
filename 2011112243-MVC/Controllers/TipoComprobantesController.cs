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
    public class TiposComprobantesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public TiposComprobantesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public TiposComprobantesController()
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

            TipoComprobante tipoComprobante = _UnityOfWork.TipoComprobante.Get(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipodeComprobante")] TipoComprobante tipoComprobante)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TipoComprobante.Add(tipoComprobante);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoComprobante);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoComprobante tipoComprobante = _UnityOfWork.TipoComprobante.Get(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipodeComprobante")] TipoComprobante tipoComprobante)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(tipoComprobante);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tipoComprobante);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoComprobante tipoComprobante = _UnityOfWork.TipoComprobante.Get(id);
            if (tipoComprobante == null)
            {
                return HttpNotFound();
            }
            return View(tipoComprobante);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoComprobante tipoComprobante = _UnityOfWork.TipoComprobante.Get(id);
            _UnityOfWork.TipoComprobante.Remove(tipoComprobante);
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
