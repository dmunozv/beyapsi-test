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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICliente
    {
        [OperationContract]
        RespuestaClientes BuscarCliente(int idCliente);

        [OperationContract]
        Response AgregarCliente(Cliente DatosCliente, float monto, object mensaje);

        [OperationContract]
        Response ModificarCliente(Cliente DatosCliente);

        [OperationContract]
        Response EliminarCliente(int idCliente);
        // TODO: agregue aquí sus operaciones de servicio
    }

    [DataContract]
    public class Response
    {
        [DataMember]
        public string Respuesta { get; set; }

        [DataMember]
        public int CodigoError { get; set; }
    }

    [DataContract]
    public class RespuestaClientes : Response
    {
        [DataMember]
        public IEnumerable<Cliente> lsClientes{ get; set; }
    }
}
