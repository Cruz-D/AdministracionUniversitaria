namespace AdministracionUniversitaria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administracions",
                c => new
                    {
                        AdministracionId = c.Int(nullable: false, identity: true),
                        Administracion_Nombre = c.String(),
                        Administracion_Apellido = c.String(),
                        Administracion_Email = c.String(),
                        Administracion_Password = c.String(),
                        Administracion_Tipo = c.String(),
                        Administracion_FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdministracionId);
            
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        IdAlumno = c.Int(nullable: false, identity: true),
                        Alumno_Nombre = c.String(),
                        Alumno_Apellido = c.String(),
                        Alumno_Edad = c.Int(nullable: false),
                        Alumno_FechaNacimiento = c.DateTime(nullable: false),
                        Alumno_Direccion = c.String(),
                        Alumno_Telefono = c.String(),
                        Alumno_Email = c.String(),
                        Alumno_Foto = c.String(),
                        Carrera_IdCarrera = c.Int(),
                    })
                .PrimaryKey(t => t.IdAlumno)
                .ForeignKey("dbo.Carreras", t => t.Carrera_IdCarrera)
                .Index(t => t.Carrera_IdCarrera);
            
            CreateTable(
                "dbo.Asignaturas",
                c => new
                    {
                        IdAsignatura = c.Int(nullable: false, identity: true),
                        Asignatura_Nombre = c.String(),
                        Asignatura_Creditos = c.Int(nullable: false),
                        Asignatura_Codigo = c.String(),
                        Asignatura_Tipo = c.String(),
                        Asignatura_Curso = c.String(),
                        Asignatura_Horario = c.String(),
                        IdCarrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAsignatura)
                .ForeignKey("dbo.Carreras", t => t.IdCarrera, cascadeDelete: true)
                .Index(t => t.IdCarrera);
            
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        IdCarrera = c.Int(nullable: false, identity: true),
                        Carrera_Nombre = c.String(),
                        Carrera_Duracion = c.String(),
                        Carrera_Titulo = c.String(),
                        Carrera_Codigo = c.String(),
                        Carrera_Tipo = c.String(),
                        Carrera_Modalidad = c.String(),
                        Carrera_Coste = c.Double(nullable: false),
                        Carrera_NumeroAsignaturas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCarrera);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        IdMatricula = c.Int(nullable: false, identity: true),
                        Matricula_Fecha = c.DateTime(nullable: false),
                        IdAlumno = c.Int(nullable: false),
                        IdAsignatura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMatricula)
                .ForeignKey("dbo.Alumnoes", t => t.IdAlumno, cascadeDelete: true)
                .ForeignKey("dbo.Asignaturas", t => t.IdAsignatura, cascadeDelete: true)
                .Index(t => t.IdAlumno)
                .Index(t => t.IdAsignatura);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "IdAsignatura", "dbo.Asignaturas");
            DropForeignKey("dbo.Matriculas", "IdAlumno", "dbo.Alumnoes");
            DropForeignKey("dbo.Asignaturas", "IdCarrera", "dbo.Carreras");
            DropForeignKey("dbo.Alumnoes", "Carrera_IdCarrera", "dbo.Carreras");
            DropIndex("dbo.Matriculas", new[] { "IdAsignatura" });
            DropIndex("dbo.Matriculas", new[] { "IdAlumno" });
            DropIndex("dbo.Asignaturas", new[] { "IdCarrera" });
            DropIndex("dbo.Alumnoes", new[] { "Carrera_IdCarrera" });
            DropTable("dbo.Matriculas");
            DropTable("dbo.Carreras");
            DropTable("dbo.Asignaturas");
            DropTable("dbo.Alumnoes");
            DropTable("dbo.Administracions");
        }
    }
}
