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

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

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
        </style>
    <%--Codigo JavaScript Deshabilitar Atras--%>
    <script type="text/javascript">
        if (window.history) {
            function noBack() { window.history.forward() }
            noBack();
            window.onload = noBack;
            window.onpageshow = function (evt) { if (evt.persisted) noBack() }
            window.onunload = function () { void (0) }
        }
    </script>
    <%--Codigo JavaScript Manejo de Hora en Etiqueta--%> <%--<script language="javascript" type="text/javascript">
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
     style="background-repeat: no-repeat; width: 1041px; background-image: url('Imagenes/Inventario.jpg');"
   >
    <div> 
    
        <asp:Button ID="Button1" runat="server" BackColor="#F1F1F1" BorderStyle="None" 
            style="top: 70px; left: 669px; height: 26px; width: 56px; " 
                            TabIndex="4" />
    
                        <br />
                        <br />
                        <br />
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
                    <td>
                        <asp:Label ID="Msg_Err" runat="server" BackColor="#FFFF99" BorderColor="Black" 
                            BorderStyle="Solid" ForeColor="#FF3300" 
                            style="float: none; text-align: center;" Text="Label" Visible="False" 
                            Width="96%"></asp:Label>
                        <br />
           
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="33%">
                        &nbsp;</td>
                    <td width="15%" style="text-align: right">
                        &nbsp;</td>
                    <td width="15%" style="text-align: right" height="40px">
                        &nbsp;</td>
                    <td width="37%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="33%">
                        &nbsp;</td>
                    <td width="15%" style="text-align: right">
        <asp:Label ID="Label3" runat="server" BorderStyle="None" 
            style="height: 19px; right: 948px; bottom: 383px; top: 266px; left: 310px; " 
            Text="Usuario:" Height="16px" CssClass="Textos_Azules"></asp:Label>
                    </td>
                    <td width="15%" style="text-align: right" height="40px">
        <asp:TextBox ID="T_Usuario" runat="server" 
            
            style="top: 264px; left: 450px; " 
            TabIndex="1" ToolTip="Contraseña" Width="98%" CssClass="form-control" autocomplete="off"></asp:TextBox>
                    </td>
                    <td width="37%">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="33%">
                        &nbsp;</td>
                    <td width="15%" style="text-align: right">
        <asp:Label ID="Label5" runat="server" BorderStyle="None" 
            style="height: 19px; right: 948px; bottom: 383px; top: 266px; left: 310px; " 
            Text="Contraseña:" Height="16px" CssClass="Textos_Azules"></asp:Label>
                    </td>
                    <td width="15%" style="text-align: right" height="40px">
        <asp:TextBox ID="T_Contraseña" runat="server" 
            
            style="top: 264px; left: 450px; " 
            TabIndex="2" ToolTip="Contraseña" Width="98%" CssClass="form-control" TextMode="Password">USUARIO1</asp:TextBox>
                    </td>
                    <td width="37%">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width:100%;">
                <tr>
                    <td width="48%" align="right">
                        &nbsp;</td>
                    <td width="4%">
                        <br />
                        <asp:Button ID="ImageButton1" runat="server" CssClass="Btn_Azul" Text="Inicio" 
                            TabIndex="3" />
                        <br />
                        <br />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
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
        <asp:Button ID="Btn_Registrarse" runat="server" 
            style="top: 124px; left: 892px; " 
            Text="Registrarse" Visible="False" CssClass="Btn_Azul" Width="100%" Height="48px" />
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
    
                        <br />
    
        <asp:HiddenField runat="server" ID="H_Hora_Minutos" />
                        <br />
        <asp:DropDownList ID="List_Servidor" runat="server" Height="28px" 
            style="top: 123px; left: 261px; " Width="345px" 
            Visible="False">
        </asp:DropDownList>
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
