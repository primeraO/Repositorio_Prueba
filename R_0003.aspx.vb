
Partial Class R_0003
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
        T_Prov_Nom_Final.Attributes.Add("readonly", "true")
        T_Prov_Nom_Inicial.Attributes.Add("readonly", "true")

        Btn_Proveedor_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Proveedor_Inicial.Attributes.Add("style", "cursor:pointer;")
        Btn_Proveedor_Final.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Proveedor_Final.Attributes.Add("style", "cursor:pointer;")

        Btn_Articulo_Final.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Articulo_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
    End Sub

    Protected Sub T_Proveedor_Inicial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Proveedor_Inicial.TextChanged
        'Busca_Proveedor(Val(T_Proveedor_Inicial.Text), 1)
        'Dim G As Glo = CType(Session("G"), Glo)
        'T_Prov_Nom_Inicial.Text = G.Nom1
        T_Prov_Nom_Inicial.Text = Buscar_Descripciones("PROVEEDOR", T_Proveedor_Inicial.Text.Trim)
        T_Prov_RFC_Ini.Text = Buscar_Descripciones("PROVEEDOR_RFC", T_Proveedor_Inicial.Text.Trim)
    End Sub
    Protected Sub T_Proveedor_Final_TextChanged(sender As Object, e As System.EventArgs) Handles T_Proveedor_Final.TextChanged
        'Busca_Proveedor(Val(T_Proveedor_Final.Text), 2)
        'Dim G As Glo = CType(Session("G"), Glo)
        'T_Prov_Nom_Final.Text = G.Nom2
        T_Prov_Nom_Final.Text = Buscar_Descripciones("PROVEEDOR", T_Proveedor_Final.Text.Trim)
        T_Prov_RFC_Fin.Text = Buscar_Descripciones("PROVEEDOR_RFC", T_Proveedor_Final.Text.Trim)

    End Sub
    Protected Sub T_Articulo_Inicial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo_Inicial.TextChanged
        T_Art_Desc_Inicial.Text = Buscar_Descripciones("ARTICULO", T_Articulo_Inicial.Text)
    End Sub
    Protected Sub T_Articulo_Final_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo_Final.TextChanged
        T_Art_Desc_Inicial.Text = Buscar_Descripciones("ARTICULO", T_Articulo_Final.Text)
    End Sub
    Private Function Buscar_Descripciones(ByVal DatoBuscar As String, ByVal Valor_Busqueda As String) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Descripcion As String = ""
        Try
            Select Case (DatoBuscar)
                Case "PROVEEDOR"
                    G.Tsql = "Select Razon_Social As Descripcion From Proveedor"
                    G.Tsql &= " where Numero=" & Val(Valor_Busqueda)
                    G.Tsql &= " and Baja<>'*'"
                Case "PROVEEDOR_RFC"
                    G.Tsql = "Select Rfc As Descripcion From Proveedor"
                    G.Tsql &= " where Numero=" & Val(Valor_Busqueda)
                    G.Tsql &= " and Baja<>'*'"
                Case "ARTICULO"
                    G.Tsql = "Select Art_Descripcion as Descripcion"
                    G.Tsql &= " from Articulos Where Baja<>'*' "
                    G.Tsql &= " and Numero=" & Pone_Apos(Valor_Busqueda)
                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " Order by Numero"
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
        Pnl_Tipo_Impresion.Visible = True
        Archivo_Imprimir = ""
        Div.Attributes.Add("Class", "Bloque_Fondo")
        'Dim Script As String = ""
        'Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?Reporte=R_0003&Fecha_Inicio="
        'Script &= T_Fecha_Inicial.Text.Trim & "&Fecha_Fin=" & T_Fecha_Final.Text.Trim & "&Art_I="
        'Script &= T_Articulo_Inicial.Text.Trim & "&Art_F=" & T_Articulo_Final.Text.Trim & "&Pro_I="
        'Script &= T_Proveedor_Inicial.Text.Trim & "&Pro_F=" & T_Proveedor_Final.Text.Trim & "');</script>"
        'Response.Write(Script)
    End Sub

    Protected Sub Btn_Acepta_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Acepta_Imp.Click
        Dim curItem As String = RB_Tipo_Impresion.SelectedValue
        Dim G As Glo = CType(Session("G"), Glo)
        If curItem = "" Then
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
        Dim Script As String = ""
        Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?" & Impresora & "Reporte=R_0003&Fecha_Inicio="
        Script &= T_Fecha_Inicial.Text.Trim & "&Fecha_Fin=" & T_Fecha_Final.Text.Trim & "&Art_I="
        Script &= T_Articulo_Inicial.Text.Trim & "&Art_F=" & T_Articulo_Final.Text.Trim & "&Pro_I="
        Script &= T_Proveedor_Inicial.Text.Trim & "&Pro_F=" & T_Proveedor_Final.Text.Trim & "');</script>"
        Response.Write(Script)
    End Sub

    Protected Sub Btn_Cancela_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Cancela_Imp.Click
        Pnl_Tipo_Impresion.Visible = False
        Div.Attributes.Remove("Class")
    End Sub
End Class
