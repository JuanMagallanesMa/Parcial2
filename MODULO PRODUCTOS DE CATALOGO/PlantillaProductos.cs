using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PRODUCTOS_DE_CATALOGO
{

    public partial class PlantillaProductos : UserControl
    {
        public event EventHandler CarritoStateChanged;
        private int id = 0;
       
        public PlantillaProductos()
        {
            InitializeComponent();
        
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion_producto
        {
            get { return lblDescripcion.Text; }
            set { lblDescripcion.Text = value; }
        }
        public string Nombre_producto
        {
            get { return lblNombre_Producto.Text; }
            set { lblNombre_Producto.Text = value; }
        }
        public int Cantidad
        {
            get {
                return Convert.ToInt32(txtCantidad.Text);
 
            }
            set { txtCantidad.Text = value.ToString(); }
        }
        public decimal PrecioD
        {
            get
            {
                if (decimal.TryParse(Precio.Replace("$", ""), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal precioD))
                {
                    
                   // MessageBox.Show("Cambiado el formato");
                    return precioD;
                }
                else
                {
                    MessageBox.Show("El formato de precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0; // O devuelve un valor predeterminado
                }
            }
        }
        public string PrecioTotalS
        {
            get
            {
                string totalstring = "$" + PrecioTotal.ToString();
                return totalstring;
            }
            
        }
        public decimal PrecioTotal
        {
            get
            {
                decimal precioDecimal= PrecioD;
                int cantidad = Cantidad;
                return precioDecimal * cantidad;
            }
        }
        public string Precio
        {
            get { return lblPrecio.Text; }
            set { lblPrecio.Text = value; }
        }
        public Image Imagen
        {
            get { return imagenProducto.Image; }
            set { imagenProducto.Image = value; }
        }


        public bool Carrito
        {
            get { return cbCarrito.Checked; }
            set { cbCarrito.Checked = value; }
        }

        private void cbCarrito_CheckedChanged(object sender, EventArgs e)
        {
            CarritoStateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtCantidad.Text);
            valor++;
            txtCantidad.Text = valor.ToString();
            
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtCantidad.Text);
            valor--;
            txtCantidad.Text = valor.ToString();
        }
    }
    }

