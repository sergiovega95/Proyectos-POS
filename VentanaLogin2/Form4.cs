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
       

        public Vpagar()
        {
            
            InitializeComponent();

            //double cambio = 0.0;
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

            Vproducto ventanaproducto = new Vproducto();
            ventanaproducto.Show();
            //ventanaproducto.Close();
            this.Close();

        }
    }
}
