using integradorforever.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace integradorforever.Datos
{
    public class Admindatos
    {

        public List<Adminmodel> ListarADMIN()
        {
            var uLista = new List<Adminmodel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("consultaradministradores", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        uLista.Add(new Adminmodel()
                        {

                            Matricula = Convert.ToInt32(dr["Matricula"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            contrasena = dr["contrasena"].ToString()

                        });
                    }
                }


            }
            return uLista;
        }







        public Adminmodel ObtenerADMIN(int Matricula)
        {
            var oadmin = new Adminmodel ();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("consultarADMIN", conexion);
                cmd.Parameters.AddWithValue("Matricula", Matricula);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oadmin.Matricula = Convert.ToInt32(dr["Matricula"]);
                        oadmin.Nombre = dr["Nombre"].ToString();
                        oadmin.Apellido = dr["Apellido"].ToString();
                        oadmin.contrasena = dr["contrasena"].ToString();
                    }
                }
                return oadmin;


            }


        }
    
    public bool GuardarADMIN (Adminmodel oadmin)
    {
            bool rpta;
            try 
            { 
           var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("insertaradmin", conexion);
                cmd.Parameters.AddWithValue("Nombre", oadmin.Nombre);
                cmd.Parameters.AddWithValue("Apellido", oadmin.Apellido);
                cmd.Parameters.AddWithValue("contrasena", oadmin.contrasena);
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
        public bool EditarADMIN(Adminmodel oadmin)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using(var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("modificaradmin",conexion);
                    cmd.Parameters.AddWithValue("Matricula", oadmin.Matricula);
                    cmd.Parameters.AddWithValue("Nombre", oadmin.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oadmin.Apellido);
                    cmd.Parameters.AddWithValue("contrasena", oadmin.contrasena);
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
        public bool EliminarADMINS(int Matricula)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("eliminaradmin", conexion); 
                    cmd.Parameters.AddWithValue("Matricula", Matricula);

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
