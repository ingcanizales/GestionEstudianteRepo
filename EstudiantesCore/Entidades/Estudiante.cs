using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("Estudiante", Schema = "GE")]
    public class Estudiante
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(200)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(20)]
        public string Documento { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(1)]
        public string Sexo { get; set; } 

        [Required]
        [MaxLength(500)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

        public int Edad { get; set; }
        public DateTime FechaEgreso { get; set; }

        public DateTime FechaRetiro { get; set; }

        [Required]
        public TipoDocumento TipoDocumento { get; set; }

        [Required]
        public EstadoEstudiante Estado { get; set; }

        [NotMapped]
        public string TipoBusqueda { get; set; }
    }
}
