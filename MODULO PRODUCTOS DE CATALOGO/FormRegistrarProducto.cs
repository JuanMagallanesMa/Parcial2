using DATOS_TSP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    public partial class FormRegistrarProducto : Form
    {
        /* Instanciamos la clase que esta enlazada a la base de datos*/
        Dato_ts datos = new Dato_ts();
        string nombreCompletoProveedor;
        public FormRegistrarProducto()
        {
            InitializeComponent();
            TxtPrecio.TextChanged += CalcularResultado;
            txtCantidad.TextChanged += CalcularResultado;
        }

        private void CargarProveedores()
        {
            comboProveedor.Items.Clear();

            List<string> proveedores = datos.ObtenerListaProveedores();

            comboProveedor.Items.AddRange(proveedores.ToArray());

            if (comboProveedor.Items.Count > 0)
            {
                comboProveedor.SelectedIndex = 0;
            }
        }

        private byte[] ImagenProducto()
        {
            MemoryStream ms = new MemoryStream();
            imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.GetBuffer();
        }
        public void limpiaCampo()
        {
            TxtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtNombre.Text = "";
            TxtPrecio.Text = "";
            lblTotal.Text = "";
        }
        /*Validar Texbox*/
        public void validacion()
        {
            var v = !string.IsNullOrEmpty(txtNombre.Text) &&
                    !string.IsNullOrEmpty(TxtDescripcion.Text) &&
                    !string.IsNullOrEmpty(txtCantidad.Text) &&
                    !string.IsNullOrEmpty(TxtPrecio.Text);     
            btnRegistrarProductos.Enabled = v;
        }
        private void btnRegistrarProductos_Click(object sender, EventArgs e)
        {
            datos.InsertarProducto(comboProveedor.Text, txtNombre.Text, TxtDescripcion.Text, int.Parse(txtCantidad.Text), float.Parse(TxtPrecio.Text), float.Parse(lblTotal.Text), ImagenProducto(), out nombreCompletoProveedor);
            MessageBox.Show("Se ha insertado correctamente los datos");
            limpiaCampo();
        }

        private void FormRegistrarProducto_Load(object sender, EventArgs e)
        {
            btnRegistrarProductos.Enabled = false;
            CargarProveedores();
        }

        private void CalcularResultado(object sender, EventArgs e)
        {
            if (float.TryParse(TxtPrecio.Text, out float precio) && int.TryParse(txtCantidad.Text, out int cantidad))
            {
                double resultado = precio * cantidad;
                lblTotal.Text = resultado.ToString();
            }
            else
            {
                lblTotal.Text = "Error";
            }
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();

            ofdSeleccionar.Filter = "“Imagenes|*.jpg; *.png; *.jpeg";

            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                imagen.Image = System.Drawing.Image.FromFile(ofdSeleccionar.FileName);

            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            validacion();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

