<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="Catalogo_Servidores.aspx.vb" Inherits="Catalogo_Servidores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catálogo de Servidores</title>
    <style type="text/css">
        #form1
        {
            height: 727px;
            margin-bottom: 0px;
        }
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 153px;
        }
        .style3
        {
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">--%><%--   </asp:Content>--%>
    
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <br />
                <br />
                     <asp:ImageButton ID="Btn_Buscar" runat="server" 
                         ImageUrl="~/Imagenes/M_Buscar_50.png" ToolTip="Buscar" />
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="Btn_Alta" runat="server" 
                         ImageUrl="~/Imagenes/M_Alta_50.png" ToolTip="Adicionar" 
                    onclientclick="   " />
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="Btn_Baja" runat="server" 
                         ImageUrl="~/Imagenes/M_Baja_50.png" ToolTip="Baja" TabIndex="32" />
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="Btn_Cambio" runat="server" 
                         ImageUrl="~/Imagenes/M_Cambio_50.png" ToolTip="Cambio" 
                    TabIndex="33" />
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="Btn_Restaura" runat="server" 
                         ImageUrl="~/Imagenes/M_Regresa_50.png" ToolTip="Restaurar" 
                    TabIndex="34" />
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="Btn_Guardar" runat="server" 
                         ImageUrl="~/Imagenes/M_Salva_50.png" ToolTip="Salvar" TabIndex="30" />
                     &nbsp;&nbsp;
                     <asp:ImageButton ID="Btn_Regresar" runat="server" 
                         ImageUrl="~/Imagenes/M_Salir_50.png" ToolTip="Regresar" 
                    TabIndex="35" />
                 </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <br />
                     <asp:Label ID="Label18" runat="server" BorderStyle="None" Text="Nombre" 
                         Width="94px"></asp:Label>
            <asp:TextBox ID="T_Nombre" runat="server" 
             style="text-align:left; top: 493px; left: 645px; " MaxLength="100" TabIndex="2" 
                    Width="227px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label20" runat="server" BorderStyle="None" Text="Servidor" 
                         Width="94px"></asp:Label>
            <asp:TextBox ID="T_Servidor" runat="server" 
             style="text-align:left; top: 493px; left: 645px; " MaxLength="100" TabIndex="2" 
                    Width="227px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="Base" 
                         Width="94px"></asp:Label>
            <asp:TextBox ID="T_Base" runat="server" 
             style="text-align:left; top: 493px; left: 645px; " MaxLength="100" TabIndex="3" 
                    Width="227px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label17" runat="server" BorderStyle="None" Text="Usuario" 
                         Width="94px"></asp:Label>
         <asp:TextBox ID="T_Usuario" runat="server" 
                  style="top: 550px; left: 155px; right: 66px; bottom: 70px;" 
                MaxLength="20" TabIndex="4" Width="226px"></asp:TextBox>
                     <br />
                     <asp:Label ID="Label19" runat="server" BorderStyle="None" Text="Acceso" 
                         Width="94px"></asp:Label>
            <asp:TextBox ID="T_Acceso" runat="server" 
             style="text-align:left; top: 493px; left: 645px; " MaxLength="20" TabIndex="5" 
                    Width="227px"></asp:TextBox>
                     <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style2">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
            GridLines="None" 
             style="top: 152px; left: 86px; " 
             ToolTip="Datos" DataKeyNames="Conexion_Desc" Font-Size="Small" 
                         Width="733px" EnableModelValidation="True" 
                         CellSpacing="5">
            <RowStyle BackColor="#EFF3FB" Height="22px" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" >
                <ItemStyle Width="80px" />
                </asp:CommandField>
                <asp:BoundField DataField="Conexion_Desc" HeaderText="Nombre" >
                <ItemStyle Width="150px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Servidor" HeaderText="Servidor" />
                <asp:BoundField DataField="BaseNombre" HeaderText="Base de Datos" >
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style3">
                     <br />
         <asp:HiddenField ID="Movimiento" runat="server" />
                 </td>
            <td class="style3">
            </td>
        </tr>
    </table>
    
    </form>
</body>
</html>
