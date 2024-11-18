using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Models;
using AdministracionUniversitaria.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace AdministracionUniversitaria.Controllers
{
    [Authorize]
    public class AsignaturaController : Controller
    {
        // Instanciar la base de datos
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asignatura
        // Método para mostrar la vista de asignaturas
        [HttpGet]
        public ActionResult AsignaturasPage()
        {
            var asignaturas = db.Asignatura_Set
                .Select(a => new AsignaturaViewModel
                {
                    Asignatura_IdAsignatura = a.IdAsignatura,
                    Asignatura_Nombre = a.Asignatura_Nombre,
                    Asignatura_Creditos = a.Asignatura_Creditos,
                    Asignatura_Codigo = a.Asignatura_Codigo,
                    Asignatura_Tipo = a.Asignatura_Tipo,
                    Asignatura_Curso = a.Asignatura_Curso,
                    Asignatura_Horario = a.Asignatura_Horario,
                    IdCarrera = a.IdCarrera,
                    Asignatura_Carrera_Nombre = a.Carrera.Carrera_Nombre
                    
                }).ToList();

            var vm = new AsignaturaViewModel
            {
                Asignaturas = asignaturas,
                Carreras = db.Carrera_Set.Select(c => new SelectListItem { Value = c.IdCarrera.ToString(), Text = c.Carrera_Nombre }).ToList()
            };

            return View(vm);
        }

        // GET: Asignatura/Create
        [HttpGet]
        public ActionResult CreateAsignatura()
        {
            var vm = new AsignaturaViewModel
            {
                Carreras = db.Carrera_Set.Select(c => new SelectListItem
                {
                    Value = c.IdCarrera.ToString(),
                    Text = c.Carrera_Nombre
                }).ToList()
            };

            return View(vm);
        }

        // POST: Asignatura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAsignatura(AsignaturaViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var asignatura = new Asignatura
                {
                    Asignatura_Nombre = vm.Asignatura_Nombre,
                    Asignatura_Creditos = vm.Asignatura_Creditos,
                    Asignatura_Codigo = vm.Asignatura_Codigo,
                    Asignatura_Tipo = vm.Asignatura_Tipo,
                    Asignatura_Curso = vm.Asignatura_Curso,
                    Asignatura_Horario = vm.Asignatura_Horario,
                    IdCarrera = vm.IdCarrera,
                    Carrera = db.Carrera_Set.Find(vm.IdCarrera)

                };

                db.Asignatura_Set.Add(asignatura);
                db.SaveChanges();

                return RedirectToAction("AsignaturasPage");
            }

            vm.Carreras = db.Carrera_Set.Select(c => new SelectListItem
            {
                Value = c.IdCarrera.ToString(),
                Text = c.Carrera_Nombre
            }).ToList();

            return View(vm);
        }

        // GET: Asignatura/Detail/5
        [HttpGet]
        public ActionResult AsignaturaDetail(int idAsignatura)
        {
            var asignatura = db.Asignatura_Set
                .Where(a => a.IdAsignatura == idAsignatura)
                .Select(a => new AsignaturaViewModel
                {
                    Asignatura_IdAsignatura = a.IdAsignatura,
                    Asignatura_Nombre = a.Asignatura_Nombre,
                    Asignatura_Creditos = a.Asignatura_Creditos,
                    Asignatura_Codigo = a.Asignatura_Codigo,
                    Asignatura_Tipo = a.Asignatura_Tipo,
                    Asignatura_Curso = a.Asignatura_Curso,
                    Asignatura_Horario = a.Asignatura_Horario,
                    Asignatura_Carrera_Nombre = a.Carrera.Carrera_Nombre,
                    //IdCarrera = a.IdCarrera
                }).FirstOrDefault();

            if (asignatura == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("AsignaturasPage");
        }

        // POST: Asignatura/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAsignatura(AsignaturaViewModel vm, int idAsignatura)
        {
            var asignatura = db.Asignatura_Set.Find(idAsignatura);

            if (asignatura == null)
            {
                return HttpNotFound();
            }

            asignatura.Asignatura_Nombre = vm.Asignatura_Nombre;
            asignatura.Asignatura_Creditos = vm.Asignatura_Creditos;
            asignatura.Asignatura_Codigo = vm.Asignatura_Codigo;
            asignatura.Asignatura_Tipo = vm.Asignatura_Tipo;
            asignatura.Asignatura_Curso = vm.Asignatura_Curso;
            asignatura.Asignatura_Horario = vm.Asignatura_Horario;
            //asignatura.IdCarrera = vm.IdCarrera; // Esta línea estaba comentada

            db.SaveChanges();

            vm.Carreras = db.Carrera_Set.Select(c => new SelectListItem
            {
                Value = c.IdCarrera.ToString(),
                Text = c.Carrera_Nombre
            }).ToList();
            
            return RedirectToAction("AsignaturasPage");
        }

        // POST: Asignatura/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAsignatura(int idAsignatura)
        {
            var asignatura = db.Asignatura_Set.Find(idAsignatura);
            if (asignatura == null)
            {
                return HttpNotFound();
            }

            db.Asignatura_Set.Remove(asignatura);
            db.SaveChanges();

            return RedirectToAction("AsignaturasPage");
        }
    }
}
