using DTO;
using JSLZ_MVC_Escuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace JSLZ_MVC_Escuela.Controllers
{
    public class CalificacionesController : Controller
    {
        private EscuelaEntities db = new EscuelaEntities();

        // GET: Calificaciones
        public ActionResult agregarCalificacion()
        {
        List<Calificaciones_DTO> lista_calid = new List<Calificaciones_DTO>();

            lista_calid = (from c in db.Calificaciones
                           join al in db.Alumnos on c.Alumno_ID equals al.ID_Alumno
                           join m in db.Materias on c.Materia_ID equals m.ID_Materia

                           select new Calificaciones_DTO()
                           {
                               C_ = c.ID_Calificacion,
                               Nombre_Alumno = al.Nombre + " " + al.Apellido,
                               Materia = m.Nombre,
                               Calificacion = 0,
                               Semestre = 0,
                               Parcial = 0


                           }).ToList();
            
            
            return View(lista_calid);
        }
    }
}