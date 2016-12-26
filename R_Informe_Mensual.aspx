<%@ Page Language="VB" AutoEventWireup="false" CodeFile="R_Informe_Mensual.aspx.vb" Inherits="R_Informe_Mensual" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
 

.Textos_Encabezado_Azul
{
 color:         #000087;
 font-weight:bold;
 font:          normal 700 36px/1 "Calibri", sans-serif;
    }

 .Textos_Azules
{
 color:         #000087;
 font-weight:bold;
} 

        .style2
        {
            width: 53px;
        }
    .form-control {
  display: block;
  padding: 6px 12px;
  font-size: 14px;
  line-height: 1.42857143;
  color: #555;
  background-color: #fff;
  background-image: none;
  border: 1px solid #ccc;
  border-radius: 4px;
  -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
  -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
       -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
          transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
}  
        .style3
        {
            width: 109px;
        }
        .style4
        {
            width: 31px;
        }
        .style5
        {
            width: 44px;
        }
        .style6
        {
            width: 97px;
        }
        .style8
        {
        }

 .Btn_Azul
{
display:       inline-block;
padding:       8px 20px;
background:    #0f78d7 repeat-x;
background:    -moz-linear-gradient(#429ff3, #0f78d7);
background:    -o-linear-gradient(#429ff3, #0f78d7);
background:    -webkit-linear-gradient(#429ff3, #0f78d7);
background:    linear-gradient(#429ff3, #0f78d7);
border-radius: 999px;
color:         #fff;
font:          normal 700 16px/1 "Calibri", sans-serif;
text-shadow:   1px 1px 0 #000;
}  

        .style9
        {
            width: 22px;
        }
        .style10
        {
            width: 7px;
        }
        .style11
        {
            width: 161px;
        }
        .style12
        {
            width: 91px;
        }
        .Bloque_Fondo  
        {
    	    position: fixed;
    	    z-index: 98;
    	    top: 0px;
    	    left: 0px;
    	    right: 0px;
    	    bottom: 0px;
            
        }
        .Contenido_Pregunta
        {
            position: fixed;
    	    z-index: 99;
    	    width: 80px;
    	    height: 80px;
    	    margin-left:32%;
    	    margin-top:200px;
        }
    </style>
      <link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>
       <style type="text/css">
          .overlay  
        {
    	    position: fixed;
    	    z-index: 98;
    	    top: 0px;
    	    left: 0px;
    	    right: 0px;
    	    bottom: 0px;
            
        }
        .overlayContent
        {
    	    z-index: 99;
    	    margin: 250px auto;
    	    width: 80px;
    	    height: 80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        .overlayContent img
        {
    	    width: 150px;
    	    height: 150px;
        }
           </style>
</head>
<body>
<center>
    <form id="form1" runat="server" style="width:984px;">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <triggers>
              <asp:PostBackTrigger runat="server" ControlID="Btn_Acepta_Imp"></asp:PostBackTrigger>
            </triggers>
            <ContentTemplate>
    <div>
    
        <table style="width:100%;">
            <tr>
                <td width="20%">
                    &nbsp;</td>
                <td align="center" width="60%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Selección de Reporte"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Compañia" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="#000087"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Obra" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="#000087"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Usuario" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="#000087"></asp:Label>
                            </asp:Panel>

                        </td>
                <td width="20%">
                    &nbsp;</td>
            </tr>
        </table>
                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">
                         <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" 
                             BorderStyle="Solid" ForeColor="#FF3300" 
                             style="float: none; text-align: center;" Text="Label" Visible="False" 
                             Width="96%"></asp:Label>
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
        <table align="center">
            <tr>
                <td class="style10">
                </td>
                <td align="left" class="style2">
                            <asp:Label ID="Label17" runat="server" BorderStyle="None" 
                                CssClass="Textos_Azules" Text="Fecha Inicio" Width="85px"></asp:Label>
                        </td>
                <td align="center" class="style3">
                            <asp:TextBox ID="T_Fecha_Inicio" runat="server" Height="18px" 
                                MaxLength="35" style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                                TabIndex="4" Width="80px"></asp:TextBox>
                        </td>
                <td align="center" class="style4">
                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="T_Fecha_Inicio" 
                                Format="yyyy mm dd" Separator="/" />
                        </td>
                <td align="left" class="style5">
                            <asp:Label ID="Label26" runat="server" BorderStyle="None" 
                                CssClass="Textos_Azules" Text="Fecha Fin" Width="79px"></asp:Label>
                        </td>
                <td align="center" class="style6">
                            <asp:TextBox ID="T_Fecha_Fin" runat="server" Height="18px" 
                                MaxLength="35" style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                                TabIndex="4" Width="80px"></asp:TextBox>
                        </td>
                <td align="left" class="style9">
                            <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="T_Fecha_Fin" 
                                Format="yyyy mm dd" Separator="/" />
                        </td>
                <td class="style11">
                    <asp:CheckBox ID="CB_Detalle" runat="server" CssClass="Textos_Azules" 
                        Text="Detalle" />
                </td>
            </tr>
        </table>
        <table style="width:21%;" align="center">
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td align="center" class="style6">
                            <asp:Button ID="Ima_Imprimir" runat="server" CssClass="Btn_Azul" Text="Imprimir" 
                                Width="110px" />
                                                </td>
                <td align="left" class="style12">
                                                <asp:Button ID="Ima_Salir" runat="server" 
                                CssClass="Btn_Azul" Text="Salir" />
                            </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    <div id="Div" runat="server">
            <asp:Panel ID="Pnl_Tipo_Impresion" runat="server" 
            BackColor="#FFFF99" Height="120px" HorizontalAlign="Center" Visible="False" 
            Width="500px" CssClass="Contenido_Pregunta">
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right" width="170px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:RadioButtonList ID="RB_Tipo_Impresion" runat="server">
                                    <asp:ListItem Value="Vista_Previa" Selected="True">Vista Previa</asp:ListItem>
                                    <asp:ListItem>Impresora</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%; height: 60px;">
                        <tr>
                            <td style="text-align:center">
                                <asp:Button ID="Btn_Acepta_Imp" runat="server" 
                            CssClass="Btn_Azul" Text="Aceptar" />
                                
                            </td>
                            <td style="text-align:center">
                            <asp:Button ID="Btn_Cancela_Imp" runat="server" 
                            CssClass="Btn_Azul" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
        </div>
         </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                
                <img src="Imagenes/cargando.gif" alt="Loading"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
    </center>
</body>
</html>
