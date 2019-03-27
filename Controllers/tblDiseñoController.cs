using System;
using System.IO;
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
    public class tblDiseñoController : Controller
    {
        private dbDiseñadoresAsociadosEntities db = new dbDiseñadoresAsociadosEntities();

        // GET: tblDiseño
        public ActionResult Index()
        {
            return View(db.tblDiseño.ToList());
        }

        // GET: tblDiseño/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDiseño tblDiseño = db.tblDiseño.Find(id);
            if (tblDiseño == null)
            {
                return HttpNotFound();
            }
            return View(tblDiseño);
        }

        // GET: tblDiseño/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblDiseño/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDiseño,precio,talla,color,cantidad,marca,descripcion,nombre,apellido")] tblDiseño tblDiseño, HttpPostedFileBase imagen)
        {

            if (imagen != null && imagen.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binary = new BinaryReader(imagen.InputStream))
                {
                    imageData = binary.ReadBytes(imagen.ContentLength);
                }
                tblDiseño.imagen = imageData;
            }

            if (ModelState.IsValid)
            {
                db.tblDiseño.Add(tblDiseño);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDiseño);
        }
        
        public ActionResult convertir(int id)
        {
            var imagen = db.tblDiseño.Where(x => x.idDiseño == id)
                  .FirstOrDefault();

            if (imagen.imagen == null)
            {
                return null;
            }
            else
            {
                return File(imagen.imagen, "image/jpeg");
            }

        }                      

        // GET: tblDiseño/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDiseño tblDiseño = db.tblDiseño.Find(id);
            if (tblDiseño == null)
            {
                return HttpNotFound();
            }
            return View(tblDiseño);
        }

        // POST: tblDiseño/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDiseño,precio,talla,color,cantidad,marca,descripcion,nombre,apellido")] tblDiseño tblDiseño, HttpPostedFileBase imagen)
        {
            if (imagen != null && imagen.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binary = new BinaryReader(imagen.InputStream))
                {
                    imageData = binary.ReadBytes(imagen.ContentLength);
                }
                tblDiseño.imagen = imageData;
            }

            if (ModelState.IsValid)
            {
                db.Entry(tblDiseño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDiseño);
        }

        // GET: tblDiseño/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDiseño tblDiseño = db.tblDiseño.Find(id);
            if (tblDiseño == null)
            {
                return HttpNotFound();
            }
            return View(tblDiseño);
        }

        // POST: tblDiseño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDiseño tblDiseño = db.tblDiseño.Find(id);
            db.tblDiseño.Remove(tblDiseño);
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
