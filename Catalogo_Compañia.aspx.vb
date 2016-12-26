Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Drawing

Partial Class Catalogo_Compañia
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
        T_CP.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_CP.ClientID & "');")
        'T_Fcancelacion.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Fcancelacion.ClientID & "');")
        'T_Fresguardo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Fresguardo.ClientID & "');")
        'T_Fsalidas.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Fsalidas.ClientID & "');")
        'T_Formato_Orden.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Formato_Orden.ClientID & "');")
        'T_Formato_Requisicion.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Formato_Requisicion.ClientID & "');")
        'T_Max_Pedidos.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Max_Pedidos.ClientID & "');")
        'T_Max_Registros.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Max_Registros.ClientID & "');")
        'T_Mes_Procesos.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Mes_Procesos.ClientID & "');")
        T_Num_Almacen.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Num_Almacen.ClientID & "');")
        'T_Num_Lote.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Num_Lote.ClientID & "');")
        T_Num_Orden.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Num_Orden.ClientID & "');")
        T_Num_Requisicion.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Num_Requisicion.ClientID & "');")
        Msg_Err.Visible = False
        Nom_Imagen.Visible = False
        T_Numero.Attributes.Add("onfocus", "this.select();")

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
        'Tabla Compañia      
        Session("dt").Columns.Add("Cia", Type.GetType("System.Int64")) : Session("dt").Columns("Cia").DefaultValue = 0
        Session("dt").Columns.Add("Razon_Social", Type.GetType("System.String")) : Session("dt").Columns("Razon_Social").DefaultValue = ""
        Session("dt").Columns.Add("Adicional", Type.GetType("System.String")) : Session("dt").Columns("Adicional").DefaultValue = ""
        Session("dt").Columns.Add("RFC", Type.GetType("System.String")) : Session("dt").Columns("RFC").DefaultValue = ""
        Session("dt").Columns.Add("Colonia", Type.GetType("System.String")) : Session("dt").Columns("Colonia").DefaultValue = ""
        Session("dt").Columns.Add("Direccion", Type.GetType("System.String")) : Session("dt").Columns("Direccion").DefaultValue = ""
        Session("dt").Columns.Add("Estado", Type.GetType("System.String")) : Session("dt").Columns("Estado").DefaultValue = ""
        Session("dt").Columns.Add("Codigo_Postal", Type.GetType("System.Int64")) : Session("dt").Columns("Codigo_Postal").DefaultValue = 0
        Session("dt").Columns.Add("Telefono", Type.GetType("System.String")) : Session("dt").Columns("Telefono").DefaultValue = ""
        Session("dt").Columns.Add("Almacen", Type.GetType("System.Int64")) : Session("dt").Columns("Almacen").DefaultValue = 0
        Session("dt").Columns.Add("Clave_Acceso", Type.GetType("System.String")) : Session("dt").Columns("Clave_Acceso").DefaultValue = ""
        Session("dt").Columns.Add("Logo", Type.GetType("System.String")) : Session("dt").Columns("Logo").DefaultValue = ""
        Session("dt").Columns.Add("Height", Type.GetType("System.Int64")) : Session("dt").Columns("Height").DefaultValue = 0
        Session("dt").Columns.Add("Width", Type.GetType("System.Int64")) : Session("dt").Columns("Width").DefaultValue = 0
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Cia")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        fileUploader1.Enabled = True
        T_Numero.Enabled = False
        T_Razon_Social.Enabled = False
        T_Adicional.Enabled = False
        T_RFC.Enabled = False
        T_Colonia.Enabled = False
        T_Direccion.Enabled = False
        T_Estado.Enabled = False
        T_CP.Enabled = False
        T_Telefono.Enabled = False
        'T_Fcancelacion.Enabled = False
        'T_Fresguardo.Enabled = False
        'T_Fsalidas.Enabled = False
        'T_Formato_Orden.Enabled = False
        'T_Formato_Requisicion.Enabled = False
        'T_Max_Pedidos.Enabled = False
        'T_Max_Registros.Enabled = False
        'T_Mes_Procesos.Enabled = False
        'T_Num_Lote.Enabled = False
        T_Num_Orden.Enabled = False
        T_Num_Requisicion.Enabled = False
        T_Num_Almacen.Enabled = False
        T_Clave_Acceso.Enabled = False
        T_Width.Enabled = False
        T_Height.Enabled = False
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        Msg_Err.Visible = False
        GridView1.Enabled = True
        TB_Numero.Enabled = True
        TB_Descripcion.Enabled = True
        Nom_Imagen.Visible = False

    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False

        TB_Numero.Enabled = False
        TB_Descripcion.Enabled = False
        T_Numero.Enabled = True
        T_Razon_Social.Enabled = True
        T_Adicional.Enabled = True
        T_RFC.Enabled = True
        T_Colonia.Enabled = True
        T_Direccion.Enabled = True
        T_Estado.Enabled = True
        T_CP.Enabled = True
        T_Telefono.Enabled = True
        'T_Fcancelacion.Enabled = True
        T_Width.Enabled = True
        T_Height.Enabled = True
        'T_Fresguardo.Enabled = True
        'T_Fsalidas.Enabled = True
        'T_Formato_Orden.Enabled = True
        'T_Formato_Requisicion.Enabled = True
        'T_Max_Pedidos.Enabled = True
        'T_Max_Registros.Enabled = True
        'T_Mes_Procesos.Enabled = True
        'T_Num_Lote.Enabled = True
        T_Num_Orden.Enabled = True
        T_Num_Requisicion.Enabled = True
        T_Num_Almacen.Enabled = True
        T_Clave_Acceso.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        GridView1.Enabled = False
        Nom_Imagen.Visible = True

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
            G.Tsql = "Select Cia,Razon_Social,Adicional,RFC,Colonia,Direccion,Estado,Codigo_Postal,Telefono,Almacen,Clave_Acceso,Logo,Height,Width from Compañias "
            G.Tsql &= " Where Cia<>0 "
            If Val(TB_Numero.Text.Trim) <> 0 Then
                G.Tsql &= " and Cia =" & Val(TB_Numero.Text.Trim)
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Razon_Social like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            G.Tsql &= " Order by Cia"
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
        T_Razon_Social.Text = ""
        T_Adicional.Text = ""
        T_RFC.Text = ""
        T_Colonia.Text = ""
        T_Direccion.Text = ""
        T_Estado.Text = ""
        T_CP.Text = ""
        T_Telefono.Text = ""
        'T_Fcancelacion.Text = ""
        'T_Fresguardo.Text = ""
        'T_Fsalidas.Text = ""
        'T_Formato_Orden.Text = ""
        'T_Formato_Requisicion.Text = ""
        'T_Max_Pedidos.Text = ""
        'T_Max_Registros.Text = ""
        'T_Mes_Procesos.Text = ""
        'T_Num_Lote.Text = ""
        T_Num_Orden.Text = ""
        T_Num_Requisicion.Text = ""
        T_Num_Almacen.Text = ""
        T_Clave_Acceso.Text = ""
        T_Height.Text = ""
        T_Width.Text = ""

    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Cia) from Compañias"
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
        If Val(T_Numero.Text.Trim) = 0 Then Msg_Error("Numero invalido") : Exit Function
        If T_Razon_Social.Text.Trim = "" Then Msg_Error("Nombre inválida") : Exit Function
        If T_Adicional.Text.Trim = "" Then Msg_Error("Adicional inválida") : Exit Function
        If T_RFC.Text.Trim.Length < 12 Then Msg_Error("RFC inválido, debe contener minimo 12 caracteres") : Exit Function
        If T_Colonia.Text.Trim = "" Then Msg_Error("Colonia inválida") : Exit Function
        If T_Direccion.Text.Trim = "" Then Msg_Error("Direccion inválida") : Exit Function
        If T_Estado.Text.Trim = "" Then Msg_Error("Estado inválido") : Exit Function
        If Val(T_CP.Text.Trim) = 0 Then Msg_Error("Codigo Postal inválido") : Exit Function
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Razon_Social As String, ByVal RFC As String)
        Dim f As DataRow = Session("dt").NewRow()
        Dim G As Glo = CType(Session("G"), Glo)
        f("Cia") = Numero
        f("Razon_Social") = Razon_Social
        f("RFC") = RFC
        f("Colonia") = T_Colonia.Text
        f("Direccion") = T_Direccion.Text.Trim
        f("Estado") = T_Estado.Text
        f("Codigo_Postal") = Val(T_CP.Text)
        f("Telefono") = T_Telefono.Text
        'f("Numero_Orden") = Val(T_Num_Orden.Text)
        'f("Numero_Requisicion") = Val(T_Num_Requisicion.Text)
        f("Almacen") = Val(T_Num_Almacen.Text)
        f("Clave_Acceso") = T_Clave_Acceso
        f("Logo") = G.Nombre_Imagen
        f("Height") = Val(T_Height.Text)
        f("Width") = Val(T_Width.Text)
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Razon_Social As String, ByVal RFC As String)
        Dim clave(0) As String
        Dim G As Glo = CType(Session("G"), Glo)
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Razon_Social") = Razon_Social
            f("RFC") = RFC
            f("Colonia") = T_Colonia.Text
            f("Direccion") = T_Direccion.Text.Trim
            f("Estado") = T_Estado.Text
            f("Codigo_Postal") = Val(T_CP.Text)
            f("Telefono") = T_Telefono.Text
            'f("Numero_Orden") = Val(T_Num_Orden.Text)
            'f("Numero_Requisicion") = Val(T_Num_Requisicion.Text)
            f("Almacen") = Val(T_Num_Almacen.Text)
            f("Clave_Acceso") = T_Clave_Acceso
            f("Logo") = G.Nombre_Imagen
            f("Height") = Val(T_Height.Text)
            f("Width") = Val(T_Width.Text)
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
        T_Numero.Enabled = False
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Numero.Text = Siguiente()
        T_Numero.Focus()
        Pnl_Registro.Enabled = True
    End Sub

    Protected Sub Ima_Restaura_Click(sender As Object, e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Dim ext As String
        Try
            If fileUploader1.PostedFile Is Nothing Then
                ext = ""
            Else
                ext = fileUploader1.PostedFile.FileName
            End If
            Dim formatos() As String = {"jpg", "jpeg", "bmp", "png", "gif"}
            Dim nombre As String = fileUploader1.FileName
            Dim Logo_Cia As String = ""
            If Nombre_Imagen.Value > "" Then Logo_Cia = Nombre_Imagen.Value

            If fileUploader1.HasFile Then
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
                If Array.IndexOf(formatos, ext) < 0 Then
                    Msg_Error("Formato de imagen inválido.") : Exit Sub
                Else
                    GuardarArchivo(fileUploader1.PostedFile, Val(T_Height.Text), Val(T_Width.Text))
                    Logo_Cia = fileUploader1.FileName
                End If
                '  Else
                '      Logo_Cia = Server.MapPath("~/Trabajo/null.png")
            End If
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                T_Numero.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select Razon_Social from Compañias where Razon_Social=" & Pone_Apos(T_Razon_Social.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el La Rason Social") : Exit Sub
                End If
                G.Tsql = "Insert into Compañias (Cia,Razon_Social,Adicional,RFC,Colonia,Direccion,Estado,Codigo_Postal,Telefono,Numero_Orden,Numero_Requisicion,Almacen,Clave_Acceso,Logo,Height,Width) values ("
                G.Tsql &= Val(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Razon_Social.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Adicional.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_RFC.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Colonia.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Estado.Text.Trim)
                G.Tsql &= "," & Val(T_CP.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Telefono.Text.Trim)
                'G.Tsql &= "," & Val(T_Fcancelacion.Text.Trim)
                'G.Tsql &= "," & Val(T_Fresguardo.Text.Trim)
                'G.Tsql &= "," & Val(T_Fsalidas.Text.Trim)
                'G.Tsql &= "," & Val(T_Formato_Orden.Text.Trim)
                'G.Tsql &= "," & Val(T_Formato_Requisicion.Text.Trim)
                'G.Tsql &= "," & Val(T_Max_Pedidos.Text.Trim)
                'G.Tsql &= "," & Val(T_Max_Registros.Text.Trim)
                'G.Tsql &= "," & Val(T_Mes_Procesos.Text.Trim)
                'G.Tsql &= "," & Val(T_Num_Lote.Text.Trim)
                G.Tsql &= "," & Val(T_Num_Orden.Text.Trim)
                G.Tsql &= "," & Val(T_Num_Requisicion.Text.Trim)
                G.Tsql &= "," & Val(T_Num_Almacen.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Clave_Acceso.Text.Trim)
                G.Tsql &= "," & Pone_Apos(Path.GetFileName(Logo_Cia))
                G.Tsql &= "," & Val(T_Height.Text.Trim)
                G.Tsql &= "," & Val(T_Width.Text.Trim) & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Razon_Social.Text.Trim, T_RFC.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Compañias set Cia=" & Val(T_Numero.Text.Trim)
                G.Tsql &= ",Razon_social=" & Pone_Apos(T_Razon_Social.Text.Trim)
                G.Tsql &= ",Adicional=" & Pone_Apos(T_Adicional.Text.Trim)
                G.Tsql &= ",RFC=" & Pone_Apos(T_RFC.Text.Trim)
                G.Tsql &= ",Colonia=" & Pone_Apos(T_Colonia.Text.Trim)
                G.Tsql &= ",Direccion=" & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= ",Estado=" & Pone_Apos(T_Estado.Text.Trim)
                G.Tsql &= ",Codigo_Postal=" & Val(T_CP.Text.Trim)
                G.Tsql &= ",Telefono=" & Pone_Apos(T_Telefono.Text.Trim)
                'G.Tsql &= ",Folio_Cancelacion=" & Val(T_Fcancelacion.Text.Trim)
                'G.Tsql &= ",Folio_Resguardo=" & Val(T_Fresguardo.Text.Trim)
                'G.Tsql &= ",Folio_Salidas=" & Val(T_Fsalidas.Text.Trim)
                'G.Tsql &= ",Formato_Orden=" & Val(T_Formato_Orden.Text.Trim)
                'G.Tsql &= ",Formato_Requisicion=" & Val(T_Formato_Requisicion.Text.Trim)
                'G.Tsql &= ",Maximo_Pedido=" & Val(T_Max_Pedidos.Text.Trim)
                'G.Tsql &= ",Maximo_Registros=" & Val(T_Max_Registros.Text.Trim)
                'G.Tsql &= ",Mes_Proceso=" & Val(T_Mes_Procesos.Text.Trim)
                'G.Tsql &= ",Numero_Lote=" & Val(T_Num_Lote.Text.Trim)
                'G.Tsql &= ",Numero_Orden=" & Val(T_Num_Orden.Text.Trim)
                'G.Tsql &= ",Numero_Requisicion=" & Val(T_Num_Requisicion.Text.Trim)
                G.Tsql &= ",Almacen=" & Val(T_Num_Almacen.Text.Trim)
                G.Tsql &= ",Clave_Acceso=" & Pone_Apos(T_Clave_Acceso.Text.Trim)
                G.Tsql &= ",Logo=" & Pone_Apos(Path.GetFileName(Logo_Cia))
                G.Tsql &= ",Height=" & Val(T_Height.Text.Trim)
                G.Tsql &= ",Width=" & Val(T_Width.Text.Trim)
                G.Tsql &= " Where Cia=" & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Razon_Social.Text.Trim, T_RFC.Text.Trim)
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
                T_Numero.Text = f.Item("Cia")
                T_Razon_Social.Text = f.Item("Razon_Social")
                T_Adicional.Text = f.Item("Adicional")
                T_RFC.Text = f.Item("RFC")
                T_Colonia.Text = f.Item("Colonia")
                T_Direccion.Text = f.Item("Direccion")
                T_Estado.Text = f.Item("Estado")
                T_CP.Text = f.Item("Codigo_Postal")
                T_Telefono.Text = f.Item("Telefono")
                'T_Fcancelacion.Text = f.Item("Folio_Cancelacion")
                'T_Fresguardo.Text = f.Item("Folio_Resguardo")
                'T_Fsalidas.Text = f.Item("Folio_Salidas")
                'T_Formato_Orden.Text = f.Item("Formato_Orden")
                'T_Formato_Requisicion.Text = f.Item("Formato_Requisicion")
                'T_Max_Pedidos.Text = f.Item("Maximo_Pedido")
                'T_Max_Registros.Text = f.Item("Maximo_Registros")
                'T_Mes_Procesos.Text = f.Item("Mes_Proceso")
                'T_Num_Lote.Text = f.Item("Numero_Lote")
                'T_Num_Orden.Text = f.Item("Numero_Orden")
                'T_Num_Requisicion.Text = f.Item("Numero_Requisicion")
                T_Num_Almacen.Text = f.Item("Almacen")
                T_Clave_Acceso.Text = f.Item("Clave_Acceso")
                Nombre_Imagen.Value = f.Item("Logo")
                T_Height.Text = f.Item("Height")
                T_Width.Text = f.Item("Width")
                Nom_Imagen.Text = "Imagen guardada: " & f.Item("Logo")
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                fileUploader1.Enabled = False
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Razon_Social.Focus()
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

    Public Function Imagen_A_Bytes(ByVal ruta As String) As Byte()
        Dim foto As New FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim arreglo(0 To foto.Length - 1) As Byte
        Dim reader As New BinaryReader(foto)
        arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length))
        foto.Flush()
        foto.Close()
        Return arreglo
    End Function
    Private Function GuardarArchivo(file As HttpPostedFile, height As Integer, width As Integer) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Dim ruta As String = Server.MapPath("~/Trabajo")
        Dim archivo As String = String.Format("{0}\\{1}", ruta, file.FileName)
        GuardarArchivo = ""
        If Directory.Exists(ruta) Then
            If IO.File.Exists(archivo) Then
                IO.File.Delete(archivo)
                Msg_Error("Vuelve a Seleccionar tu archivo")
            Else
                Dim alto As Integer = height
                Dim ancho As Integer = width
                Dim bytes As Byte() = New Byte(file.InputStream.Length - 1) {}
                file.InputStream.Read(bytes, 0, bytes.Length)
                bytes = ResizeImage(bytes, height, width)
                Using ms As New MemoryStream(bytes)
                    Dim img As Image = Image.FromStream(ms)
                    img.Save(archivo, System.Drawing.Imaging.ImageFormat.Png)
                    GuardarArchivo = file.FileName
                    Session("Logo_Height") = Val(T_Height.Text)
                    Session("Logo_Width") = Val(T_Width.Text)
                    Session("Imagen") = file.FileName
                    G.Nombre_Imagen = Session("Imagen")
                    'Try
                    '    Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                    '    Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                    '    Image1.Style("Width") = Int(Session("Logo_Width")) & "px"

                    'Catch ex As Exception

                    'End Try

                    Nombre_Imagen.Value = Server.MapPath("~/Trabajo/" & file.FileName)
                    ms.Flush()
                    ms.Close()
                End Using
            End If
        Else
            Directory.CreateDirectory(ruta)
        End If
    End Function

    Public Shared Function ResizeImage(source As Byte(), Optional newH As Integer = 0, Optional newW As Integer = 0) As Byte()
        Dim res As Byte() = Nothing
        ' Se define un tamaño predeterminado, para el caso de que no se le dé valor a la variable size
        ' El arreglo de bytes será convertido a un Stream dentro del método, el cual será vaciado al final de la operación para liberar la imagen.
        ' Esto es muy útil cuando se está leyendo la imagen desde un archivo del disco, pues si el objeto Stream queda abierto, el archivo puede ser bloqueado.
        Using ms As New MemoryStream(source, 0, source.Length)
            ' Se utiliza un objeto Image para leer el contenido de la imagen
            Dim img As Image = Image.FromStream(ms)
            Dim h As Integer = img.Height, w As Integer = img.Width
            If h <> newH And w <> newW Or h = newH And w <> newW Or h <> newH And w = newW Then
                ' Para cambiar el tamaño de la imagen, usamos un nuevo objeto Image, dentro del cual guardaremos la imagen redimensionada
                Using newImg As New Bitmap(img, newW, newH)
                    Using g As Graphics = Graphics.FromImage(newImg)
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
                        g.DrawImage(img, 0, 0, newImg.Width, newImg.Height)
                    End Using
                    ' El objeto res será el contenido en bytes de la imagen nueva
                    res = DirectCast(New ImageConverter().ConvertTo(newImg, GetType(Byte())), Byte())
                End Using
            Else
                ' Si no hay diferencias entre el tamaño anterior y el nuevo, el objeto res será el contenido de la imagen original
                res = DirectCast(New ImageConverter().ConvertTo(img, GetType(Byte())), Byte())
            End If
            ' Aquí cerramos el objeto Stream para liberar la imagen. Este paso es necesario para evitar que la imagen se bloquee.
            ms.Flush()
            ms.Close()
        End Using
        Return res
    End Function


End Class
