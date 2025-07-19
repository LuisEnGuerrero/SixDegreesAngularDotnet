using Microsoft.Data.SqlClient;
using SixDegrees.PruebaSD.Entidades;
using System.Collections.Generic;

namespace SixDegrees.PruebaSD.AccesoDatos
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT usuID, nombre, apellido FROM Usuario", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            usuID = reader.GetDecimal(0),
                            nombre = reader.GetString(1),
                            apellido = reader.GetString(2)
                        });
                    }
                }
            }

            return usuarios;
        }

        public Usuario? GetById(decimal id)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT usuID, nombre, apellido FROM Usuario WHERE usuID = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Usuario
                {
                    usuID = reader.GetDecimal(0),
                    nombre = reader.GetString(1),
                    apellido = reader.GetString(2)
                };
            }

            return null;
        }
    }
}