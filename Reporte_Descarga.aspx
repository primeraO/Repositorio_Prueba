<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Reporte_Descarga.aspx.vb" Inherits="Reporte_Descarga" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 269px;
        }
        .style2
        {
            height: 47px;
        }
        .style3
        {
            height: 190px;
        }
        #form1
        {
            height: 803px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #F5F6F7">
    <div style="height: 323px">
    
        <table class="style1">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" CssClass="Textos_Encabezado_Azul" 
                        Text="Descarga de Vales"></asp:Label>

                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
           <asp:Label ID="L_Archivo" runat="server" BorderStyle="None" 
       Font-Names="Arial Narrow" Font-Size="X-Large" ForeColor="#3399FF" 
       style="text-align:center;top: 19px; left: 234px; bottom: 618px; " Height="31px" 
                        Width="809px"></asp:Label>

                    <br />
                    <asp:Button ID="Btn_PDF" runat="server" Text="Descargar PDF" Width="228px" 
                        CssClass="Btn_Azul" />
                    &nbsp;
                    <asp:Button ID="Btn_Regresar" runat="server" Text="Regresar" Width="120px" 
                        CssClass="Btn_Azul" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
