﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Economico.aspx.vb" Inherits="Catalogo_Economico" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
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
        <form id="form1" runat="server" style="width: 984px">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
            <div>
            <div>

                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">

                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Catálogo Económico" Width="95%"></asp:Label>
                                <br />
                                </asp:Panel>

                        </td>
                        <td style="text-align: right" width="15%">
                            <asp:Image ID="Image1" runat="server" Height="61px" 
                                ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                                Width="174px" />
                            <br />
                        </td>
                    </tr>
                </table>

                <table style="width:100%;">
                    <tr>
                        <td class="style6" style="text-align: center">
                            <asp:Label ID="Lbl_Compañia" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" style="text-align: center">
                            <asp:Label ID="Lbl_Obra" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="Lbl_Usuario" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                </table>

                
                                    <table style="width:100%;">
                                        <tr>
                                            <td width="10%" style="text-align: right">
                                            
                                &nbsp;</td>
                                            
                                            <td style="text-align: center" width="80%">
                                                <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" 
                                                    Text="Busca" />
                                                <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" 
                                                    Text="Alta" Width="80px" />
                                                <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                                    Text="Restaura" Width="110px" />
                                                <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" 
                                                    Text="Guarda" Width="100px" />
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" 
                                                    Text="Salir" />
                                                <asp:Button ID="Ima_Importar" runat="server" CssClass="Btn_Azul" 
                                                    Text="Importar" Visible="False" />
                                            </td>
                                            <td style="text-align: right" width="10%">
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
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td class="style5" width="11%">
                            </td>
                            <td width="11%">
                                <asp:TextBox ID="TB_Numero" runat="server" Width="97%" TabIndex="13" placeholder="Num." 
                                CssClass="form-control" ></asp:TextBox>
                            </td>
                            <td style="text-align: right" width="4%">
                                &nbsp;</td>
                            <td style="text-align: left" class="style3">
                                <asp:TextBox ID="TB_Descripcion" runat="server" Width="91%" TabIndex="14" 
                                placeholder="Descripcion" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td width="12%">
                                <asp:CheckBox ID="Ch_Baja" runat="server" Text="Bajas" AutoPostBack="True" 
                                CssClass="Textos_Azules" />
                            </td>
                            <td width="12%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                        <div style="overflow:hidden; height:35px; width:100%; float:left">
                            <asp:GridView ID="Cabecera" runat="server" AutoGenerateColumns="False" 
                                CellPadding="1" CellSpacing="4" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="35px" ShowHeaderWhenEmpty="True" 
                                style="top: 152px; left: 86px; " Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField HeaderText="Núm.">
                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descripción">
                                    <HeaderStyle Width="194px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Aplicación">
                                    <HeaderStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Marca">
                                    <HeaderStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Modelo">
                                    <HeaderStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Serie">
                                    <HeaderStyle Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ver">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cambio">
                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Baja">
                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="2" CellSpacing="4" DataKeyNames="Numero" Font-Size="Small" 
                                ForeColor="#333333" GridLines="None" Height="16px" ShowHeader="False" 
                                style="top: 152px; left: 86px; " Visible="False" Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Numero" HeaderText="Num.">
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                    <ItemStyle HorizontalAlign="Left" Width="194" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Aplicacion" HeaderText="Aplicacion">
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Marca" HeaderText="Marca">
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Modelo" HeaderText="Modelo">
                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Serie" HeaderText="Serie">
                                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:ButtonField>
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
                </asp:Panel>
                <br />
                <asp:Panel ID="Pnl_Registro" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" width="10%" height="40px">
                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" 
                                Text="Núm."></asp:Label>
                            </td>
                            <td style="text-align: left" width="24%" height="40px">
                                <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" 
                                Width="80%" ></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="5%">
                                &nbsp;</td>
                            <td style="text-align: left" width="15%" height="40px">
                                <asp:Label ID="Label28" runat="server" CssClass="Textos_Azules" 
                                Text="Descripción ECO"></asp:Label>
                            </td>
                            <td style="text-align: left" width="29%" height="40px">
                                <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="5%">
                                &nbsp;</td>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" 
                                Text="Aplicación"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Aplicacion" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label29" runat="server" CssClass="Textos_Azules" 
                                Text="Descripción Motor"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Desc_Motor" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label30" runat="server" CssClass="Textos_Azules" Text="Marca"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Marca" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label33" runat="server" CssClass="Textos_Azules" 
                                Text="Marca Motor"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Marca_Motor" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label31" runat="server" CssClass="Textos_Azules" Text="Modelo"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Modelo" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" 
                                Text="Modelo Motor"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Modelo_Motor" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label32" runat="server" CssClass="Textos_Azules" Text="Serie"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Serie" runat="server" CssClass="form-control" 
                                Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px">
                                <asp:Label ID="Label35" runat="server" CssClass="Textos_Azules" 
                                Text="Serie Motor"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Serie_Motor" runat="server" CssClass="form-control" 
                                    Width="80%"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" width="10%">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Azules" 
                                    Text="F. Entrada"></asp:Label>
                            </td>
                            <td height="40" width="18%">
                                <asp:TextBox ID="T_Fecha_Entrada" runat="server" CssClass="form-control" 
                                    Width="127px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="5%">
                                <rjs:PopCalendar ID="PopCalendar_FechaEntrada" runat="server" 
                                    Control="T_Fecha_Entrada" Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td style="text-align: right" width="6%">
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label37" runat="server" CssClass="Textos_Azules" 
                                    Text="F. Salida"></asp:Label>
                            </td>
                            <td width="17%">
                                <asp:TextBox ID="T_Fecha_Salida" runat="server" CssClass="form-control" 
                                    EnableTheming="True" Width="127px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <rjs:PopCalendar ID="PopCalendar_Fecha_Salida" runat="server" 
                                    Control="T_Fecha_Salida" Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label38" runat="server" CssClass="Textos_Azules" Text="Estatus"></asp:Label>
                            </td>
                            <td height="40">
                                <asp:TextBox ID="T_Estatus" runat="server" CssClass="form-control" Width="31%"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
             <asp:HiddenField ID="Movimiento" runat="server" />

            </div>
        
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
