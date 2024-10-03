using JSLZ_MVC_Escuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DTO;
using System.Drawing.Drawing2D;
namespace JSLZ_MVC_Escuela.Controllers
{
    public class GrupoController : Controller
    {
        private EscuelaEntities db = new EscuelaEntities();
        // GET: Grupo
        public ActionResult Index()
        {
          List<GruposAlumnos_DTO> listaGruAlu = new List<GruposAlumnos_DTO>();

            listaGruAlu = (from ls in db.listaenGrupos
                           join gr in db.Grupos on ls.Grupo_ID equals gr.ID_Grupo
                           join alu in db.Alumnos on ls.Alumno_ID equals alu.ID_Alumno
                           join pf in db.Profesores on ls.Profe_ID equals pf.ID_Profesor
                           join m in db.Materias on ls.Materia_ID equals m.ID_Materia
                           join h in db.Horarios on ls.Horario_ID equals h.ID_Horario

        select new GruposAlumnos_DTO()
        {
            c_ = ls.ID_GrupoAlum,
        ID_Grupo = gr.ID_Grupo,
        Nombre_Grupo = gr.Nombre,
        ID_Alumno = alu.ID_Alumno,
        Nombre_Alumno = alu.Nombre +" "+ alu.Apellido,
        ID_Profe = pf.ID_Profesor,
        Nombre_Profe = pf.Nombre +" "+ pf.Apellido,
        Materia = m.Nombre,
        Horario = h.Horario

        }).ToList();
            ViewBag.Titulo = "Lista de Grupos y Alumnos";
            return View(listaGruAlu);
        }
    }
}