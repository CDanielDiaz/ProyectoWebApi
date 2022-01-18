using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Data
{

    public class ReciboData
    {
        public static string Registrar(Recibo recibo)
        {
            Recibo oRecivo = new Recibo();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("recibo_reg", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
           
                cmd.Parameters.AddWithValue("@idusuario", recibo.idusuario);
                cmd.Parameters.AddWithValue("@proveedor", recibo.proveedor);
                cmd.Parameters.AddWithValue("@monto", recibo.monto);
                cmd.Parameters.AddWithValue("@moneda", recibo.moneda);
                cmd.Parameters.AddWithValue("@fecha", recibo.fecha);
                cmd.Parameters.AddWithValue("@comentario", recibo.comentario);
               
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                 object o =cmd.ExecuteScalar();
                    String row = o.ToString(); 
                     //cmd = new SqlCommand("recibo_reg", oConexion);
                     System.Diagnostics.Debug.WriteLine(row);
                    return row;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }

        //public static List<Recibo> Listar()
        //{
        //    List<Recibo> oRecibo = new List<Recibo>();
        //    using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        //    {
        //        SqlCommand cmd = new SqlCommand("recibo_listar", oConexion);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        try
        //        {
        //            oConexion.Open();
        //            cmd.ExecuteNonQuery();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {

        //                while (dr.Read())
        //                {
        //                    oRecibo.Add(new Recibo()
        //                    {
        //                        idusuario = Convert.ToInt32(dr["idusuario"]),
        //                        idrecibo = Convert.ToInt32(dr["idrecibo"]),
        //                        proveedor = dr["proveedor"].ToString(),
        //                        monto = dr["monto"].ToString(),
        //                        moneda = dr["moneda"].ToString(),
        //                        fecha = dr["fecha"].ToString(),
        //                        comentario = dr["comentario"].ToString()

        //                    });
        //                }

        //            }
        //            return oRecibo;
        //        }
        //        catch (Exception ex)
        //        {
        //            return oRecibo;
        //        }
        //    }


        //}

        public static List<Recibo> ListarId(int id)
        {
            List<Recibo> oRecibo = new List<Recibo>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("recibo_listarid", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oRecibo.Add(new Recibo()
                            {
                                idusuario = Convert.ToInt32(dr["idusuario"]),
                                idrecibo = Convert.ToInt32(dr["idrecibo"]),
                                proveedor = dr["proveedor"].ToString(),
                                monto = dr["monto"].ToString(),
                                moneda = dr["moneda"].ToString(),
                                fecha = dr["fecha"].ToString(),
                                comentario = dr["comentario"].ToString()

                            });
                        }

                    }
                    return oRecibo;
                }
                catch (Exception ex)
                {
                    return oRecibo;
                }
            }


        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("recibo_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idrecibo", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public static bool Modificar(Recibo recibo)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("recibo_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idrecibo", recibo.idrecibo);
                cmd.Parameters.AddWithValue("@proveedor", recibo.proveedor);
                cmd.Parameters.AddWithValue("@monto", recibo.monto);
                cmd.Parameters.AddWithValue("@moneda", recibo.moneda);
                cmd.Parameters.AddWithValue("@fecha", recibo.fecha);
                cmd.Parameters.AddWithValue("@comentario", recibo.comentario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }









    }



}