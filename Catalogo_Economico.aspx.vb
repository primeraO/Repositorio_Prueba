Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Economico
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
            Try
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
            Catch ex As Exception
            End Try

        End If
        LLenaGrid()
        DibujaSpan()
        Msg_Err.Visible = False

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
        'Tabla Economicos
        Session("dt").Columns.Add("Numero", Type.GetType("System.String")) : Session("dt").Columns("Numero").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Aplicacion", Type.GetType("System.String")) : Session("dt").Columns("Aplicacion").DefaultValue = ""
        Session("dt").Columns.Add("Marca", Type.GetType("System.String")) : Session("dt").Columns("Marca").DefaultValue = ""
        Session("dt").Columns.Add("Modelo", Type.GetType("System.String")) : Session("dt").Columns("Modelo").DefaultValue = ""
        Session("dt").Columns.Add("Serie", Type.GetType("System.String")) : Session("dt").Columns("Serie").DefaultValue = ""
        Session("dt").Columns.Add("Motor_Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Motor_Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Motor_Serie", Type.GetType("System.String")) : Session("dt").Columns("Motor_Serie").DefaultValue = ""
        Session("dt").Columns.Add("Motor_Marca", Type.GetType("System.String")) : Session("dt").Columns("Motor_Marca").DefaultValue = ""
        Session("dt").Columns.Add("Motor_Modelo", Type.GetType("System.String")) : Session("dt").Columns("Motor_Modelo").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Cambio", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Cambio").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Entrada", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Entrada").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Salida", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Salida").DefaultValue = ""
        Session("dt").Columns.Add("Estatus", Type.GetType("System.String")) : Session("dt").Columns("Estatus").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        T_Numero.Enabled = False
        T_Fecha_Entrada.Enabled = False
        T_Fecha_Salida.Enabled = False
        T_Estatus.Enabled = False
        T_Descripcion.Enabled = False
        T_Aplicacion.Enabled = False
        T_Desc_Motor.Enabled = False
        T_Marca.Enabled = False
        T_Marca_Motor.Enabled = False
        T_Modelo.Enabled = False
        T_Modelo_Motor.Enabled = False
        T_Serie.Enabled = False
        T_Serie_Motor.Enabled = False
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        GridView1.Enabled = True
        GridView1.Enabled = True
        TB_Numero.Enabled = True
        TB_Descripcion.Enabled = True
        Ch_Baja.Enabled = True
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False
        T_Numero.Enabled = True
        T_Fecha_Entrada.Enabled = True
        T_Fecha_Salida.Enabled = True
        T_Estatus.Enabled = True
        T_Descripcion.Enabled = True
        T_Aplicacion.Enabled = True
        T_Desc_Motor.Enabled = True
        T_Marca.Enabled = True
        T_Marca_Motor.Enabled = True
        T_Modelo.Enabled = True
        T_Modelo_Motor.Enabled = True
        T_Serie.Enabled = True
        T_Serie_Motor.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        GridView1.Enabled = False
        TB_Numero.Enabled = False
        TB_Descripcion.Enabled = False
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
            G.Tsql = "Select Numero,Descripcion,Aplicacion,Marca,Modelo,Serie,Motor_Descripcion,Motor_Serie,Motor_Marca,Motor_Modelo,Fecha_Entrada,Fecha_Salida,Estatus from Economico "
            G.Tsql &= " where numero <> ''"
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*'"
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If TB_Numero.Text.Trim <> "" Then
                G.Tsql &= " and Numero like '%" & TB_Numero.Text.Trim & "%'"
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
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
        T_Aplicacion.Text = ""
        T_Desc_Motor.Text = ""
        T_Marca.Text = ""
        T_Marca_Motor.Text = ""
        T_Modelo.Text = ""
        T_Modelo_Motor.Text = ""
        T_Serie.Text = ""
        T_Serie_Motor.Text = ""
        T_Fecha_Entrada.Text = ""
        T_Fecha_Salida.Text = ""
        T_Estatus.Text = ""
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Numero) from Economico where  Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
            G.com.CommandText = G.Tsql
            Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function
    Private Function validar() As Boolean
        validar = False
        If T_Numero.Text.Trim = "" Then
            Msg_Error("Numero invalido") : Exit Function
        End If
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Descripcion inválida") : Exit Function
        End If
        'If T_Aplicacion.Text.Trim = "" Then
        '    Msg_Error("Aplicacion inválida") : Exit Function
        'End If
        'If T_Desc_Motor.Text.Trim = "" Then
        '    Msg_Error("Descripcion de motor inválida") : Exit Function
        'End If
        'If T_Marca.Text.Trim = "" Then
        '    Msg_Error("Marca inválida") : Exit Function
        'End If
        'If T_Marca_Motor.Text.Trim = "" Then
        '    Msg_Error("MArca del motor inválida") : Exit Function
        'End If
        'If T_Modelo.Text.Trim = "" Then
        '    Msg_Error("Modelo inválido") : Exit Function
        'End If
        'If T_Modelo_Motor.Text.Trim = "" Then
        '    Msg_Error("Modelo de motor inválido") : Exit Function
        'End If
        'If T_Serie.Text.Trim = "" Then
        '    Msg_Error("Serie inválida") : Exit Function
        'End If
        'If T_Serie_Motor.Text.Trim = "" Then
        '    Msg_Error("Serie de motor inválida") : Exit Function
        'End If
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Aplicacion As String, ByVal Marca As String, ByVal Modelo As String, ByVal Serie As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Numero
        f("Descripcion") = Descripcion
        f("Aplicacion") = Aplicacion
        f("Marca") = Marca
        f("Modelo") = Modelo
        f("Serie") = Serie
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Aplicacion As String, ByVal Marca As String, ByVal Modelo As String, ByVal Serie As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Descripcion") = Descripcion
            f("Aplicacion") = Aplicacion
            f("Marca") = Marca
            f("Modelo") = Modelo
            f("Serie") = Serie
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal Numero As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Protected Sub Ima_Busca_Click(sender As Object, e As System.EventArgs) Handles Ima_Busca.Click
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

    Protected Sub Ima_Alta_Click(sender As Object, e As System.EventArgs) Handles Ima_Alta.Click
        Habilita()
        'T_Numero.Enabled = False
        LimpiaCampos()
        Movimiento.Value = "Alta"
        'T_Numero.Text = Siguiente()
        T_Numero.Focus()
        GridView1.Enabled = False
        Pnl_Registro.Enabled = True
    End Sub

    Protected Sub Ima_Restaura_Click(sender As Object, e As System.EventArgs) Handles Ima_Restaura.Click
        LimpiaCampos()
        DesHabilita()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub Ima_Guarda_Click(sender As Object, e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            G.cn.Open()


            If Movimiento.Value = "Alta" Then
                Tsql = "Select Numero from Economico where Numero=" & Pone_Apos(T_Numero.Text)
                Tsql &= " and Cia=" & Val(Session("Cia"))
                Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el economico con el numero: " & Pone_Apos(T_Numero.Text)) : Exit Sub
                End If
                G.Tsql = "Insert into Economico (Cia,Obra,Numero,Descripcion,Aplicacion,Marca,Modelo,Serie,Motor_Descripcion,Motor_Serie,Motor_Marca,Motor_Modelo,Fecha_Cambio,Fecha_Entrada,Fecha_Salida,Estatus,Baja) values ("
                G.Tsql &= Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(G.Sucursal)
                G.Tsql &= "," & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Marca.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Modelo.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Serie.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Desc_Motor.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Serie_Motor.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Marca_Motor.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Modelo_Motor.Text.Trim)
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= "," & Pone_Apos(T_Fecha_Entrada.Text)
                G.Tsql &= "," & Pone_Apos(T_Fecha_Salida.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Estatus.Text)
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Aplicacion.Text.Trim, T_Marca.Text.Trim, T_Modelo.Text.Trim, T_Serie.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Economico set Numero=" & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= ",Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Aplicacion=" & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= ",Marca=" & Pone_Apos(T_Marca.Text.Trim)
                G.Tsql &= ",Modelo=" & Pone_Apos(T_Modelo.Text.Trim)
                G.Tsql &= ",Serie=" & Pone_Apos(T_Serie.Text.Trim)
                G.Tsql &= ",Motor_Descripcion=" & Pone_Apos(T_Desc_Motor.Text.Trim)
                G.Tsql &= ",Motor_Serie=" & Pone_Apos(T_Serie_Motor.Text.Trim)
                G.Tsql &= ",Motor_Marca=" & Pone_Apos(T_Marca_Motor.Text.Trim)
                G.Tsql &= ",Motor_Modelo=" & Pone_Apos(T_Modelo_Motor.Text.Trim)
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= ",Fecha_Entrada=" & Pone_Apos(T_Fecha_Entrada.Text)
                G.Tsql &= ",Fecha_Salida=" & Pone_Apos(T_Fecha_Salida.Text)
                G.Tsql &= ",Estatus=" & Pone_Apos(T_Estatus.Text)
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Numero=" & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Aplicacion.Text.Trim, T_Marca.Text.Trim, T_Modelo.Text.Trim, T_Serie.Text.Trim)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                'G.Tsql = "Delete from Moneda Where Moneda=" & Val(T_NumeroPais.Text.Trim)
                'G.com.CommandText = G.Tsql
                G.Tsql = "Update Economico set Baja=" & "'*'"
                G.Tsql &= " Where Numero=" & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
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
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Or (e.CommandName.Equals("Seleccion")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f.Item("Numero")
                T_Descripcion.Text = f.Item("Descripcion")
                T_Aplicacion.Text = f.Item("Aplicacion")
                T_Desc_Motor.Text = f.Item("Motor_Descripcion")
                T_Marca.Text = f.Item("Marca")
                T_Marca_Motor.Text = f.Item("Motor_Marca")
                T_Modelo.Text = f.Item("Modelo")
                T_Modelo_Motor.Text = f.Item("Motor_Modelo")
                T_Serie.Text = f.Item("Serie")
                T_Serie_Motor.Text = f.Item("Motor_Serie")
                T_Fecha_Entrada.Text = f.Item("Fecha_Entrada")
                T_Fecha_Salida.Text = f.Item("Fecha_Salida")
                T_Estatus.Text = f.Item("Estatus")
                GridView1.Enabled = False
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Descripcion.Enabled = False
                T_Aplicacion.Enabled = False
                T_Desc_Motor.Enabled = False
                T_Marca.Enabled = False
                T_Marca_Motor.Enabled = False
                T_Modelo.Enabled = False
                T_Modelo_Motor.Enabled = False
                T_Serie.Enabled = False
                T_Serie_Motor.Enabled = False
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                T_Fecha_Entrada.Enabled = False
                T_Fecha_Salida.Enabled = False
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Descripcion.Focus()
                Habilita()
                T_Numero.Enabled = False
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
            End If

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Numero").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Numero")
            T_Descripcion.Text = f.Item("Descripcion")
            T_Aplicacion.Text = f.Item("Aplicacion")
            T_Desc_Motor.Text = f.Item("Motor_Descripcion")
            T_Marca.Text = f.Item("Marca")
            T_Marca_Motor.Text = f.Item("Motor_Marca")
            T_Modelo.Text = f.Item("Modelo")
            T_Modelo_Motor.Text = f.Item("Motor_Modelo")
            T_Serie.Text = f.Item("Serie")
            T_Serie_Motor.Text = f.Item("Motor_Serie")
        End If
    End Sub

    Protected Sub TB_Descripcion_TextChanged(sender As Object, e As System.EventArgs) Handles TB_Descripcion.TextChanged

    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub

    Protected Sub Ima_Importar_Click(sender As Object, e As System.EventArgs) Handles Ima_Importar.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Maq_Eco As New DataTable
        Dim Inv_Eco As New DataTable
        Dim f_Maq As DataRow
        Dim f_Inv As DataRow
        Try
            G.cn.Open()
            G.cn2.Open()
            G.Tsql = "Select Economico, Descripcion from Economico"
            G.Tsql &= " Where Procedencia=" & Pone_Apos(G.Sucursal)
            G.Tsql &= " and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
            G.com2.CommandText = G.Tsql
            G.dr2 = G.com2.ExecuteReader
            Maq_Eco.Load(G.dr2)
            Maq_Eco.PrimaryKey = New DataColumn() {Maq_Eco.Columns("Economico")}
            G.Tsql = "Select Numero As Economico, Descripcion from Economico Where  Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Inv_Eco.Load(G.dr)
            Inv_Eco.PrimaryKey = New DataColumn() {Inv_Eco.Columns("Economico")}
            For Each f As DataRow In Maq_Eco.Rows
                f_Inv = Inv_Eco.Rows.Find(New Object() {f("Economico")})
                If f_Inv Is Nothing Then
                    G.Tsql = "Insert Into Economico(Cia,Obra,Numero,Descripcion) values("
                    G.Tsql &= Val(Session("Cia"))
                    G.Tsql &= "," & Pone_Apos(G.Sucursal)
                    G.Tsql &= "," & Pone_Apos(f("Economico"))
                    G.Tsql &= "," & Pone_Apos(f("Descripcion")) & ")"
                Else
                    G.Tsql = "Update Economico set"
                    G.Tsql &= " Descripcion=" & Pone_Apos(f("Descripcion"))
                    G.Tsql &= " Where Numero=" & Pone_Apos(f("Economico"))
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                End If
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
            Next
            Msg_Error("Importación Exitosa")
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.cn2.Close()
        End Try
        LLenaGrid()
    End Sub
End Class
