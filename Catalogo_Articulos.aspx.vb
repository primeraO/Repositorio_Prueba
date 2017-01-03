Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
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
        End If
        Msg_Err.Visible = False
        DibujaSpan()
        T_IVA.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_IVA.ClientID & "');")
        T_Linea.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Linea.ClientID & "');")
        T_Marca.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Marca.ClientID & "');")
        T_SubLinea.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_SubLinea.ClientID & "');")

        TB_Grupo.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_SubGrupo.ClientID & "','" & TB_Grupo.ClientID & "');")
        TB_SubGrupo.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Clas_Corta.ClientID & "','" & TB_SubGrupo.ClientID & "');")
        TB_Clas_Corta.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Numero.ClientID & "','" & TB_Clas_Corta.ClientID & "');")
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
        TB_Clas_Corta.Attributes.Add("onfocus", "this.select();")
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Descripcion.Attributes.Add("onfocus", "this.select();")
        T_Marca.Attributes.Add("onfocus", "this.select();")
        T_Linea.Attributes.Add("onfocus", "this.select();")
        T_SubLinea.Attributes.Add("onfocus", "this.select();")
        T_Referencia_Sustituta.Attributes.Add("onfocus", "this.select();")
        T_IVA.Attributes.Add("onfocus", "this.select();")
        T_UMedida.Attributes.Add("onfocus", "this.select();")
        T_Codigo.Attributes.Add("onfocus", "this.select();")

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
        Session("dt").Columns.Add("IVA", Type.GetType("System.Int64")) : Session("dt").Columns("IVA").DefaultValue = 0
        Session("dt").Columns.Add("Unidad_Medida", Type.GetType("System.String")) : Session("dt").Columns("Unidad_Medida").DefaultValue = ""
        Session("dt").Columns.Add("Ref_Sub_Num", Type.GetType("System.String")) : Session("dt").Columns("Ref_Sub_Num").DefaultValue = ""
        'Session("dt").Columns.Add("Clas_Corta", Type.GetType("System.String")) : Session("dt").Columns("Clas_Corta").DefaultValue = ""
        'Session("dt").Columns.Add("IEPS", Type.GetType("System.String")) : Session("dt").Columns("IEPS").DefaultValue = ""
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
        T_Descripcion.Enabled = False
        T_Marca.Enabled = False
        T_Linea.Enabled = False
        T_SubLinea.Enabled = False
        T_Codigo.Enabled = False
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
            G.Tsql = "Select top 200 a.Numero,a.Art_Descripcion,a.Lin_Numero,a.Sub_Numero,a.IVA,a.Unidad_Medida,a.Ref_Sub_Num"
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
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Unidad_Medida As String, ByVal IVA As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Numero
        f("Art_Descripcion") = Descripcion
        f("Unidad_Medida") = Unidad_Medida
        f("IVA") = IVA
        f("Lin_Numero") = T_Linea.Text
        f("Sub_Numero") = T_SubLinea.Text
        'If CH_IEPS.Checked = True Then f("IEPS") = RB_Opciones.SelectedValue.ToString
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Unidad_Medida As String, ByVal IVA As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Art_Descripcion") = Descripcion
            f("Unidad_Medida") = Unidad_Medida
            f("IVA") = IVA
            f("Lin_Numero") = T_Linea.Text

            f("Sub_Numero") = T_SubLinea.Text

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

        If TB_Numero.Text.Trim = "" And TB_Descripcion.Text.Trim = "" And TB_SubGrupo.Text = "" And TB_Grupo.Text = "" And TB_Clas_Corta.Text = "" Then
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

    Protected Sub Ima_Guarda_Click(sender As Object, e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                G.cn.Open()
                'Tsql = "Select Art_Descripcion from Articulos where Art_Descripcion=" & Pone_Apos(T_Descripcion.Text)
                'G.com.CommandText = Tsql
                'If Not G.com.ExecuteScalar Is Nothing Then
                '    Msg_Error("Ya existe el Nombre del Articulos") : Exit Sub
                'End If
                Tsql = "Select Numero from Articulos where Numero=" & Pone_Apos(T_Numero.Text) & " and Empresa=" & Val(G.Empresa_Numero)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el articulo: " & Pone_Apos(T_Numero.Text)) : Exit Sub
                End If
                G.Tsql = "Insert into Articulos (Empresa,Numero,Art_Descripcion,Mar_Numero,Lin_Numero,Sub_Numero,IVA,Unidad_Medida,Ref_Sub_Num,Baja) values ("
                G.Tsql &= Val(G.Empresa_Numero)
                G.Tsql &= "," & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Val(T_Marca.Text.Trim)
                G.Tsql &= "," & Val(T_Linea.Text.Trim)
                G.Tsql &= "," & Val(T_SubLinea.Text.Trim)
                G.Tsql &= "," & Val(T_IVA.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_UMedida.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Codigo.Text.Trim)
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_UMedida.Text.Trim, T_IVA.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Articulos set Art_Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Mar_Numero=" & Val(T_Marca.Text.Trim)
                G.Tsql &= ",Lin_Numero=" & Val(T_Linea.Text.Trim)
                G.Tsql &= ",Sub_Numero=" & Val(T_SubLinea.Text.Trim)
                G.Tsql &= ",IVA=" & Val(T_IVA.Text.Trim)
                G.Tsql &= ",Unidad_Medida=" & Pone_Apos(T_UMedida.Text.Trim)
                G.Tsql &= ",Ref_Sub_Num=" & Pone_Apos(T_Codigo.Text.Trim)
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " WHERE Numero = " & Pone_Apos(T_Numero.Text.Trim)
                G.Tsql &= " and Empresa = " & Val(G.Empresa_Numero)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_UMedida.Text.Trim, T_IVA.Text.Trim)
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


    Protected Sub TB_Clas_Corta_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Clas_Corta.TextChanged, TB_Descripcion.TextChanged, TB_Numero.TextChanged, TB_SubGrupo.TextChanged
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub

   
    Protected Sub T_Contado_TextChanged(sender As Object, e As System.EventArgs) Handles T_Contado.TextChanged, T_Credito.TextChanged, T_Mayoreo.TextChanged, T_Filial.TextChanged
        If T_IVA_v.Text > "" Then
            T_Contado_IVA.Text = Val(T_Contado.Text * Val(T_IVA.Text / 100))
            T_Credito_Iva.Text = Val(T_Credito.Text * Val(T_IVA.Text / 100))
            T_Mayoreo_IVA.Text = Val(T_Mayoreo.Text * Val(T_IVA.Text / 100))
            T_Filial_IVA.Text = Val(T_Filial.Text * Val(T_IVA.Text / 100))
        End If
    End Sub

    Protected Sub T_IVA_v_TextChanged(sender As Object, e As System.EventArgs) Handles T_IVA_v.TextChanged
        If T_Contado.Text > 0 Then T_Contado_IVA.Text = Val(T_Contado.Text * Val(T_IVA.Text / 100))
        T_Credito_Iva.Text = Val(T_Credito.Text * Val(T_IVA.Text / 100))
        T_Mayoreo_IVA.Text = Val(T_Mayoreo.Text * Val(T_IVA.Text / 100))
        T_Filial_IVA.Text = Val(T_Filial.Text * Val(T_IVA.Text / 100))
    End Sub
End Class
