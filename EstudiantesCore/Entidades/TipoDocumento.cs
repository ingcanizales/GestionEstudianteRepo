﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("TipoDocumento", Schema = "GE")]
    public class TipoDocumento
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public  string Code { get; set; }

        public string Nombre { get; set; }
    }
}
