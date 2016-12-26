Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Empleados
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
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Session("dt") = New DataTable
            CrearCamposTabla()
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            DesHabilita()
            Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
            Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
        End If
        Msg_Err.Visible = False
        LLenaGrid()
        DibujaSpan()
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        T_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Numero.ClientID & "');")
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
        Session("dt").Columns.Add("Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Nombre", Type.GetType("System.String")) : Session("dt").Columns("Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Categoria", Type.GetType("System.String")) : Session("dt").Columns("Categoria").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Cambio", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Cambio").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Registro.Visible = False
        Pnl_Busqueda.Visible = True
        T_Numero.Enabled = False
        T_Descripcion.Enabled = False
        Ima_Restaura.Enabled = False
        T_Categoria.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        GridView1.Enabled = True
        TB_Descripcion.Enabled = True
        TB_Numero.Enabled = True
        Ch_Baja.Enabled = True

    End Sub
    Private Sub Habilita()
        Pnl_Registro.Visible = True
        Pnl_Busqueda.Visible = False
        T_Numero.Enabled = True
        T_Categoria.Enabled = True
        T_Descripcion.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        GridView1.Enabled = False
        TB_Descripcion.Enabled = False
        TB_Numero.Enabled = False
        Ch_Baja.Enabled = False
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
            G.Tsql = "Select Numero,Nombre,Categoria from Empleados "
            G.Tsql &= "   and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
            If Ch_Baja.Checked = True Then
                G.Tsql &= " where Baja='*'"
            Else
                G.Tsql &= " where Baja<>'*' "
            End If
            If Val(TB_Numero.Text.Trim) <> 0 Then
                G.Tsql &= " and Numero =" & Val(TB_Numero.Text.Trim)
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Nombre like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            G.Tsql &= " Order by Numero"
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
    Private Sub LimpiaCampos()
        T_Numero.Text = ""
        T_Descripcion.Text = ""
        T_Categoria.Text = ""
    End Sub
    'Private Function Siguiente() As Integer
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Siguiente = 0
    '    Try
    '        G.cn.Open()
    '        G.Tsql = "Select Max(Numero) from Empleados"
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
        If Val(T_Numero.Text.Trim) = 0 Then
            Msg_Error("Numero invalido") : Exit Function
        End If
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Nombre inválido") : Exit Function
        End If
        Return True
    End Function

    Protected Sub Ima_Alta_Click(sender As Object, e As System.EventArgs) Handles Ima_Alta.Click
        Habilita()
        T_Numero.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        'T_Numero.Text = Siguiente()
        T_Numero.Focus()
        Pnl_Grids.Visible = False
    End Sub
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Categoria As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Numero
        f("Nombre") = Descripcion
        f("Categoria") = Categoria
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Categoria As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Nombre") = Descripcion
            f("Categoria") = Categoria
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

    Protected Sub Ima_Guarda_Click(sender As Object, e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            G.cn.Open()

            If Movimiento.Value = "Alta" Then
                Tsql = "Select Nombre from Empleados where Nombre=" & Pone_Apos(T_Descripcion.Text)
                Tsql &= "     and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe un empleado con el nombre: " & Pone_Apos(T_Descripcion.Text)) : Exit Sub
                End If
                Tsql = "Select Numero from Empleados where Numero=" & Val(T_Numero.Text)
                Tsql &= "   and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe un empleado con el numero: " & Pone_Apos(T_Numero.Text)) : Exit Sub
                End If
                G.Tsql = "Insert into Empleados (Cia,Obra,Numero,Nombre,Categoria,Fecha_Cambio,Baja) values ("
                G.Tsql &= Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(G.Sucursal)
                G.Tsql &= "," & T_Numero.Text.Trim
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Categoria.Text.Trim)
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Categoria.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Empleados set Nombre=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Categoria=" & Pone_Apos(T_Categoria.Text.Trim)
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " where Numero=" & Val(T_Numero.Text.Trim)
                G.Tsql &= "   and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Categoria.Text.Trim)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Empleados set Nombre=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Categoria=" & Pone_Apos(T_Categoria.Text.Trim)
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= ",Baja=" & "'*'"
                G.Tsql &= " where Numero=" & Val(T_Numero.Text.Trim)
                G.Tsql &= "   and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid(T_Numero.Text.Trim)
                LimpiaCampos()
            End If
            DesHabilita()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
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
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f.Item("Numero")
                T_Descripcion.Text = f.Item("Nombre")
                T_Categoria.Text = f.Item("Categoria")
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Descripcion.Enabled = False
                T_Categoria.Enabled = False
                Pnl_Grids.Visible = False
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Descripcion.Focus()
                Habilita()
                T_Numero.Enabled = False
                Pnl_Grids.Visible = False
            End If
        End If
    End Sub

    Protected Sub Ima_Busca_Click(sender As Object, e As System.EventArgs) Handles Ima_Busca.Click
        'dt = LLena_Datatable()
        'If Session("dt").Rows.Count > 0 Then
        '    GridView1.DataSource = Session("dt")
        '    GridView1.DataBind()
        'Else
        '    DibujaSpan()
        'End If
        Pnl_Grids.Visible = True
        LLenaGrid()
    End Sub

    Protected Sub Ima_Restaura_Click(sender As Object, e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Area").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Numero")
            T_Descripcion.Text = f.Item("Nombre")
            T_Categoria.Text = f.Item("Categoria")
        End If
    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        Pnl_Grids.Visible = True
        LLenaGrid()
    End Sub
End Class
