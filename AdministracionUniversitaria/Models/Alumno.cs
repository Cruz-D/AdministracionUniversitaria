using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdministracionUniversitaria.Models
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }
        public string Alumno_Nombre { get; set; }
        public string Alumno_Apellido { get; set; }
        public string NombreCompleto { get { return Alumno_Nombre + " " + Alumno_Apellido; } }
        public int Alumno_Edad { get; set; }
        public DateTime Alumno_FechaNacimiento { get; set; }
        public string Alumno_Direccion { get; set; }
        public string Alumno_Telefono { get; set; }
        [EmailAddress]
        public string Alumno_Email { get; set; }

        //propiedad para una foto
        public string Alumno_Foto { get; set; }


    }
}