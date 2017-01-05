<%@ Page Language="VB" AutoEventWireup="false" CodeFile="C_Productos.aspx.vb" Inherits="C_Productos" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2010" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon"  href="images/Icos/interop.ico"/>
    <link href="Styles/simple-sidebar.css" rel="stylesheet" type="text/css" />
    <link href="Styles/MyEstilo.css" rel="stylesheet" type="text/css" />
    <%--<link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />--%>    <%--<link href="Styles/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Estilos.css " rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="Scripts/jquery-ui.js"></script>
    <script language="javascript" src="Scripts/bootstrapjs.min.js" type="text/javascript"></script>
    <script language="javascript" src="Scripts/CodigoJS.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    var iMinute;var TiempoExpiracion;
    $(document).ready(function(){iMinute = <%= Session.TimeOut %>;
    clearTimeout(TiempoExpiracion);AsignaExpiracion();
    });
    function AsignaExpiracion(){TiempoExpiracion=window.setTimeout("Expira_Session();",540000);}function Expira_Session(){iMinute -= 9;if (iMinute==1) {var Div_SessionClass=document.getElementById('Div_Session');Div_SessionClass.className ="Bloque_Fondo";var bt=document.getElementById('<%= Pnl_Session.ClientID %>');bt.style.display='block';clearTimeout(TiempoExpiracion);TiempoExpiracion = window.setTimeout("Redireccionar();",30000);}}function Redireccionar(){var bt=document.getElementById('<%= Pnl_Session.ClientID %>');if (bt.style.display!="block") {clearTimeout(TiempoExpiracion);AsignaExpiracion();}else{window.location.href = '<%= Page.ResolveUrl("~/Principal.aspx") %>';}}function CargarDeNuevo(){iMinute = <%= Session.TimeOut %>;var Div_SessionClass=document.getElementById('Div_Session');Div_SessionClass.className="";var bt=document.getElementById('Pnl_Session');bt.style.display='none';clearTimeout(TiempoExpiracion);AsignaExpiracion();}AsignaExpiracion();</script>
    <title></title>
</head>
<body>
    <center>    
        <%--<nav class="navbar navbar-inverse" style="border-radius:0px;">
              <div class="container">
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                  <a class="navbar-brand" href="Principal.aspx" style=" color:White;">Herramientas Laguna</a>
                </div>
                <div id="navbar" class="navbar-collapse collapse" aria-expanded="false" style="height: 0.909091px;">
                  <ul class="nav navbar-nav">
                    <li class="active"><a href="Inicio.aspx">Productos</a></li>
                    <li><a href="C_Productos.aspx">Catalogo Productos</a></li>
                  </ul>
                </div>
              </div>
            </nav>--%>


    <form id="form1" runat="server" style="width: 984px">
   <%-- <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>--%>
        
            <div  style="margin-bottom:15px;">
                <div style="margin-top:30px; margin-bottom:30px;">
                    <table style="width:100%;">
                        <tr>
                            <td width="15%">
                                &nbsp;</td>
                            <td width="70%">
                                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Catálogo de Artículos" Width="100%"></asp:Label>
                                    <br />
                                </asp:Panel>
                            </td>
                            <td style="text-align: right" width="15%">
                                <asp:Image ID="Image1" runat="server" Height="61px" 
                                    ImageUrl="images/Icos/logo_Inter_Original.jpg" style="text-align: right" 
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
                                    <asp:Label ID="Lbl_Almacen" runat="server" Font-Bold="True" 
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
            
                   
            </div>
           <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>--%>
     
            <div>
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
                                                    <asp:Button ID="Btn_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" 
                                                        Width="90px" TabIndex="1" />
                                                    <asp:Button ID="Btn_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                                        Width="80px" TabIndex="2" />
                                                    <asp:Button ID="Btn_Restaura" runat="server" CssClass="Btn_Azul" 
                                                        Text="Restaura" Width="110px" TabIndex="3" />
                                                    <asp:Button ID="Btn_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                                        Width="100px" TabIndex="4" />
                                                    <asp:Button ID="Btn_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
                                                        TabIndex="5" />
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td width="100">
                                &nbsp;</td>
                        </tr>
                    </table>
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
                <asp:Panel ID="Pnl_Busqueda" runat="server" CssClass="Paneles" Width="984px">
                <table style="width:100%;">
                    <tr>
                        <td class="style5" width="100px">
                            </td>
                        <td width="140px">
                            <asp:TextBox ID="TB_Articulo" runat="server" Width="140px" TabIndex="6" placeholder="Clave Artículo" 
                                        CssClass="form-control" MaxLength="13" style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                        <td style="text-align: right" width="10px"> &nbsp;</td>
                        <td width="520px">
                            <asp:TextBox ID="TB_Descripcion" runat="server" Width="500px" TabIndex="7" 
                                placeholder="Descripción" CssClass="form-control" style="text-transform: uppercase;"></asp:TextBox>
                        </td>
                        <td width="100px">
                            <asp:CheckBox ID="Ch_Baja" runat="server" AutoPostBack="True" 
                                CssClass="Textos_Azules" Text="Bajas" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <%--Empieza Pnl_Grids--%>
                <asp:Panel ID="Pnl_Grids" runat="server" Visible="False" HorizontalAlign="Left">
                    <br />
                    <div style="overflow:hidden; height:35px; width:984px;" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="4">
                                         <RowStyle BackColor="#EFF3FB" Height="35px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Clave Artículo">
                                            <HeaderStyle Width="120px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripción" >
                                            <HeaderStyle Width="299px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Imagen" >
                                            <HeaderStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ficha Técnica" >
                                            <HeaderStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Ver" >
                                            <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Cambio" >
                                            <HeaderStyle Width="65px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Baja" >
                                            <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                    </div>
                    <div style="overflow-y:scroll; overflow-x:hidden;  width:984px; height:500px;">
                       <asp:GridView ID="GridView1" runat="server" 
                        AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                        GridLines="None" 
                         style="top: 152px; left: 86px; " Font-Size="Small" 
                                     Width="964px" Height="16px" CellSpacing="4" DataKeyNames="Articulo" 
                            ShowHeader="False" ShowHeaderWhenEmpty="True">
                        <RowStyle BackColor="#EFF3FB" Height="22px"/>
                        <Columns>
                            <asp:BoundField DataField="Articulo" HeaderText="Articulo" >
                            <ItemStyle Width="120px" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" >
                                <ItemStyle HorizontalAlign="Left" Width="299px" VerticalAlign="Top"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Ruta_Foto" HeaderText="Imagen" >
                                <ItemStyle HorizontalAlign="Left" Width="200px" VerticalAlign="Top"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Ficha_Tecnica" HeaderText="Ficha Tecnica" >
                                <ItemStyle HorizontalAlign="Left" Width="200px" VerticalAlign="Top"/>
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                                ImageUrl="~/images/Icos/M_Selecciona_50.png" Text="Sel.">
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                                ImageUrl="~/images/Icos/M_Cambio_50.png" Text="Cambio">
                            <ItemStyle HorizontalAlign="Center" Width="65px" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Image" CommandName="Baja" HeaderText="Baja" 
                                ImageUrl="~/images/Icos/M_Baja_50.png" Text="Baja">
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
                </asp:Panel>  <%--Termina Pnl_Grids--%>
                </asp:Panel>  <%--Termina Pnl_Busqueda--%>

                <br />

                <asp:Panel ID="Pnl_Registro" runat="server" CssClass="Paneles" Width="984px">
                    <table style="width: 100%;">
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                                <asp:Label ID="Label1" runat="server" Text="Artículo" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="784px">
                                <asp:TextBox ID="T_Articulo" runat="server" CssClass="form-control" MaxLength="13" 
                                    Width="130px" style="text-transform: uppercase;" TabIndex="70" placeholder="Artículo"></asp:TextBox>
                                <%--<asp:Label ID="L_Nombre_Foto" runat="server" Text="Aqui esta la información "></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                                <asp:Label ID="Label2" runat="server" Text="Descripción" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="784px">
                                <asp:TextBox ID="T_Descripicion" runat="server" CssClass="form-control" 
                                    MaxLength="50" Width="500px" style="text-transform: uppercase;" 
                                    TabIndex="71" placeholder="Descripción"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                                <asp:Label ID="Label3" runat="server" Text="Imagen" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="784px">
                                    <asp:FileUpload ID="FU_Ruta_Foto" runat="server" CssClass="form-control" 
                                        EnableViewState="False" />
                                <%--<asp:FileUpload ID="FU_Ruta_Foto" runat="server"
                                    Width="500px"  OnChange="metodo(this)"/>--%>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                                <asp:Label ID="Label6" runat="server" Text="" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="784px">
                                <asp:Label ID="Lbl_Ruta_Imagen" runat="server" Text="" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                                <asp:Label ID="Label4" runat="server" Text="Ficha Técnica" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="784px">
                                <asp:FileUpload ID="FU_Ficha_Tecncia" runat="server" CssClass="form-control" 
                                    Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                                <asp:Label ID="Label5" runat="server" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td width="784px">
                                <asp:Label ID="Lbl_Ficha_Tecnica" runat="server" 
                                    CssClass="Textos_Azules"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px">
                            </td>
                            <td width="110px">
                            </td>
                            <td width="784px">
                                <asp:Image ID="Imagen" runat="server" Height="540px" 
                                    ImageUrl="D:/Imagen_Herr/imagen-no.png" Width="70%" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
            </div>
            </div>
            <div>
                <table style="width:100%;">
                    <tr>
                        <td width="42%">
                            &nbsp;</td>
                        <td width="16%">
                            <br />
                            <asp:HiddenField ID="Movimiento" runat="server" />
                            <asp:HiddenField ID="HF_Ruta" runat="server" />
                            <asp:HiddenField ID="HF_Ficha" runat="server" />
                        </td>
                        <td width="42%">
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>

        
                <div id="Div_Session" runat="server">
                    <asp:Panel ID="Pnl_Session" runat="server" BackColor="#FFFF99" Height="145px" 
                        HorizontalAlign="Center" Width="500px" CssClass="Contenido_Pregunta" style="display:none;">
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                   <asp:Label ID="Label7" runat="server" Text="Su sesión a Expirado. ¿Que desea hacer?" CssClass="Textos_Azules" ></asp:Label><br />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%; height: 60px;">
                            <tr>
                                <td>
                                    <asp:Button ID="Btn_Restablecer" runat="server" CssClass="Btn_Azul" 
                                        Text="Restableder y Continuar" Width="220px"
                                            OnClientClick="CargarDeNuevo();"/>
                                </td>
                            </tr>
                        </table>
                         <table style="width: 100%; height: 60px;">
                            <tr>
                                 <td>
                                    &nbsp;<asp:Button ID="Btn_Default" runat="server" CssClass="Btn_Azul" 
                                        Text="Salir de la Forma" Width="220px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>


        <%--</ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Btn_Guarda"/>
        </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="overlay" />
                <div class="overlayContent">
                    <img src="images/Icos/cargando.gif" alt="Loading" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
       </form>
    </center>
    </body>

</html>
