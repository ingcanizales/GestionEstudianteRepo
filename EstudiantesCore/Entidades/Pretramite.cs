using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    public class Pretramite
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

       
        [MaxLength(20)]
        public string Documento { get; set; }

        public string NombreTramite { get; set; }

        public Persona Persona { get; set; }

        public int Estado { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

    }
}
