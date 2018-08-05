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

        private DataTable dt;
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
        double valortotal;
        double impuesto = 0.19;
        public double descuento = 0.0;
        public double sumatotal = 0.0;


        public Vproducto()
        {
            InitializeComponent();

            //Inicializacion del Timer que me permite mostrar la hora y fecha
            timer1.Enabled = true;
            textBox3.Text = "0";
            Int32 numero_filas = dataGridView_tabla.Rows.Count;


        }

        private void button6_Click(object sender, EventArgs e)
        {


            descuento = (Convert.ToDouble(textBox3.Text)) / 100;


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

            for (int a = 0; a < numero_filas; a++)
            {
                string codigo_actual = (string)dataGridView_tabla.Rows[a].Cells[0].Value;

                if (codigo_actual == textBox5.Text)
                {
                    numero_fila = a;
                    bandera = 1;

                }

            }

            if (bandera == 1) {

                dataGridView_tabla.Rows[numero_fila].Cells[3].Value = Convert.ToString(Convert.ToInt32((string)dataGridView_tabla.Rows[numero_fila].Cells[3].Value) + Convert.ToInt32(textBox6.Text));
                double aux3 = Convert.ToDouble(dataGridView_tabla.Rows[numero_fila].Cells[3].Value);
                double aux4 = Convert.ToDouble(precio_producto);
                valortotal = aux3 * aux4;
                dataGridView_tabla.Rows[numero_fila].Cells[4].Value = Convert.ToString(valortotal);

                //Int32 index = dataGridView_tabla.Rows.Count;
                double sumatotal = 0.0;
                double[] valor2 = new double[numero_filas];
                double aux;

                for (int a = 0; a < numero_filas; a++)
                {

                    string valor = (string)dataGridView_tabla.Rows[a].Cells[4].Value;
                    aux = Convert.ToDouble(valor);
                    valor2[a] = aux;

                }

                for (int p = 0; p < numero_filas; p++)
                {
                    sumatotal = valor2[p] + sumatotal;
                }


                //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs                       

                textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
                textBox2.Text = Convert.ToString(sumatotal * impuesto);
                textBox4.Text = Convert.ToString((sumatotal - (sumatotal * descuento)));
                label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));
                textBox5.Focus();

                textBox5.Clear();
                textBox6.Clear();
                comboBox1.Text = "";

            }

            else if (bandera != 1)
            {
                //instanciación de la datagridwiew para crear filas

                double aux2, aux3;
                aux2 = Convert.ToDouble(textBox6.Text);
                aux3 = Convert.ToDouble(precio_producto);
                valortotal = aux2 * aux3;

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

                //Logica para mostrar la sumatotal del precio de los productos

                Int32 index = dataGridView_tabla.Rows.Count;
                double sumatotal = 0.0;
                double[] valor2 = new double[index];
                double aux;

                for (int a = 0; a < index; a++)
                {

                    string valor = (string)dataGridView_tabla.Rows[a].Cells[4].Value;
                    aux = Convert.ToDouble(valor);
                    valor2[a] = aux;

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
            descuento = (Convert.ToDouble(textBox3.Text)) / 100;

            try {

                int actualnumero_filas = dataGridView_tabla.SelectedRows[0].Index;
                Int32 numero_filas = dataGridView_tabla.Rows.Count - 1;
                double[] valor2 = new double[numero_filas];
                double sumatotal = 0.0;
                double aux;


                dataGridView_tabla.Rows.RemoveAt(actualnumero_filas); //Remuevo la fila seleccionada del datagridview


                //Misma logica para volver a calcular la suma del precio total de todos los productos
                //despues de haber borrado y/o eliminado alguno

                for (int i = 0; i < numero_filas; i++)
                {

                    string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                    aux = Convert.ToDouble(valor);
                    valor2[i] = aux;

                }

                for (int p = 0; p < numero_filas; p++)
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

            Int32 numero_filas = dataGridView_tabla.Rows.Count;
            double[] valor2 = new double[numero_filas];
            double sumatotal = 0.0;
            double aux;

            //Vuelvo a aplicar la logica para sumar los precios de los productos 
            //despues de haber aplicado el descuento

            for (int i = 0; i < numero_filas; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < numero_filas; p++)
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

            Int32 numero_filas = dataGridView_tabla.Rows.Count;
            double[] valor2 = new double[numero_filas];
            double totalproductos = 0.0;
            double aux;

            //aplico una logica similar pero esta vez para sumar la cantidad de productos
            //agregados al datagridview

            for (int i = 0; i < numero_filas; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[3].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < numero_filas; p++)
            {
                totalproductos = valor2[p] + totalproductos;
            }

            //instancio y llamo la ventana de pago ademas de compartirle el valor total a pagar 
            // y la suma de la cantidad de productos en el datagridview

            Vpagar ventanapagar = new Vpagar(dt);
            ventanapagar.textBox1.Text = textBox4.Text;
            ventanapagar.Subtotal=  textBox1.Text;
            ventanapagar.Impuesto = textBox2.Text;
            ventanapagar.Descuento = textBox3.Text;
            ventanapagar.Totalpago = textBox4.Text;
            //ventanapagar.textBox2.Text = Convert.ToString(totalproductos);
            ventanapagar.ShowDialog();
           
            //ventanapagar.Show();

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


            //Borro ultima factura

            string borrar_ultima_factura = "delete from tabla_factura";
            clase_escritura consulta = new clase_escritura();
            consulta.escribir(database, borrar_ultima_factura);

            dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Detalle");
            dt.Columns.Add("Valor Unitario");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Valor Total");
            dataGridView_tabla.DataSource = dt;

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
            //Verifico si tengo campos vacios en el datagridview
            if (dataGridView_tabla.Rows.Count == 0)
            {
                MessageBox.Show("No existen campos para imprimir una factura");

            }
            else

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

            }

            string inserta_totales = "insert into tabla_totales(Subtotal,Impuesto,Descuento,Totalpago) values(" + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ") ";
            clase_escritura consulta = new clase_escritura();
            consulta.escribir(database, inserta_totales);

            Vreporte ventanareporte = new Vreporte();
            ventanareporte.Show();


        }

        
    

    private void button_prueba_Click(object sender, EventArgs e)
    {
         
        ////Verifico si tengo campos vacios en el datagridview
        //if (dataGridView_tabla.Rows.Count == 0)
        //{
        //    MessageBox.Show("No existen campos para imprimir una factura");

        //}
        //else

        //{
        //    SqlConnection conexion = new SqlConnection(database);
        //    conexion.Open();
        //    string inserta_producto_vendidos = "insert into tabla_Ventas(id_factura,Codigo,Detalle,ValorUnitario,Cantidad,ValorTotal) values(@id_factura,@Codigo,@Detalle,@ValorUnitario,@Cantidad,@ValorTotal) ";
        //    SqlCommand comando = new SqlCommand(inserta_producto_vendidos, conexion);

        //    foreach (DataGridViewRow row in dataGridView_tabla.Rows)
        //    {
        //        comando.Parameters.Clear();
        //        comando.Parameters.AddWithValue("@id_factura", textBox7.Text);
        //        comando.Parameters.AddWithValue("@Codigo", Convert.ToString(row.Cells["Codigo"].Value));
        //        comando.Parameters.AddWithValue("@Detalle", Convert.ToString(row.Cells["Detalle"].Value));
        //        comando.Parameters.AddWithValue("@ValorUnitario", Convert.ToString(row.Cells["ValorUnitario"].Value));
        //        comando.Parameters.AddWithValue("@Cantidad", Convert.ToString(row.Cells["Cantidad"].Value));
        //        comando.Parameters.AddWithValue("@ValorTotal", Convert.ToString(row.Cells["Valor_Total"].Value));
        //        comando.ExecuteNonQuery();
        //    }
        //    conexion.Close();

        //    string inserta_totales = "insert into tabla_facturas(id_factura,Subtotal,Impuesto,Descuento,Totalpago) values(" + textBox7.Text + "," + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + ") ";
        //    clase_escritura consulta = new clase_escritura();
        //    consulta.escribir(database, inserta_totales);




        //    }
        }                                        


    }
}
