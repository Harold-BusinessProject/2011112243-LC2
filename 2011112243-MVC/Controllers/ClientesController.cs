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
    public class ClientesController : Controller
    {
        private readonly IUnityOfWork _UnityOfWork;

        public ClientesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        public ClientesController()
        {

        }

       
        public ActionResult Index()
        {
            return View(_UnityOfWork.Cliente.GetAll());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,nom")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Cliente.Add(cliente);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,nom")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(cliente);
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

   
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = _UnityOfWork.Cliente.Get(id);
            _UnityOfWork.Cliente.Remove(cliente);
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
