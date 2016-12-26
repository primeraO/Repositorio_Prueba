<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Actividad_Frente.aspx.vb" Inherits="Catalogo_Actividad_Frente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
     <script type="text/javascript" src="jquery.min.js"></script>
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
</script>
    <script type="text/javascript">
        function Frente(elemValue1, elemValue2) {
            document.getElementById('<%= T_Frente.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Frente_Desc.ClientID %>').value = elemValue2; 
            __doPostBack("T_Frente","TextChanged")
        }
        
    </script>
    <style type="text/css">
        .style4
        {
            width: 103px;
        }
        .style7
        {
            width: 84px;
        }
        .style9
        {
            width: 397px;
        }
        .style10
        {
            width: 36px;
        }
        .style11
        {
            width: 96%;
        }
        .style12
        {
            width: 8%;
            height: 40px;
        }
        .style13
        {
            height: 40px;
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
           .style1
           {
               height: 19px;
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
                                        Text="Catálogo Actividad-Frente" Width="95%"></asp:Label>
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
                        <td class="style1" style="text-align: center">
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
                                            
                                <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" />
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
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td width="11%" class="style13">
                            </td>
                            <td class="style12">
                                <asp:TextBox ID="TB_Frente" runat="server" CssClass="form-control" 
                                Width="50px" TabIndex="1" placeholder="Frente" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td style="text-align: right" class="style12">
                                <asp:TextBox ID="TB_Numero" runat="server" Width="40px" TabIndex="13" placeholder="Num." 
                                CssClass="form-control" style="text-align:right;"></asp:TextBox>
                            </td>
                            <td style="text-align: left" class="style13">
                                <asp:TextBox ID="TB_Descripcion" runat="server" Width="91%" TabIndex="14" 
                                placeholder="Actividad" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td width="12%" class="style13">
                                <asp:CheckBox ID="Ch_Baja" runat="server" Text="Bajas" AutoPostBack="True" 
                                CssClass="Textos_Azules" />
                            </td>
                            <td width="11%" class="style13">
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
                                    <asp:BoundField HeaderText="Frente">
                                    <HeaderStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descrición Frente">
                                    <HeaderStyle Width="377px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Act">
                                    <HeaderStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descripción Actividad">
                                    <HeaderStyle Width="367px" />
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
                                CellPadding="1" CellSpacing="4" DataKeyNames="Frente,Actividad" 
                                Font-Size="Small" ForeColor="#333333" GridLines="None" Height="16px" 
                                ShowHeader="False" style="top: 152px; margin-left: 0px;" Visible="False" 
                                Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ItemStyle Width="1px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Frente" HeaderText="Num.">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion_Frente" HeaderText="Frente">
                                    <ItemStyle Width="367px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Actividad" HeaderText="Num.">
                                    <ItemStyle HorizontalAlign="Right" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion_Actividad" HeaderText="Descripcion">
                                    <ItemStyle Width="367px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
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
                            <asp:HiddenField ID="Movimiento" runat="server" />
                        </div>
                    </asp:Panel>
                </asp:Panel>
                <br />
                <asp:Panel ID="Pnl_Registro" CssClass="Paneles" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td class="style4">
                                &nbsp;
                            </td>
                            <td align="left" width="10%">
                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" Text="Frente"></asp:Label>
                                &nbsp;
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="T_Frente" runat="server" CssClass="form-control" 
                                Width="50px" TabIndex="1" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td align="left" class="style10">
                                <asp:HyperLink ID="H_Frente" runat="server" BorderStyle="None" Enabled="False" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td align="left" class="style9">
                                <asp:TextBox ID="T_Frente_Desc" runat="server" MaxLength="50" 
                        style="top: 481px; left: 10px; text-align: left;" 
                        TabIndex="3" CssClass="form-control" Width="76%" BackColor="SkyBlue" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left" width="10%">
                                <asp:Label ID="Label16" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Num."></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left" width="68%">
                                <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" 
                                    MaxLength="10" style="text-align:right;top: 493px; left: 645px; " TabIndex="2" 
                                    Width="50px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="11%">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left" width="10%">
                                <asp:Label ID="Label24" runat="server" BorderStyle="None" 
                                    CssClass="Textos_Azules" Text="Actividad"></asp:Label>
                            </td>
                            <td height="40px" style="text-align: left" width="68%">
                                <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" 
                                    MaxLength="50" style="top: 481px; left: 10px; text-align: left;" 
                                    TabIndex="3" Width="76%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
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
