using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using AppPersona.WsEfecty;
using System.Data;

namespace AppPersona
{
    public partial class ConsultarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                WsEfecty.Service1Client service1Client = new WsEfecty.Service1Client();

                objRtaPersona Personas = service1Client.ConsultarPersona(txtFiltro.Text);



                if (!Personas.ExisteError)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Columns.Add("ID");
                    dataTable.Columns.Add("Nombres");
                    dataTable.Columns.Add("Apellidos");
                    dataTable.Columns.Add("Fecha Nacimiento");
                    dataTable.Columns.Add("Tipo Documento");
                    dataTable.Columns.Add("Estado civil");
                    dataTable.Columns.Add("Valor a ganar");

                    foreach (objPersona persona in Personas.Personas)
                    {
                        DataRow row = dataTable.NewRow();
                        row["ID"] = persona.Id;
                        row["Nombres"] = persona.Nombres;
                        row["Apellidos"] = persona.Apellidos;
                        row["Fecha Nacimiento"] = persona.FechaNacimiento;
                        row["Tipo Documento"] = persona.TipoDocumento;
                        row["Estado civil"] = persona.EstadoCivil;
                        row["Valor a ganar"] = persona.ValorAGanar;

                        dataTable.Rows.Add(row);
                    }

                    Registros.DataSource = dataTable;
                    Registros.DataBind();
                    Registros.Visible = true;
                }
                else
                {
                    throw new Exception(Personas.MensajeError);
                }
            }
            catch (Exception ex)
            {
                txtResultado.Text = ex.Message;
            }
        }
    }
}