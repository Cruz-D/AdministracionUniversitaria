using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Models;
using AdministracionUniversitaria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministracionUniversitaria.Controllers
{
    public class AlumnoController : Controller
    {
        //declarar la conexion con la bbdd
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alumno
        //metodo para mostrar la vista de alumnos y cargar los datos
        [HttpGet]
        public ActionResult AlumnosPage()
        {
            //seleccionar los alumnos de la base de datos
            var alumnos = db.Alumnos_Set
                //seleccionar los datos de los alumnos y pintarlos en la vista
                .Select(a => new AlumnoViewModel.AlumnoInfo
                {
                    Id = a.IdAlumno,
                    Nombre = a.Alumno_Nombre,
                    Edad = a.Alumno_Edad

                }).ToList();

            //crear un objeto de la clase viewmodel
            var vm = new AlumnoViewModel();
            {
                //llenar la lista de alumnos con los datos de la base de datos

                vm.Alumnos = alumnos.Select(a => new AlumnoViewModel.AlumnoInfo
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Edad = a.Edad

                }).ToList();
            };

            return View(vm);
        }

        // GET: Alumno/CreateAlumno
        //metodo para mostrar la vista de crear alumnos
        [HttpGet]
        public ActionResult CreateAlumno()
        {
      

            return View();
        }

        //GET: Obtener un alumno por su id y mostrar datos
        //metodo para obtener un alumno por su id
        [HttpGet]
        public ActionResult AlumnoDetail(int IdAlumno) {

            System.Diagnostics.Debug.WriteLine("Id del alumno ------------------> " + IdAlumno);
            //seleccionar el alumno por su id
            var alumno = db.Alumnos_Set.Find(IdAlumno);

            return View(alumno);
        }

        //POST: Crear un alumno en el sistema
        //metodo para crear un alumno en el sistema
        [HttpPost]
        public ActionResult CreateAlumno(AlumnoViewModel model)
        {
            //crear un objeto de la clase alumno
            var alumno = new Alumno
            {
                //llenar los datos del alumno
                Alumno_Nombre = model.Alumno_Nombre,
                Alumno_Edad = model.Alumno_Edad
            };

            //agregar el alumno a la base de datos
            db.Alumnos_Set.Add(alumno);
            db.SaveChanges();

            return RedirectToAction("AlumnosPage");
        }

        //PUT: Actualizar un alumno en el sistema
        //metodo para actualizar un alumno en el sistema
        [HttpPost]
        public ActionResult UpdateAlumno(AlumnoViewModel model, int IdAlumno)
        {
            System.Diagnostics.Debug.WriteLine("Id del alumno ------------------> " + IdAlumno);
            //seleccionar el alumno por su id
            var alumno = db.Alumnos_Set.Find(IdAlumno);

            //actualizar los datos del alumno
            alumno.Alumno_Nombre = model.Alumno_Nombre;
            alumno.Alumno_Edad = model.Alumno_Edad;

            //guardar los cambios en la base de datos
            db.SaveChanges();

            return RedirectToAction("AlumnosPage");
        }

        //DELETE: Eliminar un alumno del sistema
        //metodo para eliminar un alumno del sistema
        [HttpPost]
        public ActionResult DeleteAlumno(int IdAlumno)
        {
            System.Diagnostics.Debug.WriteLine("Id del alumno ------------------> " + IdAlumno);
            try
            {
                //seleccionar el alumno por su id
                var alumno = db.Alumnos_Set.Find(IdAlumno);

                //eliminar el alumno de la base de datos
                db.Alumnos_Set.Remove(alumno);
                db.SaveChanges();

                return RedirectToAction("AlumnosPage");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}