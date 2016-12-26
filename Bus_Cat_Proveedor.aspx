<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Bus_Cat_Proveedor.aspx.vb" Inherits="Bus_Cat_Proveedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="jquery.min.js"></script>
  <%--  <script type="text/javascript" src="Encripta.js"></script>--%>
    <script type="text/javascript">
        function Proveedor(value1, value2,value3) {
            var retvalue1 = value1;
            window.opener.Proveedor(value1, value2,value3);
            window.close();
        }
        function Proveedores1(value1, value2, value3) {
            var retvalue1 = value1;
            window.opener.Proveedores1(value1, value2, value3);
            window.close();
        }
        function Proveedores2(value1, value2, value3) {
            var retvalue1 = value1;
            window.opener.Proveedores2(value1, value2, value3);
            window.close();
        }
        function Proveedores3(value1, value2, value3) {
            var retvalue1 = value1;
            window.opener.Proveedores3(value1, value2, value3);
            window.close();
        }
    </script>
    <title></title>
    </head>
<body OnLoad='compt=setTimeout("self.close();",60000)'>
    <form id="form1" runat="server" submitdisabledcontrols="False">
     <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <triggers>
              <%--<asp:PostBackTrigger runat="server" ControlID=""></asp:PostBackTrigger>--%>
            </triggers>
           <ContentTemplate>
               <asp:Panel ID="Pnl_Busqueda" runat="server" CssClass="Paneles" Width="750">
                <table style="width:100%;">
                   <tr>
                       <td width="7%">
                           <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" Width="36px" 
                               placeholder="Núm."></asp:TextBox>
                       </td>
                       <td width="25%">
                           <asp:TextBox ID="T_Descipcion" runat="server" CssClass="form-control" 
                               Width="289px" placeholder="Razon Social"></asp:TextBox>
                       </td>
                       <td width="20%">
                           <asp:TextBox ID="T_RFC" runat="server" CssClass="form-control" Width="167px" placeholder="RFC"></asp:TextBox>
                       </td>
                       <td>
                           <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" />
                       </td>
                       <td width="10%">
                       </td>
                   </tr>
               </table>
               <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="True">
                                  <div style="overflow:hidden; height:35px; width:720px; float:left" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="700px" Height="35px" CellSpacing="4">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:TemplateField HeaderText="Sel.">
                                            <ItemTemplate>
                                            <asp:ImageButton ID="Seleccionar" runat="server" Text="Seleccionar" ImageUrl="~/Imagenes/M_Salva_50.png"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Numero" HeaderText="Num." >
                                            <HeaderStyle Width="10px" HorizontalAlign="LEFT" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Razon_Social" HeaderText="Razon Social" >
                                            <HeaderStyle Width="250px" HorizontalAlign="LEFT" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Rfc" HeaderText="RFC" >
                                            <HeaderStyle Width="150px" HorizontalAlign="LEFT" />
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:720px; height:250px;">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" 
                 style="top: 152px; left: 86px; " Font-Size="Small" 
                             Width="700px" Height="16px" CellSpacing="4" 
                   DataKeyNames="Numero" ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:TemplateField HeaderText="Sel.">
                        <ItemTemplate>
                            <asp:ImageButton ID="Seleccionar" runat="server" Text="Seleccionar" ImageUrl="~/Imagenes/M_Salva_50.png"></asp:ImageButton>
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="Numero" HeaderText="Número" >
                        <ItemStyle Width="30px" HorizontalAlign="LEFT" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Razon_Social" HeaderText="Razon Social">
                        <ItemStyle Width="250px" HorizontalAlign="LEFT" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Rfc" HeaderText="RFC">
                        <ItemStyle Width="150px" HorizontalAlign="LEFT" />
                    </asp:BoundField>
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
               <br />
              
        <%--<div style="overflow-y:scroll; overflow-x:hidden; height:400px; width:100%;">
            
                        <asp:GridView ID="GridView1" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="0" CellSpacing="3" 
                                        DataKeyNames="Numero" Font-Size="Small" ForeColor="#333333" 
                                        GridLines="None" Height="27px" style="top: 1px; left: 1px; margin-right: 0px; height:85px; overflow:auto" 
                                        Width="100%" HeaderStyle-CssClass="FixedHeader" PageSize="3"
                                        >
            <RowStyle BackColor="#EFF3FB" Height="22px" />
            <Columns>
                <asp:TemplateField HeaderText="Sel.">
                     <ItemTemplate>
                        <asp:ImageButton ID="Seleccionar" runat="server" Text="Seleccionar" ImageUrl="~/Imagenes/M_Salva_50.png"></asp:ImageButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Numero" HeaderText="Número" >
                <ItemStyle Width="50px" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Razon_Social" HeaderText="Razon Social" />
                <asp:BoundField DataField="Rfc" HeaderText="RFC" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>--%>
                 <asp:HiddenField ID="Parametro" runat="server" />
                 <br />
        </ContentTemplate>
          
        </asp:UpdatePanel>
         <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="overlay" />
                <div class="overlayContent">
                    <img src="Imagenes/cargando.gif" alt="Loading"  />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
     <%--<div style="overflow-y:scroll; overflow-x:hidden; height:400px; width:100%;">
            
                        <asp:GridView ID="GridView1" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="0" CellSpacing="3" 
                                        DataKeyNames="Numero" Font-Size="Small" ForeColor="#333333" 
                                        GridLines="None" Height="27px" style="top: 1px; left: 1px; margin-right: 0px; height:85px; overflow:auto" 
                                        Width="100%" HeaderStyle-CssClass="FixedHeader" PageSize="3"
                                        >
            <RowStyle BackColor="#EFF3FB" Height="22px" />
            <Columns>
                <asp:TemplateField HeaderText="Sel.">
                     <ItemTemplate>
                        <asp:ImageButton ID="Seleccionar" runat="server" Text="Seleccionar" ImageUrl="~/Imagenes/M_Salva_50.png"></asp:ImageButton>
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Numero" HeaderText="Número" >
                <ItemStyle Width="50px" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Razon_Social" HeaderText="Razon Social" />
                <asp:BoundField DataField="Rfc" HeaderText="RFC" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>--%>
    </form>
</body>
</html>
