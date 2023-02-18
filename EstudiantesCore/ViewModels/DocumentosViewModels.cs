using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstudiantesCore.ViewModels
{
    class DocumentosViewModels
    {

       
        public bool RegistroCivil { get; set; }


        public bool CertificadoEstudio{ get; set; }


        public bool FotocopiaCedula { get; set; }

        public bool TargetaIdentidad { get; set; }

        public bool PazySalvo { get; set; }

        public bool Carpeta { get; set; }


    }
}
