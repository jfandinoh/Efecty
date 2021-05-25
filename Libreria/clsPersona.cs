using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace Libreria
{
    public class clsPersona
    {
        public SqlConnection connection; //Establecer conexión a la DB
        SqlCommand command;//Realizar consultas en DB

        public clsPersona()
        {
            System.Console.WriteLine("Clase clsPersona");
            connection = new SqlConnection();
        }

        public void AbrirConexion()
        {
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                //connection.ConnectionString = "Data Source=JAFH-PC\\SQLEXPRESS;Initial Catalog=Ejemplo1;Integrated Security=True";
                connection.Open();

            }
            catch (Exception ex)
            {
                throw new Exception("Operación fallida. Error:" + ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Operación fallida. Error:" + ex.Message);
            }
        }

        public List<objTipoDocumento> ConsultarTiposDocumento()
        {
            try
            {
                SqlDataAdapter dataAdapter;//Se usa para llenar DataTable
                DataTable dtDatatable = new DataTable();
                List<objTipoDocumento> TiposDocumento = new List<objTipoDocumento>();

                command = new SqlCommand("SP_CONSULTAR_TIPOS_DOCUMENTO", connection);
                command.CommandType = CommandType.StoredProcedure;
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dtDatatable);

                for(int i=0; i< dtDatatable.Rows.Count; i++)
                {
                    objTipoDocumento tipoDocumento = new objTipoDocumento();

                    tipoDocumento.Id = Int32.Parse(dtDatatable.Rows[i]["ID"].ToString());
                    tipoDocumento.Descripcion = dtDatatable.Rows[i]["DESCRIPCION"].ToString();

                    TiposDocumento.Add(tipoDocumento);
                }

                return TiposDocumento;
            }
            catch (Exception ex)
            {
                throw new Exception("Operación fallida. Error:" + ex.Message);
            }
        }

        public List<objEstadoCivil> ConsultarEstadosCivil()
        {
            try
            {
                SqlDataAdapter dataAdapter;//Se usa para llenar DataTable
                DataTable dtDatatable = new DataTable();
                List<objEstadoCivil> EstadosCivil = new List<objEstadoCivil>();

                command = new SqlCommand("SP_CONSULTAR_ESTADOS_CIVIL", connection);
                command.CommandType = CommandType.StoredProcedure;
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dtDatatable);

                for (int i = 0; i < dtDatatable.Rows.Count; i++)
                {
                    objEstadoCivil estadoCivil = new objEstadoCivil();

                    estadoCivil.Id = Int32.Parse(dtDatatable.Rows[i]["ID"].ToString());
                    estadoCivil.Descripcion = dtDatatable.Rows[i]["DESCRIPCION"].ToString();

                    EstadosCivil.Add(estadoCivil);
                }

                return EstadosCivil;
            }
            catch (Exception ex)
            {
                throw new Exception("Operación fallida. Error:" + ex.Message);
            }
        }

        public List<objPersona> ConsultarPersona(string Nombres)
        {
            try
            {
                SqlDataAdapter dataAdapter;//Se usa para llenar DataTable
                DataTable dtDatatable = new DataTable();
                List<objPersona> Personas = new List<objPersona>();

                command = new SqlCommand("SP_CONSULTAR_PERSONA", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NOMBRES", Nombres);
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dtDatatable);

                for (int i = 0; i < dtDatatable.Rows.Count; i++)
                {
                    objPersona persona = new objPersona();

                    persona.Id = Int32.Parse(dtDatatable.Rows[i]["ID"].ToString());
                    persona.Nombres = dtDatatable.Rows[i]["NOMBRES"].ToString();
                    persona.Apellidos = dtDatatable.Rows[i]["APELLIDOS"].ToString();
                    persona.IdTipoDocumento = Int32.Parse(dtDatatable.Rows[i]["IDTIPODOCUMENTO"].ToString());
                    persona.TipoDocumento = dtDatatable.Rows[i]["TIPODOCUMENTO"].ToString();
                    persona.IdEstadoCivil = Int32.Parse(dtDatatable.Rows[i]["IDESTADOCIVIL"].ToString());
                    persona.EstadoCivil = dtDatatable.Rows[i]["ESTADOCIVIL"].ToString();
                    persona.FechaNacimiento = DateTime.Parse(dtDatatable.Rows[i]["FECHANACIMIENTO"].ToString());
                    persona.ValorAGanar = double.Parse(dtDatatable.Rows[i]["VALORAGANAR"].ToString());

                    Personas.Add(persona);
                }

                return Personas;
            }
            catch (Exception ex)
            {
                throw new Exception("Operación fallida. Error:" + ex.Message);
            }
        }

        public void InsertarPersona(string Nombres,string Apellidos, int IdTipoDocumento, DateTime FechaNacimiento, double ValorGanar, int IdEstadoCivil)
        {
            try
            {
                DataTable dtDatatable = new DataTable();

                command = new SqlCommand("SP_CREAR_PERSONA", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NOMBRES", Nombres);
                command.Parameters.AddWithValue("@APELLIDOS", Apellidos);
                command.Parameters.AddWithValue("@IDTIPODOCUMENTO", IdTipoDocumento);
                command.Parameters.AddWithValue("@FECHANACIMIENTO", FechaNacimiento);
                command.Parameters.AddWithValue("@VALORAGANAR", ValorGanar);
                command.Parameters.AddWithValue("@IDESTADOCIVIL", IdEstadoCivil);
                command.BeginExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Operación fallida. Error:" + ex.Message);
            }
        }
    }
}
