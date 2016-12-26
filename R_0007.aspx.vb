
Partial Class R_0007
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
            RB_Tipo_Impresion.SelectedValue = 0
            T_Fecha_Fin.Text = Fecha_AMD(Now)
            T_Fecha_Ini.Text = Mid(Fecha_AMD(Now), 1, 8) & "01"
        End If
        T_Linea_Desc_Final.Attributes.Add("readonly", "true")
        T_Linea_Desc_Inicial.Attributes.Add("readonly", "true")
        T_Sub_Desc_Final.Attributes.Add("readonly", "true")
        T_Sub_Desc_Inicial.Attributes.Add("readonly", "true")

        Btn_Linea_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Linea_Inicial.Attributes.Add("style", "cursor:pointer;")
        Btn_Linea_Final.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Linea_Final.Attributes.Add("style", "cursor:pointer;")

        Btn_Sublinea_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SUBLINEA&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Sublinea_Inicial.Attributes.Add("style", "cursor:pointer;")
        Btn_Sublinea_Final.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SUBLINEA&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Sublinea_Final.Attributes.Add("style", "cursor:pointer;")

    End Sub
    Protected Sub T_Linea_Inicial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Linea_Inicial.TextChanged
        T_Linea_Desc_Inicial.Text = Buscar_Descripciones("LINEA", T_Linea_Inicial.Text.Trim)
        T_Linea_Final.Focus()
    End Sub
    Protected Sub T_Linea_Final_TextChanged(sender As Object, e As System.EventArgs) Handles T_Linea_Final.TextChanged
        T_Linea_Desc_Final.Text = Buscar_Descripciones("LINEA", T_Linea_Final.Text.Trim)
        Ima_Imprimir.Focus()
    End Sub
    Protected Sub T_Sublinea_Inicial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Sublinea_Inicial.TextChanged
        T_Sub_Desc_Inicial.Text = Buscar_Descripciones("SUBLINEA", T_Sublinea_Inicial.Text)
    End Sub
    Protected Sub T_Sublinea_Final_TextChanged(sender As Object, e As System.EventArgs) Handles T_Sublinea_Final.TextChanged
        T_Sub_Desc_Final.Text = Buscar_Descripciones("SUBLINEA", T_Sublinea_Final.Text)
    End Sub
    Private Function Buscar_Descripciones(ByVal DatoBuscar As String, ByVal Valor_Busqueda As String) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Descripcion As String = ""
        Try
            Select Case (DatoBuscar)
                Case "LINEA"
                    G.Tsql = "Select Descripcion From Linea"
                    G.Tsql &= " where Linea=" & Val(Valor_Busqueda)
                    G.Tsql &= " and Baja<>'*'"
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            End Select
            G.cn.Open()
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dr.Read()
            If G.dr.HasRows Then
                Descripcion = G.dr("Descripcion")
            End If
            If G.dr.IsClosed = False Then G.dr.Close()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Descripcion
    End Function
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Ima_Imprimir_Click(sender As Object, e As System.EventArgs) Handles Ima_Imprimir.Click
        If T_Linea_Inicial.Text = "" And T_Linea_Final.Text = "" Then
            Msg_Error("Debe especificar un rango de Lineas") : Exit Sub
        End If
        RB_Tipo_Impresion.SelectedIndex = 0
        Pnl_Tipo_Impresion.Visible = True
        Archivo_Imprimir = ""
        Div.Attributes.Add("Class", "Bloque_Fondo")
        Msg_Err.Visible = False
        'Dim Script As String = ""
        'Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?Reporte=R_0007&LinI="
        'Script &= T_Linea_Inicial.Text.Trim & "&LinF=" & T_Linea_Final.Text.Trim & "');</script>"
        'Response.Write(Script)
    End Sub

    Protected Sub Btn_Acepta_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Acepta_Imp.Click
        Dim curItem As String = RB_Tipo_Impresion.SelectedValue

        If curItem = "" Then
            Msg_Error("No se ha seleccionado una opción de Impresión")
            Exit Sub
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        G.Fecha_Ini = T_Fecha_Ini.Text
        G.Fecha_Fin = T_Fecha_Fin.Text
        Pnl_Tipo_Impresion.Visible = False
        Dim Impresora As String = ""
        If curItem = "Vista_Previa" Then
            Impresora = ""
        Else
            Impresora &= "Impresora=S&"
        End If
        Div.Attributes.Remove("Class")
        Dim Script As String = ""
        Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?" & Impresora & "Reporte=R_0007&LinI="
        Script &= T_Linea_Inicial.Text.Trim & "&LinF=" & T_Linea_Final.Text.Trim & "');</script>"
        Response.Write(Script)
    End Sub

    Protected Sub Btn_Cancela_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Cancela_Imp.Click
        Pnl_Tipo_Impresion.Visible = False
        Div.Attributes.Remove("Class")
    End Sub
End Class
