using EduTime.Domain.Models;
using EduTime.DataAccess.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EduTime.Domain.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            var usuarios = _usuarioRepository.GetAll();
            return usuarios.Select(u => new UsuarioModel
            {
                Id = u.UserID,
                Nombre = u.UserName,
                Contrasena = u.PasswordHash,
                RolId = u.RoleID
            });
        }

        public UsuarioModel GetById(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            if (usuario == null) return null;

            return new UsuarioModel
            {
                Id = usuario.UserID,
                Nombre = usuario.UserName,
                Contrasena = usuario.PasswordHash,
                RolId = usuario.RoleID
            };
        }

        public void Add(UsuarioModel usuario)
        {
            var usuarioEntity = new EduTime.DataAccess.Entities.Usuario
            {
                UserName = usuario.Nombre,
                PasswordHash = usuario.Contrasena,
                RoleID = usuario.RolId
            };

            _usuarioRepository.Add(usuarioEntity);
        }

        public void Update(UsuarioModel usuario)
        {
            var usuarioEntity = new EduTime.DataAccess.Entities.Usuario
            {
                UserID = usuario.Id,
                UserName = usuario.Nombre,
                PasswordHash = usuario.Contrasena,
                RoleID = usuario.RolId
            };

            _usuarioRepository.Update(usuarioEntity);
        }

        public void Delete(int id)
        {
            _usuarioRepository.Delete(id);
        }
    }
}
