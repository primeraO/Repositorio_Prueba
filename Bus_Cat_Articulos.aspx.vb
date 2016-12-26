Imports System.Data
Partial Class Bus_Cat_Articulos
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then
            G.dt3 = New DataTable
            CrearCamposTabla()
            LlenaGrid()
            GridView1.DataSource = G.dt3
            GridView1.DataBind()
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
            H_Grupo.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
            H_Grupo.Attributes.Add("style", "cursor:pointer;")
            T_Sub_Grupo.Enabled = False
            T_Sub_Grupo_Desc.Enabled = False
        End If
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Grupo.Attributes.Add("onfocus", "this.select();")
        T_Sub_Grupo.Attributes.Add("onfocus", "this.select();")
        T_Descripcion.Attributes.Add("onfocus", "this.select();")

        DibujaSpan()
    End Sub
    Private Sub DibujaSpan()
        Dim G As Glo = CType(Session("G"), Glo)
        Dim dtspan As New DataTable
        dtspan = G.dt3.Copy
        If G.dt3.Rows.Count = 0 Then
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
    Private Sub CrearCamposTabla()
        Dim Catalogo As String = Request.QueryString("Catalogo")

        Dim G As Glo = CType(Session("G"), Glo)
        G.Elemento = Request.QueryString("Elemento")
        Select Case Catalogo
            Case "ARTICULO", "ARTICULO_IEPS"
                G.dt3.Columns.Add("Numero", Type.GetType("System.String")) : G.dt3.Columns("Numero").DefaultValue = ""
                G.dt3.Columns.Add("Art_Descripcion", Type.GetType("System.String")) : G.dt3.Columns("Art_Descripcion").DefaultValue = ""
                G.dt3.Columns.Add("Lin_Numero", Type.GetType("System.Int64")) : G.dt3.Columns("Lin_Numero").DefaultValue = 0
                G.dt3.Columns.Add("Sub_Numero", Type.GetType("System.Int64")) : G.dt3.Columns("Sub_Numero").DefaultValue = 0
        End Select
        Dim Tipo_Dato As String = ""
        For Each c As DataColumn In G.dt3.Columns
            If c.ColumnName = "Numero" Then
                Tipo_Dato = c.DataType.ToString
                Exit For
            End If
        Next

        If Tipo_Dato = "System.String" Then
            GridView1.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Left
        Else
            GridView1.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Right
        End If

        Dim clave(0) As DataColumn
        clave(0) = G.dt3.Columns("Numero")
        G.dt3.PrimaryKey = clave
    End Sub


    Private Sub LlenaGrid()
        Dim Catalogo As String = Request.QueryString("Catalogo")
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.dt3.Rows.Clear()
            Select Case Catalogo
                Case "ARTICULO"
                    G.Tsql = "Select top 200 Numero,Art_Descripcion,Lin_Numero,Sub_Numero from Articulos Where Baja<>'*' and Obra=" & Pone_Apos(G.Sucursal) & " and Cia=" & Val(Session("Cia"))
                    If T_Numero.Text <> "" Then
                        G.Tsql &= " and Numero LIKE '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descripcion.Text.Trim <> "" Then
                        G.Tsql &= " and Art_Descripcion like '%" & T_Descripcion.Text & "%'"
                    End If
                    If Val(T_Grupo.Text.Trim) > 0 Then
                        G.Tsql &= " and Lin_Numero=" & Val(T_Grupo.Text)
                        If Val(T_Sub_Grupo.Text) > 0 Then
                            G.Tsql &= " and Sub_Numero=" & Val(T_Sub_Grupo.Text.Trim)
                        End If
                    End If
                    G.Tsql &= " order by Numero"
                Case "ARTICULO_IEPS"
                    G.Tsql = "Select top 200 Numero,Art_Descripcion,Lin_Numero,Sub_Numero from Articulos Where Baja<>'*' and Obra=" & Pone_Apos(G.Sucursal) & " and Cia=" & Val(Session("Cia")) & " and IEPS<>''"
                    If T_Numero.Text <> "" Then
                        G.Tsql &= " and Numero LIKE '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descripcion.Text.Trim <> "" Then
                        G.Tsql &= " and Art_Descripcion like '%" & T_Descripcion.Text & "%'"
                    End If
                    If Val(T_Grupo.Text.Trim) > 0 Then
                        G.Tsql &= " and Lin_Numero=" & Val(T_Grupo.Text)
                        If Val(T_Sub_Grupo.Text) > 0 Then
                            G.Tsql &= " and Sub_Numero=" & Val(T_Sub_Grupo.Text.Trim)
                        End If
                    End If
                    G.Tsql &= " order by Numero"
                    'If T_RFC.Text.Trim <> "" Then
                    '    G.Tsql &= " and Rfc like '%" & T_RFC.Text & "%'"
                    'End If
            End Select
            ' Se llena el Datatable
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dt3.Load(G.dr)
            If G.dr.IsClosed = False Then G.dr.Close()
            If G.dt3.Rows.Count > 0 Then
                GridView1.DataSource = G.dt3
                GridView1.DataBind()
                Cabecera.DataSource = New List(Of String)
                Cabecera.DataBind()
            Else
                DibujaSpan()
            End If
        Catch ex As Exception
            'Mensaje(ex.ToString)
        Finally
            G.cn.Close()
        End Try
        GridView1.DataSource = G.dt3
        GridView1.DataBind()
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LlenaGrid()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Hiper As ImageButton = CType(e.Row.FindControl("Seleccionar"), ImageButton)
            Dim Catalogo As String = Request.QueryString("Catalogo")
            Dim Numero As String = ""
            If Request.QueryString("Num") <> "" Then
                Numero = Request.QueryString("Num")
            End If
            Select Case Catalogo
                Case "ARTICULO", "ARTICULO_IEPS"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Articulo('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Articulos('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "','" + Numero + "')")
                    End If
            End Select
        End If
    End Sub

    Private Sub Crea_Columna_Grid(ByVal Datafield As String, ByVal Header As String)
        Dim col As New BoundField
        col.DataField = Datafield
        col.HeaderText = Header
        GridView1.Columns.Add(col)
    End Sub

    Protected Sub T_Grupo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Grupo.TextChanged
        Session("Linea") = T_Grupo.Text.Trim
        T_Sub_Grupo.Enabled = True
        T_Sub_Grupo_Desc.Enabled = True
        H_Sub_Grupo.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SUB_LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Sub_Grupo.Attributes.Add("style", "cursor:pointer;")
    End Sub

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click
        LlenaGrid()
    End Sub
End Class
