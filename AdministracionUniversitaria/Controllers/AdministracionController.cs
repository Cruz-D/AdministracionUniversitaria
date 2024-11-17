using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Models;
using AdministracionUniversitaria.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AdministracionUniversitaria.Controllers
{
    public class AccountController : Controller
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
                    //Con forms authentication se crea una cookie de autenticación
                    //que se almacena en el navegador del usuario
                    FormsAuthentication.SetAuthCookie(admin.Administracion_Email, false);

                    // Redirige al usuario a la página de inicio
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Si no se encuentra un administrador con esos datos, se muestra un mensaje de error
                    ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            // Se cierra la sesión del usuario usando FormsAuthentication
            // y se redirige a la página de inicio de sesión
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
