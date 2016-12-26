Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Obras
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then

            If G.Empresa_Numero = 0 Or G.Sucursal = "" Then Response.Redirect("Default.aspx")
            Lbl_Compañia.Text = "Empresa: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Proyecto.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            'Lbl_Compañia.Text = G.RazonSocial & "; " & G.Sucursal_Desc
            'Lbl_Usuario.Text = "USUARIO: " & G.UsuarioReal
            'Session("dt") = New DataTable
            'CrearCamposTabla()
            'GridView1.DataSource = Session("dt")
            'GridView1.DataBind()
            'Cabecera.DataSource = New List(Of String)
            'Cabecera.DataBind()
            'DesHabilita()
            'LLenaGrid()
            'Llena_Empresa()

            If IsNothing(Session("Imagen")) Then
                Image1.ImageUrl = "~/Imagenes/logo_Inter_Original.jpg"
            Else
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
            End If
            Try
                G.cn.Open()
                Dim dtEmpresa As New DataTable
                G.Tsql = "Select top(1) Año_Proceso,Mes_Proceso from Obra"
                G.Tsql &= " where Cia=" & G.Empresa_Numero
                G.Tsql &= " and Obra=" & G.Sucursal
                G.com.CommandText = G.Tsql
                G.dr = G.com.ExecuteReader
                dtEmpresa.Load(G.dr)
                For Each row As DataRow In dtEmpresa.Rows

                    T_Año.Text = CStr(row("Año_Proceso"))

                    T_Mes.Text = CStr(row("Mes_Proceso"))
                Next
            Catch ex As Exception
                Msg_Error(ex.Message)
            Finally
                G.cn.Close()
            End Try
        End If
        Msg_Err.Visible = False
        'DibujaSpan()
        'T_Pais.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Pais.ClientID & "');")
        'T_CP.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_CP.ClientID & "');")
        'T_Folio_Envio.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Folio_Envio.ClientID & "');")
        'T_Orden_Trabajo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Orden_Trabajo.ClientID & "');")
        T_Año.Attributes.Add("onfocus", "this.select();")
        T_Mes.Attributes.Add("onfocus", "this.select();")
        List_Empresa.Text = "Empresa: " & G.Empresa_Numero & " - " & G.RazonSocial
        T_Numero.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
        T_Año.Focus()




        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
    End Sub
    'Private Sub Llena_Empresa()
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Dim dtEmpresa As New DataTable
    '    Dim Tsql As String = ""
    '    Try
    '        G.cn.Open()
    '        Tsql = "Select Cia as Numero_Compañia,Razon_Social from Compañias "
    '        G.com.CommandText = Tsql
    '        G.dr = G.com.ExecuteReader
    '        dtEmpresa.Load(G.dr)
    '        If G.dr.IsClosed = False Then G.dr.Close()

    '        List_Empresa.DataSource = dtEmpresa
    '        BList_Empresa.DataSource = dtEmpresa
    '        List_Empresa.DataTextField = "Razon_Social"
    '        BList_Empresa.DataTextField = "Razon_Social"
    '        List_Empresa.DataValueField = "Numero_Compañia"
    '        BList_Empresa.DataValueField = "Numero_Compañia"
    '        List_Empresa.DataBind()
    '        BList_Empresa.DataBind()

    '        If List_Empresa.Items.Count > 0 Then G.Empresa_Numero2 = List_Empresa.SelectedValue
    '        If BList_Empresa.Items.Count > 0 Then G.Empresa_Numero2 = BList_Empresa.SelectedValue
    '    Catch ex As Exception
    '        Msg_Error(ex.Message)
    '    Finally
    '        G.cn.Close()
    '    End Try
    'End Sub
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
        Session("dt").Columns.Add("Cia", Type.GetType("System.Int64")) : Session("dt").Columns("Cia").DefaultValue = 0
        Session("dt").Columns.Add("Obra", Type.GetType("System.String")) : Session("dt").Columns("Obra").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Direccion", Type.GetType("System.String")) : Session("dt").Columns("Direccion").DefaultValue = ""
        Session("dt").Columns.Add("Colonia", Type.GetType("System.String")) : Session("dt").Columns("Colonia").DefaultValue = ""
        Session("dt").Columns.Add("Ciudad", Type.GetType("System.String")) : Session("dt").Columns("Ciudad").DefaultValue = ""
        Session("dt").Columns.Add("Estado", Type.GetType("System.String")) : Session("dt").Columns("Estado").DefaultValue = ""
        Session("dt").Columns.Add("Delegacion", Type.GetType("System.String")) : Session("dt").Columns("Delegacion").DefaultValue = ""
        Session("dt").Columns.Add("CP", Type.GetType("System.String")) : Session("dt").Columns("CP").DefaultValue = ""
        Session("dt").Columns.Add("Pais", Type.GetType("System.Int64")) : Session("dt").Columns("Pais").DefaultValue = 0
        Session("dt").Columns.Add("Telefono", Type.GetType("System.String")) : Session("dt").Columns("Telefono").DefaultValue = ""
        Session("dt").Columns.Add("Fax", Type.GetType("System.String")) : Session("dt").Columns("Fax").DefaultValue = ""
        Session("dt").Columns.Add("Sup_Maq", Type.GetType("System.String")) : Session("dt").Columns("Sup_Maq").DefaultValue = ""
        Session("dt").Columns.Add("Sup_Con", Type.GetType("System.String")) : Session("dt").Columns("Sup_Con").DefaultValue = ""
        Session("dt").Columns.Add("Dir_Maq", Type.GetType("System.String")) : Session("dt").Columns("Dir_Maq").DefaultValue = ""
        Session("dt").Columns.Add("Dir_Con", Type.GetType("System.String")) : Session("dt").Columns("Dir_Con").DefaultValue = ""
        Session("dt").Columns.Add("Ger_Con", Type.GetType("System.String")) : Session("dt").Columns("Ger_Con").DefaultValue = ""
        Session("dt").Columns.Add("Abreviatura", Type.GetType("System.String")) : Session("dt").Columns("Abreviatura").DefaultValue = ""
        Session("dt").Columns.Add("Activa", Type.GetType("System.String")) : Session("dt").Columns("Activa").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Mail_Sup_Maq", Type.GetType("System.String")) : Session("dt").Columns("Mail_Sup_Maq").DefaultValue = ""
        Session("dt").Columns.Add("Mail_Sup_Con", Type.GetType("System.String")) : Session("dt").Columns("Mail_Sup_Con").DefaultValue = ""
        Session("dt").Columns.Add("Mail_dir_Maq", Type.GetType("System.String")) : Session("dt").Columns("Mail_dir_Maq").DefaultValue = ""
        Session("dt").Columns.Add("Mail_Dir_Con", Type.GetType("System.String")) : Session("dt").Columns("Mail_Dir_Con").DefaultValue = ""
        Session("dt").Columns.Add("Mail_Ger_Con", Type.GetType("System.String")) : Session("dt").Columns("Mail_Ger_Con").DefaultValue = ""
        Session("dt").Columns.Add("Prefijo_Envio", Type.GetType("System.String")) : Session("dt").Columns("Prefijo_Envio").DefaultValue = ""
        Session("dt").Columns.Add("Folio_Envio", Type.GetType("System.Int64")) : Session("dt").Columns("Folio_Envio").DefaultValue = 0
        Session("dt").Columns.Add("Orden_Trabajo", Type.GetType("System.Int64")) : Session("dt").Columns("Orden_Trabajo").DefaultValue = 0
        Session("dt").Columns.Add("Numero_Requisicion", Type.GetType("System.Int64")) : Session("dt").Columns("Numero_Requisicion").DefaultValue = 0
        Session("dt").Columns.Add("Numero_Orden", Type.GetType("System.Int64")) : Session("dt").Columns("Numero_Orden").DefaultValue = 0
        Session("dt").Columns.Add("Año_Proceso", Type.GetType("System.Int64")) : Session("dt").Columns("Año_Proceso").DefaultValue = 0
        Session("dt").Columns.Add("Mes_Proceso", Type.GetType("System.Int64")) : Session("dt").Columns("Mes_Proceso").DefaultValue = 0
        Session("dt").Columns.Add("Fecha_Seg", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Hora_Seg", Type.GetType("System.String")) : Session("dt").Columns("Hora_Seg").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Obra")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        'GridView1.Visible = True

        T_Numero.Enabled = False
        T_Año.Enabled = False
        T_Mes.Enabled = False
        T_Colonia.Enabled = False
        T_Ciudad.Enabled = False
        T_desc_Pais.Enabled = False
        T_Sup_Con.Enabled = False
        T_Sup_Maq.Enabled = False
        T_Dir_Con.Enabled = False

        T_Folio_Envio.Enabled = False
        T_Prefijo_Envio.Enabled = False
        T_Orden_Trabajo.Enabled = False
        Mail_Dir_Con.Enabled = False
        Mail_Dir_Maq.Enabled = False
        Mail_Ger_Con.Enabled = False
        Mail_Sup_Con.Enabled = False
        Mail_Sup_Maq.Enabled = False
        List_Empresa.Enabled = False
        T_Dir_Maq.Enabled = False
        T_Ger_Con.Enabled = False
        T_Estado.Enabled = False
        T_Delegacion.Enabled = False
        T_CP.Enabled = False
        T_Pais.Enabled = False
        T_Telefono.Enabled = False
        T_Fax.Enabled = False
        T_Abreviatura.Enabled = False
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        H_Pais.Attributes.Add("onclick", "")
        H_Pais.Attributes.Add("style", "cursor:not-allowed;")
        TB_Descripcion.Enabled = True
        TB_Numero.Enabled = True
        Ch_Baja.Enabled = True
        RB_Activa.Enabled = False

    End Sub
    Private Sub Habilita()
        Pnl_Registro.Visible = True
        Pnl_Busqueda.Visible = False
        GridView1.Enabled = False
        GridView1.Visible = False
        Pnl_Grids.Visible = False
        List_Empresa.Enabled = True
        T_Numero.Enabled = True
        T_Año.Enabled = True
        T_Mes.Enabled = True
        T_Colonia.Enabled = True
        T_Folio_Envio.Enabled = True
        T_Prefijo_Envio.Enabled = True
        T_Orden_Trabajo.Enabled = True
        Mail_Dir_Con.Enabled = True
        Mail_Dir_Maq.Enabled = True
        Mail_Ger_Con.Enabled = True
        Mail_Sup_Con.Enabled = True
        Mail_Sup_Maq.Enabled = True
        T_Ciudad.Enabled = True
        T_Estado.Enabled = True
        T_Sup_Con.Enabled = True
        T_Sup_Maq.Enabled = True
        T_Dir_Con.Enabled = True
        T_Dir_Maq.Enabled = True
        T_Ger_Con.Enabled = True
        T_Delegacion.Enabled = True
        T_CP.Enabled = True
        T_Pais.Enabled = True
        T_Telefono.Enabled = True
        T_Fax.Enabled = True
        T_Abreviatura.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"


        H_Pais.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=PAIS',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Pais.Attributes.Add("style", "cursor:pointer;")
        TB_Descripcion.Enabled = False
        TB_Numero.Enabled = False
        Ch_Baja.Enabled = False
        RB_Activa.Enabled = True

    End Sub
    Private Sub LLenaGrid()
        Session("dt") = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
    Private Function LLena_Datatable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            Session("dt").Rows.Clear()
            G.cn.Open()
            G.Tsql = "Select Cia,Obra,Descripcion,Direccion,Colonia,Ciudad,Estado,Delegacion,CP,Pais,Telefono,Fax,Activa,"
            G.Tsql &= "Sup_Maq,Año_Proceso,Mes_Proceso,Sup_Con,Dir_Maq,Dir_Con,Ger_Con,Baja,Abreviatura,Mail_Sup_Maq,Mail_Sup_Con,Mail_Dir_Maq,Mail_Dir_Con,Mail_Ger_Con,Prefijo_Envio,Folio_Envio,Orden_Trabajo,Numero_Requisicion,Numero_Orden from Obra "
            G.Tsql &= " Where Cia=" & Val(BList_Empresa.SelectedValue)
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*'"
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If TB_Numero.Text.Trim <> "" Then
                G.Tsql &= " and Obra =" & Pone_Apos(TB_Numero.Text.Trim)
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            If CB_Activo.Checked = True Then
                G.Tsql &= " and Activa='S' "
            Else
                G.Tsql &= " and Activa<>'S' "
            End If
            G.Tsql &= " Order by Obra"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
            For Each f As DataRow In Session("dt").rows
                If f("Activa") <> "S" Then
                    f("Activa") = "N"
                End If
            Next
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function
    Private Sub LimpiaCampos()
        T_Numero.Text = ""
        T_Año.Text = ""
        T_Mes.Text = ""
        T_Colonia.Text = ""
        T_Ciudad.Text = ""
        T_Estado.Text = ""
        T_Delegacion.Text = ""
        T_CP.Text = ""
        T_Pais.Text = ""
        T_Telefono.Text = ""
        T_Fax.Text = ""
        T_Abreviatura.Text = ""
        T_Desc_Pais.Text = ""
        T_Sup_Con.Text = ""
        T_Sup_Maq.Text = ""
        T_Dir_Con.Text = ""
        T_Dir_Maq.Text = ""
        T_Ger_Con.Text = ""
        Mail_Dir_Con.Text = ""
        Mail_Dir_Maq.Text = ""
        Mail_Ger_Con.Text = ""
        Mail_Sup_Con.Text = ""
        Mail_Sup_Maq.Text = ""
        T_Prefijo_Envio.Text = ""
        T_Folio_Envio.Text = ""
        T_Orden_Trabajo.Text = ""
        RB_Activa.SelectedIndex = 0
        'List_Empresa.SelectedValue = 1
    End Sub
    'Private Function Siguiente() As Integer
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Siguiente = 0
    '    Try
    '        G.cn.Open()
    '        G.Tsql = "Select Max(Clasificacion) from Clasificacion Where Cia=" & Val(Session("Cia"))
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

        If T_Año.Text.Trim = "" Then
            Msg_Error("Año inválido") : Exit Function
        End If
        If T_Numero.Text.Trim = "" Then
            Msg_Error("Mes Inválido") : Exit Function
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
        GridView1.Enabled = False
        Pnl_Registro.Enabled = True
    End Sub
    Private Function A_SN(ByVal valor As Integer) As String
        A_SN = "N"
        If valor = 0 Then
            A_SN = "S"
        End If
    End Function
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Nombre As String)
        Session("dt").Rows.Clear()
        Dim f As DataRow = Session("dt").NewRow()
        'f("Cia") = Val(List_Empresa.SelectedValue)
        f("Obra") = Numero
        f("Descripcion") = Nombre
        f("Direccion") = T_Mes.Text
        f("Colonia") = T_Colonia.Text
        f("Ciudad") = T_Ciudad.Text
        f("Estado") = T_Estado.Text
        f("Delegacion") = T_Delegacion.Text
        f("CP") = T_CP.Text
        f("Pais") = Val(T_Pais.Text)
        f("Telefono") = T_Telefono.Text
        f("Fax") = T_Fax.Text
        f("Abreviatura") = T_Abreviatura.Text
        f("Sup_Con") = T_Sup_Con.Text
        f("Sup_Maq") = T_Sup_Maq.Text
        f("Dir_Con") = T_Dir_Con.Text
        f("Dir_Maq") = T_Dir_Maq.Text
        f("Ger_Con") = T_Ger_Con.Text
        f("Folio_Envio") = Val(T_Folio_Envio.Text)
        f("Prefijo_Envio") = T_Prefijo_Envio.Text
        f("Orden_Trabajo") = Val(T_Orden_Trabajo.Text)
        f("Mail_Sup_Con") = Mail_Sup_Con.Text
        f("Mail_Sup_Maq") = Mail_Sup_Maq.Text
        f("Mail_Dir_Con") = Mail_Dir_Con.Text
        f("Mail_dir_Maq") = Mail_Dir_Maq.Text
        f("Mail_Ger_Con") = Mail_Ger_Con.Text
        f("Numero_Requisicion") = Val(T_Num_Req.Text)
        f("Numero_Orden") = Val(T_Num_Ord.Text)
        If RB_Activa.SelectedIndex = 0 Then
            f("Activa").Equals("S")
        Else
            f("Activa").Equals("N")
        End If


        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Nombre As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            'f("Cia") = Val(List_Empresa.SelectedValue)
            f("Descripcion") = Nombre
            f("Direccion") = T_Mes.Text
            f("Colonia") = T_Colonia.Text
            f("Ciudad") = T_Ciudad.Text
            f("Estado") = T_Estado.Text
            f("Delegacion") = T_Delegacion.Text
            f("CP") = T_CP.Text
            f("Pais") = Val(T_Pais.Text)
            f("Telefono") = T_Telefono.Text
            f("Fax") = T_Fax.Text
            f("Abreviatura") = T_Abreviatura.Text
            f("Sup_Con") = T_Sup_Con.Text
            f("Sup_Maq") = T_Sup_Maq.Text
            f("Dir_Con") = T_Dir_Con.Text
            f("Dir_Maq") = T_Dir_Maq.Text
            f("Ger_Con") = T_Ger_Con.Text
            f("Folio_Envio") = Val(T_Folio_Envio.Text)
            f("Prefijo_Envio") = T_Prefijo_Envio.Text
            f("Orden_Trabajo") = Val(T_Orden_Trabajo.Text)
            f("Mail_Sup_Con") = Mail_Sup_Con.Text
            f("Mail_Sup_Maq") = Mail_Sup_Maq.Text
            f("Mail_Dir_Con") = Mail_Dir_Con.Text
            f("Mail_dir_Maq") = Mail_Dir_Maq.Text
            f("Mail_Ger_Con") = Mail_Ger_Con.Text
            f("Numero_Requisicion") = Val(T_Num_Req.Text)
            f("Numero_Orden") = Val(T_Num_Ord.Text)
            If RB_Activa.SelectedIndex = 0 Then
                f("Activa").Equals("S")
            Else
                f("Activa").Equals("N")
            End If
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
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Movimiento.Value = "Cambio"
        Dim Mes_Actual As Integer = Date.Now.Month.ToString
        Dim Año_Actual As Integer = Date.Now.Year.ToString
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try



            If Movimiento.Value = "Alta" Then

            End If
            If Movimiento.Value = "Cambio" Then
                If Elimina_Comas(T_Mes.Text) = "" Then
                    Msg_Err.Visible = True
                    Msg_Err.Text = "Falta el numero de Mes"
                    Exit Sub
                End If
                If Elimina_Comas(T_Año.Text) = "" Then
                    Msg_Err.Visible = True
                    Msg_Err.Text = "Falta el numero de Año"
                    Exit Sub
                End If
                If Val(Elimina_Comas(T_Mes.Text)) = 0 Then
                    Msg_Err.Visible = True
                    Msg_Err.Text = "Falta el numero de Mes"
                    Exit Sub
                End If
                If Val(Elimina_Comas(T_Año.Text)) = 0 Then
                    Msg_Err.Visible = True
                    Msg_Err.Text = "Falta el numero de Año"
                    Exit Sub
                End If
                If Elimina_Comas(T_Mes.Text) < 0 Or Elimina_Comas(T_Mes.Text) > 12 Then
                    Msg_Err.Visible = True
                    Msg_Err.Text = "El numero de Mes debe ser mayor a 0 y a menor 12"
                    Exit Sub
                End If
                Try
                    Dim mes As String = ""
                    If T_Mes.Text >= 10 Then
                        mes = T_Mes.Text
                    Else
                        mes = "0" & T_Mes.Text
                    End If
                    Dim dia_mes As Integer = Date.DaysInMonth(T_Año.Text, T_Mes.Text).ToString
                    G.cn.Open()
                    G.Tsql = "Select Max(Fecha_Lote) from Movimientos_Inventario "
                    G.Tsql &= " Where Compania=" & G.Empresa_Numero
                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                    G.Tsql &= " and Fecha_Lote >" & Pone_Apos(T_Año.Text & "/" & mes & "/" & dia_mes)


                    Dim m As String = ""
                    G.com.CommandText = G.Tsql
                    Dim result As Object = G.com.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        m = result.ToString()
                    End If
                    If m = "" Or IsDBNull(m) Then
                    Else
                        Msg_Err.Visible = True
                        Msg_Err.Text = "Año y Mes " & Pone_Apos(T_Año.Text & "/" & mes) & " inferiores a registro de movimientos con fecha " & Pone_Apos(m)
                        T_Mes.Text = Month(m).ToString
                        T_Año.Text = Year(m).ToString
                        Exit Sub
                    End If

                Catch ex As Exception
                    Msg_Error(ex.InnerException.ToString)
                Finally
                    G.cn.Close()
                End Try

                G.cn.Open()
                G.Tsql = "Update Obra set Año_Proceso=" & Pone_Apos(T_Año.Text.Trim)
                G.Tsql &= ",Mes_Proceso=" & Pone_Apos(T_Mes.Text.Trim)
                G.Tsql &= " Where Cia=" & Val(G.Empresa_Numero)
                G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                Response.Redirect("~/Menu.aspx")
            End If
            If Movimiento.Value = "Baja" Then
            End If

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
                '   List_Empresa.SelectedValue = f("Cia")
                T_Numero.Text = f("Obra")
                T_Año.Text = f("Año_Proceso")
                T_Mes.Text = f("Mes_Proceso")
                T_Colonia.Text = f("Colonia")
                T_Ciudad.Text = f("Ciudad")
                T_Estado.Text = f("Estado")
                T_Delegacion.Text = f("Delegacion")
                T_CP.Text = f("CP")
                T_Pais.Text = Val(f("Pais"))
                T_Telefono.Text = f("Telefono")
                T_Fax.Text = f("Fax")
                T_Abreviatura.Text = f("Abreviatura")
                T_Sup_Con.Text = f("Sup_Con")
                T_Sup_Maq.Text = f("Sup_Maq")
                T_Dir_Con.Text = f("Dir_Con")
                T_Dir_Maq.Text = f("Dir_Maq")
                T_Ger_Con.Text = f("Ger_Con")
                T_Folio_Envio.Text = f("Folio_Envio")
                T_Prefijo_Envio.Text = f("Prefijo_Envio")
                T_Orden_Trabajo.Text = f("Orden_Trabajo")
                Mail_Sup_Con.Text = f("Mail_Sup_Con")
                Mail_Sup_Maq.Text = f("Mail_Sup_Maq")
                Mail_Dir_Con.Text = f("Mail_Dir_Con")
                Mail_Dir_Maq.Text = f("Mail_dir_Maq")
                Mail_Ger_Con.Text = f("Mail_Ger_Con")
                T_Num_Req.Text = f("Numero_Requisicion")
                T_Num_Ord.Text = f("Numero_Orden")
                If f("Activa").Equals("S") Then
                    RB_Activa.SelectedIndex = 0
                Else
                    RB_Activa.SelectedIndex = 1
                End If
                GridView1.Enabled = False

                Dim G As Glo = CType(Session("G"), Glo)
                G.cn.Open()
                G.Tsql = "Select Descripcion from Pais"
                G.Tsql &= " where Numero=" & Pone_Apos(f("Pais"))
                G.Tsql &= " and Cia=" & G.Empresa_Numero
                G.com.CommandText = G.Tsql
                Dim Desc_Pais As String = G.com.ExecuteScalar
                T_Desc_Pais.Text = Desc_Pais
                G.cn.Close()
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                
                Pnl_Registro.Enabled = False
                H_Pais.Attributes.Add("Onclick", "")
                H_Pais.Attributes.Add("style", "cursor:not-allowed;")
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                H_Pais.Attributes.Add("Onclick", "")
                H_Pais.Attributes.Add("style", "cursor:not-allowed;")
            End If


            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Año.Focus()
                Habilita()
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                T_Numero.Enabled = False
                List_Empresa.Enabled = False
            End If

        End If
    End Sub
    Protected Sub Ima_Busca_Click(sender As Object, e As System.EventArgs) Handles Ima_Busca.Click


        GridView1.Visible = True
        Pnl_Grids.Visible = True
        dt = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
    Protected Sub Ima_Restaura_Click(sender As Object, e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex)("Obra").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f("Obra")
            T_Año.Text = f("Descripcion")
            T_Mes.Text = f("Direccion")
            T_Colonia.Text = f("Colonia")
            T_Ciudad.Text = f("Ciudad")
            T_Estado.Text = f("Estado")
            T_Delegacion.Text = f("Delegacion")
            T_CP.Text = f("CP")
            T_Pais.Text = f("Pais")
            T_Telefono.Text = f("Telefono")
            T_Fax.Text = f("Fax")
            T_Abreviatura.Text = f("Abreviatura")
        End If
    End Sub
    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub

    
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub CB_Activo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB_Activo.CheckedChanged
        LLenaGrid()
    End Sub

    Protected Sub BList_Empresa_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles BList_Empresa.SelectedIndexChanged
        GridView1.Visible = True
        Pnl_Grids.Visible = True
        dt = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
End Class