using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATOS_TSP;
using Menssage_Exception;

/*GRUPO A*/
namespace MODULO_FACTURA
{
    public partial class FormFactura : Form
    {
        Dato_ts datos = new Dato_ts();
        private static int contadorEstatico = 0;
        public string fecha, cliente, proveedor, empresa, subtotal, iva, total;
        public int idcliente , idproveedor, idtransporte;
        public FormFactura()
        {
            InitializeComponent();
            productos.AutoGenerateColumns = false;
            productos.Columns.Add("Nombre", "Nombre");
            productos.Columns.Add("Descripcion", "Descripción");
            productos.Columns.Add("Precio", "Precio");
            productos.Columns.Add("Cantidad", "Cantidad");
            productos.Columns.Add("PrecioTotal", "Precio Total");

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle r = e.PageBounds;
            e.Graphics.DrawImage(memoryimg, (r.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            print(this.panel1);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblcontador_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                datos.InsertarEncabezadoFactura(int.Parse(lblEstablecimiento.Text), int.Parse(lblcaja.Text), BuscarUsuario(cliente), lblruc.Text,DateTime.Now,BuscarProveedor(proveedor),BuscarTransporte(empresa));
                MessageBox.Show("Se ha insertado correctamente los datos");
                
            }
            catch (ExcepcionIngreseDatos)
            {
                MessageBox.Show("Ingrese datos para registrar");
            }
             


            print(this.panel1);
        }

        private void btnGuardarImprimir_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(imprimir, "Imprimir");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void imprimir_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(imprimir, "Imprimir");
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(BuscarNumeroFactura());
            
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            

            
            
            productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            lblfecha.Text = fecha;
            lblfecha1.Text = fecha;
            lblcliente.Text = cliente;
            lblproveedor.Text = proveedor;  
            lbltransporte.Text = empresa;
            lblSubtotal.Text = subtotal;
            lblIVA.Text = iva;
            lblTotal.Text = total;
            lblnumerofactura.Text = RellenarCadena(BuscarNumeroFactura(), '0', 5, true); ;
        }
        private void print(Panel p)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            panel1 = p;
            imp(p);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();
        }
        private Bitmap memoryimg;

        private void imp(Panel p)
        {
            memoryimg = new Bitmap(p.Width, p.Height);
            p.DrawToBitmap(memoryimg, new Rectangle(0, 0, memoryimg.Width, memoryimg.Height));
        }
        public void CargarDatosEnDataGridView(List<DataGridViewRow> rows)
        {
            foreach (var row in rows)
            {
                productos.Rows.Add(row.Clone() as DataGridViewRow);

                // Copia los valores de cada celda a la nueva fila en el segundo DataGridView
                foreach (DataGridViewCell cell in row.Cells)
                {
                    productos.Rows[productos.Rows.Count - 1].Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }
        }
        public int BuscarUsuario(string strnombre)
        {
            datos.AbrirConexion();
            string sql = "Select id_usuario from usuarios where nombre_completo LIKE @usuario and tipo_usuario like 'Cliente'";
            using (SqlCommand cmd = new SqlCommand(sql, datos.AbrirConexion()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@usuario", "%" + strnombre + "%");
                int id_PedidoCliente = Convert.ToInt32(cmd.ExecuteScalar());
                return id_PedidoCliente;
            }

        }
        public int BuscarProveedor(string strnombre)
        {

            datos.AbrirConexion();
            string sql = "Select id_usuario from usuarios where nombre_completo LIKE @usuario and tipo_usuario like 'Proveedor'";
            using (SqlCommand cmd = new SqlCommand(sql, datos.AbrirConexion()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@usuario", "%" + strnombre + "%");
                int id_PedidoCliente = Convert.ToInt32(cmd.ExecuteScalar());
                return id_PedidoCliente;
            }

        }
        public int BuscarTransporte(string strnombre)
        {
            datos.AbrirConexion();
            string sql = "Select id_usuario from usuarios where nombre_completo LIKE @usuario and tipo_usuario Like 'Empresa de transporte'";
            using (SqlCommand cmd = new SqlCommand(sql, datos.AbrirConexion()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@usuario", "%" + strnombre + "%");
                int id_PedidoCliente = Convert.ToInt32(cmd.ExecuteScalar());
                return id_PedidoCliente;
            }

        }
        public string BuscarNumeroFactura()
        {
            datos.AbrirConexion();
            string sql = "Select MAX(id_numero_factura) from enc_compra";
            using (SqlCommand cmd = new SqlCommand(sql, datos.AbrirConexion()))
            {
                cmd.CommandType = CommandType.Text;
                int id_encabezadonum = Convert.ToInt32(cmd.ExecuteScalar());
                string id_encabezado = Convert.ToString(id_encabezadonum+1);
                return id_encabezado;
            }
        }
        public string RellenarCadena(string cadenaARellenar, char caracterDeRelleno, int longitud, bool izquierda)
        {
            if (izquierda)
            {
                return cadenaARellenar.PadLeft(longitud, caracterDeRelleno);
            }
            else
            {
                return cadenaARellenar.PadRight(longitud, caracterDeRelleno);
            }
        }

        

    }
}
