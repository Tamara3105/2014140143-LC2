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
    public class TrabajadorsController : Controller
    {
        // private LineaNuevaC2DbContext db = new LineaNuevaC2DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public TrabajadorsController()
        {

        }

        public TrabajadorsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Trabajadors
        public ActionResult Index()
        {
            //return View(db.Clientes.ToList());
            return View(_UnityOfWork.Trabajadors.GetAll());
        }
        // GET: Trabajadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = _UnityOfWork.Trabajadors.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajadorId,TipoTrabajador,NombreTrabajador,ApellidoPaTrabajador,ApellidoMaTrabajador,DniTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Trabajadors.Add(trabajador);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabajador);
        }

        // GET: Trabajadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = _UnityOfWork.Trabajadors.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajadorId,TipoTrabajador,NombreTrabajador,ApellidoPaTrabajador,ApellidoMaTrabajador,DniTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(trabajador);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = _UnityOfWork.Trabajadors.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajador trabajador = _UnityOfWork.Trabajadors.Get(id);
            //_UnityOfWork.Trabajadors.Remove(trabajador);
            _UnityOfWork.Trabajadors.Delete(trabajador);
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

    

