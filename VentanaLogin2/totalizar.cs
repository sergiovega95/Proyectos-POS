using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentanaLogin2
{
    class totalizar
    {
        public double total(int indice)
        {
            Vproducto ventana = new Vproducto();

            //Int32 index = dataGridView_tabla.Rows.Count;
            double[] valores = new double[indice];
            int indice2 = Math.Abs(indice) + 1;
            double sumatotal = 0.0;
            double aux;

            for (int i = 0; i<indice2; i++)
            {

                string valor = (string)ventana.dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valores[i] = aux;

            }

            for (int p = 0; p < indice2; p++)
            {
                sumatotal = valores[p] + sumatotal;
            }

            //return (Convert.ToDouble(indice));
            return (sumatotal);
        }

    }
}
