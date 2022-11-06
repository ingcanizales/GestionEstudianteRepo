using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using EstudiantesInfraestruture.Context;
using EstudiantesInfraestruture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesInfraestruture.Implementations
{
    public class Estudiantes:IEstudiantes
    {
        private readonly AppDbContext _dbContext;

        public Estudiantes(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Agregar un número estudiante
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public void  MatricularEstudiante(Estudiante estudiante)
        {
           _dbContext.EstadoEstudiante.Find(estudiante.Estado.Id);
           _dbContext.TipoDocumento.Find(estudiante.TipoDocumento.Id);
           _dbContext.Estudiante.Add(estudiante);
           
           _dbContext.SaveChanges();
        }

        /// <summary>
        /// Obtiene todos los estudiantes matriculados
        /// </summary>
        /// <returns></returns>
        public List<Estudiante> GetAllEstudiantes()
        {
            return  _dbContext.Estudiante.AsNoTracking()
                            .Include(s => s.TipoDocumento)
                            .Include(s => s.Estado)
                            .ToList();
        }

        /// <summary>
        /// Obtiene la información de un estudiante por su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Estudiante> GetEstudianteById(int Id)
        {
            return await _dbContext.Estudiante
                   .Include(s=>s.TipoDocumento)
                   .Include(s=>s.Estado)
                   .Where(s => s.Id == Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// actualiza 
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public void ActualizarEstudiante(Estudiante estudiante)
        {
            bool existeEstudiante = _dbContext.Estudiante.Any(s => s.Id == estudiante.Id);

            if (existeEstudiante)
            {
                _dbContext.Estudiante.Update(estudiante);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }           
        }

        /// <summary>
        /// Obtiene todas las materías que tiene un estudiante
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        public async Task<List<MateriasXEstudiante>> GetMateriasByEstudiante(int idEstudiante)
        {
            return await _dbContext.MateriasXEstudiante
                         .Where(s => s.Estudiante.Id == idEstudiante)
                         .Include(s => s.Estado)
                         .Include(s => s.Materia).ToListAsync();
        }

        public List<TipoDocumento>GetDocumento()
        {

            List<TipoDocumento> listaTipoDocumento  = _dbContext.TipoDocumento.AsNoTracking().ToList();
            
            return listaTipoDocumento;
        }

        public List<EstadoEstudiante> GetEstados()
        {

            List<EstadoEstudiante> listaEstado = _dbContext.EstadoEstudiante.AsNoTracking().ToList();

            return listaEstado;
        }

        public bool VerificarEstudianteByDocumento(int IdTipoDocumento, string documento)
        {
            bool existe = false;
            existe = _dbContext.Estudiante.Any(s => s.TipoDocumento.Id == IdTipoDocumento && s.Documento == documento);
            return existe;

        }

        public EstadoEstudiante GetEstadoByCodigo(string codigo)
        {
            EstadoEstudiante estado = _dbContext.EstadoEstudiante.Where(s => s.Code == codigo).FirstOrDefault();
            return estado;
        }

        public Estudiante ObtenerEstudiante(int idEstudiante)
        {  
            
            return  _dbContext.Estudiante.Where(s => s.Id == idEstudiante).Include(s=>s.TipoDocumento).FirstOrDefault();
            
           
        }

        public List<Materia> GetMaterias()
        {
            List<Materia> materia = _dbContext.Materia.Include(s => s.Estado).AsNoTracking().ToList();
            return materia;
        }

        public List<EstadoMateria> GetEstadosMateria()
        {
            List<EstadoMateria> estados = _dbContext.EstadoMateria.ToList();

            return estados;
        }

        public bool VerificarCodigoUnicoMateria(string codigo)
        {
            return _dbContext.Materia.Any(s => s.Code.ToUpper() == codigo.ToUpper());
        }

        public void CrearNuevaMateria(Materia nuevaMateria)
        {
            nuevaMateria.Estado = _dbContext.EstadoMateria.Find(nuevaMateria.Estado.Id);
            _dbContext.Materia.Add(nuevaMateria);
            _dbContext.SaveChanges();
        }

        public Materia GetMateriaById(int Id)
        {
            return _dbContext.Materia.Find(Id);
        }

        public void ActualizarMateria(Materia materia)
        {
            materia.Estado = materia.Estado != null ? _dbContext.EstadoMateria.Find(materia.Id) : materia.Estado;
            _dbContext.SaveChanges();
        }

        public List<MateriasXEstudiante> ObtenerMateriasEstudiante(int IdEstudiante)
        {
            List<MateriasXEstudiante> materias = _dbContext.MateriasXEstudiante.Where(s => s.Estudiante.Id == IdEstudiante)
                                                 .Include(s => s.Materia).Include(s => s.Estado).AsNoTracking().ToList();

            return materias;
        }

    }
}
