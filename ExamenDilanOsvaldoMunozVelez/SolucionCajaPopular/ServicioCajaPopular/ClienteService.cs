using ServicioCajaPopular.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioCajaPopular
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ClienteService : ICliente
    {
        public Response AgregarCliente(Cliente DatosCliente, float Monto, object mensaje)
        {
            Response respuesta = new Response();
            using (CAJAPOPULARHIDALGOEntities contexto = new CAJAPOPULARHIDALGOEntities())
            {
                respuesta.CodigoError = contexto.SP_RegistrarCliente(DatosCliente.Nombre, DatosCliente.Apellido,
                     DatosCliente.FechaNacimiento, DatosCliente.Correo, DatosCliente.Telefono, DateTime.Today.Date, Monto, "");
            }
            return respuesta;
        }

        public RespuestaClientes BuscarCliente(int idCliente)
        {
            RespuestaClientes respuesta = new RespuestaClientes();
            using (CAJAPOPULARHIDALGOEntities contexto = new CAJAPOPULARHIDALGOEntities())
            {
                respuesta.lsClientes = contexto.Clientes.Where(x => x.IdCliente == idCliente).ToList();
            }
            return respuesta;
        }

        public Response EliminarCliente(int idCliente)
        {
            Response respuesta = new Response();
            using (CAJAPOPULARHIDALGOEntities contexto = new CAJAPOPULARHIDALGOEntities())
            {
                respuesta.CodigoError = contexto.SP_EliminarCliente(idCliente, "");
            }
            return respuesta;
        }

        public Response ModificarCliente(Cliente DatosCliente)
        {
            Response respuesta = new Response();
            using (CAJAPOPULARHIDALGOEntities contexto = new CAJAPOPULARHIDALGOEntities())
            {
                respuesta.CodigoError = contexto.SP_EditarCliente(DatosCliente.IdCliente, DatosCliente.Nombre, DatosCliente.Apellido,
                     DatosCliente.FechaNacimiento, DatosCliente.Correo, DatosCliente.Telefono, DateTime.Today.Date, 0.0, null);
            }
            return respuesta;
        }

    }
}
