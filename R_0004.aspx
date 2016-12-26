<%@ Page Language="VB" AutoEventWireup="false" CodeFile="R_0004.aspx.vb" Inherits="R_0004" %>
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
        function Economico(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Economico2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Area(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Area2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Frente(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Frente2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Tercero(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Tercero2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Proveedor(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Proveedor2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Obra(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Obra2(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Solicitante(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Solicitante1(elemValue1, elemValue2) {
            document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            __doPostBack("T_ElementoA", "TextChanged");
        }
        function Economico_Actividad(elemValue1, elemValue2) {
            document.getElementById('<%= T_Actividad.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Actividad_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Actividad", "TextChanged");
        }
        function Frente_Actividad(elemValue1, elemValue2) {
            document.getElementById('<%= T_Actividad.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Actividad_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Actividad", "TextChanged");
        }
        function Area_Actividad(elemValue1, elemValue2) {
            document.getElementById('<%= T_Actividad.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Actividad_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Actividad", "TextChanged");
        }
        function Articulos(elemValue1, elemValue2, elemValue3, elemValue4) {
            if (elemValue4 == "2") {
                document.getElementById('<%= T_Articulo_Final.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Art_Desc_Final.ClientID %>').value = elemValue2;
                __doPostBack("T_Articulo_Final", "TextChanged");
            }
            else {
                document.getElementById('<%= T_Articulo_Inicial.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Art_Desc_Inicial.ClientID %>').value = elemValue2;
                __doPostBack("T_Articulo_Inicial", "TextChanged");
            }

        }
        function TipoSalida(elemValue1, elemValue2, elemValue3) {
            document.getElementById('<%= T_Tipo_Costo.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Tipo_Costo_Desc.ClientID %>').value = elemValue2;
            __doPostBack("T_Tipo_Costo.ClientID", "TextChanged");
        }
        function Salida_elemento(elemValue1, elemValue2, Numero) {
            if (Numero == "1") {
                document.getElementById('<%= T_Elemento_Inicial.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Ele_Desc_Inicial.ClientID %>').value = elemValue2;
            }
            else {
                document.getElementById('<%= T_Elemento_Final.ClientID %>').value = elemValue1;
                document.getElementById('<%= T_Ele_Desc_Final.ClientID %>').value = elemValue2;
            }
        }
        function Salida_Actividad(elemValue1, elemValue2) {
            document.getElementById('<%= T_Actividad.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Actividad_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Actividad", "TextChanged");
        }
        function Salida_Clasificacion(elemValue1, elemValue2) {
            document.getElementById('<%= T_Clasificacion.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Clas_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Clasificacion", "TextChanged");
        }
        function Salida_Referencia(elemValue1, elemValue2) {
            document.getElementById('<%= T_Referencia.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Ref_Descripcion.ClientID %>').value = elemValue2;
            __doPostBack("T_Referencia", "TextChanged");
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
        .style6
        {
            text-align: left;
        }
        .style8
        {
            width: 0;
        }
        .style12
        {
            width: -500;
        }
        .style14
        {
            height: 33px;
            width: 100%;
        }
        .style20
        {
            height: 25px;
        }
        .style21
        {
            width: 250px;
        }
          .Bloque_Fondo  
        {
    	    position: fixed;
    	    z-index: 98;
    	    top: 0px;
    	    left: 0px;
    	    right: 0px;
    	    bottom: 0px;
            
        }
        .Contenido_Pregunta
        {
            position: fixed;
    	    z-index: 99;
    	    width: 80px;
    	    height: 80px;
    	    margin-left:32%;
    	    margin-top:200px;
        }
        </style>
</head>
<body>
<center>
    <form id="form1" runat="server" style="width:984px;">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <triggers>
              <asp:PostBackTrigger runat="server" ControlID="Btn_Acepta_Imp"></asp:PostBackTrigger>
            </triggers>
    <ContentTemplate>
    
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    <div>
                <table style="width:100%;">
                    <tr>
                        <td width="20%"> 
                                                        &nbsp;</td>
                        <td width="60%">
                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Reporte Consumo Por Articulo"></asp:Label>
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
                         </td>
                    </tr>
                </table>
                <div style="height: 8px;"></div>
        <table style="width:21%;" align="center">
            <tr>
                <td class="style8">
                    &nbsp;</td>
                <td align="center" class="style6">
                            <asp:Button ID="Ima_Imprimir" runat="server" CssClass="Btn_Azul" Text="Imprimir" 
                                Width="110px" />
                                                </td>
                <td align="left" class="style12">
                                                <asp:Button ID="Ima_Salir" runat="server" 
                                CssClass="Btn_Azul" Text="Salir" />
                            </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    

                <table class="style14">
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
    
                <div style="height: 8px"></div>
                <br />
                <asp:Panel ID="Panel2" runat="server" CssClass="Paneles" 
                    style="margin-bottom: 0px">
                    <table style="width: 100%;">
                        <tr>
                            <td width="50%">
                                <asp:Label ID="Label29" runat="server" CssClass="Textos_Azules" Text="Inicial"></asp:Label>
                                &nbsp;
                            </td>
                            <td width="50%">
                                <asp:Label ID="Label30" runat="server" CssClass="Textos_Azules" Text="Final"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label31" runat="server" CssClass="Textos_Azules" 
                                    Text="Tipo Costo"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Tipo_Costo" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Tipo_Costo" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="T_Tipo_Costo_Desc" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="20px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lbl_Elemento" runat="server" CssClass="Textos_Azules" 
                                    Text="Económico"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Elemento_Inicial" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Elemento_Inicial" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="T_Ele_Desc_Inicial" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                <asp:TextBox ID="T_Elemento_Final" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Elemento_Final" runat="server" 
                                    CssClass="Btn_Proveedor" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" 
                                    Width="29px" />
                            </td>
                            <td>
                                <asp:TextBox ID="T_Ele_Desc_Final" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" Text="Fecha"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Fecha_Inicial" runat="server" 
                                    CssClass="form-control-Readonly" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <rjs:PopCalendar ID="PC_Fecha_Inicial" runat="server" Control="T_Fecha_Inicial" 
                                    Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td class="style21">
                                &nbsp;</td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                <asp:TextBox ID="T_Fecha_Final" runat="server" CssClass="form-control-Readonly" 
                                    Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <rjs:PopCalendar ID="PC_Fecha_Final" runat="server" Control="T_Fecha_Final" 
                                    Format="yyyy mm dd" Separator="/" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label2" runat="server" CssClass="Textos_Azules" Text="Actividad"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Actividad" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Actividad" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="T_Actividad_Descripcion" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="20px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label28" runat="server" CssClass="Textos_Azules" Text="Artículo"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Articulo_Inicial" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Articulo_Inicial" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td class="style21">
                                <asp:TextBox ID="T_Art_Desc_Inicial" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                <asp:TextBox ID="T_Articulo_Final" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Articulo_Final" runat="server" 
                                    CssClass="Btn_Proveedor" ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" 
                                    Width="29px" />
                            </td>
                            <td>
                                <asp:TextBox ID="T_Art_Desc_Final" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style20" width="90px">
                                <asp:Label ID="Label32" runat="server" CssClass="Textos_Azules" 
                                    Text="Clasificación"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Clasificacion" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Clasificacion" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td>
                                <asp:TextBox ID="T_Clas_Descripcion" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                            <td width="5px">
                            </td>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="20px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="90px">
                                <asp:Label ID="Label33" runat="server" CssClass="Textos_Azules" 
                                    Text="Referencia"></asp:Label>
                            </td>
                            <td width="100px">
                                <asp:TextBox ID="T_Referencia" runat="server" AutoPostBack="True" 
                                    CssClass="form-control" Width="100px"></asp:TextBox>
                            </td>
                            <td width="20px">
                                <asp:ImageButton ID="Btn_Referencia" runat="server" 
                                    ImageUrl="~/Imagenes/M_Buscar_50.png" TabIndex="5" Width="29px" />
                            </td>
                            <td>
                                <asp:TextBox ID="T_Ref_Descripcion" runat="server" 
                                    CssClass="form-control-Readonly" Width="245px"></asp:TextBox>
                            </td>
                            <td width="5px">
                                &nbsp;</td>
                            <td width="100px">
                                &nbsp;</td>
                            <td width="20px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
        
        
       
        <div>

        </div>
               
     
 
      <div id="Div" runat="server">
            <asp:Panel ID="Pnl_Tipo_Impresion" runat="server" 
            BackColor="#FFFF99" Height="120px" HorizontalAlign="Center" Visible="False" 
            Width="500px" CssClass="Contenido_Pregunta">
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right" width="170px">
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:RadioButtonList ID="RB_Tipo_Impresion" runat="server">
                                    <asp:ListItem Value="Vista_Previa" Selected="True">Vista Previa</asp:ListItem>
                                    <asp:ListItem>Impresora</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%; height: 60px;">
                        <tr>
                            <td style="text-align:center">
                                <asp:Button ID="Btn_Acepta_Imp" runat="server" 
                            CssClass="Btn_Azul" Text="Aceptar" />
                              
                            </td>
                            <td style="text-align:center">
                              <asp:Button ID="Btn_Cancela_Imp" runat="server" 
                            CssClass="Btn_Azul" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
