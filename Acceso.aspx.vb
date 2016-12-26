Imports System.Data
Partial Class Acceso
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
        Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
        Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
        Dim G As Glo = CType(Session("G"), Glo)
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            'Lbl_Compañia.Text = "Empresa: " & G.Empresa_Numero & " - " & G.RazonSocial
            ''Lbl_Proyecto.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            'Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Session("dt") = New DataTable
            CrearCamposTabla()
            Llena_Empresa()
            'Llenar_DataTable()
        End If
        T_Nombre.Attributes.Add("readonly", "true")
        Btn_Usuario.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=USUARIO',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Usuario.Attributes.Add("style", "cursor:pointer;")
        Btn_Obra.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=OBRA3&Cia=" & List_Empresa.SelectedValue & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Obra.Attributes.Add("style", "cursor:pointer;")
        DibujaSpan()
        T_Obra.Attributes.Add("onfocus", "this.select();")
        T_Numero.Attributes.Add("onfocus", "this.select();")
        Msg_Err.Visible = False
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
            List_Empresa.DataTextField = "Razon_Social"
            List_Empresa.DataValueField = "Numero_Compañia"
            List_Empresa.DataBind()

            If List_Empresa.Items.Count > 0 Then G.Empresa_Numero2 = List_Empresa.SelectedValue
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
        End If
    End Sub

    Protected Sub Btn_Salir_Click(sender As Object, e As System.EventArgs) Handles Btn_Salir.Click
        Response.Redirect("~/Menu.aspx")
    End Sub

    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Clave_Punto", Type.GetType("System.String")) : Session("dt").Columns("Clave_Punto").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion_Punto", Type.GetType("System.String")) : Session("dt").Columns("Descripcion_Punto").DefaultValue = ""
        Session("dt").Columns.Add("Altas", Type.GetType("System.String")) : Session("dt").Columns("Altas").DefaultValue = ""
        Session("dt").Columns.Add("Bajas", Type.GetType("System.String")) : Session("dt").Columns("Bajas").DefaultValue = ""
        Session("dt").Columns.Add("Cambios", Type.GetType("System.String")) : Session("dt").Columns("Cambios").DefaultValue = ""
        Session("dt").Columns.Add("Impresion", Type.GetType("System.String")) : Session("dt").Columns("Impresion").DefaultValue = ""
        Session("dt").Columns.Add("Pes_1", Type.GetType("System.String")) : Session("dt").Columns("Pes_1").DefaultValue = ""
        Session("dt").Columns.Add("Pes_2", Type.GetType("System.String")) : Session("dt").Columns("Pes_2").DefaultValue = ""
        Session("dt").Columns.Add("Pes_3", Type.GetType("System.String")) : Session("dt").Columns("Pes_3").DefaultValue = ""
        Session("dt").Columns.Add("Pes_4", Type.GetType("System.String")) : Session("dt").Columns("Pes_4").DefaultValue = ""
        Session("dt").Columns.Add("Pes_5", Type.GetType("System.String")) : Session("dt").Columns("Pes_5").DefaultValue = ""
        Session("dt").Columns.Add("Pes_6", Type.GetType("System.String")) : Session("dt").Columns("Pes_6").DefaultValue = ""
        Session("dt").Columns.Add("Pes_7", Type.GetType("System.String")) : Session("dt").Columns("Pes_7").DefaultValue = ""
        Session("dt").Columns.Add("Pes_8", Type.GetType("System.String")) : Session("dt").Columns("Pes_8").DefaultValue = ""
        Session("dt").Columns.Add("TA", Type.GetType("System.String")) : Session("dt").Columns("TA").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Clave_Punto")
        Session("dt").PrimaryKey = clave
    End Sub

    Protected Sub TB_Numero_TextChanged(sender As Object, e As System.EventArgs) Handles T_Numero.TextChanged
        Llenar_DataTable()
        T_Nombre.Text = Bus_Cat("USUARIOS", T_Numero.Text)
    End Sub
    Protected Sub T_Obra_TextChanged(sender As Object, e As System.EventArgs) Handles T_Obra.TextChanged
        If T_Numero.Text.Trim <> "" Then Llenar_DataTable()
        T_Obra_Desc.Text = Bus_Cat("OBRA", T_Obra.Text)
    End Sub
    Private Function Bus_Cat(ByVal Catalogo As String, ByVal Numero As String) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Bus_Cat = ""
        Try
            G.cn.Open()
            Select Case Catalogo.ToUpper
                Case "OBRA"
                    G.com.CommandText = "Select Descripcion from Obra Where Cia=" & List_Empresa.SelectedValue
                    G.com.CommandText &= " and Obra=" & Pone_Apos(Numero)
                    Bus_Cat = G.com.ExecuteScalar
                Case "USUARIOS"
                    G.com.CommandText = "Select UsuarioReal from Usuarios Where UsuarioNumero=" & Val(Numero)
                    Bus_Cat = G.com.ExecuteScalar
            End Select
        Catch ex As Exception
            Msg_Error(ex.Message)
        Finally
            G.cn.Close()
        End Try
    End Function
    Private Sub Llenar_DataTable()
        Dim G As Glo = CType(Session("G"), Glo)
        Session("dt").Rows.Clear()
        Try
            G.cn.Open()
            G.Tsql = "Select Clave_Punto, Descripcion_Punto from Punto_Menu"
            G.Tsql &= " Where Baja<>'*'"
            G.Tsql &= " Order by Clave_Punto "
            Dim dt_Puntos As New DataTable
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Puntos.Load(G.dr)
            dt_Puntos.PrimaryKey = New DataColumn() {dt_Puntos.Columns("Clave_Punto")}
            If G.dr.IsClosed Then G.dr.Close()

            G.Tsql = "Select a.Altas,a.Bajas,a.Cambios,a.Impresion,a.Clave_Punto,a.Pes_1,a.Pes_2,a.Pes_3,a.Pes_4,a.Pes_5,a.Pes_6,a.Pes_7,a.Pes_8,a.TA"
            G.Tsql &= " from Acceso a where a.UsuarioNumero=" & Val(T_Numero.Text)
            G.Tsql &= " and Numero_Compañia=" & Val(List_Empresa.SelectedValue)
            G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text)
            G.Tsql &= " order by a.Clave_Punto"
            Dim dt_PuntosUsuario As New DataTable
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_PuntosUsuario.Load(G.dr)
            dt_PuntosUsuario.PrimaryKey = New DataColumn() {dt_PuntosUsuario.Columns("Clave_Punto")}
            If G.dr.IsClosed Then G.dr.Close()

            If dt_PuntosUsuario.Rows.Count > 0 Then
                For Each f As DataRow In dt_Puntos.Rows
                    Dim nf As DataRow = Session("dt").NewRow
                    Dim renglon As DataRow
                    renglon = dt_PuntosUsuario.Rows.Find(f("Clave_Punto"))
                    If Not renglon Is Nothing Then
                        nf("Clave_Punto") = f("Clave_Punto")
                        nf("Descripcion_Punto") = f("Descripcion_Punto")
                        nf("Altas") = renglon("Altas")
                        nf("Bajas") = renglon("Bajas")
                        nf("Cambios") = renglon("Cambios")
                        nf("Impresion") = renglon("Impresion")
                        nf("Pes_1") = renglon("Pes_1")
                        nf("Pes_2") = renglon("Pes_2")
                        nf("Pes_3") = renglon("Pes_3")
                        nf("Pes_4") = renglon("Pes_4")
                        nf("Pes_5") = renglon("Pes_5")
                        nf("Pes_6") = renglon("Pes_6")
                        nf("Pes_7") = renglon("Pes_7")
                        nf("Pes_8") = renglon("Pes_8")
                        nf("TA") = renglon("TA")
                    Else
                        nf("Clave_Punto") = f("Clave_Punto")
                        nf("Descripcion_Punto") = f("Descripcion_Punto")
                        nf("Altas") = "N"
                        nf("Bajas") = "N"
                        nf("Cambios") = "N"
                        nf("Impresion") = "N"
                        nf("Pes_1") = "N"
                        nf("Pes_2") = "N"
                        nf("Pes_3") = "N"
                        nf("Pes_4") = "N"
                        nf("Pes_5") = "N"
                        nf("Pes_6") = "N"
                        nf("Pes_7") = "N"
                        nf("Pes_8") = "N"
                        nf("TA") = "N"
                    End If
                    Session("dt").Rows.Add(nf)
                Next
            Else
                For Each f As DataRow In dt_Puntos.Rows
                    Dim nf As DataRow = Session("dt").NewRow
                    Dim renglon As DataRow
                    renglon = dt_PuntosUsuario.Rows.Find(f("Clave_Punto"))
                    nf("Clave_Punto") = f("Clave_Punto")
                    nf("Descripcion_Punto") = f("Descripcion_Punto")
                    nf("Altas") = "N"
                    nf("Bajas") = "N"
                    nf("Cambios") = "N"
                    nf("Impresion") = "N"
                    nf("Pes_1") = "N"
                    nf("Pes_2") = "N"
                    nf("Pes_3") = "N"
                    nf("Pes_4") = "N"
                    nf("Pes_5") = "N"
                    nf("Pes_6") = "N"
                    nf("Pes_7") = "N"
                    nf("Pes_8") = "N"
                    nf("TA") = "N"
                    Session("dt").Rows.Add(nf)
                Next
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Private Sub Limpiar()
        T_Numero.Text = ""
        T_Nombre.Text = ""
        Punto.Text = ""
        Cve_putno.Value = ""
        R_Si.Checked = False
        R_No.Checked = False
    End Sub

    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        Llenar_DataTable()
        Pnl_Cambios.Visible = False
        Btn_Guarda.Visible = False
        Btn_Restaura.Visible = False
        Btn_Salir.Visible = True
        Btn_TodoN.Visible = True
        Btn_TodoS.Visible = True
    End Sub

    Protected Sub Btn_TodoS_Click(sender As Object, e As System.EventArgs) Handles Btn_TodoS.Click
        If T_Obra_Desc.Text.Trim = "" Then Msg_Error("Proyecto Inválido") : Exit Sub
        If T_Nombre.Text.Trim = "" Then Msg_Error("Usuario Inválido") : Exit Sub
        GuardarTodos("S")
        Llenar_DataTable()
    End Sub

    Protected Sub Btn_TodoN_Click(sender As Object, e As System.EventArgs) Handles Btn_TodoN.Click
        If T_Obra_Desc.Text.Trim = "" Then Msg_Error("Proyecot Inválido") : Exit Sub
        If T_Nombre.Text.Trim = "" Then Msg_Error("Usuario Inválido") : Exit Sub
        GuardarTodos("N")
        Llenar_DataTable()
    End Sub

    Private Sub GuardarTodos(ByVal SN As String)
        Dim G As Glo = CType(Session("G"), Glo)
        Session("dt").Rows.Clear()
        Try
            G.cn.Open()
            G.Tsql = "Select Clave_Punto, Descripcion_Punto from Punto_Menu"
            G.Tsql &= " Order by Clave_Punto"
            Dim dt_Puntos As New DataTable
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Puntos.Load(G.dr)
            dt_Puntos.PrimaryKey = New DataColumn() {dt_Puntos.Columns("Clave_Punto")}
            If G.dr.IsClosed Then G.dr.Close()

            Dim Tabla_Acceso As New DataTable
            G.Tsql = "Select Clave_Punto from Acceso Where UsuarioNumero=" & Val(T_Numero.Text)
            G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text)
            G.Tsql &= " and Numero_Compañia=" & Val(List_Empresa.SelectedValue)
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Tabla_Acceso.Load(G.dr)
            Tabla_Acceso.PrimaryKey = New DataColumn() {Tabla_Acceso.Columns("Clave_Punto")}
            G.Tsql = ""
            If dt_Puntos.Rows.Count > 0 Then
                For Each f As DataRow In dt_Puntos.Rows
                    Dim Renglon_Punto As DataRow
                    Renglon_Punto = Tabla_Acceso.Rows.Find(New Object() {f("Clave_Punto")})
                    If Renglon_Punto Is Nothing Then
                        G.Tsql &= " Insert Into Acceso(Clave_Punto,UsuarioNumero,Descripcion_Punto,Altas,Bajas,Cambios,Impresion"
                        G.Tsql &= ",Pes_1,Pes_2,Pes_3,Pes_4,Pes_5,Pes_6,Pes_7,Pes_8,TA"
                        G.Tsql &= ",Numero_Compañia,Obra) Values("
                        G.Tsql &= Pone_Apos(f("Clave_Punto"))
                        G.Tsql &= "," & Val(T_Numero.Text)
                        G.Tsql &= "," & Pone_Apos(f("Descripcion_Punto"))
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Pone_Apos(SN)
                        G.Tsql &= "," & Val(List_Empresa.SelectedValue)
                        G.Tsql &= "," & Pone_Apos(T_Obra.Text)
                        G.Tsql &= ")" & Chr(13)
                    Else
                        G.Tsql &= " Update Acceso set"
                        G.Tsql &= " Descripcion_Punto=" & Pone_Apos(f("Descripcion_Punto"))
                        G.Tsql &= ",Altas=" & Pone_Apos(SN)
                        G.Tsql &= ",Bajas=" & Pone_Apos(SN)
                        G.Tsql &= ",Cambios=" & Pone_Apos(SN)
                        G.Tsql &= ",Impresion=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_1=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_2=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_3=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_4=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_5=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_6=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_7=" & Pone_Apos(SN)
                        G.Tsql &= ",Pes_8=" & Pone_Apos(SN)
                        G.Tsql &= ",TA=" & Pone_Apos(SN)
                        G.Tsql &= " where Clave_Punto=" & Pone_Apos(f("Clave_Punto"))
                        G.Tsql &= " and UsuarioNumero=" & Val(T_Numero.Text) & Chr(13)
                        G.Tsql &= " and Numero_Compañia=" & Val(List_Empresa.SelectedValue)
                        G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text) & Chr(13)
                    End If
                Next
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            Llenar_DataTable()
        End If
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Cambio")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = GridView1.DataKeys(ind).Item("Clave_Punto").ToString
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                Btn_Guarda.Visible = True
                Btn_Restaura.Visible = True
                Btn_Salir.Visible = False
                Pnl_Cambios.Visible = True
                Btn_TodoN.Visible = False
                Btn_TodoS.Visible = False
                Punto.Text = f("Descripcion_Punto")
                Cve_putno.Value = f("Clave_Punto")
                If f("TA") = "S" Then
                    R_Si.Checked = True
                    R_No.Checked = False
                Else
                    R_Si.Checked = False
                    R_No.Checked = True
                End If
            End If
        End If
    End Sub

    Protected Sub Btn_Guarda_Click(sender As Object, e As System.EventArgs) Handles Btn_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        If T_Obra_Desc.Text.Trim = "" Then Msg_Error("Proyecot Inválido") : Exit Sub
        If T_Nombre.Text.Trim = "" Then Msg_Error("Usuario Inválido") : Exit Sub
        Try
            G.cn.Open()
            Try
                G.Tsql = "Insert into Acceso (Numero_Compañia,Obra,UsuarioNumero,Clave_Punto) values ("
                G.Tsql &= Val(List_Empresa.SelectedValue)
                G.Tsql &= "," & Pone_Apos(T_Obra.Text)
                G.Tsql &= "," & Val(T_Numero.Text)
                G.Tsql &= "," & Pone_Apos(Cve_putno.Value) & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
            Catch ex As Exception
            End Try

            Dim SN As String = "N"
            If R_Si.Checked Then
                SN = "S"
            End If
            If R_No.Checked Then
                SN = "N"
            End If
            G.Tsql = " Update Acceso set"
            G.Tsql &= " Descripcion_Punto=" & Pone_Apos(Punto.Text)
            G.Tsql &= ",Altas=" & Pone_Apos(SN)
            G.Tsql &= ",Bajas=" & Pone_Apos(SN)
            G.Tsql &= ",Cambios=" & Pone_Apos(SN)
            G.Tsql &= ",Impresion=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_1=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_2=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_3=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_4=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_5=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_6=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_7=" & Pone_Apos(SN)
            G.Tsql &= ",Pes_8=" & Pone_Apos(SN)
            G.Tsql &= ",TA=" & Pone_Apos(SN)
            G.Tsql &= " where Clave_Punto=" & Pone_Apos(Cve_putno.Value)
            G.Tsql &= " and UsuarioNumero=" & Val(T_Numero.Text) & Chr(13)
            G.Tsql &= " and Numero_Compañia=" & Val(List_Empresa.SelectedValue)
            G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text) & Chr(13)
            G.com.CommandText = G.Tsql
            G.com.ExecuteNonQuery()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
            Btn_Restaura_Click(Nothing, Nothing)
        End Try
    End Sub


    Protected Sub List_Empresa_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles List_Empresa.SelectedIndexChanged
        Dim G As Glo = CType(Session("G"), Glo)
        G.Empresa_Numero2 = List_Empresa.SelectedValue
        T_Obra.Text = "" : T_Obra_Desc.Text = ""
        T_Numero.Text = "" : T_Nombre.Text = ""
        Session("dt").Rows.Clear()
        'DibujaSpan()
        'Llenar_DataTable()
    End Sub


End Class
