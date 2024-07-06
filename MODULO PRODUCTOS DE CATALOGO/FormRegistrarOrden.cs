using DATOS_TSP;
using MODULO_FACTURA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    public partial class FormRegistrarOrden : Form
    {
        private string nombreUsuario;
        Dato_ts datos = new Dato_ts();

        private List<PlantillaProductos> productosSeleccionados;
        private string proveedor;
        public FormRegistrarOrden(List<PlantillaProductos> productosSeleccionados, string proveedor, string nombreUsuario)
        {
            InitializeComponent();
            this.productosSeleccionados = productosSeleccionados;
            this.proveedor = proveedor;
            this.nombreUsuario = nombreUsuario;
            txtNombre.Text = nombreUsuario;
            txtProveedor.Text = proveedor;
            productos.AutoGenerateColumns = false;
            productos.Columns.Add("Nombre", "Nombre");
            productos.Columns.Add("Descripcion", "Descripción");
            productos.Columns.Add("Precio", "Precio Unitario");
            productos.Columns.Add("Cantidad","Cantidad");
            productos.Columns.Add("PrecioTotal", "Precio Total");

        }
        /*metodo para cargar los datos del nombre de la empresa*/
        private void CargarEmpresa()
        {
            comboEmpresa.Items.Clear();

            List<string> empresa = datos.ObtenerListaEmpresa();

            comboEmpresa.Items.AddRange(empresa.ToArray());

            if (comboEmpresa.Items.Count > 0)
            {
                comboEmpresa.SelectedIndex = 0;
            }
        }

        private void FormRegistrarOrden_Load(object sender, EventArgs e)
        {
            productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            CargarEmpresa();

            decimal subtotal = 0;
            decimal ivaPorcentaje = 0.12m;
            
            foreach (var producto in productosSeleccionados)
            {
                productos.Rows.Add(producto.Nombre_producto, producto.Descripcion_producto, producto.Precio, producto.Cantidad, producto.PrecioTotalS);
            }
            foreach (PlantillaProductos producto in productosSeleccionados)
            {
                if (decimal.TryParse(producto.Precio.Replace("$", ""), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal precioDecimal))
                {
                    int cantidad= producto.Cantidad;
                    decimal precioTotal = precioDecimal * cantidad;
                    subtotal += precioTotal;
                }
                else
                {
                    MessageBox.Show($"Error al analizar el precio del producto: {producto.Nombre_producto}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           


            // Calcula IVA y Total
            decimal iva = subtotal * ivaPorcentaje;
            decimal total = subtotal + iva;

            // Mostrar información en etiquetas
            lblSubtotal.Text = "$" + subtotal.ToString("N2");
            lblIVA.Text = "$" + iva.ToString("N2");
            lblTotal.Text = "$" + total.ToString("N2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
    
            FormFactura f = new FormFactura();
            f.fecha = date.Value.ToString();
            f.cliente = txtNombre.Text;
            f.proveedor = txtProveedor.Text;
            
            if (comboEmpresa.SelectedIndex == -1)
            
                f.empresa = "";
            
            else
            
                f.empresa = comboEmpresa.SelectedItem.ToString();
                



            f.subtotal = lblSubtotal.Text;
            f.iva = lblIVA.Text;
            f.total = lblTotal.Text;
            List<DataGridViewRow> filasDataGridView = new List<DataGridViewRow>();
            foreach (DataGridViewRow fila in productos.Rows)
            {
                filasDataGridView.Add(fila);
            }

            // Llama al método en FormFactura para cargar los datos
            f.CargarDatosEnDataGridView(filasDataGridView);
            f.Show();
        }

        
    }
}