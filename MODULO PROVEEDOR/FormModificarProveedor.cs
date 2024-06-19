using DATOS_TSP;
using Menssage_Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PROVEEDOR
{
    public partial class FormModificarProveedor : Form
    {
        /*llamamos la conexion de nuestro servidor*/
        Dato_ts datos = new Dato_ts();
        public FormModificarProveedor()
        {
            InitializeComponent();
        }
        public void limpiaCampo()
        {
            txtCorreoBuscar.Text = "";
            txtCorreo.Text = "";
            txtNombre.Text = "";
            TxtUsuario.Text = "";
            txtId.Text = "";
            txtConfContrasena.Text = "";
            TxtTipo.Text = "";
        }

        /*Metodo de validar el texbox de buscar*/
        public void validacionBuscar()
        {
            var v = !string.IsNullOrEmpty(txtCorreoBuscar.Text);

            button2.Enabled = v;

        }
        /*Metodo de validar el texbox de modificar*/
        public void validacionModificar()
        {
            var v = !string.IsNullOrEmpty(txtNombre.Text) &&
                    !string.IsNullOrEmpty(TxtUsuario.Text) &&
                    !string.IsNullOrEmpty(txtCorreo.Text) &&
                    !string.IsNullOrEmpty(txtConfContrasena.Text);
            btnModificar.Enabled = v;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            string correo = txtCorreoBuscar.Text;
            string tipoUsuario = "Proveedor";
            /*Llamamos el metodo de buscar por correo*/
            datos.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);
            try
            {
                DataTable dato = datos.BuscarDatosPorCorreoUsuario(correo , tipoUsuario);

                /*recorre la tabla buscando el dato ingresado */
                if (dato.Rows.Count > 0)
                {

                    txtId.Text = dato.Rows[0]["id_usuario"].ToString();
                    txtNombre.Text = dato.Rows[0]["nombre_completo"].ToString();
                    TxtUsuario.Text = dato.Rows[0]["usuario"].ToString();
                    txtCorreo.Text = dato.Rows[0]["correo"].ToString();
                    txtConfContrasena.Text = dato.Rows[0]["contrasena"].ToString();
                    TxtTipo.Text = dato.Rows[0]["tipo_usuario"].ToString();
                }
                else
                {

                    throw new ExcepcionDatosNoEncontrados("Datos no encontrados");
                }
                /*Control de excepciones*/
            }
            catch (ExcepcionDatosNoEncontrados ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                /*llamamos el metodo de la clase de datos_tsp*/
                datos.ModificarUsuarios(int.Parse(txtId.Text), txtNombre.Text, TxtUsuario.Text, txtCorreo.Text, txtConfContrasena.Text, TxtTipo.Text);
                MessageBox.Show("El dato del usuario ha sido actualizado correctamente");
                limpiaCampo();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese los datos correctamente ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormModificarProveedor_Load(object sender, EventArgs e)
        {
            /* en el metodo load desabilitamos los botones buscar y modificar*/
            btnModificar.Enabled = false;
            button2.Enabled = false;
        }

        private void txtCorreoBuscar_TextChanged(object sender, EventArgs e)
        {
            validacionBuscar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void txtConfContrasena_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
