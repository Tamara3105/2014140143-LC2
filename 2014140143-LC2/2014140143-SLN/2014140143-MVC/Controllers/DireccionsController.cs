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
    public class DireccionsController : Controller
    {
        //  private LineaTelefonicaCDbContext db = new LineaTelefonicaCDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public DireccionsController()
        {

        }

        public DireccionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
        // GET: Direccions
        public ActionResult Index()
        {
            return View(_UnityOfWork.Direccions.GetAll());

        }

        // GET: Direccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }


        // GET: Direccions/Create
        public ActionResult Create()
        {
            //ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "CodigoUbigeo");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DireccionId,codigoDireccion,descripcionDireccion,UbigeoId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Direccions.Add(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

          //  ViewBag.DireccionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "nombreCeAtencion", direccion.DireccionId);
           // ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "codUbigeo", direccion.UbigeoId);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            /*ViewBag.DireccionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "nombreCeAtencion", direccion.DireccionId);
            ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "codUbigeo", direccion.UbigeoId); */
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Edit([Bind(Include = "DireccionId,codigoDireccion,descripcionDireccion,UbigeoId")] Direccion direccion)
       public ActionResult Edit([Bind(Include = "DireccionId,UbigeoId,DescripcionDireccion")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(direccion).State = EntityState.Modified;
                _UnityOfWork.StateModified(direccion);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            //  ViewBag.UbigeoId = new SelectList(db.Ubigeos, "UbigeoId", "CodigoUbigeo", direccion.UbigeoId);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = _UnityOfWork.Direccions.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
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
