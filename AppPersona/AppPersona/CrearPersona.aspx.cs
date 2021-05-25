using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppPersona.WsEfecty;
using System.Web.Services;

namespace AppPersona
{
    public partial class CrearPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    WsEfecty.Service1Client service1Client = new Service1Client();

                    objRtaTiposDocumento objTiposDocumento = service1Client.ConsultarTiposDocumento();

                    if (!objTiposDocumento.ExisteError)
                    {
                        foreach (objTipoDocumento Tipo in objTiposDocumento.TiposDocumento)
                        {
                            ListItem listItem = new ListItem();
                            listItem.Value = Tipo.Id.ToString();
                            listItem.Text = Tipo.Descripcion;
                            ListaTiposDocumento.Items.Add(listItem);
                        }

                    }
                    else
                    {
                        throw new Exception(objTiposDocumento.MensajeError);
                    }

                    objRtaEstadosCivil objEstadosCivil = service1Client.ConsultarEstadosCivil();

                    if (!objEstadosCivil.ExisteError)
                    {
                        foreach (objEstadoCivil Tipo in objEstadosCivil.EstadosCivil)
                        {
                            ListItem listItem = new ListItem();
                            listItem.Value = Tipo.Id.ToString();
                            listItem.Text = Tipo.Descripcion;
                            ListEstadoCivil.Items.Add(listItem);
                        }

                    }
                    else
                    {
                        throw new Exception(objEstadosCivil.MensajeError);
                    }

                    Calendar.SelectedDate = DateTime.Now;

                }
                catch (Exception ex)
                {
                    txtResultado.Text = ex.Message;
                }
            }
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void ListaTiposDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                WsEfecty.Service1Client service1Client = new Service1Client();

                objRtaInsertarPersona objRtaInsertarPersona = service1Client.InsertarPersona(txtNombre.Text,
                    txtAPellidos.Text, int.Parse(ListaTiposDocumento.SelectedValue), Calendar.SelectedDate, double.Parse(txtValor.Text), int.Parse(ListEstadoCivil.SelectedValue));

                if (!objRtaInsertarPersona.ExisteError)
                {
                    txtResultado.Text = "Registro creado correctamente";
                }
            }
            catch(Exception ex)
            {
                txtResultado.Text = ex.Message;
            }
        }
    }
}