using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using EstudiantesCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
    }
}
