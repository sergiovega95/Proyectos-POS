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
    public partial class Form8 : Form
    {
        private DataTable dt;

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
             dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Detalle");
            dt.Columns.Add("ValorUnitario");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Valor_Total");
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = dt.NewRow();
            row["Codigo"] = textBox1.Text;
            row["Detalle"] = textBox2.Text; 
            row["ValorUnitario"] = textBox3.Text;
            row["Cantidad"] = textBox4.Text;
            row["Valor_Total"] = textBox5.Text;
            dt.Rows.Add(row);
            //dataGridView1.DataSource = dt;
        }
    }
}
