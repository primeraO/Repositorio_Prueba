
Partial Class R_Informe_Mensual
    Inherits System.Web.UI.Page

    Protected Sub Ima_Imprimir_Click(sender As Object, e As System.EventArgs) Handles Ima_Imprimir.Click
        If Not IsDate(T_Fecha_Inicio.Text) Then
            Msg_Error("La Fecha de Inicio es incorrecta") : Exit Sub
        End If
        If Not IsDate(T_Fecha_Fin.Text) Then
            Msg_Error("La Fecha Fin es incorrecta") : Exit Sub
        End If
        Pnl_Tipo_Impresion.Visible = True
        Archivo_Imprimir = ""
        Div.Attributes.Add("Class", "Bloque_Fondo")
        'Response.Write("<script type='text/javascript'>window.open('Visor_Reporte.aspx?Reporte=R_Informe_Mensual&Fecha_Inicio=" & T_Fecha_Inicio.Text.Trim & "&Fecha_Fin=" & T_Fecha_Fin.Text.Trim & "&Detalle=" & CB_Detalle.Checked & "');</script>")
        'Response.Redirect("~/Visor_Reporte.aspx?Reporte=R_Informe_Mensual")
    End Sub

    Protected Sub Btn_Acepta_Imp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Acepta_Imp.Click
        Dim curItem As String = RB_Tipo_Impresion.SelectedItem.Value
        If curItem Is Nothing Then
            Msg_Error("No se ha seleccionado una opción de Impresión")
            Exit Sub
        End If
        Pnl_Tipo_Impresion.Visible = False
        Dim Impresora As String = ""
        If curItem = ("Vista_Previa") Then
            Impresora = ""
        Else
            Impresora &= "Impresora=S&"
        End If
        Div.Attributes.Remove("Class")
        Response.Write("<script type='text/javascript'>window.open('Visor_Reporte.aspx?" & Impresora & "Reporte=R_Informe_Mensual&Fecha_Inicio=" & T_Fecha_Inicio.Text.Trim & _
                       "&Fecha_Fin=" & T_Fecha_Fin.Text.Trim & "&Detalle=" & CB_Detalle.Checked & "');</script>")

    End Sub

    Protected Sub Btn_Cancela_Imp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Cancela_Imp.Click
        Pnl_Tipo_Impresion.Visible = False
        Div.Attributes.Remove("Class")
    End Sub

    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            T_Fecha_Inicio.Text = Mid(Fecha_AMD(Now), 1, 8) & "01"
            T_Fecha_Fin.Text = Fecha_AMD(Now)
        End If
        Msg_Err.Visible = False
    End Sub

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub
End Class
