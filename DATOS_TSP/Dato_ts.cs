using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

/*GRUPO A*/
namespace DATOS_TSP
{
    public class Dato_ts
    {
        private DataTable usuariosDataTable;

        public SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-FH0EC0H6\\SQLEXPRESS; Initial Catalog=Proyecto_Laptops;Integrated Security=True");

        /*metodo para usar en los demas modulos para abrir la conexion*/
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        /*metodo para usar en los demas modulos para cerrar la conexion*/
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();

            return conexion;
        }
        private static Dato_ts datos_tecnolaptops = new Dato_ts();
        /*Constructor*/
        public Dato_ts() { }
        /*Metodo static que retorna toda la clase*/
        public static Dato_ts getObject()
        {
            return datos_tecnolaptops;
        }


        /*SE CREA UNA IMPORTACION DE CONEXION POR CADA METODO DE CADA CLASE*/

        /*Metodo StoredProcedure con parametros para insertar usuario*/
        public void InsertarUsuarios(string nombre, string usuario, string correo, string contrasena, string tipoUsuario)
        {
            string conet = "SP_RegistrarUsuarios";
            /*llamamos la conexion de nuestro servidor*/

            SqlCommand command = new SqlCommand(conet, conexion);

            /*se especifica los procediminetos almacenados para insertar usuario*/
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre_completo", nombre);
            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@correo", correo);
            command.Parameters.AddWithValue("@contrasena", contrasena);
            command.Parameters.AddWithValue("@tipo_usuario", tipoUsuario);
            /*Abrimos la conexion de la base de datos y se ejecuta*/
            AbrirConexion();
            command.ExecuteNonQuery();
        }


        /*Metodo StoredProcedure con parametros para modificar usuario */
        public void ModificarUsuarios(int id, string nombre, string usuario, string correo, string contrasena, string tipoUsuario)
        {
            string conet = "SP_ModificarUsuarios";
            /*llamamos la conexion de nuestro servidor*/

            using (SqlCommand command = new SqlCommand(conet, conexion))
            {
                /*se especifica los procediminetos almacenados para modificar usuario*/
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@contrasena", contrasena);
                command.Parameters.AddWithValue("@tipo_usuario", tipoUsuario);
                /*Abrimos la conexion de la base de datos y se ejecuta*/
                AbrirConexion();
                command.ExecuteNonQuery();
            }
        }


        /*Metodo StoredProcedure con parametros para buscar usuario */
        public DataTable BuscarDatosPorCorreoUsuario(string correoBuscado, string tipoUsuario)
        {
            DataTable datos = new DataTable();

            /*llamamos la conexion de nuestro servidor*/

            /*se especifica los procediminetos almacenados para busar al usuario por correo*/
            SqlCommand command = new SqlCommand("SP_BuscarCorreoUsuarios", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Correo", correoBuscado);
            command.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);

            try
            {
                /*Abre la conexion*/
                AbrirConexion();
                /*se ejecuta SqlAdapter para llenar la tabla con los datos almacenados*/
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(datos);
                return datos;
            }
            /*se envia un excepcion si hubo algun problema al buscar los datos*/
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar los datos: " + ex.Message);
                return datos;
            }
        }


        /*Metodo StoredProcedure con parametro para eliminar usuario */
        public void EliminarUsuario(int id)
        {
            try
            {
                string conet = "SP_EliminarUsuarios";

                // Llamamos la conexión de nuestro servidor.
                using (SqlCommand command = new SqlCommand(conet, conexion))
                {
                    // Especificamos los procedimientos almacenados para eliminar usuario.
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    // Abrimos la conexión de la base de datos y se ejecuta.
                    AbrirConexion();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}");
            }
            finally
            {
                // cierra conexion 
                CerrarConexion();
            }

        }
        /*metodo que llamamos la tabla y especificamos que nos de un dato en especifico ejemplo:Cliente */
        public DataTable ListaDeUsuariosCliente()
        {
            if (usuariosDataTable == null)
            {
                using (SqlCommand command = new SqlCommand("select * from usuarios where tipo_usuario = 'Cliente'", conexion))
                {
                    AbrirConexion();
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    usuariosDataTable = new DataTable();
                    data.Fill(usuariosDataTable);
                }
            }
            return usuariosDataTable;
        }


        /*metodo que llamamos la tabla y especificamos que nos de un dato en especifico ejemplo:Proveedor */
        public DataTable ListaDeUsuariosProveedor()
        {
            if (usuariosDataTable == null)
            {
                using (SqlCommand command = new SqlCommand("select * from usuarios where tipo_usuario = 'Proveedor'", conexion))
                {
                    AbrirConexion();
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    usuariosDataTable = new DataTable();
                    data.Fill(usuariosDataTable);
                }
            }
            return usuariosDataTable;
        }

        /*metodo que llamamos la tabla y especificamos que nos de un dato en especifico ejemplo:Empresa de transporte */

        public DataTable ListaDeUsuariosEmpresa()
        {
            if (usuariosDataTable == null)
            {
                using (SqlCommand command = new SqlCommand("select * from usuarios where tipo_usuario = 'Empresa de transporte'", conexion))
                {
                    AbrirConexion();
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    usuariosDataTable = new DataTable();
                    data.Fill(usuariosDataTable);
                }
            }
            return usuariosDataTable;         
        }
        /*Metodo StoredProcedure con parametros para insertar encabezado factura */
        public void InsertarEncabezadoFactura(int id_establecimiento, int id_caja, int id_cliente, string ruc_establecimiento, DateTime fecha, int id_proveedor, int id_transporte )
        {
            string conet = "SP_RegistrarEncFactura";
            /*Se llama a la conexion*/

            SqlCommand command = new SqlCommand(conet, conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_establecimiento", id_establecimiento);
            command.Parameters.AddWithValue("@id_caja", id_caja);
            command.Parameters.AddWithValue("@id_cliente", id_cliente);
            command.Parameters.AddWithValue("@ruc_establecimiento", ruc_establecimiento);
            command.Parameters.AddWithValue("@fecha", fecha);
            command.Parameters.AddWithValue("@id_proveedor", id_proveedor);
            command.Parameters.AddWithValue("@id_transporte", id_transporte);
            AbrirConexion();
            command.ExecuteNonQuery();

        }
        public void InsertarDetalleFactura(int id_nummero_factura, int id_producto, int cantidad, float precio_total, float total_pagar)
        {
            string conet = "SP_RegistrarDetFactura";

            SqlCommand command = new SqlCommand(conet, conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_nummero_factura", id_nummero_factura);
            command.Parameters.AddWithValue("@id_producto", id_producto);
            command.Parameters.AddWithValue("@cantidad", cantidad);
            command.Parameters.AddWithValue("@precio_total", precio_total);
            command.Parameters.AddWithValue("@total_pagar", total_pagar);
            AbrirConexion();
            command.ExecuteNonQuery();
        }

        /*Metodo StoredProcedure con parametros para insertar proveedor */
        public void InsertarProducto(string proveedor, string nombre_producto, string descripcion, float cantidad, float precio, float total, byte[] imagen, out string nombreCompletoProveedor)
        {
            string conet = "SP_RegistrarProductos";
            /*llamamos la conexion de nuestro servidor*/

            SqlCommand command = new SqlCommand(conet, conexion);

            /*se especifica los procediminetos almacenados para insertar los productos*/
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@proveedor", proveedor);
            command.Parameters.AddWithValue("@nombre_producto", nombre_producto);
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.Parameters.AddWithValue("@cantidad", cantidad);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@total", total);
            command.Parameters.AddWithValue("@imagen", imagen);
            command.Parameters.Add("@nombre_completo_proveedor", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            /*Abrimos la conexion de la base de datos y se ejecuta*/
            AbrirConexion();
            command.ExecuteNonQuery();
            /*cambia el ID por el nombre de la tabla relacionada*/
            nombreCompletoProveedor = command.Parameters["@nombre_completo_proveedor"].Value.ToString();
        }
        /*metodo que obtiene la lista para los proveedores para cargar en el COMOBOX*/
        public List<string> ObtenerListaProveedores()
        {
            List<string> proveedores = new List<string>();

            try
            {
                /*sencencia SQL */
                string query = "SELECT nombre_completo FROM usuarios WHERE tipo_usuario = 'Proveedor';";

                using (SqlCommand command = new SqlCommand(query, AbrirConexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proveedores.Add(reader["nombre_completo"].ToString());
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener proveedores: " + ex.Message);
            }

            return proveedores;
        }
        /*metodo que obtiene la lista para la empresa de transporte para cargar en el COMOBOX*/
        public List<string> ObtenerListaEmpresa()
        {
            /*se crea una lista */
            List<string> empresa = new List<string>();

            try
            {
                /*sencencia SQL */
                string query = "SELECT nombre_completo FROM usuarios WHERE tipo_usuario = 'Empresa de transporte';";

                using (SqlCommand command = new SqlCommand(query, AbrirConexion()))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empresa.Add(reader["nombre_completo"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener nombre de la empresa: " + ex.Message);
            }

            return empresa;
        }

        /*Metodo StoredProcedure con parametros para buscar producto */
        public DataTable BuscarDatosProductos(string producto)
        {
            DataTable datos = new DataTable();

            /*se especifica los procedimientos almacenados para buscar al usuario por nombre del producto*/
            SqlCommand command = new SqlCommand("SP_BuscarProducto", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre_producto", producto);

            try
            {
                /*Abre la conexion*/
                AbrirConexion();
                /*se ejecuta SqlAdapter para llenar la tabla con los datos almacenados*/
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(datos);
                return datos;  // Aquí se retorna el resultado de la consulta.
            }
            /*se envía una excepción si hubo algún problema al buscar los datos*/
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar los datos: " + ex.Message);
                return datos;
            }
        }

        /*Metodo StoredProcedure con parametros para modificar producto */
        public void ModificarProducto(int id, int proveedor, string nombre_producto, string descripcion, int cantidad, float precio, float total, byte[] imagen)
        {
            string conet = "SP_ModificarProducto";
            /*llamamos la conexion de nuestro servidor*/

            using (SqlCommand command = new SqlCommand(conet, conexion))
            {
                /*se especifica los procediminetos almacenados para modificar producto*/
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_producto", id);
                command.Parameters.AddWithValue("@proveedor", proveedor);
                command.Parameters.AddWithValue("@nombre_producto", nombre_producto);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@cantidad", cantidad);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@total", total);
                command.Parameters.AddWithValue("@imagen", imagen);
                /*Abrimos la conexion de la base de datos y se ejecuta*/
                AbrirConexion();
                command.ExecuteNonQuery();
            }
        }

        /*Metodo StoredProcedure con parametro para eliminar producto */
        public void EliminarProducto(int id)
        {
            string conet = "SP_EliminarProducto";

            try
            {
                AbrirConexion();

                using (SqlTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(conet, conexion, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Producto eliminado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw; // Propaga la excepción para manejarla en el método que llamó a EliminarProducto
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }
        /*metodo que muestra la lista de productos en la tabla*/
        public DataTable ListaDeProductos()
        {
            if (usuariosDataTable == null)
            {
                /*sentencia SQL que llama la tabla*/
                using (SqlCommand command = new SqlCommand("SELECT p.id_producto, u.nombre_completo AS nombre_proveedor,  p.nombre_producto, p.descripcion, p.cantidad, p.precio, p.total, p.imagen FROM productos p JOIN usuarios u ON p.id_proveedor = u.id_usuario;", conexion))
                {
                    /*Abrimos la conexion de la base de datos y se ejecuta*/
                    AbrirConexion();
                    SqlDataAdapter data = new SqlDataAdapter(command);
                    usuariosDataTable = new DataTable();
                    data.Fill(usuariosDataTable);
                }
            }
            return usuariosDataTable;
        }

    }
}

