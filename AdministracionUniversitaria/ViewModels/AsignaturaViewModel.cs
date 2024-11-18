using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministracionUniversitaria.ViewModels
{
    public class AsignaturaViewModel
    {
        // 1º se deja nulo por si no se selecciona ninguna asignatura
        public int? Asignatura_IdAsignatura { get; set; }
        //mostrar el nombre de la asignatura
        public string Asignatura_Nombre { get; set; }
        //mostrar los creditos de la asignatura
        public int Asignatura_Creditos { get; set; }
        //mostrar el código de la asignatura
        public string Asignatura_Codigo { get; set; }
        //mostrar el tipo de la asignatura
        public string Asignatura_Tipo { get; set; }
        //mostrar el curso de la asignatura
        public string Asignatura_Curso { get; set; }
        //mostrar el horario de la asignatura
        public string Asignatura_Horario { get; set; }
        //mostrar el nombre de la carrera a la que pertenece la asignatura
        public string Asignatura_Carrera_Nombre { get; set; }
        //FK hacia carrera
        public int IdCarrera { get; set; }

        public int Carrera_IdCarrera { get; set; }

        // 2º Lista de asignaturas para mostrar en la vista
        public List<AsignaturaViewModel> Asignaturas { get; set; }
        //Lista de carreras para mostrar en el ddl la vista
        public List<SelectListItem> Carreras { get; internal set; }

        // 3º Constructor que sirve para inicializar las listas
        public AsignaturaViewModel()
        {
            Asignaturas = new List<AsignaturaViewModel>();

            Carreras = new List<SelectListItem>();
        }

        // 4º estructura para mostrar los datos en la vista con una clase auxiliar
        public class AsignaturaInfo
        {
            public int id { get; set; }
            //mostrar el nombre de la asignatura
            public string Asignatura { get; set; }
            //mostrar los creditos de la asignatura
            public int Creditos { get; set; }
            //mostrar la carrera a la que pertenece la asignatura
            public string Carrera { get; set; }
            //mostrar el código de la asignatura
            public string Codigo { get; set; }
            //mostrar el tipo de la asignatura
            public string Tipo { get; set; }
            //mostrar el curso de la asignatura
            public string Curso { get; set; }
            //mostrar el horario de la asignatura
            public string Horario { get; set; }
        }
    }
}