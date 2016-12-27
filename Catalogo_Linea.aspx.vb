Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Linea
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

        End If
        Msg_Err.Visible = False
        DibujaSpan()
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        T_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Numero.ClientID & "');")

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
        T_Numero.Text = ""
        T_Descripcion.Text = ""
        T_Aplicacion.Text = ""

    End Sub
    Private Sub CrearCamposTabla()
        'Tabla Linea'
        Session("dt").Columns.Add("Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Aplicacion", Type.GetType("System.String")) : Session("dt").Columns("Aplicacion").DefaultValue = ""
        Session("dt").Columns.Add("Nombre", Type.GetType("System.String")) : Session("dt").Columns("Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Fec_cambio", Type.GetType("System.String")) : Session("dt").Columns("Fec_cambio").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Function validar() As Boolean
        validar = False
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Nombre inválido") : Exit Function
        End If

        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal LineaNumero As String, ByVal Nombre As String, ByVal Aplicacion As String)
        Dim f As DataRow = Session("dt").NewRow()
        'f("EmpresaNumero") = EmpresaNumero
        f("Numero") = LineaNumero
        f("Descripcion") = Nombre
        f("Aplicacion") = Aplicacion
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal LineaNumero As String, ByVal Nombre As String, ByVal Aplicacion As String)
        Dim clave(0) As String
        clave(0) = LineaNumero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Descripcion") = Nombre
            f("Aplicacion") = Aplicacion
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal LineaNumero As Integer)
        Dim clave(0) As String
        clave(0) = LineaNumero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
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
        Try
            Session("dt").Rows.Clear()
            G.cn.Open()
            G.Tsql = "Select Linea.Numero,Linea.Descripcion,Linea.Aplicacion from Linea"
            G.Tsql &= " Where Linea.Empresa=" & Val(G.Empresa_Numero)
            G.Tsql &= " and Linea.Sucursal=" & Pone_Apos(G.Sucursal)
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Linea.Baja='*' "
            Else
                G.Tsql &= " and Linea.Baja<>'*' "
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Linea.Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            If TB_Numero.Text <> "" Then
                G.Tsql &= " and Numero=" & Val(TB_Numero.Text.Trim)
            End If
            G.Tsql &= " Order by Linea.Numero"
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


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Or (e.CommandName.Equals("Seleccion")) Then
            T_Descripcion.Focus()
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f("Numero")
                T_Aplicacion.Text = f("Aplicacion")
                T_Descripcion.Text = f("Descripcion")
                Dim G As Glo = CType(Session("G"), Glo)
                'G.cn.Open()
                'G.Tsql = "Select Responsable.Responsable from Responsable inner join Linea on Linea.Responsable=Responsable.Responsable"
                'G.Tsql &= " where Responsable.Nombre=" & Pone_Apos(f("Nombre"))
                'G.Tsql &= "And Linea.Numero=" & Pone_Apos(f("Numero"))
                'G.com.CommandText = G.Tsql
                'Dim Valor As String = G.com.ExecuteScalar
                'G.cn.Close()

            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Aplicacion.Enabled = False
                T_Descripcion.Enabled = False


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
                T_Numero.Enabled = False
                T_Aplicacion.Focus()
                Habilita()
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
            End If

        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Numero.Enabled = False
        T_Descripcion.Enabled = False
        T_Aplicacion.Enabled = False

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

    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False

        T_Numero.Enabled = True
        T_Descripcion.Enabled = True
        T_Aplicacion.Enabled = True


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
        GridView1.Enabled = False
        Ch_Baja.Enabled = False


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
        LLenaGrid()

        Ch_Baja.Checked = False
        Habilita()
        T_Numero.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Numero.Text = Siguiente()
        T_Descripcion.Focus()
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
                T_Numero.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select Descripcion from Linea where Descripcion=" & Pone_Apos(T_Descripcion.Text)
                Tsql &= " and Empresa=" & Val(G.Empresa_Numero)
                Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe una Linea con esa Descripción") : Exit Sub
                End If
                G.Tsql = "Insert into Linea (Empresa,Sucursal,Numero,Descripcion,Aplicacion,Fec_cambio,Baja) values ("
                G.Tsql &= Val(G.Empresa_Numero)
                G.Tsql &= "," & Pone_Apos(G.Sucursal)
                G.Tsql &= "," & T_Numero.Text.Trim
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                'LLenaGrid()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Aplicacion.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Linea set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Aplicacion=" & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= ",Fec_cambio=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Empresa=" & Val(G.Empresa_Numero)
                G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
                G.Tsql &= " and Numero=" & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Aplicacion.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Linea set Baja=" & "'*'"
                G.Tsql &= " Where Empresa=" & Val(G.Empresa_Numero)
                G.Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
                G.Tsql &= " and Numero=" & Val(T_Numero.Text.Trim)
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
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Numero) from Linea "
            'G.Tsql &= "inner join Responsable on Responsable.Responsable=Linea.Responsable"
            G.Tsql &= " Where Linea.Empresa=" & Val(G.Empresa_Numero) & " and Linea.Sucursal=" & Pone_Apos(G.Sucursal)
            G.com.CommandText = G.Tsql
            Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
        Catch ex As Exception
            ' Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub

End Class
