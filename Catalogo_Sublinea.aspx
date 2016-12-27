<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Sublinea.aspx.vb" Inherits="Catalogo_Sublinea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
    </script>
    <script language="javascript" type="text/javascript">
        function Linea(elemValue1, elemValue2) {
            document.getElementById('<%= T_Lin_Numero.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Lin_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Lin_Numero", "TextChanged");
        }
        function Lineas(elemValue1, elemValue2) {
            document.getElementById('<%= TB_Grupo.ClientID %>').value = elemValue1;
            document.getElementById('<%= TB_Grupo_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("TB_Grupo", "TextChanged");
        }
    </script>
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
                                        Text="Catálogo Sub-Grupo" Width="95%"></asp:Label>
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
                                Width="90px" TabIndex="16"/>
                            &nbsp;
                            <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                Width="80px" />
                            &nbsp;
                            <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                Text="Restaura" Width="110px" />
                            &nbsp;
                            <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                Width="100px" />
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
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td width="11%" height="40px">
                            </td>
                            <td width="11%">
                                <asp:TextBox ID="TB_Grupo" runat="server" CssClass="form-control" 
                                    placeholder="Grupo" Style="text-align:right;" TabIndex="13" Width="77%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="5%">
                                <asp:HyperLink ID="HB_Linea" runat="server" BorderStyle="None" Enabled="False" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="18"></asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TB_Grupo_Descripcion" runat="server" CssClass="form-control" 
                                    placeholder="Descripcion Grupo" TabIndex="14" Width="91%"></asp:TextBox>
                            </td>
                            <td width="12%">
                                <asp:CheckBox ID="Ch_Baja" runat="server" Text="Bajas" 
                                CssClass="Textos_Azules" AutoPostBack="True" />
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="40px" width="11%">
                                &nbsp;</td>
                            <td width="11%">
                                <asp:TextBox ID="TB_Sub_Grupo" runat="server" CssClass="form-control" 
                                    placeholder="Sub-Grupo" Style="text-align:right;" TabIndex="13" 
                                    Width="75%"></asp:TextBox>                            </td>
                            <td style="text-align: right" width="5%">
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TB_Sub_Grupo_Descripcion" runat="server" 
                                    CssClass="form-control" placeholder="Descripcion Sub-Grupo" TabIndex="14" Width="91%"></asp:TextBox>
                            </td>
                            <td width="12%">
                                &nbsp;</td>
                            <td width="11%">
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
                                    <asp:BoundField HeaderText="Grupo">
                                    <HeaderStyle HorizontalAlign="right" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descripción">
                                    <HeaderStyle Width="347px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Sub-Grupo">
                                    <HeaderStyle HorizontalAlign="Right" Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descripción">
                                    <HeaderStyle Width="347px" />
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
                                CellPadding="1" CellSpacing="4" DataKeyNames="Numero_Linea,Numero_Sub_Linea" 
                                Font-Size="Small" ForeColor="#333333" GridLines="None" Height="16px" 
                                ShowHeader="False" style="top: 152px; left: 86px; " Visible="False" 
                                Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Numero_Linea" HeaderText="Línea">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lin_Descripcion" HeaderText="Línea">
                                    <ItemStyle HorizontalAlign="Left" Width="347px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Numero_Sub_Linea" HeaderText="Núm.">
                                    <ItemStyle HorizontalAlign="Right" Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Sublínea">
                                    <ItemStyle HorizontalAlign="Left" Width="347px" />
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
                            <td width="11%">
                            </td>
                            <td width="6%" style="text-align: left" height="40">
                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" 
                                Text="Grupo:"></asp:Label>
                            </td>
                            <td width="7%" style="text-align: left">
                                <asp:TextBox ID="T_Lin_Numero" runat="server" CssClass="form-control" 
                                Width="30px" style="text-align:right;" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td width="10%" style="text-align: left">
                                <asp:HyperLink ID="H_Linea" runat="server" 
                         BorderStyle="None" ImageUrl="~/Imagenes/M_Buscar_50.png" Enabled="False" 
                                TabIndex="18"></asp:HyperLink>
                            </td>
                            <td style="text-align: right; " width="230">
                                <asp:TextBox ID="T_Lin_Descripcion" runat="server" CssClass="form-control" 
                                        Width="262px" MaxLength="60" 
                                TabIndex="19"></asp:TextBox>
                            </td>
                            <td width="100">
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="6%">
                                <asp:Label ID="Label16" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Núm:"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left" width="7%">
                                <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" MaxLength="4" 
                                    ReadOnly="True" style="text-align:right;top: 493px; left: 645px; " TabIndex="1" 
                                    Width="30px"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="10%">
                                <asp:Label ID="Label17" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Sub-Grupo"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left" width="235px">
                                <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" 
                                    MaxLength="35" style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                                    TabIndex="17" Width="205px"></asp:TextBox>
                            </td>
                            <td height="40px" style="text-align: left" width="10%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: right" width="370">
                                &nbsp;</td>
                            <td style="text-align: left" width="100px">
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