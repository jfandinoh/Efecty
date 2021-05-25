<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarPersona.aspx.cs" Inherits="AppPersona.ConsultarPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            <h1>Consultar persona</h1>

            <table>
                <tr>
                    <td>
                        <label>Filtro</label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFiltro"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td td colspan="2" style="text-align:center">
                        <asp:DataGrid runat="server" ID="Registros" ></asp:DataGrid>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:TextBox runat="server" ID="txtResultado" Enabled="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button runat="server" ID="btnConsultar" Text="Consultar registro" OnClick="btnConsultar_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:HyperLink ID="Crear" runat="server" NavigateUrl="~/CrearPersona.aspx" Text="Crear registro"></asp:HyperLink>
                    </td>
                </tr>

                <tfoot>
                    
                </tfoot>
            </table>
        </div>
    </form>
</body>
</html>
