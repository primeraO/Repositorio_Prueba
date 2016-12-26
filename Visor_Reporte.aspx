<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visor_Reporte.aspx.vb" Inherits="Visor_Reporte" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body:nth-of-type(1) img[src*="Blank.gif"]{display:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; height: 800px">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Arial" 
            Font-Size="8pt" Height="1000px" InteractiveDeviceInfos="(Colección)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" 
            DocumentMapWidth="0%">
            <LocalReport ReportPath="R_Requisicion.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Requisiciones" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            TypeName="RequisicionesTableAdapters."></asp:ObjectDataSource>
      </div>
    </form>
</body>
</html>
