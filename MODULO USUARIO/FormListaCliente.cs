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
namespace MODULO_USUARIO
{
    public partial class FormListaCliente : Form
    {
        private DataTable productosDataTable;
        private DataRow selectedDataRow;
        /*instanciamos la clase de conexion*/
        Dato_ts datos = new Dato_ts();
        public FormListaCliente()
        {
            InitializeComponent();
        }
        /*metodo que actualiza los datos en la tabla y en la base de datos*/
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
            catch (ExcepcionActualizaTabla ex)
            {
                MessageBox.Show($"Error al actualizar en la base de datos: {ex.Message}");
            }
        }
        private void FormListaCliente_Load(object sender, EventArgs e)
        {
            try
            {
                dataCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataCliente.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                /*agregamos nuestro metodo para visualizarlo en el dataGridView*/
                dataCliente.DataSource = datos.ListaDeUsuariosCliente();
                /*concatenamos el evento de la tabla que edita*/
                dataCliente.CellEndEdit += dataCliente_CellEndEdit;
                productosDataTable = datos.ListaDeUsuariosCliente();

                // Configura el DataGridView
                dataCliente.DataSource = productosDataTable;

            }
            /*excepciones controladas*/
            catch (ExcepcionActualizaTabla ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            /*cierra ventana*/
            this.Close();
        }
        /*boton para modificar*/
        private void BtnModificar_Click(object sender, EventArgs e)
        {

            /*seleccionamos la fila */
            if (selectedDataRow != null)
            {
                // aplicamos los cambios con el metodo.
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "nombre_completo", selectedDataRow["nombre_completo"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "usuario", selectedDataRow["usuario"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "correo", selectedDataRow["correo"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "contrasena", selectedDataRow["contrasena"].ToString());
                ActualizarValorEnBaseDeDatos(Convert.ToInt32(selectedDataRow["id_usuario"]), "tipo_usuario", selectedDataRow["tipo_usuario"].ToString());
                // Refrescar el DataGridView para ver los cambios.
                dataCliente.DataSource = datos.ListaDeUsuariosCliente();
                /*se envia un mensaje que se realizo el proceso*/
                MessageBox.Show("Datos modificados correctamente.");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de hacer clic en Modificar.");
            }
        }

        /*evento que edita la tabla*/
        private void dataCliente_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*cuenta los daros en la tabla y si esta seleccionado*/
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow editedRow = dataCliente.Rows[e.RowIndex];
                DataGridViewCell editedCell = editedRow.Cells[e.ColumnIndex];                
                string columnName = dataCliente.Columns[e.ColumnIndex].Name;
                // Obtener la clave primaria de la fila.
                int idUsuario = Convert.ToInt32(editedRow.Cells["id_usuario"].Value);
                // Obtener el nuevo valor editado por el usuario.
                string newValue = editedCell.Value.ToString();
                // Realizar la actualización en la base de datos.
                ActualizarValorEnBaseDeDatos(idUsuario, columnName, newValue);
            }
        }

        private void dataCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*seleccionamos los datos en la tabla*/
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataCliente.Rows[e.RowIndex];
                DataRowView selectedRowView = (DataRowView)selectedRow.DataBoundItem;
                selectedDataRow = selectedRowView.Row;
                BtnModificar.Enabled = true;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            /*selecionamos los datos de la tabla para poderlos eliminar*/
            if (selectedDataRow != null)
            {
                int idUsuario = Convert.ToInt32(selectedDataRow["id_usuario"]);
                //se llama el metodo de elimar usuario
                datos.EliminarUsuario(idUsuario);
                // Eliminar la fila seleccionada del DataGridView.
                dataCliente.Rows.Remove(dataCliente.CurrentRow);
                //envia mensaje si esta correcto
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
            dataCliente.DataSource = dv;
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
