<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Pop_Proveedor.aspx.vb" Inherits="Pop_Proveedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


.Textos_Encabezado_Azul
{
 color:         #000087;
 font-weight:bold;
 font:          normal 700 36px/1 "Calibri", sans-serif;
    margin-left: 0px;
}
        .style9
        {
            width: 100px;
        }
        
.Textos_Azules
{
 color:         #000087;
 font-weight:bold;
    text-align: left;
}

        .style11
        {
            width: 59px;
        }
        .form-control {
  display: block;
  width: 100%;
  padding: 6px 12px;
  font-size: 14px;
  line-height: 1.42857143;
  color: #555;
  background-color: #fff;
  background-image: none;
  border: 1px solid #ccc;
  border-radius: 4px;
  -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
          box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
  -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
       -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
          transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
}
        .style12
        {
            width: 37px;
        }
        .style13
        {
            width: 355px;
        }
        .style17
        {
            width: 112px;
        }
        .style18
        {
            width: 68px;
        }
        .style19
        {
            width: 70px;
        }
        .style20
        {
            width: 82px;
        }
        
.Btn_Azul
{
display:       inline-block;
padding:       8px 20px;
background:    #0f78d7 repeat-x;
background:    -moz-linear-gradient(#429ff3, #0f78d7);
background:    -o-linear-gradient(#429ff3, #0f78d7);
background:    -webkit-linear-gradient(#429ff3, #0f78d7);
background:    linear-gradient(#429ff3, #0f78d7);
border-radius: 999px;
color:         #fff;
font:          normal 700 16px/1 "Calibri", sans-serif;
text-shadow:   1px 1px 0 #000;
}

        .style21
        {
            width: 60%;
        }

        </style>
        <script type="text/javascript">
        function Proveedor(elemValue1, elemValue2,elemValue3) {
            document.getElementById('<%= T_Fletero.ClientID %>').value = elemValue1;
            document.getElementById('<%= T_Fletero_Desc.ClientID %>').value = elemValue2;
            document.getElementById('<%= T_Fletero_RFC.ClientID %>').value = elemValue3;
        }
</script>        
</head>
<body>
<center>
  <form id="form1" runat="server">
    <div style="width: 984px">
    
                <table style="width:100%;">
                    <tr>
                        <td width="20%">
                            &nbsp;</td>
                        <td align="center" class="style21">

                            <asp:Panel ID="Panel1" runat="server" Height="90px" HorizontalAlign="Center">
                                <asp:Label ID="Label36" runat="server" CssClass="Textos_Encabezado_Azul" 
                                    Height="40px" Text="Fletero"></asp:Label>
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
                            <br />
                            <br />
                        </td>
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
                            <br />
                         </td>
                        <td width="15%">
                            <br />
                        </td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td class="style9">
                            &nbsp;</td>
                        <td align="left" class="style9">
                            <asp:Label ID="Label26" runat="server" BorderStyle="None" Text="Fletero" 
                                CssClass="Textos_Azules"></asp:Label>
                        </td>
                        <td class="style11">
                            <asp:TextBox ID="T_Fletero" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="4" 
                                Width="39px" CssClass="form-control">0</asp:TextBox>
                        </td>
                        <td class="style12">
                            <asp:HyperLink ID="H_Fletero" runat="server" BorderStyle="None" Enabled="False" 
                                ImageUrl="~/Imagenes/M_Buscar_50.png">HyperLink</asp:HyperLink>
                        </td>
                        <td class="style13">
                            <asp:TextBox ID="T_Fletero_Desc" runat="server" MaxLength="50" 
                        style="top: 481px; left: 10px; text-align: left;" 
                        TabIndex="3" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="T_Fletero_RFC" runat="server" MaxLength="50" 
                        style="top: 481px; left: 10px; text-align: left;" 
                        TabIndex="3" CssClass="form-control" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td class="style9">
                            &nbsp;</td>
                        <td align="left" class="style9">
                            <asp:Label ID="Label27" runat="server" BorderStyle="None" Text="Importe Flete" 
                                CssClass="Textos_Azules" Width="101px"></asp:Label>
                        </td>
                        <td class="style17">
                            <asp:TextBox ID="T_Importe" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="4" 
                                Width="80px" CssClass="form-control">0.00</asp:TextBox>
                        </td>
                        <td align="left" class="style18">
                            <asp:Label ID="Label28" runat="server" BorderStyle="None" Text="% I.V.A." 
                                CssClass="Textos_Azules" Width="70px"></asp:Label>
                        </td>
                        <td class="style19">
                            <asp:TextBox ID="T_Iva" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="4" 
                                Width="40px" CssClass="form-control">0.00</asp:TextBox>
                        </td>
                        <td align="left" class="style20">
                            <asp:Label ID="Label29" runat="server" BorderStyle="None" Text="Descuento" 
                                CssClass="Textos_Azules" Width="80px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="T_Descuento" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="4" TabIndex="4" 
                                Width="60px" CssClass="form-control">0.00</asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table style="width:100%;">
                    <tr>
                        <td class="style9">
                            &nbsp;</td>
                        <td align="left" class="style9">
                            <asp:Label ID="Label30" runat="server" BorderStyle="None" Text="Referencia" 
                                CssClass="Textos_Azules" Width="101px"></asp:Label>
                        </td>
                        <td class="style17">
                            <asp:TextBox ID="T_Referencia" runat="server" 
                 style="text-align:left; top: 493px; left: 645px; " MaxLength="30" TabIndex="4" 
                                Width="80px" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td align="left" class="style18">
                            &nbsp;</td>
                        <td class="style19">
                            &nbsp;</td>
                        <td align="left" class="style20">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
    
                <table style="width:100%;">
                    <tr>
                        <td class="style9">
                            &nbsp;</td>
                        <td align="left" class="style9">
                            &nbsp;</td>
                        <td class="style17">
                            &nbsp;</td>
                        <td align="left" class="style18">
                            &nbsp;</td>
                        <td class="style19">
                            <asp:Button ID="Ima_Guardar" runat="server" CssClass="Btn_Azul" Text="Guardar" 
                                Width="114px" TabIndex="7" />
                                                </td>
                        <td align="left" class="style20">
                                                <asp:Button ID="Ima_Salir" runat="server" 
                                CssClass="Btn_Azul" Text="Regresar" TabIndex="8" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
    
                <br />
    
    </div>
    </form>
</center>

</body>


  
</html>
