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
                    IdCarrera = a.IdCarrera
                }).ToList();

            var vm = new AsignaturaViewModel
            {
                Asignaturas = asignaturas
            };

            return View(vm);
        }
    }
}