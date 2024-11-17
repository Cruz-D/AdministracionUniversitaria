using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministracionUniversitaria.ViewModels
{
    public class LoginViewModel
    {
        //1. Crear un ViewModel para el login
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}