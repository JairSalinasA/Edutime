using System.Collections.Generic;
using EduTime.DataAccess.Entities;

namespace EduTime.DataAccess.Contracts
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
