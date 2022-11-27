using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        private CD_Sucursal objetoCDS = new CD_Sucursal();
        private DataTable tabla = null;
        public DataTable llenarCbo() {
            tabla = new DataTable();
            tabla = objetoCDS.mostrarCbo();
            return tabla;
        }
    }
}
