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
    public partial class Vnuevoproducto : Form

    {
       

        public Vnuevoproducto()
        {
            InitializeComponent();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Vproducto ventana_venta = new Vproducto();
            ventana_venta.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Subo una imagen del producto que voy a agregar a la base de datos -- esto es opcional

            string rutaimg;
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Agrega una imagen";
            openFileDialog1.Filter = "images files (*.BMP;*.JPG;*.GIF,*.PNG)|*.BMP;*.JPG;*.GIF,*.PNG|All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            rutaimg = openFileDialog1.FileName;
            pictureBox1.Load(rutaimg);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)

        {
            //Verifica que solo se pueden ingresar numeros en el texbox de codigo de producto

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Verifica que solo se pueden ingresar numeros en el texbox de codigo de precio

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Me verifica que ningun campo este vacio en los textboxs de codigo,nombre y precio antes de agregarlos 
            //a la base ya que esta no permite valores nulos

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            else
            //try

            {

           

            
                //Definición de las cajas de texto e inicilización de la conexión a la base de datos
                string nombre = textBox2.Text;
                string precio = textBox3.Text;
                string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
                SqlConnection conexion = new SqlConnection(database);
                conexion.Open();
               

                //Escrito los campos nombre y precio de los productos en la base de datos
                string peticion_escritura = "insert into tabla_productos(Nombre,Precio) Values('" + nombre + "'," + precio + " )";
                SqlCommand comando = new SqlCommand(peticion_escritura, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se agrego Correctamente el nuevo producto");
                conexion.Close();

                //Limpiar los registros para Agregar un nuevo producto
                 textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                                      
                         
                
            }
            
                                   
        }

        private void Vnuevoproducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Vproducto ventana_venta = new Vproducto();
            ventana_venta.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
       
                        
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Petición ala base de datos para que me retorne el codigo del ultimo producto agregado
            // para asi poder asignar de forma automatica el codigo del nuevo.

            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura = "select max (Codigo) from tabla_productos";
            SqlCommand comando = new SqlCommand(peticion_lectura, conexion);
            string ultimo_codigo = comando.ExecuteScalar().ToString();
            int nuevo_codigo = Convert.ToInt32(ultimo_codigo) + 1;
            textBox1.Text = Convert.ToString(nuevo_codigo);
         }
    }
}
