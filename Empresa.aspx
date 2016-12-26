<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Empresa.aspx.vb" Inherits="Empresa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
<center>
    <form id="form1" runat="server" style="width: 984px">&nbsp;<div style="width: 984px">
        <table style="width:100%;">
            <tr>
                <td width="20%">
                    &nbsp;</td>
                <td width="60%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Cátalogo Empresas"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Compañia" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="#000087"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Obra" runat="server" Font-Bold="True" Font-Size="Small" 
                                    ForeColor="#000087"></asp:Label>
                            </asp:Panel>

                     </td>
                <td width="20%">
                        <asp:Image ID="Image2" runat="server" Height="61px" 
                            ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                            Width="174px" />
                        </td>
            </tr>
        </table>
    </div>
    <div style="width: 984px">
            <table __designer:mapid="ec" 
            style="vertical-align: top; background-color: #f5f6f7">
            <tr __designer:mapid="ed">
                <td __designer:mapid="ee" class="style3" 
                    style="vertical-align: top; background-color: #F5F6F7">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:ImageButton ID="Ima_Regresa" runat="server" ImageUrl="~/Imagenes/M_Salir_50.png" 
                        ToolTip="Regresa" style="text-align: center" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="1" ForeColor="#333333" GridLines="None" Height="16px" 
            ShowFooter="True" Width="770px" DataKeyNames="EmpresaNumero" 
            style="top: 33px; left: 71px" AllowPaging="True" CellSpacing="5" Font-Size="Small">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="EmpresaNumero">
                    <EditItemTemplate>
                        <asp:Label ID="L_EmpresaNumero" runat="server" 
                            Text='<%# Bind("EmpresaNumero") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="T_EmpresaNumero" runat="server" Enabled="False"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_EmpresaNumero" runat="server" 
                            Text='<%# Bind("EmpresaNumero") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Razón Social">
                    <EditItemTemplate>
                        <asp:TextBox ID="T_EmpresaNombre" runat="server" 
                            Text='<%# Bind("EmpresaNombre") %>' Width="314px" MaxLength="90"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="T_EmpresaNombre0" runat="server" Enabled="False" Width="311px" 
                            MaxLength="90"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_EmpresaNombre" runat="server" 
                            Text='<%# Bind("EmpresaNombre") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RFC">
                    <EditItemTemplate>
                        <asp:TextBox ID="T_EmpresaRFC" runat="server" 
                            Text='<%# Bind("EmpresaRFC") %>' Width="129px" MaxLength="13"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="T_EmpresaRFC0" runat="server" Enabled="False" MaxLength="13"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_EmpresaRFC" runat="server" Text='<%# Bind("EmpresaRFC") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Año">
                     <ItemTemplate>
                         <asp:Label ID="L_Año" runat="server" BorderStyle="None" 
                             Text='<%# Bind("Año") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                         <asp:TextBox ID="T_Año" runat="server" Text='<%# Bind("Año") %>' Width="53px"></asp:TextBox>
                     </EditItemTemplate>
                     <FooterTemplate>
                         <asp:TextBox ID="T_Año0" runat="server" Width="53px"></asp:TextBox>
                     </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:LinkButton ID="Lkb_Editar" runat="server" CausesValidation="False" 
                            CommandName="Edit">Editar</asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="Lkb_Actualizar" runat="server" CommandName="Update" 
                            ForeColor="White">Actualizar</asp:LinkButton>
                        <asp:LinkButton ID="Lnb_Cancelar" runat="server" CommandName="Cancel" 
                            ForeColor="White">Cancelar</asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="Lkb_Insertar" runat="server" CommandName="Insertar" 
                            ForeColor="White">Insertar</asp:LinkButton>
                        <asp:LinkButton ID="Lkb_Actualizar0" runat="server" CommandName="Insert" 
                            ForeColor="White" Visible="False">Actualizar</asp:LinkButton>
                        <asp:LinkButton ID="Lkb_Cancelar" runat="server" CommandName="Cancelar" 
                            ForeColor="White" Visible="False">Cancelar</asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:LinkButton ID="Lkb_Eliminar" runat="server" CommandName="Delete" 
                            onclientclick="return confirm('¿Esta seguro de eliminar este registro?');" 
                            >Eliminar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
                    <br __designer:mapid="f5" />
                </td>
            </tr>
        </table>
       </div>
    <div style="width: 984px">
            <asp:Image ID="Image1" runat="server" Height="100px" Width="200px" 
                        style="text-align: left" />
            <asp:FileUpload ID="FileUpload1" runat="server" Enabled="False" Width="236px" />
    </div>
    </form>
    </center>
</body>
</html>
