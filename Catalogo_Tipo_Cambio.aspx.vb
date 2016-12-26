Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Tipo_Cambio
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            LLenaGrid()
            DesHabilita()
            Try
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"

            Catch ex As Exception

            End Try

            T_Fecha.Text = Fecha_AMD(Now)
        End If
        Msg_Err.Visible = False
        DibujaSpan()
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        T_Moneda.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Moneda.ClientID & "');")
        T_Cambio.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Cambio.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Cambio.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Cambio.ClientID & "');")
        T_Cambio.Attributes.Add("onFocus", "javascript: QuitaComas('" & T_Cambio.ClientID & "');")

        T_Cambio_Compras.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Cambio_Compras.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Cambio_Compras.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Cambio_Compras.ClientID & "');")
        T_Cambio_Compras.Attributes.Add("onFocus", "javascript: QuitaComas('" & T_Cambio_Compras.ClientID & "');")
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
    Private Sub LimpiaCampos()
        T_Moneda.Text = "0"
        T_Moneda_Desc.Text = ""
        T_Fecha.Text = Fecha_AMD(Now)
        T_Cambio.Text = "0.00"
        T_Cambio_Compras.Text = "0.00"
    End Sub
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Mon_Numero", GetType(System.Int64)) : Session("dt").Columns("Mon_Numero").DefaultValue = 0
        Session("dt").Columns.Add("Moneda_Desc", GetType(System.String)) : Session("dt").Columns("Moneda_Desc").DefaultValue = ""
        Session("dt").Columns.Add("Fecha", GetType(System.String)) : Session("dt").Columns("Fecha").DefaultValue = ""
        Session("dt").Columns.Add("Cambio", GetType(System.Double)) : Session("dt").Columns("Cambio").DefaultValue = 0
        Session("dt").Columns.Add("Cambio_Compras", GetType(System.Double)) : Session("dt").Columns("Cambio_Compras").DefaultValue = 0
        Dim clave(1) As DataColumn
        clave(0) = Session("dt").Columns("Mon_Numero")
        clave(1) = Session("dt").Columns("Fecha")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Function validar() As Boolean
        validar = False
        If Val(T_Moneda.Text) = 0 Or T_Moneda_Desc.Text.Trim = "" Then
            Msg_Error("Moneda inválida") : Exit Function
        End If
        If Not IsDate(T_Fecha.Text.Trim) Then
            Msg_Error("Fecha inválida") : Exit Function
        End If
        If Val(Elimina_Comas(T_Cambio.Text.Trim)) = 0 Then
            Msg_Error("Tipo de Cambio inválido") : Exit Function
        End If
        'If Val(Elimina_Comas(T_Cambio_Compras.Text.Trim)) = 0 Then
        '    Msg_Error("Cambio Compras inválido") : Exit Function
        'End If
        Return True
    End Function
    Private Sub AñadeFilaGrid()
        Dim f As DataRow = Session("dt").NewRow()
        f("Mon_Numero") = Val(T_Moneda.Text)
        f("Moneda_Desc") = T_Moneda_Desc.Text
        f("Fecha") = T_Fecha.Text.Trim
        f("Cambio") = Val(Elimina_Comas(T_Cambio.Text))
        f("Cambio_Compras") = Val(Elimina_Comas(T_Cambio_Compras.Text))
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Function Busca_Cat(ByVal Catalogo As String, ByVal Clave As String) As String
        Busca_Cat = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            Select Case Catalogo.ToUpper
                Case "MONEDA"
                    G.Tsql = "Select a.Descripcion "
                    G.Tsql &= " from Moneda a Where a.Baja<>'*' and a.Moneda=" & Val(Clave)
                    G.com.CommandText = G.Tsql
                    G.dr = G.com.ExecuteReader
                    If G.dr.Read Then
                        Busca_Cat = G.dr("Descripcion")
                    End If
                    If G.dr.IsClosed = False Then G.dr.Close()
            End Select
            If G.Tsql <> "" Then
                G.com.CommandText = G.Tsql
                Busca_Cat = G.com.ExecuteScalar
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function
    Private Sub CambiaFilaGrid(ByVal Moneda As String, ByVal Fecha As String)
        Dim clave(1) As String
        clave(0) = Moneda
        clave(1) = Fecha
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Cambio") = Val(Elimina_Comas(T_Cambio.Text))
            f("Cambio_Compras") = Val(Elimina_Comas(T_Cambio_Compras.Text))
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal Moneda As String, ByVal Fecha As String)
        Dim clave(1) As String
        clave(0) = Moneda
        clave(1) = Fecha
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
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
            Session("dt").rows.Clear()
            G.cn.Open()
            G.Tsql = "Select a.Mon_Numero,b.Descripcion as Moneda_Desc,a.Fecha,a.Cambio,a.Cambio_Compras from Tipo_Cambio a "
            G.Tsql &= " left join Moneda b on a.Mon_Numero=b.Moneda "
            G.Tsql &= " where a.Mon_Numero>=0 "
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and a.Baja='*' "
            Else
                G.Tsql &= " and a.Baja<>'*' "
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and b.Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            If TB_Numero.Text <> "" Then
                G.Tsql &= " and a.Mon_Numero=" & Val(TB_Numero.Text.Trim)
            End If
            G.Tsql &= " Order by Mon_Numero,Fecha"
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
    Public Sub Ejecuta_Est(ByVal tsql As String)
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.com.CommandText = tsql
            G.com.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub



    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Or (e.CommandName.Equals("Seleccion")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(1) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Clave(1) = (GridView1.Rows(ind).Cells(3).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Moneda.Text = f("Mon_Numero")
                T_Moneda_Desc.Text = f("Moneda_Desc")
                T_Fecha.Text = f("Fecha")
                T_Cambio.Text = For_Pan_Lib(f("Cambio"), 2)
                T_Cambio_Compras.Text = For_Pan_Lib(f("Cambio_Compras"), 2)
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Moneda.Enabled = False : desboton(H_Moneda) : T_Moneda_Desc.Enabled = False
                T_Fecha.Enabled = False
                Pnl_Registro.Enabled = False
                H_Moneda.Attributes.Add("onclick", "")
                H_Moneda.Attributes.Add("style", "cursor:not-allowed;")
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                H_Moneda.Attributes.Add("onclick", "")
                H_Moneda.Attributes.Add("style", "cursor:not-allowed;")
                T_Fecha.Enabled = False
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                Habilita()
                T_Moneda.Enabled = False : desboton(H_Moneda) : T_Moneda_Desc.Enabled = False
                T_Fecha.Enabled = False
                T_Cambio.Focus()
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
            End If

        End If
    End Sub

    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        desboton(H_Moneda)
        T_Moneda.Enabled = False
        T_Moneda_Desc.Enabled = False
        T_Fecha.Enabled = False
        T_Cambio.Enabled = False
        T_Cambio_Compras.Enabled = False
        TB_Numero.Enabled = True
        TB_Descripcion.Enabled = True
        Movimiento.Value = ""
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        GridView1.Enabled = True
        Ch_Baja.Enabled = True
    End Sub
    Private Sub desboton(ByRef boton As HyperLink)
        boton.Attributes.Add("style", "cursor:not-allowed;")
        boton.Attributes.Add("onclick", "")
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False


        H_Moneda.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Moneda.Attributes.Add("style", "cursor:pointer;")
        T_Moneda.Enabled = True
        T_Moneda_Desc.Enabled = True
        T_Fecha.Enabled = True
        T_Cambio.Enabled = True
        T_Cambio_Compras.Enabled = True
        TB_Numero.Enabled = False
        TB_Descripcion.Enabled = False
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        Ch_Baja.Enabled = False
        GridView1.Enabled = False
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Frente").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Moneda.Text = f.Item("Mon_Numero")
            T_Moneda_Desc.Text = f.Item("Moneda_Desc")
            T_Fecha.Text = f.Item("Fecha")
            T_Cambio.Text = f.Item("Cambio")
            T_Cambio_Compras.Text = f.Item("Cambio_Compras")
        End If
    End Sub
    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click
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
    Protected Sub Ima_Alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Alta.Click
        Ch_Baja.Checked = False
        Habilita()
        T_Moneda.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Moneda.Focus()
        GridView1.Enabled = False
        Pnl_Registro.Enabled = True

    End Sub
    Protected Sub Ima_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                G.cn.Open()
                Tsql = "Select Mon_Numero from Tipo_Cambio where Mon_Numero=" & Val(T_Moneda.Text)
                Tsql &= " and Fecha=" & Pone_Apos(T_Fecha.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el Tipo Cambio") : Exit Sub
                End If
                G.Tsql = "Insert into Tipo_Cambio (Mon_Numero,Fecha,Cambio,Cambio_Compras,Baja) values ("
                G.Tsql &= Val(T_Moneda.Text)
                G.Tsql &= "," & Pone_Apos(T_Fecha.Text)
                G.Tsql &= "," & Val(Elimina_Comas(T_Cambio.Text.Trim))
                G.Tsql &= "," & Val(Elimina_Comas(T_Cambio_Compras.Text.Trim))
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid()
                LimpiaCampos()
            End If

            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Tipo_Cambio set Cambio=" & Val(Elimina_Comas(T_Cambio.Text))
                G.Tsql &= ",Cambio_Compras=" & Val(Elimina_Comas(T_Cambio_Compras.Text))
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Mon_Numero=" & Val(T_Moneda.Text.Trim)
                G.Tsql &= " and Fecha= " & Pone_Apos(T_Fecha.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Moneda.Text, T_Fecha.Text)
                If Ch_Baja.Checked Then
                    EliminaFilaGrid(T_Moneda.Text, T_Fecha.Text)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Tipo_Cambio set Baja=" & "'*'"
                G.Tsql &= " Where Mon_Numero=" & Val(T_Moneda.Text.Trim)
                G.Tsql &= " and Fecha= " & Pone_Apos(T_Fecha.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid(T_Moneda.Text, T_Fecha.Text)
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
    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub

    Protected Sub T_Moneda_TextChanged(sender As Object, e As System.EventArgs) Handles T_Moneda.TextChanged
        T_Moneda_Desc.Text = Busca_Cat("MONEDA", T_Moneda.Text)
        T_Cambio.Focus()
    End Sub
End Class
