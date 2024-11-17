using System;
using System.Collections.Generic;
using System.Data.Entity;
using AdministracionUniversitaria.Models;

namespace AdministracionUniversitaria.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // Crear datos de prueba para Alumnos
            var alumnos = new List<Alumno>
            {
                new Alumno { Alumno_Nombre = "Juan Perez", Alumno_Edad = 20 },
                new Alumno { Alumno_Nombre = "Maria Lopez", Alumno_Edad = 22 },
                new Alumno { Alumno_Nombre = "Carlos Sanchez", Alumno_Edad = 23 },
                new Alumno { Alumno_Nombre = "Ana Torres", Alumno_Edad = 21 },
                new Alumno { Alumno_Nombre = "Luis Gomez", Alumno_Edad = 24 },
                new Alumno { Alumno_Nombre = "Laura Martinez", Alumno_Edad = 19 },
                new Alumno { Alumno_Nombre = "Pedro Fernandez", Alumno_Edad = 25 },
                new Alumno { Alumno_Nombre = "Sofia Ramirez", Alumno_Edad = 22 }
            };
            alumnos.ForEach(a => context.Alumnos_Set.Add(a));
            context.SaveChanges();

            // Crear datos de prueba para Carreras
            var carreras = new List<Carrera>
            {
                new Carrera { Carrera_Nombre = "Ingeniería Informática" },
                new Carrera { Carrera_Nombre = "Medicina" },
                new Carrera { Carrera_Nombre = "Derecho" },
                new Carrera { Carrera_Nombre = "Arquitectura" },
                new Carrera { Carrera_Nombre = "Economía" }
            };
            carreras.ForEach(c => context.Carrera_Set.Add(c));
            context.SaveChanges();

            // Crear datos de prueba para Asignaturas
            var asignaturas = new List<Asignatura>
            {
                new Asignatura { Asignatura_Nombre = "Matemáticas", Asignatura_Creditos = 5, IdCarrera = carreras[0].IdCarrera, Carrera = carreras[0] },
                new Asignatura { Asignatura_Nombre = "Biología", Asignatura_Creditos = 4, IdCarrera = carreras[1].IdCarrera, Carrera = carreras[1] },
                new Asignatura { Asignatura_Nombre = "Derecho Civil", Asignatura_Creditos = 6, IdCarrera = carreras[2].IdCarrera, Carrera = carreras[2] },
                new Asignatura { Asignatura_Nombre = "Física", Asignatura_Creditos = 5, IdCarrera = carreras[0].IdCarrera, Carrera = carreras[0] },
                new Asignatura { Asignatura_Nombre = "Química", Asignatura_Creditos = 4, IdCarrera = carreras[1].IdCarrera, Carrera = carreras[1] },
                new Asignatura { Asignatura_Nombre = "Derecho Penal", Asignatura_Creditos = 6, IdCarrera = carreras[2].IdCarrera, Carrera = carreras[2] },
                new Asignatura { Asignatura_Nombre = "Diseño Arquitectónico", Asignatura_Creditos = 5, IdCarrera = carreras[3].IdCarrera, Carrera = carreras[3] },
                new Asignatura { Asignatura_Nombre = "Microeconomía", Asignatura_Creditos = 4, IdCarrera = carreras[4].IdCarrera, Carrera = carreras[4] }
            };
            asignaturas.ForEach(a => context.Asignatura_Set.Add(a));
            context.SaveChanges();

            // Crear datos de prueba para Matriculas
            var matriculas = new List<Matricula>
            {
                new Matricula { Alumno = alumnos[0], IdAlumno = alumnos[0].IdAlumno, Asignatura = asignaturas[0], IdAsignatura = asignaturas[0].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[1], IdAlumno = alumnos[1].IdAlumno, Asignatura = asignaturas[1], IdAsignatura = asignaturas[1].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[2], IdAlumno = alumnos[2].IdAlumno, Asignatura = asignaturas[2], IdAsignatura = asignaturas[2].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[3], IdAlumno = alumnos[3].IdAlumno, Asignatura = asignaturas[3], IdAsignatura = asignaturas[3].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[4], IdAlumno = alumnos[4].IdAlumno, Asignatura = asignaturas[4], IdAsignatura = asignaturas[4].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[5], IdAlumno = alumnos[5].IdAlumno, Asignatura = asignaturas[5], IdAsignatura = asignaturas[5].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[6], IdAlumno = alumnos[6].IdAlumno, Asignatura = asignaturas[6], IdAsignatura = asignaturas[6].IdAsignatura, Matricula_Fecha = DateTime.Now },
                new Matricula { Alumno = alumnos[7], IdAlumno = alumnos[7].IdAlumno, Asignatura = asignaturas[7], IdAsignatura = asignaturas[7].IdAsignatura, Matricula_Fecha = DateTime.Now }
            };
            matriculas.ForEach(m => context.Matricula_Set.Add(m));
            context.SaveChanges();

            // Crear datos de prueba para Administracion
            var administracion = new List<Administracion>
            {
                new Administracion { Administracion_Nombre = "Admin", Administracion_Apellido = "Uno", Administracion_Email = "admin1@universidad.com", Administracion_Password = "admin123", Administracion_Tipo = "SuperAdmin", Administracion_FechaCreacion = DateTime.Now },
                new Administracion { Administracion_Nombre = "Admin", Administracion_Apellido = "Dos", Administracion_Email = "admin2@universidad.com", Administracion_Password = "admin123", Administracion_Tipo = "Admin", Administracion_FechaCreacion = DateTime.Now }
            };
            administracion.ForEach(a => context.Administracion_Set.Add(a));
            context.SaveChanges();
        }
    }
}
