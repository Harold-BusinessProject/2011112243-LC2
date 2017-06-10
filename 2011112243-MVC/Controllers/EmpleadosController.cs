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
    public class EmpleadosController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public EmpleadosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public EmpleadosController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.Empleado.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleado empleado = _UnityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmp,non,tipoEmp")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Empleado.Add(empleado);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleado empleado = _UnityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmp,nom,tipoEmp")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(empleado);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(empleado);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Empleado empleado = _UnityOfWork.Empleado.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _UnityOfWork.Empleado.Get(id);
            _UnityOfWork.Empleado.Remove(empleado);
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
