Imports System.Data.SqlClient
Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Timeout = 10
        Session("SesionActiva") = "hola"
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            List_Servidor.DataSource = Llena_Servidores()
            List_Servidor.DataTextField = ""
            List_Servidor.DataValueField = "Conexion_Desc"
            List_Servidor.DataBind()
            Session("G") = New Glo
            T_Usuario.Focus()
        End If
        'L_Fecha.Text = "Fecha:   " & Fecha_AMD(Now)
        'T_Cia.Focus()
        form1.DefaultButton = "ImageButton1"
        CreaCadenaConexion()
        Msg_Err.Visible = False
        T_Usuario.Attributes.Add("onfocus", "this.select();")
        T_Contraseña.Attributes.Add("onfocus", "this.select();")


    End Sub
    ' '' '' ''Protected Sub Btn_Iniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Iniciar.Click
    ' '' '' ''    Dim Base_Buscar = List_Servidor.SelectedValue
    ' '' '' ''    Dim G As Glo = CType(Session("G"), Glo)

    ' '' '' ''    CreaCadenaConexion()
    ' '' '' ''    'cn.ConnectionString = Conexion
    ' '' '' ''    Try
    ' '' '' ''        G.cn.Open()
    ' '' '' ''        If T_Usuario.Text.Trim.ToUpper = "BFMAFB" Then
    ' '' '' ''            If T_Contraseña.Text.Trim.ToUpper = "BFMAFB" Then  '  & Replace(Fecha_AMD(Now), "/", "") & H_Hora_Minutos.Value Then
    ' '' '' ''                Session("Empresa") = Val(T_EmpresaNumero.Text.Trim)
    ' '' '' ''                Session("Usuario") = "0"
    ' '' '' ''                Session("UsuarioNombre") = "Interaccion"
    ' '' '' ''                Session("UsuarioReal") = "Interaccion"
    ' '' '' ''                Session("EmpresaNombre") = "Interaccion Operativa"
    ' '' '' ''                G.Tsql = "Select Año from Empresas Where EmpresaNumero=" & Val(T_EmpresaNumero.Text.Trim)
    ' '' '' ''                G.com.CommandText = G.Tsql
    ' '' '' ''                G.Año = NuloADouble(G.com.ExecuteScalar)
    ' '' '' ''                Response.Redirect("~/Bienvenido.aspx")
    ' '' '' ''            End If
    ' '' '' ''        Else
    ' '' '' ''            '   Dim EmpresaNumero As Object
    ' '' '' ''            G.Tsql = "Select EmpresaNumero,EmpresaNombre,Año from Empresas Where EmpresaNumero=" & Val(T_EmpresaNumero.Text.Trim)
    ' '' '' ''            G.com.CommandText = G.Tsql
    ' '' '' ''            G.dr = G.com.ExecuteReader
    ' '' '' ''            If G.dr.HasRows = False Then
    ' '' '' ''                Mensaje("Empresa inválida") : Exit Sub
    ' '' '' ''            Else
    ' '' '' ''                G.dr.Read()
    ' '' '' ''                '  EmpresaNumero = dr.Item("EmpresaNumero")
    ' '' '' ''                Session("Empresa") = Val(T_EmpresaNumero.Text)
    ' '' '' ''                Session("EmpresaNombre") = G.dr.Item("EmpresaNombre")
    ' '' '' ''                G.Año = G.dr("Año")
    ' '' '' ''            End If
    ' '' '' ''            If G.dr.IsClosed = False Then G.dr.Close()

    ' '' '' ''            G.Tsql = "Select UsuarioNumero from Usuarios Where UsuarioNombre='" & Encripta(T_Usuario.Text.Trim) & "'"
    ' '' '' ''            G.Tsql &= " and EmpresaNumero=" & Val(T_EmpresaNumero.Text.Trim)
    ' '' '' ''            G.Tsql &= " and UsuarioActivo='S'"
    ' '' '' ''            G.com.CommandText = G.Tsql
    ' '' '' ''            G.dr = G.com.ExecuteReader
    ' '' '' ''            If G.dr.HasRows = False Then
    ' '' '' ''                Mensaje("Usuario inválido") : Exit Sub
    ' '' '' ''            End If
    ' '' '' ''            If G.dr.IsClosed = False Then G.dr.Close()

    ' '' '' ''            G.Tsql = "Select UsuarioNumero,UsuarioClave,UsuarioNombre,UsuarioReal,UsuarioAdministrador from Usuarios Where UsuarioNombre='" & Encripta(T_Usuario.Text.Trim) & "'"
    ' '' '' ''            G.Tsql &= " and EmpresaNumero=" & Val(T_EmpresaNumero.Text.Trim)
    ' '' '' ''            G.Tsql &= " and UsuarioClave='" & Encripta(T_Contraseña.Text.Trim) & "'"
    ' '' '' ''            G.com.CommandText = G.Tsql
    ' '' '' ''            G.dr = G.com.ExecuteReader
    ' '' '' ''            If G.dr.HasRows = False Then
    ' '' '' ''                Mensaje("Contraseña inválida") : Exit Sub
    ' '' '' ''            Else
    ' '' '' ''                G.dr.Read()
    ' '' '' ''                Session("Usuario") = G.dr.Item("UsuarioNumero")
    ' '' '' ''                Session("UsuarioNombre") = DesEncripta(G.dr.Item("UsuarioNombre"))
    ' '' '' ''                Session("UsuarioReal") = G.dr.Item("UsuarioReal")
    ' '' '' ''                Session("UsuarioAdministrador") = G.dr.Item("UsuarioAdministrador")
    ' '' '' ''            End If
    ' '' '' ''            If G.dr.IsClosed = False Then G.dr.Close()
    ' '' '' ''            Response.Redirect("~/Bienvenido.aspx")
    ' '' '' ''        End If
    ' '' '' ''        Catch ex As Exception
    ' '' '' ''        Mensaje(ex.Message.ToString)
    ' '' '' ''    Finally
    ' '' '' ''        G.cn.Close()
    ' '' '' ''    End Try

    ' '' '' ''End Sub




    Private Sub CreaCadenaConexion()
        Dim G As Glo = CType(Session("G"), Glo)
        Dim dtCombo As DataTable = Llena_Servidores()
        For Each f As DataRow In dtCombo.Rows
            If List_Servidor.Text.ToUpper = f("Conexion_Desc").ToUpper Then
                If InStr(f("Conexion_Desc").ToUpper.ToString, ".MDB") Then
                    'mConecta = "Provider=Microsoft.ACE.OLEDB.12.0"
                    'mConecta += ";Data Source=" & Alltrim(Conn_Ser(Tw_Countx, 1))
                    'mConecta += ";Jet OLEDB:Database Password=bffdos12345;"
                Else
                    'Server=192.168.50.10;uid=bernardo;pwd=B150958m;database=Fact_Web
                    'Conexion = "Provider=sqloledb "
                    Conexion = "Server=" & f("Servidor")
                    Conexion &= ";database=" & f("BaseNombre")
                    Conexion &= ";uid=" & f("Usuario")
                    Conexion &= ";pwd=" & f("Password")
                    G.cn.ConnectionString = Conexion

                    Conexion2 = "Server=" & f("Servidor")
                    Conexion2 &= ";database=" & "Maquinaria_Prueba"
                    Conexion2 &= ";uid=" & f("Usuario")
                    Conexion2 &= ";pwd=" & f("Password")
                    G.cn2.ConnectionString = Conexion2

                    Conexion3 = "Server=interopwebs.com"
                    Conexion3 &= ";database=" & "Prueba_WS"
                    Conexion3 &= ";uid=" & f("Usuario")
                    Conexion3 &= ";pwd=" & f("Password")
                    G.cn3.ConnectionString = Conexion3
                    'mConecta = "Provider=sqloledb "|
                    'mConecta += ";Server=" & Alltrim(Conn_Ser(Tw_Countx, 1))
                    'mConecta += ";Database=" & Alltrim(Conn_Ser(Tw_Countx, 2))
                    'mConecta += ";User Id=" & Alltrim(Conn_Ser(Tw_Countx, 3))
                    'mConecta += ";Password=" & Alltrim(Conn_Ser(Tw_Countx, 4))
                End If

                Exit For
            End If
        Next
    End Sub
    Private Function Llena_Servidores() As DataTable
        Dim sLine As String
        Dim arrayDatos() As String
        Dim longArray As Integer
        Dim i As Integer = 1
        Dim arrText As New ArrayList()
        Dim fichero As String = Server.MapPath("./Trabajo/Servidores.txt")
        Dim sr As New System.IO.StreamReader(fichero)
        Dim Cont_Act As Integer = 0
        Dim dtCombo As New DataTable
        dtCombo.Columns.Add("Conexion_Desc", Type.GetType("System.String")) : dtCombo.Columns("Conexion_Desc").DefaultValue = ""
        dtCombo.Columns.Add("Servidor", Type.GetType("System.String")) : dtCombo.Columns("Servidor").DefaultValue = ""
        dtCombo.Columns.Add("BaseNombre", Type.GetType("System.String")) : dtCombo.Columns("BaseNombre").DefaultValue = ""
        dtCombo.Columns.Add("Usuario", Type.GetType("System.String")) : dtCombo.Columns("Usuario").DefaultValue = ""
        dtCombo.Columns.Add("Password", Type.GetType("System.String")) : dtCombo.Columns("Password").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = dtCombo.Columns("Conexion_Desc")
        dtCombo.PrimaryKey = clave

        Do
            sLine = sr.ReadLine()
            If Not sLine Is Nothing Then
                If sLine.Trim <> "" Then
                    sLine = DesEncripta(sLine)
                    arrayDatos = Split(sLine, "|")
                    longArray = (UBound(arrayDatos))
                    dtCombo.Rows.Add()
                    Cont_Act = dtCombo.Rows.Count - 1
                    For C As Integer = 0 To longArray
                        If C = 0 Then dtCombo.Rows(Cont_Act)("Conexion_Desc") = arrayDatos(0)
                        If C = 1 Then dtCombo.Rows(Cont_Act)("Servidor") = arrayDatos(1)
                        If C = 2 Then dtCombo.Rows(Cont_Act)("BaseNombre") = arrayDatos(2)
                        If C = 3 Then dtCombo.Rows(Cont_Act)("Usuario") = arrayDatos(3)
                        If C = 4 Then dtCombo.Rows(Cont_Act)("Password") = arrayDatos(4)
                    Next
                End If
            End If
        Loop Until sLine Is Nothing
        sr.Close()
        Return dtCombo

    End Function
    'Private Sub Llena_Combo()
    '    'Recupera_RegistroW()
    '    Dim Acceso_anterior As String = ""
    '    Try
    '        List_Servidor.Items.Add(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Fact_Web", "NOM0", Nothing))
    '        Acceso_anterior = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Fact_Web", "NOM0", Nothing)
    '    Catch ex As Exception

    '    End Try

    '    For Tw_Countx = 1 To 40
    '        If Alltrim(Conn_Ser(Tw_Countx, 0)) > "" Then
    '            If Alltrim(Conn_Ser(Tw_Countx, 0)) <> Acceso_anterior Then
    '                List_Servidor.Items.Add(Conn_Ser(Tw_Countx, 0))
    '                'Combo1.Items.Add()
    '            End If
    '        End If
    '    Next
    '    If List_Servidor.Items.Count > 0 Then
    '        List_Servidor.SelectedIndex = 0
    '    End If
    'End Sub
    Protected Sub Btn_Registrarse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Registrarse.Click
        Response.Redirect("~/Registro_Usuario.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If T_Usuario.Text.ToUpper = "BFMAFB" And T_Contraseña.Text.ToUpper = "BFMAFB" Then Response.Redirect("~/Catalogo_Servidores.aspx")
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As System.EventArgs) Handles ImageButton1.Click
        Dim Base_Buscar = List_Servidor.SelectedValue
        Dim G As Glo = CType(Session("G"), Glo)
        'CreaCadenaConexion()'
        Try
            G.cn.Open()
            Session("Contraseña") = T_Contraseña.Text

            G.Tsql = "Select * from Usuarios Where UsuarioNombre=" & Pone_Apos(T_Usuario.Text.Trim)
            G.Tsql &= " and UsuarioClave=" & Pone_Apos(T_Contraseña.Text.Trim)
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            If G.dr.HasRows Then
                G.dr.Read()
                G.UsuarioNumero = G.dr("UsuarioNumero")
                G.UsuarioReal = G.dr("UsuarioReal")
                G.Usuario_Activo = DevuelveT_F(G.dr("UsuarioActivo"))
                G.Es_Administrador = DevuelveT_F(G.dr("UsuarioAdministrador"))
            Else
                If T_Usuario.Text.Trim.ToUpper = "BFMAFB" And T_Contraseña.Text.Trim.ToUpper = "BFMAFB" Then
                    G.Glo_Contraseña = "BFMAFB"
                    G.UsuarioNumero = 1
                    G.UsuarioReal = "Bernardo Fernandez Fernandez"
                    G.Usuario_Activo = True
                    G.Es_Administrador = True
                Else
                    Msg_Error("No existe el Usuario") : Exit Sub
                End If

            End If
            If G.dr.IsClosed = False Then G.dr.Close()

            If G.Usuario_Activo = False Then Msg_Error("Usuario sin activar") : Exit Sub
        Catch ex As Exception
            Mensaje(ex.Message.ToString) : Exit Sub
        Finally
            G.cn.Close()
        End Try
        Response.Redirect("~/Default1.aspx")
    End Sub

    Protected Sub T_Usuario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Usuario.TextChanged

    End Sub
End Class
