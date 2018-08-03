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
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";

        public Vusuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Asigno nombres a las cajas de texto

            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string usuario = textBox3.Text;
            string contraseña = textBox4.Text;
            string seguridad = textBox5.Text;

            
            //Verifico que no existen espacios vacios ya que la base de datos no me permite registros NULL

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Conexion y peticiòn de escritura a la base de datos , con los datos de un nuevo usuario
            string peticion_escritura_usuario = "insert into tabla_usuarios (Usuario,Contraseña,Seguridad,Nombre,Apellido) values('" + usuario + "','" + contraseña + "','" + seguridad + "','" + nombre + "','" + apellido + "') ";
            clase_escritura consulta = new clase_escritura();
            int resultado = consulta.escribir(database, peticion_escritura_usuario);

            if (resultado>0)
            {
                //Mensaje para mostrar al usuario Limpio para agregar un nuevo usuario
                MessageBox.Show("Se agrego Correctamente el nuevo usuario");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //muestro la ventana de login y cierro la de agregar usuario

            Vlogin ventanalogin = new Vlogin();
            ventanalogin.Show();
            ventanalogin.Close();
            this.Close();

        }

        private void Vusuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
          //muestro la ventana de login y cierro la de agregar usuario pero con el boton de cerrar del form
            Vlogin ventanalogin = new Vlogin();
            ventanalogin.Show();
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Restringir el ingreso de numeros en el apartado nombre

            if (char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("No se permite numero en el apartado de nombres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Restringir el ingreso de numeros en el apartado apellido

            if (char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("No se permite numero en el apartado de apellidos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
