<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Articulos.aspx.vb" Inherits="Catalogo_Articulos" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Ejemplo_Estilos1.css" rel="stylesheet" type="text/css" />
    <link href="Ejemplo_Estilos1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jquery.min.js"></script>
     <script language="javascript" src="bootstrapjs.min.js" type="text/javascript"></script>
 
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
       </script>
       <script type="text/javascript">
          
               function showimagepreview(input) {

                   if (input.files && input.files[0]) {
                       var reader = new FileReader();
                       reader.onload = function (e) {

                           document.getElementById("list").innerHTML = ['<img class="thumb" Width="500px" Height="500px" src="', e.target.result, '" />'].join('');
                       }
                       reader.readAsDataURL(input.files[0]);
                   }
               }

               function showimagepreview2(input) {

                   if (input.files && input.files[0]) {
                       var reader = new FileReader();
                       reader.onload = function (e) {

                           document.getElementById("list2").innerHTML = ['<img class="thumb" Width="500px" Height="500px" src="', e.target.result, '" />'].join('');
                       }
                       reader.readAsDataURL(input.files[0]);
                   }
               }  
        
               </script>
     <script type="text/javascript">
         function Linea(elemValue1, elemValue2) {
             document.getElementById('<%= T_Linea.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Desc_Linea.ClientID %>').value = elemValue2;
             __doPostBack("T_Linea", "TextChanged");
         }
         function Marca(elemValue1, elemValue2) {
             document.getElementById('<%= T_Marca.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Desc_Marca.ClientID %>').value = elemValue2;
             __doPostBack("T_Marca", "TextChanged");
         }
         function Sub_Linea(elemValue1, elemValue2) {
             document.getElementById('<%= T_SubLinea.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Desc_SubLinea.ClientID %>').value = elemValue2;
             __doPostBack("T_SubLinea", "TextChanged");
         }
         function Articulo(elemValue1, elemValue2) {
             document.getElementById('<%= T_Referencia_Sustituta.ClientID %>').value = elemValue1;
             document.getElementById('<%= T_Referencia_Sustituta_Desc.ClientID %>').value = elemValue2;
             __doPostBack("T_Referencia_Sustituta", "TextChanged");
         }
         function Lineas(elemValue1, elemValue2) {
             document.getElementById('<%= TB_Grupo.ClientID %>').value = elemValue1;
             __doPostBack("TB_Grupo", "TextChanged");
         }
         function Sub_Linea2(elemValue1, elemValue2) {
             document.getElementById('<%= TB_SubGrupo.ClientID %>').value = elemValue1;
             __doPostBack("TB_SubGrupo", "TextChanged");
         }
         function Monedas(elemValue1, elemValue2, Num_Prov) {
             if (Num_Prov == "1") {
                 document.getElementById('<%= T_Moneda1.ClientID %>').value = elemValue1;
                 document.getElementById('<%= T_Moneda_Desc1.ClientID %>').value = elemValue2;
                 __doPostBack("T_Moneda1", "TextChanged");
             }

         }
          
    </script>
      
    <link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>
    
    <style type="text/css">
        .form-control
        {
            margin-top: 0px;
        }
        .Textos_Azules
        {
            text-align: left;
        }
        .style2
        {
            width: 17%;
        }
  
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
           .style15
        {
            width: 250px;
        }
       
          .thumb {
            height: 300px;
            border: 1px solid #000;
            margin: 10px 5px 0 0;
          }
       
           #TextArea1
        {
            width: 854px;
        }
       
           #T_Ficha_Tecnica
        {
            width: 856px;
        }
       
           </style>
    </head>
<body>
    <center>    
        <form id="form1" runat="server" style="width: 984px">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        
            <div>
            <div>

                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">

                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Catálogo Artículos" Width="95%"></asp:Label>
                                <br />
                                </asp:Panel>

                        </td>
                        <td style="text-align: right" width="15%">
                            <asp:Image ID="Image1" runat="server" Height="61px" 
                                ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                                Width="174px" />
                            <br />
                        </td>
                    </tr>
                </table>

                <table style="width:100%;">
                    <tr>
                        <td class="style6" style="text-align: center">
                            <asp:Label ID="Lbl_Compañia" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" style="text-align: center">
                            <asp:Label ID="Lbl_Obra" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="Lbl_Usuario" runat="server" Font-Bold="True" Font-Size="Small" 
                                ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                </table>

               
                                    <table style="width:100%;">
                                        <tr>
                                            <td width="10%">
                                           
                                                &nbsp;</td>
                                            
                                            <td width="80%" style="text-align: center">
                                           
                                <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" Height="45px" />
                                &nbsp;
                                <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                    Width="80px" Height="45px" />
                                &nbsp;
                                <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                    Text="Restaura" Width="110px" Height="45px" />
                                &nbsp;
                                <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                    Width="100px" Height="45px" />
                                            &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
                                                    Height="45px" />
                                            </td>
                                            
                                            <td width="10%">
                                           
                                                &nbsp;</td>
                                            
                                        </tr>
                                    </table>
                                
            
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
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                    <table style="width:100%;">
                        <tr>
                            <td width="11%" height="40px">
                                <asp:TextBox ID="TB_Numero" runat="server" CssClass="form-control" 
                                    placeholder="Num." TabIndex="13" Width="120px"></asp:TextBox>
                            </td>
                            <td width="10%">
                                <asp:TextBox ID="TB_Descripcion" runat="server" CssClass="form-control" 
                                    placeholder="Descripción" TabIndex="14" Width="247px"></asp:TextBox>
                            </td>
                            <td style="text-align: right" width="5%">
                                <asp:TextBox ID="TB_Grupo" runat="server" 
                                    CssClass="form-control" placeholder="Grupo" TabIndex="13" Width="63px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:HyperLink ID="HB_Linea" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td width="70px">
                                <asp:TextBox ID="TB_SubGrupo" runat="server" 
                                    CssClass="form-control" placeholder="Subgrupo" TabIndex="13" Width="63px"></asp:TextBox>
                            </td>
                            <td width="50px" style="text-align: left">
                                <asp:HyperLink ID="HB_SubLinea" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td width="9%">
                                &nbsp;</td>
                            <td width="350" style="text-align: left">
                                <asp:CheckBox ID="Ch_Baja" runat="server" AutoPostBack="True" 
                                    CssClass="Textos_Azules" Text="Bajas" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                        <div style="overflow:hidden; height:35px; width:100%; float:left">
                        </div>
                        <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
                            <asp:GridView ID="Cabecera" runat="server" AutoGenerateColumns="False" 
                                CellPadding="1" CellSpacing="4" Font-Size="Small" ForeColor="#333333" 
                                GridLines="None" Height="35px" ShowHeaderWhenEmpty="True" 
                                style="top: 152px; left: 86px; " Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:BoundField HeaderText="Número">
                                    <HeaderStyle HorizontalAlign="Left" Width="119px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Descripción">
                                    <HeaderStyle Width="647px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Unidad Medida">
                                    <HeaderStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="IVA">
                                    <HeaderStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lin_Numero" HeaderText="Grupo">
                                    <HeaderStyle Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sub_Numero" HeaderText="Subgrupo">
                                    <HeaderStyle Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Ver">
                                    <HeaderStyle Width="49px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cambio">
                                    <HeaderStyle HorizontalAlign="Center" Width="54px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Baja">
                                    <HeaderStyle HorizontalAlign="Center" Width="49px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CellPadding="1" CellSpacing="4" DataKeyNames="Numero" Font-Size="Small" 
                                ForeColor="#333333" GridLines="None" Height="16px" ShowHeader="False" 
                                style="top: 152px; left: 86px; " Width="964px">
                                <RowStyle BackColor="#EFF3FB" Height="22px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" Visible="False">
                                    <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Numero" HeaderText="Num.">
                                    <ItemStyle HorizontalAlign="Left" Width="92px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Art_Descripcion" HeaderText="Descripcion">
                                    <ItemStyle HorizontalAlign="Left" Width="450px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unidad_Medida" HeaderText="Unidad de Medida">
                                    <ItemStyle HorizontalAlign="Left" Width="66px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IVA" HeaderText="IVA">
                                    <ItemStyle HorizontalAlign="Right" Width="39px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lin_Numero" HeaderText="Grupo">
                                    <ItemStyle HorizontalAlign="Right" Width="39px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sub_Numero" HeaderText="Subgrupo">
                                    <ItemStyle HorizontalAlign="Right" Width="53px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver" >
                                    <ItemStyle HorizontalAlign="Center" Width="42px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                                        ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
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
                <br />
                <asp:Panel ID="Pnl_Registro" CssClass="Paneles" runat="server">
                   
                    <br />
                 
                
                    <div>
                        <table style="width: 100%;">
                            <tr>
                                <td width="150px">
                                    &nbsp;</td>
                                <td width="464px">
                                    &nbsp;</td>
                                <td width="150px">
                                    &nbsp;</td>
                                <td width="220px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div style="height: 15px">
                    </div>
                <div class="">
	                <ul class="nav nav-tabs" id="">
		                <li class="active"><a href="#Protab1" data-toggle="tab">Articulos</a></li>
		                <li><a href="#Protab2" data-toggle="tab">Ventas</a></li>
		                <li><a href="#Protab3" data-toggle="tab">F. Tecnica</a></li>
		                <li><a href="#Protab4" data-toggle="tab">Foto</a></li>
                    </ul>

	                <div class="tab-content">
                        <%--PROVEEDOR 1--%>
		                <div class="tab-pane fade in active" id="Protab1">
                        <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePane2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                            <table style="width: 100%; border-bottom-style: solid; border-bottom-color: #3366FF;">
                                        <tr>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                            <td class="style23">
                                                <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" 
                                                    Text="Articulo"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                <table style="width:100%;">
                        <tr>
                            <td width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" width="12%">
                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" 
                                Text="Num. Articulo:"></asp:Label>
                            </td>
                            <td class="style2" style="text-align: left">
                                <asp:TextBox ID="T_Numero" runat="server" CssClass="form-control" 
                                Width="94%" MaxLength="20"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="10%">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" width="12%">
                                <asp:Label ID="Label42" runat="server" CssClass="Textos_Azules" 
                                    Text="Descripcion"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Descripcion" runat="server" CssClass="form-control" 
                                    MaxLength="250" Width="81%"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" width="12%">
                                <asp:Label ID="Label43" runat="server" CssClass="Textos_Azules" Text="Marca" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="text-align: left" width="10%">
                                <asp:TextBox ID="T_Marca" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="62px" Visible="False"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="6%">
                                <asp:HyperLink ID="H_Marca" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" Visible="False">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_Marca" runat="server" CssClass="form-control" 
                                    Enabled="False" TabIndex="14" Width="91%" Visible="False" 
                                    BackColor="SkyBlue"></asp:TextBox>
                            </td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" Text="Grupo"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Linea" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="62px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:HyperLink ID="H_Linea" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_Linea" runat="server" CssClass="form-control" 
                                    Enabled="False" TabIndex="14" Width="91%" BackColor="SkyBlue"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label45" runat="server" CssClass="Textos_Azules" 
                                    Text="Subgrupo"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_SubLinea" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="62px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:HyperLink ID="H_SubLinea" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Desc_SubLinea" runat="server" CssClass="form-control" 
                                    Enabled="False" TabIndex="14" Width="91%" BackColor="SkyBlue"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label49" runat="server" CssClass="Textos_Azules" 
                                    Text="Ref. Sustituta"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Referencia_Sustituta" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="96px"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:HyperLink ID="H_Articulo" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Referencia_Sustituta_Desc" runat="server" 
                                    CssClass="form-control" Enabled="False" TabIndex="14" Width="91%" 
                                    BackColor="SkyBlue"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                            </td>
                            <td style="text-align: left" width="11%">
                                <asp:Label ID="Label47" runat="server" CssClass="Textos_Azules" 
                                    Text="U. de Medida"></asp:Label>
                            </td>
                            <td style="text-align: left" width="16%">
                                <asp:TextBox ID="T_UMedida" runat="server" CssClass="form-control" 
                                    MaxLength="5" Width="87px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="122px">
                                <asp:Label ID="Label48" runat="server" CssClass="Textos_Azules" 
                                    Text="Codigo de Barras" Visible="False"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Codigo" runat="server" CssClass="form-control" 
                                    MaxLength="10" Visible="False"></asp:TextBox>
                            </td>
                            <td width="11%">
                            </td>
                        </tr>
                    </table>
                               
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
                                                <asp:Label ID="Label8" runat="server" CssClass="Textos_Azules" 
                                                    Text="Ventas"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                   <td width="10%">
                                              <table style="width:100%;">
                                                    <tr>
                                                        <td width="90px">
                                                            &nbsp;</td>
                                                        <td width="110px">
                                                            <asp:Label ID="Label50" runat="server" CssClass="Textos_Azules" Text="1"></asp:Label>
                                                        </td>
                                                        <td width="20">
                                                            &nbsp;</td>
                                                        <td width="110">
                                                            <asp:Label ID="Label51" runat="server" CssClass="Textos_Azules" Text="2"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td width="110">
                                                            <asp:Label ID="Label52" runat="server" CssClass="Textos_Azules" Text="3"></asp:Label>
                                                        </td>
                                                        <td style="text-align: left" width="130">
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="Label53" runat="server" CssClass="Textos_Azules" Text="4"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label58" runat="server" CssClass="Textos_Azules" Text="Contado"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Contado" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label59" runat="server" CssClass="Textos_Azules" Text="Credito"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Credito" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label60" runat="server" CssClass="Textos_Azules" Text="Mayoreo"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Mayoreo" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label61" runat="server" CssClass="Textos_Azules" Text="Filial"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Filial" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label54" runat="server" CssClass="Textos_Azules" Text="CO/IVA"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Contado_IVA" runat="server" BackColor="SkyBlue" 
                                                                CssClass="form-control" Enabled="False" placeholder="" TabIndex="13" 
                                                                Width="63px">0.00</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label55" runat="server" CssClass="Textos_Azules" Text="CR/IVA"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Credito_Iva" runat="server" BackColor="SkyBlue" 
                                                                CssClass="form-control" Enabled="False" placeholder="" TabIndex="13" 
                                                                Width="63px">0.00</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label56" runat="server" CssClass="Textos_Azules" Text="MA/IVA"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Mayoreo_IVA" runat="server" BackColor="SkyBlue" 
                                                                CssClass="form-control" Enabled="False" placeholder="" TabIndex="13" 
                                                                Width="63px">0.00</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label57" runat="server" CssClass="Textos_Azules" Text="FI/IVA"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Filial_IVA" runat="server" BackColor="SkyBlue" 
                                                                CssClass="form-control" Enabled="False" placeholder="" TabIndex="13" 
                                                                Width="63px">0.00</asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="90px">
                                                            <asp:Label ID="Label62" runat="server" CssClass="Textos_Azules" 
                                                                Text="Descuento 1"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Descuento_1" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label63" runat="server" CssClass="Textos_Azules" Text="2"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Descuento_2" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label64" runat="server" CssClass="Textos_Azules" Text="IVA"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_IVA" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px" AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label65" runat="server" CssClass="Textos_Azules" 
                                                                Text="Precio Contado"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_precio_Contado" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td style="text-align: left" width="90px">
                                                            <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" 
                                                                Text="Moneda            "></asp:Label>
                                                        </td>
                                                        <td width="130">
                                                            <asp:TextBox ID="T_Moneda1" runat="server" AutoPostBack="True" 
                                                                CssClass="form-control" style="text-align: right" TabIndex="1" Width="85px">0</asp:TextBox>
                                                        </td>
                                                        <td style="text-align: left" width="40">
                                                            <asp:ImageButton ID="Btn_Moneda1" runat="server" BorderStyle="None" 
                                                                BorderWidth="1px" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="4565" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Moneda_Desc1" runat="server" 
                                                                CssClass="form-control-Readonly" TabIndex="4552" Width="180px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table style="width: 100%; margin-top: 0px;">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label66" runat="server" CssClass="Textos_Azules" 
                                                                Text="Lote Minimo"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Lote_Minimo" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label67" runat="server" CssClass="Textos_Azules" 
                                                                Text="Multiplos"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="T_Multiplos" runat="server" CssClass="form-control" 
                                                                placeholder="" TabIndex="13" Width="63px"></asp:TextBox>
                                                        </td>                                             
                                                       
                                                       
                                                    </tr>
                                                 
                                                </table>
                                                </td>
                                </div>
                                  </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--FINAL PROVEEDOR 2--%>
                         <%--FICHA TECNICA--%>
                        <div class="tab-pane fade " id="Protab3">
                        <div class="panel-body">
        <%--
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <div>
                                    <table style="width: 100%; border-bottom-style: solid; border-bottom-color: #3366FF;">
                                        <tr>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label2" runat="server" CssClass="Textos_Azules" 
                                                    Text="Ficha Tecnica"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                   <td width="10%">
                                              <br />
                                                </td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="text-align: left">
                                                
                                                <asp:Label ID="Label68" runat="server" AssociatedControlId="Ficha_Tecnica" 
                                                    CssClass="Textos_Azules" Text="Seleccionar una imagen:" />
                                                <br />
                                            </td>
                                            <td class="style15" style="text-align: left">
                                                                            
                                                <input type="file" id="Ficha_Tecnica" runat="server"  onchange="showimagepreview(this)" /> 
                                               </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="Nombre_Ficha" runat="server" />
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="5%">
                                                &nbsp;</td>
                                            <td style="text-align: left" height="40" width="20%">
                                                &nbsp;</td>
                                            <td style="text-align: left">
                                                &nbsp;</td>
                                            <td width="5%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <div ID="list" runat="server">
                                                  
                                                    <%--   <asp:Image ID='Image2' ImageUrl='Handler.ashx?img=C:/Fichas_Tecnicas/el sueño.jpg' runat='server'/>--%>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                   
                                    <asp:Label ID="Nom_ficha" runat="server" CssClass="Textos_Azules"></asp:Label>
                                   
                                    <br />
                                    
                                </div>
                                 <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                        <%--FINAL FICHA TECNICA--%>
                        <%--inicio foto--%>
                         <div class="tab-pane fade " id="Protab4">
                        <div class="panel-body">
                            <%--
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <div>
                                    <table style="width: 100%; border-bottom-style: solid; border-bottom-color: #3366FF;">
                                        <tr>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                            <td width="150px">
                                                <asp:Label ID="Label3" runat="server" CssClass="Textos_Azules" 
                                                    Text="Foto"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td width="432px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                   <td width="10%">
                                              <br />
                                             </td>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="text-align: left">
                                                
                                                <asp:Label ID="Label4" runat="server" AssociatedControlId="file_fotos" 
                                                    CssClass="Textos_Azules" Text="Seleccionar una imagen:" />
                                                <br />
                                            </td>
                                            <td class="style15" style="text-align: left">
                                            <input type="file" ID="file_fotos" runat="server"  onchange="showimagepreview2(this)" /> 
                                                </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="Nombre_Foto" runat="server" />
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="5%">
                                                &nbsp;</td>
                                            <td style="text-align: left" height="40" width="20%">
                                                &nbsp;</td>
                                            <td style="text-align: left">
                                                &nbsp;</td>
                                            <td width="5%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <div ID="list2" runat="server">
                                                    
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                   
                                    <asp:Label ID="Nom_Foto" runat="server" CssClass="Textos_Azules"></asp:Label>
                                   
                                    <br />
                                    
                                </div>
                            <%-- </ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </div>
                        </div>
                      <%--  final foto--%>
                    <br />
                </asp:Panel>
             <asp:HiddenField ID="Movimiento" runat="server" />

            </div>
        
        </div>


       
           <%--FINAL FICHA TECNICA--%>
                    <br />
                </asp:Panel>
             <asp:HiddenField ID="HiddenField2" runat="server" />

            </div>
        
        </div>
          
         <%--  <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                
                <img src="Imagenes/cargando.gif" alt="Loading"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
   
        </form>
    </center>
   
</body>
</html>
 