using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministracionUniversitaria.ViewModels
{
    public class CarreraViewModel
    {
        // 1º se deja nulo por si no se selecciona ninguna carrera
        public int? Carrera_IdCarrera { get; set; }
        public string Carrera_Nombre { get; set; }

        // 2º Lista de carreras para mostrar en la vista
        public List<CarreraViewModel> Carreras { get; set; }

        // 3º Constructor que sirve para inicializar las listas
        
        public CarreraViewModel()
        {
            Carreras = new List<CarreraViewModel>();
        }

        // 4º estructura para mostrar los datos en la vista con una clase auxiliar
        public class CarreraInfo
        {
            public string Carrera { get; set; }

            public string Nombre { get; set; }


        }
    }
}