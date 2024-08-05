using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EduTime.DataAccess.Contracts;
using EduTime.DataAccess.Entities;

namespace EduTime.DataAccess.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Usuarios", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                UserID = reader.GetInt32(0),
                                UserName = reader.GetString(1),
                                PasswordHash = reader.GetString(2),
                                RoleID = reader.GetInt32(3),
                                ActivationKey = reader.IsDBNull(4) ? null : reader.GetString(4)
                                // Otros campos aquí
                            });
                        }
                    }
                }
            }
            return usuarios;
        }

        public Usuario GetById(int id)
        {
            Usuario usuario = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Usuarios WHERE UserID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                UserID = reader.GetInt32(0),
                                UserName = reader.GetString(1),
                                PasswordHash = reader.GetString(2),
                                RoleID = reader.GetInt32(3),
                                ActivationKey = reader.IsDBNull(4) ? null : reader.GetString(4)
                                // Otros campos aquí
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public void Add(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Usuarios (UserName, PasswordHash, RoleID, ActivationKey) VALUES (@UserName, @PasswordHash, @RoleID, @ActivationKey)", connection))
                {
                    command.Parameters.AddWithValue("@UserName", usuario.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", usuario.PasswordHash);
                    command.Parameters.AddWithValue("@RoleID", usuario.RoleID);
                    command.Parameters.AddWithValue("@ActivationKey", usuario.ActivationKey ?? (object)DBNull.Value);
                    // Otros parámetros aquí
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Usuarios SET UserName = @UserName, PasswordHash = @PasswordHash, RoleID = @RoleID, ActivationKey = @ActivationKey WHERE UserID = @UserID", connection))
                {
                    command.Parameters.AddWithValue("@UserName", usuario.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", usuario.PasswordHash);
                    command.Parameters.AddWithValue("@RoleID", usuario.RoleID);
                    command.Parameters.AddWithValue("@ActivationKey", usuario.ActivationKey ?? (object)DBNull.Value);
                    // Otros parámetros aquí
                    command.Parameters.AddWithValue("@UserID", usuario.UserID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Usuarios WHERE UserID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
