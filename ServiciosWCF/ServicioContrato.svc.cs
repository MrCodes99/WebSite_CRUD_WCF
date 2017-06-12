using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//REFERENCIA
using System.Data.SqlClient;
using System.Data;

namespace ServiciosWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioContrato" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioContrato.svc o ServicioContrato.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioContrato : IServicioContrato
    {
        string IServicioContrato.Actualizar(cliente reg)
        {
            string msj = "";

            //No dejamos el rastro el uso de la conexion
            using (SqlConnection cn = new SqlConnection(
                "server=.; database=Negocios2017; uid=sql; pwd=sql"))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "update tb_clientes set nombrecia = @nom, direccion = @dir, idpais = @pais,"+
                        "telefono = @fono where idcliente = @cod", cn);
                    cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@dir", reg.direccion);
                    cmd.Parameters.AddWithValue("@pais", reg.idpais);
                    cmd.Parameters.AddWithValue("@fono", reg.telefono);
                    cmd.Parameters.AddWithValue("@cod", reg.idcliente);

                    cmd.ExecuteNonQuery();
                    msj = "Registro actualizado";
                }
                catch (SqlException e)
                {
                    msj = e.Message;
                }
                finally
                {
                    cn.Close();
                }

            }

            return msj;
        }

        string IServicioContrato.Agregar(cliente reg)
        {
            string msj = "";

            using (SqlConnection cn = new SqlConnection(
                "server=.; database=Negocios2017; uid=sql; pwd=sql"))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "insert into tb_clientes values(@cod,@nom,@dir,@pais,@fono)",cn);
                    cmd.Parameters.AddWithValue("@cod", reg.idcliente);
                    cmd.Parameters.AddWithValue("@nom", reg.nombrecia);
                    cmd.Parameters.AddWithValue("@dir", reg.direccion);
                    cmd.Parameters.AddWithValue("@pais", reg.idpais);
                    cmd.Parameters.AddWithValue("@fono", reg.telefono);

                    cmd.ExecuteNonQuery();
                    msj = "Registro exitoso";
                }
                catch(SqlException e)
                {
                    msj = e.Message;
                }
                finally
                {
                    cn.Close();
                }
                
            }

            return msj;
        }

        string IServicioContrato.Eliminar(cliente reg)
        {
            string msj = "";

            using (SqlConnection cn = new SqlConnection(
                "server=.; database=Negocios2017; uid=sql; pwd=sql"))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "delete from tb_clientes where idcliente = @cod", cn);
                    cmd.Parameters.AddWithValue("@cod", reg.idcliente);

                    cmd.ExecuteNonQuery();
                    msj = "Registro eliminado";
                }
                catch (SqlException e)
                {
                    msj = e.Message;
                }
                finally
                {
                    cn.Close();
                }

            }

            return msj;
        }

        List<cliente> IServicioContrato.Clientes()
        {
            List<cliente> lista = new List<cliente>();

            using (SqlConnection cn = new SqlConnection(
                "server=.; database=Negocios2017; uid=sql; pwd=sql"))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from tb_clientes", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente reg = new cliente();
                    reg.idcliente = dr.GetString(0);
                    reg.nombrecia = dr.GetString(1);
                    reg.direccion = dr.GetString(2);
                    reg.idpais = dr.GetString(3);
                    reg.telefono = dr.GetString(4);

                        lista.Add(reg);
                }

                dr.Close();
                cn.Close();
            }
            
            
                return lista;
        }

        List<cliente> IServicioContrato.ClientesxPais(string pais)
        {
            List<cliente> lista = new List<cliente>();

            using (SqlConnection cn = new SqlConnection(
                "server=.; database=Negocios2017; uid=sql; pwd=sql"))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from tb_clientes where idpais = @pais", cn);
                cmd.Parameters.AddWithValue("@pais", pais);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente reg = new cliente();
                    reg.idcliente = dr.GetString(0);
                    reg.nombrecia = dr.GetString(1);
                    reg.direccion = dr.GetString(2);
                    reg.idpais = dr.GetString(3);
                    reg.telefono = dr.GetString(4);

                    lista.Add(reg);
                }

                dr.Close();
                cn.Close();
            }


            return lista;
        }
        

        List<pais> IServicioContrato.Paises()
        {
            List<pais> lista = new List<pais>();

            using (SqlConnection cn = new SqlConnection(
                "server=.; database=Negocios2017; uid=sql; pwd=sql"))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from tb_paises", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pais reg = new pais();
                    reg.idpais = dr.GetString(0);
                    reg.nombrepais = dr.GetString(1);

                        lista.Add(reg);
               }

                dr.Close();
                cn.Close();
            }


            return lista;
        }
    }
}
