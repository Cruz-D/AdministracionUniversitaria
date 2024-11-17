using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AdministracionUniversitaria.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }
        public string Carrera_Nombre { get; set; }
    }
}