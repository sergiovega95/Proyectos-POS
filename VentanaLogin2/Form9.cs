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
    public partial class Vlista_facturas : Form
    {
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";

        public Vlista_facturas()
        {
            InitializeComponent();
        }

        private void Vlista_facturas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet4.tabla_facturas' Puede moverla o quitarla según sea necesario.
            this.tabla_facturasTableAdapter.Fill(this.dbPOSDataSet4.tabla_facturas);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            clase_escritura borrar = new clase_escritura();
            string peticion_borrar = "delete from tabla_factura";
            borrar.escribir(database,peticion_borrar);


            int fila_seleccionada = dataGridView_facturas.SelectedRows[0].Index;
            string id_factura_seleccionada = dataGridView_facturas.Rows[fila_seleccionada].Cells[0].Value.ToString();
            //MessageBox.Show(id_factura_seleccionada);
            string peticion_lectura = "select Codigo,Detalle,ValorUnitario,Cantidad,ValorTotal from tabla_ventas where Id_factura = '" + Convert.ToString(id_factura_seleccionada) + "' ";
            clase_lectura leer = new clase_lectura();
            SqlDataReader registros = leer.leer_varios_datos(database, peticion_lectura);
            SqlConnection conexion = new SqlConnection(database);

            while (registros.Read())
            {

                string Codigo1 = registros["Codigo"].ToString();
                string Detalle1 = registros["Detalle"].ToString();
                string ValorUnitario1 = registros["ValorUnitario"].ToString();
                string Cantidad1 = registros["Cantidad"].ToString();
                string ValorTotal1 = registros["ValorTotal"].ToString();

                string inserta_factura = "insert into tabla_factura(Codigo,Detalle,ValorUnitario,Cantidad,ValorTotal) values('" + Codigo1 + "','" + Detalle1 + "','" + ValorUnitario1 + "','" + Cantidad1 + "','" + ValorTotal1 + "') ";
                clase_escritura escritura = new clase_escritura();
                int confirmar = escritura.escribir(database, inserta_factura);
                             

            }
            registros.Close();
            conexion.Close();

            Vfacturas_todas ventanareporte = new Vfacturas_todas();
            ventanareporte.Show();

            
                          

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Este evento me proporciona filtrar en tiempo real las facturas
            //que estan en la base de datos

            string filtro = textBox1.Text;
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_lectura_filtro = "select id_factura,Subtotal,Impuesto,Descuento,Totalpago from tabla_facturas where id_factura like '"+ filtro +"%'";
            SqlCommand comando = new SqlCommand(peticion_lectura_filtro, conexion);
            comando.ExecuteNonQuery();

            //Lleno los datos de el datagridview con los resultados retornados del filtro
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            dataGridView_facturas.DataSource = dt;
            conexion.Close();
        }
    }
}
