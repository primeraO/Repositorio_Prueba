<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Acceso.aspx.vb" Inherits="Acceso" %>

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
        document.getElementById('<%= T_Numero.ClientID %>').value = elemValue1;
        document.getElementById('<%= T_Nombre.ClientID %>').value = elemValue2;
        __doPostBack('T_Numero', 'Text_Changed');
    }

    function Obra3(elemValue1, elemValue2) {
        document.getElementById('<%= T_Obra.ClientID %>').value = elemValue1;
        document.getElementById('<%= T_Obra_Desc.ClientID %>').value = elemValue2;
    }
    </script>

    <style type="text/css">
        .style1
        {
            width: 100px;
        }
        .style2
        {}
        </style>

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
                                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Acceso a Usuarios" Width="100%"></asp:Label>
                                <br />
                                </asp:Panel>
                            </td>
                            <td style="text-align: right" width="15%">
                                <asp:Image ID="Image1" runat="server" Height="61px" 
                                    ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                                    Width="174px" />
                            </td>
                        </tr>
                    </table>
                <table style="width:100%;">
                    <tr>
                        <td style="text-align: center" class="style6">
                                &nbsp;</td>
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
                &nbsp;<asp:Button ID="Btn_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                    Width="90px" TabIndex="2000" Visible="False" />
                &nbsp;<asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" 
                    Text="Guarda" Width="100px" TabIndex="2000" Visible="False" />
                &nbsp;<asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" 
                    Text="Restaura" Width="111px" TabIndex="2000" Visible="False" />
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
                <br />
            </div>

                <table style="width:100%;">
                    <tr>
                        <td class="style1" align="left">
                            <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" Text="Empresa"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="List_Empresa" runat="server" AutoPostBack="True" 
                                CssClass="form-control" Width="765px">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

                <table style="width:100%;">
                    <tr>
                        <td align="left" width="100px">
                            <asp:Label ID="Label37" runat="server" CssClass="Textos_Azules" Text="Proyecto"></asp:Label>
                        </td>
                        <td width="100px">
                            <asp:TextBox ID="T_Obra" runat="server" AutoPostBack="True" 
                                CssClass="form-control" placeholder="Número" style="text-transform:uppercase;" 
                                Width="100px"></asp:TextBox>
                        </td>
                        <td width="20px">
                            <asp:HyperLink ID="Btn_Obra" runat="server" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="2000">HyperLink</asp:HyperLink>
                            </td>
                        <td>
                            <asp:TextBox ID="T_Obra_Desc" runat="server" CssClass="form-control-Readonly" 
                                placeholder="Descripcion de Punto" style="text-transform:uppercase;" 
                                TabIndex="1" Width="320px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

            <asp:Panel ID="Pnl_Todo" runat="server">
                <div>
                    <table style="width:100%;">
                        <tr>
                            <td width="100px" align="left">
                                <asp:Label ID="Label32" runat="server" CssClass="Textos_Azules" Text="Usuario"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Numero"  style="text-transform:uppercase;" runat="server" 
                                    CssClass="form-control" Width="100px" AutoPostBack="True" 
                                    placeholder="Número"></asp:TextBox>
                            </td>
                            <td width="20px">
                     
                                <asp:HyperLink ID="Btn_Usuario" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="2000">HyperLink</asp:HyperLink>
                            </td>
                            <td width="340px">
                                <asp:TextBox ID="T_Nombre" runat="server" CssClass="form-control-Readonly" 
                                    Width="320px" TabIndex="1" style="text-transform:uppercase;" 
                                    placeholder="Descripcion de Punto"></asp:TextBox>
                            </td>
                            <td width="10px">
                                &nbsp;</td>
                            <td width="100px">
                                <asp:Button ID="Btn_TodoS" runat="server" CssClass="Btn_Azul" TabIndex="2000" 
                                    Text="Todos SI" Width="102px" />
                            </td>
                            <td width="100px">
                                <asp:Button ID="Btn_TodoN" runat="server" CssClass="Btn_Azul" TabIndex="2000" 
                                    Text="Todos NO" Width="133px" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        </table>
                </div>
            </asp:Panel>  <%--Final Panel Busqueda--%>
          
            <asp:Panel ID="Pnl_Cambios" runat="server" Visible="False">
                <div>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Punto" runat="server" CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:Label ID="Label33" runat="server" CssClass="Textos_Azules" 
                                    Text="Acceso Total"></asp:Label>
                            </td>
                            <td width="60px">
                                <asp:RadioButton ID="R_Si" runat="server" CssClass="Textos_Azules" 
                                    GroupName="TA" Text="Sí" />
                            </td>
                            <td width="60px">
                                <asp:RadioButton ID="R_No" runat="server" CssClass="Textos_Azules" 
                                    GroupName="TA" Text="No" />
                            </td>
                            <td width="20px">
                     
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
                        <td width="78%">
                            <br />
            <asp:GridView ID="GridView1" runat="server" 
                                AutoGenerateColumns="False" CellPadding="4" 
                                DataKeyNames="Clave_Punto" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="27px" style="top: 152px; left: 86px; " 
                                Width="100%">
                <Columns>
                    <asp:BoundField DataField="Clave_Punto" HeaderText="Clave de Punto" 
                        Visible="False" >
                    <ItemStyle Width="120px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripcion_Punto" HeaderText="Descripción" >
                        <HeaderStyle HorizontalAlign="Left" Width="350px" />
                        <ItemStyle HorizontalAlign="Left" Width="350px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TA" HeaderText="T.A.">
                    <HeaderStyle Width="100px" />
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Altas" HeaderText="Alta" Visible="False">
                    <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Bajas" HeaderText="Baja" Visible="False">
                    <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Cambios" HeaderText="Camb." Visible="False">
                    <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Impresion" HeaderText="Impr." Visible="False">
                    <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_1" HeaderText="P1" Visible="False">
                    <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_2" HeaderText="P2" Visible="False">
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_3" HeaderText="P3" Visible="False">
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_4" HeaderText="P4" Visible="False">
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_5" HeaderText="P5" Visible="False">
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_6" HeaderText="P6" Visible="False">
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_7" HeaderText="P7" Visible="False">
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Pes_8" HeaderText="P8" Visible="False">
                    <HeaderStyle Width="40px" />
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" 
                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio" HeaderText="Cambio" >
                    <HeaderStyle Width="60px" />
                    <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:ButtonField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
                         </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="42%">
                            &nbsp;</td>
                        <td width="16%">
                            <br />
             <asp:HiddenField ID="Cve_putno" runat="server" />
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
        </div>
        </form>
    </center>
</body>
</html>
