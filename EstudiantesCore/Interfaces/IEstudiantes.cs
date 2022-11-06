using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Interfaces
{
    public interface IEstudiantes
    {
        //Task MatricularEstudiante(Estudiante estudiante);

        void MatricularEstudiante(Estudiante estudiante);

        //Task<List<Estudiante>> GetAllEstudiantes();

        List<Estudiante> GetAllEstudiantes();

        Task<Estudiante> GetEstudianteById(int Id);

        //Task ActualizarEstudiante(Estudiante estudiante);
        void/*async Task*/ ActualizarEstudiante(Estudiante estudiante);

        Task<List<MateriasXEstudiante>> GetMateriasByEstudiante(int idEstudiante);

        List<TipoDocumento> GetDocumento();
        List<EstadoEstudiante> GetEstados();
        bool VerificarEstudianteByDocumento(int IdTipoDocumento, string documento);
        EstadoEstudiante GetEstadoByCodigo(string codigo);

        Estudiante ObtenerEstudiante(int idEstudiante);
        Materia GetMateriaById(int Id);
        void ActualizarMateria(Materia materia);
        bool VerificarCodigoUnicoMateria(string codigo);
        List<Materia> GetMaterias();
        void CrearNuevaMateria(Materia nuevaMateria);
        List<EstadoMateria> GetEstadosMateria();

        List<MateriasXEstudiante> ObtenerMateriasEstudiante(int IdEstudiante);
    }
}