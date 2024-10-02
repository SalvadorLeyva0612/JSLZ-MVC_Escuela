using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JSLZ_MVC_Escuela.Models;

namespace JSLZ_MVC_Escuela.Controllers
{
    public class GruposController : Controller
    {
        private EscuelaEntities db = new EscuelaEntities();

        // GET: Grupos
        public ActionResult Index()
        {
            var grupos = db.Grupos.Include(g => g.Horarios).Include(g => g.Materias).Include(g => g.Profesores);
            var alumnos = db.Alumnos.Include(al => al.ID_Alumno).Include(al => al.Nombre).Include(al => al.Apellido);
            var profes = db.Profesores.Include(pr => pr.ID_Profesor).Include(pr => pr.Nombre).Include(pr => pr.Apellido);
            var materias = db.Materias.Include(m => m.Nombre);
            var horarios = db.Horarios.Include(h => h.Horario);



            var alugru = new List<string>();

           // alugru.AddRange();
            
            



          
            
            
            return View(alumnos.ToList());
            
        }

        // GET: Grupos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            return View(grupos);
        }

        // GET: Grupos/Create
        public ActionResult Create()
        {
            ViewBag.Horario_ID = new SelectList(db.Horarios, "ID_Horario", "Horario");
            ViewBag.Materia_ID = new SelectList(db.Materias, "ID_Materia", "Nombre");
            ViewBag.Profesor_ID = new SelectList(db.Profesores, "ID_Profesor", "Nombre");
            return View();
        }

        // POST: Grupos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Grupo,Nombre,Profesor_ID,Materia_ID,Horario_ID")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                db.Grupos.Add(grupos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Horario_ID = new SelectList(db.Horarios, "ID_Horario", "Horario", grupos.Horario_ID);
            ViewBag.Materia_ID = new SelectList(db.Materias, "ID_Materia", "Nombre", grupos.Materia_ID);
            ViewBag.Profesor_ID = new SelectList(db.Profesores, "ID_Profesor", "Nombre", grupos.Profesor_ID);
            return View(grupos);
        }

        // GET: Grupos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Horario_ID = new SelectList(db.Horarios, "ID_Horario", "Horario", grupos.Horario_ID);
            ViewBag.Materia_ID = new SelectList(db.Materias, "ID_Materia", "Nombre", grupos.Materia_ID);
            ViewBag.Profesor_ID = new SelectList(db.Profesores, "ID_Profesor", "Nombre", grupos.Profesor_ID);
            return View(grupos);
        }

        // POST: Grupos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Grupo,Nombre,Profesor_ID,Materia_ID,Horario_ID")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Horario_ID = new SelectList(db.Horarios, "ID_Horario", "Horario", grupos.Horario_ID);
            ViewBag.Materia_ID = new SelectList(db.Materias, "ID_Materia", "Nombre", grupos.Materia_ID);
            ViewBag.Profesor_ID = new SelectList(db.Profesores, "ID_Profesor", "Nombre", grupos.Profesor_ID);
            return View(grupos);
        }

        // GET: Grupos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            return View(grupos);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupos grupos = db.Grupos.Find(id);
            db.Grupos.Remove(grupos);
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
