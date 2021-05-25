<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearPersona.aspx.cs" Inherits="AppPersona.CrearPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <h1>Registrar persona</h1>

            <table style="margin:0 auto; text-align:left">
                <thead></thead>
                <tbody>
                    <tr>
                        <td>
                            <label>Nombres</label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Apellidos</label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAPellidos"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <label>Fecha nacimiento</label>
                        </td>
                        <td>
                            <asp:Calendar ID = "Calendar" runat = "server" SelectionMode="DayWeekMonth" OnSelectionChanged="Calendar_SelectionChanged">
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Tipo documento</label>
                        </td>
                        <td>
                            <asp:DropDownList id="ListaTiposDocumento"
                                AutoPostBack="True"
                                runat="server" OnSelectedIndexChanged="ListaTiposDocumento_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Estado civil</label>
                        </td>
                        <td>
                            <asp:DropDownList id="ListEstadoCivil"
                                AutoPostBack="True"
                                runat="server" OnSelectedIndexChanged="ListEstadoCivil_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Valor a ganar</label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtValor" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:TextBox runat="server" ID="txtResultado" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:Button runat="server" ID="btnCrear" Text="Insertar registro" OnClick="btnCrear_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:HyperLink ID="Consultar" runat="server" NavigateUrl="~/ConsultarPersona.aspx" Text="Consultar Regitros"></asp:HyperLink>
                        </td>
                    </tr>

                </tbody>

                <tfoot>
                    
                </tfoot>
            </table>

        </div>
    </form>
</body>
</html>
