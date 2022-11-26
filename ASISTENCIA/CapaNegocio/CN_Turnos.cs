using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Turnos
    {
        private CD_Turnos objetoCD = new CD_Turnos();

        public DataTable MostrarTurn() { 
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarTurnos(string nombre, string HEntrada, string HSalida) {
            objetoCD.Insertar(nombre, HEntrada, HSalida); 
        }

        public void EditarTurno(string nombre, string HEntrada, string HSalida, string id) {
            objetoCD.Editar(nombre, HEntrada, HSalida, Convert.ToInt32(id));
        }

        public void EliminarTurno(String id) {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
