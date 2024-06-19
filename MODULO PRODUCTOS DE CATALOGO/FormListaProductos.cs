using DATOS_TSP;
using Menssage_Exception;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    public partial class FormListaProductos : Form
    {
        private DataTable productosDataTable;
        private DataRow selectedDataRow;
        /*Llamamos la clase que tiene la conexion de datos*/
        Dato_ts datos = new Dato_ts();
        public FormListaProductos()
        {
            InitializeComponent();
        }
      
        private void ActualizarValorEnBaseDeDatos(int idUsuario, string columna, string nuevoValor)
        {
            try
            {
                using (SqlCommand command = new SqlCommand($"UPDATE productos SET {columna} = @NuevoValor WHERE id_producto = @ID", datos.AbrirConexion()))
                {
                    command.Parameters.AddWithValue("@NuevoValor", nuevoValor);
                    command.Parameters.AddWithValue("@ID", idUsuario);

                    datos.AbrirConexion();
                    command.ExecuteNonQuery();
                }
            }
            catch (ExcepcionActualizarValorEnBaseDeDatos ex)
            {
                MessageBox.Show($"Error al actualizar en la base de datos: {ex.Message}");
            }
        }

        private void FormListaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                dataProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataProducto.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                /*agregamos nuestro metodo para visualizarlo en el dataGridView*/
                dataProducto.DataSource = datos.ListaDeProductos();
                dataProducto.CellEndEdit += dataProducto_CellEndEdit;
                productosDataTable = datos.ListaDeProductos();

                // Configura el DataGridView
                dataProducto.DataSource = productosDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /*cierra ventana */
            this.Close();
        }

        private void dataProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*seleciona los campos de la tabla*/
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataProducto.Rows[e.RowIndex];
                DataRowView selectedRowView = (DataRowView)selectedRow.DataBoundItem;
                selectedDataRow = selectedRowView.Row;

                BtnModificar.Enabled = true;
            }
        }

        private void dataProducto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*seleciona y edita en la tabla*/
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow editedRow = dataProducto.Rows[e.RowIndex];
                DataGridViewCell editedCell = editedRow.Cells[e.ColumnIndex];

                // Obtiene la columna actual y el nombre de la columna.
                string columnName = dataProducto.Columns[e.ColumnIndex].Name;

                // Obtiene la clave primaria de la fila.
                int idUsuario = Convert.ToInt32(editedRow.Cells["id_producto"].Value);

                // Obtiene el nuevo valor editado por el usuario.
                string newValue = editedCell.Value.ToString();

                // se llama al metodo para para actualizar
                ActualizarValorEnBaseDeDatos(idUsuario, columnName, newValue);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificado correctamente");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            /*selecciona y se llama el metodo para eliminar la fila seleccionada*/
            if (selectedDataRow != null)
            {
                int idProducto = Convert.ToInt32(selectedDataRow["id_producto"]);

                try
                {
                    datos.EliminarProducto(idProducto);
                    // Si llega hasta aquí sin excepciones, elimina la fila del DataGridView
                    dataProducto.Rows.Remove(dataProducto.CurrentRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de hacer clic en Eliminar.");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBuscar.Text.ToLower();

            // Filtra los resultados en base al término de búsqueda
            DataView dv = new DataView(productosDataTable);

            // Utiliza el RowFilter para filtrar por nombre_producto
            dv.RowFilter = $"CONVERT(nombre_producto, 'System.String') LIKE '%{searchTerm}%'";

            // Actualiza el origen de datos del DataGridView con los resultados filtrados
            dataProducto.DataSource = dv;

        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if(txtBuscar.Text == "BUSCAR")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
         
      
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "" && !txtBuscar.Focused)
            {
                txtBuscar.Text = "BUSCAR";
                txtBuscar.ForeColor = Color.DarkGray;
            }
        }
    }
}
