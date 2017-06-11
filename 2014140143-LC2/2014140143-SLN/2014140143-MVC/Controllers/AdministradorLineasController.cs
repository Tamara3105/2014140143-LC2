using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2014140143_ENT.Entities;
using _2014140143_PER;
using _2014140143_ENT.IRepositories;

namespace _2014140143_MVC.Controllers
{
    public class AdministradorLineasController : Controller
    {
        //private _2014140143DbContext db = new _2014140143DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public AdministradorLineasController()
        {

        }

        public AdministradorLineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: AdministradorLineas
        public ActionResult Index()
        {
            return View(_UnityOfWork.AdministrarLineas.GetAll());
        }

        // GET: AdministradorLineas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorLinea = _UnityOfWork.AdministrarLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Create
        public ActionResult Create()
        {
            //ViewBag.LineaTelefonicaId = new SelectList(db.LineaTelefonicas, "LineaTelefonicaId", "codigoLinea");
            return View();
        }

        // POST: AdministradorLineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdministradorLineaId,numeroTelefonico,fecha,estadoLinea,LineaTelefonicaId")] AdministradorLinea administradorLinea)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.AdministrarLineas.Add(administradorLinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.LineaTelefonicaId = new SelectList(db.LineaTelefonicas, "LineaTelefonicaId", "codigoLinea", administradorLinea.LineaTelefonicaId);
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorLinea = _UnityOfWork.AdministrarLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // POST: AdministradorLineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdministradorLineaId,numeroTelefonico,fecha,estadoLinea,LineaTelefonicaId")] AdministradorLinea administradorLinea)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(administradorLinea);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.LineaTelefonicaId = new SelectList(db.LineaTelefonicas, "LineaTelefonicaId", "codigoLinea", administradorLinea.LineaTelefonicaId);
            return View(administradorLinea);
        }

        // GET: AdministradorLineas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorLinea administradorLinea = _UnityOfWork.AdministrarLineas.Get(id);
            if (administradorLinea == null)
            {
                return HttpNotFound();
            }
            return View(administradorLinea);
        }

        // POST: AdministradorLineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministradorLinea administradorLinea = _UnityOfWork.AdministrarLineas.Get(id);
            _UnityOfWork.AdministrarLineas.Delete(administradorLinea);
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
