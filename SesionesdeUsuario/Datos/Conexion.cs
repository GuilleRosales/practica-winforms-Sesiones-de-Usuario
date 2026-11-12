using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesionesdeUsuario.Datos
{
    public class Conexion
    {
        SqlConnection cn = new SqlConnection(
             "SERVER=LAB1-44;DATABASE=DBSistema;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }

        public SqlConnection CerrarConexion()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }

            return cn;
        }
    }

}
