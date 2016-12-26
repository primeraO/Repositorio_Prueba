<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Catalogo_Compañia.aspx.vb" Inherits="Catalogo_Compañia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script language="javascript" src="CodigoJS.js" type="text/javascript">
        alert("Error al abrir archivo.js");
</script>
    <style type="text/css">
        .style6
        {
            width: 12%;
        }
        .style9
        {
            width: 43%;
        }
        .style10
        {
            width: 32px;
        }
        .style11
        {
            width: 5%;
        }
        .style12
        {
            width: 25%;
        }
        .style15
        {
            width: 250px;
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
           </style>
</head>
<body>
    <center>    
        <form id="form1" runat="server" style="width: 984px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>--%>
            
            <div>

                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            &nbsp;</td>
                        <td width="70%">

                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center">
                                    <asp:Label ID="Label25" runat="server" CssClass="Textos_Encabezado_Azul" 
                                        Text="Catálogo Compañía" Width="95%"></asp:Label>
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
                                           
                                <asp:Button ID="Ima_Busca" runat="server" CssClass="Btn_Azul" Text="Busca" />
                                &nbsp;
                                <asp:Button ID="Ima_Alta" runat="server" CssClass="Btn_Azul" Text="Alta" 
                                  />
                                &nbsp;
                                <asp:Button ID="Ima_Restaura" runat="server" CssClass="Btn_Azul" 
                                    Text="Restaura" />
                                &nbsp;
                                <asp:Button ID="Ima_Guarda" runat="server" CssClass="Btn_Azul" Text="Guarda" 
                                   />
                                            &nbsp;
                                                <asp:Button ID="Ima_Salir" runat="server" CssClass="Btn_Azul" Text="Salir" 
                                                   />
                                            </td>
                                            
                                            <td width="10%">
                                           
                                                &nbsp;</td>
                                            
                                        </tr>
                                    </table>
                                
            
                

            

                <table style="width:100%;">
                    <tr>
                        <td width="15%">
                            </img>

                            &nbsp;&nbsp;</td>
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
                <asp:Panel ID="Pnl_Busqueda" CssClass="Paneles" runat="server" >
                    <table style="width:100%;">
                        <tr>
                            <td width="5%">
                            </td>
                            <td width="11%">
                                <asp:TextBox ID="TB_Numero" runat="server" Width="97%" TabIndex="1" placeholder="Num." 
                                CssClass="form-control" Height="18px"></asp:TextBox>
                            </td>
                            <td style="text-align: right" class="style10">
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TB_Descripcion" runat="server" Width="91%" TabIndex="2" 
                                placeholder="Razon Social" CssClass="form-control" 
                                Height="18px"></asp:TextBox>
                            </td>
                            <td width="12%">
                                &nbsp;</td>
                            <td width="5%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="5%">
                                &nbsp;</td>
                            <td width="11%">
                                &nbsp;</td>
                            <td class="style10" style="text-align: right">
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td width="12%">
                                &nbsp;</td>
                            <td width="5%">
                                &nbsp;</td>
                        </tr>
                    </table>

                    <asp:Panel ID="Pnl_Grids" runat="server" HorizontalAlign="Left" Visible="False">
                                  <div style="overflow:hidden; height:35px; width:100%; float:left" >
                             <asp:GridView id="Cabecera" runat="server" 
                                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                                GridLines="None" ShowHeaderWhenEmpty="True"
                                 style="top: 152px; left: 86px; " Font-Size="Small" 
                                         Width="964px" Height="35px" CellSpacing="4">
                                         <RowStyle BackColor="#EFF3FB" Height="22px" />
                                            <Columns>
                                            <asp:BoundField HeaderText="Núm">
                                            <HeaderStyle  Width="50px" HorizontalAlign="Left"/>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Razón Social" >
                                            <HeaderStyle Width="684px" />
                                            </asp:BoundField>
                                              <asp:BoundField HeaderText="RFC" >
                                            <HeaderStyle Width="110px" />
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Ver" >
                                            <HeaderStyle Width="40px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField  HeaderText="Cambio" >
                                            <HeaderStyle Width="50px"  HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                            </div>
           <div style="overflow-y:scroll; overflow-x:hidden; width:100%; height:500px;">
            <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns="False" CellPadding="1" ForeColor="#333333" 
                GridLines="None" 
                 style="top: 152px; left: 86px; " Font-Size="Small" 
                             Width="964px" Height="16px" CellSpacing="4" DataKeyNames="Cia" 
                                Visible="False" ShowHeader="False">
                <RowStyle BackColor="#EFF3FB" Height="22px" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" Visible="False" >
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Cia" HeaderText="Num." >
                    <ItemStyle Width="50px" HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Razon_Social" HeaderText="Razon social" >
                        <ItemStyle HorizontalAlign="Left" Width="684px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="RFC" HeaderText="RFC" >
                        <ItemStyle HorizontalAlign="Left" Width="110px"/>
                    </asp:BoundField>
                     <asp:ButtonField ButtonType="Image" CommandName="Seleccion" HeaderText="Ver" 
                        ImageUrl="~/Imagenes/M_Selecciona_50.png" Text="Ver">
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Image" CommandName="Cambio" HeaderText="Cambio" 
                        ImageUrl="~/Imagenes/M_Cambio_50.png" Text="Cambio">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
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
                <asp:Panel ID="Pnl_Registro" CssClass="Paneles" runat="server" >
                    <table style="width:100%;">
                        <tr>
                            <td style="text-align: left" class="style11">
                                &nbsp;</td>
                            <td style="text-align: left" width="15%" height="40px">
                                <asp:Label ID="Label16" runat="server" BorderStyle="None" Text="Num." 
                                CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Numero" runat="server" 
                 style="text-align:right;top: 493px; left: 645px; " MaxLength="10" TabIndex="3" 
                                Width="50px" CssClass="form-control" 
                                Height="18px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="15%" height="40px">
                                <asp:Label ID="Label45" runat="server" CssClass="Textos_Azules" 
                                Text="Clave de Acceso"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px">
                                <asp:TextBox ID="T_Clave_Acceso" runat="server" CssClass="form-control" 
                                Height="18px" Width="104px" MaxLength="10" TabIndex="4"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="5%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" class="style11">
                                &nbsp;</td>
                            <td style="text-align: left" width="10%" height="40px">
                                <asp:Label ID="Label24" runat="server" BorderStyle="None" Text="Razon Social" 
                                CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px" class="style9">
                                <asp:TextBox ID="T_Razon_Social" runat="server" MaxLength="60" 
                        style="top: 481px; left: 10px; text-align: left;" 
                        TabIndex="5" CssClass="form-control" Width="90%" 
                                Height="18px"></asp:TextBox>
                            </td>
                            <td style="text-align: left" height="40px" class="style6">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px" class="style12">
                                &nbsp;</td>
                            <td style="text-align: left" width="11%">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" class="style11">
                                &nbsp;</td>
                            <td style="text-align: left" width="10%" height="40px">
                                <asp:Label ID="Label26" runat="server" CssClass="Textos_Azules" 
                                Text="Adicional"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px" class="style9">
                                <asp:TextBox ID="T_Adicional" runat="server" CssClass="form-control" Height="18px" 
                                MaxLength="50" TabIndex="6" Width="90%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" height="40px" class="style6">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px" class="style12">
                                &nbsp;</td>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: left" class="style11">
                                &nbsp;</td>
                            <td style="text-align: left" width="10%" height="40px">
                                <asp:Label ID="Label27" runat="server" CssClass="Textos_Azules" Text="RFC"></asp:Label>
                            </td>
                            <td style="text-align: left" height="40px" class="style9">
                                <asp:TextBox ID="T_RFC" runat="server" CssClass="form-control" Height="18px" 
                                TabIndex="7" Width="177px" MaxLength="13"></asp:TextBox>
                            </td>
                            <td style="text-align: left" height="40px" class="style6">
                                &nbsp;</td>
                            <td style="text-align: left" height="40px" class="style12">
                                &nbsp;</td>
                            <td style="text-align: left" width="11%">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td class="style11">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left" width="15%">
                                <asp:Label ID="Label28" runat="server" CssClass="Textos_Azules" Text="Colonia"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Colonia" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="50" TabIndex="8" Width="90%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="10%">
                                <asp:Label ID="Label29" runat="server" CssClass="Textos_Azules" 
                                    Text="Direccion"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Direccion" runat="server" CssClass="form-control" 
                                    Height="18px" TabIndex="9" Width="86%"></asp:TextBox>
                            </td>
                            <td class="style11">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="5%">
                                &nbsp;</td>
                            <td height="40px" style="text-align: left" width="15%">
                                <asp:Label ID="Label30" runat="server" CssClass="Textos_Azules" Text="Estado"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Estado" runat="server" CssClass="form-control" Height="18px" 
                                    MaxLength="20" TabIndex="10" Width="70%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="17%">
                                <asp:Label ID="Label31" runat="server" CssClass="Textos_Azules" Text="C.P."></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_CP" runat="server" CssClass="form-control" Height="18px" 
                                    TabIndex="11" Width="70%"></asp:TextBox>
                            </td>
                            <td style="text-align: left" width="15%">
                                <asp:Label ID="Label32" runat="server" CssClass="Textos_Azules" Text="Telefono"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="T_Telefono" runat="server" CssClass="form-control" 
                                    Height="18px" MaxLength="18" TabIndex="12" Width="70%"></asp:TextBox>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td height="40px" style="text-align: left">
                                <asp:Label ID="Label42" runat="server" CssClass="Textos_Azules" 
                                    Text="Numero de Orden" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Num_Orden" runat="server" CssClass="form-control" 
                                    Height="18px" TabIndex="22" Width="70%" Visible="False"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="Label43" runat="server" CssClass="Textos_Azules" 
                                    Text="Numero de Requisicion" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Num_Requisicion" runat="server" CssClass="form-control" 
                                    Height="18px" TabIndex="23" Width="70%" Visible="False"></asp:TextBox>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="Label44" runat="server" CssClass="Textos_Azules" Text="Almacen"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="T_Num_Almacen" runat="server" CssClass="form-control" 
                                    Height="18px" TabIndex="24" Width="70%"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table style="width:100%;">
                        <tr>
                            <td width="5%">
                                &nbsp;</td>
                            <td height="40" style="text-align: left" width="20%">
                                <asp:Label ID="Label1" runat="server" AssociatedControlId="fileUploader1" 
                                    CssClass="Textos_Azules" Text="Seleccionar una imagen:" />
                            </td>
                            <td style="text-align: left">
                                <asp:FileUpload ID="fileUploader1" runat="server" />
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label46" runat="server" AssociatedControlId="fileUploader1" 
                                    CssClass="Textos_Azules" Text="Alto de imagen:" />
                            </td>
                            <td class="style15" style="text-align: left">
                                <asp:TextBox ID="T_Height" runat="server" CssClass="form-control" Height="18px" 
                                    style="text-align: left"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label47" runat="server" AssociatedControlId="fileUploader1" 
                                    CssClass="Textos_Azules" Text="Ancho de imagen:" />
                            </td>
                            <td class="style15" style="text-align: left">
                                <asp:TextBox ID="T_Width" runat="server" CssClass="form-control" Height="18px" 
                                    style="text-align: left"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: left">
                                &nbsp;</td>
                            <td class="style15" style="text-align: left">
                                <asp:Label ID="Nom_Imagen" runat="server" CssClass="Textos_Azules"></asp:Label>
                            </td>
                            <td>
                                <asp:HiddenField ID="Nombre_Imagen" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
          
             <asp:HiddenField ID="Movimiento" runat="server" />
        
        </div>
        
          <%--  </ContentTemplate>
        </asp:UpdatePanel>--%>
        

        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
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
