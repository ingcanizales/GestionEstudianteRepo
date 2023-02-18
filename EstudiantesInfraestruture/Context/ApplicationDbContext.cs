using EstudiantesCore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesInfraestruture.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<EstadoEstudiante> EstadoEstudiante { get; set; }
        public DbSet<EstadoMateria> EstadoMateria { get; set; }
        public DbSet<EstadoProfesor> EstadoProfesor { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<MateriasXEstudiante> MateriasXEstudiante { get; set; }
        public DbSet<Materia> Materia { get; set; } 
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<ProfesorXMaterias> ProfesorXMaterias { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Tramitacion> Tramitacion { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<EstadoTramite> EstadoTramite { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<TipoTramite> TipoTramite { get; set; }
        public DbSet<Pretramite> Pretramite { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasIndex(p => p.Documento)
                .HasName("idx_documento")
                .IsUnique(true);
        }
    }
}
