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
    public partial class Veditar : Form
    {
        public Veditar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;
            string nombre = textBox2.Text;
            string precio = textBox3.Text;
            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();


            //Actualizo los campos nombre y precio de los productos en la base de datos
            string peticion_edicion = "update tabla_productos set Nombre='" + nombre + "',Precio=" + precio + " where Codigo=" + codigo + "";
            SqlCommand comando = new SqlCommand(peticion_edicion, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se actualizo correctamente el producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexion.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            this.Close();


        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //Vnuevoproducto ventanaproducto = new Vnuevoproducto();

                    
                       
           

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                button1.Focus();


            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                textBox3.Focus();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
