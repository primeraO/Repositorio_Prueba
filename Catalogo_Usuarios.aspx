<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Usuarios.aspx.vb" Inherits="Catalogo_Usuarios" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
</script>
    <style type="text/css">
        .style2
        {
            width: 315px;
        }
        </style>
    <script type="text/javascript">
        __doPostBack("T_Usuario", "TextChanged")
    </script>
</head>
<body>
    <center>    
        <form id="form1" runat="server" style="width: 984px; margin-bottom: 19px;">
        <div>
            <div>

                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Catálogo de Usuarios" Width="100%"></asp:Label>
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
                        <td style="text-align: right" width="15%">
                            <asp:Image ID="Image1" runat="server" Height="61px" 
                                ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                                Width="174px" />
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>

            </div>
           

            <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <%-- <triggers>
              <asp:PostBackTrigger runat="server" ControlID="BtnI_Imprimir"></asp:PostBackTrigger>
            </triggers>--%>
           <ContentTemplate>
            <asp:Panel ID="Pnl_completo" runat="server">
            <div>
           <asp:Button ID="Btn_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                    Width="90px" TabIndex="2000" /> &nbsp;
                <asp:Button ID="Btn_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                    Width="80px" TabIndex="2000" />
                
                &nbsp;<asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" 
                    Text="Guarda" Width="100px" TabIndex="2000" />
                &nbsp;<asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" 
                    Text="Restaura" Width="111px" TabIndex="2000" />
                &nbsp;<asp:Button ID="Btn_Salir" runat="server" CssClass="Btn_Azul" 
                    Text="Salir" TabIndex="2000" />
                &nbsp;&nbsp;</div>

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
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>

            <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                <div>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Label32" runat="server" CssClass="Textos_Azules" Text="Número"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="TB_Numero"  style="text-align:right;" runat="server" 
                                    CssClass="form-control" Width="85px" AutoPostBack="True" 
                                    placeholder="Número"></asp:TextBox>
                            </td>
                            <td width="10px">
                     
                                &nbsp;</td>
                            <td width="65px">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Azules" Text="Nombre"></asp:Label>
                            </td>
                            <td width="300px">
                                <asp:TextBox ID="TB_Nombre" runat="server" CssClass="form-control" 
                                    Width="285px" TabIndex="1" style="text-transform:uppercase;" 
                                    placeholder="Nombre"></asp:TextBox>
                            </td>
                            <td width="15px">
                                &nbsp;</td>
                            <td width="80px">
                                <asp:CheckBox ID="ChB_Activo" runat="server" CssClass="Textos_Azules" 
                                    Text="Activo" AutoPostBack="True" Checked="True" TabIndex="1500" />
                            </td>
                            <td width="80px">
                                <asp:CheckBox ID="ChB_Baja" runat="server" CssClass="Textos_Azules" 
                                    Text="Bajas" AutoPostBack="True" TabIndex="1500" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Label37" runat="server" CssClass="Textos_Azules" Text="Usuario"></asp:Label>
                            </td>
                            <td width="320px">
                                <asp:TextBox ID="TB_Usuario" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" placeholder="Nombre de Usuario"
                                    TabIndex="2" Width="300px"></asp:TextBox>
                            </td>
                            <td width="198px">
                                &nbsp;</td>
                            <td width="80px">
                                <asp:CheckBox ID="ChB_Admn" runat="server" CssClass="Textos_Azules" 
                                    Text="Admin" AutoPostBack="True" TabIndex="1500"  />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Pnl_Grids" runat="server" Visible="False">
                        <table ID="Tab_Enc_Grid" runat="server" style="width:100%;">
                            <tr>
                                <td bgcolor="#507CD1" style="color: #FFFFFF; text-align: center;" width="9%">
                                    Número&nbsp;
                                </td>
                                <td bgcolor="#507CD1" style="color: #FFFFFF; text-align: center;" width="20%">
                                    Nombre Real</td>
                                <td bgcolor="#507CD1" style="color: #FFFFFF; text-align: center;" width="20%">
                                    Nombre de Usuario</td>
                                <td bgcolor="#507CD1" style="color: #FFFFFF; text-align: center;" width="20%">
                                    E-Mail</td>
                                <td bgcolor="#507CD1" style="color: #FFFFFF; text-align: center;" width="10%">
                                    Cambio</td>
                                <td bgcolor="#507CD1" style="color: #FFFFFF; text-align: center;" width="10%">
                                    <asp:Label ID="Label38" runat="server" Text="Baja"></asp:Label>
                                </td>
                                <td bgcolor="#507CD1" 
                                    style="color: #FFFFFF; text-align: center; background-color: #FFFFFF;" 
                                    width="2%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel_Grid" runat="server" Height="300px" ScrollBars="Vertical" 
                            Visible="False" Width="100%">
                            <%--  <table style="width:100%;">--%>
                            <%--      <tr>
                        <td width="78%">--%>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" DataKeyNames="UsuarioNumero" Font-Size="Small" 
                                ForeColor="#333333" GridLines="None" Height="15px" ShowHeader="False" 
                                Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="UsuarioNumero" HeaderText="Número">
                                    <HeaderStyle Width="9%" />
                                    <ItemStyle HorizontalAlign="Left" Width="9%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsuarioReal" HeaderText="Nombre Real">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsuarioNombre" HeaderText="Nombre de Usuario">
                                    <HeaderStyle Width="20%" />
                                    <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsuarioMail" HeaderText="E-mail">
                                    <HeaderStyle Width="20%" />
                                    <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsuarioClave" HeaderText="Clave" Visible="False" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                    <ControlStyle Font-Bold="True" />
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                                        ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja">
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="UsuarioActivo" HeaderText="Activo" Visible="False" />
                                    <asp:BoundField DataField="UsuarioAdministrador" HeaderText="Administrador" 
                                        Visible="False" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                                    Width="964px" Wrap="False" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </asp:Panel>  <%--Final Panel Busqueda--%>
          
            <asp:Panel ID="Pnl_Registro" CssClass="Paneles" runat="server">
                <div>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" Text="Número"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Numero" style="text-align:right;"  runat="server" 
                                    CssClass="form-control" Width="85px" 
                                    AutoPostBack="True" TabIndex="3"></asp:TextBox>
                            </td>
                            <td width="20px">
                     
                                &nbsp;</td>
                            <td width="315px" class="style2">
                                &nbsp;</td>
                            <td width="80px">
                                &nbsp;</td>
                            <td width="100px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Label4" runat="server" CssClass="Textos_Azules" Text="Nombre"></asp:Label>
                            </td>
                            <td width="460px">
                                <asp:TextBox ID="T_Nombre"  style="text-transform:uppercase;" runat="server" CssClass="form-control" 
                                    Width="445px" TabIndex="4"></asp:TextBox>
                            </td>
                            <td width="10px">
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="Ch_Activo" runat="server" CssClass="Textos_Azules" 
                                    Text="Activo" Checked="True" TabIndex="1500" />
                            </td>
                        </tr>
                        </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Label35" runat="server" CssClass="Textos_Azules" Text="E-mail"></asp:Label>
                            </td>
                            <td width="460px">
                                <asp:TextBox ID="T_Correo" runat="server" CssClass="form-control" 
                                    TabIndex="5" Width="445px"></asp:TextBox>
                            </td>
                            <td width="10px">
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="Ch_Admn" runat="server" CssClass="Textos_Azules" 
                                    Text="Administrador" Checked="True" TabIndex="1500" />
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Label33" runat="server" CssClass="Textos_Azules" Text="Usuario"></asp:Label>
                            </td>
                            <td width="460px">
                                <asp:TextBox ID="T_Usuario" runat="server" CssClass="form-control" 
                                    style="text-transform:uppercase;" TabIndex="6" Width="445px"></asp:TextBox>
                            </td>
                            <td width="10px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Lbl_Clave1" runat="server" CssClass="Textos_Azules" Text="Clave"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Clave" runat="server" 
                                    CssClass="form-control" Width="85px" TabIndex="7" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td width="20px">
                     
                                <asp:Label ID="Lbl_Clave3" runat="server" CssClass="Textos_Azules" 
                                    Text="Nueva Clave"></asp:Label>
                            </td>
                            <td width="315px">
                                <asp:TextBox ID="T_Nue_Cve" runat="server" CssClass="form-control" TabIndex="8" 
                                    TextMode="Password" Width="85px"></asp:TextBox>
                            </td>
                            <td width="80px">
                                &nbsp;</td>
                            <td width="80px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="70px">
                                <asp:Label ID="Lbl_Clave2" runat="server" CssClass="Textos_Azules" 
                                    Text="Confirma Clave"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Clave2" runat="server" 
                                    CssClass="form-control" TabIndex="9" 
                                    TextMode="Password"   Width="85px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                &nbsp;</td>
                            <td width="315px">
                                &nbsp;</td>
                            <td width="80px">
                                &nbsp;</td>
                            <td width="80px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </asp:Panel> <%--Final Panel Registro--%>
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
          
            </asp:Panel>  <%--Final Panel comleto--%>              
               <%--Final Panel Copiar--%><%--Final Panel Importar Y Exportar--%>          
               <%--Final Panel Impresion--%>          
           </ContentTemplate>
        </asp:UpdatePanel>
           <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="overlay" />
                    <div class="overlayContent">
                
                        <img src="Imagenes/cargando.gif" alt="Loading"/>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
        </div>
        </form>
    </center>
</body>
</html>

