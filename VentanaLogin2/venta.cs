using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentanaLogin2
{
    class venta
    {
        

        public string Totalizar(int indice)
        {
            Vproducto ventanaproducto = new Vproducto();
            //Int32 index = ventanaproducto.dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[indice];
            double sumatotal = 0.0;
            double aux;

            for (int i = 0; i < indice; i++)
            {

                string valor = (string)ventanaproducto.dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < indice; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }
            
            return (Convert.ToString(sumatotal));


        }
    }
}
