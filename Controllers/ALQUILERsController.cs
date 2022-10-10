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
    public class ALQUILERsController : Controller
    {
        private DBVEHICULOSEntities db = new DBVEHICULOSEntities();

        // GET: ALQUILERs
        public ActionResult Index()
        {
            var aLQUILERs = db.ALQUILERs.Include(a => a.CLIENTE).Include(a => a.VEHICULO);
            return View(aLQUILERs.ToList());
        }

        // GET: ALQUILERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUILER aLQUILER = db.ALQUILERs.Find(id);
            if (aLQUILER == null)
            {
                return HttpNotFound();
            }
            return View(aLQUILER);
        }

        // GET: ALQUILERs/Create
        public ActionResult Create()
        {
            ViewBag.FK_IdClientes = new SelectList(db.CLIENTES, "IdClientes", "Nombre");
            ViewBag.FK_Placa = new SelectList(db.VEHICULOS, "Placa", "Marca");
            return View();
        }

        // POST: ALQUILERs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlquiler,Localizacion,FechaDeEntrega,FechaDeDevolucion,FK_IdClientes,FK_Placa")] ALQUILER aLQUILER)
        {
            if (ModelState.IsValid)
            {
                db.ALQUILERs.Add(aLQUILER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_IdClientes = new SelectList(db.CLIENTES, "IdClientes", "Nombre", aLQUILER.FK_IdClientes);
            ViewBag.FK_Placa = new SelectList(db.VEHICULOS, "Placa", "Marca", aLQUILER.FK_Placa);
            return View(aLQUILER);
        }

        // GET: ALQUILERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUILER aLQUILER = db.ALQUILERs.Find(id);
            if (aLQUILER == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_IdClientes = new SelectList(db.CLIENTES, "IdClientes", "Nombre", aLQUILER.FK_IdClientes);
            ViewBag.FK_Placa = new SelectList(db.VEHICULOS, "Placa", "Marca", aLQUILER.FK_Placa);
            return View(aLQUILER);
        }

        // POST: ALQUILERs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlquiler,Localizacion,FechaDeEntrega,FechaDeDevolucion,FK_IdClientes,FK_Placa")] ALQUILER aLQUILER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLQUILER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_IdClientes = new SelectList(db.CLIENTES, "IdClientes", "Nombre", aLQUILER.FK_IdClientes);
            ViewBag.FK_Placa = new SelectList(db.VEHICULOS, "Placa", "Marca", aLQUILER.FK_Placa);
            return View(aLQUILER);
        }

        // GET: ALQUILERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALQUILER aLQUILER = db.ALQUILERs.Find(id);
            if (aLQUILER == null)
            {
                return HttpNotFound();
            }
            return View(aLQUILER);
        }

        // POST: ALQUILERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALQUILER aLQUILER = db.ALQUILERs.Find(id);
            db.ALQUILERs.Remove(aLQUILER);
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
