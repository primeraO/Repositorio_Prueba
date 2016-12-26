<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Tipo_Cambio.aspx.vb" Inherits="Catalogo_Tipo_Cambio" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
 <title></title>
<script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
</script>
<script type="text/javascript">
    function Moneda(elemValue1, elemValue2) {
        document.getElementById('<%= T_Moneda.ClientID %>').value = elemValue1;
        document.getElementById('<%= T_Moneda_Desc.ClientID %>').value = elemValue2;
        __doPostBack("T_Moneda", "TextChanged");
    }
</script>
<style type="text/css">
        .style9
        {
            width: 100px;
        }
        .style35
        {
            width: 123px;
        }
        .style33
        {
            width: 58px;
        }
        .style12
        {
            width: 37px;
        }
        .style36
        {
            width: 151px;
        }
        .style37
        {
            width: 48px;
        }
        .style38
        {
            width: 107px;
        }
        .style39
        {
            width: 120px;
        }
        .style40
        {
            width: 83px;
        }
        .style41
        {
            width: 126px;
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
                                        Text="Catálogo Tipo Cambio" Width="95%"></asp:Label>
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
                                        <td width="10%">
                                        
                                            &nbsp;</td>
                                       
                                        <td width="80%" style="text-align: center">
                                        
                            <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                                Width="90px" TabIndex="16" />
                            &nbsp;
                            <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                Width="80px" />
                            &nbsp;
                            <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                Text="Restaura" Width="110px" />
                            &nbsp;
                            <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                Width="100px" TabIndex="18" />
                                        &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" />
                                            </td>
                                       
                                        <td width="10%">
                                        
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
                            <br />
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                            </td>
                            <td width="9%" style="text-align: left; margin-left: 40px;">
                                <asp:TextBox ID="TB_Numero" runat="server" Width="55px" TabIndex="13" 
                                placeholder="Moneda" CssClass="form-control" 
                                MaxLength="4" style="text-align:right;"></asp:TextBox>
                            </td>
                            <td width="4%" style="text-align: left; margin-left: 40px;">
                                &nbsp;</td>
                            <td style="text-align: right; " width="35%">
                                <asp:TextBox ID="TB_Descripcion" runat="server" Width="276px" TabIndex="14" 
                                placeholder="Descripción Moneda" CssClass="form-control" MaxLength="50"></asp:TextBox>
                            </td>
                            <td style="text-align: left; " width="30%">
                                &nbsp;&nbsp;
                                <asp:CheckBox ID="Ch_Baja" runat="server" CssClass="Textos_Azules" 
                                Text="Bajas" TabIndex="15" AutoPostBack="True" />
                            </td>
                            <td width="11%">
                            </td>
                        </tr>
                        <tr>
                            <td width="11%">
                                &nbsp;</td>
                            <td style="text-align: left; margin-left: 40px;" width="9%">
                                &nbsp;</td>
                            <td style="text-align: left; margin-left: 40px;" width="4%">
                                &nbsp;</td>
                            <td style="text-align: right;" width="35%">
                                &nbsp;</td>
                            <td style="text-align: left;" width="30%">
                                &nbsp;</td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>

                    <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                                  <div style="overflow:hidden; height:35px; width:100%; float:left" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="4">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Núm">
                                            <HeaderStyle  Width="40px" HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Moneda" >
                                            <HeaderStyle Width="429px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha">
                                            <HeaderStyle  Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Tipo de Cambio">
                                            <HeaderStyle  Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cambio Compras" Visible="False">
                                            <HeaderStyle  Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Ver" >
                                            <HeaderStyle Width="40px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Cambio" >
                                            <HeaderStyle Width="50px"  HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Baja" >
                                            <HeaderStyle Width="40px"  HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" 
                 style="top: 152px; left: 86px; " DataKeyNames="Mon_Numero,Fecha" Font-Size="Small" 
                             Width="964px" Height="16px" CellSpacing="4" Visible="False" 
                   ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" Visible="False" >
                    <ItemStyle Width="10px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Mon_Numero" HeaderText="Núm." >
                    <ItemStyle HorizontalAlign="Right" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Moneda_Desc" HeaderText="Moneda" >
                    <ItemStyle Width="429px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                     <ItemStyle HorizontalAlign="left"  Width="100px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Cambio" DataFormatString="{0:N2}" 
                        HeaderText="Tipo de Cambio">
                    <ItemStyle HorizontalAlign="Right"  Width="150px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Cambio_Compras" DataFormatString="{0:N2}" 
                        HeaderText="Cambio Compras" Visible="False">
                    <ItemStyle HorizontalAlign="Right" Width="150px" />
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
                            <td class="style9">
                                &nbsp;</td>
                            <td align="left" class="style35">
                                <asp:Label ID="Label39" runat="server" BorderStyle="None" Text="Moneda" 
                                CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td class="style33" align="left">
                                <asp:TextBox ID="T_Moneda" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="10" 
                                Width="30px" CssClass="form-control" AutoPostBack="True">0</asp:TextBox>
                            </td>
                            <td class="style12">
                                <asp:HyperLink ID="H_Moneda" runat="server" BorderStyle="None" Enabled="False" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td class="style36" align="left">
                                <asp:TextBox ID="T_Moneda_Desc" runat="server" MaxLength="50" 
                        style="top: 481px; left: 10px; text-align: left;" 
                        TabIndex="30" CssClass="form-control">Pesos</asp:TextBox>
                            </td>
                            <td class="style37" align="left">
                                <asp:Label ID="Label32" runat="server" BorderStyle="None" 
                                CssClass="Textos_Azules" Text="Fecha"></asp:Label>
                            </td>
                            <td class="style38" align="left">
                                <asp:TextBox ID="T_Fecha" runat="server" CssClass="form-control" 
                                MaxLength="10" style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                                TabIndex="2" Width="80px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="T_Fecha" 
                                Format="yyyy mm dd" Separator="/" />
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" width="100">
                                &nbsp;</td>
                            <td align="left" class="style39" height="40px">
                                <asp:Label ID="Label17" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Tipo de Cambio"></asp:Label>
                            </td>
                            <td class="style40" height="40px" style="text-align: left">
                                <asp:TextBox ID="T_Cambio" runat="server" CssClass="form-control" 
                                    MaxLength="50" 
                                    style="top: 550px; left: 155px; right: 66px; bottom: 70px; text-align: right;" 
                                    TabIndex="17" Width="50px">0.00</asp:TextBox>
                            </td>
                            <td align="left" class="style41" height="40px">
                                <asp:Label ID="Label40" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Cambio Compras" Visible="False"></asp:Label>
                            </td>
                            <td height="40px">
                                <asp:TextBox ID="T_Cambio_Compras" runat="server" CssClass="form-control" 
                                    MaxLength="50" 
                                    style="top: 550px; left: 155px; right: 66px; bottom: 70px; text-align: right;" 
                                    TabIndex="17" Width="50px" Visible="False">0.00</asp:TextBox>
                            </td>
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

