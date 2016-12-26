Imports System.Data
Partial Class Consulta_Seguimiento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim G As Glo = CType(Session("G"), Glo)
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Session("dt") = New DataTable
            T_Fecha1.Text = Fecha_AMD(Now)
            T_Fecha2.Text = Fecha_AMD(Now)
            CrearCamposTabla()
            'GridView1.DataSource = Session("dt")
            'GridView1.DataBind()
            Session("dt") = New DataTable
            CrearCamposTabla()
            'DesHabilita()
            LLenaGrid()
            Img_Logotipo.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Img_Logotipo.Style("Height") = Int(Session("Logo_Height")) & "px"
            Img_Logotipo.Style("Width") = Int(Session("Logo_Width")) & "px"
        End If
        DibujaSpan()
        Btn_Usuario.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=USUARIO',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Usuario.Attributes.Add("style", "cursor:pointer;")
        'T_Fecha1.Attributes.Add("readonly", "true")
        'T_Fecha2.Attributes.Add("readonly", "true")
        Msg_Err.Visible = False
    End Sub

    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Numero", GetType(System.Int64)) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Usuario", GetType(System.String)) : Session("dt").Columns("Usuario").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion_Punto", GetType(System.String)) : Session("dt").Columns("Descripcion_Punto").DefaultValue = 0
        Session("dt").Columns.Add("Fecha", GetType(System.String)) : Session("dt").Columns("Fecha").DefaultValue = ""
        Session("dt").Columns.Add("Hora", GetType(System.String)) : Session("dt").Columns("Hora").DefaultValue = ""
        Session("dt").Columns.Add("E_S", GetType(System.String)) : Session("dt").Columns("E_S").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub

    Private Sub LLenaGrid()
        Try
            dt = LLena_Datatable()
            If Session("dt").Rows.Count > 0 Then
                GridView1.DataSource = Session("dt")
                GridView1.DataBind()
                Cabecera.DataSource = New List(Of String)
                Cabecera.DataBind()
            Else
                DibujaSpan()
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        End Try
    End Sub

    Private Function LLena_Datatable() As DataTable
        Session("dt").Rows.Clear()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select top 2000 Numero,Usuario,Descripcion_Punto,Fecha,Hora,E_S from Seguimiento Where Numero>0"
            If TB_Usuario.Text.Trim > "" Then
                G.Tsql &= " and Usuario like '%" & TB_Usuario.Text & "%'"
            End If
            If Ch_Fecha.Checked Then
                If T_Fecha1.Text = T_Fecha2.Text Then
                    G.Tsql &= " and Fecha=" & Pone_Apos(T_Fecha1.Text)
                Else
                    G.Tsql &= " and Fecha>=" & Pone_Apos(T_Fecha1.Text) & " and Fecha<=" & Pone_Apos(T_Fecha2.Text)
                End If
            End If
            G.Tsql &= " and Cia=" & G.Empresa_Numero
            G.Tsql &= " and Obra=" & G.Sucursal
            G.Tsql &= " Order by Usuario,Fecha,Hora Asc"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
        Catch ex As Exception
            Msg_Error(ex.Message)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function

    Private Sub DibujaSpan()
        Dim dtspan As New DataTable
        dtspan = Session("dt").Copy
        If Session("dt").Rows.Count = 0 Then
            Dim f As DataRow = dtspan.NewRow()
            'f("Lote") = 0
            'f("Fecha_Lote") = ""
            'f("Fletero") = 0
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

    Protected Sub Btn_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Busca.Click
        LLenaGrid()
        Pnl_Grids.Visible = True
        GridView1.Visible = True
        'Session("dt") = LLena_Datatable()
        'If Session("dt").Rows.Count > 0 Then
        '    GridView1.DataSource = Session("dt")
        '    GridView1.DataBind()
        '    Cabecera.DataSource = New List(Of String)
        '    Cabecera.DataBind()
        'Else
        '    DibujaSpan()
        'End If
    End Sub

    Protected Sub Btn_Salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    'Protected Sub TB_Usuario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Usuario.TextChanged
    '    Btn_Busca_Click(Nothing, Nothing)
    'End Sub

    Protected Sub Ch_Fecha_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ch_Fecha.CheckedChanged
        
        LLenaGrid()
        Pnl_Grids.Visible = True
        GridView1.Visible = True
        'Session("dt") = LLena_Datatable()
        'If Session("dt").Rows.Count > 0 Then
        '    GridView1.DataSource = Session("dt")
        '    GridView1.DataBind()
        '    Cabecera.DataSource = New List(Of String)
        '    Cabecera.DataBind()
        'Else
        '    DibujaSpan()
        'End If
    End Sub
End Class
