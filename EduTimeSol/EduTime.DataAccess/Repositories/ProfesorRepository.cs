using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EduTime.DataAccess.Contracts;
using EduTime.DataAccess.Entities;

namespace EduTime.DataAccess.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly string _connectionString;

        public ProfesorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Profesor> GetAll()
        {
            var profesores = new List<Profesor>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Profesores", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profesores.Add(new Profesor
                            {
                                ProfesorID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                                // Otros campos aquí
                            });
                        }
                    }
                }
            }
            return profesores;
        }

        public Profesor GetById(int id)
        {
            Profesor profesor = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Profesores WHERE ProfesorID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            profesor = new Profesor
                            {
                                ProfesorID = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                                // Otros campos aquí
                            };
                        }
                    }
                }
            }
            return profesor;
        }

        public void Add(Profesor profesor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Profesores (Nombre) VALUES (@Nombre)", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                    // Otros parámetros aquí
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Profesor profesor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Profesores SET Nombre = @Nombre WHERE ProfesorID = @ProfesorID", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", profesor.Nombre);
                    // Otros parámetros aquí
                    command.Parameters.AddWithValue("@ProfesorID", profesor.ProfesorID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Profesores WHERE ProfesorID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
