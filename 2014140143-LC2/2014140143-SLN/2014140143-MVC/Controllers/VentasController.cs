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
    public class VentasController : Controller
    {
        //  private LineaNuevaC2DbContext db = new LineaNuevaC2DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public VentasController()
        {

        }

        public VentasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        // GET: Ventas
        public ActionResult Index()
        {
            // return View(db.Ventas.ToList());
            return View(_UnityOfWork.Ventas.GetAll());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Ventas.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            //  ViewBag.CentroAtencionId = new SelectList(db.CentroAtencions, "CentroAtencionId", "NombreCeAtencion");
            //ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "NombreCliente");
            //  ViewBag.EvaluacionId = new SelectList(db.Evaluacions, "EvaluacionId", "Documento");
            // ViewBag.LineaTelefonicaId = new SelectList(db.LineaTelefonicas, "LineaTelefonicaId", "numeroTelefonico");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,EvaluacionId,ClienteId,LineaTelefonicaId,TipoPago,CentroAtencionId,NumeroVenta,ModalidadVenta,FechaVenta,MontoVenta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Ventas.Add(venta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Ventas.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,EvaluacionId,ClienteId,LineaTelefonicaId,TipoPago,CentroAtencionId,NumeroVenta,ModalidadVenta,FechaVenta,MontoVenta")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(venta);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = _UnityOfWork.Ventas.Get(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = _UnityOfWork.Ventas.Get(id);
            // db.Ventas.Remove(venta);
            _UnityOfWork.Ventas.Delete(venta);
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
