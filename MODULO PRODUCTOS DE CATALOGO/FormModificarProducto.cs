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
    public partial class FormModificarProducto : Form
    {
        Dato_ts datos = new Dato_ts();
        public FormModificarProducto()
        {
            InitializeComponent();
            TxtPrecio.TextChanged += CalcularResultado;
            txtCantidad.TextChanged += CalcularResultado;

        }

        private byte[] ImagenProducto()
        {
            MemoryStream ms = new MemoryStream();
            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.GetBuffer();
        }
        public void limpiaCampo()
        {
            txtNombreProducto.Text = "";
            TxtDescripcion.Text = "";
            txtCantidad.Text = "";
            TxtPrecio.Text = "";
            txtTotal.Text = "";
            txtProducto.Text = "";
            txtProveedor.Text = "";
        }
        /*Metodo de validar el texbox de buscar*/
        public void validacionBuscar()
        {
            var v = !string.IsNullOrEmpty(txtBuscar.Text);

            btnBuscar.Enabled = v;

        }
        /*Metodo de validar el texbox de modificar*/
        public void validacionModificar()
        {
            var v = !string.IsNullOrEmpty(txtNombreProducto.Text) &&
                    !string.IsNullOrEmpty(TxtDescripcion.Text) &&
                    !string.IsNullOrEmpty(txtCantidad.Text) &&
                    !string.IsNullOrEmpty(TxtPrecio.Text);
            btnModificarProducto.Enabled = v;

        }
        private void CalcularResultado(object sender, EventArgs e)
        {
            if (float.TryParse(TxtPrecio.Text, out float precio) && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                double resultado = precio * cantidad;
                txtTotal.Text = resultado.ToString();
            }
            else
            {
                txtTotal.Text = "Error";
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string producto = txtBuscar.Text;

            try
            {
                DataTable dato = datos.BuscarDatosProductos(producto);

                if (dato.Rows.Count > 0)
                {
                    txtProducto.Text = dato.Rows[0]["id_producto"].ToString();
                    txtProveedor.Text = dato.Rows[0]["id_proveedor"].ToString();
                    txtNombreProducto.Text = dato.Rows[0]["nombre_producto"].ToString();
                    TxtDescripcion.Text = dato.Rows[0]["descripcion"].ToString();
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

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                datos.ModificarProducto(int.Parse(txtProducto.Text), int.Parse(txtProveedor.Text), txtNombreProducto.Text, TxtDescripcion.Text, int.Parse(txtCantidad.Text), float.Parse(TxtPrecio.Text), float.Parse(txtTotal.Text), ImagenProducto());
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

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();

            ofdSeleccionar.Filter = "“Imagenes|*.jpg; *.png";

            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                imagen.Image = System.Drawing.Image.FromFile(ofdSeleccionar.FileName);

            }
        }

        private void FormModificarProducto_Load(object sender, EventArgs e)
        {
            /* en el metodo load desabilitamos los botones buscar y modificar*/
            btnModificarProducto.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            validacionBuscar();
        }

        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            validacionModificar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
