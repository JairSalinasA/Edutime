using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EduTime.DataAccess.Contracts;
using EduTime.DataAccess.Entities;

namespace EduTime.DataAccess.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly string _connectionString;

        public CursoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Curso> GetAll()
        {
            var cursos = new List<Curso>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Cursos", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cursos.Add(new Curso
                            {
                                CursoID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                                // Otros campos aquí
                            });
                        }
                    }
                }
            }
            return cursos;
        }

        public Curso GetById(int id)
        {
            Curso curso = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Cursos WHERE CursoID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            curso = new Curso
                            {
                                CursoID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                                // Otros campos aquí
                            };
                        }
                    }
                }
            }
            return curso;
        }

        public void Add(Curso curso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Cursos (Nombre) VALUES (@Nombre)", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", curso.Nombre);
                    // Otros parámetros aquí
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Curso curso)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Cursos SET Nombre = @Nombre WHERE CursoID = @CursoID", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", curso.Nombre);
                    // Otros parámetros aquí
                    command.Parameters.AddWithValue("@CursoID", curso.CursoID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Cursos WHERE CursoID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
