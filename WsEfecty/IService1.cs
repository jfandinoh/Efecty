using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using Libreria;

namespace WsEfecty
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        objRtaTiposDocumento ConsultarTiposDocumento();

        [OperationContract]
        objRtaEstadosCivil ConsultarEstadosCivil();

        [OperationContract]
        objRtaPersona ConsultarPersona(string Nombres);

        [OperationContract]
        objRtaInsertarPersona InsertarPersona(string Nombres, string Apellidos, int IdTipoDocumento, DateTime FechaNacimiento, double ValorGanar, int IdEstadoCivil);

    }
}
