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

        public DataTable dt;
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
        double impuesto = 0.19;
        public double descuento = 0.0;
        public string actual_id_factura;
        // public double sumatotal = 0.0;


        public Vproducto()
        {
            InitializeComponent();
            //Inicializacion del Timer que me permite mostrar la hora y fecha
            timer1.Enabled = true;
            textBox3.Text = "0";
           
        }

             

        private void button6_Click(object sender, EventArgs e)
        {
            
            double descuento = (Convert.ToDouble(textBox3.Text)) / 100;


            //Verificación si los espacios de codigo, cantidad y nombre de productos estaban vacios

            if (textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string producto_elegido = comboBox1.Text;
            string peticion_lectura_precio = "select Precio from tabla_productos where Nombre = '" + producto_elegido + "' ";
            clase_lectura leer = new clase_lectura();
            string precio_producto = leer.leer_un_dato(database, peticion_lectura_precio);

            Int32 numero_filas = dataGridView_tabla.Rows.Count;
            int numero_fila = 0;
            int bandera = 0;

            //Este for recorre toda las filas de el datagridview_tabla y me busca si el ultimo
            //producto que agrege ya existe en la tabla , para asi solo sumar sus cantidades

            for (int a = 0; a < numero_filas; a++)
            {
                string codigo_actual = (string)dataGridView_tabla.Rows[a].Cells[0].Value;

                if (codigo_actual == textBox5.Text)
                {
                    //MessageBox.Show("El articulo ya existe en la tabla");
                    numero_fila = a;
                    bandera = 1;

                }

            }

            if (bandera == 1) {

                //Logica para sumar cantidades de productos iguales
                dataGridView_tabla.Rows[numero_fila].Cells[3].Value = Convert.ToString(Convert.ToInt32((string)dataGridView_tabla.Rows[numero_fila].Cells[3].Value) + Convert.ToInt32(textBox6.Text));
                double aux3 = Convert.ToDouble(dataGridView_tabla.Rows[numero_fila].Cells[3].Value);
                double aux4 = Convert.ToDouble(precio_producto);
                double valortotal = aux3 * aux4;
                dataGridView_tabla.Rows[numero_fila].Cells[4].Value = Convert.ToString(valortotal);


                //Clase que me entrega el total, subtotal, impuesto ,descuento 
                Totalizar resultado = new Totalizar(dt);
                textBox1.Text = resultado.subtotal(impuesto);
                textBox2.Text = resultado.impuesto(impuesto);
                textBox4.Text = resultado.sumatotal(descuento);
                label25.Text = resultado.sumatotal(descuento);
                textBox5.Focus();

                //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs                       

                textBox5.Focus();
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.Text = "";

            }

            else if (bandera != 1)
            {
                //MessageBox.Show("El articulo se agrega por primera vez");

                double aux2, aux3;
                aux2 = Convert.ToDouble(textBox6.Text);
                aux3 = Convert.ToDouble(precio_producto);
                double valortotal = aux2 * aux3;

                DataRow row = dt.NewRow();
                row["Codigo"] = textBox5.Text;
                row["Detalle"] = comboBox1.Text; ;
                row["Valor Unitario"] = precio_producto; ;
                row["Cantidad"] = textBox6.Text; ;
                row["Valor Total"] = Convert.ToString(valortotal); ;
                dt.Rows.Add(row);
                
                //Refresco las textbox para ingresar nuevo datos
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.Text = "";

                //Clase que me entrega el total a pagar

                Totalizar resultado = new Totalizar(dt);
                textBox1.Text = resultado.subtotal(impuesto);
                textBox2.Text = resultado.impuesto(impuesto);
                textBox4.Text = resultado.sumatotal(descuento);
                label25.Text = resultado.sumatotal(descuento);
                textBox5.Focus();



                //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs                       




            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //muestro la Hora del sistema en un simple label
            lblhora.Text = DateTime.Now.ToString("G");
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

            dt.Clear();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            label25.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";

            button6.Enabled = true;
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
            comboBox1.Text = "Huevo Kikes";

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
            //double descuento = (Convert.ToDouble(textBox3.Text)) / 100;

            try {

                int fila_seleccionada = dataGridView_tabla.SelectedRows[0].Index;
                
                dataGridView_tabla.Rows.RemoveAt(fila_seleccionada); //Remuevo la fila seleccionada del datagridview


                //Clase que me entrega el total a pagar , la tengo que llamar para que 
                //recalcule el total despues de haber borrado un articulo

                Totalizar resultado = new Totalizar(dt);
                textBox1.Text = resultado.subtotal(impuesto);
                textBox2.Text = resultado.impuesto(impuesto);
                textBox4.Text = resultado.sumatotal(descuento);
                label25.Text = resultado.sumatotal(descuento);
                textBox5.Focus();
            }

            catch
            {

                MessageBox.Show("No existen registros que se puedan borrar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



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

                button6.Focus();


            }



        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string peticion_lectura_producto = "select Nombre from tabla_productos where Codigo = '" + textBox5.Text + "' ";


            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }



            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                try {
                    clase_lectura leer = new clase_lectura();
                    string nombre_producto = leer.leer_un_dato(database, peticion_lectura_producto);
                    comboBox1.Text = nombre_producto;
                    textBox6.Focus();

                }

                catch
                {
                    clase_lectura leer = new clase_lectura();
                    int verificar = leer.verificar_existencia(database, peticion_lectura_producto);

                    if (verificar == 0)
                    {
                        MessageBox.Show("No se encontraron productos con el codigo ingresado intente con otro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox1.Text = "";
                    }



                }

            }

        }


        private void button9_Click(object sender, EventArgs e)
        {
            //Aplico el descuento ingresado

           // double descuento = (Convert.ToDouble(textBox3.Text)) / 100;


            //Clase que me entrega el total a pagar , la tengo que llamar para que 
            //recalcule el total despues de haber aplicado el descuento 

            Totalizar resultado = new Totalizar(dt);
            double descuento = (Convert.ToDouble(textBox3.Text))/100;
            textBox1.Text = resultado.subtotal(impuesto);
            textBox2.Text = resultado.impuesto(impuesto);
            textBox4.Text = resultado.sumatotal(descuento);
            label25.Text = resultado.sumatotal(descuento);
            textBox5.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //llamo la misma clase Totalizar pero esta vez con el metodo que me devuelve la 
            // cantidad de productos comprados

            Totalizar resultado = new Totalizar(dt);
            double total_productos_comprados = resultado.cantidad_de_productos();
                           
            //instancio y llamo la ventana de pago ademas de compartirle el valor total a pagar 
            // y la suma de la cantidad de productos en el datagridview

            Vpagar ventanapagar = new Vpagar(dt);
            ventanapagar.textBox1.Text = textBox4.Text;
            ventanapagar.textBox2.Text = Convert.ToString(total_productos_comprados);

            //ademas tambien le comparto el Subtotal,Impuesto,Descuento,Totalpago
            ventanapagar.Subtotal=  textBox1.Text;
            ventanapagar.Impuesto = textBox2.Text;
            ventanapagar.Descuento = textBox3.Text;
            ventanapagar.Totalpago = textBox4.Text;
            ventanapagar.actual_id_factura = actual_id_factura;
            ventanapagar.ShowDialog();
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //instancio y llamo la ventana para agregar un nuevo producto al inventario

            Vnuevoproducto ventananuevoproducto = new Vnuevoproducto();
            ventananuevoproducto.Show();
            //this.Close();

        }
        
        private void Vproducto_Load(object sender, EventArgs e)
        {
            
            //Todo lo de este evento  se ejecuta apenas el formulario se carga

             textBox5.Focus();

           // cargo todos los productos de la base de datos en el combobox1 apenas se carga el fomulario

            string peticion_lectura = "select Codigo,Nombre from tabla_productos";
            SqlConnection conexion = new SqlConnection(database);

            clase_lectura lectura = new clase_lectura();
            SqlDataReader registros = lectura.leer_varios_datos(database, peticion_lectura);

            while (registros.Read())
            {
                string nombre_producto = registros["Nombre"].ToString();
                comboBox1.Items.Add(nombre_producto);

            }

            registros.Close();
            conexion.Close();

                   

            //Creo el datatable que me va a almacenar los datos del datagridview_tabla
            dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Detalle");
            dt.Columns.Add("Valor Unitario");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Valor Total");
            dataGridView_tabla.DataSource = dt;

            string peticion_idfactura = " SELECT TOP 1 id_factura FROM tabla_facturas ORDER BY id_factura DESC ";
            clase_lectura leer = new clase_lectura();
            string ultimo_id_factura = leer.leer_un_dato(database, peticion_idfactura);
            int aux = Convert.ToInt32(ultimo_id_factura)+1;
            actual_id_factura = Convert.ToString(aux);
                      
            textBox7.Text = "#FAC-00" + actual_id_factura;
                        
            //Borro la ultima factura

            string borrar_ultima_factura = "delete from tabla_factura";
            clase_escritura consulta = new clase_escritura();
            consulta.escribir(database, borrar_ultima_factura);
                        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto_elegido = comboBox1.Text;
            string peticion_lectura_codigo = "select Codigo from tabla_productos where Nombre = '" + producto_elegido + "' ";

            clase_lectura leer = new clase_lectura();
            string codigo_producto = leer.leer_un_dato(database, peticion_lectura_codigo);
            textBox5.Text = codigo_producto;
            textBox6.Text = "1";

        }

        private void Vproducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Vlogin ventanainicio = new Vlogin();
            ventanainicio.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(database);
                conexion.Open();
                string inserta_factura = "insert into tabla_factura(Codigo,Detalle,ValorUnitario,Cantidad,ValorTotal) values(@Codigo,@Detalle,@ValorUnitario,@Cantidad,@ValorTotal) ";
                SqlCommand comando = new SqlCommand(inserta_factura, conexion);

                foreach (DataGridViewRow row in dataGridView_tabla.Rows)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@Codigo", Convert.ToString(row.Cells["Codigo"].Value));
                    comando.Parameters.AddWithValue("@Detalle", Convert.ToString(row.Cells["Detalle"].Value));
                    comando.Parameters.AddWithValue("@ValorUnitario", Convert.ToString(row.Cells["Valor Unitario"].Value));
                    comando.Parameters.AddWithValue("@Cantidad", Convert.ToString(row.Cells["Cantidad"].Value));
                    comando.Parameters.AddWithValue("@ValorTotal", Convert.ToString(row.Cells["Valor Total"].Value));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();

                string inserta_totales = "insert into tabla_totales(Subtotal,Impuesto,Descuento,Totalpago) values(" + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ") ";
                clase_escritura consulta = new clase_escritura();
                consulta.escribir(database, inserta_totales);

                Vreporte ventanareporte = new Vreporte();
                ventanareporte.Show();

            }

            catch
            {
                //Alerta cuando se quiere generar una factura con campos vacios
                MessageBox.Show("No existen campos para imprimir una factura","Cesta de compras vacia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vlista_facturas ventana = new Vlista_facturas();
            ventana.Show();

        }
    }
}
