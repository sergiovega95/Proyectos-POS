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
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
        public int actualindex;
        
       


        public Vnuevoproducto()
        {
            InitializeComponent();
         


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

      
        //private void Vnuevoproducto_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //Vproducto ventana_venta = new Vproducto();
        //    //ventana_venta.Show();
        //}

        //private void button3_Click_1(object sender, EventArgs e)
        //{
            
                        
        //}

        private void Vnuevoproducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet3.tabla_productos' Puede moverla o quitarla según sea necesario.
            this.tabla_productosTableAdapter1.Fill(this.dbPOSDataSet3.tabla_productos);
            //Consulto Cargo y Genero el Codigo para un producto nuevo leyendo el ultimo de la base
            //string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura = "select max (Codigo) from tabla_productos";
            SqlCommand comando = new SqlCommand(peticion_lectura, conexion);
            string ultimo_codigo = comando.ExecuteScalar().ToString();
            int nuevo_codigo = Convert.ToInt32(ultimo_codigo) + 1;
            textBox1.Text = Convert.ToString(nuevo_codigo);
                        
            //Esta línea de código carga datos en la tabla 'dbPOSDataSet.tabla_productos' Puede moverla o quitarla según sea necesario.
            //this.tabla_productosTableAdapter.Fill(this.dbPOSDataSet.tabla_productos);

        }

       
        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Este evento me proporciona filtrar en tiempo real un producto de la lista de producto
            //que estan en la base de datos

            string filtro = textBox4.Text;
            //string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura_filtro = "select Codigo,Nombre,Precio,Stock from tabla_productos where Nombre like '" + filtro + "%' ";
            SqlCommand comando = new SqlCommand(peticion_lectura_filtro, conexion);
            comando.ExecuteNonQuery();

            //Lleno los datos de el datagridview con los resultados retornados del filtro
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
                //Definición de las cajas de texto y del query (peticion_escritura)
                //la conexion y el query los gestiona la clase "clase_escritura"

                string nombre = textBox2.Text;
                string precio = textBox3.Text;
                string peticion_escritura = "insert into tabla_productos(Nombre,Precio) Values('" + nombre + "'," + precio + " )";
                clase_escritura consulta = new clase_escritura();
                int resultado = consulta.escribir(database, peticion_escritura);
                
                if (resultado > 0)
                {
                    //Mensaje para mostar al usuario y limpiar los registros para Agregar un nuevo producto

                    MessageBox.Show("Se agrego Correctamente el nuevo producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                }
                else

                {
                    MessageBox.Show("No se pudo agregar el producto a la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                

            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Petición ala base de datos para que me retorne el codigo del ultimo producto agregado
            // para asi poder asignar de forma automatica el codigo del nuevo usando el boton Auto.

            //string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
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
            //logica para cuando se desea eliminar un producto de la tabla de productos  por ende
            //de la base de datos

            DialogResult eleccion= MessageBox.Show("Seguro desea eliminar el producto de la lista", "My Application",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            if (eleccion== DialogResult.OK)
            {
                try
                {
                    int actualindex = dataGridView1.SelectedRows[0].Index;
                    string codigo_producto_seleccionado = dataGridView1.Rows[actualindex].Cells[0].Value.ToString();
                    string peticion_borrar = "delete from tabla_productos where Codigo = " + codigo_producto_seleccionado + " ";
                    clase_escritura consulta = new clase_escritura();
                    int resultado = consulta.escribir(database, peticion_borrar);

                    if (resultado>0)
                    {
                        MessageBox.Show("Se Borro el Producto Correctamente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }                                  
               

                    // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet.tabla_productos' Puede moverla o quitarla según sea necesario.
                    this.tabla_productosTableAdapter.Fill(this.dbPOSDataSet.tabla_productos);
                }

                catch{
                    MessageBox.Show("Para Borrar un Producto debe elegir toda la fila y no solo una celda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                }
               
            }          

                     

        }

        private void button5_Click(object sender, EventArgs e)
        { //Logica para adquirir el codigo , producto y precio de la fila seleccionada
          //del datagridview que  muestra la lista de productos 
         
            try
            {
                int actualindex =dataGridView1.SelectedRows[0].Index; //Indice de la fila seleccionada
                actualindex = dataGridView1.SelectedRows[0].Index;
                string codigo_producto_edicion = dataGridView1.Rows[actualindex].Cells[0].Value.ToString();
                string nombre_producto_edicion = dataGridView1.Rows[actualindex].Cells[1].Value.ToString();
                string precio_producto_edicion = dataGridView1.Rows[actualindex].Cells[2].Value.ToString();

                //instancio este Forms por que los valores  adquiridos de la fila seleccionada
                //se los comparto a los textos del otro form
                Veditar ventanaeditar = new Veditar();
                ventanaeditar.textBox1.Text = codigo_producto_edicion;
                ventanaeditar.textBox2.Text = nombre_producto_edicion;
                ventanaeditar.textBox3.Text = precio_producto_edicion;                       
                ventanaeditar.Show();
            }

            catch
            {
              MessageBox.Show("Para Editar un Producto debe elegir toda la fila y no solo una celda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                     
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {   //verifico que solo existan numeros en la casilla precio de un nuevo producto

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                button2.Focus();


            }
        }
    }
}
