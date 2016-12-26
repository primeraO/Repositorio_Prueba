<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Comp_Compras_Requisiciones.aspx.vb" Inherits="Comp_Compras_Requisiciones" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
    </script>
    <script type="text/javascript">

        function Solicitante(elemValue1, elemValue2) {
            document.getElementById('TB_Solicitante').value = elemValue1;
            __doPostBack("TB_Solicitante", "TextChanged");
        }

        function Centro_Costos(elemValue1, elemValue2) {
            document.getElementById('TB_Centro_Costo').value = elemValue1;
            __doPostBack("TB_Centro_Costo", "TextChanged");
        }
    </script>
    <link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>
       <style type="text/css">
          .overlay  
        {
    	    position: fixed;
    	    z-index: 98;
    	    top: 0px;
    	    left: 0px;
    	    right: 0px;
    	    bottom: 0px;
            
        }
        .overlayContent
        {
    	    z-index: 99;
    	    margin: 250px auto;
    	    width: 80px;
    	    height: 80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        .overlayContent img
        {
    	    width: 150px;
    	    height: 150px;
        }
           </style>
</head>
<body>
    <center>
        <form id="form1" runat="server" style="width: 984px">
         <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
   
    <ContentTemplate>   
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="20%"> 
                                                        &nbsp;</td>
                        <td width="60%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Comparativo"></asp:Label>
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
   
       
            <div>
                <asp:Button ID="Btn_Busca" runat="server" CssClass="Btn_Azul" 
                    Text="Busca" TabIndex="8" />
                <asp:Button ID="Btn_Salir" runat="server" CssClass="Btn_Azul" TabIndex="9" 
                    Text="Salir" />
            </div>
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
        
            <asp:Panel ID="P_Filtro" runat="server" CssClass="Paneles" Height="650px">
            <table style="width:100%;">
                <tr>
                    <td style="text-align: left" width="327px">
                        &nbsp;</td>
                    <td style="text-align: left" width="95px">
                        <asp:TextBox ID="TB_Requisicion" runat="server" CssClass="form-control" 
                            Width="70px" placeholder="Requisición" Height="18px" 
                            style="text-align:right; margin-top: 0px;" TabIndex="1" 
                            AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="text-align: left" width="10px">
                        &nbsp;</td>
                    <td style="text-align: left" width="80px">
                        <asp:TextBox ID="TB_Solicitante" runat="server" CssClass="form-control" Width="70px"
                        placeholder="Solicitante" Height="18px" style="text-align:right" TabIndex="1"></asp:TextBox>
                    </td>
                    <td width="30px" style="text-align: left">
                            <asp:ImageButton ID="Btn_Solicitante" runat="server" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png" />
                        </td>
                    <td width="10px">
                        &nbsp;</td>
                    <td style="text-align: left" width="80px">
                        <asp:TextBox ID="TB_Centro_Costo" runat="server" CssClass="form-control" Width="70px"
                        placeholder="CCostos" Height="18px" style="text-align:right" TabIndex="2"></asp:TextBox>
                    </td>
                    <td width="30px" style="text-align: left">
                            <asp:ImageButton ID="Btn_CentroCostos" runat="server" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png" />
                        </td>
                    <td style="text-align: left" width="125px">
                        </td>
                    <td style="text-align: left" width="327px">
                        &nbsp;</td>
                </tr>
            </table>
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: left" width="212px">
                            &nbsp;</td>
                        <td style="text-align: left" width="140px">
                            <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" 
                                Text="Rango de Fecha de:"></asp:Label>
                        </td>
                        <td style="text-align: left" width="90px">
                            <asp:TextBox ID="TB_Fecha_Inicial" runat="server" CssClass="form-control" 
                                Height="18px" MaxLength="10" Width="80px" TabIndex="4"></asp:TextBox>
                        </td>
                        <td width="20px">
                                    <rjs:PopCalendar ID="PC_Fecha_Inicial" runat="server" Separator="/" 
                                        Format="yyyy mm dd" Control="TB_Fecha_Inicial" />
                        </td>
                        <td width="30px">
                            <asp:Label ID="Label35" runat="server" CssClass="Textos_Azules" Text="A:"></asp:Label>
                        </td>
                        <td width="90px">
                            <asp:TextBox ID="TB_Fecha_Final" runat="server" CssClass="form-control" 
                                Height="18px" MaxLength="10" Width="80px" TabIndex="5"></asp:TextBox>
                        </td>
                        <td width="20px">
                                    <rjs:PopCalendar ID="PC_Fecha_Final" runat="server" Separator="/" 
                                        Format="yyyy mm dd" Control="TB_Fecha_Final" />
                        </td>
                        <td style="text-align: right" width="125px">
                            <asp:CheckBox ID="Ch_Fechas" runat="server" CssClass="Textos_Azules" 
                                Text="Filtro Fechas" TextAlign="Left" AutoPostBack="True" TabIndex="6" 
                                Checked="True" />
                            &nbsp;</td>
                        <td style="text-align: left" width="213px">
                            &nbsp;</td>
                    </tr>
                </table>
                
                <br />
                
                <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                    <div style="overflow:hidden; height: 40px; width:100%; float:left">
                        <asp:GridView ID="Cabecera" runat="server" AutoGenerateColumns="False" 
                            CellPadding="1" CellSpacing="3" Font-Size="Small" ForeColor="#333333" 
                            GridLines="None" Height="35px" ShowHeaderWhenEmpty="True" 
                            style="top: 152px; left: 86px; " Width="964px">
                            <RowStyle BackColor="#EFF3FB" Height="30px" />
                            <Columns>
                                <asp:BoundField HeaderText="Requisición">
                                <HeaderStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Sol.">
                                <HeaderStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre Solicitante">
                                <HeaderStyle Width="267px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="C. Costo">
                                <HeaderStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descripción">
                                <HeaderStyle Width="277px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha">
                                <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Requiere">
                                <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha Lib_Alm">
                                <HeaderStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Ver">
                                <HeaderStyle Width="30px" />
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                    <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:530px;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CellPadding="0" CellSpacing="3" DataKeyNames="Requisicion" Font-Size="Small" 
                            ForeColor="#333333" GridLines="None" Height="27px" ShowHeader="False" 
                            style="top: 152px; left: 86px; " Width="964px">
                            <RowStyle BackColor="#EFF3FB" Height="22px" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" Visible="False" />
                                <asp:BoundField DataField="Requisicion" HeaderText="Requisición">
                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Solicitante" HeaderText="Sol.">
                                <ItemStyle horizontalAlign="Right" Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nom_Solicitante" HeaderText="Nombre Solicitante">
                                <ItemStyle Width="277px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CenCos" HeaderText="C. Costo">
                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CenCos_Descripcion" HeaderText="Descripción">
                                <ItemStyle Width="277px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_Solicitud" HeaderText="Fecha">
                                <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_Requiere" HeaderText="Requiere">
                                <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha_Libera_Almacen" HeaderText="Fecha Lib_Alm">
                                <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:ButtonField ButtonType="Image" CommandName="Ver" HeaderText="Ver" 
                                    ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Botón">
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
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
                
            </asp:Panel>
            <div style="height: 15px">
            </div>
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
