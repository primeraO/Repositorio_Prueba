Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Actividad_Area
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
            LLenaGrid()
            Try
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
            Catch ex As Exception

            End Try
        End If
        Msg_Err.Visible = False
        DibujaSpan()
        H_Frente.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=AREA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Frente.Attributes.Add("style", "cursor:pointer;")
        T_Area.Attributes.Add("style", "text-align:right")
        T_Numero.Attributes.Add("style", "text-align:right")
        T_Area.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Area.ClientID & "');")
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        T_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Numero.ClientID & "');")

        TB_Numero.Attributes.Add("onfocus", "this.select();")
        TB_Descripcion.Attributes.Add("onfocus", "this.select();")
        T_Area.Attributes.Add("onfocus", "this.select();")
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Descripcion.Attributes.Add("onfocus", "this.select();")

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
        Dim G As Glo = CType(Session("G"), Glo)
        Session("dt").Columns.Add("Area", Type.GetType("System.Int64")) : Session("dt").Columns("Area").DefaultValue = 0
        Session("dt").Columns.Add("Actividad", Type.GetType("System.String")) : Session("dt").Columns("Actividad").DefaultValue = 0
        Session("dt").Columns.Add("Descripcion_Actividad", Type.GetType("System.String")) : Session("dt").Columns("Descripcion_Actividad").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion_Area", Type.GetType("System.String")) : Session("dt").Columns("Descripcion_Area").DefaultValue = ""
        Session("dt").Columns.Add("Cve_Seg", Type.GetType("System.String")) : Session("dt").Columns("Cve_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Seg", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Hora_Seg", Type.GetType("System.String")) : Session("dt").Columns("Hora_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Dim clave(1) As DataColumn
        clave(0) = Session("dt").Columns("Area")
        clave(1) = Session("dt").Columns("Actividad")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Numero.Enabled = False
        T_Descripcion.Enabled = False
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        Ch_Baja.Enabled = True
        GridView1.Enabled = True
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible=False

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
        Ch_Baja.Enabled = False
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
            G.Tsql = "Select a.Area,a.Actividad,a.Descripcion as Descripcion_Actividad, b.Descripcion as Descripcion_Area from Actividad_Area a"
            G.Tsql &= " left join Area b on a.Cia=b.Cia and a.Obra=b.Obra and a.Area=b.Area"
            G.Tsql &= " Where a.Cia=" & Val(Session("Cia"))
            G.Tsql &= " and a.Obra=" & Pone_Apos(Session("Obra"))
            If Val(TB_Numero.Text) > 0 Then
                G.Tsql &= " and a.Actividad=" & Val(TB_Numero.Text)
            End If
            If TB_Descripcion.Text <> "" Then
                G.Tsql &= " and a.Descripcion like'%" & TB_Descripcion.Text & "%'"
            End If
            If Val(T_Area.Text) > 0 Then
                G.Tsql &= " and a.Area=" & Val(T_Area.Text)
            End If
            If T_Area_Desc.Text <> "" Then
                G.Tsql &= " and b.Descripcion like'%" & T_Area_Desc.Text & "%'"
            End If
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and a.Baja='*'"
            Else
                G.Tsql &= " and a.Baja<>'*' "
            End If
            G.Tsql &= " Order by A.Area"
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
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Actividad) from Actividad_Area"
            G.Tsql &= " Where Cia=" & Session("Cia")
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.Tsql &= " and Area=" & Val(T_Area.Text)
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
        If Val(T_Area.Text.Trim) = 0 Then
            Msg_Error("Numero de Area Invalida") : Exit Function
        End If
        Return True
    End Function

    Protected Sub Ima_Alta_Click(sender As Object, e As System.EventArgs) Handles Ima_Alta.Click
        'If Val(T_Area.Text) = 0 Then Msg_Error("Seleccione un Area") : Exit Sub
        Habilita()
        'T_Area.Enabled = False
        'H_Frente.Attributes.Add("style", "cursor:not-allowed;")
        'H_Frente.Attributes.Add("onclick", "")
        'T_Area_Desc.Enabled = False
        'T_Numero.Enabled = False
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Area.Focus()
        Pnl_Registro.Enabled = True
    End Sub
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal Area As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Actividad") = Numero
        f("Area") = Area
        f("Descripcion_Actividad") = Descripcion
        f("Descripcion_Area") = T_Area_Desc.Text.Trim
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid()
        Dim clave(1) As String
        clave(0) = Val(T_Area.Text)
        clave(1) = Val(T_Numero.Text)
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Area") = Val(T_Area.Text)
            f("Descripcion_Area") = T_Area_Desc.Text
            f("Actividad") = Val(T_Numero.Text)
            f("Descripcion_Actividad") = T_Descripcion.Text
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal Numero As Integer)
        Dim clave(1) As String
        clave(0) = Val(T_Area.Text)
        clave(1) = Val(T_Numero.Text)
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Protected Sub Ima_Guarda_Click(sender As Object, e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub

            If Movimiento.Value = "Alta" Then
                'T_Numero.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select Actividad from Actividad_Area where Actividad=" & Pone_Apos(T_Numero.Text)
                Tsql &= " and Area=" & Val(T_Area.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe La actividad: " & T_Numero.Text) : Exit Sub
                End If
                'Tsql = "Select Descripcion from Actividad_Area where Descripcion=" & Pone_Apos(T_Descripcion.Text)
                'G.com.CommandText = Tsql
                'If Not G.com.ExecuteScalar Is Nothing Then
                '    Msg_Error("Ya existe el Nombre de la Actividad") : Exit Sub
                'End If
                G.Tsql = "Insert into Actividad_Area (Cia,Obra,Actividad,Area,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values ("
                G.Tsql &= Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(Session("Obra"))
                G.Tsql &= "," & T_Numero.Text.Trim
                G.Tsql &= "," & T_Area.Text.Trim
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(Session("Contraseña"))
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Descripcion.Text.Trim, T_Area.Text.Trim)
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Actividad_Area set Cia=" & Val(Session("Cia"))
                G.Tsql &= ",Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql &= ",Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Area=" & Val(T_Area.Text.Trim)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql &= " and Area=" & Val(T_Area.Text)
                G.Tsql &= " and Actividad=" & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                CambiaFilaGrid()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Actividad_Area set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Baja=" & "'*'"
                G.Tsql &= " Where Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Area=" & Val(T_Area.Text.Trim)
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql &= " and Actividad = " & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid(T_Numero.Text.Trim)
                LimpiaCampos()
            End If
            DesHabilita()
            T_Area.Enabled = True
            T_Area_Desc.Enabled = True
            GridView1.Visible = True
            Pnl_Grids.Visible = True
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            LimpiaCampos()
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
            Dim Clave(1) As String
            Clave(0) = GridView1.Rows(ind).Cells(1).Text
            Clave(1) = GridView1.Rows(ind).Cells(3).Text
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f.Item("Actividad").ToString
                T_Area.Text = f.Item("Area").ToString
                T_Descripcion.Text = f.Item("Descripcion_Actividad").ToString
                T_Area_Desc.Text = f.Item("Descripcion_Area").ToString
                H_Frente.Attributes.Add("onclick", "")
                H_Frente.Attributes.Add("style", "cursor:not-allowed;")
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Area.Enabled = False
                T_Area_Desc.Enabled = False
                T_Numero.Enabled = False
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
                T_Descripcion.Focus()
                Habilita()
                T_Area.Enabled = False
                T_Area_Desc.Enabled = False
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

    Protected Sub Ima_Busca_Click(sender As Object, e As System.EventArgs) Handles Ima_Busca.Click
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

    Protected Sub Ima_Restaura_Click(sender As Object, e As System.EventArgs) Handles Ima_Restaura.Click
        LimpiaCampos()
        DesHabilita()
        T_Area.Enabled = True
        T_Area_Desc.Enabled = True
        T_Area.Text = ""
        T_Area_Desc.Text = ""
        GridView1.Visible = True
        Pnl_Grids.Visible = True

    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub

    Protected Sub T_Area_TextChanged(sender As Object, e As System.EventArgs) Handles T_Area.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        G.cn.Open()
        G.Tsql = "Select Descripcion from Area"
        G.Tsql &= " where Area=" & Pone_Apos(T_Area.Text.Trim)
        G.Tsql &= " and Cia=" & Val(Session("Cia"))
        G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
        G.com.CommandText = G.Tsql
        Dim Desc_Area As String = G.com.ExecuteScalar
        T_Area_Desc.Text = Desc_Area
        G.cn.Close()
        T_Numero.Text = Siguiente()
        T_Descripcion.Focus()
    End Sub
End Class
