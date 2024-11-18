using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Models;
using AdministracionUniversitaria.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AdministracionUniversitaria.Controllers
{
    public class AdministracionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Para evitar ataques CSRF
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // Valida que los datos ingresados sean correctos
            {
                // Busca un administrador con el correo y contraseña ingresados
                var admin = db.Administracion_Set
                    .FirstOrDefault(a => a.Administracion_Email == model.Email && a.Administracion_Password == model.Password);

                if (admin != null)
                {
                    try
                    {
                        if (admin.Administracion_Tipo == "superAdmin")
                        {
                            //Con forms authentication se crea una cookie de autenticación
                            //que se almacena en el navegador del usuario
                            FormsAuthentication.SetAuthCookie(admin.Administracion_Email, false);

                            //guardar el tipo de usuario en un session
                            Session["TipoUsuario"] = admin.Administracion_Tipo;

                            // Si el administrador es de tipo "admin", se redirige a la página de administrador
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(admin.Administracion_Email, false);
                            // Si el administrador es de tipo "user", se redirige a la página de usuario

                            //guardar el tipo de usuario en un session
                            Session["TipoUsuario"] = admin.Administracion_Tipo;

                            return RedirectToAction("Index", "Home");
                        }
                    }
                    catch (Exception)
                    {
                        // Manejo de la excepción
                        ModelState.AddModelError("", "Ocurrió un error al iniciar sesión. Por favor, inténtelo de nuevo.");
                        // Opcional: registrar el error
                        // Logger.Error(ex);
                    }
                }
            }

            return View(model);
        }
        //post para cerrar la sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // Se cierra la sesión del usuario usando FormsAuthentication
            FormsAuthentication.SignOut();
            // Se cierra la sesión del usuario
            Session.Abandon();

            return RedirectToAction("Login", "Account");
        }

    }
}
