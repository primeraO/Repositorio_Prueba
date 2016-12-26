<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consulta_Seguimiento.aspx.vb" Inherits="Consulta_Seguimiento" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>
    <link href="Ejemplo_Estilos1.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
</script>
      <script type="text/javascript">
          function Usuario(elemValue1, elemValue2) {
              document.getElementById('<%= TB_Usuario.ClientID %>').value = elemValue2;
              __doPostBack("TB_Usuario", "TextChanged");
          }
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
                            <asp:Image ID="Img_Logotipo" runat="server" Height="61px" 
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
                    Width="90px" TabIndex="2000" />
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
                                <asp:Label ID="Label37" runat="server" CssClass="Textos_Azules" Text="Usuario"></asp:Label>
                            </td>
                            <td width="320px">
                                <asp:TextBox ID="TB_Usuario" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" placeholder="Nombre de Usuario"
                                    TabIndex="2" Width="300px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Usuario" runat="server" BorderStyle="None" 
                                    BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="14542" />
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
                            <td width="40px">
                                <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" Text="De:"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Fecha1" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" placeholder="Nombre de Usuario"
                                    TabIndex="2" Width="90px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <rjs:PopCalendar ID="PC_Fecha1" runat="server" Control="T_Fecha1" 
                                    Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td width="10px">
                                &nbsp;</td>
                            <td width="20px">
                                <asp:Label ID="Label38" runat="server" CssClass="Textos_Azules" Text="A:"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Fecha2" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" placeholder="Nombre de Usuario" TabIndex="2" 
                                    Width="90px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <rjs:PopCalendar ID="PC_Fecha2" runat="server" Control="T_Fecha2" 
                                    Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td>
                                <asp:CheckBox ID="Ch_Fecha" runat="server" AutoPostBack="True" 
                                    CssClass="Textos_Azules" Text="Filtrar Por Fecha" Checked="True" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>  <%--Final Panel Busqueda--%>
          
                <%--Final Panel Registro--%>
       
          <%--  <div>
                <table style="width:100%;">
                    <tr>
                        <td width="78%">
                            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CellPadding="0" CellSpacing="3" 
                                DataKeyNames="UsuarioNumero" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="27px" style="top: 152px; left: 86px; " 
                                Width="100%">
                <Columns>
                    <asp:BoundField DataField="UsuarioReal" HeaderText="Usuario" >
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Punto_Acceso" HeaderText="Punto" >
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha " />
                    <asp:BoundField DataField="Hora_Entrada" HeaderText="Hora Entrada" />
                    <asp:BoundField DataField="Hora_Salida" HeaderText="Hora Salida" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                         </td>
                    </tr>
                </table>
            </div>--%>
             <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                 <div style="overflow: hidden; height: 35px; width:100%">
                                          <asp:GridView id="Cabecera" runat="server" 
                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" ShowHeaderWhenEmpty="True"
                 style="top: 152px; left: 86px; " Font-Size="Small" 
                             Width="964px" Height="35px" CellSpacing="4">
                             <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <%--<asp:CommandField ShowSelectButton="True" Visible="False" >
                                    <ItemStyle Width="50px" />
                                    </asp:CommandField >--%>
                                    <asp:BoundField HeaderText="Usuario" >
                                    <HeaderStyle Width="340px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Punto Menú" >
                                    <HeaderStyle HorizontalAlign="Left" Width="340px" />
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Fecha" >
                                    <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="Hora">
                                    <HeaderStyle Width="100px" HorizontalAlign="Center"/>
                                    </asp:BoundField>

                                    <asp:BoundField HeaderText="E - S">
                                    <HeaderStyle Width="100px" />
                                    </asp:BoundField>

                                  <%--  <asp:BoundField>
                                    <HeaderStyle Width="20px" />
                                    </asp:BoundField>--%>

                                </Columns>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
            </div>
            <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
             <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" showheader="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" 
                 style="top: 152px; left: 86px; margin-top: 0px;" Font-Size="Small" 
                             Width="964px" Height="16px" CellSpacing="4" DataKeyNames="Numero" 
                                Visible="False">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" >
                                    <ItemStyle Width="347px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Descripcion_Punto" HeaderText="Punto Descripción" >
                                    <ItemStyle Width="347px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" >
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Hora" HeaderText="Hora" >
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="E_S" HeaderText="E - S" >
                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Numero" Visible="False" />
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
          
            </asp:Panel>  <%--Final Panel comleto--%>              
               <%--Final Panel Copiar--%><%--Final Panel Importar Y Exportar--%>          
               <%--Final Panel Impresion--%>          
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