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
    public partial class Vlistaproductos : Form
    {
        public Vlistaproductos()
        {
            InitializeComponent();
        }

        private void Vlistaproductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet.tabla_productos' Puede moverla o quitarla según sea necesario.
            this.tabla_productosTableAdapter.Fill(this.dbPOSDataSet.tabla_productos);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {



        }
    }
}
