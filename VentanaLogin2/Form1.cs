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
        string database = "server=DESKTOP-N49DV7A\\SQLEXPRESS;database=dbPOS;integrated security = true";


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

            if (Usuario == "" || Clave == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else 
            {
                //Conexion a la base de datos para traerme el usuario y contraseña con el criterio ingresado desde la base de datos

                SqlConnection conexion = new SqlConnection(database);
                string peticion_lectura_usuario = "select Usuario,Contraseña from tabla_usuarios where Usuario = '" + Usuario + "' ";
                
                clase_lectura leer = new clase_lectura();
                SqlDataReader registros = leer.leer_varios_datos(database, peticion_lectura_usuario);

                //la contraseña ingresada la paso por la funcion hash de sha 1
                string hash_clave_introducida = hash.EncodePassword(Clave);


               while (registros.Read())
               {
                  
                  string usuario_registrado = registros["Usuario"].ToString();
                  string hash_clave_registrada = registros["Contraseña"].ToString();
                             

                
                    //Verificaciòn de el usuario y la contraseña con su hash para mas seguridad

                  if (usuario_registrado == Usuario & hash_clave_introducida == hash_clave_registrada)
                  {
                        MessageBox.Show("Inicio de sesiòn correctamente", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textboxUser.Clear();
                        textboxClave.Clear();
                        this.Hide();
                        Vproducto Ventas_ventana = new Vproducto();
                         Ventas_ventana.Show();
                  }

                    else
                    {
                      MessageBox.Show("Usuario o contraseña incorectos", "Error inicio de sesiòn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textboxUser.Text = "";
                        textboxClave.Text = "";

                    }
               
                }

                registros.Close();
                conexion.Close();
            }
        }
                        
        private void label3_Click(object sender, EventArgs e)
        {
            //Llamo la ventana de crear nuevo usuarios
            Vusuarios ventausuarios = new Vusuarios();
            ventausuarios.Show();
            this.Hide();
        }

        private void Vlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult eleccion = MessageBox.Show("¿Seguro que desea salir?", "Saliendo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if(eleccion == DialogResult.OK)

            {
                Application.Exit();
            }            
        }

       
    }      
    
}
