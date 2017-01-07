Imports System.Data

Partial Class Cotizacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Img_Logotipo.ImageUrl = "~/Trabajo/" & Session("Imagen")
            G.Imagen = Session("Imagen")
            Img_Logotipo.Style("Height") = Int(Session("Logo_Height")) & "px"
            Img_Logotipo.Style("Width") = Int(Session("Logo_Width")) & "px"
            Session("dt") = New DataTable
            Session("dtDetalle") = New DataTable
            CrearCamposTablaPedidos()
            CrearCamposTablaDetalles()
            HabilitaBuscar()
            LlenaGrid()
            Limpiar()
        End If
        Movimiento.Value = Movimiento.Value
        DibujaSpan()

        T_Articulo_Descripcion.Attributes.Add("readonly", "true")
        TB_Cliente_Razon_Social.Attributes.Add("readonly", "true")
        TB_Cotizacion_Razon_Social.Attributes.Add("readonly", "true")
        TB_Articulo_Descripcion.Attributes.Add("readonly", "true")
        T_Cliente_Razon_Social.Attributes.Add("readonly", "true")
        T_Articulo_Descripcion.Attributes.Add("readonly", "true")

        BtnB_Cliente.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        BtnB_Cliente.Attributes.Add("style", "cursor:pointer;")

        BtnB_Cotizacion.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        BtnB_Cotizacion.Attributes.Add("style", "cursor:pointer;")

        BtnB_Articulo.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        BtnB_Articulo.Attributes.Add("style", "cursor:pointer;")

        Btn_Cliente.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Cliente.Attributes.Add("style", "cursor:pointer;")

        Btn_Articulo.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Articulo.Attributes.Add("style", "cursor:pointer;")

        T_Precio.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Precio.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")

        T_Cantidad.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Cantidad.ClientID & "');")
        T_Precio.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Precio.ClientID & "');")
        T_IVA.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_IVA.ClientID & "');")
        T_Marca.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Marca.ClientID & "');")
        T_Linea.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Linea.ClientID & "');")
        T_Precio.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Precio.ClientID & "');")

        T_Cliente.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Articulo.ClientID & "');")
        T_Articulo.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Unidad_Medida.ClientID & "');")
        T_Unidad_Medida.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Cantidad.ClientID & "');")
        T_Cantidad.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Precio.ClientID & "');")
        T_Precio.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_IVA.ClientID & "');")
        T_IVA.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Marca.ClientID & "');")
        T_Marca.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Linea.ClientID & "');")

        'T_Linea.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Pagina.ClientID & "');")
        'T_Pagina.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Figura.ClientID & "');")
        'TB_Proveedor.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & TB_Articulo.ClientID & "');")
        'T_Figura.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")

        TB_Cliente.Attributes.Add("onfocus", "this.select();")
        TB_Cotizacion.Attributes.Add("onfocus", "this.select();")
        TB_Articulo.Attributes.Add("onfocus", "this.select();")
        T_Cliente.Attributes.Add("onfocus", "this.select();")
        T_Articulo.Attributes.Add("onfocus", "this.select();")
        T_Unidad_Medida.Attributes.Add("onfocus", "this.select();")
        T_Cantidad.Attributes.Add("onfocus", "this.select();")
        T_Precio.Attributes.Add("onfocus", "this.select();")
        T_IVA.Attributes.Add("onfocus", "this.select();")
        T_Marca.Attributes.Add("onfocus", "this.select();")
        T_Linea.Attributes.Add("onfocus", "this.select();")

        'T_Pagina.Attributes.Add("onfocus", "this.select();")
        'T_Figura.Attributes.Add("onfocus", "this.select();")
        'T_Art_Numero.Attributes.Add("onfocus", "this.select();")
        'T_Art_Numero_Desc.Attributes.Add("onfocus", "this.select();")

    End Sub

    Private Sub CrearCamposTablaPedidos()
        Session("dt").Columns.Add("Pedido", Type.GetType("System.String")) : Session("dt").Columns("Pedido").DefaultValue = ""
        Session("dt").Columns.Add("Razon_Social", Type.GetType("System.String")) : Session("dt").Columns("Razon_Social").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Pedido", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Pedido").DefaultValue = ""
        Session("dt").Columns.Add("Cliente", Type.GetType("System.String")) : Session("dt").Columns("Cliente").DefaultValue = ""
        Dim Clave(0) As DataColumn
        Clave(0) = Session("dt").Columns("Pedido")
        Session("dt").PrimaryKey = Clave
    End Sub
    Private Sub CrearCamposTablaDetalles()
        Session("dtDetalle").Columns.Add("Partida", Type.GetType("System.String")) : Session("dtDetalle").Columns("Partida").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Numero_Articulo", Type.GetType("System.String")) : Session("dtDetalle").Columns("Numero_Articulo").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Descripcion_Articulo", Type.GetType("System.String")) : Session("dtDetalle").Columns("Descripcion_Articulo").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Unidad_Medida", Type.GetType("System.String")) : Session("dtDetalle").Columns("Unidad_Medida").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Cantidad_Pedida", Type.GetType("System.String")) : Session("dtDetalle").Columns("Cantidad_Pedida").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Precio_Base", Type.GetType("System.String")) : Session("dtDetalle").Columns("Precio_Base").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Base_IVA", Type.GetType("System.String")) : Session("dtDetalle").Columns("Base_IVA").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Marca", Type.GetType("System.String")) : Session("dtDetalle").Columns("Marca").DefaultValue = ""
        Session("dtDetalle").Columns.Add("Linea", Type.GetType("System.String")) : Session("dtDetalle").Columns("Linea").DefaultValue = ""
        Dim Clave(1) As DataColumn
        Clave(0) = Session("dtDetalle").Columns("Partida")
        Clave(0) = Session("dtDetalle").Columns("Numero_Articulo")
        Session("dtDetalle").PrimaryKey = Clave
    End Sub

    Private Sub DibujaSpan()
        Dim dtspan As New DataTable
        dtspan = Session("dt").Copy
        If Session("dt").Rows.Count = 0 Then
            Dim f As DataRow = dtspan.NewRow()
            dtspan.Rows.Add(f)
            GridView1.DataSource = dtspan
            GridView1.DataBind()
            Dim TotalColumnas2 As Integer = GridView1.Rows(0).Cells.Count
            GridView1.Rows(0).Cells.Clear()
            GridView1.Rows(0).Cells.Add(New TableCell)
            GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumnas2
            GridView1.Rows(0).Cells(0).Text = ""
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        End If
    End Sub
    Private Sub DibujaSpanDetalle()
        Dim dtspan As New DataTable
        dtspan = Session("dtDetalle").Copy
        If Session("dtDetalle").Rows.Count = 0 Then
            Dim f As DataRow = dtspan.NewRow()
            dtspan.Rows.Add(f)
            GridView2.DataSource = dtspan
            GridView2.DataBind()
            Dim TotalColumnas2 As Integer = GridView2.Rows(0).Cells.Count
            GridView2.Rows(0).Cells.Clear()
            GridView2.Rows(0).Cells.Add(New TableCell)
            GridView2.Rows(0).Cells(0).ColumnSpan = TotalColumnas2
            GridView2.Rows(0).Cells(0).Text = ""
            Cabecera2.DataSource = New List(Of String)
            Cabecera2.DataBind()
        End If
    End Sub

    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Private Function Llena_DataTable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select Pedido,Razon_Social,Fecha_Pedido,Cliente from Encab_Pedido A "

            If Val(TB_Articulo.Text.Trim) > 0 Then
                G.Tsql += " join Detalle_Pedido B on A.Pedido = B.Numero_Pedido and  where A.Tipo_Documento = 1 and B.Numero_Articulo = " & Pone_Apos(TB_Articulo.Text.Trim)
            Else
                G.Tsql += " where A.Tipo_Documento = 1 "
            End If
            If Val(TB_Cliente.Text.Trim) > 0 Then
                G.Tsql += " and A.Cliente = " & Pone_Apos(TB_Cliente.Text.Trim)
            End If
            If Val(TB_Cotizacion.Text.Trim) > 0 Then
                G.Tsql += " and A.Pedido = " & Pone_Apos(TB_Cotizacion.Text.Trim)
            End If
            'G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and A.Sucursal = " & Pone_Apos(G.Sucursal)
            G.Tsql &= " Order by A.Pedido"

            G.com.CommandText = G.Tsql
            Session("dt").rows.clear()
            G.dr = G.com.ExecuteReader()
            Session("dt").Load(G.dr)

            Dim clave(0) As DataColumn
            clave(0) = Session("dt").Columns("Pedido")
            Session("dt").PrimaryKey = clave

        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function
    Private Function Llena_DataTable_Detalle(ByVal Pedido As String) As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select A.Numero_Pedido ,A.Partida ,A.Numero_Articulo ,A.Descripcion_Articulo,A.Unidad_Medida,"
            G.Tsql += "A.Cantidad_Pedida,A.Precio_Base,A.Base_Iva,A.Marca,A.Linea from Detalle_Pedido A join Encab_Pedido B"
            G.Tsql += "on A.Numero_Pedido = B.Pedido where B.Pedido = " & Pone_Apos(Pedido)
            G.Tsql += " Order by A.Partida"

            G.com.CommandText = G.Tsql
            Session("dtDetalle").rows.clear()
            G.dr = G.com.ExecuteReader()
            Session("dtDetalle").Load(G.dr)

            Dim clave(1) As DataColumn
            clave(0) = Session("dtDetalle").Columns("Partida")
            clave(1) = Session("dtDetalle").Columns("Numero_Articulo")
            Session("dtDetalle").PrimaryKey = clave

        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dtDetalle")
    End Function

    Private Sub LlenaGrid()
            Session("dt") = Llena_DataTable()
            If Session("dt").Rows.Count > 0 Then
                GridView1.DataSource = Session("dt")
                GridView1.DataBind()
                Cabecera.DataSource = New List(Of String)
                Cabecera.DataBind()
            Else
                DibujaSpan()
            End If
    End Sub
    Private Sub LlenarGridDetalle()
        Session("dtDetalle") = Llena_DataTable()
        If Session("dtDetalle").Rows.Count > 0 Then
            GridView2.DataSource = Session("dtDetalle")
            GridView2.DataBind()
            Cabecera2.DataSource = New List(Of String)
            Cabecera2.DataBind()
        Else
            DibujaSpanDetalle()
        End If
    End Sub

    Private Sub HabilitaBuscar()
        P_Buscar.Visible = True
        P_Campos_Alta.Visible = False
        P_Buscar.Enabled = True
        P_Campos_Alta.Enabled = False

        Btn_Alta.Enabled = True
        Btn_Busca.Enabled = True
        Btn_Restaura.Enabled = False
        Btn_Guarda.Enabled = False
        Btn_Alta.CssClass = "Btn_Azul"
        Btn_Busca.CssClass = "Btn_Azul"
        Btn_Restaura.CssClass = "Btn_Rojo"
        Btn_Guarda.CssClass = "Btn_Rojo"
        GridView1.Enabled = True
    End Sub
    Private Sub DeshabilitaBuscar()
        P_Campos_Alta.Enabled = True
        P_Buscar.Visible = False
        P_Buscar.Enabled = False
        Btn_Alta.Enabled = False
        Btn_Busca.Enabled = False
        Btn_Restaura.Enabled = True
        Btn_Guarda.Enabled = True
        Btn_Alta.CssClass = "Btn_Rojo"
        Btn_Busca.CssClass = "Btn_Rojo"
        Btn_Restaura.CssClass = "Btn_Azul"
        Btn_Guarda.CssClass = "Btn_Azul"
        GridView1.Enabled = False
        Cabecera2.Visible = True
        GridView2.Visible = True
    End Sub

    Protected Sub Btn_Busca_Click(sender As Object, e As System.EventArgs) Handles Btn_Busca.Click
        LlenaGrid()
        Pnl_Grids.Visible = True
    End Sub
    Protected Sub Btn_Alta_Click(sender As Object, e As System.EventArgs) Handles Btn_Alta.Click
        Movimiento.Value = "Alta"
        T_Cliente.Enabled = True
        P_Campos_Alta.Visible = True
        Pnl_Grids2.Visible = True
        P_Buscar.Visible = False
        Pnl_Grids.Visible = False

        T_Pedido.Text = siguientePedido()
        DeshabilitaBuscar()
        T_Cliente.Focus()
        DibujaSpanDetalle()
    End Sub
    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        HabilitaBuscar()
        Limpiar()
        Pnl_Grids.Visible = True
        Pnl_Grids2.Visible = False
    End Sub
    Protected Sub Btn_Regresa_Click(sender As Object, e As System.EventArgs) Handles Btn_Regresa.Click
        Response.Redirect("~/Menu.aspx")

    End Sub
    Protected Sub Btn_Guarda_Click(sender As Object, e As System.EventArgs) Handles Btn_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                G.cn.Open()
                G.Tsql = "Insert into Encab_Pedido(Sucursal,Caja,Pedido,Tipo_Documento,Cliente,Fecha_Pedido)values("
                G.Tsql &= Pone_Apos(G.Sucursal)
                G.Tsql &= ",0"
                G.Tsql &= "," & Pone_Apos(T_Pedido.Text)
                G.Tsql &= ",5"
                G.Tsql &= "," & Pone_Apos(T_Cliente.Text)
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGridPedido()
                HabilitaBuscar()
                G.cn.Close()
                Limpiar()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Articulo_Proveedor set Unidad_Medida=" & Pone_Apos(T_Unidad_Medida.Text.Trim)
                G.Tsql &= ",Dias_Entrega=" & Val(T_Cantidad.Text)
                G.Tsql &= ",Garantia=" & Pone_Apos(T_Cliente.Text).ToString
                G.Tsql &= ",Precio1=" & Elimina_Comas(T_Marca.Text)
                G.Tsql &= ",Costo1=" & Elimina_Comas(T_Marca.Text)
                G.Tsql &= ",Fecha_Precio1=" & Pone_Apos(T_Cliente.Text).ToString
                G.Tsql &= ",Moneda=" & Val(T_Precio.Text)
                G.Tsql &= ",Baja=''"
                G.Tsql &= " Where Numero_Pedido = " & Val(T_Cliente.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGridPedido(T_Articulo.Text)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGridPedido(T_Articulo.Text)
                End If
                HabilitaBuscar()
                Limpiar()
                G.cn.Close()
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        LlenaGrid()
        Btn_Restaura_Click(Nothing, Nothing)
    End Sub
    Protected Sub Btn_agregar_Click(sender As Object, e As System.EventArgs) Handles Btn_agregar.Click
        AñadeFilaGridDetalle()
        Limpiar()
    End Sub


    Private Sub Limpiar()
        T_Cliente.Text = ""
        T_Cliente_Razon_Social.Text = ""
        T_Cliente_RFC.Text = ""
        T_Articulo.Text = ""
        T_Articulo_Descripcion.Text = ""
        T_Unidad_Medida.Text = ""
        T_Cantidad.Text = ""
        T_Precio.Text = ""
        T_IVA.Text = ""
        T_Marca.Text = ""
        T_Linea.Text = ""
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LlenaGrid()
        End If
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Then
            Dim G As Glo = CType(Session("G"), Glo)
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(0).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Pedido.Text = f("Pedido")
                T_Cliente.Text = f("Cliente")
                T_Cliente_Razon_Social.Text = f("Razon_Social")
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
            End If
            DeshabilitaBuscar()
            P_Campos_Alta.Visible = True
            P_Buscar.Visible = False
            Pnl_Grids.Visible = False
            T_Cliente.Enabled = False
            Btn_Cliente.Enabled = False
        End If
    End Sub

    Private Sub AñadeFilaGridPedido()
        Dim f As DataRow = Session("dt").NewRow()
        Dim G As Glo = CType(Session("G"), Glo)
        f("Pedido") = T_Pedido.Text
        f("Razon_Social") = T_Cliente_Razon_Social.Text
        f("Fecha_Pedido") = Fecha_AMD(Now)
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub AñadeFilaGridDetalle()
        Dim f As DataRow = Session("dtDetalle").NewRow()
        Dim G As Glo = CType(Session("G"), Glo)

        f("Partida") = (GridView2.Rows.Count + 1)
        f("Numero_Articulo") = T_Articulo.Text
        f("Descripcion_Articulo") = T_Articulo_Descripcion.Text
        f("Unidad_Medida") = T_Unidad_Medida.Text
        f("Cantidad_Pedida") = T_Cantidad.Text
        f("Precio_Base") = T_Precio.Text
        f("Base_IVA") = T_IVA.Text
        f("Marca") = T_Marca.Text
        f("Linea") = T_Linea.Text

        Session("dtDetalle").Rows.Add(f)
        GridView2.PageIndex = Int((Session("dtDetalle").Rows.Count) / 10)
        GridView2.DataSource = Session("dtDetalle")
        GridView2.DataBind()
    End Sub

    Private Sub CambiaFilaGridPedido(ByVal Numero As String)
        Dim clave(1) As String
        Dim G As Glo = CType(Session("G"), Glo)
        clave(0) = Numero
        clave(1) = T_Cliente.Text
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Pedido") = T_Cliente.Text
            f("Razon_Social") = T_Cliente.Text
            f("Fecha_Pedido") = T_Cantidad.Text
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGridDetalle(ByVal Numero As String)
        Dim clave(1) As String
        Dim G As Glo = CType(Session("G"), Glo)
        clave(0) = Numero
        clave(1) = T_Cliente.Text
        Dim f As DataRow = Session("dtDetalle").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Partida") = T_Pedido.Text
            f("Numero_Articulo") = T_Articulo.Text
            f("Descripcion_Articulo") = T_Articulo_Descripcion.Text
            f("Unidad_Medida") = T_Unidad_Medida.Text
            f("Cantidad_Pedida") = T_Cantidad.Text
            f("Precio_Base") = T_Precio.Text
            f("Base_IVA") = T_IVA.Text
            f("Marca") = T_Marca.Text
            f("Linea") = T_Linea.Text
        End If
        GridView1.DataSource = Session("dtDetalle")
        GridView1.DataBind()
    End Sub

    Private Sub EliminaFilaGridPedido(ByVal Numero As Integer)

        Dim clave(1) As String
        clave(0) = Numero
        clave(1) = T_Cliente.Text
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGridDetalle(ByVal Numero As Integer)

        Dim clave(1) As String
        clave(0) = Numero
        clave(1) = T_Cliente.Text
        Dim f As DataRow = Session("dtDetalle").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dtDetalle")
        GridView1.DataBind()
    End Sub

    Private Function validar() As Boolean
        validar = False
        Dim G As Glo = CType(Session("G"), Glo)
        If Movimiento.Value = "Alta" Then
            G.cn.Open()
            G.Tsql = "Select Pro_Numero,Art_Numero from Articulo_Proveedor"
            G.Tsql &= " where Pro_Numero=" & Val(T_Cliente.Text)
            G.Tsql &= " and Art_Numero=" & Pone_Apos(T_Articulo.Text)
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Sucursal =" & Pone_Apos(Session("Sucursal"))
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            If G.dr.HasRows Then
                Msg_Error("Ya existe un registro con el articulo y proveedor seleccionado")
                Exit Function
            End If
            G.cn.Close()
        End If
        If Val(T_Cliente.Text) = 0 Then
            Msg_Error("El registro no se puede realizar sin un proveedor") : Exit Function
        End If
        If Val(T_Marca.Text) = 0 Then
            Msg_Error("Precio inválido") : Exit Function
        End If
        If T_Cliente.Text = "" Or T_Cliente.Text.Trim = "" Then
            Msg_Error("Fecha de Vigencia inválida") : Exit Function
        End If
        If T_Cantidad.Text = "" Or T_Cantidad.Text.Trim = "" Then
            Msg_Error("Dias de Entrega inválida") : Exit Function
        End If
        Return True
    End Function

    Protected Sub TB_Proveedor_TextChanged(sender As Object, e As System.EventArgs) Handles T_Cliente.TextChanged
        T_Cliente.Text = Busca_Cat(Session("G"), "PROVEEDOR", T_Cliente.Text)
        TB_Articulo.Focus()
        T_Cliente.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", T_Cliente.Text)
    End Sub
    Protected Sub T_Proveedor_TextChanged(sender As Object, e As System.EventArgs) Handles T_Cliente.TextChanged
        T_Cliente.Text = Busca_Cat(Session("G"), "PROVEEDOR", T_Cliente.Text)
        T_Cliente.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", T_Cliente.Text)
        T_Unidad_Medida.Focus()
    End Sub
    Protected Sub T_Precio_Lista_TextChanged(sender As Object, e As System.EventArgs) Handles T_Marca.TextChanged

    End Sub
    Protected Sub T_Moneda_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Precio.TextChanged
        T_Cliente.Text = Busca_Cat(Session("G"), "MONEDA", T_Cliente.Text)
        T_IVA.Focus()
    End Sub
    Protected Sub TB_Articulo_TextChanged(sender As Object, e As System.EventArgs) Handles TB_Articulo.TextChanged
        TB_Articulo_Descripcion.Text = Busca_Cat(Session("G"), "ARTICULO", TB_Articulo.Text)
    End Sub
    Protected Sub Ch_Baja_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LlenaGrid()
    End Sub


    Public Function siguientePedido() As String
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Auxiliar As String = ""
        Try
            G.cn.Open()
            G.Tsql = "Select max(Pedido)+1 from Encab_Pedido"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader()
            While G.dr.Read
                Auxiliar = G.dr.GetValue(0)
            End While
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Auxiliar
    End Function
End Class