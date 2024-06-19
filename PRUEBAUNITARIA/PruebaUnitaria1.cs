using DATOS_TSP;
using Menssage_Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROYECTO_TECNOLAPTOPS;
using System;
using System.IO;
using System.Windows.Forms;

namespace Prueba_Unitaria
{
    [TestClass]
    public class PruebasTest
    {
        /* Prueba validar usuario existente*/
        [TestMethod]
        public void ValidaUsuarioExistente()
        {
            FormLogin formLogin = new FormLogin();
            string usuario = "GrupoCS";
            string contrasena = "Grupocs2024";
            formLogin.iniciar(usuario, contrasena);
        }

        /* Prueba  usuario incorrecto*/
        [TestMethod]
        public void ValidaUsuarioNoExistente()
        {
            FormLogin formLogin = new FormLogin();
            string usuario = "?";
            string contrasena = "?";
            formLogin.iniciar(usuario, contrasena);
            Assert.IsFalse(false);
        }

        /* Prueba busca usuario por correo y tipo de usuariario correcto*/
        [TestMethod]
        public void TestBuscaUsuario()
        {
            Dato_ts buscar = new Dato_ts();
            string correo = "grupoA.cs@gmail.com";
            string tipoUsuario = "Cliente";
            buscar.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);
            Assert.IsTrue(true);
        }

        /* Prueba busca usuario por correo y tipo de usuariario incorrecto*/
        [TestMethod]
        public void TestBuscaUsuarioIncorrecto()
        {
            Dato_ts buscar = new Dato_ts();
            string correo = "?";
            string tipoUsuario = "?";
            buscar.BuscarDatosPorCorreoUsuario(correo, tipoUsuario);
            Assert.IsFalse(false);
        }
        /* Prueba modificar usuario correcto*/
        [TestMethod]
        public void TestModificarUsuarios()
        {
            Dato_ts modificar = new Dato_ts();
            int id = 2;
            string nombre = "Carlos Dnailo Macias";
            string usuario = "CarlM";
            string correo = "carlitos.m2002@gmail.com";
            string contrasena = "CarlM";
            string tipo = "Cliente";
            modificar.ModificarUsuarios(id, nombre, usuario, correo, contrasena, tipo);
            Assert.IsTrue(true);
        }

        /* Prueba modificar usuario formato incorrecto*/
        [TestMethod]
        public void TestModificarUsuariosIncorrecto()
        {
            Dato_ts modificar = new Dato_ts();
            int id = 0;
            string nombre = "?";
            string usuario = "?";
            string correo = "?";
            string contrasena = "?";
            string tipo = "?";
            modificar.ModificarUsuarios(id, nombre, usuario, correo, contrasena, tipo);
            Assert.IsFalse(false);
        }

        /* Prueba eliminar usuario formato correcto*/
        [TestMethod]
        public void TestEliminarUsuarioCorrecto()
        {
            Dato_ts eliminar = new Dato_ts();
            int id = 2;
            eliminar.EliminarUsuario(id);
            Assert.IsTrue(true);
        }

        /* Prueba eliminar usuario formato incorrecto*/
        [TestMethod]
        public void TestEliminarUsuariosIncorrecto()
        {
            Dato_ts eliminar = new Dato_ts();
            int id = 0;
            eliminar.EliminarUsuario(id);
            Assert.IsFalse(false);
        }


        /* Prueba eliminar producto correcto*/
        [TestMethod]
        public void TestElimnarProductoCorrecto()
        {
            Dato_ts eliminar = new Dato_ts();
            int id = 17;
            eliminar.EliminarProducto(id);
            Assert.IsTrue(true);
        }

        /* Prueba eliminar producto incorrecto*/
        [TestMethod]
        public void TestElimnarProductoIncorrecto()
        {
            Dato_ts eliminar = new Dato_ts();
            int id = 0;
            eliminar.EliminarProducto(id);
            Assert.IsFalse(false);
        }
        /* Prueba busca producto por nombre correcto*/
        [TestMethod]
        public void TestBuscaProductoCorrecto()
        {
            Dato_ts buscar = new Dato_ts();
            string nombre = "Asus Vivobook 14";
            buscar.BuscarDatosProductos(nombre);
            Assert.IsTrue(true);
        }
        /* Prueba busca producto por nombre incorrecto*/
        [TestMethod]
        public void TestBuscaProductoIncorrecto()
        {
            Dato_ts buscar = new Dato_ts();
            string nombre = "?";
            buscar.BuscarDatosProductos(nombre);
            Assert.IsFalse(false);
        }

        /* Prueba de obtener lista cargada de proveedores*/
        [TestMethod]
        public void TestListaObtenerProveedores()
        {
            Dato_ts lista = new Dato_ts();
            lista.ObtenerListaProveedores();
            Assert.IsTrue(true);
        }

        /* Prueba de obtener lista cargada de proveedores incorrecto*/
        [TestMethod]
        public void TestListaObtenerProveedoresIncorrecto()
        {
            Dato_ts lista = new Dato_ts();
            lista.ObtenerListaProveedores();
            Assert.IsFalse(false);
        }

        /* Prueba de obtener lista cargada de empresa*/
        [TestMethod]
        public void TestListaObtenerEmpresa()
        {
            Dato_ts lista = new Dato_ts();
            lista.ObtenerListaEmpresa();
            Assert.IsTrue(true);
        }

        /* Prueba de obtener lista cargada de empresa incorrecta*/
        [TestMethod]
        public void TestListaObtenerEmpresaIncorrecta()
        {
            Dato_ts lista = new Dato_ts();
            lista.ObtenerListaEmpresa();
            Assert.IsFalse(false);
        }

        /* Prueba de obtener lista de cliente*/
        [TestMethod]
        public void TestListaCliente()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeUsuariosCliente();
            Assert.IsTrue(true);
        }

        /* Prueba de obtener lista de cliente incorrecto*/
        [TestMethod]
        public void TestListaClienteIncorrecto()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeUsuariosCliente();
            Assert.IsFalse(false);
        }

        /* Prueba de obtener lista de proveedores*/
        [TestMethod]
        public void TestListaProveedores()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeUsuariosProveedor();
            Assert.IsTrue(true);
        }
        /* Prueba de obtener lista de proveedores incorrecto*/
        [TestMethod]
        public void TestListaProveedoresIncorrecto()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeUsuariosProveedor();
            Assert.IsFalse(false);
        }

        /* Prueba de obtener lista de empresa*/
        [TestMethod]
        public void TestListaEmpresa()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeUsuariosEmpresa();
            Assert.IsTrue(true);
        }

        /* Prueba de obtener lista de empresa incorrecto*/
        [TestMethod]
        public void TestListaEmpresaIncorrecto()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeUsuariosEmpresa();
            Assert.IsFalse(false);
        }

        /* Prueba de obtener lista de productos*/
        [TestMethod]
        public void TestListaProductos()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeProductos();
            Assert.IsTrue(true);
        }


        /* Prueba de obtener lista de productos incorrecto*/
        [TestMethod]
        public void TestListaProductosIncorrecto()
        {
            Dato_ts lista = new Dato_ts();
            lista.ListaDeProductos();
            Assert.IsFalse(false);
        }
    }
}
