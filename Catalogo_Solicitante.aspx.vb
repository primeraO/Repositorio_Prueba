Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Solicitante
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
            G.Nombre_Catalogo = "Solicitante"
            Session("dt") = New DataTable
            CrearCamposTabla()
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            LLenaGrid()
            DesHabilita()
            Try
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"

            Catch ex As Exception

            End Try

        End If
        Msg_Err.Visible = False
        LLenaGrid()
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
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
    Private Sub LLenaGrid()
        dt = LLena_Datatable()
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
            Session("dt").rows.clear()
            G.cn.Open()
            G.Tsql = "Select Solicitante, Nombre, RFC, Tarjeta from Solicitante"
            G.Tsql &= " Where Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*' "
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If TB_Nombre.Text.Trim <> "" Then
                G.Tsql &= " and Nombre like '%" & TB_Nombre.Text.Trim & "%'"
            End If
            If TB_Numero.Text <> "" Then
                G.Tsql &= " and Solicitante =" & Val(TB_Numero.Text.Trim)
            End If
            'G.Tsql &= " and EmpresaNumero=" & Session("Empresa")
            G.Tsql &= " Order by Solicitante"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
        Catch ex As Exception
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Private Sub LimpiaCampos()
        T_Numero.Text = ""
        T_Nombre.Text = ""
        T_RFC.Text = ""
        T_Num_Tarjeta.Text = ""
    End Sub
    Private Sub CrearCamposTabla()
        'Tabla Paises'
        Session("dt").Columns.Add("Cia", Type.GetType("System.Int64")) : Session("dt").Columns("Cia").DefaultValue = 0
        Session("dt").Columns.Add("Obra", Type.GetType("System.String")) : Session("dt").Columns("Obra").DefaultValue = ""
        Session("dt").Columns.Add("Solicitante", Type.GetType("System.String")) : Session("dt").Columns("Solicitante").DefaultValue = ""
        Session("dt").Columns.Add("Nombre", Type.GetType("System.String")) : Session("dt").Columns("Nombre").DefaultValue = ""
        Session("dt").Columns.Add("RFC", Type.GetType("System.String")) : Session("dt").Columns("RFC").DefaultValue = ""
        Session("dt").Columns.Add("Cve_Seg", Type.GetType("System.String")) : Session("dt").Columns("Cve_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Seg", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Hora_Seg", Type.GetType("System.String")) : Session("dt").Columns("Hora_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Tarjeta", Type.GetType("System.String")) : Session("dt").Columns("Tarjeta").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Solicitante")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Numero.Enabled = False
        T_Nombre.Enabled = False
        T_Num_Tarjeta.Enabled = False
        T_RFC.Enabled = False
        TB_Numero.Enabled = True
        TB_Nombre.Enabled = True
        Movimiento.Value = ""
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        Ch_Baja.Enabled = True
        GridView1.Enabled = True
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False
        T_Numero.Enabled = True
        T_Nombre.Enabled = True
        T_Num_Tarjeta.Enabled = True
        T_RFC.Enabled = True
        TB_Numero.Enabled = False
        TB_Nombre.Enabled = False
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        Ch_Baja.Enabled = False
        GridView1.Enabled = False
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Solicitante").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Solicitante")
            T_Nombre.Text = f.Item("Nombre")
            T_Nombre.Text = f.Item("RFC")
            T_Num_Tarjeta.Text = f.Item("Tarjeta")
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Or (e.CommandName.Equals("Seleccion")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f("Solicitante")
                T_Nombre.Text = f("Nombre")
                T_RFC.Text = f("RFC")
                T_Num_Tarjeta.Text = f("Tarjeta")
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Nombre.Enabled = False
                T_RFC.Enabled = False
                T_Num_Tarjeta.Enabled = False
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
                T_Numero.Enabled = False
                T_Nombre.Focus()
                Habilita()
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
            End If

        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub
   
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Nombre As String, ByVal RFC As String, ByVal Num_Tarjeta As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Solicitante") = Numero
        f("Nombre") = Nombre
        f("RFC") = RFC
        f("Tarjeta") = Num_Tarjeta
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Nombre As String, ByVal RFC As String, ByVal Num_Tarjeta As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Nombre") = Nombre
            f("RFC") = RFC
            f("Tarjeta") = Num_Tarjeta
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
   

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click



        GridView1.Visible = True
        Pnl_Grids.Visible = True
        dt = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
    Protected Sub Ima_Alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Alta.Click
        Ch_Baja.Checked = False
        Habilita()
        T_Numero.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Numero.Text = Siguiente()
        T_Nombre.Focus()
        Pnl_Registro.Enabled = True
    End Sub
    Protected Sub Ima_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            G.cn.Open()
            Dim rfc As String = T_RFC.Text
            If Movimiento.Value = "Alta" Then
                Tsql = "Select Nombre from Solicitante where Nombre=" & Pone_Apos(T_Nombre.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe un Solicitante con ese nombre") : Exit Sub
                End If
                G.Tsql = "Insert into Solicitante (Cia,Obra,Solicitante,Nombre,RFC,Cve_Seg,Fecha_Seg,Hora_Seg,Baja,Tarjeta) values ("
                G.Tsql &= Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(Session("Obra"))
                G.Tsql &= "," & T_Numero.Text.Trim
                G.Tsql &= "," & Pone_Apos(T_Nombre.Text.Trim)
                G.Tsql &= "," & Pone_Apos(rfc.ToUpper)
                G.Tsql &= "," & Pone_Apos(Session("Contraseña"))
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= "," & "''"
                G.Tsql &= "," & Pone_Apos(T_Num_Tarjeta.Text.Trim) & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Nombre.Text.Trim, rfc.ToUpper, T_Num_Tarjeta.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Solicitante set Nombre=" & Pone_Apos(T_Nombre.Text.Trim)
                G.Tsql &= ",RFC=" & Pone_Apos(rfc.ToUpper)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= ",Tarjeta=" & Pone_Apos(T_Num_Tarjeta.Text.Trim)
                G.Tsql &= " Where Solicitante=" & Val(T_Numero.Text.Trim)
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Nombre.Text.Trim, rfc.ToUpper, T_Num_Tarjeta.Text.Trim)
                If Ch_Baja.Checked Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Solicitante set Nombre=" & Pone_Apos(T_Nombre.Text.Trim)
                G.Tsql &= ",RFC=" & Pone_Apos(rfc.ToUpper)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Baja=" & "'*'"
                G.Tsql &= ",Tarjeta=" & Pone_Apos(T_Num_Tarjeta.Text.Trim)
                G.Tsql &= " Where Solicitante=" & Val(T_Numero.Text.Trim)
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid(T_Numero.Text.Trim)
                LimpiaCampos()
            End If
            DesHabilita()
            GridView1.Visible = True
            Pnl_Grids.Visible = True
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Private Function validar() As Boolean
        validar = False
        If T_Nombre.Text.Trim = "" Then
            Msg_Error("Nombre inválido") : Exit Function
        End If
        Return True
    End Function
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Solicitante) from Solicitante where Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.com.CommandText = G.Tsql
            Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub
End Class
