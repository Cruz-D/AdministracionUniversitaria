using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministracionUniversitaria.ViewModels
{
    public class AsignaturaViewModel
    {

        // 1º se deja nulo por si no se selecciona ninguna asignatura
        public int? Asignatura_IdAsignatura { get; set; }
        //mostrar el nombre de la asignatura
        public string Asignatura_Nombre { get; set; }
        //
        public string Asignatura_Carrera_Nombre { get; set; }
        //mostrar los creditos de la asignatura
        public int Asignatura_Creditos { get; set; }
        //FK hacia carrera
        public int IdCarrera { get; set; }

        // 2º Lista de asignaturas para mostrar en la vista
        public List<AsignaturaViewModel> Asignaturas { get; set; }

        // 3º Constructor que sirve para inicializar las listas
        public AsignaturaViewModel()
        {
            Asignaturas = new List<AsignaturaViewModel>();
        }

        // 4º estructura para mostrar los datos en la vista con una clase auxiliar
        public class AsignaturaInfo
        {

            //mostrar el nombre de la asignatura
            public string Asignatura { get; set; }

            //mostrar los creditos de la asignatura
            public int Creditos { get; set; }

            //mostrar la carrera a la que pertenece la asignatura
            public string Carrera { get; set; }

        }
    }
}