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
namespace MODULO_EMPRESA_DE_TRANSPORTE
{
    public partial class FormModificarEmpresa : Form
    {
        /*instanciamos la clase que contiene la conexion  */
        Dato_ts datos = new Dato_ts();
        public FormModificarEmpresa()
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
        /*metodo de validacon de busquedad */
        public void validacionBuscar()
        {
            var v = !string.IsNullOrEmpty(txtCorreoBuscar.Text);

            button2.Enabled = v;

        }
        /*metodo de validacon para modificar */
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
            /*variable para hacer la busquedad */
            string correo = txtCorreoBuscar.Text;
            string tipoUsuario = "Empresa de transporte";
            /*llamamos el metodo de busquedad*/
            datos.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);
            try
            {
                /*lo agregamos a la tabla */
                DataTable dato = datos.BuscarDatosPorCorreoUsuario(correo , tipoUsuario);

                /*recorremos la tabla*/
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
                /*control de excepciones */
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
                /*se llama el metodo para modificar */
                datos.ModificarUsuarios(int.Parse(txtId.Text), txtNombre.Text, TxtUsuario.Text, txtCorreo.Text, txtConfContrasena.Text, TxtTipo.Text);
                MessageBox.Show("El dato del usuario ha sido actualizado correctamente");
                limpiaCampo();
            }
            /*control de excepciones*/
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

        private void FormModificarEmpresa_Load(object sender, EventArgs e)
        {
            /*metodo load desabilitamos el boton el modificar y buscar  */
            btnModificar.Enabled = false;
            button2.Enabled = false;
        }

        private void txtCorreoBuscar_TextChanged(object sender, EventArgs e)
        {
            /*pasamos el metodo de validar en todos los texBox */
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
