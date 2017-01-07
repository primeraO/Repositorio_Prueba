<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Bus_Cat.aspx.vb" Inherits="Bus_Cat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript" src="jquery.min.js"></script>
    <%--<script type="text/javascript" src="Encripta.js"></script>--%>
 <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
  
    <title></title>
    <%--<script type = "text/javascript">
    function OnClose() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.HideModalDiv();
                }
         }
    window.onunload = OnClose;
</script> --%>
        <script type="text/javascript">
            function Responsable(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Responsable(value1, value2);
                window.close();
            }
            function Sel_Articulo(value1, value2, value3, value4,value5) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                var retvalue3 = value3;
                var retvalue4 = value4;
                var retvalue5 = value5;
                window.opener.Articulo(value1, value2, value3, value4, value5);
                window.close();
            }
            function Linea(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Linea(value1, value2);
                window.close();
            }
            function Frente_Actividad(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Frente_Actividad(value1, value2);
                window.close();
            }
            function Area_Actividad(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Area_Actividad(value1, value2);
                window.close();
            }
            function Economico_Actividad(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Economico_Actividad(value1, value2);
                window.close();
            }
            function Cond_Pago(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Cond_Pago(value1, value2);
                window.close();
            }
            function Sel_Moneda(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Moneda(value1, value2);
                window.close();
            }
            function Area(value1, value2) {
                var retvalue1 = value1;
                window.opener.Area(value1, value2);
                window.close();
            }
            function Area2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Area2(value1, value2);
                window.close();
            }
            function Frente(value1, value2) {
                var retvalue1 = value1;
                window.opener.Frente(value1, value2);
                window.close();
            }
            function Frente2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Frente2(value1, value2);
                window.close();
            }
            function Tercero(value1, value2) {
                var retvalue1 = value1;
                window.opener.Tercero(value1, value2);
                window.close();
            }
            function Tercero2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Tercero2(value1, value2);
                window.close();
            }
            function Solicitante(value1, value2) {
                var retvalue1 = value1;
                window.opener.Solicitante(value1, value2);
                window.close();
            }
            function Solicitante1(value1, value2) {
                var retvalue1 = value1;
                window.opener.Solicitante1(value1, value2);
                window.close();
            }

//            function Articulo(value1, value2, value3) {
//                var retvalue1 = value1;
//                window.opener.Articulo(value1, value2, value3);
//                window.close();
//            }
            function Economico(value1, value2) {
                var retvalue1 = value1;
                window.opener.Economico(value1, value2);
                window.close();
            }
            function Economico2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Economico2(value1, value2);
                window.close();
            }
            function TipoSalida(value1, value2,value3) {
                var retvalue1 = value1;
                window.opener.TipoSalida(value1, value2,value3);
                window.close();
            }
            function Req_Costos(value1) {
                var retvalue1 = value1;
                window.opener.Req_Costos(value1);
                window.close();
            }
            function Req_Economico(value1) {
                var retvalue1 = value1;
                window.opener.Req_Economico(value1);
                window.close();
            }
            function cliente(value1,value2) {
                var retvalue1 = value1;
                window.opener.cliente(value1,value2);
                window.close();
            }
            function articulo(value1, value2) {
                var retvalue1 = value1;
                window.opener.articulo(value1, value2);
                window.close();
            }
            function Salida_elemento(value1, value2, Funcion) {
                var retvalue1 = value1;
//                window.opener.Salida_elemento(value1, value2);
                switch (Funcion) {
                    case "Actividad":
                        window.opener.Salida_Actividad(value1, value2);
                        break;
                    case "Elemento":
                        window.opener.Salida_elemento(value1, value2);
                        break;
                    case "Clasificacion":
                        window.opener.Salida_Clasificacion(value1, value2);
                        break;
                    case "Referencia":
                        window.opener.Salida_Referencia(value1, value2);
                        break;
                    default:
                }
                window.close();
            }
            function Salida_elementos(value1, value2, Funcion,Numero) {
                var retvalue1 = value1;
                //                window.opener.Salida_elemento(value1, value2);
                switch (Funcion) {
                    case "Actividad":
                        window.opener.Salida_Actividad(value1, value2);
                        break;
                    case "Elemento":
                        window.opener.Salida_elemento(value1, value2,Numero);
                   break;
//                    case "Clasificacion":
//                        window.opener.Salida_Clasificacion(value1, value2);
//                        break;
//                    case "Referencia":
//                        window.opener.Salida_Referencia(value1, value2);
//                        break;
                    default:
                }
                window.close();
            }
            function Proveedor(value1, value2) {
                var retvalue1 = value1;
                window.opener.Proveedor(value1, value2);
                window.close();
            }
            function Proveedor2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Proveedor2(value1, value2);
                window.close();
            }
            function Clave_Movimientos_Inventario(value1, value2) {
                var retvalue1 = value1;
                window.opener.Clave_Movimientos_Inventario(value1, value2);
                window.close();
            }
            function Clave_Movimientos_Inventario2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Clave_Movimientos_Inventario2(value1, value2);
                window.close();
            }
            function Clave_Movimientos_Inventario_Entradas(value1, value2) {
                var retvalue1 = value1;
                window.opener.Clave_Movimientos_Inventario(value1, value2);
                window.close();
            }

            function Almacen(value1, value2) {
                window.opener.Almacen(value1, value2);
                window.close();
            }
            function Almacen2(value1, value2) {
                window.opener.Almacen2(value1, value2);
                window.close();
            }
            function Moneda(value1, value2) {
                window.opener.Moneda(value1, value2);
                window.close();
            }
            function Centro_Costos(value1, value2) {
                window.opener.Centro_Costos(value1, value2);
                window.close();
            }
            function Almacen_Destino(value1, value2) {
                window.opener.Almacen_Destino(value1, value2);
                window.close();
            }
            function Empleados(value1, value2) {
                window.opener.Empleados(value1, value2);
                window.close();
            }
            function Linea(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Linea(value1, value2);
                window.close();
            }
            function Marca(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Marca(value1, value2);
                window.close();
            }
            function Marca1(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Marca1(value1, value2);
                window.close();
            }
            function Sub_Linea(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Sub_Linea(value1, value2);
                window.close();
            }
            function Sub_Linea2(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Sub_Linea2(value1, value2);
                window.close();
            }
            function Comprador(value1, value2) {
                var retvalue1 = value1;
                window.opener.Comprador(value1, value2);
                window.close();
            }
            function Transporte(value1, value2) {
                var retvalue1 = value1;
                window.opener.Transporte(value1, value2);
                window.close();
            }
            function Cond_Pago(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Cond_Pago(value1, value2);
                window.close();
            }
            function Pais(value1, value2) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Pais(value1, value2);
                window.close();
            }
            function Resguardo(value1, value2, value3, value4) {
                window.opener.Resguardo(value1, value2, value3, value4);
                window.close();
            }
            function Lugar_Entrega(value1, value2) {
                window.opener.Lugar_Entrega(value1, value2);
                window.close();
            }
            function OpcionesFiltro(value1, value2) {
                window.opener.OpcionesFiltro(value1, value2);
                window.close();
            }
            function Ordenes_Compra(value1, value2, value3) {
                window.opener.Ordenes_Compra(value1, value2, value3);
                window.close();
            }
            function Ordenes_Compra_Ns(value1, value2, value3) {
                window.opener.Ordenes_Compra_Ns(value1, value2, value3);
                window.close();
            }

            function Autoriza1(value1, value2, value3) {
                var retvalue1 = value1;
                window.opener.Autoriza1(value1, value2);
                window.close();
            }
            function Autoriza2(value1, value2) {
                var retvalue1 = value1;
                window.opener.Autoriza2(value1, value2);
                window.close();
            }
            function Autoriza3(value1, value2, value3) {
                var retvalue1 = value1;
                window.opener.Autoriza3(value1, value2);
                window.close();
            }
            function Autoriza4(value1, value2, value3) {
                var retvalue1 = value1;
                window.opener.Autoriza4(value1, value2);
                window.close();
            }
            function Monedas(value1, value2, value3) {
                window.opener.Monedas(value1, value2, value3);
                window.close();
            }
            function Proveedores(value1, value2, value3) {
                window.opener.Proveedores(value1, value2, value3);
                window.close();
            }

            function Articulos(value1, value2, value3,value4) {
                var retvalue1 = value1;
                window.opener.Articulos(value1, value2, value3,value4);
                window.close();
            }
            function Cve_Movimientos(value, value2) {
                var retvalue1 = value1;
                window.opener.Cve_Movimientos(value1, value2);
                window.close();
            }
            function Obra(value1, value2) {
                window.opener.Obra(value1, value2);
                window.close();
            }
            function Obra2(value1, value2) {
                window.opener.Obra2(value1, value2);
                window.close();
            }
            function Lineas(value1, value2,value3) {
                var retvalue1 = value1;
                var retvalue2 = value2;
                window.opener.Lineas(value1, value2,value3);
                window.close();
            }
            function Usuario(value1, value2) {
                window.opener.Usuario(value1, value2);
                window.close();
            }
            function Salida_elementoArea(value1, value2) {
                window.opener.Salida_elementoArea(value1, value2);
                window.close();
            }
            function Salida_elementoFrente(value1, value2) {
                window.opener.Salida_elementoFrente(value1, value2);
                window.close();
            }
            function Salida_elementoEconomico(value1, value2) {
                window.opener.Salida_elementoEconomico(value1, value2);
                window.close();
            }
            function Compañia(value1, value2) {
                window.opener.Compañia(value1, value2);
                window.close();
            }
            function Obra3(value1, value2) {
                window.opener.Obra3(value1, value2);
                window.close();
            }
            function BObra3(value1, value2) {
                window.opener.BObra3(value1, value2);
                window.close();
            }
    </script>
</head>
<body OnLoad='compt=setTimeout("self.close();",60000)'>
    <form id="form1" runat="server" submitdisabledcontrols="False">
     <asp:ScriptManager ID="ScriptManager2" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <triggers>
              <%--<asp:PostBackTrigger runat="server" ControlID="Ima_Busca"></asp:PostBackTrigger>--%>
            </triggers>
           <ContentTemplate>
               <asp:Panel ID="Pnl_Busqueda" runat="server" CssClass="Paneles" Width="750px">
                <asp:TextBox ID="T_Numero" runat="server" Width="67px"></asp:TextBox>
    <asp:TextBox ID="T_Descipcion" runat="server" Width="514px"></asp:TextBox>
                     &nbsp;<asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" 
                   Text="Busca" />
        <br />
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
                                            <HeaderStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="" HeaderText="Número" >
                                            <HeaderStyle Width="50px" HorizontalAlign="Right" />
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
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                               <asp:BoundField DataField="Numero" HeaderText="Número" >
                <ItemStyle Width="50px" HorizontalAlign="Right" />
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
