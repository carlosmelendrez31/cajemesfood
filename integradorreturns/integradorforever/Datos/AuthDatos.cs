using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using integradorforever.Models;
using integradorforever.Datos;

namespace YourNamespace.Data
{
    public class AuthDatos{ 
        // Método para obtener un usuario por nombre
        public Usuariomodel ObtenerNombreUsuario(string nombre)
        {
            Usuariomodel user = null;
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                string query = "SELECT * FROM Usuario WHERE Nombre = @Nombre";
                using (SqlCommand command = new SqlCommand(query,conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    conexion.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Usuariomodel
                            {
                                id_usuario = Convert.ToInt32(reader["id_Usuario"]),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                contrasena = reader["contrasena"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }
        public Adminmodel obtenerAdmini(string Nombre)
        {
            Adminmodel admin = null;
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                string query = "SELECT * FROM Administrador WHERE Nombre = @Nombre";
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    conexion.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            admin = new Adminmodel
                            {
                                Matricula = Convert.ToInt32(reader["Matricula"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                contrasena = reader["Contrasena"].ToString()
                            };
                        }
                    }
                }
            }

            return admin;
        }
       
    }
}

