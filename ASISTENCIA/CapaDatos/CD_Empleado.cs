using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Empleado
    {
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();
        private CD_Conexion conexion = new CD_Conexion();

        public DataTable Mostrar() {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__EmpleadoIndex";
                comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                conexion.CerrarConexion();
                comando.Parameters.Clear();
                return tabla;
            } catch (Exception ex) { throw ex; }
        }

        public void Insert(int idSucursal, string codigo, string n1, string n2, string fechaC, string genero, string correo, int idPais, string ciudad, string direccion, string telefono) {
            try {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "__EmpleadoInsert";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@SUCURSALID", idSucursal);
                comando.Parameters.AddWithValue("@CODIGOEMPLEADO", codigo);
                comando.Parameters.AddWithValue("@PRIMERNOMBRE", n1);
                comando.Parameters.AddWithValue("@SEGUNDONOMBRE", n2);
                comando.Parameters.AddWithValue("@FECHANACIMIENTO", fechaC);
                comando.Parameters.AddWithValue("@GENERO", genero);
                comando.Parameters.AddWithValue("@EMAIL", correo);
                comando.Parameters.AddWithValue("@PAISID", idPais);
                comando.Parameters.AddWithValue("@CIUDAD", ciudad);
                comando.Parameters.AddWithValue("@DIRECCION", direccion);
                comando.Parameters.AddWithValue("@TELEFONO", telefono);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
            } catch (Exception ex) { throw ex; }
        }
    }
}
