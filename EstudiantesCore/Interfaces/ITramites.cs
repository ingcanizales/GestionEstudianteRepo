using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Interfaces
{
    public interface ITramites
    {
        List<String> GetCargos();
        Persona LoadDatosById(string Identificacion, int tipoDocumentoId);
        void CrearPretramite(Pretramite pretramite);
        List<Pretramite> GetPretramites();
        List<string> GetTramites();
    }
}
