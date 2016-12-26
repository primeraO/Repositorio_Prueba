<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Almacen.aspx.vb" Inherits="Catalogo_Almacen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="CodigoJS.js" type="text/javascript">
    alert("Error al abrir archivo.js");
</script>
 <script type="text/javascript">
         function Obra3(elemValue1, elemValue2) {
         document.getElementById('<%= T_Obra.ClientID %>').value = elemValue1;
         document.getElementById('<%= T_Obra_Desc.ClientID %>').value = elemValue2;
         __doPostBack('T_Obra', 'Text_Changed');
     }
     function BObra3(elemValue1, elemValue2) {
         document.getElementById('<%= TB_Obra.ClientID %>').value = elemValue1;
     }
    </script>
    <title></title>
    <style type="text/css">
        .style2
        {
            width: 96px;
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
           
 .Textos_Azules
{
 color:         #000087;
 font-weight:bold;
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
 
a {
  color: #337ab7;
  text-decoration: none;
               text-align: left;
           }

 .form-control-Readonly {
  display: block;
  padding: 6px 12px;
  font-size: 14px;
  line-height: 1.42857143;
  color: #000;
  background-color: #7ec0ee;
  background-image: none;
  border: 1px solid #ccc;
  border-radius: 4px;
  -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
  -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
       -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
          transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
}  
           .style4
           {
               width: 536px;
           }
           .style5
           {
               width: 49px;
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
                                        Text="Catálogo Almacén" Width="95%"></asp:Label>
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
                                Width="90px" TabIndex="1" />
                            &nbsp;
                            <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                Width="80px" TabIndex="2" />
                            &nbsp;
                            <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                Text="Restaura" Width="108px" TabIndex="3" />
                            &nbsp;
                            <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                Width="100px" TabIndex="4" />
                                        &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
                                                TabIndex="5" />
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
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                                <asp:DropDownList ID="BList_Empresa" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="260px">
                                </asp:DropDownList>
                            </td>
                            <td width="11%">
                                <asp:TextBox ID="TB_Obra" runat="server" CssClass="form-control" 
                                    MaxLength="4" placeholder="Núm." style="text-align: right;" TabIndex="6" 
                                    Width="55px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="11%">
                                <asp:HyperLink ID="Btn_BObra" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="2000">HyperLink</asp:HyperLink>
                            </td>
                            <td width="9%" style="text-align: left">
                                <asp:TextBox ID="TB_Numero" runat="server" Width="55px" TabIndex="6" 
                                placeholder="Núm." CssClass="form-control" 
                                MaxLength="4" style="text-align:right;"></asp:TextBox>
                            </td>
                            <td width="4%" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: right; " width="35%">
                                <asp:TextBox ID="TB_Descripcion" runat="server" Width="239px" TabIndex="7" 
                                placeholder="Almacen" CssClass="form-control" MaxLength="35"></asp:TextBox>
                            </td>
                            <td style="text-align: right; " width="30%">
                                &nbsp;&nbsp;
                                <asp:CheckBox ID="Ch_Baja" runat="server" CssClass="Textos_Azules" 
                                Text="Bajas" TabIndex="2" AutoPostBack="True" />
                            </td>
                            <td width="11%">
                            </td>
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
                                    <asp:BoundField HeaderText="Compañia" >
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Obra" >
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Núm">
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descripcion">
                                    <HeaderStyle Width="640px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Lote Entrada">
                                    <HeaderStyle HorizontalAlign="Center" Width="77px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Lote Salida">
                                    <HeaderStyle HorizontalAlign="Center" Width="77px" />
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
                                CellPadding="1" CellSpacing="4" DataKeyNames="Almacen" Font-Size="Small" 
                                ForeColor="#333333" GridLines="None" Height="16px" ShowHeader="False" 
                                style="top: 152px; left: 86px; " Visible="False" width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Cia" >
                                     <ItemStyle HorizontalAlign="Right" Width="69px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Obra" >
                                     <ItemStyle HorizontalAlign="Right" Width="46px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Almacen" HeaderText="Núm.">
                                    <ItemStyle HorizontalAlign="Right" Width="52px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Aplicación">
                                    <ItemStyle Width="568px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lote_Entrada" HeaderText="Lote Entrada">
                                    <ItemStyle HorizontalAlign="Right" Width="77px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lote_Salida" HeaderText="Lote Salida">
                                    <ItemStyle HorizontalAlign="Right" Width="77px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                                        ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja">
                                    <HeaderStyle Width="40px" />
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
                    <br />
                    <table style="width:100%;">
                        <tr>
                            <td align="left" width="10%">
                                &nbsp;</td>
                            <td align="left" width="10%">
                                <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" Text="Empresa"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:DropDownList ID="List_Empresa" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="740px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td align="left" width="10%">
                                &nbsp;</td>
                            <td align="left" width="10%">
                                <asp:Label ID="Label37" runat="server" CssClass="Textos_Azules" Text="Proyecto"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Obra" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" placeholder="Número" style="text-transform:uppercase;" 
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:HyperLink ID="Btn_Obra" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="2000">HyperLink</asp:HyperLink>
                            </td>
                            <td class="style4">
                                <asp:TextBox ID="T_Obra_Desc" runat="server" CssClass="form-control-Readonly" 
                                    placeholder="Descripcion de Punto" style="text-transform:uppercase;" 
                                    TabIndex="1" Width="320px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" width="10%">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px" width="10%">
                                <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="Núm:" 
                                CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px" width="90px">
                                <asp:TextBox ID="T_Numero" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="8" 
                                Width="55px" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" width="10%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left" width="10%">
                                <asp:Label ID="Label27" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Almacen:"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left">
                                <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" MaxLength="35" 
                                    style="top: 550px; left: 155px; right: 66px; bottom: 70px;" TabIndex="9" 
                                    Width="337px"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="10%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left">
                                <asp:Label ID="Label28" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Height="16px" Text="Aplicación:"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left">
                                <asp:TextBox ID="T_Aplicacion" runat="server" CssClass="form-control" 
                                    MaxLength="50" style="top: 481px; left: 10px;" TabIndex="10" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="10%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left">
                                <asp:Label ID="Label29" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Lote Entrada"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left" width="90px">
                                <asp:TextBox ID="T_Lote_Entrada" runat="server" CssClass="form-control" MaxLength="35" 
                                    style="top: 550px; text-align: right; left: 155px; right: 66px; bottom: 70px;" TabIndex="11" 
                                    Width="49px"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="210px">
                                <asp:Label ID="Label30" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Height="16px" Text="Lote Salida"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: right" width="90px">
                                <asp:TextBox ID="T_Lote_Salida" runat="server" CssClass="form-control" 
                                    MaxLength="50" style="top: 481px; text-align: right; left: 10px;" TabIndex="12" 
                                    Width="49px"></asp:TextBox>
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
