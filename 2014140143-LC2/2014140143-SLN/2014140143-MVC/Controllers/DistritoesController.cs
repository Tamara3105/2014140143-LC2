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
    public class DistritoesController : Controller
    {
        // private LineaNuevaC2DbContext db = new LineaNuevaC2DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public DistritoesController()
        {

        }

        public DistritoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Distritoes
        public ActionResult Index()
        {
            // var distritos = db.Distritos.Include(d => d.Provincia);
            return View(_UnityOfWork.Distritos.GetAll());
        }

        // GET: Distritoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritoes/Create
        public ActionResult Create()
        {
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "CodigoProvincia");
            return View();
        }

        // POST: Distritoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,CodigoDistrito,NombreDistrito,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Distritos.Add(distrito);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "CodigoProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            // ViewBag.ProvinciaId = new SelectList(_UnityOfWork.Provincias, "ProvinciaId", "CodigoProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // POST: Distritoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,CodigoDistrito,NombreDistrito,ProvinciaId")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(distrito);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ProvinciaId = new SelectList(db.Provincias, "ProvinciaId", "CodigoProvincia", distrito.ProvinciaId);
            return View(distrito);
        }

        // GET: Distritoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = _UnityOfWork.Distritos.Get(id);
            _UnityOfWork.Distritos.Delete(distrito);
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
