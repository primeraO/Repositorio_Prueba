<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Firmas.aspx.vb" Inherits="Catalogo_Firmas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
    </script>
    <script type="text/javascript">
        function Autoriza1(elemValue1, elemValue2) {
            document.getElementById('<%= T_Superintendente.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Superintendente_Descripcion.ClientID %>').value = elemValue2;
        }
        function Autoriza2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Almacen.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Almacen_Descripcion.ClientID %>').value = elemValue2;
        }
        function Autoriza3(elemValue1, elemValue2) {
            document.getElementById('<%= T_Administracion.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Administracion_Descripcion.ClientID %>').value = elemValue2;
        }
        function Autoriza4(elemValue1, elemValue2) {
            document.getElementById('<%= T_Gerente.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Gerente_Descripcion.ClientID %>').value = elemValue2;
        }
    </script>
    <style type="text/css">
        .style1
        {
            height: 34px;
        }
        .style2
        {
            width: 984px;
        }
        .style3
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server" style="width:984px;">
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="20%"> 
                                                        &nbsp;</td>
                        <td width="60%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Catálogo de Firmas"></asp:Label>
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
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>   
                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
            <asp:Panel ID="P_Botones" runat="server">
                 <div>
                    <asp:Button ID="Btn_Cambio" runat="server" CssClass="Btn_Azul" Text="Cambio" />
                     <asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" TabIndex="788" 
                         Text="Guarda" />
                     <asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" 
                                        Text="Restaura" TabIndex="455" />
                     <asp:Button ID="Btn_Salir" runat="server" CssClass="Btn_Azul" 
                         Text="Salir" />
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
            <div>
                <asp:Panel runat="server" ID="P_Campos_Requisicion" CssClass="Paneles">
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td class="style3">
                                    &nbsp;
                                    <asp:Label ID="Label35" runat="server" CssClass="Textos_Azules" 
                                        Text="REQUISICION"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table style="width:100%;">
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" Text="Puesto 1"></asp:Label>
                                </td>
                                <td style="text-align: left" width="250px">
                                    <asp:TextBox ID="T_RequisicionP1" runat="server" CssClass="form-control" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td style="text-align: left" width="20px">
                                    &nbsp;</td>
                                <td width="100px">
                                    <asp:TextBox ID="T_Superintendente" runat="server" 
                                        CssClass="form-control" MaxLength="6" style="text-align:right" TabIndex="1" 
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td width="30px">
                                    <asp:ImageButton ID="Btn_Superintendente" runat="server" 
                                        ImageUrl="~/Imagenes/M_Buscar_50.png" Width="29px" />
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="T_Superintendente_Descripcion" runat="server" 
                                        CssClass="form-control-Readonly" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label28" runat="server" CssClass="Textos_Azules" Text="Puesto 2"></asp:Label>
                                </td>
                                <td style="text-align: left" width="250px">
                                    <asp:TextBox ID="T_RequisicionP2" runat="server" CssClass="form-control" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td style="text-align: left" width="20px">
                                    &nbsp;</td>
                                <td width="100px">
                                    <asp:TextBox ID="T_Almacen" runat="server" 
                                        CssClass="form-control" MaxLength="6" style="text-align:right;" TabIndex="1" 
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td width="30px">
                                    <asp:ImageButton ID="Btn_Almacen" runat="server" 
                                        ImageUrl="~/Imagenes/M_Buscar_50.png" />
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="T_Almacen_Descripcion" runat="server" 
                                        CssClass="form-control-Readonly" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label29" runat="server" CssClass="Textos_Azules" Text="Puesto 3"></asp:Label>
                                </td>
                                <td style="text-align: left" width="250px">
                                    <asp:TextBox ID="T_RequisicionP3" runat="server" CssClass="form-control" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td style="text-align: left" width="20px">
                                    &nbsp;</td>
                                <td width="100px">
                                    <asp:TextBox ID="T_Administracion" runat="server" 
                                        CssClass="form-control" MaxLength="6" TabIndex="2" 
                                        style="text-align:right" Width="100px"></asp:TextBox>
                                </td>
                                <td width="30px">
                                    <asp:ImageButton ID="Btn_Administracion" runat="server" 
                                        ImageUrl="~/Imagenes/M_Buscar_50.png" />
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="T_Administracion_Descripcion" runat="server" 
                                        CssClass="form-control-Readonly" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" Text="Puesto4"></asp:Label>
                                </td>
                                <td style="text-align: left" width="250px">
                                    <asp:TextBox ID="T_RequisicionP4" runat="server" CssClass="form-control" 
                                        Width="230px"></asp:TextBox>
                                </td>
                                <td style="text-align: left" width="20px">
                                    &nbsp;</td>
                                <td width="100px">
                                    <asp:TextBox ID="T_Gerente" runat="server" 
                                        CssClass="form-control" style="text-align:right" MaxLength="6" 
                                        TabIndex="2" Width="100px"></asp:TextBox>
                                </td>
                                <td width="30px">
                                    <asp:ImageButton ID="Btn_Gerente" runat="server" 
                                        ImageUrl="~/Imagenes/M_Buscar_50.png" />
                                </td>
                                <td style="text-align: left">
                                    <asp:TextBox ID="T_Gerente_Descripcion" runat="server" 
                                        CssClass="form-control-Readonly" Width="350px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </div>
            <div class="style2">
                <div style="height: 25px">
                </div>
                
                <asp:Panel ID="P_Campos_Compras" runat="server" CssClass="Paneles">
                    <div>
                    <table style="width: 100%;">
                            <tr>
                                <td class="style3">
                                    &nbsp;
                                    <asp:Label ID="Label5" runat="server" CssClass="Textos_Azules" 
                                        Text="COMPRAS"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table style="width:100%; margin-right: 0px;">
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" 
                                        Text="Puesto 1"></asp:Label>
                                </td>
                                <td width="250px">
                                    <asp:TextBox ID="T_ComprasP1" runat="server" CssClass="form-control" 
                                        Width="230px" TabIndex="6"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: left" width="35px" class="style1">
                                    </td>
                                <td style="text-align: left" width="70px" class="style1">
                                    <asp:Label ID="Label2" runat="server" CssClass="Textos_Azules" Text="Puesto 2"></asp:Label>
                                </td>
                                <td width="250px" class="style1">
                                    <asp:TextBox ID="T_ComprasP2" runat="server" CssClass="form-control" 
                                        Width="230px" TabIndex="7"></asp:TextBox>
                                </td>
                                <td style="text-align: left" class="style1">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label3" runat="server" CssClass="Textos_Azules" 
                                        Text="Puesto 3"></asp:Label>
                                </td>
                                <td width="250px">
                                    <asp:TextBox ID="T_ComprasP3" runat="server" CssClass="form-control" 
                                        Width="230px" TabIndex="8"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: left" width="35px">
                                    &nbsp;</td>
                                <td style="text-align: left" width="70px">
                                    <asp:Label ID="Label4" runat="server" CssClass="Textos_Azules" Text="Puesto 4"></asp:Label>
                                </td>
                                <td width="250px">
                                    <asp:TextBox ID="T_ComprasP4" runat="server" CssClass="form-control" 
                                        Width="230px" TabIndex="9"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </div>
            <div>
                                    <asp:HiddenField ID="Movimiento" runat="server" />
            </div>
            
    </ContentTemplate>  
    </asp:UpdatePanel>
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel2">
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
