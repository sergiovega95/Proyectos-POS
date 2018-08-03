using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VentanaLogin2
{
    class clase_lectura
    {
        public string leer_un_dato(string database, string query)
        {
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            string registro = comando.ExecuteScalar().ToString();
            conexion.Close();
            return (registro);
            
        }


        public int verificar_existencia(string database, string query)
        {
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            int confirmacion = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();
            return (confirmacion);


        }

        public SqlDataReader leer_varios_datos(string database, string query)
        {
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            //conexion.Close();
            return (registros);

        }




    }
}
