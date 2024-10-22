using integradorforever.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace integradorforever.Datos
{
    public class Comprardatos
    {

        public bool comprarproducto(int productId, decimal total, int cantidad, string Nombre)
        {
            var cn = new Conexion();
            try
            {
                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand("comprarpedido", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return false;
            }
        }

        public IEnumerable<comprarmodel> obtenerproducto()
        {
            var cn = new Conexion();
            var products = new List<comprarmodel>();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                using (var cmd = new SqlCommand("SELECT Id, Nombre, precio FROM Products", conexion))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new comprarmodel
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            return products;
        }
        public List<carritomodel> ListarCompras()
        {
            var oLista = new List<carritomodel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ConsultarCompras", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new carritomodel()
                        {
                            
                            Id = Convert.ToInt32(dr["Id"]),
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Total = Convert.ToInt32(dr["Total"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"])
                        });
                    }
                }
            }

            return oLista;
        }
    }

}
