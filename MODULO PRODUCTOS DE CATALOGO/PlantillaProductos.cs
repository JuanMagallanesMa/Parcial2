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
        public decimal PrecioD
        {
            get
            {
                if (decimal.TryParse(lblPrecio.Text.Replace("$", ""), NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal precio))
                {
                    
                   // MessageBox.Show("Cambiado el formato");
                    return precio;
                }
                else
                {
                    MessageBox.Show("El formato de precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0; // O devuelve un valor predeterminado
                }
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

      
        }
    }

