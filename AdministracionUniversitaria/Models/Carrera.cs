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
        
        public string Carrera_Duracion { get; set; }
        //titulo que se obtiene al finalizar la carrera
        public string Carrera_Titulo { get; set; }
        //codigo de la carrera
        public string Carrera_Codigo { get; set; }
        //con tipo se refiere a si es tecnico, licenciatura, etc
        public string Carrera_Tipo { get; set; }
        //modalidad se refiere a si es presencial, a distancia, etc
        public string Carrera_Modalidad { get; set; }

        //coste de la carrera
        public double Carrera_Coste { get; set; }

        //numero de asignaturas que tiene la carrera
        public int Carrera_NumeroAsignaturas { get; set; }

        //relacion con las asignaturas que tiene la carrera,
        //una carrera tiene muchas asignaturas y una asignatura pertenece a una carrera
        public virtual ICollection<Asignatura> Asignaturas { get; set; }

        //relacion con los alumnos que estan cursando la carrera
        //una carrera tiene muchos alumnos y un alumno pertenece a una carrera
        public virtual ICollection<Alumno> Alumnos { get; set; }


    }
}