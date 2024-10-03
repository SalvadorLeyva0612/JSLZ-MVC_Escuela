using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GruposAlumnos_DTO
    {
        public int c_ { get; set; }
        public int ID_Grupo {get; set;}
        public string Nombre_Grupo {get; set;}
        public int ID_Alumno {get; set;}
        public string Nombre_Alumno {get; set;}
        public int ID_Profe {get; set;}
        public string Nombre_Profe { get;set; }
        public string Materia {get; set;}
        public string Horario { get; set; }
    }
}
