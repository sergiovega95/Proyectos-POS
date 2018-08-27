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
   
    public partial class Vpagar : Form
    {
       // private DataTable dt;
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
        DataTable source = new DataTable();
        public string Subtotal;
        public string Impuesto;
        public string Descuento;
        public string Totalpago;
        //public string actual_id_factura;


        public Vpagar()
        {
            InitializeComponent();                
            textBox3.Text = "0.0";
            textBox4.Text = "0.0";
        }

        public Vpagar(DataTable datasource_Padre)
        {
            InitializeComponent();
            source = datasource_Padre;
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
            foreach (DataRow fila in source.Rows)
            {
                string codigo_producto = fila["Codigo"].ToString();
                string cantidad_productos_vendidos = fila["Cantidad"].ToString();
                //MessageBox.Show(codigo_producto);

                string peticion_stock_actual = "Select Stock from tabla_productos where Codigo=" + codigo_producto + "";

                clase_lectura leer = new clase_lectura();
                string stock_actual = leer.leer_un_dato(database, peticion_stock_actual);

                int stock_nuevo = Convert.ToInt32(stock_actual) - Convert.ToInt32(cantidad_productos_vendidos);

                string peticion_modificar_stock = "update tabla_productos set Stock = " + Convert.ToString(stock_nuevo) + " where Codigo= " + codigo_producto + " ";
                clase_escritura consulta = new clase_escritura();
                int resultado = consulta.escribir(database, peticion_modificar_stock);

            }


            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string inserta_producto_vendidos = "insert into tabla_Ventas(id_factura,Codigo,Detalle,ValorUnitario,Cantidad,ValorTotal) values(@id_factura,@Codigo,@Detalle,@ValorUnitario,@Cantidad,@ValorTotal) ";
            SqlCommand comando = new SqlCommand(inserta_producto_vendidos, conexion);
            Vproducto v = new Vproducto();
            string actual_id_factura = textBox5.Text;

            foreach (DataRow fila in source.Rows)
            {
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id_factura", actual_id_factura);
                comando.Parameters.AddWithValue("@Codigo", fila["Codigo"].ToString());
                comando.Parameters.AddWithValue("@Detalle", fila["Detalle"].ToString());
                comando.Parameters.AddWithValue("@ValorUnitario", fila["Valor Unitario"].ToString());
                comando.Parameters.AddWithValue("@Cantidad", fila["Cantidad"].ToString());
                comando.Parameters.AddWithValue("@ValorTotal", fila["Valor Total"].ToString());
                comando.ExecuteNonQuery();
            }
            conexion.Close();

            //Vproducto venta_producto = new Vproducto();

            string inserta_totales = "insert into tabla_facturas(id_factura,Subtotal,Impuesto,Descuento,Totalpago) values( " + actual_id_factura + " ," + Subtotal + "," + Impuesto + "," + Descuento + "," + Totalpago + ")";
            clase_escritura consulta2 = new clase_escritura();
            consulta2.escribir(database, inserta_totales);

            //int nuevo_id = Convert.ToInt32(actual_id_factura) + 1;


            DialogResult eleccion = MessageBox.Show("Desea Imprimir una factura", "Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (eleccion == DialogResult.Yes)
            {                            
                    SqlConnection conexion3 = new SqlConnection(database);
                    conexion3.Open();
                    string inserta_factura = "insert into tabla_factura(Codigo,Detalle,ValorUnitario,Cantidad,ValorTotal) values(@Codigo,@Detalle,@ValorUnitario,@Cantidad,@ValorTotal) ";
                    SqlCommand comando3 = new SqlCommand(inserta_factura, conexion3);

                foreach (DataRow fila in source.Rows)
                {
                    comando3.Parameters.Clear();
                    comando3.Parameters.AddWithValue("@id_factura", actual_id_factura);
                    comando3.Parameters.AddWithValue("@Codigo", fila["Codigo"].ToString());
                    comando3.Parameters.AddWithValue("@Detalle", fila["Detalle"].ToString());
                    comando3.Parameters.AddWithValue("@ValorUnitario", fila["Valor Unitario"].ToString());
                    comando3.Parameters.AddWithValue("@Cantidad", fila["Cantidad"].ToString());
                    comando3.Parameters.AddWithValue("@ValorTotal", fila["Valor Total"].ToString());
                    comando3.ExecuteNonQuery();
                }
                conexion.Close();

                string inserta_totales2 = "insert into tabla_totales(Subtotal,Impuesto,Descuento,Totalpago) values(" + Subtotal + "," + Impuesto + "," + Descuento + "," + Totalpago + ") ";
                    clase_escritura consulta = new clase_escritura();
                    consulta.escribir(database, inserta_totales2);

                    Vreporte ventanareporte = new Vreporte();
                    ventanareporte.Show();
                    this.Close();

            }                        

            

             else
            {

                this.Close();
            }

            Vproducto ventana = new Vproducto();
            ventana.Hide();
            ventana.Show();
        }

        private void Vpagar_Load(object sender, EventArgs e)
        {
            
        }

        private void Vpagar_FormClosed(object sender, FormClosedEventArgs e)
        {
           


        }

        private void Vpagar_FormClosing(object sender, FormClosingEventArgs e)
        {            
            
        }
    }
}
