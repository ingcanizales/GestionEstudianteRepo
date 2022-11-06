using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EstudiantesCore.ViewModels
{
    public class EstudiantesViewModels
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

       
        public string Apellido { get; set; }

       
        public string Documento { get; set; }

        public Materia Materia { get; set; }

        public EstadoMateria Estado { get; set; }

        public string Codigo { get; set; }

        public string NombreEstado { get; set; }

        public int EstadoId { get; set; }


    }
}
