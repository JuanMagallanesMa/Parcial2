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
using Menssage_Exception;

/*GRUPO A*/
namespace MODULO_USUARIO
{
    public partial class FormModificarUsuario : Form
    {
        /*instanciamos la clase de conexion*/
        Dato_ts datos = new Dato_ts();
        public FormModificarUsuario()
        {
            InitializeComponent();
        }

        /*metodo de limpiar campos*/
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
        /*metodo para validar el txt de correo*/
        public void validacionBuscar()
        {
            var v = !string.IsNullOrEmpty(txtCorreoBuscar.Text);

            button2.Enabled = v;
        }
        /*metodo de validacion*/
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
            /*buscamos por correo y el tipo de usuario */
            string correo = txtCorreoBuscar.Text;
            string tipoUsuario = "Cliente";
            /*pasamos el metodo de buscar*/
            datos.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);
            try
            {
                DataTable dato = datos.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);
                /*seleccionamos las filas */
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
                /*pasamos el metodo y ingresamos los txt*/
                datos.ModificarUsuarios(int.Parse(txtId.Text), txtNombre.Text,TxtUsuario.Text, txtCorreo.Text, txtConfContrasena.Text, TxtTipo.Text);
                MessageBox.Show("El dato del usuario ha sido actualizado correctamente");
                /*metodo de limpiar datos*/
                limpiaCampo();
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese los datos correctamente ");
            }
            catch (ExcepcionModificarUsuario ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormModificarUsuario_Load(object sender, EventArgs e)
        {
            /*desactivamos los botones*/
            btnModificar.Enabled = false;
            button2.Enabled = false;
        }
        /*pasamos las validaciones por los txt*/
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
