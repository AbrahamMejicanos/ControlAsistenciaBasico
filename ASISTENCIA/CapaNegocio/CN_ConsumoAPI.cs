using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ConsumoAPI
    {
        private ConsumoAPI api = null;
        public void Get(dynamic url) {
            api = new ConsumoAPI();
            dynamic data = "";
            data += api.Get(url);
            //nuevaEstructura(data);
            CrearJson(data);
        }

        private void nuevaEstructura(dynamic objJson) {

            int contador = 0;
            dynamic nuevo = "";
            foreach (char i in objJson) {
                if (i.Equals('{')) {
                    contador++;
                    nuevo += "\""+contador+"\": {";
                }
                else { 
                    nuevo += i;
                }
            }
            objJson = nuevo;
            nuevo = "";
            foreach (char i in objJson)
            {
                if (i.Equals('['))
                {
                    nuevo += "{";
                }
                else if (i.Equals(']'))
                {
                    nuevo += "}";
                }
                else
                {
                    nuevo += i;
                }
            }
           // CrearJson(nuevo);
        }

        private void CrearJson(dynamic nuevo) {
            TextWriter archivo = new StreamWriter("paises.json");
            archivo.Write(nuevo);
            archivo.Close();
            archivo.Dispose();
        }
    }
}
