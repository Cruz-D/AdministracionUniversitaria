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
                new Alumno { Alumno_Nombre = "Juan", Alumno_Apellido = "Perez", Alumno_Edad = 20, Alumno_FechaNacimiento = new DateTime(2001, 5, 15), Alumno_Direccion = "Calle Falsa 123", Alumno_Telefono = "123456789", Alumno_Email = "juan.perez@example.com", Alumno_Foto = "juan.jpg" },
                new Alumno { Alumno_Nombre = "Maria", Alumno_Apellido = "Lopez", Alumno_Edad = 22, Alumno_FechaNacimiento = new DateTime(1999, 8, 22), Alumno_Direccion = "Avenida Siempre Viva 456", Alumno_Telefono = "987654321", Alumno_Email = "maria.lopez@example.com", Alumno_Foto = "maria.jpg" },
                new Alumno { Alumno_Nombre = "Carlos", Alumno_Apellido = "Sanchez", Alumno_Edad = 23, Alumno_FechaNacimiento = new DateTime(1998, 3, 10), Alumno_Direccion = "Calle Luna 789", Alumno_Telefono = "456123789", Alumno_Email = "carlos.sanchez@example.com", Alumno_Foto = "carlos.jpg" },
                new Alumno { Alumno_Nombre = "Ana", Alumno_Apellido = "Torres", Alumno_Edad = 21, Alumno_FechaNacimiento = new DateTime(2000, 11, 30), Alumno_Direccion = "Calle Sol 321", Alumno_Telefono = "321654987", Alumno_Email = "ana.torres@example.com", Alumno_Foto = "ana.jpg" },
                new Alumno { Alumno_Nombre = "Luis", Alumno_Apellido = "Gomez", Alumno_Edad = 24, Alumno_FechaNacimiento = new DateTime(1997, 7, 25), Alumno_Direccion = "Calle Estrella 654", Alumno_Telefono = "789321456", Alumno_Email = "luis.gomez@example.com", Alumno_Foto = "luis.jpg" },
                new Alumno { Alumno_Nombre = "Laura", Alumno_Apellido = "Martinez", Alumno_Edad = 19, Alumno_FechaNacimiento = new DateTime(2002, 2, 14), Alumno_Direccion = "Calle Cometa 987", Alumno_Telefono = "654789321", Alumno_Email = "laura.martinez@example.com", Alumno_Foto = "laura.jpg" },
                new Alumno { Alumno_Nombre = "Pedro", Alumno_Apellido = "Fernandez", Alumno_Edad = 25, Alumno_FechaNacimiento = new DateTime(1996, 9, 5), Alumno_Direccion = "Calle Planeta 159", Alumno_Telefono = "159753486", Alumno_Email = "pedro.fernandez@example.com", Alumno_Foto = "pedro.jpg" },
                new Alumno { Alumno_Nombre = "Sofia", Alumno_Apellido = "Ramirez", Alumno_Edad = 22, Alumno_FechaNacimiento = new DateTime(1999, 12, 20), Alumno_Direccion = "Calle Galaxia 753", Alumno_Telefono = "753159486", Alumno_Email = "sofia.ramirez@example.com", Alumno_Foto = "sofia.jpg" }
            };
            alumnos.ForEach(a => context.Alumnos_Set.Add(a));
            context.SaveChanges();

            // Crear datos de prueba para Carreras
            var carreras = new List<Carrera>
            {
                new Carrera { Carrera_Nombre = "Ingeniería Informática", Carrera_Duracion = "5 años", Carrera_Titulo = "Ingeniero Informático", Carrera_Codigo = "INF001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 50000, Carrera_NumeroAsignaturas = 40 },
                new Carrera { Carrera_Nombre = "Medicina", Carrera_Duracion = "6 años", Carrera_Titulo = "Médico Cirujano", Carrera_Codigo = "MED001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 60000, Carrera_NumeroAsignaturas = 50 },
                new Carrera { Carrera_Nombre = "Derecho", Carrera_Duracion = "5 años", Carrera_Titulo = "Abogado", Carrera_Codigo = "DER001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 40000, Carrera_NumeroAsignaturas = 35 },
                new Carrera { Carrera_Nombre = "Arquitectura", Carrera_Duracion = "5 años", Carrera_Titulo = "Arquitecto", Carrera_Codigo = "ARQ001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 55000, Carrera_NumeroAsignaturas = 45 },
                new Carrera { Carrera_Nombre = "Economía", Carrera_Duracion = "4 años", Carrera_Titulo = "Economista", Carrera_Codigo = "ECO001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 45000, Carrera_NumeroAsignaturas = 30 },
                new Carrera { Carrera_Nombre = "Ingeniería Civil", Carrera_Duracion = "5 años", Carrera_Titulo = "Ingeniero Civil", Carrera_Codigo = "CIV001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 50000, Carrera_NumeroAsignaturas = 40 },
                new Carrera { Carrera_Nombre = "Psicología", Carrera_Duracion = "4 años", Carrera_Titulo = "Psicólogo", Carrera_Codigo = "PSI001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 40000, Carrera_NumeroAsignaturas = 30 },
                new Carrera { Carrera_Nombre = "Ingeniería Electrónica", Carrera_Duracion = "5 años", Carrera_Titulo = "Ingeniero Electrónico", Carrera_Codigo = "ELE001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 50000, Carrera_NumeroAsignaturas = 40 },
                new Carrera { Carrera_Nombre = "Administración de Empresas", Carrera_Duracion = "4 años", Carrera_Titulo = "Administrador de Empresas", Carrera_Codigo = "ADM001", Carrera_Tipo = "Licenciatura", Carrera_Modalidad = "Presencial", Carrera_Coste = 45000, Carrera_NumeroAsignaturas = 30 }
            };
            carreras.ForEach(c => context.Carrera_Set.Add(c));
            context.SaveChanges();

            // Crear datos de prueba para Asignaturas
            var asignaturas = new List<Asignatura>
            {
                new Asignatura { Asignatura_Nombre = "Matemáticas", Asignatura_Creditos = 5, Asignatura_Codigo = "MAT101", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Lunes 8-10", IdCarrera = carreras[0].IdCarrera, Carrera = carreras[0] },
                new Asignatura { Asignatura_Nombre = "Programación", Asignatura_Creditos = 4, Asignatura_Codigo = "PRO102", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Martes 10-12", IdCarrera = carreras[0].IdCarrera, Carrera = carreras[0] },
                new Asignatura { Asignatura_Nombre = "Algoritmos", Asignatura_Creditos = 3, Asignatura_Codigo = "ALG103", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Miércoles 8-10", IdCarrera = carreras[0].IdCarrera, Carrera = carreras[0] },
                new Asignatura { Asignatura_Nombre = "Biología", Asignatura_Creditos = 4, Asignatura_Codigo = "BIO101", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Lunes 10-12", IdCarrera = carreras[1].IdCarrera, Carrera = carreras[1] },
                new Asignatura { Asignatura_Nombre = "Anatomía", Asignatura_Creditos = 5, Asignatura_Codigo = "ANA102", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Martes 8-10", IdCarrera = carreras[1].IdCarrera, Carrera = carreras[1] },
                new Asignatura { Asignatura_Nombre = "Fisiología", Asignatura_Creditos = 4, Asignatura_Codigo = "FIS103", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Miércoles 10-12", IdCarrera = carreras[1].IdCarrera, Carrera = carreras[1] },
                new Asignatura { Asignatura_Nombre = "Derecho Civil", Asignatura_Creditos = 6, Asignatura_Codigo = "DER101", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Lunes 8-10", IdCarrera = carreras[2].IdCarrera, Carrera = carreras[2] },
                new Asignatura { Asignatura_Nombre = "Derecho Penal", Asignatura_Creditos = 6, Asignatura_Codigo = "DER102", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Martes 10-12", IdCarrera = carreras[2].IdCarrera, Carrera = carreras[2] },
                new Asignatura { Asignatura_Nombre = "Derecho Constitucional", Asignatura_Creditos = 5, Asignatura_Codigo = "DER103", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Miércoles 8-10", IdCarrera = carreras[2].IdCarrera, Carrera = carreras[2] },
                new Asignatura { Asignatura_Nombre = "Física", Asignatura_Creditos = 5, Asignatura_Codigo = "FIS101", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Lunes 10-12", IdCarrera = carreras[3].IdCarrera, Carrera = carreras[3] },
                new Asignatura { Asignatura_Nombre = "Diseño Arquitectónico", Asignatura_Creditos = 5, Asignatura_Codigo = "DIS102", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Martes 8-10", IdCarrera = carreras[3].IdCarrera, Carrera = carreras[3] },
                new Asignatura { Asignatura_Nombre = "Historia de la Arquitectura", Asignatura_Creditos = 4, Asignatura_Codigo = "HIS103", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Miércoles 10-12", IdCarrera = carreras[3].IdCarrera, Carrera = carreras[3] },
                new Asignatura { Asignatura_Nombre = "Microeconomía", Asignatura_Creditos = 4, Asignatura_Codigo = "MIC101", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Lunes 8-10", IdCarrera = carreras[4].IdCarrera, Carrera = carreras[4] },
                new Asignatura { Asignatura_Nombre = "Macroeconomía", Asignatura_Creditos = 4, Asignatura_Codigo = "MAC102", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Martes 10-12", IdCarrera = carreras[4].IdCarrera, Carrera = carreras[4] },
                new Asignatura { Asignatura_Nombre = "Economía Internacional", Asignatura_Creditos = 4, Asignatura_Codigo = "ECO103", Asignatura_Tipo = "Obligatoria", Asignatura_Curso = "1er Año", Asignatura_Horario = "Miércoles 8-10", IdCarrera = carreras[4].IdCarrera, Carrera = carreras[4] }
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
