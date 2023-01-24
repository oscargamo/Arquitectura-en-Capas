using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        // Estados - Atributos
        // -- Establecemos la CapaProducotos de la capa de datos
        private CD_Productos objetoCD =  new CD_Productos();


        // Comportamientos - Metodos

        // Metodo para mostrar todos los productos en una tabla
        public DataTable MostrarProd() 
        { 
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        // Metodo para insertar en la base de datos 
        public void InsertarProd(string nombre, string desc, string marca, string precio, string stock)
        {
            objetoCD.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }
        // Metodo para Editar Producto 
        public void EditarProd(string nombre, string desc, string marca, string precio, string stock, string Id)
        {
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(Id));
        }
        // Metodo para eliminar el producto seleccionado 
        public void EliminarProd(string Id)
        {
            objetoCD.Eliminar(Convert.ToInt32(Id));
        }
        
    }
}
