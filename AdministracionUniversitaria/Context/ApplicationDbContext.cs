using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AdministracionUniversitaria.Models;


namespace AdministracionUniversitaria.Context 
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor para la conexión a la base de datos
        public ApplicationDbContext() : base("name=bbddConnection")
        {

        }

        // Crear los DbSet para las tablas de la base de datos
        public DbSet<Alumno> Alumnos_Set { get; set; }
        public DbSet<Asignatura> Asignatura_Set { get; set; }
        public DbSet<Carrera> Carrera_Set { get; set; }
        public DbSet<Matricula> Matricula_Set { get; set; }
        public DbSet<Administracion> Administracion_Set { get; set; }
    }

}