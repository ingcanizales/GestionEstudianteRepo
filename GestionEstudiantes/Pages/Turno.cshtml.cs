using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EstudiantesCore.Dtos;
using EstudiantesCore.Entidades;
using EstudiantesCore.Enums;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;

namespace GestionEstudiantes.Pages
{
    public class TurnoModel : PageModel
    {
        private readonly IEstudiantes _gestionEstudiante;
        private readonly IMatricula _matricula;
        private readonly ITramites _gestionTramites;

        public TurnoModel(IEstudiantes gestionEstudiante, IMatricula matricula, ITramites gestionTramites)
        {
            _gestionEstudiante = gestionEstudiante;
            _matricula = matricula;
            _gestionTramites = gestionTramites;
        }

        public void OnGet()
        {

        }

        [HttpGet]
        public IActionResult OnGetTipoDocumento(DataSourceLoadOptions options)
        {
            try
            {
                List<TipoDocumento> documentos = _gestionEstudiante.GetDocumento();
                return new JsonResult(DataSourceLoader.Load(documentos, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetCargos(DataSourceLoadOptions options)
        {
            try
            {
                List<String> cargos = _gestionTramites.GetCargos();
                return new JsonResult(DataSourceLoader.Load(cargos, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public IActionResult OnGetTramites(DataSourceLoadOptions options)
        {
            try
            {
                List<String> tramites = _gestionTramites.GetTramites();
                return new JsonResult(DataSourceLoader.Load(tramites, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetPretramites(DataSourceLoadOptions options)
        {
            try
            {
                List<Pretramite> pretramites = _gestionTramites.GetPretramites();
                return new JsonResult(DataSourceLoader.Load(pretramites, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public JsonResult OnPostLoadDatosById(string Identificacion, int tipoDocumentoId)
        {
            Persona claseVTipoS = new Persona();
            try
            {
                if (!string.IsNullOrEmpty(Identificacion) && tipoDocumentoId>0)
                {
                    claseVTipoS = _gestionTramites.LoadDatosById(Identificacion, tipoDocumentoId);
                    string json = JsonConvert.SerializeObject(claseVTipoS, Formatting.Indented);
                    
                }
                
                return new JsonResult(claseVTipoS);
            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e, "Error al cargar las clases del vehículo para la placa especificada.");
                return new JsonResult("Error al cargar las clases del vehículo para la placa especificada.");
            }
            
        }

        [HttpPost]
        public IActionResult OnPostCrearPretramite(Pretramite pretramite)
        {
            try
            {
                if (pretramite.Id == 0)
                {
                    //pretramite.Estado = _gestionEstudiante.GetEstadoByCodigo("M");
                   _gestionTramites.CrearPretramite(pretramite);
                }
                //else
                //{
                //    _gestionEstudiante.ActualizarEstudiante(estudiante);
                //}

                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
