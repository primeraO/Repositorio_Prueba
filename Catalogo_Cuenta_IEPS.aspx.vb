Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Cuenta_IEPS
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Session("dt") = New DataTable
            CrearCamposTabla()
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            DesHabilita()
            LLenaGrid()

            Try
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"

            Catch ex As Exception

            End Try

        End If
        Msg_Err.Visible = False
        DibujaSpan()
        TB_Año.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Año.ClientID & "');")
        T_Año.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Año.ClientID & "');")
        T_Magna.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Magna.ClientID & "');")
        T_Premium.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Premium.ClientID & "');")
        T_Diesel.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Diesel.ClientID & "');")
        TB_Año.Attributes.Add("onfocus", "this.select();")

        T_Año.Attributes.Add("onfocus", "this.select();")
        T_Magna.Attributes.Add("onfocus", "this.select();")
        T_Premium.Attributes.Add("onfocus", "this.select();")
        T_Diesel.Attributes.Add("onfocus", "this.select();")

        T_Magna.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Magna.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Premium.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Premium.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Diesel.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Diesel.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
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
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        End If
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Private Sub CrearCamposTabla()
        'Tabla Area'
        Session("dt").Columns.Add("Año", Type.GetType("System.Int64")) : Session("dt").Columns("Año").DefaultValue = 0
        Session("dt").Columns.Add("Mes", Type.GetType("System.String")) : Session("dt").Columns("Mes").DefaultValue = ""
        Session("dt").Columns.Add("Magna", Type.GetType("System.Double")) : Session("dt").Columns("Magna").DefaultValue = 0
        Session("dt").Columns.Add("Premium", Type.GetType("System.Double")) : Session("dt").Columns("Premium").DefaultValue = 0
        Session("dt").Columns.Add("Diesel", Type.GetType("System.Double")) : Session("dt").Columns("Diesel").DefaultValue = 0

        Dim clave(1) As DataColumn
        clave(0) = Session("dt").Columns("Año")
        clave(1) = Session("dt").Columns("Mes")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Año.Enabled = False
        T_Mes.Enabled = False
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        GridView1.Enabled = True
        TB_Año.Enabled = True
        TB_Mes.Enabled = True

    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False

        T_Año.Enabled = True
        T_Mes.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        GridView1.Enabled = False
        TB_Año.Enabled = False
        TB_Mes.Enabled = False


    End Sub
    Private Sub LLenaGrid()
        Session("dt") = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
    Private Function LLena_Datatable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            Session("dt").Rows.Clear()
            G.cn.Open()
            G.Tsql = "Select Año,Mes,Magna,Premium,Diesel from Cuota_IEPS "
            If Val(TB_Año.Text.Trim) <> 0 Then
                G.Tsql &= Es_Where(G.Tsql)
                G.Tsql &= " Año =" & Val(TB_Año.Text.Trim)
            End If
            If Val(TB_Mes.SelectedValue) <> 0 Then
                G.Tsql &= Es_Where(G.Tsql)
                G.Tsql &= " Mes=" & Val(TB_Mes.SelectedValue)
            End If
            G.Tsql &= " Order by Año,Mes"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Dim dt_datos As New DataTable
            dt_datos.Load(G.dr)
            For Each f As DataRow In dt_datos.Rows
                Dim nf As DataRow = Session("dt").NewRow
                nf("Año") = f("Año")
                nf("Mes") = Mes_Nombre(f("Mes"))
                nf("Magna") = f("Magna")
                nf("Premium") = f("Premium")
                nf("Diesel") = f("Diesel")
                Session("dt").Rows.add(nf)
            Next
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function
    Private Sub LimpiaCampos()
        T_Año.Text = ""
        T_Magna.Text = ""
        T_Premium.Text = ""
        T_Diesel.Text = ""
        T_Mes.SelectedValue = 0
    End Sub
    'Private Function Siguiente() As Integer
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Siguiente = 0
    '    Try
    '        G.cn.Open()
    '        G.Tsql = "Select Max(Area) from Area Where Cia=" & Val(Session("Cia"))
    '        G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
    '        G.com.CommandText = G.Tsql
    '        Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
    '    Catch ex As Exception
    '        Msg_Error(ex.Message.ToString)
    '    Finally
    '        G.cn.Close()
    '    End Try
    'End Function
    Private Function validar() As Boolean
        validar = False
        If Val(T_Año.Text.Trim) = 0 Then
            Msg_Error("Año invalido") : Exit Function
        End If
        If T_Mes.SelectedValue = 0 Then
            Msg_Error("Mes inválido") : Exit Function
        End If
        Return True
    End Function

    Protected Sub Ima_Alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Alta.Click
        Habilita()

        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Año.Text = Mid(Fecha_AMD(Now), 1, 4)
        T_Mes.Focus()
        GridView1.Enabled = False
        Pnl_Registro.Enabled = True
    End Sub
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Mes As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Año") = Numero
        f("Mes") = Mes
        f("Magna") = T_Magna.Text
        f("Premium") = T_Premium.Text
        f("Diesel") = T_Diesel.Text
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Mes As String)
        Dim clave(1) As String
        clave(0) = Numero
        clave(1) = Mes
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Magna") = T_Magna.Text
            f("Premium") = T_Premium.Text
            f("Diesel") = T_Diesel.Text
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal Numero As Integer)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                'T_Año.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select * from Cuota_IEPS where Año=" & Val(T_Año.Text) & " and Mes=" & Val(T_Mes.SelectedValue)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Mes y año registrados") : Exit Sub
                End If
                G.Tsql = "Insert into Cuota_IEPS (Año,Mes,Magna,Premium,Diesel) values ("
                G.Tsql &= Val(T_Año.Text.Trim)
                G.Tsql &= "," & Val(T_Mes.SelectedValue)
                G.Tsql &= "," & Val(Elimina_Comas(T_Magna.Text))
                G.Tsql &= "," & Val(Elimina_Comas(T_Premium.Text))
                G.Tsql &= "," & Val(Elimina_Comas(T_Diesel.Text)) & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Año.Text.Trim, T_Mes.SelectedItem.ToString.ToUpper)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Cuota_IEPS set Magna=" & Val(Elimina_Comas(T_Magna.Text))
                G.Tsql &= ",Premium=" & Val(Elimina_Comas(T_Premium.Text))
                G.Tsql &= ",Diesel=" & Val(Elimina_Comas(T_Diesel.Text.Trim))
                G.Tsql &= " Where Año=" & Val(T_Año.Text.Trim)
                G.Tsql &= " and Mes=" & Val(T_Mes.SelectedValue)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Año.Text.Trim, T_Mes.SelectedItem.ToString.ToUpper)
                'If Ch_Baja.Checked = True Then
                '    EliminaFilaGrid(T_Año.Text.Trim)
                'End If
                LimpiaCampos()
            End If
            'If Movimiento.Value = "Baja" Then
            '    G.cn.Open()
            '    G.Tsql = "Update Area set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
            '    G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
            '    G.Tsql &= ",Fecha_Seg=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
            '    G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
            '    G.Tsql &= ",Baja=" & "'*'"
            '    G.Tsql &= " Where Cia=" & Val(Session("Cia"))
            '    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            '    G.Tsql &= " and Area=" & Val(T_Año.Text.Trim)
            '    G.com.CommandText = G.Tsql
            '    G.com.ExecuteNonQuery()
            '    EliminaFilaGrid(T_Año.Text.Trim)
            '    LimpiaCampos()
            'End If
            DesHabilita()
            GridView1.Visible = True
            Pnl_Grids.Visible = True
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Ima_Salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub
    Protected Function Numero_Mes(ByVal Nombre_Mes As String) As Integer
        Select Case Nombre_Mes
            Case "ENERO"
                Numero_Mes = 1
            Case "FEBRERO"
                Numero_Mes = 2
            Case "MARZO"
                Numero_Mes = 3
            Case "ABRIL"
                Numero_Mes = 4
            Case "MAYO"
                Numero_Mes = 5
            Case "JUNIO"
                Numero_Mes = 6
            Case "JULIO"
                Numero_Mes = 7
            Case "AGOSTO"
                Numero_Mes = 8
            Case "SEPTIEMBRE"
                Numero_Mes = 9
            Case "OCTUBRE"
                Numero_Mes = 10
            Case "NOVIEMBRE"
                Numero_Mes = 11
            Case "DICIEMBRE"
                Numero_Mes = 12
        End Select
        Return Numero_Mes
    End Function
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Or (e.CommandName.Equals("Seleccion")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(1) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Clave(1) = (GridView1.Rows(ind).Cells(2).Text.ToUpper)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Año.Text = f.Item("Año")
                T_Mes.SelectedValue = Numero_Mes(f.Item("Mes"))
                T_Magna.Text = For_Pan_Lib(f.Item("Magna"), 2)
                T_Premium.Text = For_Pan_Lib(f.Item("Premium"), 2)
                T_Diesel.Text = For_Pan_Lib(f.Item("Diesel"), 2)
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Año.Enabled = False
                T_Mes.Enabled = False
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"

            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Magna.Focus()
                Habilita()
                T_Año.Enabled = False
                T_Mes.Enabled = False
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
            End If

        End If
    End Sub

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click
        GridView1.Visible = True
        Pnl_Grids.Visible = True
        LLenaGrid()
    End Sub

    Protected Sub Ima_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
