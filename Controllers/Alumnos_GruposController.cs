using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JSLZ_MVC_Escuela.Models;
using JSLZ_MVC_Escuela.Utilidades;
using static JSLZ_MVC_Escuela.Models.Enum;

namespace JSLZ_MVC_Escuela.Controllers
{
    public class Alumnos_GruposController : Controller
    {
        private EscuelaEntities db = new EscuelaEntities();

        // GET: Alumnos_Grupos
        
        
        
        
        
        public ActionResult Index()
        {

            var alumnos_Grupos = db.Alumnos_Grupos.Include(a => a.Alumnos).Include(a => a.Grupos);
            return View(alumnos_Grupos.ToList());
        }

        // GET: Alumnos_Grupos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos_Grupos alumnos_Grupos = db.Alumnos_Grupos.Find(id);
            if (alumnos_Grupos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos_Grupos);
        }

       
        // GET: Alumnos_Grupos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos_Grupos alumnos_Grupos = db.Alumnos_Grupos.Find(id);
            if (alumnos_Grupos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno_ID = new SelectList(db.Alumnos, "ID_Alumno", "Nombre", alumnos_Grupos.Alumno_ID);
            ViewBag.Grupo_ID = new SelectList(db.Grupos, "ID_Grupo", "Nombre", alumnos_Grupos.Grupo_ID);
            return View(alumnos_Grupos);
        }

        // POST: Alumnos_Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Alumnos_Grupos,Alumno_ID,Grupo_ID")] Alumnos_Grupos alumnos_Grupos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos_Grupos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno_ID = new SelectList(db.Alumnos, "ID_Alumno", "Nombre", alumnos_Grupos.Alumno_ID);
            ViewBag.Grupo_ID = new SelectList(db.Grupos, "ID_Grupo", "Nombre", alumnos_Grupos.Grupo_ID);
            return View(alumnos_Grupos);
        }

        // GET: Alumnos_Grupos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos_Grupos alumnos_Grupos = db.Alumnos_Grupos.Find(id);
            if (alumnos_Grupos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos_Grupos);
        }

        // POST: Alumnos_Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnos_Grupos alumnos_Grupos = db.Alumnos_Grupos.Find(id);
            db.Alumnos_Grupos.Remove(alumnos_Grupos);
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
