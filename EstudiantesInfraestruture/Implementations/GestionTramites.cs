using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using EstudiantesInfraestruture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EstudiantesCore.Enums;

namespace EstudiantesInfraestruture.Implementations
{
    public class GestionTramites:ITramites
    {
        private readonly AppDbContext _dbContext;

        public GestionTramites(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<string> GetCargos()
        {

            List<string> Cargos = _dbContext.Cargos.Select(s => s.Nombre).ToList();

            return Cargos;
        }

        public List<string> GetTramites()
        {

            List<string> tramites = _dbContext.Tramitacion.Select(s => s.NombreTramite).ToList();

            return tramites;
        }

        public Persona LoadDatosById(string Identificacion, int tipoDocumentoId)
        {
            Persona persona = new Persona();
           if (Identificacion != null && tipoDocumentoId > 0)
            {
                persona = _dbContext.Personas.Where(m => m.Documento == Identificacion && m.TipoDocumento.Id == tipoDocumentoId).Include(m => m.TipoDocumento).Include(m=>m.Cargo).FirstOrDefault();
            }

            return persona;
            
        }

        public void CrearPretramite(Pretramite pretramite)
        {
            pretramite.Fecha = DateTime.Now.Date;
            pretramite.Estado = EnumEstadoPretramite.Ventanilla;
           
            //_dbContext.EstadoEstudiante.Find(estudiante.Estado.Id);
            //_dbContext.Personas.Find(pretramite.Persona.Id);
            _dbContext.Pretramite.Add(pretramite);

            _dbContext.SaveChanges();
        }

        public List<Pretramite> GetPretramites()
        {

            List<Pretramite> pretramites = _dbContext.Pretramite.Include(s=>s.Persona).Include(s=>s.TipoDocumento).ToList();

            return pretramites;
        }
    }

   
}
