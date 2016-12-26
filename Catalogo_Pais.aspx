<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Pais.aspx.vb" Inherits="Catalogo_Pais" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
    </script>
    <style type="text/css">
        .form-control
        {
            text-align: left;
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
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div>
                    <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">

                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Catálogo País" Width="95%"></asp:Label>
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
                                    Width="90px" TabIndex="3" />
                                &nbsp;
                                <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                    Width="80px" />
                                &nbsp;
                                <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                    Text="Restaura" Width="110px" />
                                &nbsp;
                                <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                    Width="100px" TabIndex="5" />
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
                                BorderStyle="Solid" ForeColor="#FF3300" Height="26px" 
                                style="float: none; text-align: center;" Text="Label" Width="652px" 
                                Visible="False"></asp:Label>
                                 <br />
                        </td>
                        <td width="15%">
                            &nbsp;</td>
                    </tr>
                </table>
                    <br />
                    <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td width="10%">
                                    &nbsp;</td>
                                <td width="784">
                                    <div>
                                        <table style="width:100%;">
                                            <tr style="height: 40px">
                                                <td width="9%" style="text-align: left">
                                                    <asp:TextBox ID="TB_Numero" runat="server" Width="56px" 
                                placeholder="Núm" CssClass="form-control" TabIndex="1" style="text-align:right;"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left" width="4%">
                                                    &nbsp;</td>
                                                <td style="text-align: left" width="35%">
                                                    <asp:TextBox ID="TB_Descripcion" runat="server" Width="297px" 
                                CssClass="form-control" placeholder="Pais" TabIndex="1"></asp:TextBox>
                                                </td>
                                                <td style="text-align: right" width="30%">
                                                    &nbsp;&nbsp;
                                                    <asp:CheckBox ID="Ch_Baja" runat="server" Text="Bajas" 
                                        CssClass="Textos_Azules" TabIndex="2" AutoPostBack="True" />
                                                </td>
                                            </tr>
                                            <tr style="height: 40px">
                                                <td style="text-align: left" width="9%">
                                                    &nbsp;</td>
                                                <td style="text-align: left" width="4%">
                                                    &nbsp;</td>
                                                <td style="text-align: left" width="35%">
                                                    &nbsp;</td>
                                                <td style="text-align: right" width="30%">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
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
                                            <asp:BoundField HeaderText="País" >
                                            <HeaderStyle Width="794px" />
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
                             style="top: 152px; left: 86px; " DataKeyNames="Numero" Font-Size="Small" Height="16px" 
                                            CellSpacing="4" Visible="False" Width="964px" 
                               ShowHeader="False">
                            <RowStyle BackColor="#EFF3FB" Height="22px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" Visible="False" >
                                <HeaderStyle Width="40px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="Numero" HeaderText="Núm." >
                                <ItemStyle Width="40px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="País" >
                                <ItemStyle Width="794px" />
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                    ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver">
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                    ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
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


                    <asp:Panel ID="Pnl_Registro" CssClass="Paneles" runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td width="10%">
                                    &nbsp;</td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label2" runat="server" CssClass="Textos_Azules" 
                Text="Núm:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="T_Numero" runat="server" 
                CssClass="form-control" Width="45px" 
                                        ReadOnly="True" style="text-align:right;"></asp:TextBox>
                                </td>
                                <td width="10%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="text-align: left">
                                    <asp:Label ID="Label3" runat="server" CssClass="Textos_Azules" 
                Text="País:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" 
                                        Width="240px" TabIndex="4"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <br />
              

             <asp:HiddenField ID="Movimiento" runat="server" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
                          
                    
        </div>
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
