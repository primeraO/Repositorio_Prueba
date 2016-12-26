Imports System.Data
Partial Class R_0002
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


            T_Elemento_Final.Enabled = False
            T_Elemento_Inicial.Enabled = False
            Btn_Elemento_Inicial.Attributes.Add("onclick", "")
            Btn_Elemento_Inicial.Attributes.Add("style", "cursor:not-allowed")
            Btn_Elemento_Final.Attributes.Add("onclick", "")
            Btn_Elemento_Final.Attributes.Add("style", "cursor:not-allowed")

            Btn_Actividad.Attributes.Add("style", "cursor:not-allowed")
            Btn_Actividad.Attributes.Add("onclick", "")
            T_Actividad.Enabled = False
            T_Tipo_Costo_Desc.Text = Busca_Cat(Session("G"), "TIPO_COSTO", T_Tipo_Costo.Text)
        End If
        T_Fecha_Final.Attributes.Add("readonly", "true")
        T_Fecha_Inicial.Attributes.Add("readonly", "true")
        T_Art_Desc_Final.Attributes.Add("readonly", "true")
        T_Art_Desc_Inicial.Attributes.Add("readonly", "true")
        T_Tipo_Costo.Attributes.Add("readonly", "true")
        T_Ele_Desc_Inicial.Attributes.Add("readonly", "true")
        T_Ele_Desc_Final.Attributes.Add("readonly", "true")
        T_Actividad_Descripcion.Attributes.Add("readonly", "true")


        G.Elemento = T_Elemento_Inicial.Text
       

        Btn_Articulo_Final.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Articulo_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        'Btn_Elemento_Final.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=ECONOMICO&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        'Btn_Elemento_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=ECONOMICO&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        'Btn_Articulo_Final.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        'Btn_Tipo_Costo.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=TIPO_SALIDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
    End Sub

    Protected Sub T_Articulo_Inicial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo_Inicial.TextChanged
        T_Art_Desc_Inicial.Text = Busca_Cat(Session("G"), "ARTICULO", T_Articulo_Inicial.Text)
    End Sub

    Protected Sub T_Articulo_Final_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo_Final.TextChanged
        T_Art_Desc_Final.Text = Busca_Cat(Session("G"), "ARTICULO", T_Articulo_Final.Text)
    End Sub

    Protected Sub Ima_Imprimir_Click(sender As Object, e As System.EventArgs) Handles Ima_Imprimir.Click
        Pnl_Tipo_Impresion.Visible = True
        Archivo_Imprimir = ""
        Div.Attributes.Add("Class", "Bloque_Fondo")
        'Dim Script As String = ""
        'Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?Reporte=R_0002&Elem_I="
        'Script &= T_Elemento_Inicial.Text.Trim & "&Elem_F=" & T_Elemento_Final.Text.Trim & "&Act=" & T_Actividad.Text.Trim & "&TpCos="
        'Script &= T_Tipo_Costo.Text.Trim & "&Fecha_Inicio=" & T_Fecha_Inicial.Text.Trim & "&Fecha_Fin=" & T_Fecha_Final.Text.Trim & "&Art_I="
        'Script &= T_Articulo_Inicial.Text.Trim & "&Art_F=" & T_Articulo_Final.Text.Trim & "');</script>"
        'Response.Write(Script)
    End Sub

    Protected Sub Btn_Acepta_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Acepta_Imp.Click
        Dim curItem As String = RB_Tipo_Impresion.SelectedValue
        If curItem = "" Then
            Msg_Error("No se ha seleccionado una opción de Impresión")
            Exit Sub
        End If
        Pnl_Tipo_Impresion.Visible = False
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Impresora As String = ""
        If curItem = ("Vista_Previa") Then
            Impresora = ""
        Else
            Impresora &= "Impresora=S&"
        End If
        Div.Attributes.Remove("Class")
        Dim Script As String = ""
        Script = "<script type='text/javascript'>window.open('Visor_Reporte.aspx?" & Impresora & "Reporte=R_0002&Elem_I="
        Script &= T_Elemento_Inicial.Text.Trim & "&Elem_F=" & T_Elemento_Final.Text.Trim & "&Act=" & T_Actividad.Text.Trim & "&TpCos="
        Script &= T_Tipo_Costo.Text.Trim & "&Fecha_Inicio=" & T_Fecha_Inicial.Text.Trim & "&Fecha_Fin=" & T_Fecha_Final.Text.Trim & "&Art_I="
        Script &= T_Articulo_Inicial.Text.Trim & "&Art_F=" & T_Articulo_Final.Text.Trim & "');</script>"
        Response.Write(Script)

    End Sub

    Protected Sub Btn_Cancela_Imp_Click(sender As Object, e As System.EventArgs) Handles Btn_Cancela_Imp.Click
        Pnl_Tipo_Impresion.Visible = False
        Div.Attributes.Remove("Class")
    End Sub

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub


    Protected Sub T_Tipo_Costo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Tipo_Costo.TextChanged
        T_Elemento_Final.Enabled = True
        T_Elemento_Inicial.Enabled = True
        T_Elemento_Final.Text = ""
        T_Ele_Desc_Final.Text = ""
        T_Elemento_Inicial.Text = ""
        T_Ele_Desc_Inicial.Text = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select Tipo as Numero,Descripcion,Catalogo"
            G.Tsql &= " from Tipo_Salida Where Baja<>'*'"
            G.Tsql &= " and Tipo=" & Val(T_Tipo_Costo.Text)
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Dim dt_TipoSalida As New DataTable
            dt_TipoSalida.Load(G.dr)
            If G.dr.IsClosed = False Then G.dr.Close()
            Dim f As DataRow
            T_Tipo_Costo_Desc.Text = ""
            Lbl_Elemento.Text = "Elemento"
            For Each f In dt_TipoSalida.Rows
                T_Tipo_Costo_Desc.Text = f("Descripcion")
                T_Tipo_Costo_Desc.Enabled = False
                Select Case Val(f("Catalogo"))
                    Case 0
                        Lbl_Elemento.Text = "Economico"
                    Case 1
                        Lbl_Elemento.Text = "Frente"
                    Case 2
                        Lbl_Elemento.Text = "Obra"
                    Case 3
                        Lbl_Elemento.Text = "Proveedor"
                    Case 4
                        Lbl_Elemento.Text = "Solicitante"
                    Case 5
                        Lbl_Elemento.Text = "Tercero"
                    Case 6
                        Lbl_Elemento.Text = "Area"
                End Select
            Next
            Dim Tipo_Catalogo As String = Lbl_Elemento.Text.ToUpper
            Btn_Elemento_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=" + Tipo_Catalogo + "&Num=',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
            Btn_Elemento_Inicial.Attributes.Add("style", "cursor:pointer")
            Btn_Elemento_Final.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=" + Tipo_Catalogo + "&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
            Btn_Elemento_Final.Attributes.Add("style", "cursor:pointer")
            Select Case Tipo_Catalogo
                Case "FRENTE"
                    'Btn_Elemento_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=" + Tipo_Catalogo + "_SALIDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    'Btn_Elemento_Final.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=" + Tipo_Catalogo + "_SALIDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    T_Actividad.Enabled = True
                    T_Actividad_Descripcion.Enabled = True
                    G.Elemento = T_Elemento_Inicial.Text.Trim
                    Btn_Actividad.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=FRENTE_ACTIVIDAD" & "&Elemento=" & T_Elemento_Inicial.Text & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    Btn_Actividad.Attributes.Add("style", "cursor:pointer;")
                Case "AREA"
                    T_Actividad.Enabled = True
                    T_Actividad_Descripcion.Enabled = True
                    Btn_Actividad.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AREA_ACTIVIDAD" & "&Elemento=" & T_Elemento_Inicial.Text & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    Btn_Actividad.Attributes.Add("style", "cursor:pointer;")

                Case "ECONOMICO"
                    T_Actividad.Enabled = True
                    T_Actividad_Descripcion.Enabled = True
                    Btn_Actividad.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=ECONOMICO_ACTIVIDAD" & "&Elemento=" & T_Elemento_Inicial.Text & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    Btn_Actividad.Attributes.Add("style", "cursor:pointer;")

                Case "OBRA", "PROVEEDOR", "SOLICITANTE", "TERCERO"
                    'Btn_Elemento_Inicial.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=" + Tipo_Catalogo + "_SALIDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    'Btn_Elemento_Final.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=" + Tipo_Catalogo + "_SALIDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                    T_Actividad.Enabled = False
                    T_Actividad_Descripcion.Enabled = False
                    Btn_Actividad.Attributes.Add("onclick", "")
                    Btn_Actividad.Attributes.Add("style", "cursor:not-allowed")
                Case Else
                    Btn_Elemento_Inicial.Attributes.Add("onclick", "")
                    Btn_Elemento_Final.Attributes.Add("onclick", "")
            End Select
          
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Protected Sub T_Elemento_Inicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Elemento_Inicial.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        G.Elemento = T_Elemento_Inicial.Text.Trim

        ' G.Control = "ELEMENTO"
        T_Elemento_Inicial.Enabled = True
        'T_Elemento_Descripcion.Text = ""
       
        'T_Actividad.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_ActividadA.ClientID & "');")
        Dim Tipo_Catalogo As String = Lbl_Elemento.Text.ToUpper
        Select Case Tipo_Catalogo
            Case "FRENTE"
                Btn_Actividad.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=FRENTE_ACTIVIDAD" & "&Elemento=" & T_Elemento_Inicial.Text & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                Btn_Actividad.Attributes.Add("style", "cursor:pointer;")
            Case "AREA"
                Btn_Actividad.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AREA_ACTIVIDAD" & "&Elemento=" & T_Elemento_Inicial.Text & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                Btn_Actividad.Attributes.Add("style", "cursor:pointer;")
            Case "ECONOMICO"
                Btn_Actividad.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=ECONOMICO_ACTIVIDAD" & "&Elemento=" & T_Elemento_Inicial.Text & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                Btn_Actividad.Attributes.Add("style", "cursor:pointer;")
        End Select
    End Sub
End Class
