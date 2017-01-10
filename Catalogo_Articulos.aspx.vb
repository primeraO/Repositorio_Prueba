Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Drawing
Partial Class Catalogo_Articulos
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
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
            'LLenaGrid()
            DesHabilita()
            Try
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
            Catch ex As Exception
            End Try
            TB_SubGrupo.Enabled = False
            HB_SubLinea.Attributes.Add("style", "cursor:not-allowed;")
            'RB_Opciones.Visible = False
            T_Moneda_Desc1.Text = Busca_Cat(Session("G"), "MONEDA", T_Moneda1.Text)
        End If
        Msg_Err.Visible = False
        DibujaSpan()
        T_IVA.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_IVA.ClientID & "');")
        T_Linea.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Linea.ClientID & "');")
        T_Marca.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Marca.ClientID & "');")
        T_SubLinea.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_SubLinea.ClientID & "');")

        TB_Grupo.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_SubGrupo.ClientID & "','" & TB_Grupo.ClientID & "');")
        'TB_SubGrupo.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Clas_Corta.ClientID & "','" & TB_SubGrupo.ClientID & "');")
        HB_Linea.Attributes.Add("style", "cursor:pointer;")
        'TB_Clas_Corta.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Numero.ClientID & "','" & TB_Clas_Corta.ClientID & "');")
        TB_Numero.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Descripcion.ClientID & "','" & TB_Numero.ClientID & "');")
        TB_Descripcion.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Grupo.ClientID & "','" & TB_Descripcion.ClientID & "');")
        Btn_Moneda1.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Moneda1.Attributes.Add("style", "cursor:pointer;")
        HB_Linea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Linea.Attributes.Add("style", "cursor:pointer;")
        TB_Numero.Attributes.Add("onfocus", "this.select();")
        TB_Descripcion.Attributes.Add("onfocus", "this.select();")
        TB_Grupo.Attributes.Add("onfocus", "this.select();")
        TB_SubGrupo.Attributes.Add("onfocus", "this.select();")
        'TB_Clas_Corta.Attributes.Add("onfocus", "this.select();")
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Descripcion.Attributes.Add("onfocus", "this.select();")
        T_Marca.Attributes.Add("onfocus", "this.select();")
        T_Linea.Attributes.Add("onfocus", "this.select();")
        T_SubLinea.Attributes.Add("onfocus", "this.select();")
        T_Referencia_Sustituta.Attributes.Add("onfocus", "this.select();")
        T_IVA.Attributes.Add("onfocus", "this.select();")
        T_UMedida.Attributes.Add("onfocus", "this.select();")
        T_Codigo.Attributes.Add("onfocus", "this.select();")

        T_Contado.Attributes.Add("onfocus", "this.select();")
        T_Contado.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Contado.ClientID & "');")

        T_Credito.Attributes.Add("onfocus", "this.select();")
        T_Credito.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Credito.ClientID & "');")

        T_Mayoreo.Attributes.Add("onfocus", "this.select();")
        T_Mayoreo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Mayoreo.ClientID & "');")

        T_Filial.Attributes.Add("onfocus", "this.select();")
        T_Filial.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Filial.ClientID & "');")

        T_Descuento_1.Attributes.Add("onfocus", "this.select();")
        T_Descuento_1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Descuento_1.ClientID & "');")

        T_Descuento_2.Attributes.Add("onfocus", "this.select();")
        T_Descuento_2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Descuento_2.ClientID & "');")

        T_IVA.Attributes.Add("onfocus", "this.select();")
        T_IVA.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_IVA.ClientID & "');")

        T_precio_Contado.Attributes.Add("onfocus", "this.select();")
        T_precio_Contado.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_precio_Contado.ClientID & "');")

        T_Moneda1.Attributes.Add("onfocus", "this.select();")
        T_Lote_Minimo.Attributes.Add("onfocus", "this.select();")
        T_Lote_Minimo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Lote_Minimo.ClientID & "');")

        T_Multiplos.Attributes.Add("onfocus", "this.select();")
        T_Multiplos.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Multiplos.ClientID & "');")


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
        'Tabla Condicion_Pago
        Session("dt").Columns.Add("Numero", Type.GetType("System.String")) : Session("dt").Columns("Numero").DefaultValue = ""
        Session("dt").Columns.Add("Art_Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Art_Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Mar_Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Mar_Numero").DefaultValue = 0
        Session("dt").Columns.Add("Lin_Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Lin_Numero").DefaultValue = 0
        Session("dt").Columns.Add("Sub_Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Sub_Numero").DefaultValue = 0

        Session("dt").Columns.Add("IVA", Type.GetType("System.Double")) : Session("dt").Columns("IVA").DefaultValue = 0
        Session("dt").Columns.Add("Pre_Vta_1", Type.GetType("System.Double")) : Session("dt").Columns("Pre_Vta_1").DefaultValue = 0
        Session("dt").Columns.Add("Pre_Vta_2", Type.GetType("System.Double")) : Session("dt").Columns("Pre_Vta_2").DefaultValue = 0
        Session("dt").Columns.Add("Pre_Vta_3", Type.GetType("System.Double")) : Session("dt").Columns("Pre_Vta_3").DefaultValue = 0
        Session("dt").Columns.Add("Pre_Vta_4", Type.GetType("System.Double")) : Session("dt").Columns("Pre_Vta_4").DefaultValue = 0
        Session("dt").Columns.Add("Descuento_1", Type.GetType("System.Double")) : Session("dt").Columns("Descuento_1").DefaultValue = 0
        Session("dt").Columns.Add("Descuento_2", Type.GetType("System.Double")) : Session("dt").Columns("Descuento_2").DefaultValue = 0
        Session("dt").Columns.Add("Pre_Contado", Type.GetType("System.Double")) : Session("dt").Columns("Pre_Contado").DefaultValue = 0
        Session("dt").Columns.Add("Mon_Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Mon_Numero").DefaultValue = 0
        Session("dt").Columns.Add("Lote_Minimo", Type.GetType("System.Double")) : Session("dt").Columns("Lote_Minimo").DefaultValue = 0
        Session("dt").Columns.Add("Multiplos", Type.GetType("System.Double")) : Session("dt").Columns("Multiplos").DefaultValue = 0

        Session("dt").Columns.Add("Unidad_Medida", Type.GetType("System.String")) : Session("dt").Columns("Unidad_Medida").DefaultValue = ""
        Session("dt").Columns.Add("Ref_Sub_Num", Type.GetType("System.String")) : Session("dt").Columns("Ref_Sub_Num").DefaultValue = ""
        'Session("dt").Columns.Add("Clas_Corta", Type.GetType("System.String")) : Session("dt").Columns("Clas_Corta").DefaultValue = ""
        'Session("dt").Columns.Add("IEPS", Type.GetType("System.String")) : Session("dt").Columns("IEPS").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Ficha_Tecnica", Type.GetType("System.String")) : Session("dt").Columns("Ficha_Tecnica").DefaultValue = ""
        Session("dt").Columns.Add("Ruta_Foto", Type.GetType("System.String")) : Session("dt").Columns("Ruta_Foto").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        T_Numero.Enabled = False
        T_Descripcion.Enabled = False
        T_Marca.Enabled = False
        T_Linea.Enabled = False
        T_SubLinea.Enabled = False
        T_Codigo.Enabled = False
        T_Contado.Enabled = False
        T_Credito.Enabled = False
        T_Mayoreo.Enabled = False
        T_Filial.Enabled = False
        T_Descuento_1.Enabled = False
        T_Descuento_2.Enabled = False
        T_IVA.Enabled = False
        T_precio_Contado.Enabled = False
        T_Moneda1.Enabled = False
        T_Lote_Minimo.Enabled = False
        T_Multiplos.Enabled = False
        T_IVA.Enabled = False
        T_UMedida.Enabled = False
        T_Desc_Linea.Enabled = False
        T_Desc_Marca.Enabled = False
        T_Desc_SubLinea.Enabled = False
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
        TB_Descripcion.Enabled = True
        TB_Numero.Enabled = True
        Ch_Baja.Enabled = True
        H_Linea.Attributes.Add("onclick", "")
        H_Linea.Attributes.Add("style", "cursor:not-allowed;")
        H_Marca.Attributes.Add("onclick", "")
        H_Marca.Attributes.Add("style", "cursor:not-allowed;")
        H_SubLinea.Attributes.Add("onclick", "")
        H_SubLinea.Attributes.Add("style", "cursor:not-allowed;")
        H_Articulo.Attributes.Add("onclick", "")
        H_Articulo.Attributes.Add("style", "cursor:not-allowed;")
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        'GridView1.Visible = False
        Pnl_Grids.Visible = False

        T_Numero.Enabled = True
        T_Descripcion.Enabled = True
        T_Marca.Enabled = True
        T_Linea.Enabled = True
        'T_SubLinea.Enabled = True
        T_Codigo.Enabled = True
        T_IVA.Enabled = True
        T_UMedida.Enabled = True
        T_Desc_Linea.Enabled = True
        T_Contado.Enabled = True
        T_Credito.Enabled = True
        T_Mayoreo.Enabled = True
        T_Filial.Enabled = True
        T_Descuento_1.Enabled = True
        T_Descuento_2.Enabled = True
        T_IVA.Enabled = True
        T_precio_Contado.Enabled = True
        T_Moneda1.Enabled = True
        T_Lote_Minimo.Enabled = True
        T_Multiplos.Enabled = True
        T_Desc_Marca.Enabled = True
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
        H_Linea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Linea.Attributes.Add("style", "cursor:pointer;")
        H_Marca.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MARCA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Marca.Attributes.Add("style", "cursor:pointer;")
        H_Articulo.Attributes.Add("onclick", "window.open('Bus_Cat_Articulos.aspx?Catalogo=ARTICULO',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Articulo.Attributes.Add("style", "cursor:pointer;")

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
            G.Tsql = "Select top 200 a.Numero,a.Art_Descripcion,a.Ficha_Tecnica,a.Ruta_Foto,a.Lin_Numero,a.Sub_Numero,a.IVA,a.Unidad_Medida,a.Ref_Sub_Num,a.Pre_Vta_1,a.Pre_Vta_2,a.Pre_Vta_3,a.Pre_Vta_4,a.Descuento_1,a.Descuento_2,a.Pre_Contado,a.Mon_Numero,a.Lote_Minimo,a.Multiplos"
            G.Tsql &= " from Articulos a inner join Sub_Linea b on a.Lin_Numero=b.Lin_Numero and a.Sub_Numero=b.Numero"
            If Ch_Baja.Checked = True Then
                G.Tsql &= " where a.Baja='*'"
            Else
                G.Tsql &= " where a.Baja<>'*' "
            End If
            If TB_Numero.Text.Trim <> "" Then
                G.Tsql &= " and a.Numero like '%" & TB_Numero.Text.Trim & "%'"
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and a.Art_Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            If Val(TB_Grupo.Text) > 0 Then
                G.Tsql &= " and a.Lin_Numero=" & Val(TB_Grupo.Text)
                If Val(TB_SubGrupo.Text) > 0 Then
                    G.Tsql &= " and a.Sub_Numero=" & Val(TB_SubGrupo.Text)
                End If
            End If
            G.Tsql &= " and a.Empresa=" & Val(G.Empresa_Numero)
            G.Tsql &= " Order by a.Numero"
            'Label50.Text = G.Tsql
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
        T_Marca.Text = ""
        T_Linea.Text = ""
        T_SubLinea.Text = ""
        'T_IVA.Text = ""
        T_Codigo.Text = ""
        T_UMedida.Text = ""
        T_Desc_Linea.Text = ""
        T_Desc_Marca.Text = ""
        T_Desc_SubLinea.Text = ""

        T_Contado.Text = ""
        T_Credito.Text = ""
        T_Mayoreo.Text = ""
        T_Filial.Text = ""
        T_Contado_IVA.Text = ""
        T_Credito_Iva.Text = ""
        T_Mayoreo_IVA.Text = ""
        T_Filial_IVA.Text = ""
        T_Descuento_1.Text = ""
        T_Descuento_2.Text = ""
        T_IVA.Text = ""
        T_precio_Contado.Text = ""
        T_Moneda1.Text = 0
        T_Lote_Minimo.Text = ""
        T_Multiplos.Text = ""

        Nombre_Ficha.Value = ""
        Nombre_Foto.Value = ""
    End Sub
    'Private Function Siguiente() As Integer
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Siguiente = 0
    '    Try
    '        G.cn.Open()
    '        G.Tsql = "Select Max(Numero) from Arti"
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
        If T_Numero.Text.Trim = "" Then
            Msg_Error("Numero invalido") : Exit Function
        End If
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Art_Descripcion inválida") : Exit Function
        End If
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Unidad_Medida As String, ByVal IVA As String, ByVal ruta_foto As String, ByVal ruta_ficha As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Numero
        f("Art_Descripcion") = Descripcion
        f("Unidad_Medida") = Unidad_Medida
        f("IVA") = IVA
        f("Lin_Numero") = T_Linea.Text
        f("Sub_Numero") = T_SubLinea.Text
        f("Pre_Vta_1") = T_Contado_IVA.Text
        f("Pre_Vta_2") = T_Credito_Iva.Text
        f("Pre_Vta_3") = T_Mayoreo_IVA.Text
        f("Pre_Vta_4") = T_Filial_IVA.Text
        f("Descuento_1") = T_Descuento_1.Text
        f("Descuento_2") = T_Descuento_2.Text
        f("Pre_Contado") = T_precio_Contado.Text
        f("Mon_Numero") = T_Moneda1.Text
        f("Lote_Minimo") = T_Lote_Minimo.Text
        f("Multiplos") = T_Multiplos.Text
        f("Ruta_Foto") = ruta_foto
        f("Ficha_Tecnica") = ruta_ficha

        'If CH_IEPS.Checked = True Then f("IEPS") = RB_Opciones.SelectedValue.ToString
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Unidad_Medida As String, ByVal IVA As String, ByVal ruta_foto As String, ByVal ruta_ficha As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Art_Descripcion") = Descripcion
            f("Unidad_Medida") = Unidad_Medida
            f("IVA") = IVA
            f("Lin_Numero") = T_Linea.Text

            f("Sub_Numero") = T_SubLinea.Text

            f("Pre_Vta_1") = T_Contado_IVA.Text
            f("Pre_Vta_2") = T_Credito_Iva.Text
            f("Pre_Vta_3") = T_Mayoreo_IVA.Text
            f("Pre_Vta_4") = T_Filial_IVA.Text
            f("Descuento_1") = T_Descuento_1.Text
            f("Descuento_2") = T_Descuento_2.Text
            f("Pre_Contado") = T_precio_Contado.Text
            f("Mon_Numero") = T_Moneda1.Text
            f("Lote_Minimo") = T_Lote_Minimo.Text
            f("Multiplos") = T_Multiplos.Text
            f("Ruta_Foto") = ruta_foto
            f("Ficha_Tecnica") = ruta_ficha
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

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click

        If TB_Numero.Text.Trim = "" And TB_Descripcion.Text.Trim = "" And TB_SubGrupo.Text = "" And TB_Grupo.Text = "" Then
            Msg_Error("Especificar información a buscar")
            Exit Sub
        End If
        GridView1.Visible = True
        Pnl_Grids.Visible = True
        Session("dt") = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub

    Protected Sub Ima_Alta_Click(sender As Object, e As System.EventArgs) Handles Ima_Alta.Click
        Habilita()
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Numero.Focus()
        GridView1.Enabled = False
        Pnl_Registro.Enabled = True
    End Sub

    Protected Sub Ima_Restaura_Click(sender As Object, e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub

   
    Private Sub Guardar_Ficha()
        Dim ruta As String = "C:/images"
        If Ficha_Tecnica.PostedFile Is Nothing Then
            Msg_Error("Elija una imagen de ficha tecnica antes de guardar") : Exit Sub

        End If
        Dim mi_imagen As HttpPostedFile = Ficha_Tecnica.PostedFile

        Dim ext As String
        If Ficha_Tecnica.PostedFile Is Nothing Then
            ext = ""
        Else
            ext = Ficha_Tecnica.PostedFile.FileName
        End If
        Dim formatos() As String = {"jpg", "jpeg", "bmp", "png", "gif"}
        Nombre_Ficha.Value = mi_imagen.FileName.ToString

        If mi_imagen.ContentLength > 0 Then
            ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
            If Array.IndexOf(formatos, ext) < 0 Then
                Msg_Error("Formato de imagen inválido.") : Exit Sub
            Else
                Directory.CreateDirectory(ruta)
                Dim tamaño As Integer = mi_imagen.ContentLength
                Dim datos_img As Byte() = New Byte(tamaño) {}
                mi_imagen.InputStream.Read(datos_img, 0, tamaño)
                Guardar_Archivo(ruta & "/" & mi_imagen.FileName, datos_img)
            End If
        End If
    End Sub
    Private Sub Guardar_Foto()
        If file_fotos.PostedFile Is Nothing Then
            Msg_Error("Elija una imagen de articulo antes de guardar") : Exit Sub

        End If
        Dim ruta As String = "C:/images"
        Dim mi_imagen As HttpPostedFile = file_fotos.PostedFile
        Dim ext As String
        If mi_imagen.ContentLength > 0 Then
            ext = mi_imagen.FileName
        Else
            ext = ""
        End If
        Dim formatos() As String = {"jpg", "jpeg", "bmp", "png", "gif"}
        Nombre_Foto.Value = mi_imagen.FileName.ToString

        If mi_imagen.ContentLength > 0 Then
            ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
            If Array.IndexOf(formatos, ext) < 0 Then
                Msg_Error("Formato de imagen inválido.") : Exit Sub
            Else
                Directory.CreateDirectory(ruta)
                Dim tamaño As Integer = mi_imagen.ContentLength
                Dim datos_img As Byte() = New Byte(tamaño) {}
                mi_imagen.InputStream.Read(datos_img, 0, tamaño)
                Guardar_Archivo(ruta & "/" & mi_imagen.FileName, datos_img)
            End If
        End If
    End Sub

    Protected Sub Ima_Guarda_Click(sender As Object, e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                Guardar_Ficha()
                Guardar_Foto()
                G.cn.Open()
                Tsql = "Select Numero from Articulos where Numero=" & Pone_Apos(T_Numero.Text) & " and Empresa=" & Val(G.Empresa_Numero)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el articulo: " & Pone_Apos(T_Numero.Text)) : Exit Sub
                End If
                G.Tsql = "Insert into Articulos (Empresa,Numero,Art_Descripcion,Ficha_Tecnica,Ruta_Foto,Mar_Numero,Lin_Numero,Sub_Numero,IVA,Unidad_Medida,Ref_Sub_Num,a.Pre_Vta_1,a.Pre_Vta_2,a.Pre_Vta_3,a.Pre_Vta_4,a.Descuento_1,a.Descuento_2,a.Pre_Contado,a.Mon_Numero,a.Lote_Minimo,a.Multiplos,Baja) values ("
                G.Tsql &= Val(G.Empresa_Numero)
                G.Tsql &= "," & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(Nombre_Ficha.Value.ToString)
                G.Tsql &= "," & Pone_Apos(Nombre_Foto.Value.ToString)
                G.Tsql &= "," & Val(T_Marca.Text.Trim)
                G.Tsql &= "," & Val(T_Linea.Text.Trim)
                G.Tsql &= "," & Val(T_SubLinea.Text.Trim)
                G.Tsql &= "," & Val(T_IVA.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_UMedida.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Codigo.Text.Trim)
                G.Tsql &= "," & Val(T_Contado_IVA.Text)
                G.Tsql &= "," & Val(T_Credito_Iva.Text)
                G.Tsql &= "," & Val(T_Mayoreo_IVA.Text)
                G.Tsql &= "," & Val(T_Filial_IVA.Text)
                G.Tsql &= "," & Val(T_Descuento_1.Text)
                G.Tsql &= "," & Val(T_Descuento_2.Text)
                G.Tsql &= "," & Val(T_precio_Contado.Text)
                G.Tsql &= "," & Val(T_Moneda1.Text)
                G.Tsql &= "," & Val(T_Lote_Minimo.Text)
                G.Tsql &= "," & Val(T_Multiplos.Text)
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_UMedida.Text.Trim, T_IVA.Text.Trim, Nombre_Foto.Value, Nombre_Ficha.Value.ToString)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                If Ficha_Tecnica.PostedFile.FileName > "" Then Guardar_Ficha()
                If file_fotos.PostedFile.FileName > "" Then Guardar_Foto()
                G.cn.Open()
                G.Tsql = "Update Articulos set Art_Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Mar_Numero=" & Val(T_Marca.Text.Trim)
                G.Tsql &= ",Lin_Numero=" & Val(T_Linea.Text.Trim)
                G.Tsql &= ",Sub_Numero=" & Val(T_SubLinea.Text.Trim)
                G.Tsql &= ",IVA=" & Val(T_IVA.Text.Trim)
                G.Tsql &= ",Unidad_Medida=" & Pone_Apos(T_UMedida.Text.Trim)
                G.Tsql &= ",Ref_Sub_Num=" & Pone_Apos(T_Codigo.Text.Trim)
                G.Tsql &= ",Pre_Vta_1=" & Val(T_Contado_IVA.Text)
                G.Tsql &= ",Pre_Vta_2=" & Val(T_Credito_Iva.Text)
                G.Tsql &= ",Pre_Vta_3=" & Val(T_Mayoreo_IVA.Text)
                G.Tsql &= ",Pre_Vta_4=" & Val(T_Filial_IVA.Text)
                G.Tsql &= ",Descuento_1=" & Val(T_Descuento_1.Text)
                G.Tsql &= ",Descuento_2=" & Val(T_Descuento_2.Text)
                G.Tsql &= ",Pre_Contado=" & Val(T_precio_Contado.Text)
                G.Tsql &= ",Mon_Numero=" & Val(T_Moneda1.Text)
                G.Tsql &= ",Lote_Minimo=" & Val(T_Lote_Minimo.Text)
                G.Tsql &= ",Multiplos=" & Val(T_Multiplos.Text)
                If file_fotos.PostedFile.FileName > "" Then G.Tsql &= ",Ficha_Tecnica=" & Pone_Apos(Nombre_Ficha.Value.ToString)
                If Ficha_Tecnica.PostedFile.FileName > "" Then G.Tsql &= ",Ruta_Foto=" & Pone_Apos(Nombre_Foto.Value)
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " WHERE Numero = " & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Empresa = " & Val(G.Empresa_Numero)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_UMedida.Text.Trim, T_IVA.Text.Trim, Nombre_Foto.Value.ToString, Nombre_Ficha.Value.ToString)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Articulos set Baja=" & "'*'"
                G.Tsql &= " WHERE Numero = " & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Empresa = " & Val(G.Empresa_Numero)
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
                'CH_IEPS.Checked = False
                'RB_Opciones.Visible = False
                T_Numero.Text = f.Item("Numero").ToString
                T_Descripcion.Text = f.Item("Art_Descripcion").ToString
                T_Marca.Text = f.Item("Mar_Numero").ToString
                T_Linea.Text = f.Item("Lin_Numero").ToString
                T_SubLinea.Text = f.Item("Sub_Numero").ToString
                T_IVA.Text = f.Item("IVA").ToString
                T_Codigo.Text = f.Item("Ref_Sub_Num").ToString
                T_UMedida.Text = f.Item("Unidad_Medida").ToString

                T_Contado.Text = For_Pan_Lib(f.Item("Pre_Vta_1") / Val(1 + Val(T_IVA.Text / 100)), 2)
                T_Credito.Text = For_Pan_Lib(f.Item("Pre_Vta_2") / Val(1 + Val(T_IVA.Text / 100)), 2)
                T_Mayoreo.Text = For_Pan_Lib(f.Item("Pre_Vta_3") / Val(1 + Val(T_IVA.Text / 100)), 2)
                T_Filial.Text = For_Pan_Lib(f.Item("Pre_Vta_4") / Val(1 + Val(T_IVA.Text / 100)), 2)

                T_Contado_IVA.Text = For_Pan_Lib(Val(f.Item("Pre_Vta_1")), 2)
                T_Credito_Iva.Text = For_Pan_Lib(Val(f.Item("Pre_Vta_1")), 2)
                T_Mayoreo_IVA.Text = For_Pan_Lib(Val(f.Item("Pre_Vta_1")), 2)
                T_Filial_IVA.Text = For_Pan_Lib(Val(f.Item("Pre_Vta_1")), 2)

                If f.Item("Ruta_Foto") <> "" Then
                    Dim g As New System.Web.UI.WebControls.Image
                    g.ID = "Image2"
                    g.ImageUrl = "Handler.ashx?img=" & f.Item("Ruta_Foto")
                    g.Width = 400
                    g.Height = 400
                    list2.Controls.Add(g)
                    Nombre_Foto.Value = f.Item("Ruta_Foto")

                End If
                If f.Item("Ficha_Tecnica") <> "" Then
                    Dim h As New System.Web.UI.WebControls.Image
                    h.ID = "Image3"
                    h.ImageUrl = "Handler.ashx?img=" & f.Item("Ficha_Tecnica")
                    h.Width = 400
                    h.Height = 400
                    list.Controls.Add(h)
                    Nombre_Ficha.Value = f.Item("Ficha_Tecnica")
                End If


                T_Descuento_1.Text = f.Item("Descuento_1")
                T_Descuento_2.Text = f.Item("Descuento_2")
                T_precio_Contado.Text = f.Item("Pre_Contado")
                T_Moneda1.Text = f.Item("Mon_Numero")
                T_Lote_Minimo.Text = f.Item("Lote_Minimo")
                T_Multiplos.Text = f.Item("Multiplos")
                T_Moneda_Desc1.Text = Busca_Cat(Session("G"), "MONEDA", T_Moneda1.Text)
                GridView1.Enabled = False
                'T_Desc_Marca.Text = Busca_Cat(CType(Session("G"), Glo), "MARCA", f("Mar_Numero"))
                T_Desc_Linea.Text = Busca_Cat(CType(Session("G"), Glo), "LINEA", f("Lin_Numero"))
                T_Desc_SubLinea.Text = Busca_Cat(CType(Session("G"), Glo), "SUBLINEA", f("Sub_Numero"), f("Lin_Numero"))

            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Descripcion.Enabled = False
                T_Marca.Enabled = False
                T_Linea.Enabled = False
                T_SubLinea.Enabled = False
                T_IVA.Enabled = False
                T_Codigo.Enabled = False
                T_UMedida.Enabled = False
                T_Desc_Linea.Enabled = False
                T_Desc_Marca.Enabled = False
                T_Desc_SubLinea.Enabled = False
                H_Linea.Attributes.Add("onclick", "")
                H_Linea.Attributes.Add("style", "cursor:not-allowed;")
                H_Marca.Attributes.Add("onclick", "")
                H_Marca.Attributes.Add("style", "cursor:not-allowed;")
                H_SubLinea.Attributes.Add("onclick", "")
                H_SubLinea.Attributes.Add("style", "cursor:not-allowed;")
                Pnl_Registro.Enabled = False

                Ficha_Tecnica.Disabled = True
                file_fotos.Disabled = True
            End If
            If (e.CommandName.Equals("Seleccion")) Then

                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                H_Linea.Attributes.Add("onclick", "")
                H_Linea.Attributes.Add("style", "cursor:not-allowed;")
                H_Marca.Attributes.Add("onclick", "")
                H_Marca.Attributes.Add("style", "cursor:not-allowed;")
                H_SubLinea.Attributes.Add("onclick", "")
                H_SubLinea.Attributes.Add("style", "cursor:not-allowed;")

                H_Articulo.Attributes.Add("onclick", "")
                H_Articulo.Attributes.Add("style", "cursor:not-allowed;")


                Ficha_Tecnica.Disabled = True
                file_fotos.Disabled = True
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
                T_SubLinea.Enabled = True
                T_Desc_SubLinea.Enabled = True
                Session("Linea") = Val(T_Linea.Text.Trim)
                H_SubLinea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SUB_LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                H_SubLinea.Attributes.Add("style", "cursor:pointer;")

                Ficha_Tecnica.Disabled = False
                Nombre_Ficha.Value = f.Item("Ficha_Tecnica")

                file_fotos.Disabled = False
                Nombre_Foto.Value = f.Item("Ruta_Foto")

            End If

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Numero").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Numero")
            T_Descripcion.Text = f.Item("Art_Descripcion")
        End If
    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()

    End Sub
    Protected Sub T_Marca_TextChanged(sender As Object, e As System.EventArgs) Handles T_Marca.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        G.cn.Open()
        G.Tsql = "Select Descripcion from Marca"
        G.Tsql &= " where Numero=" & Val(T_Marca.Text.Trim)
        G.Tsql &= " and Empresa=" & Val(G.Empresa_Numero)
        G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
        G.com.CommandText = G.Tsql
        Dim Desc_Mar As String = G.com.ExecuteScalar
        T_Desc_Marca.Text = Desc_Mar
        G.cn.Close()
        T_Linea.Focus()
    End Sub
    Protected Sub T_Linea_TextChanged(sender As Object, e As System.EventArgs) Handles T_Linea.TextChanged

        T_Desc_Linea.Text = Busca_Cat(Session("G"), "LINEA", T_Linea.Text)

        Session("Linea") = Val(T_Linea.Text.Trim)
        T_SubLinea.Enabled = True
        T_Desc_SubLinea.Enabled = True
        H_SubLinea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SUB_LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_SubLinea.Attributes.Add("style", "cursor:pointer;")
        T_SubLinea.Text = ""
        T_Desc_SubLinea.Text = ""
        T_SubLinea.Focus()
    End Sub



    Protected Sub T_SubLinea_TextChanged(sender As Object, e As System.EventArgs) Handles T_SubLinea.TextChanged

        T_Desc_SubLinea.Text = Busca_Cat(Session("G"), "SUBLINEA", T_SubLinea.Text, T_Linea.Text)

        T_UMedida.Focus()
    End Sub

    Protected Sub TB_Grupo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Grupo.TextChanged
        'TB_Descripcion_Grupo.Text = Busca_Cat(Session("G"), "LINEA", TB_Grupo.Text)

        Session("Linea") = Val(TB_Grupo.Text.Trim)
        TB_SubGrupo.Enabled = True
        'TB_Descripcion_Subgrupo.Enabled = True
        HB_SubLinea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SUB_LINEA&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        HB_SubLinea.Attributes.Add("style", "cursor:pointer;")
        TB_SubGrupo.Text = ""
        'TB_Descripcion_Subgrupo.Text = ""
        'TB_SubGrupo.Focus()

        'Label50.Text = TB_Grupo.Text
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub


    Protected Sub TB_Descripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Descripcion.TextChanged, TB_Numero.TextChanged, TB_SubGrupo.TextChanged
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub


    Protected Sub T_Contado_TextChanged(sender As Object, e As System.EventArgs) Handles T_Contado.TextChanged
        If T_IVA.Text > "" And T_Contado.Text > "" Then
            T_Contado_IVA.Text = For_Pan_Lib(Val(T_Contado.Text * Val(T_IVA.Text / 100)) + Val(T_Contado.Text), 2)
        End If
        If T_Contado.Text = "" Then T_Contado_IVA.Text = ""
        T_Credito.Focus()
    End Sub

    Protected Sub T_IVA_v_TextChanged(sender As Object, e As System.EventArgs) Handles T_IVA.TextChanged
        If T_IVA.Text > "" Then
            If T_Contado.Text > "" Then T_Contado_IVA.Text = For_Pan_Lib(Val(T_Contado.Text * Val(T_IVA.Text / 100)) + Val(T_Contado.Text), 2)
            If T_Credito.Text > "" Then T_Credito_Iva.Text = For_Pan_Lib(Val(T_Credito.Text * Val(T_IVA.Text / 100)) + Val(T_Credito.Text), 2)
            If T_Mayoreo.Text > "" Then T_Mayoreo_IVA.Text = For_Pan_Lib(Val(T_Mayoreo.Text * Val(T_IVA.Text / 100)) + Val(T_Mayoreo.Text), 2)
            If T_Filial.Text > "" Then T_Filial_IVA.Text = For_Pan_Lib(Val(T_Filial.Text * Val(T_IVA.Text / 100)) + Val(T_Filial.Text), 2)
        End If
        If T_IVA.Text = "" Then T_Contado_IVA.Text = "" : T_Credito_Iva.Text = "" : T_Mayoreo_IVA.Text = "" : T_Filial_IVA.Text = ""
        T_precio_Contado.Focus()
    End Sub

    Protected Sub T_Credito_TextChanged(sender As Object, e As System.EventArgs) Handles T_Credito.TextChanged
        If T_IVA.Text > "" And T_Credito.Text > "" Then
            T_Credito_Iva.Text = For_Pan_Lib(Val(T_Credito.Text * Val(T_IVA.Text / 100)) + Val(T_Credito.Text), 2)
        End If
        T_Mayoreo.Focus()
        If T_Credito.Text = "" Then T_Credito_Iva.Text = ""
    End Sub

    Protected Sub T_Mayoreo_TextChanged(sender As Object, e As System.EventArgs) Handles T_Mayoreo.TextChanged
        If T_IVA.Text > "" And T_Mayoreo.Text > "" Then
            T_Mayoreo_IVA.Text = For_Pan_Lib(Val(T_Mayoreo.Text * Val(T_IVA.Text / 100)) + Val(T_Mayoreo.Text), 2)
        End If
        T_Filial.Focus()
        If T_Mayoreo.Text = "" Then T_Mayoreo_IVA.Text = ""
    End Sub

    Protected Sub T_Filial_TextChanged(sender As Object, e As System.EventArgs) Handles T_Filial.TextChanged
        If T_IVA.Text > "" And T_Filial.Text > "" Then
            T_Filial_IVA.Text = For_Pan_Lib(Val(T_Filial.Text * Val(T_IVA.Text / 100)) + Val(T_Filial.Text), 2)
        End If
        T_Descuento_1.Focus()
        If T_Filial.Text = "" Then T_Filial_IVA.Text = ""
    End Sub

    Protected Sub T_Moneda1_TextChanged(sender As Object, e As System.EventArgs) Handles T_Moneda1.TextChanged
        T_Moneda_Desc1.Text = Busca_Cat(Session("G"), "MONEDA", T_Moneda1.Text)
    End Sub



    Private Sub Guardar_Archivo(strPath As String, ByRef Buffer As Byte())
        Try
            Dim newFile As New FileStream(strPath, FileMode.Create)
            newFile.Write(Buffer, 0, Buffer.Length)
            newFile.Close()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        End Try

    End Sub

 
End Class
