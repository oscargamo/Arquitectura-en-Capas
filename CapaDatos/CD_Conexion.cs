using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion
    {
        // Estados - Atributos
        private SqlConnection Conexion = new SqlConnection(@"Data Source = DESKTOP-E508I4F\SQLEXPRESS; Initial Catalog = Practica; User = sa; Password = 12345;");
        
        // Comportamiento - Metodos

        // Verificamos si la conexion a la base de datos esta cerrada, entonces lo abrimos
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
            return Conexion;
        }

        // Verificamos si la conexion a la base de datos esta abierta, entonces la cerramos
        public SqlConnection ClosedConexion()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
            return Conexion;

        }


    }
}
