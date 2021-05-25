using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Libreria;

namespace WsEfecty
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class Service1 : IService1
    {
        public objRtaTiposDocumento ConsultarTiposDocumento()
        {
            objRtaTiposDocumento Respuesta = new objRtaTiposDocumento();
            clsPersona clsPersona = new clsPersona();

            try
            {
                clsPersona.AbrirConexion();

                Respuesta.TiposDocumento = clsPersona.ConsultarTiposDocumento();
                Respuesta.ExisteError = false;
                Respuesta.MensajeError = string.Empty;
            }
            catch(Exception ex)
            {
                Respuesta.ExisteError = true;
                Respuesta.MensajeError = ex.Message;
            }
            finally
            {
                if(clsPersona.connection.State == System.Data.ConnectionState.Open)
                {
                    clsPersona.CerrarConexion();
                }
            }
            return Respuesta;
        }

        public objRtaEstadosCivil ConsultarEstadosCivil()
        {
            objRtaEstadosCivil Respuesta = new objRtaEstadosCivil();
            clsPersona clsPersona = new clsPersona();

            try
            {
                clsPersona.AbrirConexion();

                Respuesta.EstadosCivil = clsPersona.ConsultarEstadosCivil();
                Respuesta.ExisteError = false;
                Respuesta.MensajeError = string.Empty;
            }
            catch (Exception ex)
            {
                Respuesta.ExisteError = true;
                Respuesta.MensajeError = ex.Message;
            }
            finally
            {
                if (clsPersona.connection.State == System.Data.ConnectionState.Open)
                {
                    clsPersona.CerrarConexion();
                }
            }
            return Respuesta;
        }

        public objRtaPersona ConsultarPersona(string Nombres)
        {
            objRtaPersona Respuesta = new objRtaPersona();
            clsPersona clsPersona = new clsPersona();

            try
            {
                clsPersona.AbrirConexion();

                Respuesta.Personas = clsPersona.ConsultarPersona(Nombres);
                Respuesta.ExisteError = false;
                Respuesta.MensajeError = string.Empty;
            }
            catch (Exception ex)
            {
                Respuesta.ExisteError = true;
                Respuesta.MensajeError = ex.Message;
            }
            finally
            {
                if (clsPersona.connection.State == System.Data.ConnectionState.Open)
                {
                    clsPersona.CerrarConexion();
                }
            }
            return Respuesta;
        }

        public objRtaInsertarPersona InsertarPersona(string Nombres, string Apellidos, int IdTipoDocumento, DateTime FechaNacimiento, double ValorGanar, int IdEstadoCivil)
        {
            objRtaInsertarPersona Respuesta = new objRtaInsertarPersona();
            clsPersona clsPersona = new clsPersona();


            try
            {
                clsPersona.AbrirConexion();

                clsPersona.InsertarPersona(Nombres,Apellidos,IdTipoDocumento,FechaNacimiento,ValorGanar,IdEstadoCivil);
                Respuesta.ExisteError = false;
                Respuesta.MensajeError = string.Empty;
            }
            catch (Exception ex)
            {
                Respuesta.ExisteError = true;
                Respuesta.MensajeError = ex.Message;
            }
            finally
            {
                if (clsPersona.connection.State == System.Data.ConnectionState.Open)
                {
                    clsPersona.CerrarConexion();
                }
            }
            return Respuesta;
        }
    }
}
