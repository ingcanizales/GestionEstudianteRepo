using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Dtos;
using EstudiantesCore.Entidades;
using EstudiantesCore.Enums;
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
        /// Metodo que verifica que la identificación del núevo estudiante sea unica 
        /// </summary>
        /// <param name="identificacion">identificación del estudiante</param>
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
        /// Actualiza la información de un usuario existente
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
        /// Permite obtener las materías matriculas por un estudiante
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

        /// <summary>
        /// Cancela un solo Estudiante.
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult OnPostCancelarEstudiante(int idEstudiante)
        {
            try
            {
               

                if (idEstudiante > 0)
                {

                    _gestionEstudiante.CancelarEstudiante(idEstudiante);
                }
               

                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        public IActionResult OnGetObtenerNotasById(DataSourceLoadOptions options, int idestudiante)
        {
            try
            {
                List<Notas> materias = new List<Notas>();

                if (idestudiante != 0)
                {
                    materias = _gestionEstudiante.ObtenerNotasById(idestudiante);
                }

                return new JsonResult(DataSourceLoader.Load(materias, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult OnPostCancelarVariosEstudiante(List<int>idEstudiantes)
        {
                try
            {

                List<Estudiante> estudiantes = new List<Estudiante>();

                if (idEstudiantes.Count>0)
                {

                   estudiantes = _gestionEstudiante.CancelarVariosEstudiantes(idEstudiantes);
                }
               

                    return StatusCode(200,estudiantes);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult OnPostMatricularVariosEstudiante(List<int> idEstudiantes)
        {
            try
            {

                List<Estudiante> estudiantes = new List<Estudiante>();

                if (idEstudiantes.Count > 0)
                {

                    estudiantes = _gestionEstudiante.MatricularVariosEstudiantes(idEstudiantes);
                }


                return StatusCode(200, estudiantes);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult OnPostEgresarVariosEstudiante(List<int> idEstudiantes)
        {
            try
            {

                List<Estudiante> estudiantes = new List<Estudiante>();

                if (idEstudiantes.Count > 0)
                {

                    estudiantes = _gestionEstudiante.EgresarVariosEstudiantes(idEstudiantes);
                }


                return StatusCode(200, estudiantes);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Método para obtener los documentos de los trámites seleccionados
        /// </summary>
        /// <param name="tramites">Lista de trámites seleccionados</param>
        /// <returns>Lista de documentos</returns>
        public IActionResult OnPostLoadDocumentos(List<Estudiante> tramites)
        {
            try
            {

                //List<Estudiante> estudiantes = new List<Estudiante>();

                //if (idEstudiantes.Count > 0)
                //{

                //    estudiantes = _gestionEstudiante.EgresarVariosEstudiantes(idEstudiantes);
                //}


                return StatusCode(200 /*estudiantes*/);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            //List<Documento> documentos = new List<Documento>();
            //try
            //{
            //    int pretramiteId = (int)HttpContext.Session.GetInt32("preTramiteSelectedId");
            //    PreTramite preTramite = _Ventanilla.GetById<PreTramite>(pretramiteId);

            //    List<Propietario> propietariosActuales = _Tramite.GetPropietariosVehiculo(preTramite.Placa);
            //    var tempProp = HttpContext.Session.GetString("tempProp");
            //    List<PropietarioPreTramite> tempPropietarios = JsonConvert.DeserializeObject<List<PropietarioPreTramite>>(tempProp);

            //    documentos = _Ventanilla.LoadDocumentos(tramites, preTramite, propietariosActuales, tempPropietarios);

            //    string json = JsonConvert.SerializeObject(documentos, Formatting.Indented);
            //    HttpContext.Session.SetString("documentos", json);
            //    string jsonTra = JsonConvert.SerializeObject(tramites, Formatting.Indented);
            //    HttpContext.Session.SetString("tramitesSelected", jsonTra);

            //    return new JsonResult(documentos);
            //}
            //catch (ListaDocumentosException e)
            //{
            //    Logger logger = LogManager.GetCurrentClassLogger();
            //    logger.Error(e, "Error al obtener los documentos correspondientes al trámite.");
            //    return new JsonResult("Error al obtener los documentos correspondientes al trámite.");
            //}
            //catch (Exception e)
            //{
            //    Logger logger = LogManager.GetCurrentClassLogger();
            //    logger.Error(e, "Error al obtener los documentos correspondientes al trámite.");
            //    return new JsonResult("Error al obtener los documentos correspondientes al trámite.");
            //}
        }
    }
}

    

