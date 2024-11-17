using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministracionUniversitaria.Controllers
{
    public class AsignaturaController : Controller
    {
        //instanciar la base de datos
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Asignatura
        //metodo para mostrar la vista de asignaturas

        public ActionResult AsignaturasPage()
        {
  
            var asignaturas = db.Asignatura_Set
            
                .Select(a => new AsignaturaViewModel.AsignaturaInfo
                {
                    Asignatura = a.Asignatura_Nombre,
                    Creditos = a.Asignatura_Creditos,
                    Carrera = a.Carrera.Carrera_Nombre
                }).ToList();

            var vm = new AsignaturaViewModel
            {
                Asignaturas = asignaturas.Select(a => new AsignaturaViewModel
                {
                    Asignatura_Nombre = a.Asignatura,
                    Asignatura_Creditos = a.Creditos,
                    Asignatura_Carrera_Nombre = a.Carrera
                }).ToList()
            };

            return View(vm);
        }
    }
}