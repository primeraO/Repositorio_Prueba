<%@ Page Language="VB" AutoEventWireup="false" CodeFile="R_0011.aspx.vb" Inherits="R_0011" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
    </script>
    <script type="text/javascript">
        function Articulos(elemValue1, elemValue2, elemValue3, elemValue4) {
            if (elemValue4 == "2") {
                document.getElementById('<%= T_Articulo_Final.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Art_Desc_Final.ClientID %>').value = elemValue2;
                __doPostBack("T_Articulo_Final", "TextChanged");
            }
            else {
                document.getElementById('<%= T_Articulo_Inicial.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Art_Desc_Inicial.ClientID %>').value = elemValue2;
                __doPostBack("T_Articulo_Inicial", "TextChanged");
            }
        }
    </script>
    <style type="text/css">
        .style4
        {
            text-align: left;
        }
        .style6
        {
            text-align: left;
        }
        .style8
        {
            width: 0;
        }
        .style12
        {
            width: -500;
        }
        .style13
        {
            width: 29px;
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
    <link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>

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
                        <td width="60%">
                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Reporte Auxiliar de Movimiento"></asp:Label>
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
                        <td style="text-align: right" width="20%">
                             <asp:Image ID="Img_Logotipo" runat="server" Height="61px" 
                             style="text-align: right" 
                              Width="174px" />
                                    <br />
                         </td>
                    </tr>
                </table>
                <div style="height: 8px;"></div>
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
    
                <table width="100%">
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
    
                <div style="height: 8px"></div>
                <asp:Panel ID="Panel2" runat="server" CssClass="Paneles">
                    <table style="width: 100%;">
                        <tr>
                            <td width="50%">
                                <asp:Label ID="Label29" runat="server" CssClass="Textos_Azules" Text="Inicial"></asp:Label>
                                &nbsp;
                            </td>
                            <td width="50%">
                                <asp:Label ID="Label30" runat="server" CssClass="Textos_Azules" Text="Final"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" Text="Fecha"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Fecha_Inicial" runat="server" 
                                    CssClass="form-control-Readonly" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <rjs:PopCalendar ID="PC_Fecha_Inicial" runat="server" Control="T_Fecha_Inicial" 
                                    Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td width="250px">
                                &nbsp;</td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                <asp:TextBox ID="T_Fecha_Final" runat="server" CssClass="form-control-Readonly" 
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <rjs:PopCalendar ID="PC_Fecha_Final" runat="server" Control="T_Fecha_Final" 
                                    Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td width="250px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label28" runat="server" CssClass="Textos_Azules" Text="Artículo"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Articulo_Inicial" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Articulo_Inicial" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td width="250px">
                                <asp:TextBox ID="T_Art_Desc_Inicial" runat="server" 
                                    CssClass="form-control-Readonly" Width="255px"></asp:TextBox>
                            </td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                <asp:TextBox ID="T_Articulo_Final" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Articulo_Final" runat="server" 
                                    CssClass="Btn_Proveedor" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" 
                                    Width="29px" />
                            </td>
                            <td width="250px">
                                <asp:TextBox ID="T_Art_Desc_Final" runat="server" 
                                    CssClass="form-control-Readonly" Width="255px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td class="style4" width="70px">
                            &nbsp;</td>
                        <td width="115px">
                            &nbsp;</td>
                        <td class="style13">
                                        &nbsp;</td>
                        <td width="260px">
                            &nbsp;</td>
                        <td width="14px">
                            &nbsp;</td>
                        <td class="style12" width="115px">
                            &nbsp;</td>
                        <td width="20px">
                                        &nbsp;</td>
                        <td width="260px">
                            &nbsp;</td>
                    </tr>
                 </table>
    
    </div>
    <div>

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
