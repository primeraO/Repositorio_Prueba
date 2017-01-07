Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net

Partial Class C_Entradas
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Sucursal: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Session("dt") = New DataTable
            CrearCamposTabla()
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            'LLenaGrid()
            'DesHabilita()
            Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
            Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
            T_Fecha_Pedido.Text = Fecha_AMD(Now)
            'T_Fecha_Fin.Text = Fecha_AMD(Now)
            T_Pedido.Text = Siguiente()
            T_Partida.Text = SiguientePartida()
            T_Cliente.Focus()

        End If
        H_Cliente.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=CLIENTE&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Cliente.Attributes.Add("style", "cursor:pointer;")
        H_Articulo.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=ARTICULO&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Articulo.Attributes.Add("style", "cursor:pointer;")

        H_imprimir2.Attributes.Add("onclick", "window.open('C_Imp_Entradas.aspx?Catalogo=ALMACEN_DESTINO',null,'left=400, top=100, height=450, width= 990, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_imprimir2.Attributes.Add("style", "cursor:pointer;")
        H_Procesar.Attributes.Add("onclick", "window.open('C_Procesa_Entradas.aspx?Catalogo=ALMACEN_DESTINO',null,'left=400, top=100, height=450, width= 990, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Procesar.Attributes.Add("style", "cursor:pointer;")
        'TB_Entrada.Attributes.Add("onfocus", "this.select();")
        T_Fecha_Pedido.Attributes.Add("onfocus", "this.select();")
        T_Cliente.Attributes.Add("onfocus", "this.select();")
        T_Articulo.Attributes.Add("onfocus", "this.select();")
        T_Cantidad_Pedida.Attributes.Add("onfocus", "this.select();")
       

        Msg_Err.Visible = False

        DibujaSpan()
    End Sub
    Private Sub DibujaSpan()
        Dim dtspan As New DataTable
        dtspan = Session("dt").Copy
        If Session("dt").Rows.Count = 0 Then
            Dim f As DataRow = dtspan.NewRow()
            f("Partida") = 0
            f("Fecha") = ""
            ' f("Pedido") = 0
            'f("Cantidad") = 0
            ' f("Solicitante") = 0
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
    Private Sub LimpiaCampos()
        T_Articulo.Text = 0
        T_Articulo_Desc.Text = ""
        T_Iva.Text = ""
        T_Precio_Unitario.Text = ""
        T_Cantidad_Pedida.Text = ""
        T_Marca_Desc.Text = ""
        T_Marca.Text = ""
        T_Unidad_Medida.Text = ""

    End Sub
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Partida", GetType(System.String)) : Session("dt").Columns("Partida").DefaultValue = 0
        Session("dt").Columns.Add("Fecha", GetType(System.String)) : Session("dt").Columns("Fecha").DefaultValue = ""
        Session("dt").Columns.Add("Articulo", GetType(System.String)) : Session("dt").Columns("Articulo").DefaultValue = 0
        Session("dt").Columns.Add("Descripcion", GetType(System.String)) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Precio_Unitario", GetType(System.Double)) : Session("dt").Columns("Precio_Unitario").DefaultValue = 0
        Session("dt").Columns.Add("Iva", GetType(System.Double)) : Session("dt").Columns("Iva").DefaultValue = 0
        Session("dt").Columns.Add("Total", GetType(System.Double)) : Session("dt").Columns("Total").DefaultValue = 0

        Session("dt").Columns.Add("Cantidad", GetType(System.Double)) : Session("dt").Columns("Cantidad").DefaultValue = 0
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Cambio", Type.GetType("System.String")) : Session("dt").Columns("Cambio").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Partida")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Function validar() As Boolean
        validar = False
        If Val(T_Cliente.Text.Trim) = 0 Or T_Cliente.Text = "" Then
            Msg_Error("Cliente Inválido") : Exit Function
        End If
        If Val(T_Articulo.Text.Trim) = 0 Or T_Articulo.Text = "" Then
            Msg_Error("Articulo Inválido") : Exit Function
        End If
        If Not IsDate(T_Fecha_Pedido.Text.Trim) Then
            Msg_Error("Fecha  Inválida") : Exit Function
        End If
        If T_Cliente_Desc.Text = "" Then
            Msg_Error("Cliente  Inválido") : Exit Function
        End If
        If Val(T_Cantidad_Pedida.Text) = 0 Or T_Cantidad_Pedida.Text = "" Then
            Msg_Error("Cantidad  Inválida") : Exit Function
        End If
        If T_Partida.Text = "" Or Val(T_Partida.Text) = 0 Then
            Msg_Error("Partida  Inválida") : Exit Function
        End If
        If T_Pedido.Text = "" Or Val(T_Pedido.Text) = 0 Then
            Msg_Error("Pedido  Inválida") : Exit Function
        End If
        Dim precio = Convert.ToDouble(Elimina_Comas(T_Precio_Unitario.Text))

        If precio = 0 Or T_Precio_Unitario.Text = "" Then
            Msg_Error("Precio Unitario Invalido") : Exit Function
        End If
        'If Val(T_Fletero.Text.Trim) = 0 Or T_Fletero_Desc.Text.Trim = "" Then
        '    Msg_Error("Fletero inválido") : Exit Function
        'End If
        'If Val(Elimina_Comas(T_Importe.Text)) = 0 Then
        '    Msg_Error("Abreviatura invá lida") : Exit Function
        'End If
        Return True
    End Function
    Private Sub AñadeFilaGrid()
        Dim f As DataRow = Session("dt").NewRow()
        f("Partida") = Val(T_Partida.Text)
        f("Fecha") = T_Fecha_Pedido.Text.Trim
        f("Articulo") = T_Articulo.Text.Trim
        f("Descripcion") = T_Articulo_Desc.Text
        f("Cantidad") = Val(T_Cantidad_Pedida.Text.Trim)
        f("Precio_Unitario") = Val(T_Precio_Unitario.Text.Trim)
        f("Iva") = Val(T_Iva.Text.Trim)
        'f("Pedido") = Val(T_Pedido.Text.Trim)
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    'Private Sub CambiaFilaGrid()
    '    Dim clave(0) As String
    '    clave(0) = Val(T_Entrada.Text)
    '    Dim f As DataRow = Session("dt").Rows.Find(clave)
    '    If Not f Is Nothing Then
    '        f("Fecha_Lote") = T_Fecha_Pedido.Text.Trim
    '        f("UUID") = L_UUID.Text.Trim
    '        f("Solicitante") = Val(T_Cliente.Text.Trim)

    '    End If
    '    GridView1.DataSource = Session("dt")
    '    GridView1.DataBind()
    'End Sub
    'Private Sub EliminaFilaGrid()
    '    Dim clave(0) As String
    '    clave(0) = Val(T_Entrada.Text)
    '    Dim f As DataRow = Session("dt").Rows.Find(clave)
    '    If Not f Is Nothing Then
    '        f.Delete()
    '    End If
    '    GridView1.DataSource = Session("dt")
    '    GridView1.DataBind()
    'End Sub
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
        Dim dt As DataTable = Session("dt")
        Dim dtTodos As New DataTable
        Try
            G.cn.Open()
            dt.Rows.Clear()
            G.Tsql = "Select Numero_Articulo as Articulo,(select Top 1 Fecha_Pedido from Cotiza_Encab where Pedido='" & T_Pedido.Text & "') as Fecha,Descripcion_Articulo as Descripcion,  Partida,Base_Iva as Iva, Precio_Unitario, Cantidad_Pedida as Cantidad from Cotiza_Detalle  where Sucursal='" & G.Sucursal & "' and Numero_Pedido='" & T_Pedido.Text & "' "
            G.Tsql &= " Order by Partida"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
            'For Each f As DataRow In dt.Rows
            '    f("Subtotal") = NuloADouble(dtTodos.Compute("Sum(Costo_Total)", "Lote=" & f("Lote") & " and Partida>0"))
            '    f("Iva") = NuloADouble(dtTodos.Compute("Sum(Iva_Importe)", "Lote=" & f("Lote") & " and Partida>0"))
            '    f("Total") = f("Subtotal") + f("Iva")
            'Next
        Catch ex As Exception
            Msg_Error(ex.Message)
        Finally
            G.cn.Close()
        End Try
        Return dt
    End Function
    'Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
    '    If Me.IsPostBack Then
    '        GridView1.PageIndex = e.NewPageIndex
    '        LLenaGrid()
    '    End If
    'End Sub
    'Private Sub DesHabilita()
    '    TB_Entrada.Enabled = True
    '    T_Entrada.Enabled = False
    '    T_Fecha_Pedido.Enabled = False
    '    T_Cliente.Enabled = False
    '    T_Cliente_Desc.Enabled = False
    '    fileUploader1.Enabled = False
    '    Movimiento.Value = ""
    '    Ima_Restaura.Enabled = False
    '    Ima_Guarda.Enabled = False
    '    Ima_Alta.Enabled = True
    '    Ima_Busca.Enabled = True
    '    'Ima_Regresa.Enabled = True
    '    Ima_Restaura.CssClass = "Btn_Rojo"
    '    Ima_Guarda.CssClass = "Btn_Rojo"
    '    Ima_Alta.CssClass = "Btn_Azul"
    '    'Ima_Regresa.CssClass = "Btn_Azul"
    '    Ima_Busca.CssClass = "Btn_Azul"
    '    GridView1.Enabled = True
    '    Pnl_Grids.Visible = False
    '    'Ch_Baja.Enabled = True

    '    H_Solicitante.Attributes.Add("onclick", "")
    '    H_Solicitante.Attributes.Add("style", "cursor:not-allowed;")

    'End Sub
    'Private Sub Habilita()
    '    'TB_Entrada.Enabled = False
    '    'TB_Fletero_Desc.Enabled = True
    '    T_Entrada.Enabled = True
    '    T_Fecha_Pedido.Enabled = True
    '    'fileUploader1.Enabled = True
    '    T_Cliente.Enabled = True
    '    T_Cliente_Desc.Enabled = True
    '    Ima_Restaura.Enabled = True
    '    Ima_Guarda.Enabled = True
    '    Ima_Alta.Enabled = False
    '    Ima_Busca.Enabled = False
    '    'Ima_Regresa.Enabled = False
    '    Ima_Restaura.CssClass = "Btn_Azul"
    '    Ima_Guarda.CssClass = "Btn_Azul"
    '    Ima_Alta.CssClass = "Btn_Rojo"
    '    'Ima_Regresa.CssClass = "Btn_Rojo"
    '    Ima_Busca.CssClass = "Btn_Rojo"
    '    GridView1.Enabled = False
    '    Pnl_Grids.Visible = False
    '    ' Ch_Baja.Enabled = False

    '    H_Solicitante.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SOLICITANTE',null,'left=400, top=100, height=450, width= 990, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
    '    H_Solicitante.Attributes.Add("style", "cursor:pointer;")
    'End Sub
    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    '    Dim clave(0) As String
    '    clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Lote").ToString
    '    Dim f As DataRow = Session("dt").Rows.Find(clave)
    '    If Not f Is Nothing Then
    '        T_Entrada.Text = f("Lote")
    '        T_Fecha_Pedido.Text = f("Fecha_Lote")
    '        'T_Fletero.Text = f("Fletero")
    '        'T_Fletero_Desc.Text = f("Fletero_Desc").ToString
    '        'T_Importe.Text = For_Pan_Lib(f("Importe_Flete"), 2)
    '        'T_Iva.Text = For_Pan_Lib(f("Iva_Flete"), 2)
    '        'T_Descuento.Text = For_Pan_Lib(f("Descuento"), 2)
    '        'T_Referencia.Text = f("Ref_Flete")
    '    End If
    'End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Then
            Dim G As Glo = CType(Session("G"), Glo)
            Dim Tsql As String = ""

            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                G.cn.Open()
                G.Tsql = "Delete from Cotiza_Detalle where Numero_Pedido =" & Pone_Apos(T_Pedido.Text) & "  and Sucursal=  " & Pone_Apos(G.Sucursal) & " and Partida=" & Pone_Apos(f("Partida"))

                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                G.cn.Close()
            End If
            LLenaGrid()
            Pnl_Grids.Visible = True
            T_Partida.Text = SiguientePartida()
            '    If Not f Is Nothing Then
            '        T_Entrada.Text = f("Lote")
            '        T_Fecha_Pedido.Text = f("Fecha_Lote")
            '        T_Cliente.Text = f("Solicitante")
            '        T_Cliente_Desc.Text = Busca_Cat(Session("G"), "SOLICITANTE", f("Solicitante"))
            '        'T_Fletero.Text = f("Fletero")
            '        'T_Fletero_Desc.Text = f("Fletero_Desc").ToString
            '        'T_Importe.Text = For_Pan_Lib(f("Importe_Flete"), 2)
            '        'T_Iva.Text = For_Pan_Lib(f("Iva_Flete"), 2)
            '        'T_Descuento.Text = For_Pan_Lib(f("Descuento"), 2)
            '        'T_Referencia.Text = f("Ref_Flete")
            '    End If
            '    If (e.CommandName.Equals("Baja")) Then
            '        Movimiento.Value = "Baja"
            '        Habilita()
            '    End If

            '    If (e.CommandName.Equals("Cambio")) Then
            '        Movimiento.Value = "Cambio"
            '        T_Entrada.Enabled = False
            '        T_Fecha_Pedido.Focus()
            '        Habilita()
            '    End If
            'ElseIf e.CommandName.Equals("Partidas") Then
            '    Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            '    Dim G As Glo = CType(Session("G"), Glo)
            '    Dim Clave(0) As String
            '    Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            '    Dim f As DataRow = Session("dt").Rows.Find(Clave)
            '    If Not f Is Nothing Then
            '        T_Entrada.Text = f("Lote")
            '        T_Fecha_Pedido.Text = f("Fecha_Lote")
            '        T_Cliente.Text = f("Solicitante")
            '    End If
            '    G.Tsql = "Select * from Movimientos_Entradas where Lote=" & Val(Clave(0)) & " and Compania=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Obra)
            '    G.Tsql &= " and E_S='E' and Almacen=" & Val(G.Almacen)
            '    G.cn.Open()
            '    G.com.CommandText = G.Tsql
            '    If IsNothing(G.com.ExecuteScalar) Then
            '        G.cn.Close()
            '        LLenaGrid()
            '    Else
            '        G.cn.Close()

            '        Response.Redirect("~/C_Entradas_Detalle.aspx?Lote=" & GridView1.Rows(ind).Cells(1).Text & "&Fecha_Lote=" & T_Fecha_Pedido.Text)

            '    End If

            'ElseIf e.CommandName.Equals("Fletero") Then
            '    Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            '    Dim Clave(0) As String
            '    Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            '    Dim f As DataRow = Session("dt").Rows.Find(Clave)
            '    If Not f Is Nothing Then
            '        T_Entrada.Text = f("Lote")
            '        T_Fecha_Pedido.Text = f("Fecha_Lote")
            '        T_Cliente.Text = f("Solicitante")

            '    End If
            '    Response.Redirect("~/Pop_Proveedor.aspx?Lote=" & GridView1.Rows(ind).Cells(1).Text & "&Fecha_Lote=" & T_Fecha_Pedido.Text)
        End If
        If (e.CommandName.Equals("Cambio")) Then
            Movimiento.Value = "Cambio"
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Cantidad_Pedida.Text = f("Cantidad")
                T_Articulo.Text = f("Articulo")
                T_Articulo_Desc.Text = f("Descripcion")
                T_Partida.Text = f("Partida")
                InformacionArticulo()
            End If
        End If


    End Sub
    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click
        LLenaGrid()
        Pnl_Grids.Visible = True
        'LimpiaCampos()
    End Sub
    'Protected Sub Ima_Alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Alta.Click
    '    Habilita()
    '    T_Fecha_Pedido.Text = Fecha_AMD(Now)
    '    T_Entrada.Enabled = True
    '    LimpiaCampos()
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    ''consultamos periodo de la tabla de obras
    '    'Ch_Baja.Checked = False
    '    Consulta_Periodo()
    '    If G.año_proceso <> Mid(Fecha_AMD(Now), 1, 4) Or G.mes_proceso <> Mid(Fecha_AMD(Now), 6, 2) Then
    '        T_Fecha_Pedido.Text = Fecha_AMD(G.año_proceso & "/" & G.mes_proceso & "/" & Date.DaysInMonth(G.año_proceso, G.mes_proceso))
    '    Else
    '        T_Fecha_Pedido.Text = Fecha_AMD(Now)
    '    End If
    '    Movimiento.Value = "Alta"
    '    T_Entrada.Text = Siguiente()
    '    T_Entrada.Focus()
    'End Sub
    Public Sub InformacionCliente()
        Dim G As Glo = CType(Session("G"), Glo)
        G.Tsql = "Select * from Cliente where Numero=" & Val(T_Cliente.Text)
        G.com.CommandText = G.Tsql
        If G.cn.State = ConnectionState.Open Then
            G.cn.Close()
        End If
        G.cn.Open()
        G.dr = G.com.ExecuteReader
        If G.dr.Read Then
            T_Cliente_Desc.Text = G.dr!Razon_Social
            T_Agente.Text = G.dr!Age_Numero
            T_Ejecutivo.Text = G.dr!Eje_Numero
            'G.mes_proceso = Format(G.dr!mes_proceso, "0#")
        End If
        G.cn.Close()
        InformacionAgente()
        InformacionEjecutivo()
    End Sub
    Public Sub InformacionArticulo()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select * from Articulos where Numero=" & Pone_Apos(T_Articulo.Text)
            G.com.CommandText = G.Tsql

            G.dr = G.com.ExecuteReader
            If G.dr.Read Then
                T_Articulo_Desc.Text = G.dr!Art_Descripcion
                T_Unidad_Medida.Text = G.dr!Unidad_Medida
                T_Precio_Unitario.Text = For_Pan_Lib(G.dr!Pre_Vta_1, 2)
                T_Iva.Text = G.dr!IVA
                T_Marca.Text = G.dr!Mar_Numero
                'G.mes_proceso = Format(G.dr!mes_proceso, "0#")

            End If

            
        Catch ex As Exception
            Msg_Error(ex.ToString)
        Finally
            G.cn.Close()
            InformacionMarca()
        
        End Try
       

    End Sub

    Public Sub InformacionMarca()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select * from Marca where Numero=" & Pone_Apos(T_Marca.Text)
            G.com.CommandText = G.Tsql

            G.dr = G.com.ExecuteReader
            If G.dr.Read Then

                T_Marca_Desc.Text = G.dr!Descripcion
                'G.mes_proceso = Format(G.dr!mes_proceso, "0#")

            End If


        Catch ex As Exception
            Msg_Error(ex.ToString)
        Finally
            G.cn.Close()
        End Try


    End Sub

    Public Sub InformacionAgente()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select * from Agente where Numero=" & Pone_Apos(T_Agente.Text) & " and Sucursal=" & Pone_Apos(G.Sucursal) & " and Compañia =" & Pone_Apos(G.Empresa_Numero)
            G.com.CommandText = G.Tsql

            G.dr = G.com.ExecuteReader
            If G.dr.Read Then

                T_Agente_Desc.Text = G.dr!Nombre
                'G.mes_proceso = Format(G.dr!mes_proceso, "0#")

            End If


        Catch ex As Exception
            Msg_Error(ex.ToString)
        Finally
            G.cn.Close()
        End Try


    End Sub
    Public Sub InformacionEjecutivo()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select * from Ejecutivo where Numero=" & Pone_Apos(T_Ejecutivo.Text)
            G.com.CommandText = G.Tsql

            G.dr = G.com.ExecuteReader
            If G.dr.Read Then

                T_Ejecutivo_Desc.Text = G.dr!Nombre
                'G.mes_proceso = Format(G.dr!mes_proceso, "0#")

            End If


        Catch ex As Exception
            Msg_Error(ex.ToString)
        Finally
            G.cn.Close()
        End Try


    End Sub
    Protected Sub Ima_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Restaura.Click

        LimpiaCampos()
        Movimiento.Value = ""
        T_Partida.Text = SiguientePartida()

    End Sub
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Dim Lista As New ArrayList

        Try
            If validar() = False Then Exit Sub



            G.cn.Open()
            If Movimiento.Value <> "Cambio" Then
                If T_Partida.Text = "1" Then
                    G.Tsql = "Insert into  Cotiza_Encab (Situacion,Pedido,Sucursal,Tipo_Documento,Cliente,Razon_Social,Fecha_Pedido,Agente,Ejecutivo)"
                    G.Tsql &= " values('Cotiza'," & T_Pedido.Text & "," & Pone_Apos(G.Sucursal) & ",'5' ,"
                    G.Tsql &= " " & Pone_Apos(T_Cliente.Text) & ", "
                    G.Tsql &= " " & Pone_Apos(T_Cliente_Desc.Text) & ", "
                    G.Tsql &= " " & Pone_Apos(T_Fecha_Pedido.Text) & ", "
                    G.Tsql &= " " & Pone_Apos(T_Agente.Text) & ", "
                    G.Tsql &= " " & Pone_Apos(T_Ejecutivo.Text) & ") "
                    G.com.CommandText = G.Tsql
                    G.com.ExecuteNonQuery()


                End If



                G.Tsql = "Insert into  Cotiza_Detalle (Sucursal,Numero_Pedido,Partida,Numero_Articulo,Descripcion_Articulo,Marca,Unidad_Medida,Base_Iva,Cantidad_Pedida,Precio_Unitario)"
                G.Tsql &= " values(" & Pone_Apos(G.Sucursal) & ", "
                G.Tsql &= " " & Pone_Apos(T_Pedido.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Partida.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Articulo.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Articulo_Desc.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Marca.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Unidad_Medida.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Iva.Text) & ", "
                G.Tsql &= " " & Pone_Apos(T_Cantidad_Pedida.Text) & ", "
                G.Tsql &= " " & Val(Elimina_Comas(T_Precio_Unitario.Text)) & ") "
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                desabilita()
                LimpiaCampos()
                ' AñadeFilaGrid()
                'EliminaFilaGrid()
                'LimpiaCampos()

                'DesHabilita()
            ElseIf Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Cotiza_Detalle set Numero_Articulo=" & Pone_Apos(T_Articulo.Text) & " , Descripcion_Articulo=" & Pone_Apos(T_Articulo_Desc.Text) & ","
                G.Tsql &= " Marca=" & Pone_Apos(T_Marca.Text) & ", "
                G.Tsql &= " Base_Iva=" & Pone_Apos(T_Iva.Text) & ", "
                G.Tsql &= " Cantidad_Pedida=" & Pone_Apos(T_Cantidad_Pedida.Text) & ", "
                G.Tsql &= " Precio_Unitario=" & Pone_Apos(Elimina_Comas(T_Precio_Unitario.Text)) & ", "
                G.Tsql &= " Unidad_Medida=" & Pone_Apos(T_Unidad_Medida.Text) & " where Numero_Pedido=" & Pone_Apos(T_Pedido.Text) & " and Sucursal=" & Pone_Apos(G.Sucursal) & " and Partida=" & Pone_Apos(T_Partida.Text)

                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                LimpiaCampos()
            End If
           
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally

            G.cn.Close()

            InformacionCliente()
            T_Partida.Text = SiguientePartida()
            Movimiento.Value = ""

        End Try
        LLenaGrid()
        Pnl_Grids.Visible = True
        GridView1.Visible = True
        T_Articulo.Focus()
    End Sub
    Public Sub desabilita()
        T_Cliente.Enabled = False
        T_Cliente_Desc.Enabled = False
        H_Cliente.Enabled = False

        T_Articulo.Text = ""
        T_Articulo_Desc.Text = ""
        T_Cantidad_Pedida.Text = 0
    End Sub
    Private Function EjecutaTransaccion(ByVal ListaSentencias As ArrayList, ByRef cn As SqlConnection) As Boolean
        EjecutaTransaccion = False
        Dim com As New SqlCommand("", cn)
        Dim otransaccion As SqlTransaction = Nothing
        Dim sentencia As String
        Try
            otransaccion = cn.BeginTransaction
            com.Transaction = otransaccion
            For Each strSentencia In ListaSentencias
                sentencia = strSentencia.ToString()
                com.CommandText = sentencia.ToString()
                com.Transaction = otransaccion
                com.ExecuteNonQuery()
            Next
            otransaccion.Commit()
            Return True
        Catch ex As Exception
            If Not otransaccion Is Nothing Then
                otransaccion.Rollback() 'deshacer transaccion '
            End If
            Msg_Error(ex.Message)
            Return False
        End Try
    End Function
    'Private Function SubirXML(ByRef xml As C_XML, ByRef String_XML As String) As Boolean
    '    SubirXML = False
    '    Dim ext As String = ""
    '    If Not fileUploader1.HasFile Then
    '        SubirXML = True
    '        Exit Function
    '    End If
    '    Dim NombreArchXML As String = fileUploader1.PostedFile.FileName
    '    Dim formatos() As String = {"xml"}
    '    If fileUploader1.HasFile Then
    '        ext = NombreArchXML.Substring(NombreArchXML.LastIndexOf(".") + 1).ToLower()
    '        If Array.IndexOf(formatos, ext) < 0 Then
    '            Msg_Error("Solo se admiten archivos XML.") : Exit Function
    '        Else
    '            Try
    '                GuardarArchivo(fileUploader1.PostedFile)
    '                Subir()
    '                xml = New C_XML
    '                Dim mRutaArch As String = Server.MapPath("~/XML/" & NombreArchXML)
    '                If xml.LeerXML(mRutaArch) = False Then
    '                    xml.convierteXMLaUTF8(mRutaArch)
    '                    If xml.LeerXML(xml.Xml_NuevaRuta) = False Then
    '                        Msg_Error("Error en lectura de XML") : Exit Function
    '                    End If
    '                End If
    '                String_XML = xml.Convierte_XML_String(mRutaArch)
    '                L_UUID.Text = xml.Xml_UUID
    '            Catch ex As Exception
    '                Msg_Error(ex.Message)
    '            End Try
    '        End If
    '    End If
    '    SubirXML = True
    'End Function
    'Private Function GuardarArchivo(file As HttpPostedFile) As String
    '    Dim ruta As String = Server.MapPath("~/XML")
    '    Dim archivo As String = String.Format("{0}\\{1}", ruta, file.FileName)
    '    GuardarArchivo = ""
    '    If Directory.Exists(ruta) Then
    '        If IO.File.Exists(archivo) Then
    '            IO.File.Delete(archivo)
    '        End If
    '        file.SaveAs(archivo)
    '        GuardarArchivo = file.FileName
    '    Else
    '        Directory.CreateDirectory(ruta)
    '    End If
    'End Function
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Pedido) from Cotiza_Encab "
            G.Tsql &= " where Sucursal=" & Pone_Apos(G.Sucursal)

            G.com.CommandText = G.Tsql
            Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
        Catch ex As Exception
            ' Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function

    Private Function SiguientePartida() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        SiguientePartida = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Partida) as Partida from Cotiza_Detalle "
            G.Tsql &= " where Sucursal=" & Pone_Apos(G.Sucursal)
            G.Tsql &= " and Numero_Pedido=" & Pone_Apos(T_Pedido.Text)

            G.com.CommandText = G.Tsql
            'Dim resultado = Val(G.com.ExecuteScalar.ToString)
            G.dr = G.com.ExecuteReader
            If G.dr.Read Then
                SiguientePartida = Val(G.dr!Partida.ToString) + 1
            Else
                SiguientePartida = 1
            End If


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

    'Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
    '    LLenaGrid()
    'End Sub

    Protected Sub Ima_Procesar1_Click(sender As Object, e As System.EventArgs) Handles Ima_Procesar1.Click
        Response.Redirect("~/C_Procesa_Entradas.aspx")

    End Sub

    'Protected Sub T_Solicitante_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Cliente.TextChanged
    '    T_Cliente_Desc.Text = Busca_Cat(Session("G"), "SOLICITANTE", T_Cliente.Text)
    '    fileUploader1.Enabled = True

    'End Sub

    'Private Sub Subir()
    '    Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://inter-op.com.mx/Inventarios_XML/" + fileUploader1.FileName), System.Net.FtpWebRequest)
    '    clsRequest.Credentials = New System.Net.NetworkCredential("bfernand", "Ale2336")
    '    clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
    '    Dim bFile As Byte() = fileUploader1.FileBytes
    '    Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
    '    clsStream.Write(bFile, 0, bFile.Length)
    '    clsStream.Close()
    '    clsStream.Dispose()
    'End Sub
    'Protected Sub LB_Descargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LB_Descargar.Click
    '    Dim url As String = Replace(T_Punto_Liga.Text, "www.", "http://")
    '    url = Replace(url, "www.", "http://")
    '    Descargar3(url)
    'End Sub
    'Private Sub Descargar3(ByVal url As String)
    '    Dim fileName As String = System.IO.Path.GetFileName(url)
    '    'Dim descFilePath As String = System.IO.Path.Combine(Me.DestDir, fileName)
    '    Try
    '        Dim myre As WebRequest = WebRequest.Create(url)
    '    Catch ex As Exception
    '        'Throw New Exception("File doesn't exist on server", ex.InnerException)
    '        Msg_Error("No existe el archivo en el servidor")
    '    End Try
    '    Try
    '        Dim fileData As Byte()
    '        Using client As New WebClient()
    '            fileData = client.DownloadData(url)
    '        End Using
    '        Dim ms As New System.IO.MemoryStream(fileData)
    '        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", fileName))
    '        Response.ContentType = "application/octet-stream"
    '        Response.BinaryWrite(ms.ToArray())
    '    Catch ex As Exception
    '        'Throw New Exception("Failed to download", ex.InnerException)
    '        Msg_Error("Descarga fallida")
    '    End Try
    'End Sub
    'Private Sub Descargar2()
    '    Dim downloadClient As RemoteDownload = Nothing
    '    'If Me.rbDownloadList.SelectedIndex = 0 Then
    '    downloadClient = New HttpRemoteDownload("http://inter-op.com.mx/envio/1113Bancos.pdf", "C:\temp\")
    '    'Else

    '    'downloadClient = New FtpRemoteDownload("http://inter-op.com.mx/envio/1113Bancos.pdf", "C:\temp\")
    '    'End If

    '    If downloadClient.DownloadFile() Then
    '        Response.Write("Download is complete")
    '    Else
    '        Response.Write("Failed to download")
    '    End If
    'End Sub
    'Private Sub Descargar(ByVal Archivo As String)
    '    Dim myFtpWebRequest As FtpWebRequest
    '    Dim myFtpWebResponse As FtpWebResponse
    '    Dim myStreamWriter As StreamWriter
    '    myFtpWebRequest = WebRequest.Create("ftp://inter-op.com.mx/envio/1113Bancos.pdf")
    '    myFtpWebRequest.Credentials = New NetworkCredential("bfernand", "Ale2336")
    '    myFtpWebRequest.Method = WebRequestMethods.Ftp.DownloadFile
    '    myFtpWebRequest.UseBinary = True
    '    myFtpWebResponse = myFtpWebRequest.GetResponse()
    '    myStreamWriter = New StreamWriter(Server.MapPath("Archivo.pdf"))
    '    myStreamWriter.Write(New StreamReader(myFtpWebResponse.GetResponseStream()).ReadToEnd)
    '    Msg_Error(myFtpWebResponse.StatusDescription)
    '    myStreamWriter.Close()
    '    myFtpWebResponse.Close()
    'End Sub


    'Protected Sub H_Procesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles H_Procesar.Click
    ''    Response.Redirect("~\C_Procesa_Entradas.aspx")
    ''End Sub

    'Protected Sub H_imprimir2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles H_imprimir2.Click

    'End Sub

    Protected Sub T_Cliente_TextChanged(sender As Object, e As System.EventArgs) Handles T_Cliente.TextChanged
        InformacionCliente()
        T_Articulo.Focus()
    End Sub

    Protected Sub T_Articulo_TextChanged(sender As Object, e As System.EventArgs) Handles T_Articulo.TextChanged
        InformacionArticulo()
        T_Cantidad_Pedida.Focus()
    End Sub

    Protected Sub T_Marca_TextChanged(sender As Object, e As System.EventArgs) Handles T_Marca.TextChanged

    End Sub
End Class
