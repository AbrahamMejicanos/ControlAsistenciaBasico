using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Sucursal
    {
        private CD_Sucursal objetoCD = new CD_Sucursal();
        private CD_Turnos objetoCD_T = new CD_Turnos();
        private DataTable tabla = null;

        public DataTable MostrarSucur() {
            tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public DataTable MostrarCbo() {
            tabla = new DataTable();
            tabla = objetoCD_T.MostrarCbo();
            return tabla;
        }

        public void Insertar(string nombre, string turnoId) {
            objetoCD.Insertar(nombre, Convert.ToInt32(turnoId));
        }

        public void Update(string nombre, string turnoId, string id) {
            objetoCD.Update(nombre, Convert.ToInt32(turnoId), Convert.ToInt32(id));
        }

        public void Delete(string id) {
            objetoCD.Delete(Convert.ToInt32(id));
        }
    }
}
