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
    public partial class Vusuarios : Form
    {
        public Vusuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string usuario = textBox3.Text;
            string contraseña = textBox4.Text;
            string seguridad = textBox5.Text;

            string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            string peticion_escritura_usuario = "insert into tabla_usuarios (Usuario,Contraseña,Nombre,Apellido) values('" + usuario + "','" + contraseña + "','" + nombre + "','" + apellido + "') ";
            SqlCommand comando = new SqlCommand(peticion_escritura_usuario, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se agrego Correctamente el nuevo usuario");
            conexion.Close();

            nombre = "";
            apellido = "";
            usuario = "";
            contraseña = "";
            seguridad = "";


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vlogin ventanalogin = new Vlogin();
            ventanalogin.Show();
            ventanalogin.Close();
            this.Close();

        }

        private void Vusuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Vlogin ventanalogin = new Vlogin();
            ventanalogin.Show();
            
        }
    }
}
