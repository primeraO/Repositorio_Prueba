Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Partial Class Catalogo_Proveedores
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
            H_Pais.Attributes.Add("style", "cursor:not-allowed;")
            H_Comprador.Attributes.Add("style", "cursor:not-allowed;")
            H_CondPago.Attributes.Add("style", "cursor:not-allowed;")
            H_Transporte.Attributes.Add("style", "cursor:not-allowed;")
        End If
        Msg_Err.Visible = False
        LLenaGrid()
        DibujaSpan()
        TB_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & TB_Numero.ClientID & "');")
        T_Pais.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Pais.ClientID & "');")
        T_Comprador.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Comprador.ClientID & "');")
        T_CondPago.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_CondPago.ClientID & "');")
        T_Transporte.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Transporte.ClientID & "');")
        T_CP.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_CP.ClientID & "');")
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
        'Tabla Area'
        Session("dt").Columns.Add("Colonia", Type.GetType("System.String")) : Session("dt").Columns("Colonia").DefaultValue = ""
        Session("dt").Columns.Add("Baja", Type.GetType("System.String")) : Session("dt").Columns("Baja").DefaultValue = ""
        Session("dt").Columns.Add("Comprador", Type.GetType("System.Int64")) : Session("dt").Columns("Comprador").DefaultValue = 0
        Session("dt").Columns.Add("Cond_Pago", Type.GetType("System.Int64")) : Session("dt").Columns("Cond_Pago").DefaultValue = 0
        Session("dt").Columns.Add("CP", Type.GetType("System.Int64")) : Session("dt").Columns("CP").DefaultValue = 0
        Session("dt").Columns.Add("Direccion", Type.GetType("System.String")) : Session("dt").Columns("Direccion").DefaultValue = ""
        Session("dt").Columns.Add("Estado", Type.GetType("System.String")) : Session("dt").Columns("Estado").DefaultValue = ""
        Session("dt").Columns.Add("Fax", Type.GetType("System.String")) : Session("dt").Columns("Fax").DefaultValue = ""
        Session("dt").Columns.Add("Mail", Type.GetType("System.String")) : Session("dt").Columns("Mail").DefaultValue = ""
        Session("dt").Columns.Add("Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Pais", Type.GetType("System.Int64")) : Session("dt").Columns("Pais").DefaultValue = 0
        Session("dt").Columns.Add("Razon_Social", Type.GetType("System.String")) : Session("dt").Columns("Razon_Social").DefaultValue = ""
        Session("dt").Columns.Add("Rfc", Type.GetType("System.String")) : Session("dt").Columns("Rfc").DefaultValue = ""
        Session("dt").Columns.Add("Telefono_1", Type.GetType("System.String")) : Session("dt").Columns("Telefono_1").DefaultValue = ""
        Session("dt").Columns.Add("Telefono_2", Type.GetType("System.String")) : Session("dt").Columns("Telefono_2").DefaultValue = ""
        Session("dt").Columns.Add("Transporte", Type.GetType("System.Int64")) : Session("dt").Columns("Transporte").DefaultValue = 0
        Session("dt").Columns.Add("Fecha_Cambio", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Cambio").DefaultValue = ""
        Session("dt").Columns.Add("Es_Corporativo", Type.GetType("System.String")) : Session("dt").Columns("Es_Corporativo").DefaultValue = ""
        Session("dt").Columns.Add("Contacto_Nombre", Type.GetType("System.String")) : Session("dt").Columns("Contacto_Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Contacto_Mail", Type.GetType("System.String")) : Session("dt").Columns("Contacto_Mail").DefaultValue = ""
        Session("dt").Columns.Add("Contacto_Telefono", Type.GetType("System.String")) : Session("dt").Columns("Contacto_Telefono").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True

        T_Numero.Enabled = False
        T_Direccion.Enabled = False
        T_Colonia.Enabled = False
        T_Comprador.Enabled = False
        T_CondPago.Enabled = False
        T_CP.Enabled = False
        T_Estado.Enabled = False
        T_Fax.Enabled = False
        T_Mail.Enabled = False
        T_RFC.Enabled = False
        T_Tel1.Enabled = False
        T_Tel2.Enabled = False
        T_Transporte.Enabled = False
        T_Pais.Enabled = False
        T_RazonSocial.Enabled = False
        Ima_Restaura.Enabled = False
        Ima_Guarda.Enabled = False
        Ima_Alta.Enabled = True
        Ima_Busca.Enabled = True
        Ima_Restaura.CssClass = "Btn_Rojo"
        Ima_Guarda.CssClass = "Btn_Rojo"
        Ima_Alta.CssClass = "Btn_Azul"
        Ima_Busca.CssClass = "Btn_Azul"
        H_Pais.Attributes.Add("style", "cursor:not-allowed;")
        H_Comprador.Attributes.Add("style", "cursor:not-allowed;")
        H_CondPago.Attributes.Add("style", "cursor:not-allowed;")
        H_Transporte.Attributes.Add("style", "cursor:not-allowed;")
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
        T_Numero.Enabled = True
        T_Direccion.Enabled = True
        T_Colonia.Enabled = True
        T_Comprador.Enabled = True
        T_CondPago.Enabled = True
        T_CP.Enabled = True
        T_Estado.Enabled = True
        T_Fax.Enabled = True
        T_Mail.Enabled = True
        T_RFC.Enabled = True
        T_Tel1.Enabled = True
        T_Tel2.Enabled = True
        T_Transporte.Enabled = True
        T_Pais.Enabled = True
        T_RazonSocial.Enabled = True
        Ima_Restaura.Enabled = True
        Ima_Guarda.Enabled = True
        Ima_Alta.Enabled = False
        Ima_Busca.Enabled = False
        Ima_Restaura.CssClass = "Btn_Azul"
        Ima_Guarda.CssClass = "Btn_Azul"
        Ima_Alta.CssClass = "Btn_Rojo"
        Ima_Busca.CssClass = "Btn_Rojo"
        H_Pais.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=PAIS',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Pais.Attributes.Add("style", "cursor:pointer;")
        H_Comprador.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=COMPRADOR',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Comprador.Attributes.Add("style", "cursor:pointer;")
        H_CondPago.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=COND_PAGO',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_CondPago.Attributes.Add("style", "cursor:pointer;")
        H_Transporte.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=TRANSPORTE',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Transporte.Attributes.Add("style", "cursor:pointer;")
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
            G.Tsql = "Select Numero,Colonia,Comprador,Cond_Pago,CP,direccion,Estado,Fax,Mail,Pais,Razon_social,Rfc,Telefono_1,Telefono_2,"
            G.Tsql &= "Contacto_Nombre,Contacto_Mail,Contacto_Telefono,Transporte,Es_Corporativo from Proveedor "
            G.Tsql &= " Where Numero<>0 "
            If Ch_Baja.Checked = True Then
                G.Tsql &= " and Baja='*'"
            Else
                G.Tsql &= " and Baja<>'*' "
            End If
            If TB_RFC.Text <> "" Then
                G.Tsql &= " and Rfc like '%" & TB_RFC.Text.Trim & "%' "
            End If
            If Val(TB_Numero.Text.Trim) <> 0 Then
                G.Tsql &= " and Numero =" & Val(TB_Numero.Text.Trim)
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Razon_Social like '%" & TB_Descripcion.Text.Trim & "%'"
            End If
            ' '' '' '' '' ''If CH_Corporativo.Checked Then
            ' '' '' '' '' ''    G.Tsql &= " and Es_Corporativo='S'"
            ' '' '' '' '' ''Else
            ' '' '' '' '' ''    G.Tsql &= " and Es_Corporativo<>'S'"
            ' '' '' '' '' ''End If
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
        T_Numero.Text = ""
        T_Direccion.Text = ""
        T_Colonia.Text = ""
        T_Comprador.Text = ""
        T_CondPago.Text = ""
        T_CP.Text = ""
        T_Estado.Text = ""
        T_Fax.Text = ""
        T_Mail.Text = ""
        T_RFC.Text = ""
        T_Tel1.Text = ""
        T_Tel2.Text = ""
        T_Transporte.Text = ""
        T_Pais.Text = ""
        T_RazonSocial.Text = ""
        T_Desc_Comprador.Text = ""
        T_Desc_CondPago.Text = ""
        T_Desc_Pais.Text = ""
        T_Desc_Transporte.Text = ""
    End Sub
    Private Function Siguiente() As Integer
        Dim G As Glo = CType(Session("G"), Glo)
        Siguiente = 0
        Try
            G.cn.Open()
            G.Tsql = "Select Max(Numero) from Proveedor"
            G.com.CommandText = G.Tsql
            Siguiente = Val(G.com.ExecuteScalar.ToString) + 1
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function
    Private Function validar() As Boolean
        Dim G As Glo = CType(Session("G"), Glo)
        validar = False
        If Movimiento.Value = "Alta" Then
            G.cn.Open()
            G.Tsql = "Select Rfc from Proveedor where Rfc=" & Pone_Apos(T_RFC.Text.Trim)
            G.com.CommandText = G.Tsql
            If G.com.ExecuteReader.HasRows Then
                Msg_Error("Ya ha sido registrado el RFC") : G.cn.Close() : Return False
            End If
            If (T_RFC.Text Like "[A-Z][A-Z][A-Z]######*") = False Then
                Msg_Error("RFC Inválido") : Return False
            End If
        End If
        If T_RFC.Text = "" Or T_RFC.Text.Trim.Length < 12 Then
            Msg_Error("RFC Inválido") : Return False
        End If
        If Val(T_Numero.Text.Trim) = 0 Then
            Msg_Error("Numero Inválido") : Return False
        End If
        If T_RazonSocial.Text.Trim = "" Then
            Msg_Error("Razón Social Inválida") : Return False
        End If
        If T_Colonia.Text.Trim = "" Then
            Msg_Error("Colonia Inválido") : Return False
        End If
        'If Val(T_Comprador.Text.Trim) = 0 Then
        '    Msg_Error("Comprador Inválido") : Exit Function
        'End If
        If Val(T_CondPago.Text.Trim) = 0 Then
            Msg_Error("Condicion de Pago Inválida") : Return False
        End If
        If T_Direccion.Text.Trim = "" Then
            Msg_Error("Direccion Inválida") : Return False
        End If
        If T_Estado.Text.Trim = "" Then
            Msg_Error("Estado Inválido") : Return False
        End If
        If Val(T_Pais.Text.Trim) = 0 Then
            Msg_Error("Pais Inválido") : Return False
        End If

        'If T_Tel1.Text.Trim = "" Then
        '    Msg_Error("Telefono Inválido") : Exit Function
        'End If
        'If Val(T_Transporte.Text.Trim) = 0 Then
        '    Msg_Error("Transporte Inválido") : Exit Function
        'End If
        G.cn.Close()
        Return True
    End Function

    Protected Sub Ima_Alta_Click(sender As Object, e As System.EventArgs) Handles Ima_Alta.Click
        Habilita()
        T_Numero.Enabled = False
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Numero.Text = Siguiente()
        T_Numero.Focus()
        Pnl_Registro.Enabled = True
    End Sub
    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal RFC As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Numero
        f("Razon_Social") = Descripcion
        f("Rfc") = RFC.Trim
        f("Colonia") = T_Colonia.Text.Trim
        f("Cond_Pago") = T_CondPago.Text.Trim
        f("CP") = T_CP.Text.Trim
        f("Direccion") = T_Direccion.Text.Trim
        f("Estado") = T_Estado.Text.Trim
        f("Mail") = T_Mail.Text.Trim
        f("Pais") = T_Pais.Text.Trim
        f("Telefono_1") = T_Tel1.Text.Trim
        f("Telefono_2") = T_Tel2.Text.Trim
        f("Es_Corporativo") = R_Es_Corporativo.SelectedValue
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()

    End Sub
    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Razon_Social As String, ByVal RFC As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Razon_Social") = Razon_Social
            f("RFC") = RFC
            f("Colonia") = T_Colonia.Text.Trim
            f("Cond_Pago") = T_CondPago.Text.Trim
            f("CP") = T_CP.Text.Trim
            f("Direccion") = T_Direccion.Text.Trim
            f("Estado") = T_Estado.Text.Trim
            f("Mail") = T_Mail.Text.Trim
            f("Pais") = T_Pais.Text.Trim
            f("Telefono_1") = T_Tel1.Text.Trim
            f("Telefono_2") = T_Tel2.Text.Trim
            f("Es_Corporativo") = R_Es_Corporativo.SelectedValue
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

    Protected Sub Ima_Guarda_Click(sender As Object, e As System.EventArgs) Handles Ima_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Try
            If validar() = False Then Exit Sub
            If Movimiento.Value = "Alta" Then
                T_Numero.Text = Siguiente()
                G.cn.Open()
                Tsql = "Select Razon_Social from Proveedor where Razon_Social=" & Pone_Apos(T_RazonSocial.Text)
                G.com.CommandText = Tsql
                If Not G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Ya existe el registro: " & Pone_Apos(T_RazonSocial.Text)) : Exit Sub
                End If
                G.Tsql = "Insert into Proveedor (Numero,Rfc,Razon_Social,Direccion,Colonia,Estado,CP,Pais,Mail,Fax,Telefono_1,Telefono_2,"
                G.Tsql &= "Comprador,Cond_Pago,Transporte,Fecha_Cambio,Es_Corporativo,Contacto_Nombre,Contacto_Mail,Contacto_Telefono,Baja) values ("
                G.Tsql &= Val(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_RFC.Text.Trim.ToUpper)
                G.Tsql &= "," & Pone_Apos(T_RazonSocial.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Colonia.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Estado.Text.Trim)
                G.Tsql &= "," & Val(T_CP.Text.Trim)
                G.Tsql &= "," & Val(T_Pais.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Mail.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Fax.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Tel1.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Tel2.Text.Trim)
                G.Tsql &= "," & Val(T_Comprador.Text.Trim)
                G.Tsql &= "," & Val(T_CondPago.Text.Trim)
                G.Tsql &= "," & Val(T_Transporte.Text.Trim)
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= "," & Pone_Apos(R_Es_Corporativo.SelectedValue.ToString)
                G.Tsql &= "," & Pone_Apos(T_Contacto_Nombre.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Contacto_Mail.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Contacto_Telefono.Text.Trim)
                G.Tsql &= "," & "''" & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(T_Numero.Text.Trim, T_RazonSocial.Text.Trim, T_RFC.Text.Trim)
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Proveedor set RFC=" & Pone_Apos(T_RFC.Text.Trim.ToUpper)
                G.Tsql &= ",Razon_Social=" & Pone_Apos(T_RazonSocial.Text.Trim)
                G.Tsql &= ",Direccion=" & Pone_Apos(T_Direccion.Text.Trim)
                G.Tsql &= ",Colonia=" & Pone_Apos(T_Colonia.Text.Trim)
                G.Tsql &= ",Estado=" & Pone_Apos(T_Estado.Text.Trim)
                G.Tsql &= ",CP=" & Pone_Apos(T_CP.Text.Trim)
                G.Tsql &= ",Pais=" & Val(T_Pais.Text.Trim)
                G.Tsql &= ",Mail=" & Pone_Apos(T_Mail.Text.Trim)
                G.Tsql &= ",Fax=" & Pone_Apos(T_Fax.Text.Trim)
                G.Tsql &= ",Telefono_1=" & Pone_Apos(T_Tel1.Text.Trim)
                G.Tsql &= ",Telefono_2=" & Pone_Apos(T_Tel2.Text.Trim)
                G.Tsql &= ",Comprador=" & Val(T_Comprador.Text.Trim)
                G.Tsql &= ",Cond_Pago=" & Val(T_CondPago.Text.Trim)
                G.Tsql &= ",Transporte=" & Val(T_Transporte.Text.Trim)
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(DateTime.Now.ToString("yyyy/mm/dd"))
                G.Tsql &= ",Es_Corporativo=" & Pone_Apos(R_Es_Corporativo.SelectedValue.ToString)
                G.Tsql &= ",Contacto_Nombre=" & Pone_Apos(T_Contacto_Nombre.Text.Trim)
                G.Tsql &= ",Contacto_Mail=" & Pone_Apos(T_Contacto_Mail.Text.Trim)
                G.Tsql &= ",Contacto_Telefono=" & Pone_Apos(T_Contacto_Telefono.Text.Trim)
                G.Tsql &= ",Baja=" & "''"
                G.Tsql &= " Where Numero=" & Val(T_Numero.Text.Trim)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Numero.Text.Trim, T_RazonSocial.Text.Trim, T_RFC.Text.Trim)
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid(T_Numero.Text.Trim)
                End If

                LimpiaCampos()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Proveedor set Baja=" & "'*'"
                G.Tsql &= " Where Numero=" & Val(T_Numero.Text.Trim)
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
        LLenaGrid()
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
                T_Direccion.Text = f.Item("Direccion")
                T_Colonia.Text = f.Item("Colonia")
                T_Comprador.Text = f.Item("Comprador")
                T_CondPago.Text = f.Item("Cond_Pago")
                T_CP.Text = f.Item("CP")
                T_Estado.Text = f.Item("Estado")
                T_Fax.Text = f.Item("Fax")
                T_Mail.Text = f.Item("Mail")
                T_RFC.Text = f.Item("RFC")
                T_Tel1.Text = f.Item("Telefono_1")
                T_Tel2.Text = f.Item("Telefono_2")
                T_Transporte.Text = f.Item("Transporte")
                T_Pais.Text = f.Item("Pais")
                T_RazonSocial.Text = f.Item("Razon_Social")
                T_Contacto_Nombre.Text = f.Item("Contacto_Nombre")
                T_Contacto_Mail.Text = f.Item("Contacto_Mail")
                T_Contacto_Telefono.Text = f.Item("Contacto_Telefono")
                If f.Item("Es_Corporativo").Equals("S") Then
                    R_Es_Corporativo.SelectedValue = "S"
                Else
                    R_Es_Corporativo.SelectedValue = "N"
                End If
                T_Desc_Pais.Text = Busca_Cat(CType(Session("G"), Glo), "PAIS", T_Pais.Text)
                T_Desc_Transporte.Text = Busca_Cat(CType(Session("G"), Glo), "TRANSPORTE", T_Transporte.Text)
                T_Desc_CondPago.Text = Busca_Cat(CType(Session("G"), Glo), "CONDICION_PAGO", T_CondPago.Text)
                T_Desc_Comprador.Text = Busca_Cat(CType(Session("G"), Glo), "COMPRADOR", T_Comprador.Text)
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                T_Numero.Enabled = False
                T_Direccion.Enabled = False
                T_Colonia.Enabled = False
                T_Comprador.Enabled = False
                T_CondPago.Enabled = False
                T_CP.Enabled = False
                T_Estado.Enabled = False
                T_Fax.Enabled = False
                T_Mail.Enabled = False
                T_RFC.Enabled = False
                T_Tel1.Enabled = False
                T_Tel2.Enabled = False
                T_Transporte.Enabled = False
                T_Pais.Enabled = False
                T_RazonSocial.Enabled = False
                Pnl_Registro.Enabled = False
                H_Pais.Attributes.Add("style", "cursor:not-allowed;")
                H_Pais.Attributes.Add("onclick", "")
                H_Comprador.Attributes.Add("style", "cursor:not-allowed;")
                H_Comprador.Attributes.Add("onclick", "")
                H_CondPago.Attributes.Add("style", "cursor:not-allowed;")
                H_CondPago.Attributes.Add("onclick", "")
                H_Transporte.Attributes.Add("style", "cursor:not-allowed;")
                H_Transporte.Attributes.Add("onclick", "")
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Ima_Guarda.Enabled = False
                Ima_Guarda.CssClass = "Btn_Rojo"
                H_Pais.Attributes.Add("style", "cursor:not-allowed;")
                H_Pais.Attributes.Add("onclick", "")
                H_Comprador.Attributes.Add("style", "cursor:not-allowed;")
                H_Comprador.Attributes.Add("onclick", "")
                H_CondPago.Attributes.Add("style", "cursor:not-allowed;")
                H_CondPago.Attributes.Add("onclick", "")
                H_Transporte.Attributes.Add("style", "cursor:not-allowed;")
                H_Transporte.Attributes.Add("onclick", "")
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Direccion.Focus()
                Habilita()
                T_Numero.Enabled = False
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                Pnl_Registro.Enabled = True
                Ima_Guarda.Enabled = True
                Ima_Guarda.CssClass = "Btn_Azul"
                T_RFC.Enabled = True
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
        DesHabilita()
        LimpiaCampos()
        H_Pais.Attributes.Add("onclick", "")
        H_Comprador.Attributes.Add("onclick", "")
        H_CondPago.Attributes.Add("onclick", "")
        H_Transporte.Attributes.Add("onclick", "")
        GridView1.Visible = True
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Numero").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Numero.Text = f.Item("Numero")
            T_Direccion.Text = f.Item("Direccion")
            T_Colonia.Text = f.Item("Colonia")
            T_Comprador.Text = f.Item("Comprador")
            T_CondPago.Text = f.Item("Cond_Pago")
            T_CP.Text = f.Item("CP")
            T_Estado.Text = f.Item("Estado")
            T_Fax.Text = f.Item("Fax")
            T_Mail.Text = f.Item("Mail")
            T_RFC.Text = f.Item("RFC")
            T_Tel1.Text = f.Item("Telefono_1")
            T_Tel2.Text = f.Item("Telefono_2")
            T_Transporte.Text = f.Item("Transporte")
            T_Pais.Text = f.Item("Pais")
            T_RazonSocial.Text = f.Item("Razon_Social")
        End If
    End Sub
    
    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LLenaGrid()
    End Sub
     

    Protected Sub T_Pais_TextChanged(sender As Object, e As System.EventArgs) Handles T_Pais.TextChanged
        T_Desc_Pais.Text = Busca_Cat(CType(Session("G"), Glo), "PAIS", T_Pais.Text)
        If T_Desc_Pais.Text = "" Then
            Msg_Error("No existe Pais") : Exit Sub
        End If
        T_Mail.Focus()
    End Sub

    Protected Sub T_Transporte_TextChanged(sender As Object, e As System.EventArgs) Handles T_Transporte.TextChanged
        T_Desc_Transporte.Text = Busca_Cat(CType(Session("G"), Glo), "TRANSPORTE", T_Transporte.Text)
    End Sub

    Protected Sub T_CondPago_TextChanged(sender As Object, e As System.EventArgs) Handles T_CondPago.TextChanged
        T_Desc_CondPago.Text = Busca_Cat(CType(Session("G"), Glo), "CONDICION_PAGO", T_CondPago.Text)
        If T_Desc_CondPago.Text = "" Then
            Msg_Error("No existe Condicion de Pago") : Exit Sub
        End If
        T_Transporte.Focus()
    End Sub

    Protected Sub T_Comprador_TextChanged(sender As Object, e As System.EventArgs) Handles T_Comprador.TextChanged
        T_Desc_Comprador.Text = Busca_Cat(CType(Session("G"), Glo), "COMPRADOR", T_Comprador.Text)
        If T_Desc_Comprador.Text = "" Then
            Msg_Error("No existe Comprador") : Exit Sub
        End If
        T_CondPago.Focus()
    End Sub

   

    Protected Sub CH_Corporativo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CH_Corporativo.CheckedChanged
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
