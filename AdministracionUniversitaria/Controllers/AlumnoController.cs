using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Models;
using AdministracionUniversitaria.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AdministracionUniversitaria.Controllers
{
    [Authorize]
    public class AlumnoController : Controller
    {
        //declarar la conexion con la bbdd
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alumno
        //metodo para mostrar la vista de alumnos y cargar los datos
        [HttpGet]
        public ActionResult AlumnosPage()
        {
            try
            {
                //seleccionar los alumnos de la base de datos
                var alumnos = db.Alumnos_Set
                    //seleccionar los datos de los alumnos y pintarlos en la vista
                    .Select(a => new AlumnoViewModel.AlumnoInfo
                    {
                        Id = a.IdAlumno,
                        Nombre = a.Alumno_Nombre,
                        Apellido = a.Alumno_Apellido,
                        Edad = a.Alumno_Edad,
                        FechaNacimiento = a.Alumno_FechaNacimiento,
                        Direccion = a.Alumno_Direccion,
                        Telefono = a.Alumno_Telefono,
                        Email = a.Alumno_Email,


                    }).ToList();

                //crear un objeto de la clase viewmodel
                var vm = new AlumnoViewModel();
                {
                    //llenar la lista de alumnos con los datos de la base de datos

                    vm.Alumnos = alumnos.Select(a => new AlumnoViewModel.AlumnoInfo
                    {
                        Id = a.Id,
                        Nombre = a.Nombre,
                        Apellido = a.Apellido,
                        Edad = a.Edad,
                        FechaNacimiento = a.FechaNacimiento,
                        Direccion = a.Direccion,
                        Telefono = a.Telefono,
                        Email = a.Email,

                    }).ToList();
                };

                return View(vm);
            }
            catch (Exception)
            {

                throw;
            }
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

            if (alumno != null)
            {
                try
                {
                    //crear un objeto de la clase viewmodel

                    var vm = new AlumnoViewModel
                    {
                        //llenar los datos del alumno
                        Alumno_Nombre = alumno.Alumno_Nombre,
                        Alumno_Apellido = alumno.Alumno_Apellido,
                        Alumno_Edad = alumno.Alumno_Edad,
                        Alumno_FechaNacimiento = alumno.Alumno_FechaNacimiento,
                        Alumno_Direccion = alumno.Alumno_Direccion,
                        Alumno_Telefono = alumno.Alumno_Telefono,
                        Alumno_Email = alumno.Alumno_Email,
                        Alumno_Foto = alumno.Alumno_Foto
                    };

                    return View(vm);
                }
                catch (Exception)
                {
                    throw;

                }
            }
            else
            {
                return RedirectToAction("AlumnosPage");
            }
        }

        //POST: Crear un alumno en el sistema
        //metodo para crear un alumno en el sistema
        [HttpPost]
        public ActionResult CreateAlumno(AlumnoViewModel model)
        {
            try
            {
                //crear un objeto de la clase alumno
                var alumno = new Alumno
                {
                    //llenar los datos del alumno
                    Alumno_Nombre = model.Alumno_Nombre,
                    Alumno_Edad = model.Alumno_Edad,
                    Alumno_Apellido = model.Alumno_Apellido,
                    Alumno_FechaNacimiento = model.Alumno_FechaNacimiento,
                    Alumno_Direccion = model.Alumno_Direccion,
                    Alumno_Telefono = model.Alumno_Telefono,
                    Alumno_Email = model.Alumno_Email,
                    Alumno_Foto = model.Alumno_Foto
                };

                //agregar el alumno a la base de datos
                db.Alumnos_Set.Add(alumno);
                db.SaveChanges();

                return RedirectToAction("AlumnosPage");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //PUT: Actualizar un alumno en el sistema
        //metodo para actualizar un alumno en el sistema
        [HttpPost]
        public ActionResult UpdateAlumno(AlumnoViewModel model, int IdAlumno)
        {
            System.Diagnostics.Debug.WriteLine("Id del alumno ------------------> " + IdAlumno);
            //seleccionar el alumno por su id
            var alumno = db.Alumnos_Set.Find(IdAlumno);

            if (alumno != null)
            {
                try
                {
                    //actualizar los datos del alumno
                    alumno.Alumno_Nombre = model.Alumno_Nombre;
                    alumno.Alumno_Apellido = model.Alumno_Apellido;
                    alumno.Alumno_Edad = model.Alumno_Edad;
                    //alumno.Alumno_FechaNacimiento = model.Alumno_FechaNacimiento; //todo: verificar fecha nacimiento da eror al actualizar
                    alumno.Alumno_Direccion = model.Alumno_Direccion;
                    alumno.Alumno_Telefono = model.Alumno_Telefono;
                    alumno.Alumno_Email = model.Alumno_Email;
                    //alumno.Alumno_Foto = model.Alumno_Foto;

                    //guardar los cambios en la base de datos
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

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