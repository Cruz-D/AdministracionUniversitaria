using AdministracionUniversitaria.Context;
using AdministracionUniversitaria.Enums.Alumno;
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
                    //seleccionar los datos de los alumnos y pintarlos
                    //en un viewmodel
                    .Select(a => new AlumnoViewModel.AlumnoInfo
                    {
                        Id = a.IdAlumno,
                        Nombre = a.Alumno_Nombre,
                        Apellido_1 = a.Alumno_Apellido_1,
                        Apellido_2 = a.Alumno_Apellido_2,
                        NombreCompleto = a.Alumno_Nombre + " " + a.Alumno_Apellido_1 + " " + a.Alumno_Apellido_2,
                        Sexo = a.Alumno_Sexo,
                        Edad = DateTime.Now.Year - a.Alumno_FechaNacimiento.Year,
                        FechaRegistro = a.Alumno_FechaRegistro,
                        FechaNacimiento = a.Alumno_FechaNacimiento,
                        Telefono_1 = a.Alumno_Telefono_1,
                        Telefono_2 = a.Alumno_Telefono_2,
                        Email = a.Alumno_Email,
                        Foto = a.Alumno_Foto,
                        Via = a.Alumno_Via,
                        Calle = a.Alumno_Calle,
                        Calle_2 = a.Alumno_Calle_2,
                        Numero = a.Alumno_Numero,
                        Escalera = a.Alumno_Escalera,
                        Piso = a.Alumno_Piso,
                        Puerta = a.Alumno_Puerta,
                        ComunidadAutonoma = a.Alumno_ComunidadAutonoma,
                        CodigoPostal = a.Alumno_CodigoPostal,
                        DireccionCompleta = a.Alumno_Via + " " + a.Alumno_Calle + " " + a.Alumno_Calle_2 + " "+ " " + a.Alumno_Numero + " " + a.Alumno_CodigoPostal + " " + a.Alumno_ComunidadAutonoma

                    }).ToList();

                var vm = new AlumnoViewModel
                {
                    Alumnos = alumnos
                };



                return View(vm);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}