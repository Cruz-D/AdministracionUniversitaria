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
    [Authorize]
    public class CarreraController : Controller
    {
        //contexto de la base de datos
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carrera
        //metodo para mostrar la vista de carreras y cargar los datos
        [HttpGet]
        public ActionResult CarrerasPage()
        {

            try
            {
                //seleccionar las carreras de la base de datos
                var carreras = db.Carrera_Set
                    //seleccionar los datos de las carreras y pintarlos en la vista
                    .Select(c => new
                    {
                        id_carrera = c.IdCarrera,
                        Nombre = c.Carrera_Nombre,
                        Duracion = c.Carrera_Duracion,
                        Titulo = c.Carrera_Titulo,
                        Codigo = c.Carrera_Codigo,
                        Tipo = c.Carrera_Tipo,
                        Modalidad = c.Carrera_Modalidad,
                        Coste = c.Carrera_Coste,
                        NumeroAsignaturas = c.Asignaturas.Count
                    }).ToList();

                //crear un objeto de la clase viewmodel
                var vm = new CarreraViewModel();
                {
                    //llenar la lista de carreras con los datos de la base de datos

                    vm.Carreras = carreras.Select(c => new CarreraViewModel
                    {
                        Carrera_IdCarrera = c.id_carrera,
                        Carrera_Nombre = c.Nombre,
                        Carrera_Duracion = c.Duracion,
                        Carrera_Titulo = c.Titulo,
                        Carrera_Codigo = c.Codigo,
                        Carrera_Tipo = c.Tipo,
                        Carrera_Modalidad = c.Modalidad,
                        Carrera_Coste = c.Coste,
                        Carrera_NumeroAsignaturas = c.NumeroAsignaturas
                    }).ToList();
                };

                return View(vm);
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        
        [HttpGet]
        public ActionResult CreateCarrera()
        {
            return View();
        }

        //POST: Crear una nueva carrera
        //metodo para crear una nueva carrera
        [HttpPost]
        public ActionResult CreateCarrera(CarreraViewModel vm)
        {
            if (vm != null)
            {
                try
                {
                    //crear un objeto de la clase carrera
                    var carrera = new Carrera
                    {
                        Carrera_Nombre = vm.Carrera_Nombre,
                        Carrera_Duracion = vm.Carrera_Duracion,
                        Carrera_Titulo = vm.Carrera_Titulo,
                        Carrera_Codigo = vm.Carrera_Codigo,
                        Carrera_Tipo = vm.Carrera_Tipo,
                        Carrera_Modalidad = vm.Carrera_Modalidad,
                        Carrera_Coste = vm.Carrera_Coste,
                        Carrera_NumeroAsignaturas = vm.Carrera_NumeroAsignaturas

                    };

                    //agregar la carrera a la base de datos
                    db.Carrera_Set.Add(carrera);

                    db.SaveChanges();

                   
                }
                catch (Exception)
                {

                    throw;
                }

                
            }

            return RedirectToAction("CarrerasPage");

        }

        //GET: Obtener una carrera por su id y mostrar datos
        //metodo para obtener una carrera por su id
        [HttpGet]
        public ActionResult CarreraDetail(int IdCarrera)
        {
            //seleccionar la carrera por su id
            var carrera = db.Carrera_Set.Find(IdCarrera);

            //crear un objeto de la clase viewmodel
            var model = new CarreraViewModel
            {
                Carrera_IdCarrera = carrera.IdCarrera,
                Carrera_Nombre = carrera.Carrera_Nombre,
                Carrera_Duracion = carrera.Carrera_Duracion,
                Carrera_Titulo = carrera.Carrera_Titulo,
                Carrera_Codigo = carrera.Carrera_Codigo,
                Carrera_Tipo = carrera.Carrera_Tipo,
                Carrera_Modalidad = carrera.Carrera_Modalidad,
                Carrera_Coste = carrera.Carrera_Coste,
                Carrera_NumeroAsignaturas = carrera.Carrera_NumeroAsignaturas
            };

            //retornar la vista con los datos de la carrera
            return View(model);
       
        }

        //PUT: Actualizar una carrera
        //metodo para actualizar una carrera
        [HttpPost]
        public ActionResult UpdateCarrera(CarreraViewModel vm, int IdCarrera)
        {
            
            // Obtener la carrera por su id
            var carrera = db.Carrera_Set.Find(IdCarrera);

            // si carrera no es nula, actualizar los datos
            if (carrera != null)
            {
                // Actualizar los datos de la carrera
                carrera.Carrera_Nombre = vm.Carrera_Nombre;
                carrera.Carrera_Duracion = vm.Carrera_Duracion;
                carrera.Carrera_Titulo = vm.Carrera_Titulo;
                carrera.Carrera_Codigo = vm.Carrera_Codigo;
                carrera.Carrera_Tipo = vm.Carrera_Tipo;
                carrera.Carrera_Modalidad = vm.Carrera_Modalidad;
                carrera.Carrera_Coste = vm.Carrera_Coste;
                carrera.Carrera_NumeroAsignaturas = vm.Carrera_NumeroAsignaturas;

                // Guardar los cambios en la base de datos
                db.SaveChanges();

            }

            return RedirectToAction("CarrerasPage"); 

        }

        //DELETE: Eliminar una carrera
        //metodo para eliminar una carrera
        [HttpPost]
        public ActionResult DeleteCarrera(int idCarrera)
        {
            //seleccionar la carrera por el id
            var carrera = db.Carrera_Set.Find(idCarrera);

            if (carrera != null)
            {
                //eliminar la carrera de la base de datos
                db.Carrera_Set.Remove(carrera);

                db.SaveChanges();


            }
            return RedirectToAction("CarrerasPage");

        }
    }
}