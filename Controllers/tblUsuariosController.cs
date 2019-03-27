using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NETCRUD.Models;

namespace ASP.NETCRUD.Controllers
{
    public class tblUsuariosController : Controller
    {
        private dbDiseñadoresAsociadosEntities db = new dbDiseñadoresAsociadosEntities();

        // GET: tblUsuarios
        public ActionResult Index()
        {
            return View(db.tblUsuarios.ToList());
        }

        // GET: tblUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuarios.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // GET: tblUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,nombre,pass")] tblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                db.tblUsuarios.Add(tblUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUsuario);
        }

        // GET: tblUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuarios.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // POST: tblUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,nombre,pass")] tblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUsuario);
        }

        // GET: tblUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuario tblUsuario = db.tblUsuarios.Find(id);
            if (tblUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuario);
        }

        // POST: tblUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsuario tblUsuario = db.tblUsuarios.Find(id);
            db.tblUsuarios.Remove(tblUsuario);
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
