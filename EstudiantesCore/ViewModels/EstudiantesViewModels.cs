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

        //public Materia Materia { get; set; }

        public EstadoEstudiante Estado { get; set; }

        public string Codigo { get; set; }

        public string NombreEstado { get; set; }

        public int EstadoId { get; set; }
        public int TotalCount { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaRetiro { get; set; }

        //public string Materias { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int MateriaId { get; set; }

       
        public TipoDocumento TipoDocumento { get; set; }

        //public EstadoMateria Estado { get; set; }


    }
}
