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
    public class DepartamentoesController : Controller
    {
       // private _2014140143DbContext db = new _2014140143DbContext();

        // private LineaTelefonicaCDbContext db = new LineaTelefonicaCDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public DepartamentoesController()
        {

        }

        public DepartamentoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Departamentoes
        public ActionResult Index()
        {
            return View(_UnityOfWork.Departamentos.GetAll());
        }


        // GET: Departamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentoId,CodigoDepartamento,NombreDepartamento")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Departamentos.Add(departamento);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(departamento);
        }

        // GET: Departamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentoId,codigoDepartamento,nombreDepartamento")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(departamento).State = EntityState.Modified;
                _UnityOfWork.StateModified(departamento);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        // GET: Departamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = _UnityOfWork.Departamentos.Get(id);
            //db.Departamentos.Remove(departamento);
            _UnityOfWork.Departamentos.Delete(departamento);
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
