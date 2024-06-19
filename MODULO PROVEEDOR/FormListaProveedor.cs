using DATOS_TSP;
using Menssage_Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PROVEEDOR
{
    public partial class FormListaProveedor : Form
    {
        private DataTable productosDataTable;
        private DataRow selectedDataRow;
        /*Llamamos la clase que tiene la conexion de datos*/
        Dato_ts datos = new Dato_ts();
        public FormListaProveedor()
        {
            InitializeComponent();
        }
        private void ActualizarValorEnBaseDeDatos(int idUsuario, string columna, string nuevoValor)
        {
            try
            {
                using (SqlCommand command = new SqlCommand($"UPDATE usuarios SET {columna} = @NuevoValor WHERE id_usuario = @ID", datos.AbrirConexion()))
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
        private void FormListaProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                dataProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataProveedor.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                /*agregamos nuestro metodo para visualizarlo en el dataGridView*/
                dataProveedor.DataSource = datos.ListaDeUsuariosProveedor();
                dataProveedor.CellEndEdit += dataProveedor_CellEndEdit;

                productosDataTable = datos.ListaDeUsuariosCliente();

                // Configura el DataGridView
                dataProveedor.DataSource = productosDataTable;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /*cierra la ventana*/
            this.Close();
        }

        private void dataProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*seleciona los campos de la tabla*/
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataProveedor.Rows[e.RowIndex];
                DataRowView selectedRowView = (DataRowView)selectedRow.DataBoundItem;
                selectedDataRow = selectedRowView.Row;

                BtnModificar.Enabled = true;
            }
        }

        private void dataProveedor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*seleciona y edita en la tabla*/
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow editedRow = dataProveedor.Rows[e.RowIndex];
                DataGridViewCell editedCell = editedRow.Cells[e.ColumnIndex];

                // Obtiene la columna actual y el nombre de la columna.
                string columnName = dataProveedor.Columns[e.ColumnIndex].Name;

                // Obtiene la clave primaria de la fila.
                int idUsuario = Convert.ToInt32(editedRow.Cells["id_usuario"].Value);

                //  Obtiene el nuevo valor editado por el usuario.
                string newValue = editedCell.Value.ToString();

                // se llama al metodo para para actualizar
                ActualizarValorEnBaseDeDatos(idUsuario, columnName, newValue);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            /*seleciona la tabla y actualiza los datos con el metodo de actualizar */
            if (selectedDataRow != null)
            {
                // Aplicar los cambios a la base de datos.
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "nombre_completo", selectedDataRow["nombre_completo"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "usuario", selectedDataRow["usuario"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "correo", selectedDataRow["correo"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "contrasena", selectedDataRow["contrasena"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "tipo_usuario", selectedDataRow["tipo_usuario"].ToString());

                // Refresca el DataGridView para ver los cambios.
                dataProveedor.DataSource = datos.ListaDeUsuariosProveedor();

                MessageBox.Show("Datos modificados correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de hacer clic en Modificar.");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            /*selecciona y se llama el metodo para eliminar la fila seleccionada*/
            if (selectedDataRow != null)
            {
                int idUsuario = Convert.ToInt32(selectedDataRow["id_usuario"]);

                // Eliminar el usuario de la base de datos.
                datos.EliminarUsuario(idUsuario);

                // Eliminar la fila seleccionada del DataGridView.
                dataProveedor.Rows.Remove(dataProveedor.CurrentRow);

                MessageBox.Show("Usuario eliminado correctamente.");
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
            dv.RowFilter = $"CONVERT(nombre_completo, 'System.String') LIKE '%{searchTerm}%'";

            // Actualiza el origen de datos del DataGridView con los resultados filtrados
            dataProveedor.DataSource = dv;
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "BUSCAR")
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
