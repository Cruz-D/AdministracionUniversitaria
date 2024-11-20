using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AdministracionUniversitaria.Enums.Alumno;

namespace AdministracionUniversitaria.Models
{
    public class Alumno
    {
        // ID DEL ALUMNO
        //______________________________________________________________________________________________

        [Key]
        public int IdAlumno { get; set; }


        // DATOS PERSONALES DEL ALUMNO
        //______________________________________________________________________________________________

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Alumno_Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Primer apellido")]
        public string Alumno_Apellido_1 { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [Display(Name = "Segundo apellido")]
        public string Alumno_Apellido_2 { get; set; }

        [Required(ErrorMessage = "El Sexo es obligatorio")]
        [Display(Name = "Sexo")]
        public string Alumno_Sexo { get; set; }

        [Display(Name = "Nombre completo")]
        public string Alumno_NombreCompleto
        {
            get { return Alumno_Nombre + " " + Alumno_Apellido_1 + " " + Alumno_Apellido_2; }
        }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Alumno_FechaNacimiento { get; set; }

        // Mostrar que en vez poner Alumno_Edad ponga edad de alumno
        [Display(Name = "Edad")]
        public int Alumno_Edad
        {
            get { return DateTime.Now.Year - Alumno_FechaNacimiento.Year; }
        }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime Alumno_FechaRegistro { get; set; }

        [Display(Name = "Foto")]
        public string Alumno_Foto { get; set; }


        // DATOS DE COMUNICACION DEL ALUMNO
        //______________________________________________________________________________________________

        [Phone(ErrorMessage = "El teléfono no es válido")]
        [Display(Name = "Teléfono")]
        public string Alumno_Telefono_1 { get; set; }

        [Phone(ErrorMessage = "El teléfono no es válido")]
        [Display(Name = "Teléfono")]
        public string Alumno_Telefono_2 { get; set; }

        [EmailAddress(ErrorMessage = "El correo no es válido")]
        [Display(Name = "Correo electrónico")]
        public string Alumno_Email { get; set; }


        // DATOS DE LA DIRECCION DEL ALUMNO
        //______________________________________________________________________________________________

        [Required(ErrorMessage = "La vía es obligatoria")]
        [Display(Name = "Vía")]
        public string Alumno_Via { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria")]
        [Display(Name = "Nombre de la calle")]
        public string Alumno_Calle { get; set; }

        [Display(Name = "Informacion de la calle")]
        public string Alumno_Calle_2 { get; set; }

        [Display(Name = "Número")]
        public string Alumno_Numero { get; set; }

        [Display(Name = "Escalera")]
        public string Alumno_Escalera { get; set; }

        [Display(Name = "Piso")]
        public string Alumno_Piso { get; set; }

        [Display(Name = "Puerta")]
        public string Alumno_Puerta { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria")]
        [Display(Name = "Comunidad Autonoma")]
        public string Alumno_ComunidadAutonoma { get; set; }

        [Required(ErrorMessage = "La localidad es obligatoria")]
        [Display(Name = "Codigo Postal")]
        //que unicamente contega 5 numeros como minimo y maximo
        [StringLength(5, MinimumLength = 5, ErrorMessage = "El código postal debe tener 5 dígitos")]
        public string Alumno_CodigoPostal { get; set; }

        [Display(Name = "Direccion Completa")]
        public string Alumno_DireccionCompleta
        {
            get
            {
                return Alumno_Via + " " + Alumno_Calle + " " + Alumno_Numero + " " + Alumno_CodigoPostal + " " + Alumno_ComunidadAutonoma;
            }
        }

    }

}