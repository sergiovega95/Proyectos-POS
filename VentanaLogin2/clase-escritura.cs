using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VentanaLogin2
{
    class clase_escritura
    {
        // el metodo escribir gestiona la conexion y desconexion con la base de datos
        // cuando se usan sentencias sql de tipo insert,update,delete ya que son sentencias 
        // que la base no retorna datos.

        public int escribir(string database , string query)
        {
            SqlConnection conexion = new SqlConnection(database);
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            int filas_afectadas=comando.ExecuteNonQuery();
            conexion.Close();
            // me retorna la cantidad de filas afectas por lo tanto si es mayor a 0 se ejecuto correctamente
            return (filas_afectadas); 
        }

       




    }
}
