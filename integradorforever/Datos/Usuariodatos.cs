using integradorforever.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
namespace integradorforever.Datos
{
    public class Usuariodatos
    {
        public List<Usuariomodel> Listar()
        {
            var oLista = new List<Usuariomodel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("consultarUsuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Usuariomodel()
                        {

                            id_usuario = Convert.ToInt32(dr["id_usuario"]),
                            Nombre = dr["Nombre"].ToString(),
                            contrasena = dr["contrasena"].ToString(),
                            Telefono = dr["telefono"].ToString()

                        });
                    }
                }


            }
            return oLista;
        }
        public Usuariomodel Obtener(int id_usuario)
        {
            var ousuario = new Usuariomodel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("consultarespecifico ", conexion);
                cmd.Parameters.AddWithValue("id_usuario", id_usuario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ousuario.id_usuario = Convert.ToInt32(dr["id_usuario"]);
                        ousuario.Nombre = dr["Nombre"].ToString();
                        ousuario.contrasena = dr["contrasena"].ToString();
                        ousuario.Telefono = dr["telefono"].ToString();
                    }
                }
                return ousuario;


            }


        }
        public bool Guardar(Usuariomodel ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("insertarusuario ", conexion);
                    cmd.Parameters.AddWithValue("contrasena", ousuario.contrasena);
                    cmd.Parameters.AddWithValue("Nombre", ousuario.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ousuario.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(Usuariomodel ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("modificarUsuario", conexion);
                    cmd.Parameters.AddWithValue("id_usuario", ousuario.id_usuario);
                    cmd.Parameters.AddWithValue("contrasena", ousuario.contrasena);
                    cmd.Parameters.AddWithValue("Nombre", ousuario.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ousuario.Telefono);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        
        public bool Eliminar(int id_usuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminarUsuario", conexion);
                    cmd.Parameters.AddWithValue("id_usuario",id_usuario);
                    
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
