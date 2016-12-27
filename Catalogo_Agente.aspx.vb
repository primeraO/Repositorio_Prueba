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
        ' Numero, Nombre, Direccion, Colonia, Estado, Telefono, Fax, Mail
        Session("dt").Columns.Add("Numero", Type.GetType("System.String")) : Session("dt").Columns("Numero").DefaultValue = ""
        Session("dt").Columns.Add("Nombre", Type.GetType("System.String")) : Session("dt").Columns("Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Direccion", Type.GetType("System.String")) : Session("dt").Columns("Direccion").DefaultValue = ""
        Session("dt").Columns.Add("Colonia", Type.GetType("System.String")) : Session("dt").Columns("Colonia").DefaultValue = ""
        Session("dt").Columns.Add("Estado", Type.GetType("System.String")) : Session("dt").Columns("Estado").DefaultValue = ""
        Session("dt").Columns.Add("Telefono", Type.GetType("System.String")) : Session("dt").Columns("Telefono").DefaultValue = ""
        Session("dt").Columns.Add("Fax", Type.GetType("System.String")) : Session("dt").Columns("Fax").DefaultValue = ""
        Session("dt").Columns.Add("Mail", Type.GetType("System.String")) : Session("dt").Columns("Mail").DefaultValue = ""
        'Session("dt").Columns.Add("Motor_Marca", Type.GetType("System.String")) : Session("dt").Columns("Motor_Marca").DefaultValue = ""
        'Session("dt").Columns.Add("Motor_Modelo", Type.GetType("System.String")) : Session("dt").Columns("Motor_Modelo").DefaultValue = ""
        'Session("dt").Columns.Add("Fecha_Cambio", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Cambio").DefaultValue = ""
        'Session("dt").Columns.Add("Fecha_Entrada", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Entrada").DefaultValue = ""
        'Session("dt").Columns.Add("Fecha_Salida", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Salida").DefaultValue = ""
        'Session("dt").Columns.Add("Estatus", Type.GetType("System.String")) : Session("dt").Columns("Estatus").DefaultValue = ""
        'Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        T_Numero.Enabled = False
        'T_Fecha_Entrada.Enabled = False
        'T_Fecha_Salida.Enabled = False
        'T_Estatus.Enabled = False
        T_Nombre.Enabled = False
        T_Direccion.Enabled = False
        T_Mail.Enabled = False
        'T_Marc.Enabled = False
        T_Fax.Enabled = False
        T_Estado.Enabled = False
        ' T_Modelo_Motor.Enabled = False
        'Te.Enabled = False
        'T_Serie_Motor.Enabled = False
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
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
        Ch_Baja.Enabled = True
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False
        T_Numero.Enabled = True
        'T_Fecha_Entrada.Enabled = True
        'T_Fecha_Salida.Enabled = True
        'T_Estatus.Enabled = True
        T_Nombre.Enabled = True
        T_Direccion.Enabled = True
        T_Mail.Enabled = True
        T_Colonia.Enabled = True

        'T_Marc.Enabled = True
        T_Fax.Enabled = True
        T_Estado.Enabled = True
        'T_Modelo_Motor.Enabled = True
        'Te.Enabled = True
        'T_Serie_Motor.Enabled = True
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
            G.Tsql = "Select Numero,Nombre,Direccion,Colonia,Estado,Telefono,Fax,Mail from Agente "
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
                G.Tsql &= " and Nombre like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            G.Tsql &= " and Compañia=" & Val(Session("Cia"))
            G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
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
        T_Nombre.Text = ""
        T_Direccion.Text = ""
        T_Mail.Text = ""
        T_Telefono.Text = ""
        ' T_Estado.Text = ""
        T_Colonia.Text = ""
        'T_Marc.Text = ""
        T_Fax.Text = ""
        T_Estado.Text = ""
        ' T_Modelo_Motor.Text = ""
        'Te.Text = ""
        'T_Serie_Motor.Text = ""
        'T_Fecha_Entrada.Text = ""
        'T_Fecha_Salida.Text = ""
        'T_Estatus.Text = ""
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Numero) from Agente where  Compañia=" & Val(Session("Cia"))
            G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
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
        If T_Nombre.Text.Trim = "" Then
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
        f("Nombre") = Descripcion
        f("Direccion") = Aplicacion
        f("Colonia") = Marca
        f("Estado") = Modelo
        f("Telefono") = Serie
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
            f("Nombre") = Descripcion
            f("Direccion") = Aplicacion
            f("Colonia") = Marca
            f("Estado") = Modelo
            f("Telefono") = Serie
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
                Tsql = "Select Numero from Agente where Numero=" & Pone_Apos(T_Numero.Text)
                Tsql &= " and Compañia=" & Val(Session("Cia"))
                Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el agente con el numero: " & Pone_Apos(T_Numero.Text)) : Exit Sub
                End If
                G.Tsql = "Insert into Agente (Compañia,Sucursal,Numero,Nombre,Direccion,Colonia,Estado,Telefono,Fax,Mail,Baja) values ("
                G.Tsql &= Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(G.Sucursal)
                G.Tsql &= "," & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Nombre.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Colonia.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Estado.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Telefono.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Fax.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Mail.Text.Trim)
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Nombre.Text.Trim, T_Direccion.Text.Trim, T_Colonia.Text.Trim, T_Estado.Text.Trim, T_Telefono.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Agente set Numero=" & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= ",Nombre=" & Pone_Apos(T_Nombre.Text.Trim)
                G.Tsql &= ",Direccion=" & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= ",Colonia=" & Pone_Apos(T_Colonia.Text.Trim)
                G.Tsql &= ",Estado=" & Pone_Apos(T_Estado.Text.Trim)
                G.Tsql &= ",Telefono=" & Pone_Apos(T_Telefono.Text.Trim)
                G.Tsql &= ",Mail=" & Pone_Apos(T_Mail.Text.Trim)
                G.Tsql &= ",Fax=" & Pone_Apos(T_Fax.Text.Trim)
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Numero=" & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Compañia=" & Val(Session("Cia"))
                G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Nombre.Text.Trim, T_Direccion.Text.Trim, T_Colonia.Text.Trim, T_Estado.Text.Trim, T_Telefono.Text.Trim)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Agente set Baja=" & "'*'"
                G.Tsql &= " Where Numero=" & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Compañia=" & Val(Session("Cia"))
                G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
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
                T_Nombre.Text = f.Item("Nombre")
                T_Direccion.Text = f.Item("Direccion")
                T_Colonia.Text = f.Item("Colonia")
                T_Estado.Text = f.Item("Estado")
                T_Telefono.Text = f.Item("Telefono")
                T_Mail.Text = f.Item("Mail")
                T_Fax.Text = f.Item("Fax")
                
                GridView1.Enabled = False
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Nombre.Enabled = False
                T_Direccion.Enabled = False
                T_Colonia.Enabled = False
                T_Estado.Enabled = False
                T_Telefono.Enabled = False
                T_Mail.Enabled = False
                T_Fax.Enabled = False
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                'T_Fecha_Entrada.Enabled = False
                'T_Fecha_Salida.Enabled = False
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Nombre.Focus()
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
            T_Nombre.Text = f.Item("Nombre")
            T_Direccion.Text = f.Item("Direccion")
            T_Colonia.Text = f.Item("Colonia")
            T_Estado.Text = f.Item("Estado")
            T_Telefono.Text = f.Item("Telefono")
            T_Mail.Text = f.Item("Mail")
            T_Fax.Text = f.Item("Fax")
            ' Te.Text = f.Item("Serie")
            'T_Serie_Motor.Text = f.Item("Motor_Serie")
        End If
    End Sub

    Protected Sub TB_Descripcion_TextChanged(sender As Object, e As System.EventArgs) Handles TB_Descripcion.TextChanged

    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub

    'Protected Sub Ima_Importar_Click(sender As Object, e As System.EventArgs) Handles Ima_Importar.Click
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Dim Maq_Eco As New DataTable
    '    Dim Inv_Eco As New DataTable
    '    Dim f_Maq As DataRow
    '    Dim f_Inv As DataRow
    '    Try
    '        G.cn.Open()
    '        G.cn2.Open()
    '        G.Tsql = "Select Economico, Descripcion from Economico"
    '        G.Tsql &= " Where Procedencia=" & Pone_Apos(G.Sucursal)
    '        G.Tsql &= " and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
    '        G.com2.CommandText = G.Tsql
    '        G.dr2 = G.com2.ExecuteReader
    '        Maq_Eco.Load(G.dr2)
    '        Maq_Eco.PrimaryKey = New DataColumn() {Maq_Eco.Columns("Economico")}
    '        G.Tsql = "Select Numero As Economico, Descripcion from Economico Where  Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
    '        G.com.CommandText = G.Tsql
    '        G.dr = G.com.ExecuteReader
    '        Inv_Eco.Load(G.dr)
    '        Inv_Eco.PrimaryKey = New DataColumn() {Inv_Eco.Columns("Economico")}
    '        For Each f As DataRow In Maq_Eco.Rows
    '            f_Inv = Inv_Eco.Rows.Find(New Object() {f("Economico")})
    '            If f_Inv Is Nothing Then
    '                G.Tsql = "Insert Into Economico(Cia,Obra,Numero,Descripcion) values("
    '                G.Tsql &= Val(Session("Cia"))
    '                G.Tsql &= "," & Pone_Apos(G.Sucursal)
    '                G.Tsql &= "," & Pone_Apos(f("Economico"))
    '                G.Tsql &= "," & Pone_Apos(f("Descripcion")) & ")"
    '            Else
    '                G.Tsql = "Update Economico set"
    '                G.Tsql &= " Descripcion=" & Pone_Apos(f("Descripcion"))
    '                G.Tsql &= " Where Numero=" & Pone_Apos(f("Economico"))
    '                G.Tsql &= " and Cia=" & Val(Session("Cia"))
    '                G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
    '            End If
    '            G.com.CommandText = G.Tsql
    '            G.com.ExecuteNonQuery()
    '        Next
    '        Msg_Error("Importación Exitosa")
    '    Catch ex As Exception
    '        Msg_Error(ex.Message.ToString)
    '        Exit Sub
    '    Finally
    '        G.cn.Close()
    '        G.cn2.Close()
    '    End Try
    '    LLenaGrid()
    'End Sub

    'Private Function T_Fecha_Entrada() As Object
    '    Throw New NotImplementedException
    'End Function

End Class
