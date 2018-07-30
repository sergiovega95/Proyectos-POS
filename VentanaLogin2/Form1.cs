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
    public partial class Vlogin : Form
    {
        public Vlogin()
        {
            InitializeComponent();

           
        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            //definición de las texbox para el usuario y clave

            string Usuario,Clave;
            Usuario=textboxUser.Text;
            Clave = textboxClave.Text;

            //Logica para comprobar si tengo los campos de usuario y contraseña
            //vacios o si el usuario y la contraseña son incorrectos

            /*if (Usuario == "" || Clave == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (Usuario == "admin" & Clave == "1234")
            {
                MessageBox.Show("Inicio Sesión Correctamente");
                textboxUser.Clear();
                textboxClave.Clear();
                this.Hide();

                Vproducto Ventas_ventana = new Vproducto();
                Ventas_ventana.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrectos");
                textboxUser.Clear();
                textboxClave.Clear();

            }
            */


            if (Usuario == "" || Clave == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else 
            {

                string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";
                SqlConnection conexion = new SqlConnection(database);
                string peticion_lectura_usuario = "select Usuario,Contraseña from tabla_usuarios where Usuario = '" + Usuario + "' ";
                conexion.Open();
                SqlCommand comando = new SqlCommand(peticion_lectura_usuario, conexion);                                             
                SqlDataReader registros = comando.ExecuteReader();
                 
               while (registros.Read())
               {
                     string usuario_registrado = registros["Usuario"].ToString();
                     string clave_registrada = registros["Contraseña"].ToString();
                        
                  if(usuario_registrado==Usuario & clave_registrada==Clave)
                  {
                    MessageBox.Show("Inicio Sesión Correctamente");
                    textboxUser.Clear();
                    textboxClave.Clear();
                    this.Hide();
                    Vproducto Ventas_ventana = new Vproducto();
                    Ventas_ventana.Show();
                    
                  }
                    
               }
                registros.Close();
                conexion.Close();



            }
        }

                
        private void label3_Click(object sender, EventArgs e)
        {
            Vusuarios ventausuarios = new Vusuarios();
            ventausuarios.Show();
            this.Hide();
        }
    }

        
    
}
