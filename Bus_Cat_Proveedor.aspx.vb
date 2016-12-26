Imports System.Data

Partial Class Bus_Cat_Proveedor
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then
            G.dt2 = New DataTable
            CrearCamposTabla()
            LlenaGrid()
            GridView1.DataSource = G.dt2
            GridView1.DataBind()
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        End If
        DibujaSpan()
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Descipcion.Attributes.Add("onfocus", "this.select();")
        T_RFC.Attributes.Add("onfocus", "this.select();")

    End Sub
    Private Sub DibujaSpan()
        Dim G As Glo = CType(Session("G"), Glo)
        Dim dtspan As New DataTable
        dtspan = G.dt2.Copy
        If G.dt2.Rows.Count = 0 Then
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
            Case "PROVEEDOR_SALIDA", "PROVEEDOR"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Razon_Social", Type.GetType("System.String")) : G.dt2.Columns("Razon_Social").DefaultValue = ""
                G.dt2.Columns.Add("RFC", Type.GetType("System.String")) : G.dt2.Columns("RFC").DefaultValue = ""
                'Dim col1, col2 As New BoundField
                'col1.HeaderText = "Razon_Social"
                'col1.DataField = "Razon_Social"
                'GridView1.Columns.Add(col1)
                'col1.HeaderText = "RFC"
                'col1.DataField = "Rfc"
                'GridView1.Columns.Add(col2)
        End Select
        Dim Tipo_Dato As String = ""
        For Each c As DataColumn In G.dt2.Columns
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
        clave(0) = G.dt2.Columns("Numero")
        G.dt2.PrimaryKey = clave
    End Sub

   
    Private Sub LlenaGrid()
        Dim Catalogo As String = Request.QueryString("Catalogo")
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.dt2.Rows.Clear()
            Select Case Catalogo
                Case "PROVEEDOR_SALIDA", "PROVEEDOR"
                    G.Tsql = "Select Numero,Razon_Social,Rfc"
                    G.Tsql &= " from Proveedor Where Baja<>'*'"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Razon_Social like '%" & T_Descipcion.Text & "%'"
                    End If
                    If T_RFC.Text.Trim <> "" Then
                        G.Tsql &= " and Rfc like '%" & T_RFC.Text & "%'"
                    End If
            End Select
            ' Se llena el Datatable
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dt2.Load(G.dr)
            If G.dr.IsClosed = False Then G.dr.Close()
            If G.dt2.Rows.Count > 0 Then
                GridView1.DataSource = G.dt2
                GridView1.DataBind()
            Else
                DibujaSpan()
            End If
        Catch ex As Exception
            Mensaje(ex.ToString)
        Finally
            G.cn.Close()
        End Try
        GridView1.DataSource = G.dt2
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
                Case "PROVEEDOR"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Proveedor(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")

                    ElseIf Numero = 1 Then
                        Hiper.Attributes.Add("onclick", "javascript:Proveedores1(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")

                    ElseIf Numero = 2 Then
                        Hiper.Attributes.Add("onclick", "javascript:Proveedores2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")

                    ElseIf Numero = 3 Then
                        Hiper.Attributes.Add("onclick", "javascript:Proveedores3(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")
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

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click
        LlenaGrid()
    End Sub
End Class
