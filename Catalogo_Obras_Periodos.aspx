<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Obras_Periodos.aspx.vb" Inherits="Catalogo_Obras" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="jquery.min.js"></script>
   <link href="Ejemplo_Estilos.css " rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="bootstrapjs.min.js"></script>
    <title></title>
        <script language="javascript" type="text/javascript">
            function Pais(elemValue1, elemValue2) {                
                document.getElementById('<%= T_Pais.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Desc_Pais.ClientID %>').value = elemValue2;
            }
        
    </script>
     <script language="javascript" src="CodigoJS.js" type="text/javascript">
         alert("Error al abrir archivo.js");
    </script>
    <style type="text/css">
        .grid_scroll
{
    overflow: auto;
    height: 500px;
     height: 500px; width:100%; float:left;
    /*border: solid 1px orange;*/
    /*height: 480px;overflow: hidden;*/
    width: 800px;
    ShowHeaderWhenEmpty="True"
}
        .style6
        {
            height: 19px;
        }
        </style>
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
             .style8
             {
                 width: 241px;
             }
             .style10
             {
                 width: 308px;
             }
             .style11
             {
                 width: 103px;
             }
             .style7
             {
                 width: 93px;
             }
             .style8
             {
                 width: 94px;
             }
             .style9
             {
                 width: 116px;
             }
         .style2
        {
            width: 96px;
        }
             .style12
             {
                 width: 30%;
             }
         </style>
</head>
<body>
    <center>    
    <form id="form1" runat="server" style="width: 984px">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
     <div>
            <div>
            
                <div>
                    <table style="width:100%;">
                        <tr>
                            <td width="15%">
                                &nbsp;</td>
                            <td width="70%">
                                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Catalogo de Periodos en Obras" Width="100%"></asp:Label>
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
                                <asp:Label ID="Lbl_Compañia" runat="server" Font-Bold="True" 
                                Font-Size="Small" ForeColor="#000087"></asp:Label>
                                </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" class="style6">
                                <asp:Label ID="Lbl_Proyecto" runat="server" Font-Bold="True" 
                                Font-Size="Small" ForeColor="#000087"></asp:Label>
                                </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                                <asp:Label ID="Lbl_Usuario" runat="server" Font-Bold="True" 
                                Font-Size="Small" ForeColor="#000087"></asp:Label>
                        </td>
                    </tr>
                    </table>
                </div>
            
                <table style="width:100%;">
                        <tr>
                            <td width="100">
                                &nbsp;</td>
                            <td width="784">
                                <div>
                                    <table style="width:100%;">
                                        <tr>
                                            <td width="80%">
                                            <center>
                                <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                                    Width="90px" TabIndex="1" Visible="False" />
                                &nbsp;
                                <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                    Width="80px" TabIndex="2" Visible="False" />
                                &nbsp;
                                <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                    Text="Restaura" Width="110px" TabIndex="3" Visible="False" />
                                &nbsp;
                                <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                    Width="100px" TabIndex="4" />
                                            &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
                                                    TabIndex="5" />
                                            </td>
                                            </center>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td width="100">
                                &nbsp;</td>
                        </tr>
                        </table>
            
            </div>

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
            </div>

            <div>
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td width="11%">
                            <asp:DropDownList ID="BList_Empresa" runat="server" AutoPostBack="True" 
                                CssClass="form-control" Width="260px">
                            </asp:DropDownList>
                            </td>
                        <td width="11%" style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left" width="9%">
                     
                     <asp:TextBox ID="TB_Numero" runat="server" Width="55px" TabIndex="6" 
                                placeholder="Núm." CssClass="form-control" MaxLength="4" 
                                style="text-align:right;"></asp:TextBox>
                         </td>
                        <td style="text-align: left" width="4%">
                     
                            &nbsp;</td>
                        <td width="35%" style="text-align: right; ">
                            <asp:TextBox ID="TB_Descripcion" runat="server" CssClass="form-control" 
                                MaxLength="35" placeholder="Descripcion" TabIndex="7" Width="239px"></asp:TextBox>
                        </td>
                        <td style="text-align: left; " width="10%">
                            <asp:CheckBox ID="CB_Activo" runat="server" AutoPostBack="True" Checked="True" 
                                CssClass="Textos_Azules" Text="Activo" />
                        </td>
                        <td style="text-align: left; " width="30%">
                            &nbsp;<asp:CheckBox ID="Ch_Baja" runat="server" AutoPostBack="True" 
                                CssClass="Textos_Azules" TabIndex="2" Text="Bajas" />
                        </td>
                        <td width="11%">
                         </td>
                    </tr>
                </table>
                    <br />
                   <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                            <div style="overflow:hidden; height:35px; width:100%; float:left">
                                <asp:GridView ID="Cabecera" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="1" CellSpacing="4" Font-Size="Small" ForeColor="#333333" 
                                    GridLines="None" Height="35px" ShowHeaderWhenEmpty="True" 
                                    style="top: 152px; left: 86px; " Width="964px">
                                    <RowStyle BackColor="#EFF3FB" Height="22px" />
                                    <Columns>
                                        <asp:BoundField HeaderText="Proyecto">
                                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Descripción">
                                        <HeaderStyle Width="800px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Cambio">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </div>
                            <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="2" CellSpacing="4" DataKeyNames="Obra" Font-Size="Small" 
                                    ForeColor="#333333" GridLines="None" Height="16px" ShowHeader="False" 
                                    style="top: 152px; left: 86px; " Visible="False">
                                    <RowStyle BackColor="#EFF3FB" Height="22px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" Visible="False">
                                        <HeaderStyle Width="100px" />
                                        <ItemStyle Width="100px" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="Obra" HeaderText="Núm.">
                                        <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                        <ItemStyle Width="800px" />
                                        </asp:BoundField>
                                        <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                            ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                                        <HeaderStyle Width="40px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
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
                            <td align="left" width="11%">
                                &nbsp;</td>
                            <td align="left" width="10%">
                                <asp:Label ID="Label49" runat="server" CssClass="Textos_Azules" Text="Empresa"></asp:Label>
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="List_Empresa" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="740px" Enabled="False" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                <%--Empieza registor--%>
                <table style="width:100%;">
                    <tr>
                        <td style="text-align: left" width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="Proyecto" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>
                        <td style="text-align: left" width="68%">
                            <asp:TextBox ID="T_Numero" runat="server" 
                 style="top: 493px; left: 645px; " MaxLength="5" TabIndex="8" 
                                Width="306px" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align: left" width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label24" runat="server" BorderStyle="None" Text="Año" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>
                        <td style="text-align: left" width="68%">
                            <asp:TextBox ID="T_Año" runat="server" MaxLength="70" 
                        style="top: 481px; left: 10px; text-align: left;" 
                        TabIndex="9" CssClass="form-control" Width="24%"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="11%">
                            <br />
                        </td>
                    </tr>
                    </table>
                     <table style="width:100%;">
                                         <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label1" runat="server" CssClass="Textos_Azules" 
                                Text="Mes"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="T_Mes" runat="server" CssClass="form-control" 
                                Width="23%" MaxLength="250" TabIndex="10"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                     </table>
                <table style="width:100%;">
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" class="style7">
                            <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" 
                                Text="Colonia" Visible="False"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="T_Colonia" runat="server" CssClass="form-control" 
                                MaxLength="50" TabIndex="11" Width="80%" Visible="False"></asp:TextBox>
                        </td>
                        <td class="style9" style="text-align: left">
                            <asp:Label ID="Label28" runat="server" CssClass="Textos_Azules" Text="Ciudad" 
                                Visible="False"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="T_Ciudad" runat="server" CssClass="form-control" 
                                MaxLength="30" TabIndex="12" Width="80%" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: left" class="style7">
                            <asp:Label ID="Label29" runat="server" CssClass="Textos_Azules" Text="Estado" 
                                Visible="False"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="T_Estado" runat="server" CssClass="form-control" 
                                MaxLength="50" TabIndex="13" Width="80%" Visible="False"></asp:TextBox>
                        </td>
                        <td style="text-align: left" class="style9">
                            <asp:Label ID="Label30" runat="server" CssClass="Textos_Azules" 
                                Text="Delegación" Visible="False"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="T_Delegacion" runat="server" CssClass="form-control" 
                                MaxLength="30" TabIndex="14" Width="80%" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width:100%; margin-bottom: 1px;">
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label32" runat="server" CssClass="Textos_Azules" Text="País" 
                                Visible="False"></asp:Label>
                        </td>
                        <td width="7%">
                            <asp:TextBox ID="T_Pais" runat="server" CssClass="form-control" 
                                Width="32px" MaxLength="3" TabIndex="16" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="H_Pais" runat="server" ImageUrl="~/Imagenes/M_Buscar_50.png" 
                                Visible="False">HyperLink</asp:HyperLink>
                        </td>
                        <td style="text-align: left" class="style8">
                            <asp:TextBox ID="T_Desc_Pais" runat="server" CssClass="form-control" 
                                style="text-align: left" Width="205px" Enabled="False" Visible="False"></asp:TextBox>
                        </td>
                        <td class="style11" style="text-align: left">
                            <asp:Label ID="Label31" runat="server" CssClass="Textos_Azules" Text="C.P." 
                                Visible="False"></asp:Label>
                        </td>
                        <td class="style10" style="text-align: left">
                            <asp:TextBox ID="T_CP" runat="server" CssClass="form-control" MaxLength="6" 
                                TabIndex="15" Width="75%" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label33" runat="server" CssClass="Textos_Azules" Text="Teléfono" 
                                Visible="False"></asp:Label>
                        </td>
                        <td width="28%">
                            <asp:TextBox ID="T_Telefono" runat="server" CssClass="form-control" Width="80%" 
                                MaxLength="18" TabIndex="17" Visible="False"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="12%">
                            <asp:Label ID="Label34" runat="server" CssClass="Textos_Azules" Text="Fax" 
                                Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Fax" runat="server" CssClass="form-control" 
                                Width="80%" MaxLength="18" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label35" runat="server" CssClass="Textos_Azules" 
                                Text="Abreviatura" Visible="False"></asp:Label>
                        </td>
                        <td width="28%">
                            <asp:TextBox ID="T_Abreviatura" runat="server" CssClass="form-control" 
                                Width="54%" TabIndex="19" MaxLength="20" Visible="False"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="4%">
                            <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" 
                                Text="Prefijo Envío" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Prefijo_Envio" runat="server" CssClass="form-control" 
                                Width="80%" MaxLength="18" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label46" runat="server" CssClass="Textos_Azules" 
                                Text="Folio Envío" Visible="False"></asp:Label>
                        </td>
                        <td width="28%">
                            <asp:TextBox ID="T_Folio_Envio" runat="server" CssClass="form-control" 
                                Width="80%" MaxLength="18" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="4%">
                            <asp:Label ID="Label45" runat="server" CssClass="Textos_Azules" 
                                Text="Orden Trabajo" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Orden_Trabajo" runat="server" CssClass="form-control" 
                                Width="80%" MaxLength="18" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="10%">
                            <asp:Label ID="Label47" runat="server" CssClass="Textos_Azules" 
                                Text="Num. Requisición" Visible="False"></asp:Label>
                        </td>
                        <td width="28%">
                            <asp:TextBox ID="T_Num_Req" runat="server" CssClass="form-control" 
                                MaxLength="18" TabIndex="18" Width="80%" Visible="False"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="4%">
                            <asp:Label ID="Label48" runat="server" CssClass="Textos_Azules" 
                                Text="Num. Orden" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Num_Ord" runat="server" CssClass="form-control" 
                                MaxLength="18" TabIndex="18" Width="80%" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    </table>
                <table style="width:100%;">
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td height="40" width="16%" style="text-align: left">
                            <asp:Label ID="Label41" runat="server" CssClass="Textos_Azules" Text="Activa" 
                                Visible="False"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <asp:RadioButtonList ID="RB_Activa" runat="server" CssClass="Textos_Azules" 
                                RepeatDirection="Horizontal" RepeatLayout="Flow" style="text-align: left" 
                                Width="81px" Visible="False">
                                <asp:ListItem Selected="True" Value="S">SI</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td height="40" width="16%">
                            &nbsp;</td>
                        <td style="text-align: center">
                            <asp:Label ID="Label42" runat="server" CssClass="Textos_Azules" Text="Nombre" 
                                Visible="False"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="Label43" runat="server" CssClass="Textos_Azules" Text="Mail" 
                                Visible="False"></asp:Label>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left" width="16%">
                            <asp:Label ID="Label36" runat="server" CssClass="Textos_Azules" 
                                Text="Sup. de Maquinaria" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Sup_Maq" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Mail_Sup_Maq" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Label ID="Label39" runat="server" CssClass="Textos_Azules" 
                                Text="Sup. de Construcción" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Sup_Con" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Mail_Sup_Con" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Label ID="Label37" runat="server" CssClass="Textos_Azules" 
                                Text="Dir. de Maquinaria" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Dir_Maq" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Mail_Dir_Maq" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="11%">
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Label ID="Label40" runat="server" CssClass="Textos_Azules" 
                                Text="Dir. de Construcción" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Dir_Con" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Mail_Dir_Con" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td width="11%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: left">
                            <asp:Label ID="Label38" runat="server" CssClass="Textos_Azules" 
                                Text="Ger. de Construcción" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Ger_Con" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="Mail_Ger_Con" runat="server" CssClass="form-control" 
                                Width="284px" MaxLength="40" TabIndex="18" Visible="False"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td style="text-align: left">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>

                </asp:Panel>
                

                <%--terminaregistro--%>
                <br />
            </div>
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="42%">
                            &nbsp;</td>
                        <td width="16%">
                            <br />
             <asp:HiddenField ID="Movimiento" runat="server" />
                        </td>
                        <td width="42%">
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                
                <img src="Imagenes/cargando.gif" alt="Loading" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
       </form>
    </center>
    </body>
    </html>