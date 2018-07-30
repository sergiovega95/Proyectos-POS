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
    public partial class Vproducto : Form
    {
        //Definición de las variables globales que deseo que conozcan todo el form

        double valortotal;
        double impuesto=0.19;
        public double descuento = 0.0;
        public double sumatotal = 0.0;
        
        
        public Vproducto()
        {
            InitializeComponent();

            //Inicializacion del Timer que me permite mostrar la hora y fecha
            timer1.Enabled = true;
            textBox3.Text = "0";
                           

         }

        private void button6_Click(object sender, EventArgs e)
        {
            string producto_elegido = comboBox1.Text;
                       

            descuento = (Convert.ToDouble(textBox3.Text)) / 100;


            //Verificación si los espacios de codigo, cantidad y nombre de productos estaban vacios

            if (textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura_precio = "select Precio from tabla_productos where Nombre = '" + producto_elegido + "' ";
            SqlCommand comando = new SqlCommand(peticion_lectura_precio, conexion);
            string precio_producto = comando.ExecuteScalar().ToString();
            conexion.Close();

            //instanciación de la datagridwiew para crear filas

            DataGridViewRow fila = new DataGridViewRow();
            dataGridView_tabla.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            double aux2 , aux3;

            aux2 = Convert.ToDouble(textBox6.Text);
            aux3 = Convert.ToDouble(precio_producto);
            valortotal = aux2*aux3;

            //Agrego los datos a la datagridview

            fila.CreateCells(dataGridView_tabla);
            fila.Cells[0].Value = textBox5.Text;
            fila.Cells[1].Value = comboBox1.Text;                
            fila.Cells[2].Value = precio_producto;
            fila.Cells[3].Value = textBox6.Text;
            fila.Cells[4].Value = Convert.ToString(valortotal);

            dataGridView_tabla.Rows.Add(fila);

            //Refresco las textbox para ingresar nuevo datos

            textBox5.Clear();
            textBox6.Clear(); 
            comboBox1.Text = "";

            //Logica para mostrar la sumatotal del precio de los productos

            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double sumatotal = 0.0;
            double aux;

            for (int i = 0; i <index; i++)
            {
                
                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index ; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }
        

            
            //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs                       

            textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
            textBox2.Text = Convert.ToString(sumatotal * impuesto);
            textBox4.Text = Convert.ToString((sumatotal-(sumatotal*descuento)));
            label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));

            textBox5.Focus();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //muestro la Hora del sistema en un simple label


            Hora.Text = DateTime.Now.ToString("G");
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_cocacola_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes     

            textBox5.Text = "1";
            textBox6.Text = "1";
            comboBox1.Text = "Coca Cola 250 ml";
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Limpio todos los campos del form , tanto los textbox como la datagridview

            dataGridView_tabla.Rows.Clear();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            label25.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text ="";

            agregarform2.Enabled = true;
            borrarform2.Enabled = true;

            textBox5.Focus();


        }

        private void pictureBox_aguila_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "2";
            textBox6.Text = "1";
            comboBox1.Text = "Cerveza Aguila 250 ml";
            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "3";
            textBox6.Text = "1";
            comboBox1.Text = "Pepsi 250 ml";
            

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "4";
            textBox6.Text = "1";
            comboBox1.Text = "Agua Cristal 450 ml";
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {   
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "5";
            textBox6.Text = "1";
            comboBox1.Text = "Leche Freskaleche 1000 ml";
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {   
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes
            textBox5.Text = "6";
            textBox6.Text = "1";
            comboBox1.Text = "Aceite de Girasol 1000 ml";
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "7";
            textBox6.Text = "1";
            comboBox1.Text = "Pan Tajado Bimbo";
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "8";
            textBox6.Text = "1";
            comboBox1.Text = "Pastas la muñeca 250 gr";
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {   //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "9";
            textBox6.Text = "1";
            comboBox1.Text = "Huevo Kikes ";
           
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {   
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "10";
            textBox6.Text = "1";
            comboBox1.Text = "Chocolatina Jet pequeña";
           
        }

        private void button8_Click(object sender, EventArgs e)
        {

            descuento = (Convert.ToDouble(textBox3.Text)) / 100;
            DataGridViewRow fila = new DataGridViewRow();
            int actualindex;
            actualindex = dataGridView_tabla.SelectedRows[0].Index;
            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double sumatotal = 0.0;
            double aux;
                                  
                                           
            dataGridView_tabla.Rows.RemoveAt(actualindex); //Remuevo la fila seleccionada del datagridview


            //Misma logica para volver a calcular la suma del precio total de todos los productos
            //despues de haber borrado y/o eliminado alguno
            
            for (int i = 0; i < index; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }


            //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs    

            textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
            textBox2.Text = Convert.ToString(sumatotal * impuesto);
            textBox4.Text = Convert.ToString((sumatotal - (sumatotal * descuento)));
            label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));

            textBox5.Focus();
                    

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            if ((int)e.KeyChar == (int)Keys.Enter)
            {

                agregarform2.Focus();


            }



        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            string peticion_lectura_producto = "select Nombre from tabla_productos where Codigo = '" + textBox5.Text + "' ";
            SqlCommand comando = new SqlCommand(peticion_lectura_producto, conexion);


            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }



            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try {
                
                conexion.Open();

                int verificar = Convert.ToInt32(comando.ExecuteScalar());

                conexion.Close();

                if (verificar==0) {

                    MessageBox.Show("No se encontraron productos con el codigo ingresado intente con otro");
                    textBox5.Text = "";
                    textBox6.Text = "";
                    comboBox1.Text = "";
                 }

                  
                }

                catch
                {

                    string nombre_producto = comando.ExecuteScalar().ToString();
                    comboBox1.Text = nombre_producto;
                    conexion.Close();
                    textBox6.Focus();


                }




            }

        }
                

        private void button9_Click(object sender, EventArgs e)
        {
            //Aplico el descuento ingresado

            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double sumatotal = 0.0;
            double aux;

            //Vuelvo a aplicar la logica para sumar los precios de los productos 
            //despues de haber aplicado el descuento

            for (int i = 0; i < index; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }

            //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs    

            descuento = (Convert.ToDouble(textBox3.Text)) / 100;
            textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
            textBox2.Text = Convert.ToString(sumatotal * impuesto);
            textBox4.Text = Convert.ToString((sumatotal - (sumatotal * descuento)));
            label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));

        }

        private void button5_Click(object sender, EventArgs e)
        {

                                
            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double totalproductos = 0.0;
            double aux;

            //aplico una logica similar pero esta vez para sumar la cantidad de productos
            //agregados al datagridview

            for (int i = 0; i < index; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[3].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index; p++)
            {
                totalproductos = valor2[p] + totalproductos;
            }

            //instancio y llamo la ventana de pago ademas de compartirle el valor total a pagar 
            // y la suma de la cantidad de productos en el datagridview

            Vpagar ventanapagar = new Vpagar();
            ventanapagar.textBox1.Text =textBox4.Text ;
            ventanapagar.textBox2.Text = Convert.ToString(totalproductos);
            ventanapagar.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //instancio y llamo la ventana para agregar un nuevo producto al inventario

            Vnuevoproducto ventananuevoproducto = new Vnuevoproducto();
            ventananuevoproducto.Show();
            this.Close();
                       
        }

        private void nuevaventaform2_Click(object sender, EventArgs e)
        {
            agregarform2.Enabled = true;
            borrarform2.Enabled = true;
            limpiarform2.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;

            dataGridView_tabla.Rows.Clear();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            label25.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            }

        private void Vproducto_Load(object sender, EventArgs e)
        {
            textBox5.Focus();

            // cargo todos los productos de la base de datos en el combobox1 apenas se carga el fomulario

            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura = "select Codigo,Nombre from tabla_productos";
            SqlCommand comando = new SqlCommand(peticion_lectura, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            while (registros.Read())
            {
                string nombre_producto = registros["Nombre"].ToString();
                comboBox1.Items.Add(nombre_producto);
              
            }

                        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto_elegido=comboBox1.Text;

            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura_codigo = "select Codigo from tabla_productos where Nombre = '" + producto_elegido + "' ";
            SqlCommand comando = new SqlCommand(peticion_lectura_codigo, conexion);
            string codigo_producto = comando.ExecuteScalar().ToString();
            textBox5.Text = codigo_producto;
            textBox6.Text = "1";
            conexion.Close();

                                    

        }
    }
}
