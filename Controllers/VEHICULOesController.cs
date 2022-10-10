using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehiculosWebApp.Models;

namespace VehiculosWebApp.Controllers
{
    public class VEHICULOesController : Controller
    {
        private DBVEHICULOSEntities db = new DBVEHICULOSEntities();

        // GET: VEHICULOes
        public ActionResult Index()
        {
            return View(db.VEHICULOS.ToList());
        }

        // GET: VEHICULOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULOS.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // GET: VEHICULOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VEHICULOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Placa,Marca,Modelo,Color,Pasajeros")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.VEHICULOS.Add(vEHICULO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vEHICULO);
        }

        // GET: VEHICULOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULOS.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // POST: VEHICULOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Placa,Marca,Modelo,Color,Pasajeros")] VEHICULO vEHICULO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vEHICULO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vEHICULO);
        }

        // GET: VEHICULOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICULO vEHICULO = db.VEHICULOS.Find(id);
            if (vEHICULO == null)
            {
                return HttpNotFound();
            }
            return View(vEHICULO);
        }

        // POST: VEHICULOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VEHICULO vEHICULO = db.VEHICULOS.Find(id);
            db.VEHICULOS.Remove(vEHICULO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
