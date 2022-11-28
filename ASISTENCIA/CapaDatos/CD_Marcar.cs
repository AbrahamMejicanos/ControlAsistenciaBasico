using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Marcar
    {
        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = null;
        private SqlCommand comando = new SqlCommand();
        public void Marcar(string entrada, string salida, string codigo) {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "__Marcar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CODIGO", codigo);
            comando.Parameters.AddWithValue("@HORAENTRADA", entrada);
            comando.Parameters.AddWithValue("@HORASALIDA", salida);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public DataTable Mostrar() {
            tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "__VerMarcaciones";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return tabla;
        }
    }
}
