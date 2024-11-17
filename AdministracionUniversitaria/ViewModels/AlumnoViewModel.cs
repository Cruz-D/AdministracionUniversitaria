﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministracionUniversitaria.ViewModels
{
    public class AlumnoViewModel
    {
        // Propiedades del alumno
        public int AlumnoId { get; set; }
        public string Alumno_Nombre { get; set; }
        public int Alumno_Edad { get; set; }

        // Clase auxiliar para mostrar información del alumno en la vista
        public class AlumnoInfo
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }

        // Lista de alumnos para mostrar en la vista
        public List<AlumnoInfo> Alumnos { get; set; }

        // Constructor para inicializar la lista de alumnos
        public AlumnoViewModel()
        {
            Alumnos = new List<AlumnoInfo>();
        }

    }
}