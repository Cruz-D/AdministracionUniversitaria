using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdministracionUniversitaria.Models
{
    public class Asignatura
    {
        [Key]
        public int IdAsignatura { get; set; }
        public string Asignatura_Nombre { get; set; }
        public int Asignatura_Creditos { get; set; }

        //FK hacia carrera
        public int IdCarrera { get; set; }
        public Carrera Carrera { get; set; }
    }
}