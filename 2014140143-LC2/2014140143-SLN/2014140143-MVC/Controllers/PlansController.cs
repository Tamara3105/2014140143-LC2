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
    public class PlansController : Controller
    {
        //private LineaNuevaC2DbContext db = new LineaNuevaC2DbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public PlansController()
        {

        }

        public PlansController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }


        // GET: Plans
        public ActionResult Index()
        {
            //return View(db.Plans.ToList());
            return View(_UnityOfWork.Plans.GetAll());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _UnityOfWork.Plans.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,TipoPlan,CodigoPlan,TopeConsumo,CargoFijo,CaracteristicaPlan")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.Plans.Add(plan);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plan);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _UnityOfWork.Plans.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,TipoPlan,CodigoPlan,TopeConsumo,CargoFijo,CaracteristicaPlan")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _UnityOfWork.StateModified(plan);
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plan);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = _UnityOfWork.Plans.Get(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = _UnityOfWork.Plans.Get(id);
            // db.Plans.Remove(plan);
            _UnityOfWork.Plans.Delete(plan);
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
