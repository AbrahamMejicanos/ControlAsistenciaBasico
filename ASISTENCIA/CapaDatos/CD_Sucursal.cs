using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Sucursal
    {

        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private SqlCommand comando = new SqlCommand();
        private DataTable tabla = new DataTable();

        public DataTable Mostrar() {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__SucursalesIndex";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                comando.Parameters.Clear();
                return tabla;
            } catch (Exception ex) { throw ex; }
        }

        public void Insertar(string nombre, int turnoId) {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__SucursalInsert";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NOMBRE", nombre);
                comando.Parameters.AddWithValue("@TURNOID", turnoId);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            }
            catch(Exception ex) { throw ex; }
        }

        public void Update(string nombre, int turnoId, int id)
        {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__SucursalUpdate";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@NOMBRE", nombre);
                comando.Parameters.AddWithValue("@TURNOID", turnoId);
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            } catch (Exception ex) { throw ex; }
        }

        public void Delete(int id) {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__SucursalDelete";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
            } catch (Exception ex) { throw ex; }
        }

        public DataTable mostrarCbo()
        {
            try{
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__SucursalCbo";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                comando.Parameters.Clear();
                return tabla;
            } catch(Exception ex) { throw ex; }
        }
    }
}
