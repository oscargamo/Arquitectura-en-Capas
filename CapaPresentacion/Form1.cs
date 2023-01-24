using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        // Estados - Atributos
        // Invocamos las referencias de las capas
        CN_Productos objectoCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        // Comportamientos - Metodos
        public void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Insertar
            if (Editar == false)
            {
                try
                {
                    objectoCN.InsertarProd(TxtNombre.Text, TxtDescrip.Text, TxtMarca.Text, TxtPrecio.Text, TxtStock.Text);
                    MessageBox.Show("Se Guardo Correctamente");
                    MostrarProductos();
                    LimpiarForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede insertar los datos porque uno o varios campos estan vacios: ", "Atencion", MessageBoxButtons.OK);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objectoCN.EditarProd(TxtNombre.Text, TxtDescrip.Text, TxtMarca.Text, TxtPrecio.Text, TxtStock.Text, idProducto);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    LimpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por:" + ex);
                }
            }

        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                TxtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                TxtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                TxtDescrip.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                TxtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                TxtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecciona una fila por favor");
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objectoCN.EliminarProd(idProducto);
                MessageBox.Show("Se elimino el producto");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Selecciona una fila por favor");
            }
        }

        // Limpiamos los textBox
        private void LimpiarForm()
        {
            TxtNombre.Clear();
            TxtMarca.Clear();
            TxtDescrip.Clear();
            TxtPrecio.Clear();
            TxtStock.Text = "";
        }
        // Verificamos que los textbox no esten vacios
        private void CamposVacios()
        {
            if (TxtNombre.Text == " " || TxtPrecio.Text == " ")
            {
                MessageBox.Show("Algunos de los campos esta vacio: ");
            }
        }

    }
}
