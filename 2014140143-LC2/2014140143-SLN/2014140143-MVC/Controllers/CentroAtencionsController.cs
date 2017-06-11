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
    public class CentroAtencionsController : Controller
    {
        // private LineaNuevaC2DbContext db = new LineaNuevaC2DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public CentroAtencionsController()
        {

        }

        public CentroAtencionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: CentroAtencions
        public ActionResult Index()
        {
            //var centroAtencions = db.CentroAtencions.Include(c => c._Direccion);
            return View(_UnityOfWork.CentroAtencions.GetAll());
        }

        // GET: CentroAtencions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Create
        public ActionResult Create()
        {
            //ViewBag.CentroAtencionId = new SelectList(db.Evaluacions, "EvaluacionId", "documento");
            return View();
        }

        // POST: CentroAtencions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroAtencionId,nombreCeAtencion,DireccionId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.CentroAtencions.Add(centroAtencion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CentroAtencionId = new SelectList(db.Evaluacions, "EvaluacionId", "documento", centroAtencion.CentroAtencionId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.CentroAtencionId = new SelectList(db.Evaluacions, "EvaluacionId", "documento", centroAtencion.CentroAtencionId);
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroAtencionId,nombreCeAtencion,DireccionId")] CentroAtencion centroAtencion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(centroAtencion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.CentroAtencionId = new SelectList(db.Evaluacions, "EvaluacionId", "documento", centroAtencion.CentroAtencionId);
            return View(centroAtencion);
        }

        // GET: CentroAtencions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            if (centroAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroAtencion);
        }

        // POST: CentroAtencions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CentroAtencion centroAtencion = _UnityOfWork.CentroAtencions.Get(id);
            //db.CentroAtencions.Remove(centroAtencion);
            _UnityOfWork.CentroAtencions.Delete(centroAtencion);
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
