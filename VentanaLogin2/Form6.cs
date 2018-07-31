using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet1.tabla_factura' Puede moverla o quitarla según sea necesario.
            this.tabla_facturaTableAdapter.Fill(this.dbPOSDataSet1.tabla_factura);

            this.reportViewer1.RefreshReport();
        }
    }
}
