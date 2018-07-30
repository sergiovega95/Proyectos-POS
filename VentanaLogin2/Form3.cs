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

      
        private void Vnuevoproducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Vproducto ventana_venta = new Vproducto();
            ventana_venta.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Vlistaproductos ventanaproductos = new Vlistaproductos();
            ventanaproductos.Show();
                        
        }

        

        private void Vnuevoproducto_Load(object sender, EventArgs e)
        {
            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura = "select max (Codigo) from tabla_productos";
            SqlCommand comando = new SqlCommand(peticion_lectura, conexion);
            string ultimo_codigo = comando.ExecuteScalar().ToString();
            int nuevo_codigo = Convert.ToInt32(ultimo_codigo) + 1;
            textBox1.Text = Convert.ToString(nuevo_codigo);
                        
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet.tabla_productos' Puede moverla o quitarla según sea necesario.
            this.tabla_productosTableAdapter.Fill(this.dbPOSDataSet.tabla_productos);

        }

       
        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            string filtro = textBox4.Text;
            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura_filtro = "select Codigo,Nombre,Precio from tabla_productos where Nombre like '" + filtro + "%' ";
            SqlCommand comando = new SqlCommand(peticion_lectura_filtro, conexion);
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult eleccion= MessageBox.Show("Seguro desea eliminar el producto de la lista", "My Application",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            if (eleccion== DialogResult.OK)
            {
                try
                {
                    int actualindex = dataGridView1.SelectedRows[0].Index;
                    string codigo_producto_seleccionado = dataGridView1.Rows[actualindex].Cells[0].Value.ToString();
                    string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
                    SqlConnection conexion = new SqlConnection(database);
                    conexion.Open();
                    string peticion_borrar = "delete from tabla_productos where Codigo = " + codigo_producto_seleccionado + " ";
                    SqlCommand comando = new SqlCommand(peticion_borrar, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Se Borro el Producto Correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conexion.Close();

                    // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet.tabla_productos' Puede moverla o quitarla según sea necesario.
                    this.tabla_productosTableAdapter.Fill(this.dbPOSDataSet.tabla_productos);
                }

                catch{
                    MessageBox.Show("Para Borrar un Producto debe elegir toda la fila y no solo una celda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
               
            }          

                     

        }
    }
}
