//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JSLZ_MVC_Escuela.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumnos_Grupos
    {
        public int ID_Alumnos_Grupos { get; set; }
        public Nullable<int> Alumno_ID { get; set; }
        public Nullable<int> Grupo_ID { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Grupos Grupos { get; set; }
    }
}
