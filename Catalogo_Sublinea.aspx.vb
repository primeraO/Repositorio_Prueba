Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Sublinea
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        H_Linea.Attributes.Add("onclick", "")
        H_Linea.Attributes.Add("style", "cursor:not-allowed;")
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
        H_Linea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Linea.Attributes.Add("style", "cursor:pointer;")
        HB_Linea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        HB_Linea.Attributes.Add("style", "cursor:pointer;")
        T_Lin_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Lin_Numero.ClientID & "');")
        TB_Sub_Grupo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Sub_Grupo.ClientID & "');")
        TB_Grupo.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Grupo.ClientID & "');")
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
        T_Lin_Numero.Text = ""
        T_Lin_Descripcion.Text = ""
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Numero.Enabled = False
        T_Descripcion.Enabled = False
        Movimiento.Value = ""
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        'Ima_Regresa.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        'Ima_Regresa.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        GridView1.Enabled = True
        T_Lin_Numero.Enabled = True
        T_Lin_Descripcion.Enabled = True
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False

        T_Numero.Enabled = True
        T_Descripcion.Enabled = True
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
    Private Sub CrearCamposTabla()
        'Tabla Sub-Linea'
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Numero_Linea", Type.GetType("System.Int64")) : Session("dt").Columns("Numero_Linea").DefaultValue = 0
        Session("dt").Columns.Add("Lin_Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Lin_Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Numero_Sub_Linea", Type.GetType("System.Int64")) : Session("dt").Columns("Numero_Sub_Linea").DefaultValue = 0
        Session("dt").Columns.Add("Fecha_Cambio", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Cambio").DefaultValue = ""
        Session("dt").Columns.Add("Clas_Corta", Type.GetType("System.String")) : Session("dt").Columns("Clas_Corta").DefaultValue = ""
        Dim clave(1) As DataColumn
        clave(0) = Session("dt").Columns("Numero_Linea")
        clave(1) = Session("dt").Columns("Numero_Sub_Linea")

        Session("dt").PrimaryKey = clave
    End Sub
    Private Function validar() As Boolean
        validar = False
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Nombre inválido") : Exit Function
        End If
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal Sublinea_Numero As String, ByVal Descripcion As String, ByVal Nombre_Linea As String, ByVal Numero_Linea As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Descripcion") = Descripcion
        f("Lin_Descripcion") = Nombre_Linea
        f("Numero_Sub_Linea") = Sublinea_Numero
        f("Numero_Linea") = Numero_Linea
        f("Clas_Corta") = T_Clasificacion_Corta.Text.Trim
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Sublinea_Numero As String, ByVal Descripcion As String, ByVal Numero_Linea As String)
        Dim clave(1) As String
        clave(0) = Numero_Linea
        clave(1) = Sublinea_Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Descripcion") = Descripcion
            f("Clas_Corta") = T_Clasificacion_Corta.Text.Trim

        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal Numero_Sub_Linea As Integer, ByVal Numero_Linea As Integer)
        Dim clave(1) As String
        clave(0) = Numero_Linea
        clave(1) = Numero_Sub_Linea
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
            Session("dt").Rows.Clear()
            G.cn.Open()
            G.Tsql = "Select Sub_Linea.Numero as Numero_Sub_Linea,Sub_Linea.Clas_Corta, Sub_Linea.Descripcion,Sub_Linea.Lin_Numero as Numero_Linea, Linea.Descripcion as Lin_Descripcion from Sub_Linea"
            G.Tsql &= " left join Linea on Linea.Linea=Sub_Linea.Lin_Numero"
            If Ch_Baja.Checked = True Then
                G.Tsql &= " where Sub_Linea.Baja='*' "
            Else
                G.Tsql &= " where Sub_Linea.Baja<>'*' "
            End If
            If Val(TB_Sub_Grupo.Text) > 0 Then
                G.Tsql &= " and Sub_Linea.Numero=" & Val(TB_Sub_Grupo.Text)
            End If
            If TB_Sub_Grupo_Descripcion.Text <> "" Then
                G.Tsql &= " and Sub_Linea.Descripcion like'%" & TB_Sub_Grupo_Descripcion.Text.Trim & "%'"

            End If
            If Val(TB_Grupo.Text) > 0 Then
                G.Tsql &= " and Linea.Linea=" & Val(TB_Grupo.Text)
            End If
            If TB_Grupo_Descripcion.Text <> "" Then
                G.Tsql &= " and Linea.Descripcion like'%" & TB_Grupo_Descripcion.Text.Trim & "%'"

            End If

            G.Tsql &= " Order by Sub_Linea.Lin_Numero"
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
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(1) As String
            Clave(0) = GridView1.Rows(ind).Cells(1).Text
            Clave(1) = GridView1.Rows(ind).Cells(3).Text
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f.Item("Numero_sub_Linea").ToString
                T_Descripcion.Text = f.Item("Descripcion").ToString
                T_Lin_Descripcion.Text = f.Item("Lin_Descripcion").ToString
                T_Lin_Numero.Text = f.Item("Numero_Linea").ToString
                T_Clasificacion_Corta.Text = f.Item("Clas_Corta").ToString
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Descripcion.Enabled = False
                T_Lin_Descripcion.Enabled = False
                T_Lin_Numero.Enabled = False
                Pnl_Registro.Enabled = False
                H_Linea.Attributes.Add("onclick", "")
                H_Linea.Attributes.Add("style", "cursor:not-allowed;")
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                H_Linea.Attributes.Add("onclick", "")
                H_Linea.Attributes.Add("style", "cursor:not-allowed;")
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Lin_Descripcion.Enabled = False
                T_Lin_Numero.Enabled = False
                T_Numero.Enabled = False
                T_Descripcion.Focus()
                Habilita()
                H_Linea.Attributes.Add("onclick", "")
                H_Linea.Attributes.Add("style", "cursor:not-allowed;")

                'H_Linea.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=LINEA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
                'H_Linea.Attributes.Add("style", "cursor:pointer;")
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
    
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(1) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Numero_Sub_Linea").ToString
        clave(1) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Numero_Linea").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Numero_Sub_Linea")
            T_Descripcion.Text = f.Item("Descripcion")
            T_Lin_Descripcion.Text = f.Item("Lin_Descripcion")
            T_Lin_Numero.Text = f("Numero_Linea")
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
        'If Val(T_Lin_Numero.Text) = 0 Then
        '    Msg_Error("Selecciona una linea") : Exit Sub
        'End If
        Movimiento.Value = "Alta"
        'T_Numero.Text = Siguiente()
        Habilita()
        T_Lin_Numero.Enabled = False
        T_Lin_Descripcion.Enabled = False
        Pnl_Registro.Enabled = True

    End Sub
    Protected Sub Ima_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Restaura.Click
        DesHabilita()
        H_Linea.Attributes.Add("onclick", "")
        H_Linea.Attributes.Add("style", "cursor:not-allowed;")
        LimpiaCampos()
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            G.cn.Open()
            If Movimiento.Value = "Alta" Then
                Tsql = "Select Descripcion from Sub_Linea where Descripcion=" & Pone_Apos(T_Descripcion.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe una Sub_Linea con esa Descripción") : Exit Sub
                End If
                G.Tsql = "Insert into Sub_Linea (Baja,Descripcion,Lin_Numero,Numero,Fecha_Cambio,Clas_Corta) values ("
                G.Tsql &= "''"
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Val(T_Lin_Numero.Text)
                G.Tsql &= "," & Val(T_Numero.Text)
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= "," & Pone_Apos(T_Clasificacion_Corta.Text.Trim)
                G.Tsql &= ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Lin_Descripcion.Text.Trim, T_Lin_Numero.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Sub_Linea set Baja=''"
                G.Tsql &= ",Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= ",Clas_Corta=" & Pone_Apos(T_Clasificacion_Corta.Text.Trim)
                G.Tsql &= " Where Numero=" & Val(T_Numero.Text.Trim)
                G.Tsql &= " and Lin_Numero=" & Val(T_Lin_Numero.Text)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Lin_Numero.Text.Trim)
                If Ch_Baja.Checked Then
                    EliminaFilaGrid(T_Numero.Text.Trim, T_Lin_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Sub_Linea set Baja='*'"
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= " Where Numero=" & Val(T_Numero.Text.Trim)
                G.Tsql &= " and Lin_Numero=" & Val(T_Lin_Numero.Text)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid(T_Numero.Text.Trim, T_Lin_Numero.Text.Trim)
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
            G.Tsql = "Select Max(Numero) from Sub_Linea "
            G.Tsql &= " where Lin_Numero=" & Val(T_Lin_Numero.Text)
            G.com.CommandText = G.Tsql
            Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
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

    Protected Sub T_Lin_Numero_TextChanged(sender As Object, e As System.EventArgs) Handles T_Lin_Numero.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        G.cn.Open()
        G.Tsql = "Select Descripcion from Linea"
        G.Tsql &= " where Linea=" & Pone_Apos(T_Lin_Numero.Text.Trim)
        G.Tsql &= " and Cia=" & Val(Session("Cia"))
        G.com.CommandText = G.Tsql
        Dim Desc_Lin As String = G.com.ExecuteScalar
        T_Lin_Descripcion.Text = Desc_Lin
        G.cn.Close()

        T_Numero.Text = Siguiente()
    End Sub
End Class
