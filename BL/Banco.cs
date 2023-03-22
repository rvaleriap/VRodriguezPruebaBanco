using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL
{
    public class Banco
    {
        public static ML.Result Add(ML.Banco banco)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "BancoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        SqlParameter[] Collection = new SqlParameter[7];
                        Collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        Collection[0].Value = banco.Nombre;
                        Collection[1] = new SqlParameter("NoEmpleados", SqlDbType.VarChar);
                        Collection[1].Value = banco.NoEmpleados;
                        Collection[2] = new SqlParameter("NoSucursales", SqlDbType.VarChar);
                        Collection[2].Value = banco.NoSucursales;
                        Collection[3] = new SqlParameter("Capital", SqlDbType.VarChar);
                        Collection[3].Value = banco.Capital;
                        Collection[4] = new SqlParameter("NoClientes", SqlDbType.VarChar);
                        Collection[4].Value = banco.NoClientes;

                        banco.Pais = new ML.Pais();
                        Collection[5] = new SqlParameter("IdPais", SqlDbType.VarChar);
                        Collection[5].Value = banco.Pais.IdPais;

                       banco.RazonSocial = new ML.RazonSocial();
                        Collection[6] = new SqlParameter("IdRazonSocial", SqlDbType.VarChar);
                        Collection[6].Value = banco.RazonSocial.IdRazonSocial;

                        cmd.Parameters.AddRange(Collection);
                        cmd.Connection.Open();
                        int rowaffected = cmd.ExecuteNonQuery();
                        if (rowaffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Se ha agregado";
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "NO se ha agregado";
            }
            return result;
        }
    }
}
