using System.Collections.Generic;
using EduTime.DataAccess.Entities;

namespace EduTime.DataAccess.Contracts
{
    public interface IProfesorRepository
    {
        IEnumerable<Profesor> GetAll();
        Profesor GetById(int id);
        void Add(Profesor profesor);
        void Update(Profesor profesor);
        void Delete(int id);
    }
}
