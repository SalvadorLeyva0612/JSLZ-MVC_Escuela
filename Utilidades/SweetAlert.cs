using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static JSLZ_MVC_Escuela.Models.Enum;

namespace JSLZ_MVC_Escuela.Utilidades
{
    public class SweetAlert
    {
        public static string Sweet_Alert(string title, string msg, NotificationType nt)
        {
            var script = "<Script languaje ='javascript'>" +
                  "Swal.fire({" +
                  "title: '" + title + "'," +
                  "text: '" + msg + "'," +
                  "icon: '" + nt + "'" +
                  "});" +
                  "</Script>";

            return script;
        }

    }
}