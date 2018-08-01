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
    public partial class Vreporte : Form
    {
        public Vreporte()
        {
            InitializeComponent();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet1.tabla_factura' 
            this.tabla_facturaTableAdapter.Fill(this.dbPOSDataSet1.tabla_factura);
            this.reportViewer1.RefreshReport();
        }

        private void Vreporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string borrar_ultima_factura = "delete from tabla_factura";
            SqlCommand comando2 = new SqlCommand(borrar_ultima_factura, conexion);
            comando2.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
