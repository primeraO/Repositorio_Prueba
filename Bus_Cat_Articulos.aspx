<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Bus_Cat_Articulos.aspx.vb" Inherits="Bus_Cat_Articulos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript" src="jquery.min.js"></script>
   
   <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Articulos(value1, value2, value3, value4) {
            var retvalue1 = value1;
            window.opener.Articulos(value1, value2, value3, value4);
            window.close();
        }
        function Articulo(value1, value2, value3) {
            var retvalue1 = value1;
            window.opener.Articulo(value1, value2, value3);
            window.close();
        }

        function Linea(elemValue1, elemValue2) {
            document.getElementById('<%= T_Grupo.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Grupo_Desc.ClientID %>').value = elemValue2;
            __doPostBack("T_Grupo", "TextChanged");
        }
       
        function Sub_Linea(elemValue1, elemValue2) {
            document.getElementById('<%= T_Sub_Grupo.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Sub_Grupo_Desc.ClientID %>').value = elemValue2;
            __doPostBack("T_Sub_Grupo", "TextChanged");
        }
       
    </script>
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 34px;
        }
    </style>
    </head>
<body OnLoad='compt=setTimeout("self.close();",60000)'>
    <form id="form1" runat="server" submitdisabledcontrols="False">
     <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <triggers>
              <asp:PostBackTrigger runat="server" ControlID="Ima_Busca"></asp:PostBackTrigger>
            </triggers>
           <ContentTemplate>
              
                       <asp:Panel ID="Pnl_Busqueda" runat="server" CssClass="Paneles" Width="750px" >
                        <table style="width:100%;">
                           <tr>
                               <td class="style1" width="10%">
                                   <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" 
                                       placeholder="Núm." Width="100px"></asp:TextBox>
                               </td>
                               <td class="style1" width="5%">
                               </td>
                               <td class="style1" width="10%">
                                   <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" 
                                       placeholder="Descripción" Width="370px"></asp:TextBox>
                               </td>
                               <td class="style1" width="7%">
                                   <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" />
                               </td>
                               <td class="style1" width="7%">
                               </td>
                               <td class="style1" style="text-align: left">
                                   &nbsp;</td>
                           </tr>
                           <tr>
                               <td width="10%">
                                   <asp:TextBox ID="T_Grupo" runat="server" 
                                       CssClass="form-control" placeholder="Grupo" Width="100px"></asp:TextBox>
                               </td>
                               <td width="5%">
                                   <asp:ImageButton ID="H_Grupo" runat="server" 
                                       ImageUrl="~/Imagenes/M_Buscar_50.png" style="width: 25px" ToolTip="Buscar"  />
                               </td>
                               <td width="10%">
                                   <asp:TextBox ID="T_Grupo_Desc" runat="server" CssClass="form-control" 
                                       placeholder="Descripción" Width="370px" BackColor="SkyBlue" 
                                       ReadOnly="True"></asp:TextBox>
                               </td>
                               <td width="7%">
                                   &nbsp;</td>
                               <td width="7%">
                                   &nbsp;</td>
                               <td style="text-align: left">
                                   &nbsp;</td>
                           </tr>
                       </table>
                     
                               <table style="width:100%;">
                                   <tr>
                                       <td width="10%">
                                           <asp:TextBox ID="T_Sub_Grupo" runat="server" CssClass="form-control" 
                                               placeholder="Subgrupo" Width="100px"></asp:TextBox>
                                       </td>
                                       <td width="5%">
                                           <asp:ImageButton ID="H_Sub_Grupo" runat="server" 
                                               ImageUrl="~/Imagenes/M_Buscar_50.png" style="width: 25px" ToolTip="Buscar" />
                                       </td>
                                       <td>
                                           <asp:TextBox ID="T_Sub_Grupo_Desc" runat="server" CssClass="form-control" 
                                               placeholder="Descripción" Width="370px" BackColor="SkyBlue" 
                                               ReadOnly="True"></asp:TextBox>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                   </tr>
                                   <tr>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
                                       <td>
                                           &nbsp;</td>
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
                                            <HeaderStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Número">
                                            <HeaderStyle  Width="95px" HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripción" >
                                            <HeaderStyle Width="370px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Grupo" >
                                            <HeaderStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Subgrupo" >
                                            <HeaderStyle Width="70px" />
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:720px; height:200px;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="None" style="top: 152px; left: 86px; " Font-Size="Small" 
                Width="700px" Height="16px" CellSpacing="4" DataKeyNames="Numero" ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:TemplateField HeaderText="Sel.">
                        <ItemTemplate>
                            <asp:ImageButton ID="Seleccionar" runat="server" Text="Seleccionar" ImageUrl="~/Imagenes/M_Salva_50.png"></asp:ImageButton>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Numero" HeaderText="Num." >
                    <ItemStyle Width="95px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Art_Descripcion" HeaderText="Descripcion" >
                    <ItemStyle HorizontalAlign="Left" Width="370px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Lin_Numero" HeaderText="Grupo">
                    <ItemStyle HorizontalAlign="Left" Width="50px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="Sub_Numero" HeaderText="Subgrupo" >
                    <ItemStyle HorizontalAlign="Right" Width="70px"/>
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
    </form>
</body>
</html>
