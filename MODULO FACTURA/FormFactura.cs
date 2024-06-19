using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*GRUPO A*/
namespace MODULO_FACTURA
{
    public partial class FormFactura : Form
    {
        private static int contadorEstatico = 0;
        public string fecha, cliente, proveedor, empresa, subtotal, iva, total;
        public FormFactura()
        {
            InitializeComponent();
            productos.AutoGenerateColumns = false;
            productos.Columns.Add("Nombre", "Nombre");
            productos.Columns.Add("Descripcion", "Descripción");
            productos.Columns.Add("Precio", "Precio");

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

        private void imprimir_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(imprimir, "Imprimir");
        }

        private void FormFactura_Load(object sender, EventArgs e)
        {
            contadorEstatico++;

            // Mostrar el contador en el label
            lblcontador.Text = $"00{contadorEstatico}";
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
    }
}
