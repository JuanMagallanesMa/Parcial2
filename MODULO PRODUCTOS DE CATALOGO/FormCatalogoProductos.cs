using DATOS_TSP;
using Menssage_Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_PRODUCTOS_DE_CATALOGO
{
    public partial class FormCatalogoProductos : Form
    {
  
        /*se crea una lista de la clase de usuario de control*/
        private List<PlantillaProductos> productosSeleccionados;
        private string proveedor;
        /*clase que contiene la conexion*/
        Dato_ts datos = new Dato_ts();

        public FormCatalogoProductos()
        {
            InitializeComponent();
            /*inicializa la lista de los productos agregados*/
            productosSeleccionados = new List<PlantillaProductos>();

        }
        /*carga al provedoor en el combobox*/
        private void CargarProveedores()
        {
            comboP.Items.Clear();
            /*se para el metodo de obtener la lista del proveedor*/
            List<string> proveedores = datos.ObtenerListaProveedores();

            comboP.Items.AddRange(proveedores.ToArray());

            if (comboP.Items.Count > 0)
            {
                comboP.SelectedIndex = 0;
            }
        }
        /*llama el nombre del cliente de que a ingresado al sistema*/
        public void SetNombre_Usuario(string nombre)
        {
            lblNombre.Text =  nombre;
        }
        /*se obtiene el nombre del label */
        public string ObtenerNombreUsuario()
        {
            return lblNombre.Text;
        }
        /* metodo que indica que cargue al usuario de control */
        public void plantilla(FlowLayoutPanel contenedor)
        {
            try
            {
                contenedor.Controls.Clear();
                
                string proveedorSeleccionado = comboP.SelectedItem as string;

                if (proveedorSeleccionado != null)
                {
                    proveedor = proveedorSeleccionado;

                    datos.AbrirConexion();
                    string sql = "SELECT * FROM productos WHERE id_proveedor = (SELECT id_usuario FROM usuarios WHERE nombre_completo = @Proveedor)";
                    using (SqlCommand cmd = new SqlCommand(sql, datos.AbrirConexion()))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Proveedor", proveedorSeleccionado);

                        using (SqlDataReader read = cmd.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                int id_producto = Convert.ToInt32(read[0]);
                                int id_proveedor = Convert.ToInt32(read[1]);
                                string nombre_producto = read[2].ToString();
                                string descripcion = read[3].ToString();
                                int cantidad = Convert.ToInt32(read[4]);
                                string precio = read[5].ToString();
                                string total = read[6].ToString();
                                decimal precioDecimal = Convert.ToDecimal(precio);
                                decimal totalDecimal = Convert.ToDecimal(total);
                                byte[] imagen = ((byte[])read[7]);

                                PlantillaProductos p = new PlantillaProductos();
                                p.Nombre_producto = nombre_producto;
                                p.Descripcion_producto = descripcion;                      
                                p.Precio = "$" + precioDecimal.ToString("N2");                          
                                MemoryStream m = new MemoryStream(imagen);
                                p.Imagen = Image.FromStream(m);

                                p.CarritoStateChanged += PlantillaProducto_CarritoChanged;

                                contenedor.Controls.Add(p);
                            }
                        }
                    }
                    contenedor.Refresh();
                    datos.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un proveedor.");
                }
            }
            catch (ExcepcionPlantilla ex)
            {
                MessageBox.Show("Error en la operación: " + ex.Message);
            }
        }


        private void FormCatalogoProductos_Load(object sender, EventArgs e)
        {
            /*se llama el metodo para cargar los provedores*/
            CargarProveedores();
            comboP.SelectedIndexChanged += comboP_SelectedIndexChanged;
       
        }

        private void comboP_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*se llama el metodo de plantilla */
            plantilla(flp);
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = ObtenerNombreUsuario();
            FormRegistrarOrden formRegistrarOrden = new FormRegistrarOrden(new List<PlantillaProductos>(productosSeleccionados), proveedor, nombreUsuario);
            
            formRegistrarOrden.ShowDialog();

        }

        private void PlantillaProducto_CarritoChanged(object sender, EventArgs e)
        {
            /*carga al carrito*/
            PlantillaProductos productoSeleccionado = (PlantillaProductos)sender;

            if (productoSeleccionado.Carrito)
            {
                productosSeleccionados.Add(productoSeleccionado);
            }
            else
            {
                productosSeleccionados.Remove(productoSeleccionado);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

