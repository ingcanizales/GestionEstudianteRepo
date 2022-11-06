using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Interactores
{
    public interface IMatricula
    {
        void MatricularEstudiante(Estudiante estudiante);

        void ActualizarEstudiante(Estudiante estudiante);

        Estudiante ObtenerEstudiante(int IdEstudiante);

        List<Estudiante> ObtenerEstudiantes();

        List<MateriasXEstudiante> ObtenerMateriasEstudiantes(int IdEstudiante);

    }
}
