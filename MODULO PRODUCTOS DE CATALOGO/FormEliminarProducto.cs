using DATOS_TSP;
using Menssage_Exception;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    public partial class FormEliminarProducto : Form
    {
        Dato_ts datos = new Dato_ts();
        public FormEliminarProducto()
        {
            InitializeComponent();
        }
        private void limpiarCampo()
        {
            txtId.Text = "";
            txtCantidad.Text = "";
            txtDescripcion.Text = "";
            txtIdP.Text = "";
            txtNombre.Text = "";
            txtNombreP.Text = "";
            txtProveedor.Text = "";
            txtTotal.Text = "";
            TxtPrecio.Text = "";

        }
        /*Metodo de validar el texbox de buscar*/
        public void validacionBuscar()
        {
            var v = !string.IsNullOrEmpty(txtNombre.Text);

            btnBuscar.Enabled = v;

        }
        /*Metodo de validar el texbox de eliminar*/
        public void validacionEliminar()
        {
            var v = !string.IsNullOrEmpty(txtId.Text);

            btnEliminarProducto.Enabled = v;

        }

        private void btnEliminarProducto_Click(object sender, System.EventArgs e)
        {
            /*Control de exepciones */
            try
            {
                /*se llama el metodo con parametro*/
                datos.EliminarProducto(int.Parse(txtId.Text));
                MessageBox.Show("Se ha eliminado correctamente");
                limpiarCampo();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string producto = txtNombre.Text;

            try
            {
                DataTable dato = datos.BuscarDatosProductos(producto);

                if (dato.Rows.Count > 0)
                {
                    txtIdP.Text = dato.Rows[0]["id_producto"].ToString();
                    txtProveedor.Text = dato.Rows[0]["id_proveedor"].ToString();
                    txtNombreP.Text = dato.Rows[0]["nombre_producto"].ToString();
                    txtDescripcion.Text = dato.Rows[0]["descripcion"].ToString();
                    txtCantidad.Text = dato.Rows[0]["cantidad"].ToString();
                    TxtPrecio.Text = dato.Rows[0]["precio"].ToString();
                    txtTotal.Text = dato.Rows[0]["total"].ToString();
                    byte[] datosImagen = (byte[])dato.Rows[0]["imagen"];
                    MemoryStream ms = new MemoryStream(datosImagen);
                    imagen.Image = Image.FromStream(ms);
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

        private void FormEliminarProducto_Load(object sender, EventArgs e)
        {
            /*en el metodo de load desabilitamos el boton de buscar y eliminar */
            btnBuscar.Enabled = false;
            btnEliminarProducto.Enabled = false;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            /*se envia el metodo de validacion */
            validacionBuscar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            /*se envia el metodo de validacion */
            validacionEliminar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
