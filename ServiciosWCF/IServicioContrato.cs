using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosWCF
{

    // Servicios donde se definen e implementan los metodos

    [ServiceContract]
    public interface IServicioContrato
    {
        //Cada metodo tiene que tener su [OperationContract]

        [OperationContract]
        List<cliente> Clientes();

        [OperationContract]
        List<pais> Paises();

        [OperationContract]
        List<cliente> ClientesxPais(string pais);

        [OperationContract]
        string Agregar(cliente reg);

        [OperationContract]
        string Actualizar(cliente reg);

        [OperationContract]
        string Eliminar(cliente reg);
    }

    // Cada clase tiene que ter su [DataContract]
    [DataContract]
    public class cliente
    {
        //Cada atributo tiene que tener su [DataMember]
        [DataMember]public string idcliente { get; set; }
        [DataMember]public string nombrecia { get; set; }
        [DataMember]public string direccion { get; set; }
        [DataMember]public string idpais { get; set; }
        [DataMember]public string telefono { get; set; }
    }

    // Cada clase tiene que ter su [DataContract]
    [DataContract]
    public class pais
    {
        //Cada atributo tiene que tener su [DataMember]
        [DataMember]public string idpais { get; set; }
        [DataMember]public string nombrepais { get; set; }
    }
}
