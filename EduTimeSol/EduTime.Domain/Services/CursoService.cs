using EduTime.Domain.Models;
using EduTime.DataAccess.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EduTime.Domain.Services
{
    public class CursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public IEnumerable<CursoModel> GetAll()
        {
            // Obtener todos los cursos desde el repositorio
            var cursos = _cursoRepository.GetAll();

            // Mapear cada curso a CursoModel
            return cursos.Select(c => new CursoModel
            {
                Id = c.CursoID,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            }).ToList();
        }

        public CursoModel GetById(int id)
        {
            // Obtener el curso por ID desde el repositorio
            var curso = _cursoRepository.GetById(id);

            if (curso == null)
                return null;

            // Mapear el curso a CursoModel
            return new CursoModel
            {
                Id = curso.CursoID,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion
            };
        }

        public void Add(CursoModel curso)
        {
            // Mapear CursoModel a la entidad Curso
            var cursoEntity = new EduTime.DataAccess.Entities.Curso
            {
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion
            };

            _cursoRepository.Add(cursoEntity);
        }

        public void Update(CursoModel curso)
        {
            // Mapear CursoModel a la entidad Curso
            var cursoEntity = new EduTime.DataAccess.Entities.Curso
            {
                CursoID = curso.Id,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion
            };

            _cursoRepository.Update(cursoEntity);
        }

        public void Delete(int id)
        {
            _cursoRepository.Delete(id);
        }
    }
}
