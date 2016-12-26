<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Comp_Compras_Detalle.aspx.vb" Inherits="Comp_Compras_Detalle" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Ejemplo_Estilos1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jquery.min.js"></script>
     <script language="javascript" src="bootstrapjs.min.js" type="text/javascript"></script>
    <script language="javascript" src="CodigoJS.js"  type="text/javascript">
    </script>
    <%--<script type="text/javascript">
        document.onkeydown = function (evt) { return (evt ? evt.which : event.keyCode) != 13; }
    </script>--%>
    <style type="text/css">
        .style1
        {
            width: 90px;
        }
        .style2
        {
            text-align: left;
        }
        .style7
        {
            width: 141px;
        }
        .style9
        {
            width: 140px;
        }
        .style13
        {
            text-align: left;
        }
        .style17
        {
            text-align: left;
            width: 128px;
        }
        .style18
        {
            text-align: left;
            width: 122px;
        }
        .style19
        {
            text-align: left;
            width: 124px;
        }
        .style20
        {
            text-align: left;
            width: 120px;
        }
        .style23
        {
            width: 130px;
        }
        .style26
        {
            text-align: left;
            width: 127px;
        }
        .style27
        {
            text-align: left;
            width: 121px;
        }
    </style>
    <script type="text/javascript">
        function Monedas(elemValue1, elemValue2, Num_Prov) {
            if (Num_Prov == "1") {
                document.getElementById('<%= T_Moneda1.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Moneda_Desc1.ClientID %>').value = elemValue2;
                __doPostBack("T_Moneda1", "TextChanged");
            } else if (Num_Prov == "2") {
                document.getElementById('<%= T_Moneda2.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Moneda_Desc2.ClientID %>').value = elemValue2;
                __doPostBack("T_Moneda2", "TextChanged");
            } else if (Num_Prov == "3") {
                document.getElementById('<%= T_Moneda3.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Moneda_Desc3.ClientID %>').value = elemValue2;
                __doPostBack("T_Moneda3", "TextChanged");
            }

        }

        function Proveedores1(elemValue1, elemValue2, elemValue3) {
            document.getElementById('<%= T_Proveedor1.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Proveedor_Desc1.ClientID %>').value = elemValue2;
            document.getElementById('<%= T_Proveedor1_RFC.ClientID %>').value = elemValue3;
            __doPostBack("T_Proveedor1", "TextChanged");
        }
        function Proveedores2(elemValue1, elemValue2, elemValue3) {
            document.getElementById('<%= T_Proveedor2.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Proveedor_Desc2.ClientID %>').value = elemValue2;
            document.getElementById('<%= T_Proveedor2_RFC.ClientID %>').value = elemValue3;
            __doPostBack("T_Proveedor2", "TextChanged");
         }
         function Proveedores3(elemValue1, elemValue2, elemValue3) {
             document.getElementById('<%= T_Proveedor3.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Proveedor_Desc3.ClientID %>').value = elemValue2;
             document.getElementById('<%= T_Proveedor3_RFC.ClientID %>').value = elemValue3;
             __doPostBack("T_Proveedor3", "TextChanged");
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
        <form id="form1" runat="server" style="width: 984px; margin-right: 0px;">
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="20%"> 
                                                        &nbsp;</td>
                        <td width="60%">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Comparativo de Proveedores"></asp:Label>
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
            
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <triggers>
              <asp:PostBackTrigger runat="server" ControlID="Btn_Restaura"></asp:PostBackTrigger>
            </triggers>
            <ContentTemplate>--%>
                <asp:Panel ID="P_Botones" runat="server">
                <div>
                    <asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" TabIndex="12225" 
                        Text="Guardar"/>
                    <asp:Button ID="Btn_Exporta" runat="server" CssClass="Btn_Azul" 
                        Text="Exporta Excel" TabIndex="2000" />
                         <asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" 
                        TabIndex="2000" Text="Restaura" />
                    <asp:Button ID="Btn_Regresar" runat="server" CssClass="Btn_Azul" 
                        TabIndex="2000" Text="Regresa" />
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
                    <asp:Panel ID="P_Req_Partidas" runat="server" CssClass="Paneles" Height="650px">
                        <div>
                            <table style="width:100%;">
                                <tr>
                                    <td style="text-align: left" width="90px">
                                        <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" 
                                            Text="Requisición:"></asp:Label>
                                    </td>
                                    <td style="text-align: left" width="90px">
                                        <asp:Label ID="Lbl_Requisicion" runat="server" CssClass="Textos_Azules"></asp:Label>
                                    </td>
                                    <td width="15px">
                                        &nbsp;</td>
                                    <td style="text-align: left" width="130px">
                                        <asp:Label ID="Label46" runat="server" CssClass="Textos_Azules" 
                                            Text="Centro de Costos:"></asp:Label>
                                    </td>
                                    <td style="text-align: left" width="80px">
                                        <asp:Label ID="Lbl_Centro_Costo" runat="server" CssClass="Textos_Azules"></asp:Label>
                                    </td>
                                    <td width="20px">
                                        &nbsp;</td>
                                    <td style="text-align: left" class="style1">
                                        <asp:Label ID="Label47" runat="server" Text="Solicitante:" 
                                            CssClass="Textos_Azules"></asp:Label>
                                    </td>
                                    <td style="text-align: left" width="120px">
                                        <asp:Label ID="Lbl_Solicitante" runat="server" CssClass="Textos_Azules"></asp:Label>
                                    </td>
                                    <td style="text-align: left" width="20px">
                                        &nbsp;</td>
                                    <td style="text-align: left" width="110px">
                                        <asp:CheckBox ID="Ch_Limpiar" runat="server" Checked="True" 
                                            CssClass="Textos_Azules" Text="Limpia" />
                                    </td>
                                    <td style="text-align: left">
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </div>

                        <div style="height: 15px"></div>
                       <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left">
                        <div style="overflow:hidden; height:35px; width:100%;" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="4">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Articulo">
                                            <HeaderStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripción" >
                                            <HeaderStyle Width="170px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Cantidad"  >
                                            <HeaderStyle  Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Asignada"  >
                                            <HeaderStyle  Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="P. Concurso" >
                                            <HeaderStyle Width="80px"  />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="C.Costo" >
                                            <HeaderStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Requiere"  >
                                            <HeaderStyle  Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Proveedor" >
                                            <HeaderStyle Width="100px"  />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Entregada" >
                                            <HeaderStyle Width="80px"  />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Urgente" >
                                            <HeaderStyle Width="60px"  />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Generada" >
                                            <HeaderStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Ver"  >
                                            <HeaderStyle  Width="30px" />
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
                         <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:570px;">
                            <asp:GridView ID="GridView1" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" CellSpacing="4" 
                                DataKeyNames="Art_Numero" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="27px" style="top: 152px; left: 86px; " 
                                Width="964px" TabIndex="12336" ShowHeader="False">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False" />
                                    <asp:BoundField DataField="Art_Numero" HeaderText="Articulo">
                                    <ItemStyle HorizontalAlign="Left" Width="90px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Art_Descripcion" HeaderText="Descripcion" >
                                    <ItemStyle HorizontalAlign="Left" Width="150px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cant. Pedida" 
                                        DataFormatString="{0:N2}" >
                                    <ItemStyle HorizontalAlign="Right" Width="80px"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Asignada" DataField="Asignada" 
                                        DataFormatString="{0:N2}" >
                                    <ItemStyle HorizontalAlign="Right"  Width="80px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Precio_Concurso" HeaderText="P. Concurso" 
                                        DataFormatString="{0:N2}" >
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CenCosto" HeaderText="C. Costo" >
                                    <ItemStyle HorizontalAlign="Right" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fecha_Requiere" HeaderText="Requiere"  >
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Proveedor1" HeaderText="Proveedor" >
                                    <ItemStyle HorizontalAlign="Right" Width="100px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fecha_Entrega" HeaderText="Entrega"  >
                                    <ItemStyle HorizontalAlign="Right" Width="80px" />
                                    </asp:BoundField>
                                    <asp:CheckBoxField HeaderText="Urgente" DataField="Urgente" >
                                    <ItemStyle Width="60px" HorizontalAlign="Center"/>
                                    </asp:CheckBoxField>
                                    <asp:CheckBoxField HeaderText="Gen. OC." DataField="Generada" >
                                    <ItemStyle Width="60px" HorizontalAlign="Center"/>
                                    </asp:CheckBoxField>
                                    <asp:BoundField HeaderText="Lug.Entrega" Visible="False" 
                                        DataField="Lugar_Entrega" />
                                    <asp:ButtonField ButtonType="Image" CommandName="Ver" 
                                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Button">
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
                </div>
                <div style="height: 20px" ></div>
                <asp:Panel ID="Proveedores" runat="server" Visible="False" 
                CssClass="Paneles" Height="650px">
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td width="150px">
                                    <asp:Label ID="Lbl_Articulo" runat="server" Text="Articulo:" 
                                        CssClass="Textos_Azules"></asp:Label>
                                </td>
                                <td width="464px">
                                    <asp:Label ID="Lbl_DescArticulo" runat="server" 
                                        Text="Descripción: RADIO TRANSMISOR PORTATIL KENWOOD MOD.TK-2102GDS" 
                                        CssClass="Textos_Azules"></asp:Label>
                                </td>
                                <td width="150px">
                                    <asp:Label ID="Lbl_CantArticulo" runat="server" Text="Cantidad: 5000" 
                                        CssClass="Textos_Azules"></asp:Label>
                                </td>
                                <td width="220px">
                                    <asp:Label ID="Lbl_PreConArticulo" runat="server" 
                                        Text="Precio Concurso: $50,000.00" CssClass="Textos_Azules"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="height: 15px">
                    </div>
                <div class="">
	                <ul class="nav nav-tabs" id="">
		                <li class="active"><a href="#Protab1" data-toggle="tab">Proveedor 1</a></li>
		                <li><a href="#Protab2" data-toggle="tab">Proveedor 2</a></li>
		                <li><a href="#Protab3" data-toggle="tab">Proveedor 3</a></li>
	                </ul>

	                <div class="tab-content">
                        <%--PROVEEDOR 1--%>
		                <div class="tab-pane fade  in active" id="Protab1">
                        <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePane2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                <div>
                                    <table style="width: 100%; border-bottom-style: solid; border-bottom-color: #3366FF;">
                                        <tr>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                            <td class="style23">
                                                <asp:Label ID="Label48" runat="server" CssClass="Textos_Azules" 
                                                    Text="PROVEEDOR 1"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                                </td>
                                            <td style="text-align: left" width="13%">
                                               
                                                    <asp:Label ID="Label49" runat="server" CssClass="Textos_Azules" 
                                                        Text="Proveedor"></asp:Label>

                                            </td>
                                            <td width="8%">
                                                <asp:TextBox ID="T_Proveedor1" runat="server" AutoPostBack="True" 
                                                    CssClass="form-control" style="text-align: right" Width="85px"></asp:TextBox>
                                            </td>
                                            <td width="5%">
                                                <asp:ImageButton ID="Btn_Proveedor1" runat="server" BorderStyle="None" 
                                                    BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="14542" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="T_Proveedor_Desc1" runat="server" 
                                                    CssClass="form-control-Readonly" TabIndex="4552" Width="263px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="T_Proveedor1_RFC" runat="server" CssClass="form-control" 
                                                    style="text-align: right" TabIndex="4552" Width="130px"></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                                            <td width="13%" style="text-align: left">
                                                                <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Moneda            "></asp:Label>
                                                            </td>
                                                            <td width="8%">
                                                                <asp:TextBox ID="T_Moneda1" runat="server" CssClass="form-control" Width="85px" 
                                                                    style="text-align: right" AutoPostBack="True" TabIndex="1" ></asp:TextBox>
                                                            </td>
                                                            <td width="5%" style="text-align: left">
                                                                <asp:ImageButton ID="Btn_Moneda1" runat="server" BorderStyle="None" 
                                                                    BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="4565" />
                                                            </td>
                                                            <td width="200px">
                                                                <asp:TextBox ID="T_Moneda_Desc1" runat="server" CssClass="form-control-Readonly" 
                                                                    Width="180px" TabIndex="4552"></asp:TextBox>
                                                            </td>
                                                            <td width="260px">
                                                                <asp:TextBox ID="T_Tipo_Cambio1" runat="server" CssClass="form-control" 
                                                                    Width="70px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                                            </td>  
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                                            <td style="text-align: left" width="13%">
                                                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Precio Unitario      "></asp:Label>
                                                            </td>
                                                            <td width="140px">
                                                                <asp:TextBox ID="T_Precio1" runat="server" CssClass="form-control" 
                                                                    Width="120px" style="text-align: right" AutoPostBack="True" TabIndex="2" ></asp:TextBox>
                                                            </td>
                                                            <td class="style13" width="460px">
                                                                &nbsp;
                                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;</td>
                                            <td width="13%" style="text-align: left">
                                              
                                                            <asp:Label ID="Label2" runat="server" CssClass="Textos_Azules" Text="Descuento"></asp:Label>
                                                      
                                            </td>
                                            <td class="style7">
                                                <asp:TextBox ID="T_Descuento1" runat="server" AutoPostBack="True" 
                                                    CssClass="form-control" style="text-align: right" TabIndex="3" Width="120px"></asp:TextBox>
                                            </td>
                                            <td class="style13" width="460px">
                                                <asp:CheckBox ID="Ch_Cantidad1" runat="server" CssClass="Textos_Azules" 
                                                    TabIndex="4" Text="Cantidad Asignada" />
                                            </td>
                                            </td>
                                            <td width="150px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                           
                                                            <td style="text-align: left" width="13%">
                                                                <asp:Label ID="Label4" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Precio U. Neto"></asp:Label>
                                                            </td>
                                                            <td width="140px" class="style7">
                                                                <asp:TextBox ID="T_Costo1" runat="server" CssClass="form-control" 
                                                                    Width="120px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                                            </td>
                                                            <td width="460px" class="style13">
                                                                <asp:TextBox ID="T_Cantidad1" runat="server" CssClass="form-control" 
                                                                    Width="120px" style="text-align: right" AutoPostBack="True" TabIndex="5" placeholder="Cantidad Asginada"></asp:TextBox>
                                                            </td>
                                                      
                                            <td width="150px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                         
                                                            <td style="text-align: left" width="13%">
                                                                <asp:Label ID="Label3" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Total         "></asp:Label>
                                                            </td>
                                                            <td width="140px">
                                                                <asp:TextBox ID="T_Total1" runat="server" CssClass="form-control" 
                                                                    Width="120px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                                            </td>
                                                            <td width="460px">
                                                                &nbsp;</td>
                                                     
                                            <td width="150px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                           
                                                            <td style="text-align: left" width="13%">
                                                                <asp:Label ID="Label6" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Fecha Entrega"></asp:Label>
                                                            </td>
                                                            <td class="style9">
                                                                <asp:TextBox ID="T_Fecha1" runat="server" CssClass="form-control-Readonly" 
                                                                    Width="120px" TabIndex="4556"></asp:TextBox>
                                                            </td>
                                                            <td width="20px">
                                                                <rjs:PopCalendar ID="PC_Fecha1" runat="server" Control="T_Fecha1" 
                                                                    Format="yyyy mm dd" Separator="/" />
                                                            </td>
                                                            <td width="50px">
                                                                <asp:Label ID="Label50" runat="server" CssClass="Textos_Azules" Text="Flete"></asp:Label>
                                                            </td>
                                                            <td width="380px">
                                                                <asp:TextBox ID="T_Flete1" runat="server" CssClass="form-control" 
                                                                    Width="100px" style="text-align: right" TabIndex="6" ></asp:TextBox>
                                                            </td>
                                                     
                                            <td width="150px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                            </ContentTemplate>
                                    </asp:UpdatePanel>
                              </div>
                        </div>
                        <%--FINAL PROVEEDOR 1--%>

                        <%--PROVEEDOR 2--%>
                        <div class="tab-pane fade " id="Protab2">
                        <div class="panel-body">
        
                          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div>
                                    <table style="width: 100%; border-bottom-style: solid; border-bottom-color: #3366FF;">
                                        <tr>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                            <td class="style23">
                                                <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" 
                                                    Text="PROVEEDOR 2"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                           <%-- <td width="10%">
                                                &nbsp;
                                            </td>
                                                            <td width="13%">
                                                                <asp:Label ID="Label5" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Proveedor"></asp:Label>
                                                            </td>
                                                            <td width="8%">
                                                                <asp:TextBox ID="T_Proveedor2" runat="server" CssClass="form-control" 
                                                                    Width="85px" style="text-align: right" AutoPostBack="True" TabIndex="7" ></asp:TextBox>
                                                            </td>
                                                            <td width="5%">
                                                                <asp:ImageButton ID="Btn_Proveedor2" runat="server" BorderStyle="None" 
                                                                    BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="1235" />
                                                            </td>
                                                            <td width="200px" style="text-align: left">
                                                                <asp:TextBox ID="T_Proveedor_Desc2" runat="server" CssClass="form-control-Readonly" 
                                                                    Width="286px" TabIndex="4552"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left" width="260px">
                                                                <asp:TextBox ID="T_Proveedor2_RFC" runat="server" 
                                                                    CssClass="form-control-Readonly" TabIndex="4552" Width="130px"></asp:TextBox>
                                                            </td>
                                            <td width="10%">
                                            </td>--%>
                                            <td width="10%">
                                                &nbsp;
                                                </td>
                                            <td style="text-align: left" width="13%">
                                                    <asp:Label ID="Label5" runat="server" CssClass="Textos_Azules" 
                                                        Text="Proveedor"></asp:Label>
                                            </td>
                                            <td width="8%">
                                                <asp:TextBox ID="T_Proveedor2" runat="server" AutoPostBack="True" 
                                                    CssClass="form-control" style="text-align: right" Width="85px"></asp:TextBox>
                                            </td>
                                            <td width="5%">
                                                <asp:ImageButton ID="Btn_Proveedor2" runat="server" BorderStyle="None" 
                                                    BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="14542" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="T_Proveedor_Desc2" runat="server" 
                                                    CssClass="form-control-Readonly" TabIndex="4552" Width="263px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="T_Proveedor2_RFC" runat="server" CssClass="form-control" 
                                                    style="text-align: right" TabIndex="4552" Width="130px"></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td width="13%">
                                                <asp:Label ID="Label16" runat="server" CssClass="Textos_Azules" 
                                                 Text="Moneda            "></asp:Label>
                                            </td>
                                            <td width="8%">
                                                 <asp:TextBox ID="T_Moneda2" runat="server" CssClass="form-control" Width="85px" 
                                                  style="text-align: right" AutoPostBack="True" TabIndex="8" ></asp:TextBox>
                                           </td>
                                           <td width="5%">
                                                 <asp:ImageButton ID="Btn_Moneda2" runat="server" BorderStyle="None" 
                                                     BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="17887" />
                                           </td>
                                           <td width="200px">
                                                 <asp:TextBox ID="T_Moneda_Desc2" runat="server" CssClass="form-control-Readonly" 
                                                     Width="180px" TabIndex="4552"></asp:TextBox>
                                           </td>
                                           <td width="260px">
                                                <asp:TextBox ID="T_Tipo_Cambio2" runat="server" CssClass="form-control" 
                                                     Width="70px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td width="13%">
                                                <asp:Label ID="Label18" runat="server" CssClass="Textos_Azules" 
                                                     Text="Precio Unitario         "></asp:Label>
                                            </td>
                                            <td width="140px">
                                                <asp:TextBox ID="T_Precio2" runat="server" AutoPostBack="True" 
                                                   CssClass="form-control" style="text-align: right" TabIndex="9" Width="120px"></asp:TextBox>
                                            </td>
                                            <td class="style13" width="460px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class="" width="13%">
                                                 <asp:Label ID="Label17" runat="server" CssClass="Textos_Azules" 
                                                    Text="Descuento"></asp:Label>
                                            </td>
                                            <td class="style7"  width="140px">
                                                 <asp:TextBox ID="T_Descuento2" runat="server" AutoPostBack="True" 
                                                      CssClass="form-control" style="text-align: right" TabIndex="10" Width="120px"></asp:TextBox>
                                            </td>
                                            <td width="460px" class="style13">
                                                 <asp:CheckBox ID="Ch_Cantidad2" runat="server" CssClass="Textos_Azules" 
                                                    Text="Cantidad Asignada" TabIndex="11" />
                                            </td>
                                            <td width="150px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class=""  width="13%">
                                                <asp:Label ID="Label19" runat="server" CssClass="Textos_Azules" 
                                                   Text="Precio U. Neto"></asp:Label>
                                            </td>
                                            <td width="140px" class="style7">
                                                 <asp:TextBox ID="T_Costo2" runat="server" CssClass="form-control" 
                                                      Width="120px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                            </td>
                                            <td width="460px" class="style13">
                                                 <asp:TextBox ID="T_Cantidad2" runat="server" CssClass="form-control" 
                                                   Width="120px" style="text-align: right" AutoPostBack="True" TabIndex="12" placeholder="Cantidad Asginada"></asp:TextBox>
                                            </td>
                                            <td width="150px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class=""  width="13%">
                                                <asp:Label ID="Label20" runat="server" CssClass="Textos_Azules" 
                                                 text="Total         "></asp:Label>
                                            </td>
                                           <td width="140px">
                                                 <asp:TextBox ID="T_Total2" runat="server" CssClass="form-control" 
                                                       Width="120px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                            </td>
                                            <td width="460px">
                                                    &nbsp;
                                            </td>
                                            <td width="150px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class=""  width="13%">
                                                <asp:Label ID="Label21" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Fecha Entrega"></asp:Label>
                                            </td>
                                            <td class="style9">
                                                 <asp:TextBox ID="T_Fecha2" runat="server" CssClass="form-control-Readonly" 
                                                    Width="120px" TabIndex="1556"></asp:TextBox>
                                            </td>
                                            <td width="20px">
                                                  <rjs:PopCalendar ID="PC_Fecha2" runat="server" Control="T_Fecha2" 
                                                    Format="yyyy mm dd" Separator="/" />
                                            </td>
                                            <td width="50px">
                                                  <asp:Label ID="Label22" runat="server" CssClass="Textos_Azules" Text="Flete"></asp:Label>
                                            </td>
                                            <td width="380px">
                                                 <asp:TextBox ID="T_Flete2" runat="server" CssClass="form-control" 
                                                    Width="100px" style="text-align: right" TabIndex="13" ></asp:TextBox>
                                            </td>
                                            <td width="150px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--FINAL PROVEEDOR 2--%>

                        <%--PROVEEDOR 3--%>
                        <div class="tab-pane fade" id="Protab3">
                        <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div>
                                    <table style="width: 100%; border-bottom-style: solid; border-bottom-color: #3366FF;">
                                        <tr>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                            <td class="style23">
                                                <asp:Label ID="Label7" runat="server" CssClass="Textos_Azules" 
                                                    Text="PROVEEDOR 3"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>

                                            <td width="10%">
                                                &nbsp;
                                                </td>
                                            <td style="text-align: left" width="13%">
                                                    <asp:Label ID="Label8" runat="server" CssClass="Textos_Azules" 
                                                        Text="Proveedor"></asp:Label>
                                            </td>
                                            <td width="8%">
                                                <asp:TextBox ID="T_Proveedor3" runat="server" AutoPostBack="True" 
                                                    CssClass="form-control" style="text-align: right" Width="85px"></asp:TextBox>
                                            </td>
                                            <td width="5%">
                                                <asp:ImageButton ID="Btn_Proveedor3" runat="server" BorderStyle="None" 
                                                    BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="14542" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="T_Proveedor_Desc3" runat="server" 
                                                    CssClass="form-control-Readonly" TabIndex="4552" Width="263px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="T_Proveedor3_RFC" runat="server" CssClass="form-control" 
                                                    style="text-align: right" TabIndex="4552" Width="130px"></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td width="13%">
                                                <asp:Label ID="Label9" runat="server" CssClass="Textos_Azules" 
                                                 Text="Moneda            "></asp:Label>
                                            </td>
                                            <td width="8%">
                                                 <asp:TextBox ID="T_Moneda3" runat="server" CssClass="form-control" Width="85px" 
                                                  style="text-align: right" AutoPostBack="True" TabIndex="8" ></asp:TextBox>
                                           </td>
                                           <td width="5%">
                                                 <asp:ImageButton ID="Btn_Moneda3" runat="server" BorderStyle="None" 
                                                     BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="17887" />
                                           </td>
                                           <td width="200px">
                                                 <asp:TextBox ID="T_Moneda_Desc3" runat="server" CssClass="form-control-Readonly" 
                                                     Width="180px" TabIndex="4552"></asp:TextBox>
                                           </td>
                                           <td width="260px">
                                                <asp:TextBox ID="T_Tipo_Cambio3" runat="server" CssClass="form-control" 
                                                     Width="70px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                            </td>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td width="13%">
                                                <asp:Label ID="Label11" runat="server" CssClass="Textos_Azules" 
                                                     Text="Precio Unitario         "></asp:Label>
                                            </td>
                                            <td width="140px">
                                                <asp:TextBox ID="T_Precio3" runat="server" AutoPostBack="True" 
                                                   CssClass="form-control" style="text-align: right" TabIndex="9" Width="120px"></asp:TextBox>
                                            </td>
                                            <td class="style13" width="460px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class="" width="13%">
                                                 <asp:Label ID="Label10" runat="server" CssClass="Textos_Azules" 
                                                    Text="Descuento"></asp:Label>
                                            </td>
                                            <td class="style7"  width="140px">
                                                 <asp:TextBox ID="T_Descuento3" runat="server" AutoPostBack="True" 
                                                      CssClass="form-control" style="text-align: right" TabIndex="10" Width="120px"></asp:TextBox>
                                            </td>
                                            <td width="460px" class="style13">
                                                 <asp:CheckBox ID="Ch_Cantidad3" runat="server" CssClass="Textos_Azules" 
                                                    Text="Cantidad Asignada" TabIndex="11" />
                                            </td>
                                            <td width="150px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class=""  width="13%">
                                                <asp:Label ID="Label12" runat="server" CssClass="Textos_Azules" 
                                                   Text="Precio U. Neto"></asp:Label>
                                            </td>
                                            <td width="140px" class="style7">
                                                 <asp:TextBox ID="T_Costo3" runat="server" CssClass="form-control" 
                                                      Width="120px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                            </td>
                                            <td width="460px" class="style13">
                                                 <asp:TextBox ID="T_Cantidad3" runat="server" CssClass="form-control" 
                                                   Width="120px" style="text-align: right" AutoPostBack="True" TabIndex="12" placeholder="Cantidad Asginada"></asp:TextBox>
                                            </td>
                                            <td width="150px">
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                             <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class=""  width="13%">
                                                <asp:Label ID="Label13" runat="server" CssClass="Textos_Azules" 
                                                 text="Total         "></asp:Label>
                                            </td>
                                           <td width="140px">
                                                 <asp:TextBox ID="T_Total3" runat="server" CssClass="form-control" 
                                                       Width="120px" style="text-align: right" TabIndex="4552" ></asp:TextBox>
                                            </td>
                                            <td width="460px">
                                                    &nbsp;
                                            </td>
                                            <td width="150px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                     <table style="width: 100%;">
                                        <tr>
                                            <td width="10%">
                                                &nbsp;
                                            </td>
                                            <td class=""  width="13%">
                                                <asp:Label ID="Label14" runat="server" CssClass="Textos_Azules" 
                                                                    Text="Fecha Entrega"></asp:Label>
                                            </td>
                                            <td class="style9">
                                                 <asp:TextBox ID="T_Fecha3" runat="server" CssClass="form-control-Readonly" 
                                                    Width="120px" TabIndex="1556"></asp:TextBox>
                                            </td>
                                            <td width="20px">
                                                  <rjs:PopCalendar ID="PC_Fecha3" runat="server" Control="T_Fecha3" 
                                                    Format="yyyy mm dd" Separator="/" />
                                            </td>
                                            <td width="50px">
                                                  <asp:Label ID="Label15" runat="server" CssClass="Textos_Azules" Text="Flete"></asp:Label>
                                            </td>
                                            <td width="380px">
                                                 <asp:TextBox ID="T_Flete3" runat="server" CssClass="form-control" 
                                                    Width="100px" style="text-align: right" TabIndex="13" ></asp:TextBox>
                                            </td>
                                            <td width="150px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                            </div>
                        <%--FINAL PORVEEDOR 3--%>
	                </div>
                </div>
                </asp:Panel>
               

                <div >
                        <asp:HiddenField ID="Movimiento" runat="server" />
                </div>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>             <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div class="overlay" />
                        <div class="overlayContent">
                            <img src="Imagenes/cargando.gif" alt="Loading"/>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
            </div>
            <div>
            </div>
        </form>
    </center>
</body>
</html>