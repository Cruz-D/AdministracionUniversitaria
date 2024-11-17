using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Models;
using AdministracionUniversitaria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AdministracionUniversitaria.Controllers
{
    public class CarreraController : Controller
    {
        //contexto de la base de datos
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carrera
        //metodo para mostrar la vista de carreras y cargar los datos
        [HttpGet]
        public ActionResult CarrerasPage()
        {

            //seleccionar las carreras de la base de datos
            var carreras = db.Carrera_Set
                //seleccionar los datos de las carreras y pintarlos en la vista
                .Select(c => new
                {
                    id_carrera = c.IdCarrera,
                    Nombre = c.Carrera_Nombre
                }).ToList();

            //crear un objeto de la clase viewmodel
            var vm = new CarreraViewModel();
            {
                //llenar la lista de carreras con los datos de la base de datos

                vm.Carreras = carreras.Select(c => new CarreraViewModel
                {
                    Carrera_IdCarrera = c.id_carrera,
                    Carrera_Nombre = c.Nombre
                }).ToList();
            };

            return View(vm);
        }

        //GET: Obtener una carrera por su id y mostrar datos
        //metodo para obtener una carrera por su id
        [HttpGet]
        public JsonResult GetCarrera(int idCarrera)
        {
            //seleccionar la carrera por su id
            var carrera = db.Carrera_Set.Find(idCarrera);

            //crear un objeto de la clase viewmodel
            var vm = new CarreraViewModel
            {
                //llenar los datos de la carrera
                Carrera_IdCarrera = carrera.IdCarrera,
                Carrera_Nombre = carrera.Carrera_Nombre
            };

            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        // GET: Mostrar asignaturas de una carrera
        //metodo para mostrar las asignaturas de una carrera
        //[HttpGet]
        //public JsonResult GetAsignaturasCarrera(int idCarrera)
        //{
        //    //obtener las asignaturas de una carrera
        //    var asignaturas = db.Asignatura_Set
        //        .Where(a => a.IdCarrera == idCarrera)
        //        .Select(a => new
        //        {
        //            id_asignatura = a.Asignatura_IdAsignatura,
        //            Nombre = a.Asignatura_Nombre
        //        }).ToList();

        //    return Json(asignaturas, JsonRequestBehavior.AllowGet);
        //}

        //POST: Crear una nueva carrera
        //metodo para crear una nueva carrera
        [HttpPost]
        public ActionResult CrearCarrera(CarreraViewModel vm)
        {
            //crear un objeto de la clase carrera
            var carrera = new Carrera
            {
                Carrera_Nombre = vm.Carrera_Nombre
            };

            //agregar la carrera a la base de datos
            db.Carrera_Set.Add(carrera);

            db.SaveChanges();

            return RedirectToAction("CarrerasPage");
        }

        //DELETE: Eliminar una carrera
        //metodo para eliminar una carrera
        [HttpDelete]
        public ActionResult EliminarCarrera(int idCarrera)
        {
            //seleccionar la carrera por el id
            var carrera = db.Carrera_Set.Find(idCarrera);

            //eliminar la carrera de la base de datos
            db.Carrera_Set.Remove(carrera);

            db.SaveChanges();

            return RedirectToAction("CarrerasPage");
        }
    }
}