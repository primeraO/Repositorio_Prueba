<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Proveedores.aspx.vb" Inherits="Catalogo_Proveedores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
       </script>
    <script type="text/javascript" src="jquery.min.js"></script>
    <script type="text/javascript">
      function Cond_Pago(elemValue1, elemValue2) {
          document.getElementById('<%= T_CondPago.ClientID %>').value = elemValue1;
          document.getElementById('<%= T_Desc_CondPago.ClientID %>').value = elemValue2;
          __doPostBack("T_CondPago","TextChanged")
        }
       function Pais(elemValue1, elemValue2) {
           document.getElementById('<%= T_Pais.ClientID %>').value = elemValue1;
           document.getElementById('<%= T_Desc_Pais.ClientID %>').value = elemValue2;
           __doPostBack("T_Pais", "TextChanged")

        }
        function Comprador(elemValue1, elemValue2) {
            document.getElementById('<%= T_Comprador.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Desc_Comprador.ClientID %>').value = elemValue2;
            __doPostBack("T_Comprador", "TextChanged")

        }
        function Transporte(elemValue1, elemValue2) {
            document.getElementById('<%= T_Transporte.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Desc_Transporte.ClientID %>').value = elemValue2;
            __doPostBack("T_Transporte", "TextChanged")

        }
        
        
    </script>
    <style type="text/css">
        .form-control
        {
            margin-top: 0px;
        }
        .Textos_Azules
        {
            text-align: left;
        }
        .style2
        {
            width: 17%;
        }
        .style5
        {
            width: 12%;
        }
        .style6
        {
            width: 9%;
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
                                        Text="Catálogo Proveedores" Width="95%"></asp:Label>
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
                                           
                                <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" Height="45px" />
                                &nbsp;
                                <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                    Width="80px" Height="45px" />
                                &nbsp;
                                <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                    Text="Restaura" Width="110px" Height="45px" />
                                &nbsp;
                                <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                    Width="100px" Height="45px" />
                                            &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
                                                    Height="45px" />
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
                            <td width="11%" height="40px">
                            </td>
                            <td width="7%">
                                <asp:TextBox ID="TB_Numero" runat="server" Width="61px" TabIndex="13" placeholder="Num." 
                                CssClass="form-control" Height="18px" style="text-align:right;"></asp:TextBox>
                            </td>
                            <td style="text-align: right">
                                <asp:TextBox ID="TB_Descripcion" runat="server" CssClass="form-control" 
                                    Height="18px" placeholder="Razon Social" TabIndex="14" Width="299px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TB_RFC" runat="server" CssClass="form-control" Height="18px" 
                                    placeholder="RFC" TabIndex="14" Width="158px"></asp:TextBox>
                            </td>
                            <td width="13%">
                                <asp:CheckBox ID="CH_Corporativo" runat="server" CssClass="Textos_Azules" 
                                    Text="Es Corporativo" AutoPostBack="True" />
                            </td>
                            <td width="11%">
                                <asp:CheckBox ID="Ch_Baja" runat="server" AutoPostBack="True" 
                                    CssClass="Textos_Azules" Text="Bajas" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                        <div style="overflow:hidden; height:35px; width:100%; float:left">
                            <asp:GridView ID="Cabecera" runat="server" AutoGenerateColumns="False" 
                                CellPadding="2" CellSpacing="4" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="35px" ShowHeaderWhenEmpty="True" 
                                style="top: 152px; left: 86px; " Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField HeaderText="Núm">
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Razón Social">
                                    <HeaderStyle HorizontalAlign="Left" Width="684px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="RFC">
                                    <HeaderStyle HorizontalAlign="Left" Width="110px" />
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
                                style="top: 152px; left: 86px; " Visible="False" Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Numero" HeaderText="Num.">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Razon_Social" HeaderText="Razon Social">
                                    <ItemStyle HorizontalAlign="Left" Width="684px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Rfc" HeaderText="RFC">
                                    <ItemStyle Width="110px" />
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
                            <td width="9%">
                                &nbsp;</td>
                            <td style="text-align: left" width="12%" height="40">
                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" Text="Numero:"></asp:Label>
                            </td>
                            <td class="style2" style="text-align: left">
                                <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" Height="18px" 
                                Width="50%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="5%">
                                <asp:Label ID="Label41" runat="server" CssClass="Textos_Azules" Text="RFC:"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_RFC" runat="server" CssClass="form-control" Height="18px" 
                                Width="40%" MaxLength="13"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:Label ID="Label42" runat="server" CssClass="Textos_Azules" 
                                    Text="Razon Social:"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_RazonSocial" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="60" Width="70%"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:Label ID="Label43" runat="server" CssClass="Textos_Azules" 
                                    Text="Direccion:"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Direccion" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="50" Width="261px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="8%">
                                <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" Text="Colonia:"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Colonia" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="40" Width="152px"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:Label ID="Label45" runat="server" CssClass="Textos_Azules" Text="Estado:"></asp:Label>
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="T_Estado" runat="server" CssClass="form-control" Height="18px" 
                                    MaxLength="20" Width="106px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="5%">
                                <asp:Label ID="Label46" runat="server" CssClass="Textos_Azules" Text="C.P."></asp:Label>
                            </td>
                            <td style="text-align: left" width="47%">
                                <asp:TextBox ID="T_CP" runat="server" CssClass="form-control" Height="18px" 
                                    style="text-align:right;" Width="100px"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:Label ID="Label47" runat="server" CssClass="Textos_Azules" Text="Pais:"></asp:Label>
                            </td>
                            <td width="7%">
                                <asp:TextBox ID="T_Pais" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Height="18px" style="text-align:right;" Width="26px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="5%">
                                <asp:HyperLink ID="H_Pais" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_Pais" runat="server" CssClass="form-control" 
                                    Enabled="False" Height="18px" Width="182px"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:Label ID="Label48" runat="server" CssClass="Textos_Azules" Text="Mail:"></asp:Label>
                            </td>
                            <td width="26%">
                                <asp:TextBox ID="T_Mail" runat="server" CssClass="form-control" Height="18px" 
                                    MaxLength="30" Width="192px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="9%">
                                <asp:Label ID="Label49" runat="server" CssClass="Textos_Azules" Text="Fax:" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td width="30%">
                                <asp:TextBox ID="T_Fax" runat="server" CssClass="form-control" Height="18px" 
                                    MaxLength="20" Width="147px" Visible="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left">
                                <asp:Label ID="Label50" runat="server" CssClass="Textos_Azules" 
                                    Text="Telefono 1:"></asp:Label>
                            </td>
                            <td width="26%">
                                <asp:TextBox ID="T_Tel1" runat="server" CssClass="form-control" Height="18px" 
                                    MaxLength="20" Width="147px"></asp:TextBox>
                            </td>
                            <td class="style6">
                                <asp:Label ID="Label51" runat="server" CssClass="Textos_Azules" 
                                    Text="Telefono 2:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Tel2" runat="server" CssClass="form-control" Height="18px" 
                                    MaxLength="20" Width="147px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:RadioButtonList ID="R_Es_Corporativo" runat="server" 
                                    CssClass="Textos_Azules">
                                    <asp:ListItem Selected="True" Value="S">Corporativo</asp:ListItem>
                                    <asp:ListItem Value="N">Local</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left" width="9%">
                                &nbsp;</td>
                            <td style="text-align: left" width="6%">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="12%">
                                <asp:Label ID="Label53" runat="server" CssClass="Textos_Azules" 
                                    Text="Condicion Pago:"></asp:Label>
                            </td>
                            <td style="text-align: left" width="9%">
                                <asp:TextBox ID="T_CondPago" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Height="18px" style="text-align:right;" Width="44px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="6%">
                                <asp:HyperLink ID="H_CondPago" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_CondPago" runat="server" CssClass="form-control" 
                                    Enabled="False" Height="18px" Width="308px"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td class="style5" style="text-align: left">
                                <asp:Label ID="Label52" runat="server" CssClass="Textos_Azules" 
                                    Text="Comprador:" Visible="False"></asp:Label>
                            </td>
                            <td style="text-align: left" width="9%">
                                <asp:TextBox ID="T_Comprador" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Height="18px" style="text-align:right;" Visible="False" 
                                    Width="44px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="6%">
                                <asp:HyperLink ID="H_Comprador" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" Visible="False">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_Comprador" runat="server" CssClass="form-control" 
                                    Enabled="False" Height="18px" Visible="False" Width="308px"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td class="style5" style="text-align: left">
                                <asp:Label ID="Label54" runat="server" CssClass="Textos_Azules" 
                                    Text="Transporte:" Visible="False"></asp:Label>
                            </td>
                            <td style="text-align: left" width="9%">
                                <asp:TextBox ID="T_Transporte" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Height="18px" style="text-align:right;" 
                                    Width="44px" Visible="False"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="6%">
                                <asp:HyperLink ID="H_Transporte" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" Visible="False">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_Transporte" runat="server" CssClass="form-control" 
                                    Enabled="False" Height="18px" Width="308px" Visible="False"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label55" runat="server" CssClass="Textos_Azules" Text="Contacto"></asp:Label>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="9%">
                                &nbsp;</td>
                            <td style="text-align: left" width="10%">
                                <asp:Label ID="Label56" runat="server" CssClass="Textos_Azules" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Contacto_Nombre" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="60" Width="45%"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td width="9%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label57" runat="server" CssClass="Textos_Azules" 
                                    Text="Telefono:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Contacto_Telefono" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="20" Width="147px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label58" runat="server" CssClass="Textos_Azules" Text="Mail:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Contacto_Mail" runat="server" CssClass="form-control" 
                                    Height="17px" MaxLength="30" Width="242px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                                
            
                

                <asp:HiddenField ID="Movimiento" runat="server" />
                <br />
                                
            
                

            </div>
        
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
         <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                
                <img src="Imagenes/cargando.gif" alt="Loading"/>
                <br />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
        </form>
    </center>
    
</body>
</html>
