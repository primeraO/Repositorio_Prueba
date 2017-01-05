<%--<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">--%><%--<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jquery.min.js"></script>
    <script language="javascript" src="bootstrapjs.min.js" type="text/javascript"></script>--%><%--  <title>Sistema de Compras Web</title>
    </head>
    <body>
    </body>
</html>
--%>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default1.aspx.vb" Inherits="_Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
<link href="bootstrap.css" rel="stylesheet" type="text/css" />
<link href="bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="jquery.min.js"></script>
<script language="javascript" src="bootstrapjs.min.js" type="text/javascript"></script>
    <title>Sistema Integral de Administración</title>
    <style type="text/css">
        #form1
        {
            height: 809px;
            width: 1079px;
        }
        .style1
        {
            width: 42.4%;
        }
        </style>
    <%--Codigo JavaScript Deshabilitar Atras--%>
    <script type="text/javascript" language="javascript">
        if (window.history) {
            function noBack() { window.history.forward() }
            noBack();
            window.onload = noBack;
            window.onpageshow = function (evt) { if (evt.persisted) noBack() }
            window.onunload = function () { void (0) }
        }

        function Obra(elemValue1) {
            document.getElementById('<%= T_Obra.ClientID %>').value = elemValue1;
            __doPostBack("T_Obra", "TextChanged")
        }
    </script>
     <script type="text/javascript">
                 function Obra3(elemValue1, elemValue2) {
             document.getElementById('<%= T_Obra.ClientID %>').value = elemValue1;
         }
    </script>
    <%--Codigo JavaScript Manejo de Hora en Etiqueta--%><%--<script language="javascript" type="text/javascript">
     var timerID = null;
     var timerRunning = false;

     function stopclock() {
         if (timerRunning)
             clearTimeout(timerID);
         timerRunning = false;
     }
     function showtime() {
         var now = new Date();
         var hours = now.getHours();
         var minutes = now.getMinutes();
         var seconds = now.getSeconds();
         var timeValue = "" + ((hours > 12) ? hours - 12 : hours)

         if (timeValue == "0") timeValue = 12;
         timeValue += ((minutes < 10) ? ":0" : ":") + minutes
         timeValue += ((seconds < 10) ? ":0" : ":") + seconds
         timeValue += (hours >= 12) ? " P.M." : " A.M."
         document.getElementById('L_Tiempo').innerText = timeValue;
         timerID = setTimeout("showtime()", 1000);
         timerRunning = true;
     }
     function startclock() {
         stopclock();
         showtime();
     }
     function hora_minutos() {
         var now = new Date();
         var hours = now.getHours();
         var minutes = now.getMinutes();
         var timeValue = "" + ((hours > 12) ? hours - 12 : hours)
         if (timeValue == "0") timeValue = 12;
         document.getElementById('H_Hora_Minutos').value = "" + timeValue + "" + minutes
     }
  </script>--%>
  <link rel="shortcut icon"  href="~/Imagenes/interop.ico"/>
</head>
<body>
<center>
    <form id="form1" runat="server" 

    style="background-repeat: no-repeat; width: 1041px; background-image: url('Imagenes/PUNTODEVENTA2.jpg')">
    <div> 

        
                        <br />
                        <br />
                        <br />
                        <br />


        <div>

            <table style="width:100%;">
                <tr>
                    <td style="text-align: left" width="15%">
                        &nbsp;</td>
                    <td width="35%">
                        &nbsp;</td>
                    <td width="35%">
                        &nbsp;</td>
                    <td style="text-align: right" width="15%">
        <%--<asp:Image ID="Image1" runat="server" Height="61px" 
            ImageUrl="~/Imagenes/logo_Inter_Original.jpg" Width="174px" />--%>
                    </td>
                </tr>
            </table>

        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="35%">
                        &nbsp;</td>
                    <td width="15%">
                        &nbsp;</td>
                    <td width="15%">
                        &nbsp;</td>
                    <td width="35%">
                        <br />
           

           
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="8%">
                        &nbsp;</td>
                    <td>
                         <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" 
                             BorderStyle="Solid" ForeColor="#FF3300" 
                             style="float: none; text-align: center;" Text="Label" Visible="False" 
                             Width="96%"></asp:Label>
                         </td>
                    <td width="8%">
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                     <td width="51%">
                        &nbsp;</td>
                    <td style="text-align: right" >
        <asp:Label ID="Label1" runat="server" BorderStyle="None" 
            style="top: 181px; left: 313px; width: 111px; bottom: 540px; right: 667px; text-align: right;" 
            Text="Empresa:" CssClass="Textos_Azules"></asp:Label>
                    </td>
                    <td style="text-align: left; " 
                        align="left">
                        <asp:DropDownList ID="List_Empresa" runat="server" AutoPostBack="True" 
                            Width="329px" CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right" width="15%" height="40px">
                        &nbsp;</td>
                    <td width="37%">
                        &nbsp;</td>
                </tr>
                </table>
            <table style="width:100%;">
                <tr>
                    <td width="25%">
                        &nbsp;</td>
                    <td width="15%" style="text-align:right">
        <asp:Label ID="Label2" runat="server" BorderStyle="None" 
            style="left: 311px; bottom: 423px; top: 226px; right: 970px; text-align: center;" 
            Text="Proyecto:" CssClass="Textos_Azules"></asp:Label>
                    </td>
                    <td width="80px">
        <asp:TextBox ID="T_Obra" runat="server" 
            
            style="top: 225px; left: 450px; " 
            TabIndex="2" Width="62px" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </td>
                    <td style="text-align:left">
                        <asp:HyperLink ID="H_Obra" runat="server" 
                            ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="25%">
                        &nbsp;</td>
                    <td style="text-align: right" width="15%">
        <asp:Label ID="Label3" runat="server" BorderStyle="None" 
            style="left: 311px; bottom: 423px; top: 226px; right: 970px; text-align: center;" 
            Text="Almacen:" CssClass="Textos_Azules"></asp:Label>
                    </td>
                    <td style="text-align: right" width="15%" height="40px">
        <asp:TextBox ID="T_Almacen" runat="server" 
            
            style="top: 225px; left: 450px; " 
            TabIndex="2" Width="28%" CssClass="form-control" autocomplete="off" ></asp:TextBox>
                    </td>
                    <td style="text-align: right" width="15%" height="40px">
                        &nbsp;</td>
                    <td width="37%">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="30%">
                        &nbsp;</td>
                    <td>
                        <br />
                        <asp:Button ID="ImageButton1" runat="server" CssClass="Btn_Azul" 
                            Text="Aceptar" />
                        <asp:Button ID="ImageButton2" runat="server" CssClass="Btn_Azul" 
                            Text="Regresar" />
                        <br />
                        <br />
                    </td>
                    <td width="30%">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="30%">
                        &nbsp;</td>
                    <td width="40%">
                        &nbsp;</td>
                    <td width="30%">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="42%">
                        &nbsp;</td>
                    <td width="16%">
                        <br />
                    </td>
                    <td width="42%">
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <div>

            <table style="width:100%;">
                <tr>
                    <td xml:lang="32%">
                        &nbsp;</td>
                    <td width="36%">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
        <asp:HiddenField runat="server" ID="H_Hora_Minutos" />
                        <br />
                        <br />
                    </td>
                    <td width="32%">
                        &nbsp;</td>
                </tr>
            </table>

        </div>
    </div>

    </form>
</center>
</body>
</html>
