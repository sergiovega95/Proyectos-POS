using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VentanaLogin2
{
   
    class Totalizar
    {
         DataTable tabla = new DataTable();

        public Totalizar(DataTable dataTable_padre)
        {
            tabla = dataTable_padre;

        }


        public double presuma()
        {
            double suma = 0.0;
            foreach (DataRow fila in tabla.Rows)
            {
                string aux = fila["Valor Total"].ToString();
                double total_producto = Convert.ToDouble(aux);
                suma = suma + total_producto;

            }

            return (suma);
        }



        public string sumatotal(double descuento)
        {
            double suma = 0.0;

            foreach (DataRow fila in tabla.Rows)
            {
               string aux = fila["Valor Total"].ToString();
               double total_producto = Convert.ToDouble(aux);
               suma = suma + total_producto;

            }

            double aux2 = (suma - (suma * descuento));
            string total_pago = Convert.ToString(aux2);
            return (total_pago);
            
        }


        

                
            public double cantidad_de_productos()
             {
            double cantidad = 0.0;

            foreach (DataRow fila in tabla.Rows)
            {
                string aux = fila["Cantidad"].ToString();
                double total_producto = Convert.ToDouble(aux);
                cantidad = cantidad + total_producto;

            }

            return (cantidad);
            }


        public string subtotal(double impuesto)
        {
           double sumatotal = this.presuma();
           double aux = sumatotal - (sumatotal * impuesto);
           string valor_subtotal = Convert.ToString(aux);
           return (valor_subtotal);
        }


        public string impuesto(double impuesto)
        {
            double sumatotal = this.presuma();
            double aux = (sumatotal  * impuesto);
            string valor_impuesto = Convert.ToString(aux);
            return (valor_impuesto);
        }

        
        public string descuento(double descuento)
        {
            double sumatotal = this.presuma();
            double aux = (sumatotal - (sumatotal * descuento));
            string valor_descuento = Convert.ToString(aux);
            return (valor_descuento);
        }




       






    }
}
