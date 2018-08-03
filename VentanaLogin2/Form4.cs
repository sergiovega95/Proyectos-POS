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
   
    public partial class Vpagar : Form
    {
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";


        public Vpagar()
        {
            
            InitializeComponent();
                      
            double pagacon = 0.0;
            double total = 0.0;
            textBox3.Text = "0.0";
            textBox4.Text = "0.0";
            Vproducto ventanaproducto = new Vproducto();
            total = (ventanaproducto.sumatotal)-(ventanaproducto.sumatotal*ventanaproducto.descuento);            
            pagacon = Convert.ToDouble(textBox3.Text);

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Evento enter para calcular cuanto es el cambio a dar 

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                double cambio;
                double total;
                double pagacon;

                total = Convert.ToDouble(textBox1.Text);
                pagacon = Convert.ToDouble(textBox3.Text);
                cambio =Math.Abs(total - pagacon);
                textBox4.Text = Convert.ToString(cambio);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vproducto Ventanaproducto = new Vproducto();
            int numero_filas = Ventanaproducto.dataGridView_tabla.RowCount;
            MessageBox.Show(Convert.ToString(numero_filas));

            for (int i = 0; i < numero_filas; i++)
            {
                string codigo_producto =(string)Ventanaproducto.dataGridView_tabla.Rows[i].Cells[0].Value;
                string cantidad_productos_vendidos = (string)Ventanaproducto.dataGridView_tabla.Rows[i].Cells[3].Value;

                string peticion_stock_actual = "Select Stock from tabla_productos where Codigo=" + codigo_producto + "";

                clase_lectura leer = new clase_lectura();
                string stock_actual = leer.leer_un_dato(database, peticion_stock_actual);

                int stock_nuevo = Convert.ToInt32(stock_actual)-Convert.ToInt32(cantidad_productos_vendidos);

                string peticion_modificar_stock = "update tabla_productos set Stock = " + Convert.ToString(stock_nuevo)+" where Codigo= "+codigo_producto+" ";
                clase_escritura consulta = new clase_escritura();
                int resultado= consulta.escribir(database, peticion_modificar_stock);
            }
            
            //Vuelvo a la pantalla principal despues de pagar y cierro la de pago
            Vproducto ventanaproducto = new Vproducto();
            ventanaproducto.button6.Enabled = false;
            ventanaproducto.borrarform2.Enabled = false;
            ventanaproducto.limpiarform2.Enabled = false;
            ventanaproducto.dataGridView_tabla.Enabled = false;
            this.Close();

        }
    }
}
