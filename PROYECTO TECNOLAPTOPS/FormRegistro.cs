using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATOS_TSP;
using Menssage_Exception;
using PROYECTO_TECNOLAPTOPS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/*GRUPO A*/
namespace PROYECTO_TECNOLAPTOPS
{
    public partial class FormRegistro : Form
    {
        /* Instanciamos la clase que esta enlazada a la base de datos*/
        Dato_ts datos = new Dato_ts();

        public FormRegistro()
        {
            InitializeComponent();
        }
        /*metodo que limpia los campos*/
        public void limpiaCampo()
        {
            txtContraseña.Text = "";
            txtCorreo.Text = "";
            txtNombre.Text = "";
            txtNombreUsuario.Text = "";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            /* Llamamos el metodo para insertar al usuario y pasamos su respectivos parametros*/
            try
            {
                    tipo_usuario();
                    datos.InsertarUsuarios(txtNombre.Text, txtNombreUsuario.Text, txtCorreo.Text, txtContraseña.Text, lblUsuarioTipo.Text);
                    MessageBox.Show("Se ha insertado correctamente los datos");
                    limpiaCampo();
                }
                catch (ExcepcionIngreseDatos)
                {
                    MessageBox.Show("Ingrese datos para registrar");
                }
        }
        /* Metodo para la seleccion de tipo de usuario del radio button*/
        private void tipo_usuario()
        {
            string tipo_usuario = "";
            if (cmbTipoUsuario.SelectedIndex == 0)
            {
                tipo_usuario = "Cliente";
                // MessageBox.Show(tipo_usuario.ToString());
            }
            if (cmbTipoUsuario.SelectedIndex == 1)
            {
                tipo_usuario = "Proveedor";
                // MessageBox.Show(tipo_usuario.ToString());
            }
            if (cmbTipoUsuario.SelectedIndex == 2)
            {
                tipo_usuario = "Empresa de transporte";
                //MessageBox.Show(tipo_usuario.ToString());
            }
            if (cmbTipoUsuario.SelectedIndex == 3)
            {
                tipo_usuario = "Administrador";
                //MessageBox.Show(tipo_usuario.ToString());
            }

            lblUsuarioTipo.Text = tipo_usuario.ToString();

        }
        /*Validar Texbox*/
        public void validacion()
        {
            var v = !string.IsNullOrEmpty(txtNombre.Text) &&
                    !string.IsNullOrEmpty(txtNombreUsuario.Text) &&
                    !string.IsNullOrEmpty(txtCorreo.Text) &&
                    !string.IsNullOrEmpty(txtContraseña.Text);
            button1.Enabled = v;
        }

        /* en el metodo load inabilitamos el boton de registro*/
        private void FormRegistro_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            /* Pasamos el metodo de validacion de texbox*/
            validacion();
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio();
            inicio.Show();

        }
    }
}
