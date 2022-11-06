using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Dtos;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEstudiantes.Pages
{
    public class EstudiantesModel : PageModel
    {
        private readonly IEstudiantes _gestionEstudiante;
        private readonly IMatricula _matricula;

        public EstudiantesModel(IEstudiantes gestionEstudiante, IMatricula matricula)
        {
            _gestionEstudiante = gestionEstudiante;
            _matricula = matricula;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// Metodo que crea un nuevo estudiante
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearEstudiante(Estudiante estudiante)
        {
            try
            {
                if (estudiante.Id == 0)
                {
                    estudiante.Estado = _gestionEstudiante.GetEstadoByCodigo("M");
                    _gestionEstudiante.MatricularEstudiante(estudiante);
                }
                else
                {
                    _gestionEstudiante.ActualizarEstudiante(estudiante);
                }

                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        /// <summary>
        /// Metodo que verifica que la identificaci�n del n�evo estudiante sea unica 
        /// </summary>
        /// <param name="identificacion">identificaci�n del estudiante</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetVerificarIdentificacionUnica(int IdTipoDocumento, string identificacion)
        {
            try
            {
                if (!string.IsNullOrEmpty(identificacion) && IdTipoDocumento>0) 
                {
                    bool existe = !_gestionEstudiante.VerificarEstudianteByDocumento(IdTipoDocumento, identificacion);
                    return StatusCode(200, existe);
                }
                

                return StatusCode(200, true);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Actualiza la informaci�n de un usuario existente
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult OnPutActualizarEstudiante(EstudianteDTO estudiante)
        {
            try
            {
                if (TryValidateModel(estudiante))
                {
                    //_gestionEstudiante.ActualizarEstudiante(estu);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Obtener estudiante
        /// </summary>
        /// <param name="idEstudiante">id estudiante</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetAllEstudiante(DataSourceLoadOptions options)
        {
            try

            {

                List<Estudiante>Estudiante = _gestionEstudiante.GetAllEstudiantes();
                return new JsonResult(DataSourceLoader.Load(Estudiante, options));
            }
            catch (Exception e)
            {
               return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult OnGetTipoDocumento(DataSourceLoadOptions options)
        {
            try
            {
                List<TipoDocumento>documentos=_gestionEstudiante.GetDocumento();
                return new JsonResult(DataSourceLoader.Load(documentos, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetEstadoEstudiante(DataSourceLoadOptions options)
        {
            try
            {
                List<EstadoEstudiante>estados=_gestionEstudiante.GetEstados();
                return new JsonResult(DataSourceLoader.Load(estados, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetObtenerEstudiante(int idEstudiante)
        {
            try

            {
                if(idEstudiante > 0)
                {
                    Estudiante estudiante = _gestionEstudiante.ObtenerEstudiante(idEstudiante);
                    return StatusCode(200, estudiante);
                }
                else
                {
                    return StatusCode(200, null);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Permite obtener las mater�as matriculas por un estudiante
        /// </summary>
        /// <param name="options"></param>
        /// <param name="IdEstudiante">Id estudiante</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetMateriasEstudiante(DataSourceLoadOptions options, int idEstudiante)
        {
            try
            {

                List<MateriasXEstudiante> materias = new List<MateriasXEstudiante>();

                if (idEstudiante != 0)
                {
                    materias = _gestionEstudiante.ObtenerMateriasEstudiante(idEstudiante);
                }

                return new JsonResult(DataSourceLoader.Load(materias, options));
            }

            catch (Exception e)
            {
                
                return BadRequest("Error inesperado");
            }

        }
    }
}

    

