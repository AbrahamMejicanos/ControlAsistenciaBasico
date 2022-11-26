using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private SqlConnection conexion = new SqlConnection("Server=(local);DataBase= Empresa;Integrated Security=true");

        public SqlConnection AbrirConexion() {
            if (conexion.State == ConnectionState.Closed) { 
                conexion.Open();
            }
            return conexion;
        }

        public SqlConnection CerrarConexion() {
            if (conexion.State == ConnectionState.Open) {
                conexion.Close();
            }
            return conexion;
        }
    }
}
