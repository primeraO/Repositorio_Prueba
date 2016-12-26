Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Almacen
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
            Llena_Empresa()

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
        T_Lote_Entrada.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Lote_Entrada.ClientID & "');")
        T_Lote_Salida.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Lote_Salida.ClientID & "');")
        Btn_Obra.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=OBRA3&Cia=" & List_Empresa.SelectedValue & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Obra.Attributes.Add("style", "cursor:pointer;")

        Btn_BObra.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=OBRA3&Num=2&Cia=" & BList_Empresa.SelectedValue & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_BObra.Attributes.Add("style", "cursor:pointer;")
        TB_Obra.Attributes.Add("onfocus", "this.select();")
        TB_Numero.Attributes.Add("onfocus", "this.select();")
        TB_Descripcion.Attributes.Add("onfocus", "this.select();")
        T_Obra.Attributes.Add("onfocus", "this.select();")
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Descripcion.Attributes.Add("onfocus", "this.select();")
        T_Aplicacion.Attributes.Add("onfocus", "this.select();")
        T_Lote_Entrada.Attributes.Add("onfocus", "this.select();")


    End Sub
    Private Sub Llena_Empresa()
        Dim G As Glo = CType(Session("G"), Glo)
        Dim dtEmpresa As New DataTable
        Dim Tsql As String = ""
        Try
            G.cn.Open()
            Tsql = "Select Cia as Numero_Compañia,Razon_Social from Compañias "
            G.com.CommandText = Tsql
            G.dr = G.com.ExecuteReader
            dtEmpresa.Load(G.dr)
            If G.dr.IsClosed = False Then G.dr.Close()

            List_Empresa.DataSource = dtEmpresa
            BList_Empresa.DataSource = dtEmpresa
            List_Empresa.DataTextField = "Razon_Social"
            BList_Empresa.DataTextField = "Razon_Social"
            List_Empresa.DataValueField = "Numero_Compañia"
            BList_Empresa.DataValueField = "Numero_Compañia"
            List_Empresa.DataBind()
            BList_Empresa.DataBind()

            If List_Empresa.Items.Count > 0 Then G.Empresa_Numero2 = List_Empresa.SelectedValue
            If BList_Empresa.Items.Count > 0 Then G.Empresa_Numero2 = BList_Empresa.SelectedValue
        Catch ex As Exception
            Msg_Error(ex.Message)
        Finally
            G.cn.Close()
        End Try
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
        T_Lote_Entrada.Text = ""
        T_Lote_Salida.Text = ""
        T_Obra.Text = ""
        T_Obra_Desc.Text = ""
        List_Empresa.SelectedValue = 1
    End Sub
    Private Sub CrearCamposTabla()
        'Tabla Almacen'
        Session("dt").Columns.Add("Cia", Type.GetType("System.Int64")) : Session("dt").Columns("Cia").DefaultValue = 0
        Session("dt").Columns.Add("Obra", Type.GetType("System.String")) : Session("dt").Columns("Obra").DefaultValue = ""
        Session("dt").Columns.Add("Almacen", Type.GetType("System.Int64")) : Session("dt").Columns("Almacen").DefaultValue = 0
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Aplicacion", Type.GetType("System.String")) : Session("dt").Columns("Aplicacion").DefaultValue = ""
        Session("dt").Columns.Add("Cve_Seg", Type.GetType("System.String")) : Session("dt").Columns("Cve_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Seg", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Hora_Seg", Type.GetType("System.String")) : Session("dt").Columns("Hora_Seg").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Lote_Entrada", Type.GetType("System.Int64")) : Session("dt").Columns("Lote_Entrada").DefaultValue = 0
        Session("dt").Columns.Add("Lote_Salida", Type.GetType("System.Int64")) : Session("dt").Columns("Lote_Salida").DefaultValue = 0

        Dim clave(2) As DataColumn
        clave(0) = Session("dt").Columns("Cia")
        clave(1) = Session("dt").Columns("Obra")
        clave(2) = Session("dt").Columns("Almacen")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Function validar() As Boolean
        validar = False
        If T_Descripcion.Text.Trim = "" Then
            Msg_Error("Nombre inválido") : Exit Function
        End If
        If T_Obra.Text = "" Then
            Msg_Error("Obra inválida") : Exit Function

        End If
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal AlmacenNumero As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Cia") = List_Empresa.SelectedValue
        f("Obra") = T_Obra.Text
        f("Almacen") = AlmacenNumero
        f("Descripcion") = T_Descripcion.Text
        f("Aplicacion") = T_Aplicacion.Text
        f("Lote_Entrada") = Val(T_Lote_Entrada.Text)
        f("Lote_Salida") = Val(T_Lote_Salida.Text)
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal AlmacenNumero As String)
        Dim clave(2) As String
        clave(0) = List_Empresa.SelectedValue
        clave(1) = T_Obra.Text
        clave(2) = AlmacenNumero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Descripcion") = T_Descripcion.Text
            f("Aplicacion") = T_Aplicacion.Text
            f("Lote_Entrada") = Val(T_Lote_Entrada.Text)
            f("Lote_Salida") = Val(T_Lote_Salida.Text)
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid(ByVal AlmacenNumero As Integer)
        Dim clave(2) As String
        clave(0) = List_Empresa.SelectedValue
        clave(1) = T_Obra.Text
        clave(2) = AlmacenNumero
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
            Session("dt").rows.clear()
            G.cn.Open()
            G.Tsql = "Select Cia,Obra,Almacen,Descripcion,Aplicacion,Lote_Entrada,Lote_Salida from Almacen"
            G.Tsql &= " Where Cia=" & Val(BList_Empresa.SelectedValue)
            If TB_Obra.Text <> "" Then G.Tsql &= " and Obra=" & Pone_Apos(TB_Obra.Text)
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*' "
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Descripcion like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            If TB_Numero.Text <> "" Then
                G.Tsql &= " and Almacen=" & Val(TB_Numero.Text.Trim)
            End If
            G.Tsql &= " Order by Almacen"
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
            Dim Clave(2) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Clave(1) = (GridView1.Rows(ind).Cells(2).Text)
            Clave(2) = (GridView1.Rows(ind).Cells(3).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                List_Empresa.SelectedValue = f("Cia")
                T_Obra.Text = f("Obra")
                T_Numero.Text = f("Almacen")
                T_Aplicacion.Text = f("Aplicacion")
                T_Descripcion.Text = f("Descripcion")
                T_Lote_Entrada.Text = f("Lote_Entrada")
                T_Lote_Salida.Text = f("Lote_Salida")
                GridView1.Enabled = False

            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Descripcion.Enabled = False
                T_Aplicacion.Enabled = False
                T_Lote_Salida.Enabled = False
                T_Lote_Entrada.Enabled = False
                Pnl_Registro.Enabled = False
                List_Empresa.Enabled = False
                Btn_Obra.Attributes.Add("onclick", "")
                Btn_Obra.Attributes.Add("style", "cursor:not-allowed")
                T_Obra.Enabled = False
                T_Numero.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                Btn_Obra.Attributes.Add("onclick", "")
                Btn_Obra.Attributes.Add("style", "cursor:not-allowed")

                List_Empresa.Enabled = False
                T_Obra.Enabled = False
                T_Numero.Enabled = False
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
                Btn_Obra.Attributes.Add("onclick", "")
                Btn_Obra.Attributes.Add("style", "cursor:not-allowed")

                List_Empresa.Enabled = False
                T_Obra.Enabled = False
                T_Numero.Enabled = False
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
        T_Lote_Entrada.Enabled = False
        T_Lote_Salida.Enabled = False
        TB_Numero.Enabled = True
        TB_Descripcion.Enabled = True
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
        Ch_Baja.Enabled = True
        GridView1.Enabled = True
    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False
        T_Obra.Enabled = True
        List_Empresa.Enabled = True

        T_Numero.Enabled = True
        T_Descripcion.Enabled = True
        T_Aplicacion.Enabled = True
        T_Lote_Entrada.Enabled = True
        T_Lote_Salida.Enabled = True
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
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Almacen").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Almacen")
            T_Descripcion.Text = f.Item("Descripcion")
            T_Aplicacion.Text = f.Item("Aplicacion")
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
        Habilita()
        LLenaGrid()
        'T_Numero.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        'T_Numero.Text = Siguiente()
        T_Obra.Focus()
        Pnl_Registro.Enabled = True
        GridView1.Enabled = False
        T_Numero.Enabled = True
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
                'T_Numero.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select Descripcion from Almacen where Descripcion=" & Pone_Apos(T_Descripcion.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe una Almacen con esa Descripción") : Exit Sub
                End If
                G.Tsql = "Insert into Almacen (Cia,Obra,Almacen,Descripcion,Aplicacion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja,Lote_Entrada,Lote_Salida) values ("
                G.Tsql &= Val(List_Empresa.SelectedValue)
                G.Tsql &= "," & Pone_Apos(T_Obra.Text)
                G.Tsql &= "," & Val(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(Session("Contraseña"))
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= "," & "''"
                G.Tsql &= "," & Val(T_Lote_Entrada.Text.Trim)
                G.Tsql &= "," & Val(T_Lote_Salida.Text.Trim) & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Almacen set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Aplicacion=" & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= ",Lote_Entrada=" & Val(T_Lote_Entrada.Text.Trim)
                G.Tsql &= ",Lote_Salida=" & Val(T_Lote_Salida.Text.Trim)
                G.Tsql &= " Where Cia=" & Val(List_Empresa.SelectedValue)
                G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text)
                G.Tsql &= " and Almacen=" & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                CambiaFilaGrid(T_Numero.Text.Trim)

            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Almacen set Descripcion=" & Pone_Apos(T_Descripcion.Text.Trim)
                G.Tsql &= ",Aplicacion=" & Pone_Apos(T_Aplicacion.Text.Trim)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(DateTime.Now().ToShortDateString()))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Baja=" & "'*'"
                G.Tsql &= ",Lote_Entrada=" & Val(T_Lote_Entrada.Text.Trim)
                G.Tsql &= ",Lote_Salida=" & Val(T_Lote_Salida.Text.Trim)
                G.Tsql &= " Where Cia=" & Val(List_Empresa.SelectedValue)
                G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text)
                G.Tsql &= " and Almacen=" & Val(T_Numero.Text.Trim)
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
            LimpiaCampos()
            G.cn.Close()
        End Try
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Almacen) from Almacen"
            G.Tsql &= " Where Cia=" & Val(List_Empresa.SelectedValue)
            G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text)
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

    Protected Sub T_Obra_TextChanged(sender As Object, e As System.EventArgs) Handles T_Obra.TextChanged
        T_Numero.Text = Siguiente()
        T_Descripcion.Focus()
    End Sub

    Protected Sub BList_Empresa_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles BList_Empresa.SelectedIndexChanged
        TB_Obra.Text = ""
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
End Class
