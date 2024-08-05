using System.Collections.Generic;
using EduTime.DataAccess.Entities;

namespace EduTime.DataAccess.Contracts
{
    public interface ICursoRepository
    {
        IEnumerable<Curso> GetAll();
        Curso GetById(int id);
        void Add(Curso curso);
        void Update(Curso curso);
        void Delete(int id);
    }
}
