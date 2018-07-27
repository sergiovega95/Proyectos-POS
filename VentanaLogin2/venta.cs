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
    class venta:Vproducto
    {

        
        public  int Totalizar()
        {
          
          
            int index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double aux;
            double sumatotal=0.0;

          

            for (int a = 0 ; a<index; a++)
            {
                                
                string numero =(string) dataGridView_tabla.Rows[a].Cells[4].Value;
                aux = Convert.ToDouble(numero);
                valor2[a] = aux;
                

            }

            for (int h = 0; h<index; h++)
            {
                sumatotal = valor2[h] + sumatotal;
            }
                               
            
            return (index);


        }

        public double resultado()
        {

            return (sumatotal);
        }
    }
}
