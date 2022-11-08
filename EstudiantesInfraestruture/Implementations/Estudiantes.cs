using EstudiantesCore.Entidades;
using EstudiantesCore.Enums;
using EstudiantesCore.Interfaces;
using EstudiantesCore.ViewModels;
using EstudiantesInfraestruture.Context;
using EstudiantesInfraestruture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstudiantesCore.Dtos;
using DevExtreme.AspNet.Data;
using System.Collections;

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

        public List<EstudiantesViewModels> ObtenerDetalle()

        {
            List<EstudiantesViewModels> listaPagos = new List<EstudiantesViewModels>();

            var Datos = (from Estu in _dbContext.Estudiante
                          join Esta in _dbContext.EstadoEstudiante
                          on Estu.Estado.Id equals Esta.Id
                          orderby Estu.Estado.Id
                          select new EstudiantesViewModels
                          {
                              Nombre = Estu.Nombre,
                              Apellido = Estu.Apellido,
                              Documento = Estu.Documento,
                              //Codigo = Esta.Code,
                              //NombreEstado = Esta.Nombre,
                              //EstadoId = Esta.Id


                          }).ToList();
            return Datos;
           
        }

        public void EliminarEstudiante(int idEstudiante)
        {
            //bool existeEstudiante = _dbContext.Estudiante.Any(s => s.Id == estudiante.Id);
            Estudiante estudiante = new Estudiante();
            estudiante = _dbContext.Estudiante.Find(idEstudiante);

            if (estudiante != null)
            {
                List<MateriasXEstudiante> materiasxestudiantes = new List<MateriasXEstudiante>();
                materiasxestudiantes = _dbContext.MateriasXEstudiante.Where(s => s.Id == idEstudiante).ToList();
                foreach (var element in materiasxestudiantes)
                {
                    _dbContext.Attach(element);
                    _dbContext.RemoveRange(element);
                }
                estudiante.Estado = this.GetEstadoByCodigo(EnumEstadoEstudiante.Cancelado);
                _dbContext.Estudiante.Remove(estudiante);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public List<Notas> ObtenerNotasById(int idEstudiante)
        {
            List<Notas> notas = new List<Notas>();

            notas = _dbContext.Notas.Where(s => s.Estudiante.Id == idEstudiante)
                .Include(s=>s.Materia)
                .Include(s=>s.Estudiante).ToList();
            return notas;
        }

        public List<EstudiantesViewModels> GetEstudiantesOnDemanda(DataSourceLoadOptionsBase loadOptions, DateTime fechaInicio, DateTime fechaFin, int estadoId, int materiaId, string identificacion)
        {
            List<EstudiantesViewModels> listaDetalle = new List<EstudiantesViewModels>();
            string donde = "";
            //string orden = FilterOnDemand.GenerarOrden(loadOptions.Sort);

            IList Filtrado = loadOptions.Filter;


            var Datos = (from Estu in _dbContext.Estudiante
                         join Esta in _dbContext.EstadoEstudiante
                         on Estu.Estado.Id equals Esta.Id
                         join mate in _dbContext.MateriasXEstudiante
                         on Estu.Id equals mate.Estudiante.Id
                         orderby Estu.Estado.Id
                         select new EstudiantesViewModels
                         {
                             Nombre = Estu.Nombre,
                             Apellido = Estu.Apellido,
                             Documento = Estu.Documento,
                             MateriaId = mate.Materia.Id,
                             NombreEstado = Esta.Nombre,
                             EstadoId = mate.Estado.Id,
                             FechaIngreso = Estu.FechaIngreso,
                             FechaRetiro = Estu.FechaEgreso,
                             //Estado = Estu.Estado,
                             Email = Estu.Email,
                             TipoDocumento = Estu.TipoDocumento
                            
                         }).AsNoTracking();

            if (materiaId != 0)
            {
                //Datos = Datos.Where(j => !string.IsNullOrEmpty(j.Materia.ToString()) && (j.Materia.ToString()).ToLower() == materia.ToLower());
                Datos = Datos.Where(j => j.MateriaId == materiaId && j.EstadoId == EnumEstadoMateria.Activo);

            }

            if (!string.IsNullOrEmpty(identificacion))
            {
                Datos = Datos.Where(j => j.Documento == identificacion);
            }

            if (estadoId != 0)
            {
                Datos = Datos.Where(j => j.EstadoId == estadoId).GroupBy(a => a.Documento).Select(grp => grp.First());
            }

            if (fechaInicio != new DateTime() && fechaFin != new DateTime())
            {
                Datos = Datos.Where(j => j.FechaIngreso >= fechaInicio.Date && j.FechaRetiro.Date < fechaFin.Date.AddDays(1));
            }
            else if (fechaInicio != new DateTime() && fechaFin == new DateTime())
            {
                Datos = Datos.Where(j => j.FechaIngreso.Date >= fechaInicio.Date);
            }
            else if (fechaInicio == new DateTime() && fechaFin != new DateTime())
            {
                Datos = Datos.Where(j => j.FechaRetiro.Date < fechaFin.Date.AddDays(1));
            }

            listaDetalle = Datos.ToList();
            return listaDetalle;


        }

       
    }
}
