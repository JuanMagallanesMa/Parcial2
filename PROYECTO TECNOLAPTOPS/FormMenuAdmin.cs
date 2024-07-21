using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODULO_USUARIO;
using MODULO_PROVEEDOR;
using MODULO_EMPRESA_DE_TRANSPORTE;
using MODULO_PRODUCTOS_DE_CATALOGO;

/*GRUPO A*/
namespace PROYECTO_TECNOLAPTOPS
{
    public partial class FormMenuAdmin : Form
    {
        public FormMenuAdmin()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void contenedores(Form conten)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = conten;
            conten.TopLevel = false;
            conten.FormBorderStyle = FormBorderStyle.None;
            conten.Dock = DockStyle.Fill;
            panelContenedor1.Controls.Add(conten);
            panelContenedor1.Tag = conten;
            conten.BringToFront();
            conten.Show();

        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            contenedores(new FormListaCliente());
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            contenedores(new FormListaProveedor());
        }

        private void BtnEmpresa_Click(object sender, EventArgs e)
        {
            contenedores(new FormListaEmpresa());
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            contenedores(new FormListaProductos());
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            FormMenuPrincipal principal = new FormMenuPrincipal();
            principal.Show();
        }
    }
}
