<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Cliente.aspx.vb" Inherits="Catalogo_Cliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="CodigoJS.js" type="text/javascript">
    alert("Error al abrir archivo.js");
</script>

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
           .style19
        {
            width: 264px;
            text-align: right;
            height: 30px;
        }
        .style20
        {
            width: 212px;
            text-align: left;
            height: 30px;
        }
        .style21
        {
            text-align: right;
            width: 164px;
            height: 30px;
        }
        .style22
        {
            height: 30px;
        }
        .style8
        {
            width: 264px;
            text-align: right;
        }
        .style9
        {
            width: 212px;
            text-align: left;
        }
        .style10
        {
            text-align: left;
            width: 164px;
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
                                        Text="Catalogo Cliente" Width="95%"></asp:Label>
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
                                &nbsp;</td>
                            <td width="11%">
                                <asp:TextBox ID="TB_Numero" runat="server" CssClass="form-control" 
                                    MaxLength="4" placeholder="Núm." style="text-align:right;" TabIndex="6" 
                                    Width="55px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td width="9%" style="text-align: left">
                                <asp:TextBox ID="TB_Descripcion" runat="server" CssClass="form-control" 
                                    MaxLength="35" placeholder="Almacen" TabIndex="7" Width="239px"></asp:TextBox>
                            </td>
                            <td width="4%" style="text-align: left">
                                &nbsp;</td>
                            <td style="text-align: right; " width="35%">
                                <asp:TextBox ID="TB_RFC" runat="server" CssClass="form-control" MaxLength="35" 
                                    placeholder="RFC" TabIndex="8" Width="239px"></asp:TextBox>
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
                                    <asp:BoundField HeaderText="Núm">
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nombre">
                                    <HeaderStyle Width="640px" />
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
                                CellPadding="1" CellSpacing="4" DataKeyNames="Numero" Font-Size="Small" 
                                ForeColor="#333333" GridLines="None" Height="16px" ShowHeader="False" 
                                style="top: 152px; left: 86px; " Visible="False" width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Numero" HeaderText="Núm." >
                                     <ItemStyle HorizontalAlign="Right" Width="52px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Razon_Social" HeaderText="Nombre" >
                                     <ItemStyle Width="568px" />
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
                <table style="width:100%;">
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label58" runat="server" CssClass="Textos_Azules" 
                                Font-Bold="True" ForeColor="#000087" Text="Numero" Enabled="False"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" 
                                MaxLength="13" style="top: 250px; text-transform:uppercase; left: 265px; " 
                                TabIndex="9" Width="155px"></asp:TextBox>
                        </td>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style22" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label41" runat="server" CssClass="Textos_Azules" 
                                Font-Bold="True" ForeColor="#000087" Text="RFC *"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_RFC" runat="server" CssClass="form-control" MaxLength="13" 
                                style="top: 250px; text-transform:uppercase; left: 265px; " TabIndex="10" 
                                Width="155px"></asp:TextBox>
                        </td>
                        <td class="style21">
                        </td>
                        <td class="style22" style="text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label42" runat="server" CssClass="Textos_Azules" 
                                Text="Razón Social*"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Razon_Social" runat="server" MaxLength="200" 
                                style="top: 280px; left: 265px; " TabIndex="11" Width="410px" 
                                CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style21">
                        </td>
                        <td class="style22" style="text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" 
                                Text="Calle&nbsp;&nbsp; "></asp:Label>
                        </td>
                        <td class="style9">
                            <asp:TextBox ID="T_Direccion" runat="server" MaxLength="100" 
                                style="top: 560px; left: 145px; text-align: left;" TabIndex="12" 
                                ToolTip="Dirección" Width="410px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style10">
                            <asp:Label ID="Label53" runat="server" CssClass="Textos_Azules" 
                                Text="No. Int.&nbsp;&nbsp; "></asp:Label>
                            <asp:TextBox ID="T_Num_Int" runat="server" MaxLength="20" 
                                style="top: 620px; left: 725px; text-align: left;" TabIndex="13" 
                                ToolTip="Núm. Int." Width="56px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: left">
                            &nbsp;&nbsp;
                            <asp:Label ID="Label45" runat="server" CssClass="Textos_Azules" 
                                Text="No. Ext.&nbsp;&nbsp; "></asp:Label>
                            <asp:TextBox ID="T_Num_Ext" runat="server" MaxLength="20" 
                                style="top: 620px; left: 725px; text-align: left;" TabIndex="14" 
                                ToolTip="Núm. Ext." Width="84px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label46" runat="server" CssClass="Textos_Azules" 
                                Text="Colonia. "></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Colonia" runat="server" MaxLength="60" 
                                style="top: 590px; left: 145px; " TabIndex="15" ToolTip="Colonia" 
                                Width="410px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style22" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label47" runat="server" CssClass="Textos_Azules" 
                                Text="Ciudad. *"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Ciudad" runat="server" MaxLength="40" 
                                style="top: 620px; left: 145px; " TabIndex="16" ToolTip="Ciudad" 
                                Width="410px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style21">
                            <asp:Label ID="Label55" runat="server" CssClass="Textos_Azules" Text="Estado "></asp:Label>
                        </td>
                        <td class="style22" style="text-align: left">
                            <asp:TextBox ID="T_Estado" runat="server" MaxLength="40" 
                                style="top: 620px; left: 360px; " TabIndex="17" ToolTip="Estado" 
                                Width="228px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label48" runat="server" CssClass="Textos_Azules" Text="Pais. *"></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Pais" runat="server" MaxLength="40" 
                                style="top: 620px; left: 560px; text-align: left;" TabIndex="18" ToolTip="Pais" 
                                Width="410px" CssClass="form-control">MEXICO</asp:TextBox>
                        </td>
                        <td class="style21">
                            <asp:Label ID="Label56" runat="server" CssClass="Textos_Azules" Text="C.P."></asp:Label>
                        </td>
                        <td class="style22" style="text-align: left">
                            <asp:TextBox ID="T_CP" runat="server" MaxLength="6" 
                                style="top: 680px; left: 750px; text-align: left;" TabIndex="19" ToolTip="CP" 
                                Width="228px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label49" runat="server" CssClass="Textos_Azules" 
                                Text="Teléfono."></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Telefono1" runat="server" MaxLength="15" 
                                style="top: 650px; left: 145px; " TabIndex="20" ToolTip="Teléfono" 
                                Width="410px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style21">
                            <asp:Label ID="Label57" runat="server" CssClass="Textos_Azules" 
                                Text="Teléfono."></asp:Label>
                        </td>
                        <td class="style22" style="text-align: left">
                            <asp:TextBox ID="T_Telefono2" runat="server" MaxLength="15" 
                                style="top: 650px; left: 365px; text-align: left;" TabIndex="21" 
                                ToolTip="Teléfono" Width="228px" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label50" runat="server" CssClass="Textos_Azules" Text="Fax."></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Fax" runat="server" MaxLength="15" 
                                style="top: 650px; left: 560px; text-align: left; right: 185px;" TabIndex="22" 
                                ToolTip="Fax" Width="410px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style22" style="text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style19">
                            &nbsp;</td>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                        </td>
                        <td class="style22">
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            <asp:Label ID="Label43" runat="server" CssClass="Textos_Azules" 
                                Text="Correo Electrónico * "></asp:Label>
                        </td>
                        <td class="style20">
                            <asp:TextBox ID="T_Mail" runat="server" MaxLength="80" 
                                style="top: 370px; text-transform:lowercase; left: 265px; " TabIndex="23" 
                                Width="410px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td class="style21">
                        </td>
                        <td class="style22" style="text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td class="style19">
                            &nbsp;</td>
                        <td class="style20">
                            &nbsp;</td>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style22" style="text-align: left">
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
