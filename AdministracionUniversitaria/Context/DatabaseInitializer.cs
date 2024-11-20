using System;
using System.Collections.Generic;
using System.Data.Entity;
using AdministracionUniversitaria.Enums.Alumno;
using AdministracionUniversitaria.Models;

namespace AdministracionUniversitaria.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // Crear datos de prueba para Administracion
            var administracion = new List<Administracion>
            {
                new Administracion { Administracion_Nombre = "Admin", Administracion_Apellido = "Uno", Administracion_Email = "admin1@universidad.com", Administracion_Password = "admin123", Administracion_Tipo = "SuperAdmin", Administracion_FechaCreacion = DateTime.Now },
                new Administracion { Administracion_Nombre = "Admin", Administracion_Apellido = "Dos", Administracion_Email = "admin2@universidad.com", Administracion_Password = "admin123", Administracion_Tipo = "Admin", Administracion_FechaCreacion = DateTime.Now }
            };
            administracion.ForEach(a => context.Administracion_Set.Add(a));
            context.SaveChanges();

            // Crear datos de prueba para Alumnos
            var alumnos = new List<Alumno>
            {
                new Alumno
                {
                    IdAlumno = 1,
                    Alumno_Nombre = "Juan",
                    Alumno_Apellido_1 = "Pérez",
                    Alumno_Apellido_2 = "García",
                    Alumno_Sexo ="Hombre",// Fixed line
                    Alumno_FechaNacimiento = new DateTime(2000, 1, 1),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto1.jpg",
                    Alumno_Telefono_1 = "123456789",
                    Alumno_Telefono_2 = "987654321",
                    Alumno_Email = "juan.perez@example.com",
                    Alumno_Via = "Avenida",
                    Alumno_Calle = "Gran Vía",
                    Alumno_Calle_2 = "Apt 1",
                    Alumno_Numero = "123",
                    Alumno_Escalera = "A",
                    Alumno_Piso = "1",
                    Alumno_Puerta = "1",
                    Alumno_ComunidadAutonoma = "Madrid",
                    Alumno_CodigoPostal = "12345",
                },
                new Alumno
                {
                    Alumno_Nombre = "María",
                    Alumno_Apellido_1 = "López",
                    Alumno_Apellido_2 = "Martínez",
                    Alumno_Sexo ="Mujer",
                    Alumno_FechaNacimiento = new DateTime(1999, 5, 15),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto2.jpg",
                    Alumno_Telefono_1 = "234567890",
                    Alumno_Telefono_2 = "876543210",
                    Alumno_Email = "maria.lopez@example.com",
                    Alumno_Via = "Avenida",
                    Alumno_Calle = "Paseo de la Castellana",
                    Alumno_Calle_2 = "Apt 2",
                    Alumno_Numero = "456",
                    Alumno_Escalera = "B",
                    Alumno_Piso = "2",
                    Alumno_Puerta = "2",
                    Alumno_ComunidadAutonoma = "Cataluña",
                    Alumno_CodigoPostal = "12345",
                },
                new Alumno
                {
                    Alumno_Nombre = "Carlos",
                    Alumno_Apellido_1 = "Gómez",
                    Alumno_Apellido_2 = "Ruiz",
                    Alumno_Sexo ="Hombre",
                    Alumno_FechaNacimiento = new DateTime(1998, 3, 10),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto3.jpg",
                    Alumno_Telefono_1 = "345678901",
                    Alumno_Telefono_2 = "765432109",
                    Alumno_Email = "carlos.gomez@example.com",
                    Alumno_Via = "Calle",
                    Alumno_Calle = "Rambla Catalunya",
                    Alumno_Calle_2 = "Apt 3",
                    Alumno_Numero = "789",
                    Alumno_Escalera = "C",
                    Alumno_Piso = "3",
                    Alumno_Puerta = "3",
                    Alumno_ComunidadAutonoma = "Comunidad_Valenciana",
                    Alumno_CodigoPostal = "12345",
                },
                new Alumno
                {
                    Alumno_Nombre = "Ana",
                    Alumno_Apellido_1 = "Fernández",
                    Alumno_Apellido_2 = "Sánchez",
                    Alumno_Sexo ="Mujer",
                    Alumno_FechaNacimiento = new DateTime(1997, 7, 25),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto4.jpg",
                    Alumno_Telefono_1 = "456789012",
                    Alumno_Telefono_2 = "654321098",
                    Alumno_Email = "ana.fernandez@example.com",
                    Alumno_Via = "Avenida",
                    Alumno_Calle = "Plaza Mayor",
                    Alumno_Calle_2 = "Apt 4",
                    Alumno_Numero = "321",
                    Alumno_Escalera = "D",
                    Alumno_Piso = "4",
                    Alumno_Puerta = "4",
                    Alumno_ComunidadAutonoma = "Andalucía",
                    Alumno_CodigoPostal = "12345",
                },
                new Alumno
                {
                    Alumno_Nombre = "Pedro",
                    Alumno_Apellido_1 = "Martínez",
                    Alumno_Apellido_2 = "Hernández",
                    Alumno_Sexo ="Hombre",
                    Alumno_FechaNacimiento = new DateTime(2001, 11, 30),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto5.jpg",
                    Alumno_Telefono_1 = "567890123",
                    Alumno_Telefono_2 = "543210987",
                    Alumno_Email = "pedro.martinez@example.com",
                    Alumno_Via = "AvenidaAvenida",
                    Alumno_Calle = "Avda. de la Constitución",
                    Alumno_Calle_2 = "Apt 5",
                    Alumno_Numero = "654",
                    Alumno_Escalera = "E",
                    Alumno_Piso = "5",
                    Alumno_Puerta = "5",
                    Alumno_ComunidadAutonoma = "Murcia",
                    Alumno_CodigoPostal = "12345",
                },
                new Alumno
                {
                    Alumno_Nombre = "Laura",
                    Alumno_Apellido_1 = "Santos",
                    Alumno_Apellido_2 = "Domínguez",
                    Alumno_Sexo ="Mujer",
                    Alumno_FechaNacimiento = new DateTime(1995, 12, 12),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto6.jpg",
                    Alumno_Telefono_1 = "678901234",
                    Alumno_Telefono_2 = "432109876",
                    Alumno_Email = "laura.santos@example.com",
                    Alumno_Via = "Avenida",
                    Alumno_Calle = "Granada Street",
                    Alumno_Calle_2 = "Apt 6",
                    Alumno_Numero = "789",
                    Alumno_Escalera = "F",
                    Alumno_Piso = "6",
                    Alumno_Puerta = "6",
                    Alumno_ComunidadAutonoma = "Extremadura",
                    Alumno_CodigoPostal = "12345",
                },
                new Alumno
                {
                    Alumno_Nombre = "Sofía",
                    Alumno_Apellido_1 = "Ramírez",
                    Alumno_Apellido_2 = "Jiménez",
                    Alumno_Sexo ="Mujer",
                    Alumno_FechaNacimiento = new DateTime(1996, 6, 18),
                    Alumno_FechaRegistro = DateTime.Now,
                    Alumno_Foto = "foto7.jpg",
                    Alumno_Telefono_1 = "789012345",
                    Alumno_Telefono_2 = "321098765",
                    Alumno_Email = "sofia.ramirez@example.com",
                    Alumno_Via = "Calle",
                    Alumno_Calle = "Alcalá",
                    Alumno_Calle_2 = "Apt 7",
                    Alumno_Numero = "987",
                    Alumno_Escalera = "G",
                    Alumno_Piso = "7",
                    Alumno_Puerta = "7",
                    Alumno_ComunidadAutonoma = "Galicia",
                    Alumno_CodigoPostal = "12345",
                }
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

            
        }
    }
}
