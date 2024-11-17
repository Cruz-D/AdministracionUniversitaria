using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace AdministracionUniversitaria.ViewModels
{
    public class MatriculaViewModel
    {

        // 1º se deja nulo por si no se selecciona ninguna carrera
        public int IdMatricula { get; set; }

        public int? IdAlumno { get; set; }

        public int? IdCarrera { get; set; }

        public int? IdAsignaruta { get; set; }

        // 2º Listas para llenar los dropdownlist en la vista
        public List<SelectListItem> Alumnos { get; set; }

        public List<SelectListItem> Carreras { get; set; }

        public List<SelectListItem> Asignaturas { get; set; }

        // 3º crear un estructura para mostrar los datos en la vista con una clase auxiliar
        public class MatriculaInfo
        {
            public int IdMatricula { get; set; }

            public string Alumno { get; set; }

            public string Asignatura { get; set; }

            public DateTime FechaMatricula { get; set; }
        }

        // 4º Lista de matriculas para mostrar en la vista
        public List<MatriculaInfo> Matriculas { get; set; }


        // 5º Constructor que sirve para inicializar las listas
        // de los dropdownlist y la lista de matriculas
        public MatriculaViewModel()
        {
            Alumnos = new List<SelectListItem>();
            Carreras = new List<SelectListItem>();
            Asignaturas = new List<SelectListItem>();
            Matriculas = new List<MatriculaInfo>();
        }

    }
}
