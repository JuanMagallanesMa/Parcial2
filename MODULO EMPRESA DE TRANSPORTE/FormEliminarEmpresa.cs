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

/*GRUPO A*/
namespace MODULO_EMPRESA_DE_TRANSPORTE
{
    public partial class FormEliminarEmpresa : Form
    {
        /*Instanciamos la clase con la conexion para hacer uso de los metodos*/
        Dato_ts datos = new Dato_ts();
        public FormEliminarEmpresa()
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
        public void validacionBuscar()
        {
            var v = !string.IsNullOrEmpty(txtCorreoBuscar.Text);

            btnBuscarUsuario.Enabled = v;

        }
        public void validacionEliminar()
        {
            var v = !string.IsNullOrEmpty(txtIngreseId.Text);

            btnEliminarUsuario.Enabled = v;

        }
        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            /*se crea una variable para usarla en la tabla por medio de parametro y en el texbox*/
            string correo = txtCorreoBuscar.Text;
            string tipoUsuario = "Empresa de transporte";
            /*se llama la tabla y pasamos la conexion con el metodo de buscar por correo*/
            try
            {
                DataTable dato = datos.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);

                /*recorremos la tabla hasta encontrar el dato especificado*/
                if (dato.Rows.Count > 0)
                {
                    /*si se cumple la funcion se visualiza en los texbox especificados*/
                    txtId.Text = dato.Rows[0]["id_usuario"].ToString();
                    txtNombre.Text = dato.Rows[0]["nombre_completo"].ToString();
                    TxtUsuario.Text = dato.Rows[0]["usuario"].ToString();
                    txtCorreo.Text = dato.Rows[0]["correo"].ToString();
                    txtConfContrasena.Text = dato.Rows[0]["contrasena"].ToString();
                    TxtTipo.Text = dato.Rows[0]["tipo_usuario"].ToString();
                }
                /*caso contrario se envia un mensaje*/
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

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            /*Control de exepciones */
            try
            {
                /*se llama el metodo con parametro*/
                datos.EliminarUsuario(int.Parse(txtIngreseId.Text));
                MessageBox.Show("Se ha eliminado correctamente");
                limpiaCampo();
            }
            catch (ExcepcionIdNoEncontrado)
            {

                MessageBox.Show("ID no encontrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEliminarEmpresa_Load(object sender, EventArgs e)
        {
            btnBuscarUsuario.Enabled = false;
            btnEliminarUsuario.Enabled = false;
        }

        private void txtCorreoBuscar_TextChanged(object sender, EventArgs e)
        {
            validacionBuscar();
        }

        private void txtIngreseId_TextChanged(object sender, EventArgs e)
        {
            validacionEliminar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
