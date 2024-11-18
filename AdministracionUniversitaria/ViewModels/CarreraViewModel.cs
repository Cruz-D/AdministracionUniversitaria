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
        public string Carrera_Duracion { get; set; }
        public string Carrera_Titulo { get; set; }
        public string Carrera_Codigo { get; set; }
        public string Carrera_Tipo { get; set; }
        public string Carrera_Modalidad { get; set; }
        public double Carrera_Coste { get; set; }
        public int Carrera_NumeroAsignaturas { get; set; }

        // 2º Lista de carreras para mostrar en la vista
        public List<CarreraViewModel> Carreras { get; set; }
        public List<CarreraViewModel> Asignatura { get; set; }

        // 3º Constructor que sirve para inicializar las listas
        public CarreraViewModel()
        {
            Carreras = new List<CarreraViewModel>();
        }

        // 4º estructura para mostrar los datos en la vista con una clase auxiliar
        public class CarreraInfo
        {
            public int id { get; set; }
            public string Carrera { get; set; }
            public string Nombre { get; set; }
            public string Duracion { get; set; }
            public string Titulo { get; set; }
            public string Codigo { get; set; }
            public string Tipo { get; set; }
            public string Modalidad { get; set; }
            public double Coste { get; set; }
            public int NumeroAsignaturas { get; set; }
        }
    }
}