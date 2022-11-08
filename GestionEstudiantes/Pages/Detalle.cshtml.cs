using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using EstudiantesCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NLog;

namespace GestionEstudiantes.Pages
{
    public class DetalleModel : PageModel
    {
        private readonly IEstudiantes _gestionEstudiante;
        private readonly IMatricula _matricula;

        public DetalleModel(IEstudiantes gestionEstudiante, IMatricula matricula)
        {
            _gestionEstudiante = gestionEstudiante;
            _matricula = matricula;
        }
        public void OnGet()
        {
        }
        [HttpGet]
        public IActionResult OnGetObtenerDatos (DataSourceLoadOptions options)
        {          
            try
            {
                List<EstudiantesViewModels> detalle = _gestionEstudiante.ObtenerDetalle();
                return new JsonResult(DataSourceLoader.Load(detalle, options));
                
            }
            catch (Exception e)

            {
                return StatusCode(500,e.Message);
            }
 
        }

        [HttpGet]
        public IActionResult OnGetEstadoEstudiante(DataSourceLoadOptions options)
        {
            try
            {
                List<EstadoEstudiante> estados = _gestionEstudiante.GetEstados();
                return new JsonResult(DataSourceLoader.Load(estados, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public IActionResult OnGetObtenerDetalleByBusqueda(DataSourceLoadOptions loadOptions, DateTime fechaInicio, DateTime fechaFin, int estado, int materia, string identificacion)
        {
            LoadResult Resultado = new LoadResult();
            List<EstudiantesViewModels> listaRecibo = new List<EstudiantesViewModels>();
            try
            {
                if ((fechaInicio != new DateTime() && fechaFin != new DateTime()) || estado != 0 || materia != 0 || !string.IsNullOrEmpty(identificacion))
                {
                    listaRecibo = _gestionEstudiante.GetEstudiantesOnDemanda(loadOptions, fechaInicio, fechaFin, estado, materia, identificacion);
                    loadOptions.Skip = 0;
                    Resultado = DataSourceLoader.Load(listaRecibo, loadOptions);

                    if (listaRecibo.Count > 0)
                    {
                        Resultado.totalCount = listaRecibo[0].TotalCount;
                    }

                }

            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Error al obtener el detlle del alumno");
                return BadRequest("Error Obteniendo el Detalle");
            }
            
            return new JsonResult(Resultado);
        }

        [HttpGet]
        public IActionResult OnGetObtenerMaterias(DataSourceLoadOptions options)
        {
            try
            {
                List<Materia> materia = _gestionEstudiante.GetMaterias()
               ;
                return new JsonResult(DataSourceLoader.Load(materia, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
