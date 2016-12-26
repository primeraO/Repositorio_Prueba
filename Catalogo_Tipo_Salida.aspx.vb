Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Tipo_Salida
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
        T_Catalogo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Catalogo.ClientID & "');")
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        Msg_Err.Visible = False
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
        'Session("dt").Columns.Add("Cia", Type.GetType("System.Int64")) : Session("dt").Columns("Cia").DefaultValue = 0
        'Session("dt").Columns.Add("Obra", Type.GetType("System.String")) : Session("dt").Columns("Obra").DefaultValue = ""
        Session("dt").Columns.Add("Tipo", Type.GetType("System.Int64")) : Session("dt").Columns("Tipo").DefaultValue = 0
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Catalogo", Type.GetType("System.Int64")) : Session("dt").Columns("Catalogo").DefaultValue = 0
        Session("dt").Columns.Add("Clasifica", Type.GetType("System.String")) : Session("dt").Columns("Clasifica").DefaultValue = ""
        Session("dt").Columns.Add("Referencia", Type.GetType("System.String")) : Session("dt").Columns("Referencia").DefaultValue = ""
        'Session("dt").Columns.Add("Cve_Seg", Type.GetType("System.String")) : Session("dt").Columns("Cve_Seg").DefaultValue = ""
        'Session("dt").Columns.Add("Fecha_Seg", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Seg").DefaultValue = ""
        'Session("dt").Columns.Add("Hora_Seg", Type.GetType("System.String")) : Session("dt").Columns("Hora_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Tipo")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Numero.Enabled = False
        T_Descripcion.Enabled = False
        T_Catalogo.Enabled = False
        Ch_Clasifica.Enabled = False
        Ch_Referencia.Enabled = False
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

    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False

        T_Numero.Enabled = True
        T_Descripcion.Enabled = True
        T_Catalogo.Enabled = True
        Ch_Clasifica.Enabled = True
        Ch_Referencia.Enabled = True
        'T_Clasifica.Enabled = True
        'T_Referencia.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        GridView1.Enabled = False
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
            G.Tsql = "Select Tipo,Descripcion,Catalogo,Clasifica,Referencia from Tipo_Salida "
            G.Tsql &= " Where Tipo<>0 "
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*'"
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If Val(TB_Numero.Text.Trim) <> 0 Then
                G.Tsql &= " and Tipo =" & Val(TB_Numero.Text.Trim)
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            G.Tsql &= " Order by Tipo"
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
        T_Catalogo.Text = ""
        Ch_Clasifica.Checked = False
        Ch_Referencia.Checked = False
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Tipo) from Tipo_Salida"
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
        If Val(T_Numero.Text.Trim) = 0 Then
            Msg_Error("Numero invalido") : Exit Function
        End If
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Descripcion inválida") : Exit Function
        End If
        If T_Catalogo.Text.Trim = "" Then
            Msg_Error("Catalogo inválido") : Exit Function
        End If
        'If T_Clasifica.Text.Trim = "" Then
        '    Msg_Error("Clasificacion inválida") : Exit Function
        'End If
        'If T_Referencia.Text.Trim = "" Then
        '    Msg_Error("Referencia inválida") : Exit Function
        'End If
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Catalogo As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Tipo") = Numero
        f("Descripcion") = Descripcion
        f("Catalogo") = Catalogo
       
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Catalogo As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Descripcion") = Descripcion
            f("Catalogo") = Catalogo
           
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
        T_Descripcion.Focus()
        Pnl_Registro.Enabled = True
        GridView1.Enabled = False
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
            G.cn.Open()

            If Movimiento.Value = "Alta" Then
                Tsql = "Select Descripcion from Tipo_Salida where Descripcion=" & Pone_Apos(T_Descripcion.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe la Descripcion de la Salida") : Exit Sub
                End If
                G.Tsql = "Insert into Tipo_Salida (Tipo,Descripcion,Catalogo,Clasifica,Referencia,Baja) values ("
                'G.Tsql &= Val(Session("Cia"))
                'G.Tsql &= "," & Pone_Apos(Session("Obra"))
                G.Tsql &= T_Numero.Text.Trim
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Catalogo.Text.Trim)
                If Ch_Clasifica.Checked = True Then
                    G.Tsql &= "," & "'S'"
                Else
                    G.Tsql &= "," & "'N'"
                End If
                If Ch_Referencia.Checked = True Then
                    G.Tsql &= "," & "'S'"
                Else
                    G.Tsql &= "," & "'N'"
                End If
                'G.Tsql &= "," & Pone_Apos(T_Clasifica.Text.Trim)
                'G.Tsql &= "," & Pone_Apos(T_Referencia.Text.Trim)
                'G.Tsql &= "," & Pone_Apos(Session("Contraseña"))
                'G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                'G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Catalogo.Text.Trim)
                LimpiaCampos()
                G.cn.Close()
                LLenaGrid()
                DibujaSpan()
            End If
            If Movimiento.Value = "Cambio" Then
                'G.Tsql = "Update Comprador set Cia=" & Val(Session("Cia"))
                'G.Tsql &= ",Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql = "Update Tipo_Salida set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Catalogo=" & Val(T_Catalogo.Text.Trim)
                If Ch_Clasifica.Checked = True Then
                    G.Tsql &= ",Clasifica=" & "'S'"
                Else
                    G.Tsql &= ",Clasifica=" & "'N'"
                End If
                If Ch_Referencia.Checked = True Then
                    G.Tsql &= ",Referencia=" & "'S'"
                Else
                    G.Tsql &= ",Referencia=" & "'N'"
                End If
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Tipo=" & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Catalogo.Text.Trim)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
                G.cn.Close()
                LLenaGrid()
                DibujaSpan()
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Tipo_Salida set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Catalogo=" & Val(T_Catalogo.Text.Trim)
                If Ch_Clasifica.Checked = True Then
                    G.Tsql &= ",Clasifica=" & "'S'"
                Else
                    G.Tsql &= ",Clasifica=" & "'N'"
                End If
                If Ch_Referencia.Checked = True Then
                    G.Tsql &= ",Referencia=" & "'S'"
                Else
                    G.Tsql &= ",Referencia=" & "'N'"
                End If
                G.Tsql &= ",Baja='*'"
                G.Tsql &= " Where Tipo=" & Val(T_Numero.Text.Trim)
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
                T_Numero.Text = f.Item("Tipo")
                T_Descripcion.Text = f.Item("Descripcion")
                T_Catalogo.Text = f.Item("Catalogo")

                If f.Item("Clasifica").Equals("S") Then
                    Ch_Clasifica.Checked = True
                Else
                    Ch_Clasifica.Checked = False
                End If

                If f.Item("Referencia").Equals("S") Then
                    Ch_Referencia.Checked = True
                Else
                    Ch_Referencia.Checked = False
                End If
                Habilita()
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Descripcion.Enabled = False
                T_Catalogo.Enabled = False
                Ch_Clasifica.Enabled = False
                Ch_Referencia.Enabled = False
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"

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
            End If

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Tipo").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Tipo")
            T_Descripcion.Text = f.Item("Descripcion")
            T_Catalogo.Text = f.Item("Catalogo")
            If f.Item("Clasifica").Equals("S") Then
                Ch_Clasifica.Checked = True
            Else
                Ch_Clasifica.Checked = False
            End If
            If f.Item("Referencia").Equals("S") Then
                Ch_Referencia.Checked = True
            Else
                Ch_Referencia.Checked = False
            End If
            
        End If
    End Sub

   
    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub
End Class
