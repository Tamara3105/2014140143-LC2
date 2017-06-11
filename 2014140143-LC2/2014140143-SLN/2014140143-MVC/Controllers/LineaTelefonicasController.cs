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
    public class LineaTelefonicasController : Controller
    {
        //  private LineaNuevaC2DbContext db = new LineaNuevaC2DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public LineaTelefonicasController()
        {

        }

        public LineaTelefonicasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: LineaTelefonicas
        public ActionResult Index()
        {
            //var lineaTelefonicas = db.LineaTelefonicas.Include(l => l.AdministradorLinea);
            return View(_UnityOfWork.LineaTelefonicas.GetAll());
        }

        // GET: LineaTelefonicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Create
        public ActionResult Create()
        {
            // ViewBag.AdministradorLineaId = new SelectList(db.AdministradorLineas, "AdministradorLineaId", "numeroLinea");
            return View();
        }

        // POST: LineaTelefonicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LineaTelefonicaId,numeroTelefonico,iccid,fechaActivacion,AdministradorLineaId")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.LineaTelefonicas.Add(lineaTelefonica);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.AdministradorLineaId = new SelectList(db.AdministradorLineas, "AdministradorLineaId", "numeroLinea", lineaTelefonica.AdministradorLineaId);
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            // ViewBag.AdministradorLineaId = new SelectList(db.AdministradorLineas, "AdministradorLineaId", "numeroLinea", lineaTelefonica.AdministradorLineaId);
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LineaTelefonicaId,numeroTelefonico,iccid,fechaActivacion,AdministradorLineaId")] LineaTelefonica lineaTelefonica)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(lineaTelefonica);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            // ViewBag.AdministradorLineaId = new SelectList(_UnityOfWork.AdministradorLineas, "AdministradorLineaId", "numeroLinea", lineaTelefonica.AdministradorLineaId);
            return View(lineaTelefonica);
        }

        // GET: LineaTelefonicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            if (lineaTelefonica == null)
            {
                return HttpNotFound();
            }
            return View(lineaTelefonica);
        }

        // POST: LineaTelefonicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineaTelefonica lineaTelefonica = _UnityOfWork.LineaTelefonicas.Get(id);
            _UnityOfWork.LineaTelefonicas.Delete(lineaTelefonica);
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
