using JSLZ_MVC_Escuela.Models;
using JSLZ_MVC_Escuela.Utilidades;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Management;
using System.Web.Mvc;
using static JSLZ_MVC_Escuela.Models.Enum;

namespace JSLZ_MVC_Escuela.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Usuarios user) 
        {
            try
            {
                using (EscuelaEntities context = new EscuelaEntities())
                {                 
                    Usuarios dbUsario = (from usuario in context.Usuarios
                                         where usuario.Contraseña.Trim().ToUpper() == user.Contraseña.Trim().ToUpper() && usuario.Nombre_Usuario.Trim().ToUpper() == user.Nombre_Usuario.Trim().ToUpper() select usuario).FirstOrDefault();

                    if (dbUsario != null)
                    {
                        Session["N_Usuario"] = dbUsario.Nombre_Usuario;
                        Session["rol"] = dbUsario.Rol_ID;
                        TempData["sweetalert"] =
                        SweetAlert.Sweet_Alert("Bienvenido", $"Bienvenido Picios@{dbUsario.Nombre_Usuario}", NotificationType.success); 

                       return RedirectToAction("Index", "Grupo/Index");
                    }
                    else
                    {
                        Session.RemoveAll();
                        Session.Clear();
                      TempData["sweetalert"]=  SweetAlert.Sweet_Alert("Error", "Usuario y/o Contraseña no coindicen", NotificationType.warning);
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (HttpAntiForgeryException ex )
            {

                Session.RemoveAll();
                Session.Clear();
                TempData["sweetalert"] = SweetAlert.Sweet_Alert("Error", $"Error: {ex.Message}", NotificationType.error);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            TempData["sweetalert"] = SweetAlert.Sweet_Alert("Hasta la vista beibi", "", NotificationType.info);
            return RedirectToAction("Index");
        }
    }
}