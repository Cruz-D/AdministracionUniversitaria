using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministracionUniversitaria.Models
{
    // modelo de la clase administracion que se encarga
    // de los usuarios que majena la aplicacion
    public class Administracion
    {
        //atributos de la clase administracion
        [Key]
        public int AdministracionId { get; set; }
        public string Administracion_Nombre { get; set; }
        public string Administracion_Apellido { get; set; }
        [EmailAddress]
        public string Administracion_Email { get; set; }

        public string Administracion_Password { get; set; }
        public string Administracion_Tipo { get; set; }

        public DateTime Administracion_FechaCreacion { get; set; }

    }
}