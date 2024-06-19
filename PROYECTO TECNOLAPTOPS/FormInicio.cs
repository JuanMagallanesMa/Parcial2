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

/*GRUPO A*/
namespace PROYECTO_TECNOLAPTOPS
{
    public partial class FormInicio : Form
    {
        public FormInicio()
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
            panelContenedor.Controls.Add(conten);
            panelContenedor.Tag = conten;
            conten.BringToFront();
            conten.Show();

        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //FormLogin login = new FormLogin();
            //login.Show();
            contenedores(new FormLogin());
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnRegistroUsu_Click(object sender, EventArgs e)
        {
            contenedores(new FormRegistro());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblRegistro_Click(object sender, EventArgs e)
        {
            contenedores(new FormRegistro());
        }


    }
}
