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
    public class ProvinciasController : Controller
    {
        //private LineaTelefonicaCDbContext db = new LineaTelefonicaCDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public ProvinciasController()
        {

        }

        public ProvinciasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        // GET: Provincias
        public ActionResult Index()
        {
            //  return View(db.Provincias.ToList());
            return View(_UnityOfWork.Provincias.GetAll());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincias.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            // ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "CodigoDepartamento");
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaId,DepartamentoId,CodigoProvincia,NombreProvincia")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Provincias.Add(provincia);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "CodigoDepartamento", provincia.DepartamentoId);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincias.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaId,DepartamentoId,CodigoProvincia,NombreProvincia")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(provincia);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //  ViewBag.DepartamentoId = new SelectList(db.Departamentos, "DepartamentoId", "CodigoDepartamento", provincia.DepartamentoId);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _UnityOfWork.Provincias.Get(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = _UnityOfWork.Provincias.Get(id);
            //db.Provincias.Remove(provincia);
            _UnityOfWork.Provincias.Delete(provincia);
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
