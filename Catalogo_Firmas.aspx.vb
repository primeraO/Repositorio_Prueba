
Partial Class Catalogo_Firmas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "USuario: " & G.UsuarioReal
            Img_Logotipo.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Img_Logotipo.Style("Height") = Int(Session("Logo_Height")) & "px"
            Img_Logotipo.Style("Width") = Int(Session("Logo_Width")) & "px"
            Todo_Disponible()
            Buscar_Info()
            Buscar_Descripciones("Autoriza_Superintendente", Val(T_Superintendente.Text))
            Buscar_Descripciones("Autoriza_Almacen", Val(T_Almacen.Text))
            Buscar_Descripciones("Autoriza_Administracion", Val(T_Administracion.Text))
            Buscar_Descripciones("Autoriza_Gerente", Val(T_Gerente.Text))
        End If

        T_Superintendente_Descripcion.Attributes.Add("readonly", "true")
        T_Administracion_Descripcion.Attributes.Add("readonly", "true")
        T_Almacen_Descripcion.Attributes.Add("readonly", "true")
        T_Gerente_Descripcion.Attributes.Add("readonly", "true")

        T_Superintendente.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Superintendente.ClientID & "');")
        T_Administracion.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Administracion.ClientID & "');")
        T_Almacen.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Almacen.ClientID & "');")
        T_Gerente.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Gerente.ClientID & "');")

        T_RequisicionP1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Superintendente.ClientID & "');")
        T_Superintendente.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_RequisicionP2.ClientID & "');")
        T_RequisicionP2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Almacen.ClientID & "');")
        T_Almacen.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_RequisicionP3.ClientID & "');")
        T_RequisicionP3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Administracion.ClientID & "');")
        T_Administracion.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_RequisicionP4.ClientID & "');")
        T_RequisicionP4.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Gerente.ClientID & "');")
        T_Gerente.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_ComprasP1.ClientID & "');")
        T_ComprasP1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_ComprasP2.ClientID & "');")
        T_ComprasP2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_ComprasP3.ClientID & "');")
        T_ComprasP4.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")

        Btn_Superintendente.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AUTORIZA1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Almacen.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AUTORIZA2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Administracion.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AUTORIZA3',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Gerente.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AUTORIZA4',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Private Sub Buscar_Info()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            'Puestos en Requisicion
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=36"
            G.Glo_RequisicionP1 = AString(G.com.ExecuteScalar)
            T_RequisicionP1.Text = G.Glo_RequisicionP1
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=37"
            G.Glo_RequisicionP2 = AString(G.com.ExecuteScalar)
            T_RequisicionP2.Text = G.Glo_RequisicionP2
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=38"
            G.Glo_RequisicionP3 = AString(G.com.ExecuteScalar)
            T_RequisicionP3.Text = G.Glo_RequisicionP3
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=39"
            G.Glo_RequisicionP4 = AString(G.com.ExecuteScalar)
            T_RequisicionP4.Text = G.Glo_RequisicionP4

            G.com.CommandText = "Select valor_configuracion from Configuracion Where Numero_Configuracion=36"
            T_Superintendente.Text = AString(G.com.ExecuteScalar)
            G.com.CommandText = "Select valor_configuracion from Configuracion Where Numero_Configuracion=37"
            T_Almacen.Text = AString(G.com.ExecuteScalar)
            G.com.CommandText = "Select valor_configuracion from Configuracion Where Numero_Configuracion=38"
            T_Administracion.Text = AString(G.com.ExecuteScalar)
            G.com.CommandText = "Select valor_configuracion from Configuracion Where Numero_Configuracion=39"
            T_Gerente.Text = AString(G.com.ExecuteScalar)
            'T_Superintendente_Descripcion.Text = Buscar_Cat("AUTORIZA", Val(Te_Superintendente.Text))
            'T_Almacen_Descripcion.Text = Busca_Cat("AUTORIZA", Val(Te_Almacen.Text))
            'T_Administracion_Descripcion.Text = Busca_Cat("AUTORIZA", Val(Te_Administracion.Text))
            'T_Gerente_Descripcion.Text = Busca_Cat("AUTORIZA", Val(Te_Gerente.Text))
            'Puestos en Compras
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=40"
            G.Glo_ComprasP1 = AString(G.com.ExecuteScalar)
            T_ComprasP1.Text = G.Glo_ComprasP1
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=41"
            G.Glo_ComprasP2 = AString(G.com.ExecuteScalar)
            T_ComprasP2.Text = G.Glo_ComprasP2
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=42"
            G.Glo_ComprasP3 = AString(G.com.ExecuteScalar)
            T_ComprasP3.Text = G.Glo_ComprasP3
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=43"
            G.Glo_ComprasP4 = AString(G.com.ExecuteScalar)
            T_ComprasP4.Text = G.Glo_ComprasP4
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
            Buscar_Descripciones("Autoriza_Superintendente", Val(T_Superintendente.Text))
            Buscar_Descripciones("Autoriza_Almacen", Val(T_Almacen.Text))
            Buscar_Descripciones("Autoriza_Administracion", Val(T_Administracion.Text))
            Buscar_Descripciones("Autoriza_Gerente", Val(T_Gerente.Text))
        End Try
    End Sub
    Private Sub Buscar_Descripciones(ByVal DatoBuscar As String, ByVal Valor_Busqueda As String)
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            Select Case (DatoBuscar)
                Case "Autoriza_Superintendente", "Autoriza_Administracion", "Autoriza_Gerente", "Autoriza_Almacen"
                    G.Tsql = "Select Nombre as Descripcion From Autorizacion_Claves"
                    G.Tsql &= " Where Numero=" & Val(Valor_Busqueda)
                    G.Tsql &= " and Baja<>'*'"
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            End Select
            G.cn.Open()
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dr.Read()
            Dim Descripcion As String = ""
            If G.dr.HasRows Then
                Descripcion = G.dr("Descripcion")
            End If
            Select Case (DatoBuscar)
                Case "Autoriza_Superintendente"
                    T_Superintendente_Descripcion.Text = Descripcion
                Case "Autoriza_Administracion"
                    T_Administracion_Descripcion.Text = Descripcion
                Case "Autoriza_Gerente"
                    T_Gerente_Descripcion.Text = Descripcion
                Case "Autoriza_Almacen"
                    T_Almacen_Descripcion.Text = Descripcion
            End Select
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Private Sub Todo_Disponible()
        Btn_Cambio.Enabled = True
        Btn_Cambio.CssClass = "Btn_Azul"
        Btn_Restaura.Enabled = False
        Btn_Restaura.CssClass = "Btn_Rojo"
        Btn_Guarda.Enabled = False
        Btn_Guarda.CssClass = "Btn_Rojo"
        P_Campos_Requisicion.Enabled = False
        P_Campos_Compras.Enabled = False
    End Sub
    Private Sub Todo_NoDisponible()
        Btn_Cambio.Enabled = False
        Btn_Cambio.CssClass = "Btn_Rojo"
        Btn_Restaura.Enabled = True
        Btn_Restaura.CssClass = "Btn_Azul"
        Btn_Guarda.Enabled = True
        Btn_Guarda.CssClass = "Btn_Azul"
        P_Campos_Requisicion.Enabled = True
        P_Campos_Compras.Enabled = True
        T_RequisicionP1.Focus()
    End Sub

    Protected Sub Btn_Cambio_Click(sender As Object, e As System.EventArgs) Handles Btn_Cambio.Click
        Todo_NoDisponible()
    End Sub

    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        Buscar_Info()
        Todo_Disponible()
    End Sub

    Protected Sub T_Superintendente_TextChanged(sender As Object, e As System.EventArgs) Handles T_Superintendente.TextChanged
        Buscar_Descripciones("Autoriza_Superintendente", Val(T_Superintendente.Text))
    End Sub

    Protected Sub T_Almacen_TextChanged(sender As Object, e As System.EventArgs) Handles T_Almacen.TextChanged
        Buscar_Descripciones("Autoriza_Almacen", Val(T_Almacen.Text))
    End Sub

    Protected Sub T_Administracion_TextChanged(sender As Object, e As System.EventArgs) Handles T_Administracion.TextChanged
        Buscar_Descripciones("Autoriza_Administracion", Val(T_Administracion.Text))
    End Sub

    Protected Sub T_Gerente_TextChanged(sender As Object, e As System.EventArgs) Handles T_Gerente.TextChanged
        Buscar_Descripciones("Autoriza_Gerente", Val(T_Gerente.Text))
    End Sub

    Protected Sub Btn_Guarda_Click(sender As Object, e As System.EventArgs) Handles Btn_Guarda.Click
        Dim nl As String = Environment.NewLine
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            'Puestos en Requisicion
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=36"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion,Valor_Configuracion) values (36," & Pone_Apos(T_RequisicionP1.Text.Trim) & "," & Val(T_Superintendente.Text) & ")" & nl
            Else
                G.Tsql = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_RequisicionP1.Text.Trim) & ",Valor_Configuracion=" & Pone_Apos(T_Superintendente.Text)
                G.Tsql &= " Where Numero_Configuracion=36" & nl
                G.com.CommandText = G.Tsql
            End If
            G.com.ExecuteNonQuery()

            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=37"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion,Valor_Configuracion) values (37," & Pone_Apos(T_RequisicionP2.Text.Trim) & "," & Val(T_Almacen.Text) & ")" & nl
            Else
                G.Tsql = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_RequisicionP2.Text.Trim) & ",Valor_Configuracion=" & Pone_Apos(T_Almacen.Text)
                G.Tsql &= " Where Numero_Configuracion=37" & nl
                G.com.CommandText = G.Tsql
            End If
            G.com.ExecuteNonQuery()

            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=38"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion,Valor_Configuracion) values (38," & Pone_Apos(T_RequisicionP3.Text.Trim) & "," & Val(T_Administracion.Text) & ")" & nl
            Else
                G.Tsql = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_RequisicionP3.Text.Trim) & ",Valor_Configuracion=" & Pone_Apos(T_Administracion.Text)
                G.Tsql &= " Where Numero_Configuracion=38" & nl
                G.com.CommandText = G.Tsql
            End If
            G.com.ExecuteNonQuery()

            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=39"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion,Valor_Configuracion) values (39," & Pone_Apos(T_RequisicionP4.Text.Trim) & "," & Val(T_Gerente.Text) & ")" & nl
            Else
                G.Tsql = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_RequisicionP4.Text.Trim) & ",Valor_Configuracion=" & Pone_Apos(T_Gerente.Text)
                G.Tsql &= " Where Numero_Configuracion=39" & nl
                G.com.CommandText = G.Tsql
            End If
            G.com.ExecuteNonQuery()

            'Puestos en Compras
            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=40"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion) values (40," & Pone_Apos(T_ComprasP1.Text.Trim) & ")" & nl
            Else
                G.com.CommandText = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_ComprasP1.Text.Trim) & " Where Numero_Configuracion=40" & nl
            End If
            G.com.ExecuteNonQuery()

            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=41"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion) values (41," & Pone_Apos(T_ComprasP2.Text.Trim) & ")" & nl
            Else
                G.com.CommandText = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_ComprasP2.Text.Trim) & " Where Numero_Configuracion=41" & nl
            End If
            G.com.ExecuteNonQuery()

            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=42"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion) values (42," & Pone_Apos(T_ComprasP3.Text.Trim) & ");"
            Else
                G.com.CommandText = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_ComprasP3.Text.Trim) & " Where Numero_Configuracion=42;"
            End If
            G.com.ExecuteNonQuery()

            G.com.CommandText = "Select Texto_Configuracion from Configuracion Where Numero_Configuracion=43"
            If G.com.ExecuteScalar Is Nothing Then
                G.com.CommandText = "Insert into Configuracion (Numero_Configuracion,Texto_Configuracion) values (43," & Pone_Apos(T_ComprasP4.Text.Trim) & ");"
            Else
                G.com.CommandText = "Update Configuracion set Texto_Configuracion=" & Pone_Apos(T_ComprasP4.Text.Trim) & " Where Numero_Configuracion=43;"
            End If
            G.com.ExecuteNonQuery()
            Todo_Disponible()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Btn_Salir_Click(sender As Object, e As System.EventArgs) Handles Btn_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub
End Class
