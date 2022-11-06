using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GestionEstudiantes.Pages
   {
    public class MateriasModel : PageModel
    {
        private readonly IEstudiantes _gestionEstudiante;
        public MateriasModel(IEstudiantes estudiante)
        {
            _gestionEstudiante = estudiante;
        }
    
        public void OnGet()
        {
        }

        /// <summary>
        /// Obtiene todas las mater�as registradas en el aplicativo
        /// </summary>
        /// <param name="options">parametros de devextreme</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetObtenerMaterias(DataSourceLoadOptions options)
        {
            try
            {
                List<Materia> materias = _gestionEstudiante.GetMaterias();
                return new JsonResult(DataSourceLoader.Load(materias, options));
            }
            catch (Exception e)
            {
                return BadRequest("Existio un error al cargar los datos");
            }
        }

        /// <summary>
        /// Obtiene los estados de las mater�as
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetObtenerEstadoMaterias(DataSourceLoadOptions options)
        {
            try
            {
                List<EstadoMateria> estadosMaterias = _gestionEstudiante.GetEstadosMateria();
                return new JsonResult(DataSourceLoader.Load(estadosMaterias, options));
            }
            catch (Exception e)
            {
                return BadRequest("Existio un error al cargar los datos");
            }
        }

        /// <summary>
        /// Verifica que el codigo de una mater�a sea unica
        /// </summary>
        /// <param name="materiaCode"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetVerificarCodigoUnico(string materiaCode)
        {
            try
            {
                bool existe = true;

                if (!string.IsNullOrEmpty(materiaCode))
                {
                    //existe = !_gestionEstudiante.VerificarCodigoUnicoMateria(materiaCode);
                }

                return StatusCode(200, existe);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearMateria(string values)
        {
            try
            {
                Materia newmateria = new Materia();
                newmateria = JsonConvert.DeserializeObject<Materia>(values);
                _gestionEstudiante.CrearNuevaMateria(newmateria);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest("No se pudo agregar el usuario");
            }

        }

        /// <summary>
        /// actualiza el modelo
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult OnPutActualizarMateria(int key, string values)
        {
            try
            {
                if (key != 0)
                {
                    Materia materiaExistente = _gestionEstudiante.GetMateriaById(key);
                    JsonConvert.PopulateObject(values, materiaExistente);
                    _gestionEstudiante.ActualizarMateria(materiaExistente);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400, $"No se encontr� la mater�a con id {key}");
                }

            }
            catch (Exception e)
            {
                return BadRequest("No se pudo agregar el usuario");
            }
        }
    }


}

    

