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
    public partial class Vfacturas_todas : Form
    {
        public Vfacturas_todas()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet1.tabla_factura' Puede moverla o quitarla según sea necesario.
            this.tabla_facturaTableAdapter.Fill(this.dbPOSDataSet1.tabla_factura);
            // TODO: esta línea de código carga datos en la tabla 'dbPOSDataSet2.tabla_totales' Puede moverla o quitarla según sea necesario.
            this.tabla_totalesTableAdapter.Fill(this.dbPOSDataSet2.tabla_totales);

            this.reportViewer1.RefreshReport();
        }
    }
}
