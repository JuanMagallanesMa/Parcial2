using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*GRUPO A*/
namespace Menssage_Exception
{
    public class Excepciones : Exception
    {
        public Excepciones(string mensaje) : base(mensaje)
        { }
    }

    public class ExcepcionDatosNoEncontrados : Excepciones
    {
        public ExcepcionDatosNoEncontrados(string mensaje) : base(mensaje)
        { }
    }

    public class ExcepcionUsuarioNoExistente : Excepciones
    {
        public ExcepcionUsuarioNoExistente(string mensaje) : base(mensaje)
        { }
    }

    public class ExcepcionIdNoEncontrado : Excepciones
    {
        public ExcepcionIdNoEncontrado(string mensaje) : base(mensaje)
        { }
    }

    public class ExcepcionIngreseDatos : Excepciones
    {
        public ExcepcionIngreseDatos(string mensaje) : base(mensaje)
        { }
    }
    public class ExcepcionActualizaTabla : Excepciones
    {
        public ExcepcionActualizaTabla(string mensaje) : base(mensaje)
        { }
    }
    public class ExcepcionModificarUsuario : Excepciones
    {
        public ExcepcionModificarUsuario(string mensaje) : base(mensaje)
        { }
    }
    public class ExcepcionActualizarValorEnBaseDeDatos : Excepciones
    {
        public ExcepcionActualizarValorEnBaseDeDatos(string mensaje) : base(mensaje)
        { }
    }
    public class ExcepcionPlantilla : Excepciones
    {
        public ExcepcionPlantilla(string mensaje) : base(mensaje)
        { }
    }
}

