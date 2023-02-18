using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("Persona", Schema = "GE")]
    public class Persona
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Apellido { get; set; }


        [MaxLength(20)]
        public string Documento { get; set; }


        public DateTime FechaNacimiento { get; set; }


        [MaxLength(1)]
        public string Sexo { get; set; }


        [MaxLength(500)]
        public string Direccion { get; set; }


        [MaxLength(20)]
        public string Telefono { get; set; }


        public string Email { get; set; }


        public DateTime FechaIngreso { get; set; }

        public int Edad { get; set; }


        public DateTime FechaRetiro { get; set; }


        public TipoDocumento TipoDocumento { get; set; }


        [MaxLength(500)]
        public Cargos Cargo { get; set; }
    }
}
