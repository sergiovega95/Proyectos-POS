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
    public partial class Vproducto : Form
    {
        //Definición de las variables globales que deseo que conozcan todo el form

        string precio;
        double valortotal;
        double impuesto=0.19;
        public double descuento = 0.0;
        public double sumatotal = 0.0;
        
        
        public Vproducto()
        {
            InitializeComponent();

            //Inicializacion del Timer que me permite mostrar la hora y fecha
            timer1.Enabled = true;
            textBox3.Text = "0";
                           

         }

        private void button6_Click(object sender, EventArgs e)
        {


            descuento = (Convert.ToDouble(textBox3.Text)) / 100;


            //Verificación si los espacios de codigo y cantidad estaban vacios

            if (textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Tiene campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //instanciación de la datagridwiew para crear filas

            DataGridViewRow fila = new DataGridViewRow();
            dataGridView_tabla.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            double aux2 , aux3;

            aux2 = Convert.ToDouble(textBox6.Text);
            aux3 = Convert.ToDouble(precio);
            valortotal = aux2*aux3;

            //Agrego los datos a la datagridview

            fila.CreateCells(dataGridView_tabla);
            fila.Cells[0].Value = textBox5.Text;
            fila.Cells[1].Value = comboBox1.Text;
            fila.Cells[2].Value = precio;
            fila.Cells[3].Value = textBox6.Text;
            fila.Cells[4].Value = Convert.ToString(valortotal);

            dataGridView_tabla.Rows.Add(fila);

            //Refresco las textbox para ingresar nuevo datos

            textBox5.Clear();
            textBox6.Clear(); 
            comboBox1.Text = "";



            //Logica para mostrar la sumatotal del precio de los productos

            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double sumatotal = 0.0;
            double aux;

            for (int i = 0; i <index; i++)
            {
                
                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index ; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }
        

            
            //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs                       

            textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
            textBox2.Text = Convert.ToString(sumatotal * impuesto);
            textBox4.Text = Convert.ToString((sumatotal-(sumatotal*descuento)));
            label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //muestro la Hora del sistema en un simple label


            Hora.Text = DateTime.Now.ToString("G");
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_cocacola_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes     

            textBox5.Text = "001";
            textBox6.Text = "1";
            comboBox1.Text = "Coca Cola 250 ml";
            precio = "1800";
                     


        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Limpio todos los campos del form , tanto los textbox como la datagridview

            dataGridView_tabla.Rows.Clear();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            label25.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text ="";

            agregarform2.Enabled = true;
            borrarform2.Enabled = true;


        }

        private void pictureBox_aguila_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "002";
            textBox6.Text = "1";
            comboBox1.Text = "Cerveza Aguila 250 ml";
            precio = "2000";


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "003";
            textBox6.Text = "1";
            comboBox1.Text = "Pepsi 250 ml";
            precio = "1500";

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "004";
            textBox6.Text = "1";
            comboBox1.Text = "Agua Cristal 450 ml";
            precio = "1200";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {   
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "005";
            textBox6.Text = "1";
            comboBox1.Text = "Leche Freskaleche 1000 ml";
            precio = "2600";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {   
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes
            textBox5.Text = "006";
            textBox6.Text = "1";
            comboBox1.Text = "Aceite de Girasol 1000 ml";
            precio = "4500";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "007";
            textBox6.Text = "1";
            comboBox1.Text = "Pan Tajado Bimbo";
            precio = "3000";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "008";
            textBox6.Text = "1";
            comboBox1.Text = "Pastas la muñeca 250 gr";
            precio = "1600";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {   //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "009";
            textBox6.Text = "1";
            comboBox1.Text = "Huevo Kikes ";
            precio = "300";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {   
            //Definición del codigo , cantidad , precio y descripcion del producto del area frecuentes

            textBox5.Text = "009";
            textBox6.Text = "1";
            comboBox1.Text = "Chocolatina Jet pequeña";
            precio = "500";
        }

        private void button8_Click(object sender, EventArgs e)
        {

            descuento = (Convert.ToDouble(textBox3.Text)) / 100;
            DataGridViewRow fila = new DataGridViewRow();
            int actualindex;
            actualindex = dataGridView_tabla.SelectedRows[0].Index;
            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double sumatotal = 0.0;
            double aux;

                      
                                           
            dataGridView_tabla.Rows.RemoveAt(actualindex); //Remuevo la fila seleccionada del datagridview


            //Misma logica para volver a calcular la suma del precio total de todos los productos
            //despues de haber borrado y/o eliminado alguno
            
            for (int i = 0; i < index; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }


            //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs    

            textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
            textBox2.Text = Convert.ToString(sumatotal * impuesto);
            textBox4.Text = Convert.ToString((sumatotal - (sumatotal * descuento)));
            label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));

                    

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Aplico el descuento ingresado

            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double sumatotal = 0.0;
            double aux;

            //Vuelvo a aplicar la logica para sumar los precios de los productos 
            //despues de haber aplicado el descuento

            for (int i = 0; i < index; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[4].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index; p++)
            {
                sumatotal = valor2[p] + sumatotal;
            }

            //Visualización de el subtotal , el impuesto y el total a pagar en los textboxs    

            descuento = (Convert.ToDouble(textBox3.Text)) / 100;
            textBox1.Text = Convert.ToString(sumatotal - (sumatotal * impuesto));
            textBox2.Text = Convert.ToString(sumatotal * impuesto);
            textBox4.Text = Convert.ToString((sumatotal - (sumatotal * descuento)));
            label25.Text = Convert.ToString("$ " + (sumatotal - (sumatotal * descuento)));

        }

        private void button5_Click(object sender, EventArgs e)
        {

                                
            Int32 index = dataGridView_tabla.Rows.Count - 1;
            double[] valor2 = new double[index];
            double totalproductos = 0.0;
            double aux;

            //aplico una logica similar pero esta vez para sumar la cantidad de productos
            //agregados al datagridview

            for (int i = 0; i < index; i++)
            {

                string valor = (string)dataGridView_tabla.Rows[i].Cells[3].Value;
                aux = Convert.ToDouble(valor);
                valor2[i] = aux;

            }

            for (int p = 0; p < index; p++)
            {
                totalproductos = valor2[p] + totalproductos;
            }

            //instancio y llamo la ventana de pago ademas de compartirle el valor total a pagar 
            // y la suma de la cantidad de productos en el datagridview

            Vpagar ventanapagar = new Vpagar();
            ventanapagar.textBox1.Text =textBox4.Text ;
            ventanapagar.textBox2.Text = Convert.ToString(totalproductos);
            ventanapagar.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //instancio y llamo la ventana para agregar un nuevo producto al inventario

            Vnuevoproducto ventananuevoproducto = new Vnuevoproducto();
            ventananuevoproducto.Show();
            this.Close();
                       
        }

        private void nuevaventaform2_Click(object sender, EventArgs e)
        {
            agregarform2.Enabled = true;
            borrarform2.Enabled = true;
            limpiarform2.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;

            dataGridView_tabla.Rows.Clear();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
            label25.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            }
    }
}
