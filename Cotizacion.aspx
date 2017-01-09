<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Cotizacion.aspx.vb" Inherits="Cotizacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jquery.min.js"></script>
    <script language="javascript" src="bootstrapjs.min.js" type="text/javascript"></script>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">         alert("Error al abrir archivo.js");</script>
    
    <%--<script type="text/javascript">
        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; }
    </script>--%>
    <style type="text/css">
        .style2
        {
            text-align: left;
        }
        .style3
        {
            text-align: left;
        }
        .style4
        {
            text-align: left;
        }
        .style5
        {
            text-align: left;
        }
        .style8
        {
            text-align: left;
        }
        .style9
        {
            text-align: right;
        }
        .style10
        {
            text-align: right;
        }
        .style12
        {
            text-align: left;
        }
        .style13
        {
            text-align: center;
        }
        .style14
        {
            text-align: left;
        }
        .style15
        {
            text-align: center;
        }
        .style16
        {
            text-align: left;
        }
        .style17
        {
            text-align: left;
        }
        .style18
        {
            text-align: left;
        }
        .style19
        {
            text-align: left;
        }
        .style20
        {
            text-align: left;
        }
        </style>
    <script type="text/javascript">
        //Buscador de Cliente
        function cliente(elemValue1, elemValue2) {
            document.getElementById('<%= TB_Cliente.ClientID %>').value = elemValue1;
            document.getElementById('<%= TB_Cliente_Razon_Social.ClientID %>').value = elemValue2;
            __doPostBack("TB_Cliente", "TextChanged");
        }
        //Buscardor de Pedido
        function Pedido(elemValue1, elemValue2) {
            document.getElementById('<%= TB_Cotizacion.ClientID %>').value = elemValue1;
            document.getElementById('<%= TB_Cotizacion_Razon_Social.ClientID %>').value = elemValue2;
            __doPostBack("TB_Cotizacion", "TextChanged");
        }
        //Buscador de Articulo
        function Articulo(elemValue1, elemValue2) {
            document.getElementById('<%= TB_Articulo.ClientID %>').value = elemValue1;
            document.getElementById('<%= TB_Articulo_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("TB_Articulo", "TextChanged");
        }
        //Buscar Cliente
        //function cliente(elemValue1, elemValue2, elemValue3) {
          //  document.getElementById('<%= T_Cliente.ClientID %>').value = elemValue1;
            //document.getElementById('<%= T_Cliente_Razon_Social.ClientID %>').value = elemValue2;
            //__doPostBack("T_Cliente", "TextChanged");
        //}
        //Buscar Articulo
        function Articulos(elemValue1, elemValue2 ) {
            document.getElementById('<%= T_Articulo.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Articulo_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Articulo", "TextChanged");
        }

        function ocultarMensage() {
            $("#Msg_Err").css("display","block")
            $("#Msg_Err").delay("800").fadeOut("800")
        }

    </script>
</head>
<body>
    <center>
        <form id="form1" runat="server" style="width: 984px; margin-right: 0px;">
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="20%">&nbsp;</td>
                        <td width="60%">
                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" Height="40px" Text="Pedidos"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Compañia" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#000087"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Obra" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#000087"></asp:Label>
                                <br />
                                <asp:Label ID="Lbl_Usuario" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#000087"></asp:Label>
                            </asp:Panel>
                        </td>
                        <td style="text-align: right" width="20%">
                             <asp:Image ID="Img_Logotipo" runat="server" Height="61px" style="text-align: right" Width="174px" />
                             <br />
                             <br />
                             <br />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <%-- <Triggers>
        <asp:PostBackTrigger ControlID="Movimiento" />
        </Triggers>--%>
                <ContentTemplate>
                    <asp:Panel ID="P_Botones" runat="server">
                        <div>
                            <asp:Button ID="Btn_Busca" runat="server" CssClass="Btn_Azul" TabIndex="1" Text="Busca" />
                            <asp:Button ID="Btn_Alta" runat="server" CssClass="Btn_Azul" TabIndex="2" Text="Alta" />
                            <asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" TabIndex="3" Text="Restaura" />
                            <asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" TabIndex="4" Text="Guarda" />
                            <asp:Button ID="Btn_Regresa" runat="server" CssClass="Btn_Azul" TabIndex="5" Text="Regresa" />
                        </div>  
                    </asp:Panel>
                    <div style="height: 8px"></div>
                    <div>
                        <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" BorderStyle="Solid" ForeColor="#FF3300" style="float: none; text-align: center; display:none" Text="Label" Width="96%"></asp:Label>
                    </div>
                    <div style="height: 8px"></div>
                    <asp:Panel ID="P_Buscar" runat="server">
                        <div>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style16">
                                        <asp:Label ID="Label56" runat="server" CssClass="Textos_Azules" Text="Cliente"></asp:Label>
                                    </td>
                                    <td width="120px">
                                        <asp:TextBox ID="TB_Cliente" runat="server" CssClass="form-control" Width="100px" style="text-align:right;" AutoPostBack="True" TabIndex="6"></asp:TextBox>
                                    </td>
                                    <td width="20px">
                                        <asp:ImageButton ID="BtnB_Cliente" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png" Width="29px" TabIndex="3000" />
                                    </td>
                                    <td width="300px">
                                        <asp:TextBox ID="TB_Cliente_Razon_Social" runat="server" CssClass="form-control-Readonly" Width="280px" Style="text-transform: uppercase" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="300px">
                                        &nbsp;</td>
                                    <td class="style18">
                                        <asp:CheckBox ID="Ch_Baja" runat="server" CssClass="Textos_Azules" Text="Baja" AutoPostBack="True" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style17" width="80px">
                                        <asp:Label ID="Label57" runat="server" CssClass="Textos_Azules" Text="Cotizacion"></asp:Label>
                                    </td>
                                    <td width="120px">
                                        <asp:TextBox ID="TB_Cotizacion" runat="server" CssClass="form-control" Width="100px" Style="text-transform: uppercase" AutoPostBack="True" TabIndex="7"></asp:TextBox>
                                    </td>
                                    <td width="20px">
                                        <asp:ImageButton ID="BtnB_Cotizacion" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png" Width="29px" TabIndex="3000" />
                                    </td>
                                    <td width="300px">
                                        <asp:TextBox ID="TB_Cotizacion_Razon_Social" runat="server" 
                                            CssClass="form-control-Readonly" Width="280px"  
                                            Style="text-transform: uppercase" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="300px">&nbsp;</td>
                                    <td class="style19">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style17" width="80px">
                                        <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" Text="Articulo"></asp:Label>
                                    </td>
                                    <td width="120px">
                                        <asp:TextBox ID="TB_Articulo" runat="server" CssClass="form-control" Width="100px" Style="text-transform: uppercase" AutoPostBack="True" TabIndex="7"></asp:TextBox>
                                    </td>
                                    <td width="20px">
                                        <asp:ImageButton ID="BtnB_Articulo" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png" Width="29px" TabIndex="3000" />
                                    </td>
                                    <td width="300px">
                                        <asp:TextBox ID="TB_Articulo_Descripcion" runat="server" 
                                            CssClass="form-control-Readonly" Width="280px" 
                                            Style="text-transform: uppercase" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="300px">&nbsp;</td>
                                    <td class="style19">&nbsp;</td>
                                </tr>
                            </table>
                            <div style="height: 20px"></div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="P_Campos_Alta" runat="server">
                        <div>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style3" width="80px">
                                        <asp:Label ID="Label48" runat="server" CssClass="Textos_Azules" Text="Cliente"></asp:Label>
                                    </td>
                                    <td width="100px">
                                        <asp:TextBox ID="T_Cliente" runat="server" CssClass="form-control" Width="100px" style="text-align:right; margin-left: 2px;" AutoPostBack="True" TabIndex="8"></asp:TextBox>
                                    </td>
                                    <td width="20px">
                                        <asp:ImageButton ID="Btn_Cliente" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png" Width="29px" TabIndex="3000" />
                                    </td>
                                    <td class="style8" width="300px">
                                        <asp:TextBox ID="T_Cliente_Razon_Social" runat="server" CssClass="form-control-Readonly" Width="280px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="style2" width="70px">
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label2" runat="server" CssClass="Textos_Azules" Text="Pedido"></asp:Label>
                                    </td>
                                    <td class="style9">
                                        <asp:TextBox ID="T_Pedido" runat="server" CssClass="form-control-Readonly" Width="50px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style3" width="80px">
                                        <asp:Label ID="Label46" runat="server" CssClass="Textos_Azules" Text="Articulo"></asp:Label>
                                    </td>
                                    <td width="100px">
                                        <asp:TextBox ID="T_Articulo" runat="server" CssClass="form-control" style="text-align:right; margin-left: 2px;" Width="100px" TabIndex="9" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td width="20px">
                                        <asp:ImageButton ID="Btn_Articulo" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png" Width="29px" TabIndex="3000" />
                                    </td>
                                    <td width="300px">
                                        <asp:TextBox ID="T_Articulo_Descripcion" runat="server" CssClass="form-control-Readonly" Width="280px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="style10" width="120px"></td>
                                    <td class="style12"></td>
                                </tr>
                            </table>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style4" width="80px">
                                        <asp:Label ID="Label47" runat="server" CssClass="Textos_Azules" Text="Uni. Med."></asp:Label>
                                    </td>
                                    <td width="100px">
                                        <asp:TextBox ID="T_Unidad_Medida" runat="server" CssClass="form-control" Width="100px" MaxLength="5"  Style="text-transform: uppercase" TabIndex="10" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="130px">
                                        &nbsp;
                                        <asp:Label ID="Label52" runat="server" CssClass="Textos_Azules" Text="Cantidad Pedida"></asp:Label>
                                    </td>
                                    <td width="80px">
                                        <asp:TextBox ID="T_Cantidad" runat="server" CssClass="form-control" 
                                            Width="60px" style="text-align:right;" TabIndex="11"></asp:TextBox>
                                    </td>
                                    <td class="style5" width="110px">
                                        &nbsp;
                                        <asp:Label ID="Label54" runat="server" CssClass="Textos_Azules" Text="Precio Unidad"></asp:Label>
                                    </td>
                                    <td width="100px">
                                        <asp:TextBox ID="T_Precio" runat="server" CssClass="form-control" Width="100px" style="text-align:right;" TabIndex="14" AutoPostBack="True" ReadOnly="True">0.00</asp:TextBox>
                                    </td>
                                    <td class="style15" width="60px">
                                        <asp:Label ID="Label53" runat="server" CssClass="Textos_Azules" Text="I.V.A."></asp:Label>
                                    </td>
                                    <td class="style15">
                                        <asp:TextBox ID="T_IVA" runat="server" CssClass="form-control" Width="40px" 
                                            style="text-align:right;" TabIndex="15" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="style14">&nbsp;</td>
                                </tr>
                            </table>
                            <table style="width:100%;">
                                <tr>
                                    <td width="80px">
                                        <asp:Label ID="Label49" runat="server" CssClass="Textos_Azules" Text="Marca"></asp:Label>
                                    </td>
                                    <td width="80px">
                                        <asp:TextBox ID="T_Marca" runat="server" CssClass="form-control" Width="100px" style="text-align:right;" TabIndex="13" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="style20" width="80px">
                                        &nbsp;
                                        <asp:Label ID="Label58" runat="server" CssClass="Textos_Azules" Text="Linea"></asp:Label>
                                    </td>
                                    <td width="120px">
                                        <asp:TextBox ID="T_Linea" runat="server" CssClass="form-control" Width="100px" TabIndex="16" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="Btn_agregar" runat="server" CssClass="Btn_Azul" TabIndex="1" Text="Agregar" />
                                    </td>
                                    <td class="style14">&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>          
                    <div style="height: 15px"></div>
                    <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                        <div style="overflow:hidden; height:35px; width:100%; float:left" >
                            <asp:GridView id="Cabecera" runat="server" AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" style="top: 152px; left: 86px; " Font-Size="Small" Width="964px" Height="35px" CellSpacing="3">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField HeaderText="Pedido">
                                        <HeaderStyle  Width="70px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cliente" >
                                        <HeaderStyle Width="500px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderText="Fecha" >
                                        <HeaderStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cambio" >
                                        <HeaderStyle  Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Baja" >
                                        <HeaderStyle  Width="50px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                        <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:350px;">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="0" CellSpacing="3" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="27px" 
                                style="top: 152px; left: 86px; margin-right: 0px;" Width="964px" 
                                TabIndex="12336" ShowHeader="False">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField DataField="Pedido">
                                        <ItemStyle Width="70px" HorizontalAlign="right"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Razon_Social">
                                        <ItemStyle Width="494px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fecha_Pedido">
                                        <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                        <ItemStyle Width="50px" HorizontalAlign="Center"/>
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja">
                                        <ItemStyle Width="50px" HorizontalAlign="Center"/>
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
                    <asp:Panel ID="Pnl_Grids2" runat="server" HorizontalAlign="Left" Visible="False">
                        <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:350px;">
                            <asp:GridView id="Cabecera2" runat="server" AutoGenerateColumns="False" CellPadding="0" CellSpacing="3" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" style="top: 152px; left: 86px; " Font-Size="Small" Width="964px" Height="35px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField HeaderText="Partida" DataField="Partida">
                                        <HeaderStyle  Width="50px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Articulo" DataField="Numero_Articulo" >
                                        <HeaderStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderText="Descripcion" DataField="Descripcion_Articulo" >
                                        <HeaderStyle Width="500px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Uni. Med" DataField="Unidad_Medida">
                                        <HeaderStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad_Pedida" >
                                        <HeaderStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Precio" DataField="Precio_Base">
                                        <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="IVA" DataField="Base_IVA" >
                                        <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Marca" Visible="False" />
                                    <asp:BoundField DataField="Linea" Visible="False" />
                                    <asp:ButtonField ButtonType="Image" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" CommandName="Cambio" >
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" HeaderText="Baja" 
                                        ImageUrl="~/Imagenes/M_Baja_50.png" CommandName="Baja" >
                                    <ItemStyle HorizontalAlign="Center" />
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
                    <asp:HiddenField ID="Movimiento" runat="server" />
                    <asp:HiddenField ID="MovimientoDetalle" runat="server" Value="Alta" />        
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
        </form>
    </center>
</body>
</html>


