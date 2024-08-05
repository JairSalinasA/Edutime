using EduTime.Domain.Models;
using EduTime.DataAccess.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EduTime.Domain.Services
{
    public class ProfesorService
    {
        private readonly IProfesorRepository _profesorRepository;

        public ProfesorService(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }

        public IEnumerable<ProfesorModel> GetAll()
        {
            var profesores = _profesorRepository.GetAll();
            return profesores.Select(p => new ProfesorModel
            {
                Id = p.ProfesorID,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Correo = p.Email
            });
        }

        public ProfesorModel GetById(int id)
        {
            var profesor = _profesorRepository.GetById(id);
            if (profesor == null) return null;

            return new ProfesorModel
            {
                Id = profesor.ProfesorID,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Correo = profesor.Email
            };
        }

        public void Add(ProfesorModel profesor)
        {
            var profesorEntity = new EduTime.DataAccess.Entities.Profesor
            {
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Email = profesor.Correo
            };

            _profesorRepository.Add(profesorEntity);
        }

        public void Update(ProfesorModel profesor)
        {
            var profesorEntity = new EduTime.DataAccess.Entities.Profesor
            {
                ProfesorID = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Email = profesor.Correo
            };

            _profesorRepository.Update(profesorEntity);
        }

        public void Delete(int id)
        {
            _profesorRepository.Delete(id);
        }
    }
}
