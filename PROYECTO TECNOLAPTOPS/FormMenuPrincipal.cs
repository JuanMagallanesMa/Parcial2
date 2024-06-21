using MODULO_USUARIO;
using MODULO_PROVEEDOR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODULO_PRODUCTOS_DE_CATALOGO;
using MODULO_EMPRESA_DE_TRANSPORTE;
using MODULO_FACTURA;
using DATOS_TSP;

/*GRUPO A*/
namespace PROYECTO_TECNOLAPTOPS
{
    public partial class FormMenuPrincipal : Form
    {
       

        public FormMenuPrincipal()
        {
            InitializeComponent();
            panelSubmenu();
            lblNombre.ForeColor = Color.White;
        }


        private void panelSubmenu()
        {
            panelSubmenuUsuario.Visible = false;
            panelSubmenuProveedor.Visible = false;
     
            panelSubmenuTransporte.Visible = false;
            
        }

        private void hideSubMenu()
        {
            if(panelSubmenuUsuario.Visible == true)
               panelSubmenuUsuario.Visible = false;

            if (panelSubmenuProveedor.Visible == true)
                panelSubmenuProveedor.Visible = false;

            if (panelSubmenuTransporte.Visible == true)
                panelSubmenuTransporte.Visible = false;

          
        }

        private void showSubmenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else
           SubMenu.Visible = false;
        }

        private Form activeForm = null;
        private void contenedores(Form conten, string nombre ="")
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = conten;
            conten.TopLevel = false;
            conten.FormBorderStyle = FormBorderStyle.None;
            conten.Dock = DockStyle.None;
            if (conten is FormCatalogoProductos catalogoForm)
            {
                catalogoForm.SetNombre_Usuario(nombre);
            }
            panelContenedor.Controls.Add(conten);
            panelContenedor.Tag = conten;
            conten.BringToFront();
            conten.Show();

        }
        public void SetNombre_Usuario(string nombre)
        {
            lblNombre.Text = "Bienvenido, " + nombre;
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenuUsuario);
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenuProveedor);
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {

            string nombreUsuario = lblNombre.Text.Replace("Bienvenido, ", "");

            contenedores(new FormCatalogoProductos(), nombreUsuario);
            //contenedores(new FormCatalogoProductos());
            hideSubMenu();
        }

        private void btnTransporte_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenuTransporte);
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            contenedores(new FormFactura());
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {

            contenedores(new FormRegistro());
            hideSubMenu();
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            contenedores(new FormModificarUsuario());
            hideSubMenu();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            contenedores(new FormEliminarUsuario());
            hideSubMenu();
        }
        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            contenedores(new FormModificarProveedor());
            hideSubMenu();
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            contenedores(new FormEliminarProveedor());
            hideSubMenu();
        }

        private void btnModificarEmpresa_Click(object sender, EventArgs e)
        {
            contenedores(new FormModificarEmpresa());
            hideSubMenu();
        }

        private void btnEliminarEmpresa_Click(object sender, EventArgs e)
        {
            contenedores(new FormEliminarEmpresa());
            hideSubMenu();
        }

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
        {
   
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio();
            inicio.Show();
        }

        private void panelSubmenuUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnRegProd_Click(object sender, EventArgs e)
        {
            contenedores(new FormRegistrarProducto());
            hideSubMenu();
        }

        private void BtnModProd_Click(object sender, EventArgs e)
        {
            contenedores(new FormModificarProducto());
            hideSubMenu();
        }

        private void BtnEliProd_Click(object sender, EventArgs e)
        {
            contenedores(new FormEliminarProducto());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

    }
}
