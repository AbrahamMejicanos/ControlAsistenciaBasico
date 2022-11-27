using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Turnos
    {
        private CD_Conexion conexion = new CD_Conexion();

        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        public DataTable Mostrar() {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__TurnosIndex";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                return tabla;
            } catch (Exception ex) { throw ex; }
        }

        public DataTable MostrarCbo()
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__TurnosCbo";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                return tabla;
            }
            catch (Exception ex) { throw ex; }
        }

        public void Insertar(string nombre, string HEntrada, string HSalida) {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__TurnosInsert";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NOMBRE", nombre);
                comando.Parameters.AddWithValue("@HORAENTRADA", HEntrada);
                comando.Parameters.AddWithValue("@HORASALIDA", HSalida);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            } catch (Exception ex) { throw ex; }
        }

        public void Editar(string nombre, string HEntrada, string HSalida, int id) {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__TurnosUpdate";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NOMBRE", nombre);
                comando.Parameters.AddWithValue("@HORAENTRADA", HEntrada);
                comando.Parameters.AddWithValue("@HORASALIDA", HSalida);
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Eliminar(int id) {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__TurnosDelete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            } catch (Exception ex) { throw ex; }
        }
    }
}
