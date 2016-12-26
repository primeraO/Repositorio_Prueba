Imports System.Data
Partial Class Catalogo_Usuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
        Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
        Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
        Dim G As Glo = CType(Session("G"), Glo)
        Lbl_Compañia.Text = "Empresa: " & G.Empresa_Numero & " - " & G.RazonSocial
        Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
        Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal

        If G.Es_Administrador = False Then
            ChB_Activo.Visible = False
            ChB_Admn.Visible = False
            Ch_Activo.Visible = False
            Ch_Admn.Visible = False
        Else
            ChB_Activo.Visible = True
            ChB_Admn.Visible = True
            Ch_Activo.Visible = True
            Ch_Admn.Visible = True
        End If
        If IsPostBack = False Then
            If G.Empresa_Numero = 0 Or G.Sucursal = "" Then Response.Redirect("Default.aspx")
            TB_Numero.Focus()
            Session("dt") = New DataTable
            CrearCamposTabla()
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            LLenaGrid()
            Deshabilita_Registro()
            GridView1.PageSize = 1000
        End If
        DibujaSpan()
        Msg_Err.Visible = False

        TB_Numero.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & TB_Nombre.ClientID & "');")
        TB_Nombre.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & TB_Usuario.ClientID & "');")
        TB_Usuario.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")

        T_Numero.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Nombre.ClientID & "');")
        T_Nombre.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Correo.ClientID & "');")
        T_Correo.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Usuario.ClientID & "');")
        If Msg_Err.Text = "Nombre de Usuario No Disponible" Then
            T_Usuario.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Usuario.ClientID & "');")
        Else
            T_Usuario.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Clave.ClientID & "');")
        End If
        T_Clave.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Clave2.ClientID & "');")
        T_Clave2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")
        Btn_Alta.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Numero.ClientID & "');")
        Btn_Guarda.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & TB_Numero.ClientID & "');")

    End Sub

    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("UsuarioNumero", Type.GetType("System.Int64")) : Session("dt").Columns("UsuarioNumero").DefaultValue = 0
        Session("dt").Columns.Add("UsuarioReal", Type.GetType("System.String")) : Session("dt").Columns("UsuarioReal").DefaultValue = ""
        Session("dt").Columns.Add("UsuarioNombre", Type.GetType("System.String")) : Session("dt").Columns("UsuarioNombre").DefaultValue = ""
        Session("dt").Columns.Add("UsuarioMail", Type.GetType("System.String")) : Session("dt").Columns("UsuarioMail").DefaultValue = ""
        Session("dt").Columns.Add("UsuarioClave", Type.GetType("System.String")) : Session("dt").Columns("UsuarioClave").DefaultValue = ""
        Session("dt").Columns.Add("UsuarioActivo", Type.GetType("System.String")) : Session("dt").Columns("UsuarioActivo").DefaultValue = ""
        Session("dt").Columns.Add("UsuarioAdministrador", Type.GetType("System.String")) : Session("dt").Columns("UsuarioAdministrador").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("UsuarioNumero")
        Session("dt").PrimaryKey = clave
    End Sub

    Private Sub DibujaSpan()
        Dim dtspan As New DataTable
        dtspan = Session("dt").Copy
        If Session("dt").Rows.Count = 0 Then
            Dim f As DataRow = dtspan.NewRow()
            dtspan.Rows.Add(f)
            GridView1.DataSource = dtspan
            GridView1.DataBind()
            Dim TotalColumnas As Integer = GridView1.Rows(0).Cells.Count
            GridView1.Rows(0).Cells.Clear()
            GridView1.Rows(0).Cells.Add(New TableCell)
            GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumnas
            GridView1.Rows(0).Cells(0).Text = ""
        End If
    End Sub

    Private Sub LLenaGrid()
        Session("dt") = Llena_DataTable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
    Private Function Llena_DataTable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Session("dt").Rows.Clear()
        Try
            G.cn.Open()
            G.Tsql = "Select UsuarioNombre,UsuarioReal,UsuarioMail,UsuarioClave,UsuarioNumero,UsuarioActivo,UsuarioAdministrador"
            G.Tsql &= " from Usuarios a where "
            If ChB_Baja.Checked Then
                G.Tsql &= " Baja='*'"
            Else
                G.Tsql &= " Baja<>'*'"
            End If
            If ChB_Activo.Checked Then
                G.Tsql &= " and UsuarioActivo='S'"
            End If
            If ChB_Admn.Checked Then
                G.Tsql &= " and UsuarioAdministrador='S'"
            End If
            If TB_Nombre.Text.Trim <> "" Then
                G.Tsql &= " and UsuarioReal like '%" & TB_Nombre.Text & "%'"
            End If
            If TB_Usuario.Text.Trim <> "" Then
                G.Tsql &= " and UsuarioNombre like '%" & TB_Nombre.Text & "%'"
            End If
            If Val(TB_Numero.Text) > 0 Then
                G.Tsql &= " and UsuarioNumero=" & Val(TB_Numero.Text)
            End If
            If G.Es_Administrador = False Then
                G.Tsql &= " and UsuarioNumero=" & G.UsuarioNumero
            End If
            G.Tsql &= " Order BY UsuarioNumero"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function

    Private Sub Habilita_Registro()
        Pnl_Busqueda.Enabled = False
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Enabled = True
        Pnl_Registro.Visible = True
        Panel_Grid.Visible = False
        Tab_Enc_Grid.Visible = False

        Btn_Busca.Enabled = False
        Btn_Alta.Enabled = False
        Btn_Guarda.Enabled = True
        Btn_Restaura.Enabled = True

        Btn_Busca.CssClass = "Btn_Rojo"
        Btn_Alta.CssClass = "Btn_Rojo"
        Btn_Guarda.CssClass = "Btn_Azul"
        Btn_Restaura.CssClass = "Btn_Azul"
        GridView1.Enabled = False
    End Sub

    Private Sub Deshabilita_Registro()
        Pnl_Busqueda.Enabled = True
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Enabled = False
        Pnl_Registro.Visible = False
        Panel_Grid.Visible = True
        Tab_Enc_Grid.Visible = True


        Btn_Busca.Enabled = True
        Btn_Alta.Enabled = True
        Btn_Guarda.Enabled = False
        Btn_Restaura.Enabled = False

        Btn_Busca.CssClass = "Btn_Azul"
        Btn_Alta.CssClass = "Btn_Azul"
        Btn_Guarda.CssClass = "Btn_Rojo"
        Btn_Restaura.CssClass = "Btn_Rojo"
        GridView1.Enabled = True
    End Sub
    Private Sub Limpiar()
        TB_Nombre.Text = ""
        TB_Numero.Text = ""
        '
        T_Numero.Text = ""
        T_Nombre.Text = ""
        T_Clave.Text = ""
        T_Usuario.Text = ""
        T_Correo.Text = ""
    End Sub

    Protected Sub Btn_Alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Alta.Click
        Dim G As Glo = CType(Session("G"), Glo)
        If G.Es_Administrador = False Then
            Msg_Error("Es necesario ser administrador, para dar de alta usuarios") : Exit Sub
        End If
        Movimiento.Value = "Alta"
        Habilita_Registro()
        Lbl_Clave3.Visible = False
        T_Nue_Cve.Visible = False
        Limpiar()
        NumeroUsuario()
        T_Numero.Enabled = False
        T_Nombre.Focus()
    End Sub

    Protected Sub Btn_Busca_Click(sender As Object, e As System.EventArgs) Handles Btn_Busca.Click
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub ChB_Activo_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChB_Activo.CheckedChanged
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub ChB_Admn_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChB_Admn.CheckedChanged
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub ChB_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChB_Baja.CheckedChanged
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        Limpiar()
        T_Clave.Visible = True
        T_Clave2.Visible = True
        Lbl_Clave1.Visible = True
        Lbl_Clave2.Visible = True
        Deshabilita_Registro()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub Btn_Salir_Click(sender As Object, e As System.EventArgs) Handles Btn_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Private Sub NumeroUsuario()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select Max(UsuarioNumero) from Usuarios "
            G.cn.Open()
            G.com.CommandText = G.Tsql
            If Not IsDBNull(G.com.ExecuteScalar) Then
                If Val(G.com.ExecuteScalar) > 0 Then
                    T_Numero.Text = Val(G.com.ExecuteScalar) + 1
                Else
                    T_Numero.Text = ""
                End If
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Btn_Guarda_Click(sender As Object, e As System.EventArgs) Handles Btn_Guarda.Click

        Dim G As Glo = CType(Session("G"), Glo)
        If Validar() = False Then Exit Sub
        G.Tsql = ""
        Try
            G.cn.Open()
            If Movimiento.Value = "Cambio" And T_Nue_Cve.Text.Trim <> "" Then
                G.Tsql = "Select UsuarioClave from Usuarios Where UsuarioNumero=" & Val(T_Numero.Text)
                G.com.CommandText = G.Tsql
                Dim UsuarioClave As String = G.com.ExecuteScalar.ToString
                If UsuarioClave <> T_Clave.Text.Trim Then
                    Msg_Error("Clave inválida") : Exit Sub
                End If
            End If

            If Movimiento.Value = "Alta" Then
                G.Tsql = "Insert into Usuarios(UsuarioNumero,UsuarioClave) values("
                G.Tsql &= Val(T_Numero.Text) & ","
                G.Tsql &= Pone_Apos(T_Clave.Text) & ")" & Chr(13)
            End If
            G.Tsql &= " Update Usuarios set"
            G.Tsql &= " UsuarioNombre=" & Pone_Apos(UCase(T_Usuario.Text))
            If T_Nue_Cve.Text.Trim <> "" Then
                G.Tsql &= ",UsuarioClave=" & Pone_Apos(T_Nue_Cve.Text)
            End If
            G.Tsql &= ",UsuarioReal=" & Pone_Apos(UCase(T_Nombre.Text))
            If Ch_Activo.Checked Then
                G.Tsql &= ",UsuarioActivo='S'"
            Else
                G.Tsql &= ",UsuarioActivo='N'"
            End If
            If Ch_Admn.Checked Then
                G.Tsql &= ",UsuarioAdministrador='S'"
            Else
                G.Tsql &= ",UsuarioAdministrador='N'"
            End If
            G.Tsql &= ",UsuarioMail=" & Pone_Apos(T_Correo.Text)
            If Movimiento.Value = "Baja" Then
                G.Tsql &= ",Baja='*'"
            Else
                G.Tsql &= ",Baja=''"
            End If
            G.Tsql &= " Where  UsuarioNumero=" & Val(T_Numero.Text)

            G.com.CommandText = G.Tsql
            G.com.ExecuteNonQuery()
            Limpiar()
            Deshabilita_Registro()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
            LLenaGrid()
            T_Clave.Visible = True
            T_Clave2.Visible = True
            Lbl_Clave1.Visible = True
            Lbl_Clave2.Visible = True
        End Try
    End Sub
    Private Function Validar() As Boolean
        Validar = False
        T_Usuario_TextChanged(Nothing, Nothing)
        If T_Usuario.Text.Trim = "" Then Msg_Error("..... Nombre de Usuario Inválido .....") : Exit Function
        If Msg_Err.Text = "..... Nombre de Usuario No Disponible ....." And Movimiento.Value = "Alta" Then Validar = False : Exit Function
        If T_Nombre.Text.Trim = "" Then Msg_Error("Es necesario Escribir el Nombre Real del Usuario Inválido") : Exit Function
        If T_Clave.Text.Trim = "" And Movimiento.Value = "Alta" Then Msg_Error("Es necesario Escribir una Clave de Usuario") : Exit Function
        If T_Clave2.Text.Trim = "" And Movimiento.Value = "Alta" Then Msg_Error("Debe Confirmar la Clave") : Exit Function
        If Movimiento.Value = "Alta" Then
            If T_Clave.Text.Trim <> T_Clave2.Text.Trim Then Msg_Error("Las Claves No Coinciden") : Exit Function
        End If
        If Movimiento.Value = "Cambio" And T_Nue_Cve.Text.Trim <> "" Then
            If T_Nue_Cve.Text.Trim <> T_Clave2.Text.Trim Then Msg_Error("La nueva clave, no coincide con la clave confirma") : Exit Function
        End If
        Return True
    End Function

    Protected Sub T_Usuario_TextChanged(sender As Object, e As System.EventArgs) Handles T_Usuario.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tssql As String = ""
        Try
            Tssql = "Select Count(UsuarioNombre) from Usuarios "
            Tssql &= " Where UsuarioNombre=" & Pone_Apos(T_Usuario.Text)
            G.cn.Open()
            G.com.CommandText = Tssql
            If Not IsDBNull(G.com.ExecuteScalar) Then
                If Val(G.com.ExecuteScalar) > 0 Then
                    Msg_Err.Text = "..... Nombre de Usuario No Disponible ....."
                End If
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(0).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Clave.Visible = True
                T_Clave2.Visible = True
                Lbl_Clave1.Visible = True
                Lbl_Clave2.Visible = True
                Lbl_Clave3.Visible = True
                T_Nue_Cve.Visible = True
                T_Clave.TextMode = TextBoxMode.SingleLine
                T_Clave2.TextMode = TextBoxMode.SingleLine
                T_Nue_Cve.TextMode = TextBoxMode.SingleLine
                T_Nombre.Text = AString(f("UsuarioReal"))
                T_Usuario.Text = AString(f("UsuarioNombre"))
                T_Correo.Text = AString(f("UsuarioMail"))
                T_Clave.Text = AString(f("UsuarioClave"))
                T_Clave2.Text = AString(f("UsuarioClave"))
                T_Clave.TextMode = TextBoxMode.Password
                T_Clave2.TextMode = TextBoxMode.Password
                T_Nue_Cve.TextMode = TextBoxMode.Password
                T_Numero.Text = Val(f("UsuarioNumero"))
                If f("UsuarioActivo") = "S" Then
                    Ch_Activo.Checked = True
                Else
                    Ch_Activo.Checked = False
                End If
                If f("UsuarioAdministrador") = "S" Then
                    Ch_Admn.Checked = True
                Else
                    Ch_Admn.Checked = False
                End If
                Habilita_Registro()
            End If
            If e.CommandName.Equals("Cambio") Then
                Movimiento.Value = "Cambio"
                T_Numero.Enabled = False
                T_Nombre.Focus()
            End If
            If e.CommandName.Equals("Baja") Then
                Movimiento.Value = "Baja"
                Pnl_Registro.Enabled = False
            End If
        End If
    End Sub
End Class
