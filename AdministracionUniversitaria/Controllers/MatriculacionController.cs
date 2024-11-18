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
    public class MatriculacionController : Controller
    {
        //declarar conexion a la base de datos
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matriculacion
        //metoido para mostrar la vista de matriculaciones
        [HttpGet]
        public ActionResult MatriculacionesPage()
        {
            // se crea una sentencia linq para seleccionar los alumnos
            var matriculas = db.Matricula_Set
                //seleccionar las matriculas y pintarlas llamando a la clase auxiliar
                //del viewmodel para mostrar los datos en la vista
                .Select(m => new MatriculaViewModel.MatriculaInfo
                {
                    IdMatricula = m.IdMatricula,
                    Alumno = m.Alumno.Alumno_Nombre,
                    Asignatura = m.Asignatura.Asignatura_Nombre,
                    FechaMatricula = m.Matricula_Fecha
                }).ToList();

            //se crea un objeto de la clase viewmodel
            var vm = new MatriculaViewModel
            {
                //se llenan las listas de los dropdownlist
                Alumnos = db.Alumnos_Set
                    //crear una nueva lista de SelectListItem
                    .Select(a => new SelectListItem
                    {
                        //seleccionar el id  en el value y el nombre del alumno en el text
                        Value = a.IdAlumno.ToString(),
                        Text = a.Alumno_Nombre
                        //devolverlo en lista
                    }).ToList(),

                //seleccionar las carreras
                Carreras = db.Carrera_Set
                .Select(c => new SelectListItem
                {
                    Value = c.IdCarrera.ToString(),
                    Text = c.Carrera_Nombre
                }).ToList(),

                //seleccionar las asignaturas
                Matriculas = matriculas
            };

            //devolver la vista con el objeto viewmodel
            return View(vm);
        }

        //Metodo para obtener las asignaturas pasandole el id de la carrera
        [HttpGet]
        public JsonResult GetAsignaturas(int idCarrera)
        {

            System.Diagnostics.Debug.WriteLine("ID Carrera: " + idCarrera);

            try
            {
                //seleccionar las asignaturas por carrera
                var asignaturas = db.Asignatura_Set
                    .Where(a => a.Carrera.IdCarrera == idCarrera)
                    .Select(a => new SelectListItem
                    {
                        Value = a.IdAsignatura.ToString(),
                        Text = a.Asignatura_Nombre
                    }).ToList();

                // Log para depuración
                System.Diagnostics.Debug.WriteLine("Asignaturas encontradas: " + asignaturas.Count);

                //devolver las asignaturas en formato json
                return Json(asignaturas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + e.Message);
                return Json(e.Message);
            }
        }

        //metoodo para acceder a una matrila por su id
        [HttpGet]
        public ActionResult MatriculaDetail(int idMatricula)
        {
            //seleccionar la matricula por su id
            var matricula = db.Matricula_Set.Find(idMatricula);

            //crear un objeto de la clase viewmodel
            var vm = new MatriculaViewModel
            {
                //llenar los datos de la matricula
                IdMatricula = matricula.IdMatricula,
                IdAlumno = matricula.IdAlumno,
                IdAsignaruta = matricula.IdAsignatura,
                IdCarrera = matricula.Asignatura.Carrera.IdCarrera,

                //llenar las listas de los dropdownlist

                Alumnos = db.Alumnos_Set
                    .Select(a => new SelectListItem
                    {
                        Value = a.IdAlumno.ToString(),
                        Text = a.Alumno_Nombre
                    }).ToList(),

                Carreras = db.Carrera_Set
                    .Select(c => new SelectListItem
                    {
                        Value = c.IdCarrera.ToString(),
                        Text = c.Carrera_Nombre
                    }).ToList(),

                Asignaturas = db.Asignatura_Set
                    .Where(a => a.Carrera.IdCarrera == matricula.Asignatura.Carrera.IdCarrera)
                    .Select(a => new SelectListItem
                    {
                        Value = a.IdAsignatura.ToString(),
                        Text = a.Asignatura_Nombre
                    }).ToList()
            };

            //devolver la vista con el objeto viewmodel
            return View(vm);
        }

        //Metodo para guardar la matricula
        [HttpPost]
        public ActionResult CreateMatricula(MatriculaViewModel vm)
        {
            //primero comprobar si el alumno esta matricualdo en la asignatura
            var matricula = db.Matricula_Set
                .Where(m => m.IdAlumno == vm.IdAlumno && m.IdAsignatura == vm.IdAsignaruta)
                .FirstOrDefault();

            // si la matricula es nula, se matricula al alumno
            if (matricula == null)
            {

                //crear un objeto de la clase matricula
                var matriculaNueva = new Matricula
                {
                    //llenar los datos de la matricula
                    IdAlumno = db.Alumnos_Set.Find(vm.IdAlumno.Value).IdAlumno, 
                    IdAsignatura = db.Asignatura_Set.Find(vm.IdAsignaruta.Value).IdAsignatura,
                    Matricula_Fecha = DateTime.Now,


                };

                //guardar la matricula en la base de datos
                db.Matricula_Set.Add(matriculaNueva);
                db.SaveChanges();

                //redirigir a la vista de matriculacion
                return Redirect("MatriculacionesPage");

            }
            else
            {
                //retornar mensaje de error
                ViewBag.Message = "El alumno ya esta matriculado en la asignatura";

                return View("YaMatriculado");
            }
        }

        //metodo para actualizar una matricula
        [HttpPost]
        public ActionResult UpdateMatricula(MatriculaViewModel vm)
        {
            //seleccionar la matricula por el id
            var matricula = db.Matricula_Set.Find(vm.IdMatricula);

            //llenar los datos de la matricula
            matricula.IdAlumno = vm.IdAlumno.Value;
            matricula.IdAsignatura = vm.IdAsignaruta.Value;

            //guardar los cambios en la base de datos
            db.SaveChanges();

            //redirigir a la vista de matriculacion
            return RedirectToAction("MatriculacionesPage");
        }

        //DELETE: Eliminar una matricula
        //metodo para eliminar una matricula
        [HttpPost]
        public ActionResult DeleteMatricula(int idMatricula)
        {
            //seleccionar la matricula por el id
            var matricula = db.Matricula_Set.Find(idMatricula);

            //eliminar la matricula de la base de datos
            db.Matricula_Set.Remove(matricula);

            db.SaveChanges();

            return RedirectToAction("MatriculacionesPage");
        }
    }
}