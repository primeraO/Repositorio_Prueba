<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Claves_Autorizacion.aspx.vb" Inherits="Catalogo_Claves_Autorizacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
    </script>
    <style type="text/css">
        .style2
        {
            text-align: left;
        }
        .style3
        {}
        .style4
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server" style="width: 984px;">
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="20%"> 
                                                        &nbsp;</td>
                        <td width="60%">
                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label27" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Actualización Claves de Autorización"></asp:Label>
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
                             <asp:Image ID="Img_Logotipo" runat="server" Height="61px" 
                             style="text-align: right" 
                              Width="174px" />
                                    <br />
                                    <br />
                                    <br />
                         </td>
                    </tr>
                </table>
            </div>
             <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <%-- <Triggers>
        <asp:PostBackTrigger ControlID="Movimiento" />
        </Triggers>--%>
         <%--   <ContentTemplate>--%>
                <asp:Panel ID="P_Botones" runat="server">
                <div>
                    <asp:Button ID="Btn_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" />
                    <asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" TabIndex="5" 
                        Text="Guardar"/>
                    <asp:Button ID="Btn_Baja" runat="server" CssClass="Btn_Azul" Text="Baja" 
                        TabIndex="2000" Visible="False" />
                    <asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" Text="Restaura" 
                        TabIndex="2000" />
                    <asp:Button ID="Btn_Regresa" runat="server" CssClass="Btn_Azul" 
                        Text="Regresa" TabIndex="2000" />
                </div>  
                </asp:Panel>
                
                <div style="height: 8px">
                </div>
                <div>
                    <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" 
                        BorderStyle="Solid" ForeColor="#FF3300" 
                        style="float: none; text-align: center;" Text="Label" Visible="False" 
                        Width="96%"></asp:Label>
                </div>
                <div style="height: 8px">
                </div>
                <div class="style4">
                                            <asp:CheckBox ID="Ch_Baja" runat="server" CssClass="Textos_Azules" 
                                                Text="Baja" AutoPostBack="True" />
                                        </div>
                <div>
                        
                        <asp:Panel ID="P_Campos" runat="server">
                            <div>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left" width="75px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="120px">
                                            <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" 
                                                Text="Autorizado"></asp:Label>
                                        </td>
                                        <td style="text-align: left" width="110px">
                                            <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" 
                                                Width="100px"></asp:TextBox>
                                        </td>
                                        <td width="20px">
                                            &nbsp;</td>
                                        <td style="text-align: left">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left" width="75px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="120px">
                                            <asp:Label ID="Label35" runat="server" CssClass="Textos_Azules" Text="Nombre"></asp:Label>
                                        </td>
                                        <td style="text-align: left" width="100px">
                                            <asp:TextBox ID="T_Nombre" runat="server" CssClass="form-control" 
                                                TabIndex="1" Width="300px"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left" width="80px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="100px">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>

                            </div>
                            <div>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left" width="75px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="120px">
                                            <asp:Label ID="Label39" runat="server" CssClass="Textos_Azules" 
                                                Text="Clave"></asp:Label>
                                        </td>
                                        <td style="text-align: left; width: 200px;" width="100px">
                                            <asp:TextBox ID="T_Clave" runat="server" CssClass="form-control" 
                                                Width="100px" TextMode="Password" TabIndex="2" Placeholder="*******" MaxLength="10"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left" width="170px">
                                            &nbsp;</td>
                                        <td style="text-align: left">
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left" width="75px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="120px">
                                            <asp:Label ID="Label40" runat="server" CssClass="Textos_Azules" 
                                                Text="Firma"></asp:Label>
                                        </td>
                                        <td style="text-align: left" width="520px">
                                            <asp:FileUpload ID="fileUploader1" runat="server" CssClass="style3" 
                                                Width="400px" TabIndex="3" />
                                        </td>
                                        <td class="style2">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table style="width:100%;">
                                    <tr>
                                        <td style="text-align: left" width="75px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="120px">
                                            <asp:Label ID="Label41" runat="server" CssClass="Textos_Azules" 
                                                Text="Departamento"></asp:Label>
                                        </td>
                                        <td style="text-align: left; width: 140px;" width="120px">
                                            <asp:TextBox ID="T_Departamento" runat="server" CssClass="form-control" 
                                                Width="100px" TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td style="text-align: left" width="70px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="90px">
                                            &nbsp;</td>
                                        <td width="20px">
                                            &nbsp;</td>
                                        <td style="text-align: left" width="70px">
                                            &nbsp;</td>
                                        <td style="text-align: left">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        
                        <div style="height: 15px"></div>
                         <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left">
                                  <div style="overflow:hidden; height:35px; width:100%; float:left" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="3">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Número">
                                            <HeaderStyle  Width="70px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nombre" >
                                            <HeaderStyle Width="394px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Firma">
                                            <HeaderStyle  Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Departamento" >
                                            <HeaderStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Cambio" >
                                            <HeaderStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Baja" >
                                            <HeaderStyle Width="40px" />
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
                                <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:350px;">
                            <asp:GridView ID="GridView1" runat="server" 
                                AutoGenerateColumns="False" CellPadding="0" CellSpacing="4" 
                                DataKeyNames="Numero" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="27px" style="top: 152px; left: 86px; " 
                                Width="964px" ShowHeader="False">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField DataField="Numero" HeaderText="Número">
                                    <ItemStyle HorizontalAlign="Left" Width="70px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                                    <ItemStyle HorizontalAlign="Left" width="394px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Clave_Seguridad" HeaderText="Clave" Visible="False" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Firma" HeaderText="Firma" >
                                    <ItemStyle HorizontalAlign="Left" width="200px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Departamento" HeaderText="Departamento">
                                    <ItemStyle HorizontalAlign="Left" width="200px"/>
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" >
                                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                                        ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja" >
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
                </div>
                <div style="height: 35px">
                    <asp:HiddenField ID="Nombre_Imagen" runat="server" />
                    <asp:HiddenField ID="Movimiento" runat="server" />
                </div>
          <%--
              </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                <img src="Imagenes/cargando.gif" alt="Loading"/>
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>--%>
        </form>
    </center>
</body>
</html>
