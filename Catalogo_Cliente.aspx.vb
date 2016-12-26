Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Cliente
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
        Msg_Err.Visible = False
        LLenaGrid()
        DibujaSpan()
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        T_RFC.Attributes.Add("onfocus", "this.select();")
        T_Razon_Social.Attributes.Add("onfocus", "this.select();")
        T_Direccion.Attributes.Add("onfocus", "this.select();")
        T_Num_Int.Attributes.Add("onfocus", "this.select();")
        T_Num_Ext.Attributes.Add("onfocus", "this.select();")
        T_Colonia.Attributes.Add("onfocus", "this.select();")
        'T_Delegacion.Attributes.Add("onfocus", "this.select();")
        T_Ciudad.Attributes.Add("onfocus", "this.select();")
        T_Estado.Attributes.Add("onfocus", "this.select();")
        T_Pais.Attributes.Add("onfocus", "this.select();")
        T_CP.Attributes.Add("onfocus", "this.select();")
        T_Telefono1.Attributes.Add("onfocus", "this.select();")
        T_Telefono2.Attributes.Add("onfocus", "this.select();")
        T_Fax.Attributes.Add("onfocus", "this.select();")
     
        T_Mail.Attributes.Add("onfocus", "this.select();")


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
        Session("dt").Columns.Add("Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Razon_Social", Type.GetType("System.String")) : Session("dt").Columns("Razon_Social").DefaultValue = ""
        Session("dt").Columns.Add("RFC", Type.GetType("System.String")) : Session("dt").Columns("RFC").DefaultValue = ""
        Session("dt").Columns.Add("Direccion", Type.GetType("System.String")) : Session("dt").Columns("Direccion").DefaultValue = ""
        Session("dt").Columns.Add("Colonia", Type.GetType("System.String")) : Session("dt").Columns("Colonia").DefaultValue = ""
        Session("dt").Columns.Add("Ciudad", Type.GetType("System.String")) : Session("dt").Columns("Ciudad").DefaultValue = ""
        Session("dt").Columns.Add("Pais", Type.GetType("System.String")) : Session("dt").Columns("Pais").DefaultValue = ""
        Session("dt").Columns.Add("CP", Type.GetType("System.Double")) : Session("dt").Columns("CP").DefaultValue = 0
        Session("dt").Columns.Add("Estado", Type.GetType("System.String")) : Session("dt").Columns("Estado").DefaultValue = ""
        Session("dt").Columns.Add("Telefono_1", Type.GetType("System.String")) : Session("dt").Columns("Telefono_1").DefaultValue = ""
        Session("dt").Columns.Add("Telefono_2", Type.GetType("System.String")) : Session("dt").Columns("Telefono_2").DefaultValue = ""
        Session("dt").Columns.Add("Fax", Type.GetType("System.String")) : Session("dt").Columns("Fax").DefaultValue = ""
        Session("dt").Columns.Add("Mail", Type.GetType("System.String")) : Session("dt").Columns("Mail").DefaultValue = ""
        Session("dt").Columns.Add("Numero_Interior", Type.GetType("System.String")) : Session("dt").Columns("Numero_Interior").DefaultValue = ""
        Session("dt").Columns.Add("Numero_Exterior", Type.GetType("System.String")) : Session("dt").Columns("Numero_Exterior").DefaultValue = ""

        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        T_RFC.Enabled = False
        T_Razon_Social.Enabled = False
        T_Direccion.Enabled = False
        T_Num_Int.Enabled = False
        T_Num_Ext.Enabled = False
        T_Colonia.Enabled = False
        'T_Delegacion.Enabled = False
        T_Ciudad.Enabled = False
        T_Estado.Enabled = False
        T_Pais.Enabled = False
        T_CP.Enabled = False
        T_Telefono1.Enabled = False
        T_Telefono2.Enabled = False
        T_Fax.Enabled = False
       
        T_Mail.Enabled = False
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

    End Sub
    Private Sub Habilita()
        Pnl_Busqueda.Visible = False
        Pnl_Registro.Visible = True
        GridView1.Visible = False
        Pnl_Grids.Visible = False
        T_RFC.Enabled = True
        T_Razon_Social.Enabled = True
        T_Direccion.Enabled = True
        T_Num_Int.Enabled = True
        T_Num_Ext.Enabled = True
        T_Colonia.Enabled = True
        ' T_Delegacion.Enabled = True
        T_Ciudad.Enabled = True
        T_Estado.Enabled = True
        T_Pais.Enabled = True
        T_CP.Enabled = True
        T_Telefono1.Enabled = True
        T_Telefono2.Enabled = True
        T_Fax.Enabled = True
      
        T_Mail.Enabled = True
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
            G.Tsql = "Select top(200) Numero, Razon_Social,RFC,Direccion,Colonia,Ciudad,Estado,Numero_Interior,Numero_Exterior,Pais,CP,Telefono_1,Telefono_2,Fax,Mail from Cliente "
            G.Tsql &= " Where Numero<>0 "
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*'"
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If Val(TB_Numero.Text.Trim) <> 0 Then
                G.Tsql &= " and Numero =" & Val(TB_Numero.Text.Trim)
            End If
            If TB_RFC.Text.Trim <> "" Then
                G.Tsql &= " and RFC like '%" & TB_RFC.Text.Trim & "%'"
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Razon_Social like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            G.Tsql &= " Order by Numero"
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
        T_RFC.Text = ""
        T_Razon_Social.Text = ""
        T_Direccion.Text = ""
        T_Num_Int.Text = ""
        T_Num_Ext.Text = ""
        T_Colonia.Text = ""
        ' T_Delegacion.Enabled = True
        T_Ciudad.Text = ""
        T_Estado.Text = ""
        T_Pais.Text = ""
        T_CP.Text = ""
        T_Telefono1.Text = ""
        T_Telefono2.Text = ""
        T_Fax.Text = ""
        T_Mail.Text = ""
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Numero) from Cliente"
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
        If T_RFC.Text.Length < 12 Or T_RFC.Text.Length > 13 Then
            Msg_Error("RFC invalido") : Exit Function
        End If
        If T_Razon_Social.Text.Trim = "" Then
            Msg_Error("Nombre inválido") : Exit Function
        End If
        Return True
    End Function
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = T_Numero.Text
        f("RFC") = T_RFC.Text
        f("Razon_Social") = T_Razon_Social.Text
        f("Direccion") = T_Direccion.Text
        f("Numero_Interior") = T_Num_Int.Text
        f("Numero_Exterior") = T_Num_Ext.Text
        f("Colonia") = T_Colonia.Text
        f("Ciudad") = T_Ciudad.Text
        f("Estado") = T_Estado.Text
        f("Pais") = T_Pais.Text
        f("CP") = T_CP.Text
        f("Telefono_1") = T_Telefono1.Text
        f("Telefono_2") = T_Telefono2.Text
        f("Fax") = T_Fax.Text
        f("Mail") = T_Mail.Text
       
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Descripcion As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("RFC") = T_RFC.Text
            f("Razon_Social") = Descripcion
            f("Direccion") = T_Direccion.Text
            f("Numero_Interior") = T_Num_Int.Text
            f("Numero_Exterior") = T_Num_Ext.Text
            f("Colonia") = T_Colonia.Text
            f("Ciudad") = T_Ciudad.Text
            f("Estado") = T_Estado.Text
            f("Pais") = T_Pais.Text
            f("CP") = T_CP.Text
            f("Telefono_1") = T_Telefono1.Text
            f("Telefono_2") = T_Telefono2.Text
            f("Fax") = T_Fax.Text
            f("Mail") = T_Mail.Text

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
        T_RFC.Focus()
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
                T_Numero.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select Razon_Social from Cliente where Razon_Social=" & Pone_Apos(T_Razon_Social.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el Nombre del Comprador") : Exit Sub
                End If
                G.Tsql = "Insert into Cliente (Numero,Razon_Social,RFC,Direccion,Colonia,Ciudad,Estado,CP,Telefono_1,Telefono_2,Fax,Mail,Pais,Numero_Interior,Numero_Exterior,Baja) values ("
                G.Tsql &= Val(T_Numero.Text)
                G.Tsql &= "," & Pone_Apos(T_Razon_Social.Text)
                G.Tsql &= "," & Pone_Apos(T_RFC.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Colonia.Text)
                G.Tsql &= "," & Pone_Apos(T_Ciudad.Text)
                G.Tsql &= "," & Pone_Apos(T_Estado.Text)
                G.Tsql &= "," & Val(T_CP.Text)
                G.Tsql &= "," & Pone_Apos(T_Telefono1.Text)
                G.Tsql &= "," & Pone_Apos(T_Telefono2.Text)
                G.Tsql &= "," & Pone_Apos(T_Fax.Text)
                G.Tsql &= "," & Pone_Apos(T_Mail.Text)
                G.Tsql &= "," & Pone_Apos(T_Pais.Text)
                G.Tsql &= "," & Pone_Apos(T_Num_Int.Text)
                G.Tsql &= "," & Pone_Apos(T_Num_Ext.Text)
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_Razon_Social.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Cliente set Razon_Social=" & Pone_Apos(T_Razon_Social.Text)
                G.Tsql &= ",RFC=" & Pone_Apos(T_RFC.Text)
                G.Tsql &= ",Direccion=" & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= ",Colonia=" & Pone_Apos(T_Colonia.Text)
                G.Tsql &= ",Ciudad=" & Pone_Apos(T_Ciudad.Text)
                G.Tsql &= ",Estado=" & Pone_Apos(T_Estado.Text)
                G.Tsql &= ",CP=" & Val(T_CP.Text)
                G.Tsql &= ",Telefono_1=" & Pone_Apos(T_Telefono1.Text)
                G.Tsql &= ",Telefono_2=" & Pone_Apos(T_Telefono2.Text)
                G.Tsql &= ",Fax=" & Pone_Apos(T_Fax.Text)
                G.Tsql &= ",Mail=" & Pone_Apos(T_Mail.Text)
                G.Tsql &= ",Pais=" & Pone_Apos(T_Pais.Text)
                G.Tsql &= ",Numero_Interior=" & Pone_Apos(T_Num_Int.Text)
                G.Tsql &= ",Numero_Exterior=" & Pone_Apos(T_Num_Ext.Text)
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Numero=" & Val(T_Numero.Text)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_Razon_Social.Text.Trim)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If
                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Cliente set Baja='*'"
                G.Tsql &= " Where Numero=" & Val(T_Numero.Text)
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
                T_Numero.Text = f.Item("Numero")
                T_RFC.Text = f.Item("RFC")
                T_Razon_Social.Text = f.Item("Razon_Social")
                T_Direccion.Text = f.Item("Direccion")
                T_Num_Int.Text = f.Item("Numero_Interior")
                T_Num_Ext.Text = f.Item("Numero_Exterior")
                T_Colonia.Text = f.Item("Colonia")
                T_Ciudad.Text = f.Item("Ciudad")
                T_Estado.Text = f.Item("Estado")
                T_Pais.Text = f.Item("Pais")
                T_CP.Text = f.Item("CP")
                T_Telefono1.Text = f.Item("Telefono_1")
                T_Telefono2.Text = f.Item("Telefono_2")
                T_Fax.Text = f.Item("Fax")
                T_Mail.Text = f.Item("Mail")
                GridView1.Enabled = False
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Razon_Social.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"

            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Razon_Social.Focus()
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


    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub
End Class
