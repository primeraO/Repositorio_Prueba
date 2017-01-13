<%@ Page Language="VB" AutoEventWireup="false" CodeFile="C_Entradas.aspx.vb" Inherits="C_Entradas" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
     <script type="text/javascript">

         function cliente(elemValue1, elemValue2) {
             document.getElementById('<%= T_Cliente.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Cliente_Desc.ClientID %>').value = elemValue2;
             __doPostBack("T_Cliente", "TextChanged");
         }
         function articulo(elemValue1, elemValue2) {
             document.getElementById('<%= T_Articulo.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Articulo_Desc.ClientID %>').value = elemValue2;
             __doPostBack("T_Articulo", "TextChanged");
         }
        
         function regresa(elemValue1) {
             __doPostBack();
         }
         function KeyDownHandler(btn) {
             if (event.keyCode == 13) {
                 event.returnValue = false;
                 event.cancel = true;
                 // aca llamas al evento click del boton que queres que actue, en tu caso es como si apretara el boton de conseguir los datos.
                 btn.click();
             }
         }
             function KeyDownHandlerGuardaArticulo(btn) {
              if (event.keyCode == 13) {
                 event.returnValue = false;
                 event.cancel = true;
                 if (document.getElementById("T_Articulo")=="")
                 {
                        alert("");
                 }
                 else
                 {
                 btn.click();
                }
         }




     }
     function SoloNumeros(evt) {
         if (window.event) {//asignamos el valor de la tecla a keynum
             keynum = evt.keyCode; //IE
         }
         else {
             keynum = evt.which; //FF
         }
         //comprobamos si se encuentra en el rango numérico y que teclas no recibirá.
         if ((keynum > 47 && keynum < 58) || keynum == 8 || keynum == 13 || keynum == 6) {
             return true;
         }
         else {
             return false;
         }
     }

    </script>
    <style type="text/css">
        .style22
        {
            width: 21px;
        }
        .style24
        {
            width: 82px;
        }
        .style25
        {
            width: 109px;
        }
        .style27
        {
            width: 58px;
        }
        .style28
        {
            width: 103px;
        }
        .style29
        {
        }
        .style30
        {
            width: 91px;
        }
        .style31
        {
            width: 108px;
        }
        .style32
        {
            width: 26px;
        }
        .style36
        {
            width: 49px;
        }
        .style39
        {
            width: 393px;
        }
        .style40
        {
            width: 101px;
        }
    </style>
    <script type="text/javascript">

        function txt() {

            ctrToDisable = document.getElementById("T_Area_Desc");

            if (ctrToDisable != null)

                ctrToDisable.value = "txt desde javascript";

        }


</script>
    </head>
<body>
    <center>
        <form id="form1" runat="server" style="width: 984px">
        <div>
            <div>

                <table style="width:100%;">
                    <tr>
                        <td width="20%">
                            &nbsp;</td>
                        <td width="60%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label46" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Cotizacion Clientes"></asp:Label>
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
                            <asp:Image ID="Image1" runat="server" Height="61px" 
                                ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                                Width="174px" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>

            </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <triggers>
              <asp:PostBackTrigger runat="server" ControlID="H_Imprimir2"></asp:PostBackTrigger>
              <asp:PostBackTrigger runat="server" ControlID="H_Procesar"></asp:PostBackTrigger>
            </triggers>
        <ContentTemplate>
            <div>
               
                            <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                                Width="90px" TabIndex="3" />
                            &nbsp;<asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                Width="80px" Visible="False" />
                            <asp:Button ID="H_imprimir2" runat="server" CssClass="Btn_Azul" 
                                Text="Imprimir" Visible="False" />
                            <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                Text="Restaura" Width="110px" />
                            &nbsp;<asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                Width="100px" TabIndex="7" />
                                        &nbsp;<asp:Button ID="H_Procesar" runat="server" CssClass="Btn_Azul" 
                                Text="Procesar" Visible="False" />
                            &nbsp;<asp:Button ID="Ima_Procesar1" runat="server" CssClass="Btn_Azul" 
                                Text="Procesar" Visible="False" />
&nbsp;<asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" />
            </div>

            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">
                         <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" 
                             BorderStyle="Solid" ForeColor="#FF3300" 
                             style="float: none; text-align: center;" Text="Label" Visible="False" 
                             Width="96%"></asp:Label>
                            <br />
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel runat="server" id="Pnl_Busqueda" CssClass="Paneles">
           <%-- <table style="width:100%;">
                    <tr>
                        <td width="30%">
                            &nbsp;</td>
                        <td align="right" class="style27">
                            &nbsp;</td>
                        <td align="left" class="style30">
                    <asp:TextBox ID="TB_Entrada" runat="server" Width="55px" TabIndex="1" 
                                placeholder="Entrada" CssClass="form-control"></asp:TextBox>
                         </td>
                        <td align="left" class="style31">
                            <asp:TextBox ID="T_Fecha_Ini" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" 
                               placeholder="Inicial" BackColor="SkyBlue" ReadOnly="True"></asp:TextBox>
                         </td>
                        <td align="left" class="style32">
                            <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="T_Fecha_Ini" 
                                Format="yyyy mm dd" Separator="/" />
                         </td>
                        <td align="left" class="style31">
                            <asp:TextBox ID="T_Fecha_Fin" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" 
                               placeholder="Final" BackColor="SkyBlue" ReadOnly="True"></asp:TextBox>
                         </td>
                        <td align="left" class="style29">
                            <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="T_Fecha_Fin" 
                                Format="yyyy mm dd" Separator="/" />
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" />
                         </td>
                    </tr>
                </table>--%>
                <table style="width:100%;">
                <tr>
                <td align="left" class="style25">
                            <asp:Label ID="Label12" runat="server" BorderStyle="None" Text="Cliente" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Descripcion" runat="server" CssClass="form-control" 
                                placeholder="" onkeydown="KeyDownHandler(Ima_Buscar)" TabIndex="1" Width="320px" 
                               ></asp:TextBox>
                        </td>
                  <td align="left" class="style25">
                            <asp:Label ID="Label11" runat="server" BorderStyle="None" Text="Fecha Pedido" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Fecha_Inicial" onkeydown="KeyDownHandler(Ima_Buscar)" runat="server" 
                      style="top: 550px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" AutoPostBack="True" ></asp:TextBox>
                            </td>
                        <td align="left" class="style22">
                            <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="T_Fecha_Inicial" 
                                Format="yyyy mm dd" Separator="/" />
                        </td>
                        
                        <td class="style28">
                            <asp:TextBox ID="T_Fecha_Final" onkeydown="KeyDownHandler(Ima_Buscar)" runat="server" 
                      style="top: 550px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" AutoPostBack="True" ></asp:TextBox>
                            </td>
                        <td align="left" class="style22">
                            <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="T_Fecha_Final" 
                                Format="yyyy mm dd" Separator="/" />
                               
                        </td>
                        <td align="left" class="style22"> <asp:CheckBox ID="Check" runat="server" 
                                AutoPostBack="True" Checked="True" /></td>
                        
                </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                      <%--  <td align="left" class="style27">
                            <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="Entrada" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>--%>
                       <%-- <td align="left" class="style24">
                            <asp:TextBox ID="T_Entrada" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="4" 
                                Width="55px" CssClass="form-control" 
                                ReadOnly="True">0</asp:TextBox>
                        </td>--%>
                        <td align="left" class="style25">
                            <asp:Label ID="Label3" runat="server" BorderStyle="None" Text="Pedido" 
                                CssClass="Textos_Azules" Width="92px" Visible="False"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Pedido" runat="server" 
                      style="top: 550px; left: 40px;  bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True" 
                                Visible="False"></asp:TextBox>
                            </td>
                        <td align="left" class="style25">
                            <asp:Label ID="Label17" runat="server" BorderStyle="None" Text="Fecha Pedido" 
                                CssClass="Textos_Azules" Width="92px" Visible="False"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Fecha_Pedido" runat="server" 
                      style="top: 550px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True" 
                                Visible="False"></asp:TextBox>
                            </td>
                        <td align="left" class="style22">
                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="T_Fecha_Lote" 
                                Format="yyyy mm dd" Separator="/" Visible="False" />
                        </td>
                         <td align="left" class="style25">
                            <asp:Label ID="label_total" runat="server" BorderStyle="None" Text="Total Pedido" 
                                CssClass="Textos_Azules" Width="92px" Visible="False"></asp:Label>
                        </td>
                         <td align="left" class="style25">
                            <asp:Label ID="label_total_cantidad" runat="server" BorderStyle="None" Text="Total Pedido" 
                                CssClass="Textos_Azules" Width="92px" Visible="False"></asp:Label>
                        </td>
                        
                        <td align="left">
                            &nbsp;</td>
                          <td width="11%">
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td width="20%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label48" runat="server" BorderStyle="None" 
                                CssClass="Textos_Azules" Text="Cliente"></asp:Label>
                        </td>
                        <td width="12%">
                            <asp:TextBox  ID="T_Cliente" runat="server" CssClass="form-control" onKeyPress="return SoloNumeros(event);"
                                MaxLength="20" style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                                TabIndex="5" Width="150px" onkeydown="KeyDownHandler(Ima_Guarda)" AutoPostBack="True" ></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="1%">
                            <asp:HyperLink ID="H_Cliente" runat="server" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Cliente_Desc" runat="server" CssClass="form-control" 
                                placeholder="" TabIndex="1" Width="360px" BackColor="SkyBlue" 
                                ReadOnly="True" MaxLength="60"></asp:TextBox>
                        </td>
                        <td width="30%">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                      <%--  <td>
                            &nbsp;</td>--%>
                        <td align="left" class="style25">
                            <asp:Label ID="Label1" runat="server" BorderStyle="None" Text="Agente" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Agente" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True" 
                                Visible="False"></asp:TextBox>
                            </td>
                             <td class="style28">
                            <asp:TextBox ID="T_Agente_Desc" runat="server" 
                      style="top: 550px; bottom: 70px; margin-left:-180px!important;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="250px" ReadOnly="True"></asp:TextBox>
                            </td>

                        <td align="left" class="style25">
                            <asp:Label ID="Label2" runat="server" BorderStyle="None" Text="Ejecutivo" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Ejecutivo" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True" Visible="False"></asp:TextBox>
                            </td>
                             <td class="style28">
                            <asp:TextBox ID="T_Ejecutivo_Desc" runat="server" 
                      style="top: 550px; bottom: 70px; margin-left:-390px!important;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="250px" ReadOnly="True"></asp:TextBox>
                            </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                      <%--  <td>
                            &nbsp;</td>--%>
                         <td style="text-align: left" width="10%">
                            <asp:Label ID="Label4" runat="server" BorderStyle="None" 
                                CssClass="Textos_Azules" Text="Articulo"></asp:Label>
                        </td>
                        <td width="8%">
                            <asp:TextBox ID="T_Articulo" runat="server" CssClass="form-control" 
                                MaxLength="20" style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                                TabIndex="5" Width="150px" onkeydown="KeyDownHandlerGuardaArticulo(Ima_Guarda)" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:HyperLink ID="H_Articulo" runat="server" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Articulo_Desc" runat="server" CssClass="form-control" 
                                placeholder="" TabIndex="1" Width="360px" BackColor="SkyBlue" 
                                ReadOnly="True" MaxLength="70"></asp:TextBox>
                        </td>

                      
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                     <td>
                            &nbsp;</td>
                       <td align="left" class="style25">
                            <asp:Label ID="Label5" runat="server" BorderStyle="None" Text="Unidad de Medida" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Unidad_Medida" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True"></asp:TextBox>
                            </td>
                           <td align="left" class="style25">
                            <asp:Label ID="Label6" runat="server" BorderStyle="None" Text="Marca" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Marca" runat="server" 
                      style="top: 550px; left: 155px; bottom: 70px;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True" 
                                Visible="False"></asp:TextBox>
                            </td>
                             <td class="style28">
                            <asp:TextBox ID="T_Marca_Desc" runat="server" 
                      style="top: 550px; bottom: 70px; margin-left:-390px!important;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="250px" ReadOnly="True"></asp:TextBox>
                            </td>
                       
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                     <td>
                            &nbsp;</td>
                         <td align="left" class="style25">
                            <asp:Label ID="Label7" runat="server" BorderStyle="None" Text="Precio Unitario" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Precio_Unitario" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px; text-align: right;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="left" class="style25">
                            <asp:Label ID="Label8" runat="server" BorderStyle="None" Text="Iva" 
                                CssClass="Textos_Azules" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Iva" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px; text-align: right;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" ReadOnly="True" 
                                AutoPostBack="True"></asp:TextBox>
                            </td>
                              <td align="left" class="style25">
                            <asp:Label ID="Label9" runat="server" BorderStyle="None" Text="Cantidad" 
                                CssClass="Textos_Azules" style="margin-left:-250px !important;" Width="92px"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Cantidad_Pedida" runat="server" onKeyPress="return SoloNumeros(event);"   onkeydown="KeyDownHandlerGuardaArticulo(Ima_Guarda)"
                      style="top: 550px; margin-left:-250px !important; left: 155px; right: 66px; bottom: 70px; text-align: right;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px" AutoPostBack="True" ></asp:TextBox>
                            </td>
                    </tr>
                    <tr>   <td>
                            &nbsp;</td>
                  
                            <td align="left" class="style25">
                            <asp:Label ID="Label10" runat="server" BorderStyle="None" Text="Partida" 
                                CssClass="Textos_Azules" Width="92px" Visible="False"></asp:Label>
                        </td>
                        <td class="style28">
                            <asp:TextBox ID="T_Partida" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px; text-align: right;" 
                    MaxLength="10" TabIndex="5" CssClass="form-control" Width="80px"  ReadOnly="True" 
                                Visible="False" ></asp:TextBox>
                            </td>
                    </tr>
                    
                </table>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td width="100">
                            &nbsp;</td>
                        <td align="left" class="style27">
                            <%--<asp:Label ID="Label26" runat="server" BorderStyle="None" Text="XML" 
                                CssClass="Textos_Azules"></asp:Label>--%>
                        </td>
                        <td align="left" class="style24">
      <%--<asp:FileUpload id="fileUploader1" runat="server" />--%>
                        </td>
                        <td align="left" class="style36">
                            <%--<asp:Label ID="Label27" runat="server" BorderStyle="None" Text="UUID" 
                                CssClass="Textos_Azules" Visible="False"></asp:Label>--%>
                        </td>
                        <td class="style39" align="left">
                            <%--<asp:TextBox ID="L_UUID" runat="server" BackColor="SkyBlue" 
                                MaxLength="10" style="text-align: left" Width="300px" Visible="False"></asp:TextBox>--%>
                            </td>
                        <td align="left" class="style40">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                </table>
                <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="false">
                                  <div style="overflow:hidden; height:35px; width:100%; float:left" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="2">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Partida">
                                            <HeaderStyle  Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha" >
                                            <HeaderStyle Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Articulo">
                                            <HeaderStyle  Width="149px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripcion">
                                            <HeaderStyle  Width="280px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Precio Unitario">
                                            <HeaderStyle  Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="IVA">
                                            <HeaderStyle  Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cantidad">
                                            <HeaderStyle  Width="90px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Total" >
                                            <HeaderStyle Width="60px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                                <asp:BoundField HeaderText="Cambio" />
                                                <asp:BoundField HeaderText="Baja" />
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" 
                 style="top: 152px; left: 86px; " DataKeyNames="Partida" Font-Size="Small" 
                             Width="964px" Height="16px" CellSpacing="2" ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" Visible="False" >
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Partida" HeaderText="Partida" >
                    <ItemStyle Width="50px" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Articulo" HeaderText="Articulo">
                    <ItemStyle HorizontalAlign="Left"  Width="149px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                    <ItemStyle HorizontalAlign="Left"  Width="280px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio_Unitario" HeaderText="Precio_Unitario" 
                        DataFormatString="{0:N2}" >
                      <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Iva" DataFormatString="{0:N2}" HeaderText="Iva">
                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Cantidad" 
                        HeaderText="Cantidad" DataFormatString="{0:N2}"><ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Total" DataFormatString="{0:N2}" HeaderText="Total">
                    <ItemStyle HorizontalAlign="Right"  Width="60px"/>
                    </asp:BoundField>
                   <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                                        ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:ButtonField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </div>
            </asp:Panel>

           <%-- ----------------------------------------------------------------%>
               <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Left" Visible="false">
                                  <div style="overflow:hidden; height:35px; width:100%; float:left" >
                             <asp:GridView id="GridView2" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="2">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Pedido">
                                            <HeaderStyle  Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cliente">
                                            <HeaderStyle  Width="100px" />
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripcion">
                                            <HeaderStyle  Width="350px" />
                                                <ItemStyle Width="350px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha" >
                                            <HeaderStyle  Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Partidas">
                                            <HeaderStyle  Width="50px" />
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="None" 
                 style="top: 152px; left: 86px; " DataKeyNames="Pedido" Font-Size="Small" Width="964px" Height="16px" CellSpacing="2" ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" Visible="False" >
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Pedido" HeaderText="Pedido" >
                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" >
                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                    <ItemStyle HorizontalAlign="Left"  Width="350px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                      <ItemStyle HorizontalAlign="Right" Width="50px" />
                    </asp:BoundField>
                   <asp:ButtonField ButtonType="Image" CommandName="Partida" HeaderText="Partida" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Baja" 
                        DataTextField="Partida">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:ButtonField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </div>
            </asp:Panel>


          <%-- ----------------------------------------------------------------%>

            </asp:Panel>
            <div>
                
                
                
            </div>
               
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="42%">
                            &nbsp;</td>
                        <td width="16%">
                            <br />
             <asp:HiddenField ID="Movimiento" runat="server" />
                        </td>
                        <td width="42%">
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        
        </div>
          </div>
        <%--<asp:ButtonField CommandName="Partidas" HeaderText="Partidas" Text="Partidas">
                    <ItemStyle Width="50px" />
                    </asp:ButtonField>--%><%--<asp:ButtonField CommandName="Partidas" HeaderText="Partidas" Text="Partidas">
                    <ItemStyle Width="50px" />
                    </asp:ButtonField>--%>


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
