<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Empleados.aspx.vb" Inherits="Catalogo_Empleados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="CodigoJS.js" type="text/javascript">
    alert("Error al abrir archivo.js");
</script>
    <title></title>
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
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Catálogo de Empleados"></asp:Label>
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
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        <asp:PostBackTrigger ControlID="Btn_Acepta_Imp" />
        </Triggers>
       <ContentTemplate>
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="100">
                            &nbsp;</td>
                        <td width="784">
                            <div>
                                <table style="width:100%;">
                                    <tr>
                                        <td width="80%">
                                        <center>
                            <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                                Width="90px" TabIndex="3" />
                            &nbsp;
                            <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                Width="80px" />
                            &nbsp;
                            <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                Text="Restaura" Width="108px" />
                            &nbsp;
                            <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                Width="100px" TabIndex="6" />
                                        &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" />
                                            </td>
                                        </center>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td width="100">
                            &nbsp;</td>
                    </tr>
                    </table>
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
                            <br />
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel runat="server" ID="Pnl_Busqueda" CssClass="Paneles">
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="11%">
                            </td>
                        <td width="9%" style="text-align: left">
                    <asp:TextBox ID="TB_Numero" runat="server" Width="55px" TabIndex="1" 
                                placeholder="Núm." CssClass="form-control" 
                                MaxLength="6" style="text-align:right;"></asp:TextBox>
                         </td>
                        <td width="4%" style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: right; " width="35%">
                    <asp:TextBox ID="TB_Descripcion" runat="server" Width="272px" TabIndex="1" 
                                placeholder="Descripcion" CssClass="form-control" MaxLength="35"></asp:TextBox>
                         </td>
                        <td style="text-align: left; " width="30%">
                    &nbsp;&nbsp;
                            <asp:CheckBox ID="Ch_Baja" runat="server" CssClass="Textos_Azules" 
                                Text="Bajas" TabIndex="2" AutoPostBack="True" />
                         </td>
                        <td width="11%">
                        </td>
                    </tr>
                </table>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="Pnl_Registro" CssClass="Paneles">
                <div>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td style="text-align: left" width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" height="40px" width="40px">
                            <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="Núm:" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>
                        <td style="text-align: left" height="40px" width="90px">
                            <asp:TextBox ID="T_Numero" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="6" TabIndex="1" 
                                Width="55px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td style="text-align: right" height="40px" width="70px">
                            <asp:Label ID="Label17" runat="server" BorderStyle="None" Text="Nombre:" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>
                        <td style="text-align: left" height="40px" width="210px">
                            <asp:TextBox ID="T_Descripcion" runat="server" 
                      style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                    MaxLength="35" TabIndex="4" CssClass="form-control" Width="180px"></asp:TextBox>
                        </td>
                        <td style="text-align: right" height="40px" width="90px">
                            <asp:Label ID="Label24" runat="server" BorderStyle="None" Text="Categoria:" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>
                        <td style="text-align: left" height="40px" width="290px">
                            <asp:TextBox ID="T_Categoria" runat="server" MaxLength="50" 
                        style="top: 481px; left: 10px;" 
                        TabIndex="5" CssClass="form-control" Width="200px" ></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="11%">
                            &nbsp;</td>
                    </tr>
                    </table>
            </div>
            </asp:Panel>
             <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" 
                Visible="False">
                                  <div style="overflow:hidden; height:35px; width:100%; float:left" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="4">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Número">
                                            <HeaderStyle  Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nombre" >
                                            <HeaderStyle Width="554px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Categoria">
                                            <HeaderStyle  Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Cambio" >
                                            <HeaderStyle Width="60px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Baja" >
                                            <HeaderStyle Width="40px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" 
                 style="top: 152px; left: 86px; " DataKeyNames="Numero" Font-Size="Small" 
                             Width="964px" Height="16px" CellSpacing="4" ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" Visible="False" >
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Numero" HeaderText="Num." >
                    <ItemStyle Width="70px" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                        <ItemStyle Width="554px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" >
                        <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
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
        </div>
        </form>
    </center>
</body>
</html>
