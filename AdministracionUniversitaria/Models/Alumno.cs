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
        public int Alumno_Edad { get; set; }
    }
}