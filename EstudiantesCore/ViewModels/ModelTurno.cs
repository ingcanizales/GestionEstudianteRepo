using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstudiantesCore.ViewModels
{
   public  class ModelTurno
    {
        [MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Apellido { get; set; }


        [MaxLength(20)]
        public string Documento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public Cargos Cargo { get; set; }

        public Tramitacion NombreTramite { get; set; }

        public DateTime Fecha { get; set; }

        public string NombreCompleto 
        {
            get
            {
                string completename = "";
                completename = Nombre + " " + Apellido;
                return completename;
            }
        }

    }
}
