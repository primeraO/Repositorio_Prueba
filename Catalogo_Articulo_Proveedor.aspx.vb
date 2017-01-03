Imports System.Data
Partial Class Catalogo_Articulo_Proveedor
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
            CrearCamposTabla()
            'TB_Articulo.Text = G.Glo_Articulo
            'TB_Articulo_Descripcion.Text = G.Glo_Articulo_Descripcion
            'T_Articulo.Text = G.Glo_Articulo
            'T_Articulo_Descripcion.Text = G.Glo_Articulo_Descripcion
            HabilitaBuscar()
            LlenaGrid()
            Limpiar()
        End If
        Movimiento.Value = Movimiento.Value
        DibujaSpan()
        T_Articulo_Descripcion.Attributes.Add("readonly", "true")
        TB_Articulo_Descripcion.Attributes.Add("readonly", "true")
        T_Proveedor_Descripcion.Attributes.Add("readonly", "true")
        TB_Proveedor_Descripcion.Attributes.Add("readonly", "true")
        T_Fecha_Vigencia.Attributes.Add("readonly", "true")
        T_Moneda_Descripcion.Attributes.Add("readonly", "true")
        BB_Proveedor.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        BB_Proveedor.Attributes.Add("style", "cursor:pointer;")

        Btn_Proveedor.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Proveedor.Attributes.Add("style", "cursor:pointer;")

        Btn_Moneda.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Moneda.Attributes.Add("style", "cursor:pointer;")

        HB_Articulo.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        HB_Articulo.Attributes.Add("style", "cursor:pointer;")

        H_Articulo.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Articulo.Attributes.Add("style", "cursor:pointer;")

        T_Precio_Lista.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Precio_Lista.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Precio_Lista.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Precio_Lista.ClientID & "');")
        T_Proveedor.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Proveedor.ClientID & "');")
        TB_Proveedor.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Proveedor.ClientID & "');")
        T_IVA.Attributes.Add("onkeypress", "javascript: ValidaSoloNumero('" & T_IVA.ClientID & "');")
        T_Dias_Entrega.Attributes.Add("onkeypress", "javascript: ValidaSoloNumero('" & T_Dias_Entrega.ClientID & "');")
        T_Moneda.Attributes.Add("onkeypress", "javascript: ValidaSoloNumero('" & T_Moneda.ClientID & "');")

        T_Proveedor.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Unidad_Medida.ClientID & "');")
        T_Unidad_Medida.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Dias_Entrega.ClientID & "');")
        T_Dias_Entrega.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Garantia.ClientID & "');")
        T_Garantia.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Precio_Lista.ClientID & "');")
        T_Precio_Lista.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Moneda.ClientID & "');")
        T_Moneda.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_IVA.ClientID & "');")
        T_IVA.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Catalogo.ClientID & "');")
        T_Catalogo.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Pagina.ClientID & "');")
        T_Pagina.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Figura.ClientID & "');")
        TB_Proveedor.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & TB_Articulo.ClientID & "');")
        T_Figura.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")

        TB_Proveedor.Attributes.Add("onfocus", "this.select();")
        TB_Articulo.Attributes.Add("onfocus", "this.select();")
        T_Articulo.Attributes.Add("onfocus", "this.select();")
        T_Proveedor.Attributes.Add("onfocus", "this.select();")
        T_Unidad_Medida.Attributes.Add("onfocus", "this.select();")
        T_Dias_Entrega.Attributes.Add("onfocus", "this.select();")
        T_Garantia.Attributes.Add("onfocus", "this.select();")
        T_Precio_Lista.Attributes.Add("onfocus", "this.select();")
        T_Moneda.Attributes.Add("onfocus", "this.select();")
        T_IVA.Attributes.Add("onfocus", "this.select();")
        T_Catalogo.Attributes.Add("onfocus", "this.select();")
        T_Pagina.Attributes.Add("onfocus", "this.select();")
        T_Figura.Attributes.Add("onfocus", "this.select();")
        T_Art_Numero.Attributes.Add("onfocus", "this.select();")
        T_Art_Numero_Desc.Attributes.Add("onfocus", "this.select();")

    End Sub
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Art_Numero", Type.GetType("System.String")) : Session("dt").Columns("Art_Numero").DefaultValue = ""
        Session("dt").Columns.Add("Art_Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Art_Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Pro_Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Pro_Numero").DefaultValue = 0
        Session("dt").Columns.Add("Prov_Nombre", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Unidad_Medida", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Dias_Entrega", Type.GetType("System.Double")) : Session("dt").Columns("Prov_Nombre").DefaultValue = 0
        Session("dt").Columns.Add("Garantia", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Precio1", Type.GetType("System.Double")) : Session("dt").Columns("Prov_Nombre").DefaultValue = 0
        Session("dt").Columns.Add("Costo1", Type.GetType("System.Double")) : Session("dt").Columns("Prov_Nombre").DefaultValue = 0
        Session("dt").Columns.Add("Fecha_Precio1", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Moneda", Type.GetType("System.Double")) : Session("dt").Columns("Prov_Nombre").DefaultValue = 0
        Session("dt").Columns.Add("Impuesto", Type.GetType("System.Double")) : Session("dt").Columns("Prov_Nombre").DefaultValue = 0
        Session("dt").Columns.Add("Catalogo", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Figura", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Pagina", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Numero", Type.GetType("System.String")) : Session("dt").Columns("Prov_Nombre").DefaultValue = ""
       
        Dim Clave(1) As DataColumn
        Clave(0) = Session("dt").Columns("Art_Numero")
        Clave(1) = Session("dt").Columns("Pro_Numero")
        Session("dt").PrimaryKey = Clave
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
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Private Function Llena_DataTable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select top 200 Art_Numero,Art_Descripcion,Pro_Numero,Unidad_Medida,Dias_Entrega,Garantia,Precio1,Costo1,Fecha_Precio1,Moneda,Impuesto,Catalogo,Figura,Pagina,Numero "
            G.Tsql &= " ,(Select top 1 Razon_Social From Proveedor Where Numero=a.Pro_Numero) As Prov_Nombre"
            G.Tsql &= " ,(Select top 1 Art_Descripcion From Articulos  Where Numero=a.Art_Numero) As Articulo_Descripcion"
            G.Tsql &= "  From Articulo_Proveedor a"
            If Ch_Baja.Checked = True Then
                G.Tsql &= " Where baja='*'"
            Else
                G.Tsql &= " Where baja<>'*'"
            End If
            If TB_Articulo.Text.Trim > "" Then
                G.Tsql &= " and Art_Numero=" & Pone_Apos(TB_Articulo.Text)
            End If
            If Val(TB_Proveedor.Text.Trim) > 0 Then
                G.Tsql &= " and Pro_Numero=" & Val(TB_Proveedor.Text)
            End If
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
            G.Tsql &= " Order by Art_Numero"
            G.com.CommandText = G.Tsql
            Session("dt").rows.clear()
            G.dr = G.com.ExecuteReader()
            Session("dt").Load(G.dr)
            Dim clave(1) As DataColumn
            clave(0) = Session("dt").Columns("Art_Numero")
            clave(1) = Session("dt").Columns("Pro_Numero")
            Session("dt").PrimaryKey = clave
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
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
    Private Sub HabilitaBuscar()
        P_Buscar.Visible = True
        P_Campos_Alta.Visible = False

        P_Buscar.Enabled = True
        P_Campos_Alta.Enabled = False
        PC_Fecha_Vigencia.Enabled = False
        Btn_Alta.Enabled = True
        Btn_Busca.Enabled = True
        Btn_Restaura.Enabled = False
        Btn_Guarda.Enabled = False
        Btn_Alta.CssClass = "Btn_Azul"
        Btn_Busca.CssClass = "Btn_Azul"
        Btn_Restaura.CssClass = "Btn_Rojo"
        Btn_Guarda.CssClass = "Btn_Rojo"
        GridView1.Enabled = True

        HB_Articulo.Attributes.Add("onclick", "")
    End Sub
    Private Sub DeshabilitaBuscar()
        P_Campos_Alta.Enabled = True
        P_Buscar.Visible = False
        PC_Fecha_Vigencia.Enabled = True
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
    End Sub

    Protected Sub Btn_Busca_Click(sender As Object, e As System.EventArgs) Handles Btn_Busca.Click
        LlenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub Btn_Alta_Click(sender As Object, e As System.EventArgs) Handles Btn_Alta.Click
        Movimiento.Value = "Alta"
        DeshabilitaBuscar()
        T_Articulo.Enabled = False
        T_Proveedor.Focus()
        P_Campos_Alta.Visible = True
        P_Buscar.Visible = False
        Pnl_Grids.Visible = False
        'Pnl_Proveedores.Visible = True

    End Sub

    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        HabilitaBuscar()
        Limpiar()
        Pnl_Grids.Visible = True
    End Sub
    Private Sub Limpiar()
        T_Proveedor.Text = ""
        T_Proveedor_Descripcion.Text = ""
        TB_Proveedor.Text = ""
        TB_Proveedor_Descripcion.Text = ""
        T_Fecha_Vigencia.Text = Fecha_AMD(Now)
        T_Unidad_Medida.Text = ""
        T_Dias_Entrega.Text = ""
        T_Garantia.Text = ""
        T_Precio_Lista.Text = "0.0000"
        T_Moneda.Text = "0"
        T_Moneda_Descripcion.Text = "PESOS"
        T_IVA.Text = "16"
        T_Catalogo.Text = ""
        T_Figura.Text = ""
        T_Pagina.Text = ""
    End Sub

    Protected Sub Btn_Regresa_Click(sender As Object, e As System.EventArgs) Handles Btn_Regresa.Click
        Response.Redirect("~/Menu.aspx")

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
            Dim Clave(1) As String
            Clave(0) = (GridView1.Rows(ind).Cells(2).Text)
            Clave(1) = (GridView1.Rows(ind).Cells(0).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Articulo.Text = f("Art_Numero")
                T_Articulo_Descripcion.Text = AString(f("Art_Descripcion"))
                T_Proveedor.Text = Val(f("Pro_Numero"))
                T_Proveedor_Descripcion.Text = AString(f("Prov_Nombre"))
                T_Moneda.Text = f("Moneda").ToString
                T_Unidad_Medida.Text = f("Unidad_Medida").ToString
                T_Dias_Entrega.Text = f("Dias_Entrega").ToString
                T_Garantia.Text = f("Garantia").ToString
                T_Precio_Lista.Text = For_Pan_Lib(f("Precio1").ToString, 2)
                T_Fecha_Vigencia.Text = f("Fecha_Precio1").ToString
                T_IVA.Text = f("Impuesto").ToString
                T_Art_Numero.Text = f("Numero")
                T_Art_Numero_Desc.Text = f("Art_Descripcion")
                T_Catalogo.Text = f("Catalogo")
                T_Figura.Text = f("Figura")
                T_Pagina.Text = f("Pagina")
            End If
        If (e.CommandName.Equals("Baja")) Then
            Movimiento.Value = "Baja"
            HabilitaBuscar()
            Btn_Guarda.Enabled = True
            Btn_Guarda.CssClass = "Btn_Azul"
            Btn_Restaura.Enabled = True
            Btn_Restaura.CssClass = "Btn_Azul"
        End If
        If (e.CommandName.Equals("Cambio")) Then
            Movimiento.Value = "Cambio"
            DeshabilitaBuscar()
            T_Articulo.Enabled = False
            T_Proveedor.Enabled = False
        End If
        P_Campos_Alta.Visible = True
        P_Buscar.Visible = False
        Pnl_Grids.Visible = False
        End If
    End Sub

    Protected Sub Btn_Guarda_Click(sender As Object, e As System.EventArgs) Handles Btn_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                G.cn.Open()
                G.Tsql = "Insert Into Articulo_Proveedor(Art_Numero,Numero,Art_Descripcion,Pro_Numero,Dias_Entrega,Garantia,Precio1,Costo1"
                G.Tsql &= ",Fecha_Precio1,Moneda,Impuesto,Catalogo,Figura,Pagina,Baja,Unidad_Medida,Cia,Obra)values("
                G.Tsql &= Pone_Apos(T_Articulo.Text)
                G.Tsql &= "," & Pone_Apos(T_Art_Numero.Text)
                G.Tsql &= "," & Pone_Apos(T_Art_Numero_Desc.Text)
                G.Tsql &= "," & Val(T_Proveedor.Text)
                G.Tsql &= "," & Val(T_Dias_Entrega.Text)
                G.Tsql &= "," & Pone_Apos(T_Garantia.Text)
                G.Tsql &= "," & Elimina_Comas(T_Precio_Lista.Text)
                G.Tsql &= "," & Elimina_Comas(T_Precio_Lista.Text)
                G.Tsql &= "," & Pone_Apos(T_Fecha_Vigencia.Text)
                G.Tsql &= "," & Val(T_Moneda.Text)
                G.Tsql &= "," & Val(T_IVA.Text)
                G.Tsql &= "," & Pone_Apos(T_Catalogo.Text)
                G.Tsql &= "," & Pone_Apos(T_Figura.Text)
                G.Tsql &= "," & Pone_Apos(T_Pagina.Text)
                G.Tsql &= ",''"
                G.Tsql &= "," & Pone_Apos(T_Unidad_Medida.Text)
                G.Tsql &= "," & Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(Session("Sucursal"))
                G.Tsql &= ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Articulo.Text)
                HabilitaBuscar()
                'G.Tsql = "Select Proveedor1, Proveedor2,Proveedor3 from Requisicion Where Requisicion=" & Val(G.Num_Requisicion)
                'G.Tsql &= " and Art_Numero=" & Pone_Apos(T_Articulo.Text)
                'G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                'G.Tsql &= " and Cia=" & Val(Session("Cia"))
                'G.com.CommandText = G.Tsql
                'G.dr = G.com.ExecuteReader
                'Do While G.dr.Read
                '    If (Val(G.dr("Proveedor1")) <> Val(T_Proveedor.Text) And Val(G.dr("Proveedor2")) <> Val(T_Proveedor.Text) And Val(G.dr("Proveedor3")) <> Val(T_Proveedor.Text)) Then
                '        G.Mensaje = ("El Proveedor " & T_Proveedor.Text & ": " & T_Proveedor_Descripcion.Text & " se guardo exitosamente pero no está asignado a la requisición, por lo tanto no es posible mostrarlo en la tabla")
                '    End If
                'Loop
                G.cn.Close()
                Limpiar()
                'Response.Redirect("~/Orden_Asigna_Proveedor.aspx")
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Articulo_Proveedor set Unidad_Medida=" & Pone_Apos(T_Unidad_Medida.Text.Trim)
                G.Tsql &= ",Dias_Entrega=" & Val(T_Dias_Entrega.Text)
                G.Tsql &= ",Garantia=" & Pone_Apos(T_Garantia.Text).ToString
                G.Tsql &= ",Precio1=" & Elimina_Comas(T_Precio_Lista.Text)
                G.Tsql &= ",Costo1=" & Elimina_Comas(T_Precio_Lista.Text)
                G.Tsql &= ",Fecha_Precio1=" & Pone_Apos(T_Fecha_Vigencia.Text).ToString
                G.Tsql &= ",Moneda=" & Val(T_Moneda.Text)
                G.Tsql &= ",Impuesto=" & Val(T_IVA.Text)
                G.Tsql &= ",Catalogo=" & Pone_Apos(T_Catalogo.Text)
                G.Tsql &= ",Figura=" & Pone_Apos(T_Figura.Text)
                G.Tsql &= ",Pagina=" & Pone_Apos(T_Pagina.Text)
                G.Tsql &= ",Numero=" & Pone_Apos(T_Art_Numero.Text)
                G.Tsql &= ",Art_Descripcion=" & Pone_Apos(T_Art_Numero_Desc.Text)
                G.Tsql &= ",Baja=''"
                G.Tsql &= " Where Pro_Numero=" & Val(T_Proveedor.Text.Trim)
                G.Tsql &= " and Art_Numero=" & Pone_Apos(T_Articulo.Text)
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Sucursal=" & Pone_Apos(Session("Obra"))
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Articulo.Text)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Articulo.Text)
                End If
                HabilitaBuscar()
                'G.Tsql = "Select Proveedor1, Proveedor2,Proveedor3 from Requisicion Where Requisicion=" & Val(G.Num_Requisicion)
                'G.Tsql &= " and Art_Numero=" & Pone_Apos(T_Articulo.Text)
                'G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                'G.Tsql &= " and Cia=" & Val(Session("Cia"))
                'G.com.CommandText = G.Tsql
                'G.dr = G.com.ExecuteReader
                'Do While G.dr.Read
                '    If (Val(G.dr("Proveedor1")) <> Val(T_Proveedor.Text) And Val(G.dr("Proveedor2")) <> Val(T_Proveedor.Text) And Val(G.dr("Proveedor3")) <> Val(T_Proveedor.Text)) Then
                '        G.Mensaje = ("El Proveedor " & T_Proveedor.Text & ": " & T_Proveedor_Descripcion.Text & " se guardo exitosamente pero no está asignado a la requisición, por lo tanto no es posible mostrarlo en la tabla")
                '    End If
                'Loop
                Limpiar()
                G.cn.Close()
                'Response.Redirect("~/Orden_Asigna_Proveedor.aspx")
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Articulo_Proveedor set Baja='*'"
                G.Tsql &= " Where Pro_Numero=" & Val(T_Proveedor.Text.Trim)
                G.Tsql &= " and Art_Numero=" & Pone_Apos(T_Articulo.Text)
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Sucursal=" & Pone_Apos(Session("Obra"))
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid(T_Articulo.Text)
                Limpiar()
                HabilitaBuscar()
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        LlenaGrid()
        'P_Buscar.Visible = True
        'P_Campos_Alta.Visible = False
        'Pnl_Grids.Visible = True
        Btn_Restaura_Click(Nothing, Nothing)
    End Sub
    Private Sub AñadeFilaGrid(ByVal Art_Numero As String)
        Dim f As DataRow = Session("dt").NewRow()
        Dim G As Glo = CType(Session("G"), Glo)
        f("Art_Numero") = Art_Numero
        f("Pro_Numero") = T_Proveedor.Text
        f("Numero") = T_Art_Numero.Text
        f("Art_Descripcion") = T_Art_Numero_Desc.Text
        f("Dias_Entrega") = T_Dias_Entrega.Text
        f("Garantia") = T_Garantia.Text
        f("Precio1") = T_Precio_Lista.Text
        f("Costo1") = T_Precio_Lista.Text
        f("Fecha_Precio1") = T_Fecha_Vigencia.Text
        f("Moneda") = T_Moneda.Text
        f("Impuesto") = T_IVA.Text
        f("Catalogo") = T_Catalogo.Text
        f("Figura") = T_Figura.Text
        f("Pagina") = T_Pagina.Text
        f("Unidad_Medida") = T_Unidad_Medida.Text

        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String)
        Dim clave(1) As String
        Dim G As Glo = CType(Session("G"), Glo)
        clave(0) = Numero
        clave(1) = T_Proveedor.Text
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Numero") = T_Art_Numero.Text
            f("Art_Descripcion") = T_Art_Numero_Desc.Text
            f("Dias_Entrega") = T_Dias_Entrega.Text
            f("Garantia") = T_Garantia.Text
            f("Precio1") = T_Precio_Lista.Text
            f("Costo1") = T_Precio_Lista.Text
            f("Fecha_Precio1") = T_Fecha_Vigencia.Text
            f("Moneda") = T_Moneda.Text
            f("Impuesto") = T_IVA.Text
            f("Catalogo") = T_Catalogo.Text
            f("Figura") = T_Figura.Text
            f("Pagina") = T_Pagina.Text
            f("Unidad_Medida") = T_Unidad_Medida.Text
          
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal Numero As Integer)

        Dim clave(1) As String
        clave(0) = Numero
        clave(1) = T_Proveedor.Text
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Function validar() As Boolean
        validar = False
        Dim G As Glo = CType(Session("G"), Glo)
        If Movimiento.Value = "Alta" Then
            G.cn.Open()
            G.Tsql = "Select Pro_Numero,Art_Numero from Articulo_Proveedor"
            G.Tsql &= " where Pro_Numero=" & Val(T_Proveedor.Text)
            G.Tsql &= " and Art_Numero=" & Pone_Apos(T_Articulo.Text)
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            If G.dr.HasRows Then
                Msg_Error("Ya existe un registro con el articulo y proveedor seleccionado")
                Exit Function
            End If
            G.cn.Close()
        End If
        If Val(T_Proveedor.Text) = 0 Then
            Msg_Error("El registro no se puede realizar sin un proveedor") : Exit Function
        End If
        If Val(T_Precio_Lista.Text) = 0 Then
            Msg_Error("Precio inválido") : Exit Function
        End If
        If T_Fecha_Vigencia.Text = "" Or T_Fecha_Vigencia.Text.Trim = "" Then
            Msg_Error("Fecha de Vigencia inválida") : Exit Function
        End If
        Return True
    End Function

    Protected Sub TB_Proveedor_TextChanged(sender As Object, e As System.EventArgs) Handles TB_Proveedor.TextChanged
        TB_Proveedor_Descripcion.Text = Busca_Cat(Session("G"), "PROVEEDOR", TB_Proveedor.Text)
        TB_Articulo.Focus()
        TB_Proveedor_RFC.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", TB_Proveedor.Text)
    End Sub
    Protected Sub T_Proveedor_TextChanged(sender As Object, e As System.EventArgs) Handles T_Proveedor.TextChanged
        T_Proveedor_Descripcion.Text = Busca_Cat(Session("G"), "PROVEEDOR", T_Proveedor.Text)
        T_Proveedor_RFC.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", T_Proveedor.Text)
        T_Unidad_Medida.Focus()
    End Sub

    Protected Sub T_Precio_Lista_TextChanged(sender As Object, e As System.EventArgs) Handles T_Precio_Lista.TextChanged

    End Sub

    Protected Sub T_Moneda_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Moneda.TextChanged
        T_Moneda_Descripcion.Text = Busca_Cat(Session("G"), "MONEDA", T_Moneda.Text)
        T_IVA.Focus()
    End Sub

    Protected Sub TB_Articulo_TextChanged(sender As Object, e As System.EventArgs) Handles TB_Articulo.TextChanged
        TB_Articulo_Descripcion.Text = Busca_Cat(Session("G"), "ARTICULO", TB_Articulo.Text)
    End Sub

    Protected Sub Ch_Baja_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LlenaGrid()
    End Sub
End Class


