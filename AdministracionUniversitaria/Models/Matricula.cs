using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdministracionUniversitaria.Models
{
    public class Matricula
    {
        [Key]
        public int IdMatricula { get; set; }
        public DateTime Matricula_Fecha { get; set; }

        //FK hacia Alumno
        public int IdAlumno { get; set; }
        public Alumno Alumno { get; set; }

        //FK hacia Asignatura
        public int IdAsignatura { get; set; }
        public Asignatura Asignatura { get; set; }
    }
}