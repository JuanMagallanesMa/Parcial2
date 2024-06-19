using DATOS_TSP;
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
namespace MODULO_EMPRESA_DE_TRANSPORTE
{
    public partial class FormListaEmpresa : Form
    {
        private DataTable productosDataTable;
        private DataRow selectedDataRow;
        /*instanciamos la clase con la conexion */
        Dato_ts datos = new Dato_ts();
        public FormListaEmpresa()
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar en la base de datos: {ex.Message}");
            }
        }

        private void FormListaEmpresa_Load(object sender, EventArgs e)
        {
            try
            {
                dataEmpresa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataEmpresa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataEmpresa.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                /*agregamos nuestro metodo para visualizarlo en el dataGridView*/
                dataEmpresa.DataSource = datos.ListaDeUsuariosEmpresa();

                dataEmpresa.CellEndEdit += dataEmpresa_CellEndEdit;
                productosDataTable = datos.ListaDeUsuariosEmpresa();

                // Configura el DataGridView
                dataEmpresa.DataSource = productosDataTable;
            }
            /*excepciones controladas*/
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataEmpresa_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow editedRow = dataEmpresa.Rows[e.RowIndex];
                DataGridViewCell editedCell = editedRow.Cells[e.ColumnIndex];

                // Obtiene la columna actual y el nombre de la columna.
                string columnName = dataEmpresa.Columns[e.ColumnIndex].Name;

                // Obtiene la clave primaria de la fila.
                int idUsuario = Convert.ToInt32(editedRow.Cells["id_usuario"].Value);

                // Obtiene el nuevo valor editado por el usuario.
                string newValue = editedCell.Value.ToString();

                // Realiza la actualización en la base de datos.
                ActualizarValorEnBaseDeDatos(idUsuario, columnName, newValue);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (selectedDataRow != null)
            {
                // Aplica los cambios a la base de datos.
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "nombre_completo", selectedDataRow["nombre_completo"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "usuario", selectedDataRow["usuario"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "correo", selectedDataRow["correo"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "contrasena", selectedDataRow["contrasena"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "tipo_usuario", selectedDataRow["tipo_usuario"].ToString());

                // Refresca el DataGridView para ver los cambios.
                dataEmpresa.DataSource = datos.ListaDeUsuariosEmpresa();

                MessageBox.Show("Datos modificados correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de hacer clic en Modificar.");
            }
        }

        private void dataEmpresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataEmpresa.Rows[e.RowIndex];
                DataRowView selectedRowView = (DataRowView)selectedRow.DataBoundItem;
                selectedDataRow = selectedRowView.Row;

                BtnModificar.Enabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedDataRow != null)
            {
                int idUsuario = Convert.ToInt32(selectedDataRow["id_usuario"]);

                // Eliminar el usuario de la base de datos.
                datos.EliminarUsuario(idUsuario);

                // Eliminar la fila seleccionada del DataGridView.
                dataEmpresa.Rows.Remove(dataEmpresa.CurrentRow);

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
            dataEmpresa.DataSource = dv;
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
