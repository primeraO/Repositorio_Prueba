<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Migracion_Access_SQL.aspx.vb" Inherits="Migracion_Access_SQL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="CodigoJS.js" type="text/javascript"></script>
    <title></title>
    <script type="text/javascript">
        function Obra3(elemValue1, elemValue2) {
            document.getElementById('<%= T_Proyecto.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Proyecto_Desc.ClientID %>').value = elemValue2;
            
        }
        function Almacen(elemValue1, elemValue2) {
            document.getElementById('<%= T_Almacen.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Almacen_Desc.ClientID %>').value = elemValue2;
            
        }
        function Compañia(elemValue1, elemValue2) {
            document.getElementById('<%= T_Compañia.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Compañia_Desc.ClientID %>').value = elemValue2;
            __doPostBack('T_Compañia', 'Text_Changed');
        }
    </script>
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
    <form id="form1" runat="server" style="width:984px;">
    <div>
        <table style="width:100%;">
            <tr>
                <td width="20%"> &nbsp;</td>
                <td width="60%">
                    <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                    <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                        Height="40px" Text="Migración Access - SQL"></asp:Label>
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
                    <asp:Image ID="Image1" runat="server" Height="61px" 
                        ImageUrl="~/Imagenes/logo_Inter_Original.jpg" style="text-align: right" 
                        Width="174px" />
                </td>
           </tr>
        </table>
        
    </div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="Btn_Migrar" />
    </Triggers>
    <ContentTemplate>
        <div>
            <asp:Button ID="Btn_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
               Width="90px" TabIndex="3" />
            &nbsp;<asp:Button ID="Btn_Guarda0" runat="server" CssClass="Btn_Azul" 
                TabIndex="3" Text="Guarda" Width="107px" />
            &nbsp;<asp:Button ID="Btn_Migrar" runat="server" CssClass="Btn_Azul" TabIndex="3" 
                Text="Migrar" Width="90px" Visible="False" />
            &nbsp;<asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" TabIndex="3" 
                Text="Restaura" Width="107px" />
            &nbsp;<asp:Button ID="Btn_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
               Width="80px" />   
            <br />
            <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" 
                BorderStyle="Solid" ForeColor="#FF3300" 
                style="float: none; text-align: center;" Text="Label" Visible="False" 
                Width="96%"></asp:Label>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="280px">
                        <asp:FileUpload ID="FileUploader" runat="server" Visible="False" />
                    </td>
                    <td>
                        <asp:HiddenField ID="Archivo" runat="server" />
                        <asp:HiddenField ID="Movimiento" runat="server" />
                        <asp:HiddenField ID="Base_Numero" runat="server" />
                        <asp:HiddenField ID="Base_Clave" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>



        <%--Aqui empieza el cambio para realizar el imporar como si fuera catalogo--%>
        <div>
            <table style="width: 100%;">
                <tr>
                    <td width="100px">
                        &nbsp;
                    </td>
                    <td width="120px">
                        <asp:Label ID="Label38" runat="server" CssClass="Textos_Azules" 
                            Text="Nombre Archivo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="T_Nombre_Archivo" runat="server" CssClass="form-control" 
                            Width="500px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
               
            </table>
             <table style="width: 100%;">
                 <tr>
                    <td width="100px">
                        &nbsp;</td>
                    <td width="120px">
                        <asp:Label ID="Label45" runat="server" CssClass="Textos_Azules" 
                            Text="Compañia:"></asp:Label>
                    </td>
                    <td width="100px">
                        <asp:TextBox ID="T_Compañia" runat="server" AutoPostBack="True" 
                            CssClass="form-control" Width="100px"></asp:TextBox>
                    </td>
                     <td width="20px">
                         <asp:HyperLink ID="H_Compañia" runat="server" BorderStyle="None" 
                             Enabled="False" ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                     </td>
                     <td>
                         <asp:TextBox ID="T_Compañia_Desc" runat="server" CssClass="form-control" 
                             Enabled="false" Width="335px"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                     <td width="100px">
                         &nbsp;</td>
                     <td width="120px">
                         <asp:Label ID="Label39" runat="server" CssClass="Textos_Azules" 
                             Text="Proyecto:"></asp:Label>
                     </td>
                     <td width="100px">
                         <asp:TextBox ID="T_Proyecto" runat="server" AutoPostBack="True" 
                             CssClass="form-control" Width="100px"></asp:TextBox>
                     </td>
                     <td width="20px">
                         <asp:HyperLink ID="H_Proyecto" runat="server" BorderStyle="None" 
                             Enabled="False" ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                     </td>
                     <td>
                         <asp:TextBox ID="T_Proyecto_Desc" runat="server" CssClass="form-control" 
                             Enabled="false" Width="335px"></asp:TextBox>
                     </td>
                 </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td width="100px">
                        &nbsp;</td>
                    <td width="120px">
                        <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" Text="Almacen:"></asp:Label>
                    </td>
                    <td width="100px">
                        <asp:TextBox ID="T_Almacen" runat="server" AutoPostBack="True" 
                            CssClass="form-control" Width="100px"></asp:TextBox>
                    </td>
                    <td width="20px">
                        <asp:HyperLink ID="H_Almacen" runat="server" BorderStyle="None" Enabled="False" 
                            ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                    </td>
                    <td>
                        <asp:TextBox ID="T_Almacen_Desc" runat="server" CssClass="form-control" 
                            Enabled="false" Width="335px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div>
        <asp:Panel ID="Pnl_Botones_Migrar" runat="server" Visible="False">
            <table style="width: 100%;">
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Importar_Todo" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Importa Todo" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Borrar" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Borrar Registros" Width="98%" />
                    </td>
                </tr>
            </table>
            <table style="width: 100%;">
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Articulos" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Articulos" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Act_Area" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Act - Area" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Act_Fte" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Act - Frente" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Aut_Ordenes" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Autorización Ordenes" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Autoriza_Req" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Autoriza Requisiciones" Width="98%" />
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Auto_Claves" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Autorización Claves" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Comprador" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Comprador" Width="98%" Visible="False" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Cond_Pago" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Cond. Pago" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Config" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Configuración" Width="98%" Visible="false"/>
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Eco" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Económico" Width="98%" />
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Clientes" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Clientes" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Empl" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Empleados" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Eject" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Ejecutivos" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Frente" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Frente" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Gastos_19" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Gastos 19" Width="98%" />
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Linea" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Línea" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Lug_Ent" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Lugar Entrega" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Marca" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Marcas" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Obra" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Migrar Obra" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Ordenes" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Ordenes" Width="98%" />
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Pais" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Paises" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Proveedor" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Proveedores" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Requisicion" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Requisiciones" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Solicitante" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Solicitantes" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Migrar_Sublinea" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Sublínea" Width="98%" />
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Button ID="Btn_Migrar_Transporte" runat="server" CssClass="Btn_Azul" 
                                TabIndex="3" Text="Transporte" Width="98%" />
                        </td>
                        <td width="20%">
                        <asp:Button ID="Btn_Migrar_Tipo_Camb" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Tipo Cambio" Width="98%" />
                        </td>
                        <td width="20%">
                            <asp:Button ID="Btn_Migrar_Cen_Cos" runat="server" CssClass="Btn_Azul" 
                                TabIndex="3" Text="Centro - Costos" Width="98%" />
                        </td>
                        <td width="20%">
                            <asp:Button ID="Btn_Migrar_Compañias" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Compañias" Width="98%" Visible="false"/>
                        </td>
                        <td width="20%">
                            <asp:Button ID="Btn_Migrar_Inventario_Inicial" runat="server" CssClass="Btn_Azul" 
                            TabIndex="3" Text="Inventario Inicial" Width="98%"/>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Button ID="Btn_Responsable" runat="server" CssClass="Btn_Azul" 
                                TabIndex="3" Text="Responsable" Width="98%" />
                        </td>
                        <td width="20%">
                        <asp:Button ID="Btn_Gastos" runat="server" CssClass="Btn_Azul" 
                                TabIndex="3" Text="Gastos" Width="98%" />
                        </td>
                        <td width="20%">
                        <asp:Button ID="Btn_Concepto_Costo" runat="server" CssClass="Btn_Azul" 
                                TabIndex="3" Text="Concepto Costo" Width="98%" />
                        </td>
                        <td width="20%">
                        <asp:Button ID="Btn_Area" runat="server" CssClass="Btn_Azul" 
                                TabIndex="3" Text="Area" Width="98%" />
                        </td>
                    </tr>
                <tr>
                    <td width="20%">
                        <asp:Button ID="Btn_Referencia" runat="server" CssClass="Btn_Azul" TabIndex="3" 
                            Text="Referencia" Width="98%" />
                    </td>
                    <td width="20%">
                        <asp:Button ID="Btn_Terceros" runat="server" CssClass="Btn_Azul" TabIndex="3" 
                            Text="Terceros" Width="98%" />
                    </td>
                    <td width="20%">
                        &nbsp;</td>
                    <td width="20%">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        </div>

        <div>
            <asp:Panel ID="Pnl_Tablas" runat="server">
                <table style="width: 100%; background-color: #507CD1; color: #FFFFFF; font-size: medium; border-spacing: 3px;" 
                    frame="border">
                    <tr>
                        <td width="7%"> &nbsp;</td>
                        <td width="7%">
                            Núm.</td>
                        <td width="25%">Nombre Base</td>
                        <td width="51%"> Ruta</td>
                        <td width="5%"> Cambio</td>
                        <td width="5%"> Baja</td>
                        <td width="20px" bgcolor="White" style="background-color: #FFFFFF">&nbsp;</td>
                    </tr>
                </table>
                <asp:Panel ID="Pnl_Grid" runat="server" ScrollBars="Vertical">
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" CellPadding="1" CellSpacing="3" 
                    DataKeyNames="Numero" Font-Size="Small" ForeColor="#333333" GridLines="None" 
                    Height="16px" style="top: 152px; left: 86px; " Width="100%" ShowHeader="False">
                    <RowStyle BackColor="#EFF3FB" Height="22px" />
                    <Columns>
                        <asp:CommandField HeaderText="Sel." ShowSelectButton="True">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Numero" HeaderText="Núm.">
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Nombre_Base" HeaderText="Nombre Base">
                        <HeaderStyle Width="25%" />
                        <ItemStyle Width="25%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Ruta" HeaderText="Ruta" >
                        <HeaderStyle Width="53%" />
                        <ItemStyle Width="53%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Clave" HeaderText="Clave" Visible="False" />
                        <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                            ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                        <HeaderStyle Width="5%" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:ButtonField>
                        <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                            ImageUrl="~/Imagenes/M_Baja_50.png" Text="Baja">
                        <HeaderStyle Width="5%" Wrap="True" />
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:ButtonField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                </asp:Panel>
            </asp:Panel>
        </div>


    </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                <img src="Imagenes/cargando.gif" alt="Loading"  />
            </div>
        </ProgressTemplate>
   </asp:UpdateProgress>

    </form>
    </center>
</body>
</html>
