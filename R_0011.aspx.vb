﻿
Partial Class R_0011
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then
            Lbl_Compañia.Text = "COMPAÑIA: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "OBRA: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "USUARIO: " & G.UsuarioReal
            Img_Logotipo.ImageUrl = "~/Trabajo/" & Session("Imagen")
            G.Imagen = Session("Imagen")
            Img_Logotipo.Style("Height") = Int(Session("Logo_Height")) & "px"
            Img_Logotipo.Style("Width") = Int(Session("Logo_Width")) & "px"
            T_Fecha_Final.Text = Fecha_AMD(Now)
            T_Fecha_Inicial.Text = Mid(Fecha_AMD(Now), 1, 8) & "01"
        End If
        T_Fecha_Final.Attributes.Add("readonly", "true")
        T_Fecha_Inicial.Attributes.Add("readonly", "true")
        T_Art_Desc_Final.Attributes.Add("readonly", "true")
        T_Art_Desc_Inicial.Attributes.Add("readonly", "true")

        Btn_Articulo_Final.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Articulo_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
    End Sub

    Protected Sub T_Articulo_Inicial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo_Inicial.TextChanged
        T_Art_Desc_Inicial.Text = Busca_Cat(Session("G"), "ARTICULO", T_Articulo_Inicial.Text)
        T_Articulo_Final.Focus()
    End Sub

    Protected Sub T_Articulo_Final_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo_Final.TextChanged
        T_Art_Desc_Final.Text = Busca_Cat(Session("G"), "ARTICULO", T_Articulo_Final.Text)
        Ima_Imprimir.Focus()
    End Sub

    Protected Sub Ima_Imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Imprimir.Click
        'If T_Articulo_Final.Text = "" And T_Articulo_Final.Text = "" Then
        '    Msg_Error("Debe indicar un rango de articulos") : Exit Sub
        'End If
        RB_Tipo_Impresion.SelectedIndex = 0
        Pnl_Tipo_Impresion.Visible = True
        Archivo_Imprimir = ""
        Div.Attributes.Add("Class", "Bloque_Fondo")
        'Dim Script As String = ""
        'Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?Reporte=R_0001&Fecha_Inicio="
        'Script &= T_Fecha_Inicial.Text.Trim & "&Fecha_Fin=" & T_Fecha_Final.Text.Trim & "&Art_I="
        'Script &= T_Articulo_Inicial.Text.Trim & "&Art_F=" & T_Articulo_Final.Text.Trim & "');</script>"
        'Response.Write(Script)
    End Sub

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Protected Sub Btn_Acepta_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Acepta_Imp.Click
        Dim curItem As String = RB_Tipo_Impresion.SelectedValue
        If curItem = "" Then
            Msg_Error("No se ha seleccionado una opción de Impresión")
            Exit Sub
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        Pnl_Tipo_Impresion.Visible = False
        Dim Impresora As String = ""
        If curItem = ("Vista_Previa") Then
            Impresora = ""
        Else
            Impresora &= "Impresora=S&"
        End If
        Div.Attributes.Remove("Class")
        Dim Script As String = ""
        Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?" & Impresora & "Reporte=R_0001&Fecha_Inicio="
        Script &= T_Fecha_Inicial.Text.Trim & "&Fecha_Fin=" & T_Fecha_Final.Text.Trim & "&Art_I="
        Script &= T_Articulo_Inicial.Text.Trim & "&Art_F=" & T_Articulo_Final.Text.Trim & "');</script>"
        Response.Write(Script)
    End Sub

    Protected Sub Btn_Cancela_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Cancela_Imp.Click
        Pnl_Tipo_Impresion.Visible = False
        Div.Attributes.Remove("Class")
    End Sub

End Class
