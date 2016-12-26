﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Articulos.aspx.vb" Inherits="Catalogo_Articulos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
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
    </script>
    
      <script type="text/javascript" src="jquery.min.js"></script>
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
           </style>
    </head>
<body>
    <center>    
        <form id="form1" runat="server" style="width: 984px">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <asp:UpdatePanel   ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                                <asp:TextBox ID="TB_Clas_Corta" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" placeholder="Clasificación" TabIndex="13" Width="74px"></asp:TextBox>
                            </td>
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
                                    <asp:BoundField DataField="" HeaderText="Clas.">
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
                                    <asp:BoundField DataField="Clas_Corta" HeaderText="">
                                    <ItemStyle HorizontalAlign="Right" Width="38px" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver">
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
                            <td style="text-align: left" width="12%">
                                <asp:Label ID="Label46" runat="server" CssClass="Textos_Azules" Text="IVA"></asp:Label>
                            </td>
                            <td style="text-align: left" width="10%">
                                <asp:TextBox ID="T_IVA" runat="server" CssClass="form-control" Width="62px">16</asp:TextBox>
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
                    <table style="width:100%;">
                        <tr>
                            <td width="11%">
                                &nbsp;</td>
                            <td style="text-align: left" width="120">
                                <asp:CheckBox ID="CH_IEPS" runat="server" Text="Es IEPS" AutoPostBack="True" 
                                    CssClass="Textos_Azules" />
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RB_Opciones" runat="server" 
                                    RepeatDirection="Horizontal" Visible="False">
                                    <asp:ListItem Selected="True" Value="M">Magna</asp:ListItem>
                                    <asp:ListItem Value="P">Premium</asp:ListItem>
                                    <asp:ListItem Value="D">Diesel</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
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
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </asp:Panel>
             <asp:HiddenField ID="Movimiento" runat="server" />

            </div>
        
        </div>
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
