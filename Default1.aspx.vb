Imports System.Data.SqlClient
Imports System.Data
Partial Class _Default1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        '  Session.Timeout = 10
        Session("SesionActiva") = "hola"
        If IsPostBack = False Then
            'List_Servidor.DataSource = Llena_Servidores()
            'List_Servidor.DataTextField = ""
            'List_Servidor.DataValueField = "Conexion_Desc"
            'List_Servidor.DataBind()
            'Session("G") = New Glo
            'Session("Numero_Compañia") = Val(T_Cia.Text.Trim)
            Llena_Empresa()

        End If
        T_Obra.Focus()
        form1.DefaultButton = "ImageButton1"
        'H_Obra.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=OBRA1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        'H_Obra.Attributes.Add("style", "cursor:pointer;")
        Msg_Err.Visible = False
        H_Obra.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=OBRA3&Cia=" & List_Empresa.SelectedValue & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Obra.Attributes.Add("style", "cursor:pointer;")
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Private Sub Llena_Empresa()
        Dim G As Glo = CType(Session("G"), Glo)
        Dim dtEmpresa As New DataTable
        Dim Tsql As String = ""
        Try
            G.cn.Open()
            Tsql = "Select Numero_Compañia,Razon_Social from Compañias "
            If G.Es_Administrador = False Then
                Tsql &= " Where Numero_Compañia in (Select top 1 Numero_Compañia from Acceso Where UsuarioNumero=" & Val(G.UsuarioNumero) & ") "
            End If
            G.com.CommandText = Tsql
            G.dr = G.com.ExecuteReader
            dtEmpresa.Load(G.dr)
            If G.dr.IsClosed = False Then G.dr.Close()

            List_Empresa.DataSource = dtEmpresa
            List_Empresa.DataTextField = "Razon_Social"
            List_Empresa.DataValueField = "Numero_Compañia"
            List_Empresa.DataBind()

            If List_Empresa.Items.Count > 0 Then
                G.Empresa_Numero = List_Empresa.SelectedValue
                Session("Numero_Compañia") = List_Empresa.SelectedValue
            End If
        Catch ex As Exception
            Msg_Error(ex.Message)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As System.EventArgs) Handles ImageButton1.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            Session("Cia") = Val(List_Empresa.SelectedValue)
            Session("Obra") = T_Obra.Text.Trim
            Session("Almacen") = T_Almacen.Text.Trim

            G.Tsql = "Select c.Numero,c.Descripcion as Almacen_Desc"
            G.Tsql &= ",b.Num_Sucursal,b.Descripcion as Obra_Desc"
            G.Tsql &= ",a.Numero_Compañia,a.Razon_Social as Cia_Desc,a.Logo,a.Height,a.Width"
            G.Tsql &= " from Compañias a "
            G.Tsql &= " left join Sucursal b on a.Numero_Compañia=b.Num_Compañia and b.Num_Sucursal =" & Pone_Apos(T_Obra.Text)
            G.Tsql &= " left join Almacen c on c.Cia=a.Numero_Compañia and c.Sucursal=b.Num_Sucursal and c.Numero=" & Val(T_Almacen.Text)
            G.Tsql &= " Where a.Numero_Compañia=" & Val(List_Empresa.SelectedValue)

            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Dim dt_InfoCompañia As New DataTable
            dt_InfoCompañia.Load(G.dr)
            Dim f As DataRow
            For Each f In dt_InfoCompañia.Rows
                G.Empresa_Numero = f("Numero_Compañia").ToString
                G.RazonSocial = f("Cia_Desc").ToString
                Session("Imagen") = f("Logo")
                G.Almacen = Val(f("Numero").ToString)
                G.Almacen_Desc = f("Almacen_Desc").ToString
                G.Sucursal = f("Num_Sucursal").ToString
                G.Sucursal_Desc = f("Obra_Desc").ToString
                Session("Logo_Height") = f("Height")
                Session("Logo_Width") = f("Width")
                If G.RazonSocial = "" Then
                    Msg_Error("Empresa Inválida") : Exit Sub
                ElseIf G.Sucursal_Desc = "" Then
                    Msg_Error("Proyecto Inválido") : Exit Sub
                ElseIf G.Almacen_Desc = "" Then
                    Msg_Error("Almacén Inválido") : Exit Sub
                End If
            Next
            If G.dr.IsClosed = False Then G.dr.Close()

            If G.Es_Administrador = False Then
                G.Tsql = "Select UsuarioNumero from Acceso "
                G.Tsql &= " Where UsuarioNumero=" & G.UsuarioNumero
                G.Tsql &= " and Numero_Compañia=" & Val(List_Empresa.SelectedValue)
                G.Tsql &= " and Obra=" & Pone_Apos(T_Obra.Text)
                G.com.CommandText = G.Tsql
                If G.com.ExecuteScalar Is Nothing Then
                    Msg_Error("Proyecto no asignado a Usuario") : Exit Sub
                End If
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString) : Exit Sub
        Finally
            G.cn.Close()
        End Try
        Response.Redirect("~/Menu.aspx")
    End Sub
    'Private Function Registra_Interaccion(ByRef G As Glo) As Boolean
    '    Registra_Interaccion = False
    '    Try
    '        G.com.CommandText = "Insert Into Usuarios(Numero_Compañia,Obra,UsuarioNumero,UsuarioClave,UsuarioNombre,UsuarioReal,UsuarioActivo"
    '        G.com.CommandText &= ",UsuarioAdministrador,UsuarioMail) values "
    '        G.com.CommandText &= "(0,'0',0,'IOP010820NAA','Inter','Interacción Operativa','S','S','inter-op@interaccion.com.mx')"
    '        G.com.ExecuteNonQuery()
    '        G.com.CommandText = "Insert Into Compañia(Numero_Compañia,Razon_Social)"
    '        G.com.CommandText &= " values (0,'Interación Operativa S.A. de C.V.')"
    '        G.com.ExecuteNonQuery()
    '        G.com.CommandText = "Insert Into Obra(Numero_Compañia,Obra,Nombre)"
    '        G.com.CommandText &= " values (0,'0','Obra')"
    '        G.com.ExecuteNonQuery()
    '    Catch ex As Exception
    '    End Try
    '    Return True
    'End Function
    Protected Sub T_Obra_TextChanged(sender As Object, e As System.EventArgs) Handles T_Obra.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        Session("Numero_Compañia") = Val(List_Empresa.SelectedValue)
        G.Empresa_Numero = Val(List_Empresa.SelectedValue)
    End Sub

    Protected Sub List_Empresa_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles List_Empresa.SelectedIndexChanged
        Dim G As Glo = CType(Session("G"), Glo)
        Session("Numero_Compañia") = List_Empresa.SelectedValue
        G.Empresa_Numero = List_Empresa.SelectedValue
        T_Obra.Text = ""
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As System.EventArgs) Handles ImageButton2.Click
        Response.Redirect("~/Default.aspx")
    End Sub
End Class
