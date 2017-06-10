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
    public class TipoPagosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public TipoPagosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public TipoPagosController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.TipoPago.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoPago tipoPago = _UnityOfWork.TipoPago.Get(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipodePago")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.TipoPago.Add(tipoPago);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPago);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoPago tipoPago = _UnityOfWork.TipoPago.Get(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipodePago")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(tipoPago);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tipoPago);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoPago tipoPago = _UnityOfWork.TipoPago.Get(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPago tipoPago = _UnityOfWork.TipoPago.Get(id);
            _UnityOfWork.TipoPago.Remove(tipoPago);
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
