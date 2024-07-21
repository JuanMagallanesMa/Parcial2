using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATOS_TSP;
using MODULO_USUARIO;
using Menssage_Exception;
using MODULO_PRODUCTOS_DE_CATALOGO;

/*GRUPO A*/
namespace PROYECTO_TECNOLAPTOPS
{
    public partial class FormLogin : Form
    {
        /* Instanciamos las clases a utilizar*/
        FormMenuPrincipal p = new FormMenuPrincipal();
        FormMenuAdmin a = new FormMenuAdmin();
        FormInicio inicio  = new FormInicio();

        
        
        Dato_ts da = new Dato_ts();
        public FormLogin()
        {
            InitializeComponent();
        }

        /* metodo de validacion texbox*/
        public void validacionLogin()
        {
            var v = !string.IsNullOrEmpty(txtUsuario.Text) &&
                    !string.IsNullOrEmpty(txtClave.Text);
                 
            btn1.Enabled = v;

        }
        public void  iniciar(string usuario, string contrasena)
        {
            try
            {
                /*llamamos la conexion de nuestro servidor*/

                SqlCommand command = new SqlCommand("select  nombre_completo,  tipo_usuario from usuarios where usuario = @usuario and contrasena = @contrasena", da.AbrirConexion());

                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@contrasena", contrasena);
                command.ExecuteNonQuery();
                SqlDataAdapter ad = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                ad.Fill(table);

                /* recorre la tabla de la base de datos*/
                if (table.Rows.Count == 1)

                {
                    string nombreUsuario = table.Rows[0]["nombre_completo"].ToString();
                    this.Hide();
                    inicio.Hide();


                    if (table.Rows[0][1].ToString() == "Administrador")
                    {
                        MessageBox.Show("Usuario Administrador");

                        a.Show();
                        inicio.Hide();


                    }
                    else if (table.Rows[0][1].ToString() == "Cliente")
                    {
                        MessageBox.Show("Usuario Cliente");
                        p.SetNombre_Usuario(nombreUsuario);
                        p.Show();
                        inicio.Close();
                        p.btnProveedor.Enabled = false;
                        p.btnTransporte.Enabled = false;
                    }
                    else if (table.Rows[0][1].ToString() == "Proveedor")
                    {
                        MessageBox.Show("Usuario Proveedor");
                        p.SetNombre_Usuario(nombreUsuario);
                        p.Show();
                        inicio.Close();
                        p.btnUsuario.Enabled = false;
                        p.btnTransporte.Enabled = false;
                        p.btnCatalogo.Enabled = false;  

                    }
                    else if (table.Rows[0][1].ToString() == "Empresa de transporte")
                    {

                        MessageBox.Show("Usuario Empresa de transporte");
                        p.SetNombre_Usuario(nombreUsuario);
                        p.Show();
                        inicio.Hide();
                        p.btnUsuario.Enabled = false;
                        p.btnCatalogo.Enabled = false;
                        p.btnProveedor.Enabled = false;

                    }
                }
                else
                {
                    throw new ExcepcionUsuarioNoExistente("Usuario / contraseña no existen");

                }
            }
            catch (ExcepcionUsuarioNoExistente ex)
            {
                MessageBox.Show(ex.Message);
              
            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
             iniciar(txtUsuario.Text, txtClave.Text);

        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
            btn1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validacionLogin();
        }

        private void lblRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistro registro = new FormRegistro();
            registro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio();
            inicio.Show();

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            validacionLogin();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInicio inicio = new FormInicio();
            inicio.Show();
        }
    }
}
