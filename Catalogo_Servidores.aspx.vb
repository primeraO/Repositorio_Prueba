Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Catalogo_Servidores
    Inherits System.Web.UI.Page
    Private Tsql As String = ""
    Private cn As New SqlConnection(Conexion)
    Private com As New SqlCommand("", cn)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Session("dt") = New DataTable
            CrearCamposTabla()
            LLena_Datatable()
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            'LLena_List_Conexiones()
            DesHabilita()
        End If
        DibujaSpan()
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
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Conexion_Desc", Type.GetType("System.String")) : Session("dt").Columns("Conexion_Desc").DefaultValue = ""
        Session("dt").Columns.Add("Servidor", Type.GetType("System.String")) : Session("dt").Columns("Servidor").DefaultValue = ""
        Session("dt").Columns.Add("BaseNombre", Type.GetType("System.String")) : Session("dt").Columns("BaseNombre").DefaultValue = ""
        Session("dt").Columns.Add("Usuario", Type.GetType("System.String")) : Session("dt").Columns("Usuario").DefaultValue = ""
        Session("dt").Columns.Add("Password", Type.GetType("System.String")) : Session("dt").Columns("Password").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Conexion_Desc")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub Guarda_Registro()
        Try
            Dim Cadena As String = "Primera linea"
            Dim archivo As System.IO.FileStream
            Dim sw As System.IO.StreamWriter
            'Dim path As String

            'path = nuevo.App_Path
            'path = path & "log\"

            Dim fichero As String = Server.MapPath("./Trabajo/Servidores.txt")
            Dim sr As New System.IO.StreamReader(fichero)

            'If System.IO.Directory.Exists(fichero) = False Then
            '    System.IO.Directory.CreateDirectory(fichero)
            'End If

            'path = path & Today & ".log"
            'path = path.Replace("/", "-")
            'si no existe

            If Not System.IO.File.Exists(fichero) Then
                archivo = System.IO.File.Create(fichero)
                archivo.Close()
                sw = System.IO.File.CreateText(fichero)
                sw.WriteLine(Cadena & vbTab & TimeOfDay)
                sw.WriteLine()
                sw.Flush()
                sw.Close()
            Else
                sw = System.IO.File.AppendText(fichero) ' si le pongo esto lo abro sin machacar contenido
                sw.WriteLine(Cadena & vbTab & TimeOfDay)
                sw.WriteLine()
                sw.Flush() ' para q funcione el añadir sin machacar, si no quito esto y el appaned
                sw.Close()
            End If
        Catch ex As Exception
            Mensaje(ex.ToString)
        End Try
        'Dim Exis_Reg As Boolean
        'Dim H_Nom As String
        'Dim H_Ser As String
        'Dim H_Bas As String
        'Dim H_Usu As String
        'Dim H_Acc As String

        'Exis_Reg = False
        'Dim Tw_Reg As Integer
        'For Tw_Reg = 1 To 40
        '    If Conn_Ser(Tw_Reg, 0) = T_Nombre.Text Then
        '        Exis_Reg = True
        '        Exit For
        '    End If
        '    If Movimiento.Value <> "Baja" Then
        '        If Alltrim(Conn_Ser(Tw_Reg, 0)) = "" Then
        '            Exit For
        '        End If
        '    End If
        'Next
        'If Tw_Reg < 41 Then
        '    H_Nom = "NOM" & Tw_Reg
        '    H_Ser = "SER" & Tw_Reg
        '    H_Bas = "BAS" & Tw_Reg
        '    H_Usu = "USU" & Tw_Reg
        '    H_Acc = "ACC" & Tw_Reg
        '    If Movimiento.Value = "Baja" Then
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Nom, "")
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Ser, "")
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Bas, "")
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Usu, "")
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Acc, "")
        '    Else
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Nom, T_Nombre.Text)
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Ser, T_Servidor.Text)
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Bas, T_Base.Text)
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Usu, T_Usuario.Text)
        '        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Factura_Web", H_Acc, T_Acceso.Text)
        '    End If
        'End If
        'If Movimiento.Value = "Alta" Then
        '    AñadeFilaGrid()
        'End If
        'If Movimiento.Value = "Baja" Then
        '    Conn_Ser(Tw_Reg, 0) = " "
        '    Conn_Ser(Tw_Reg, 1) = " "
        '    Conn_Ser(Tw_Reg, 2) = " "
        '    Conn_Ser(Tw_Reg, 3) = " "
        '    Conn_Ser(Tw_Reg, 4) = " "
        '    EliminaFilaGrid()
        '    LimpiaCampos()
        'End If
        'If Movimiento.Value = "Cambio" Then
        '    Conn_Ser(Tw_Reg, 0) = T_Nombre.Text
        '    Conn_Ser(Tw_Reg, 1) = T_Servidor.Text
        '    Conn_Ser(Tw_Reg, 2) = T_Base.Text
        '    Conn_Ser(Tw_Reg, 3) = T_Usuario.Text
        '    Conn_Ser(Tw_Reg, 4) = T_Acceso.Text
        '    CambiaFilaGrid()
        'End If
    End Sub
    Private Sub WriteToFile()
        Dim fp As System.IO.StreamWriter
        Try
            If Movimiento.Value = "Alta" Then
                AñadeFilaGrid()
            End If
            If Movimiento.Value = "Baja" Then
                EliminaFilaGrid()
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                CambiaFilaGrid()
            End If
            fp = File.CreateText(Server.MapPath(".\Trabajo\") & "Servidores.txt")
            Dim Registros As String = ""
            Dim Fila As String
            Dim nl As String = Environment.NewLine
            For Each f As DataRow In Session("dt").rows
                Fila = f("Conexion_Desc") & "|"
                Fila &= f("Servidor") & "|"
                Fila &= f("BaseNombre") & "|"
                Fila &= f("Usuario") & "|"
                Fila &= f("Password")
                Fila = Encripta(Fila)
                Registros &= Fila & nl
            Next
            fp.WriteLine(Registros)
            fp.Close()
        Catch err As Exception
            Mensaje("Creación de archivo falló " & err.ToString())
        Finally

        End Try

    End Sub
    Private Sub LimpiaCampos()
        T_Nombre.Text = ""
        T_Servidor.Text = ""
        T_Base.Text = ""
        T_Usuario.Text = ""
        T_Acceso.Text = ""
    End Sub
    Private Function validar() As Boolean
        validar = False
        If T_Nombre.Text = "" Then
            Mensaje("Nombre inválido") : Exit Function
        End If
        If T_Servidor.Text.Trim = "" Then
            Mensaje("Servidor inválido") : Exit Function
        End If
        If T_Base.Text.Trim = "" Then
            Mensaje("Base inválida") : Exit Function
        End If
        If T_Usuario.Text.Trim = "" Then
            Mensaje("Usuario inválido") : Exit Function
        End If
        If T_Acceso.Text.Trim = "" Then
            Mensaje("Acceso inválido") : Exit Function
        End If
        Return True
    End Function
    Private Sub AñadeFilaGrid()
        Dim f As DataRow = Session("dt").NewRow()
        f("Conexion_Desc") = T_Nombre.Text.Trim
        f("Servidor") = T_Servidor.Text.Trim
        f("BaseNombre") = T_Base.Text.Trim
        f("Usuario") = T_Usuario.Text.Trim
        f("Password") = T_Acceso.Text.Trim
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid()
        Dim clave(0) As String
        clave(0) = T_Nombre.Text.Trim
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Servidor") = T_Servidor.Text.Trim
            f("BaseNombre") = T_Base.Text.Trim
            f("Usuario") = T_Usuario.Text.Trim
            f("Password") = T_Acceso.Text.Trim
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid()
        Dim clave(0) As String
        clave(0) = T_Nombre.Text.Trim
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
        Else
            DibujaSpan()
        End If
    End Sub
    Private Function LLena_Datatable() As DataTable
        Dim sLine As String
        Dim arrayDatos() As String
        Dim longArray As Integer
        Dim i As Integer = 1
        Dim arrText As New ArrayList()
        Session("dt").Rows.Clear()
        Dim fichero As String = Server.MapPath("./Trabajo/Servidores.txt")
        If System.IO.File.Exists(fichero) = False Then
            Return Session("dt")
        End If
        Dim sr As New System.IO.StreamReader(fichero)
        Dim Cont_Act As Integer = 0
        Do
            sLine = sr.ReadLine()
            If Not sLine Is Nothing Then
                If sLine.Trim <> "" Then
                    sLine = DesEncripta(sLine)
                    arrayDatos = Split(sLine, "|")
                    longArray = (UBound(arrayDatos))
                    Session("dt").Rows.Add()
                    Cont_Act = Session("dt").Rows.Count - 1
                    For C As Integer = 0 To longArray
                        If C = 0 Then Session("dt").Rows(Cont_Act)("Conexion_Desc") = arrayDatos(0)
                        If C = 1 Then Session("dt").Rows(Cont_Act)("Servidor") = arrayDatos(1)
                        If C = 2 Then Session("dt").Rows(Cont_Act)("BaseNombre") = arrayDatos(2)
                        If C = 3 Then Session("dt").Rows(Cont_Act)("Usuario") = arrayDatos(3)
                        If C = 4 Then Session("dt").Rows(Cont_Act)("Password") = arrayDatos(4)
                    Next
                End If
            End If
        Loop Until sLine Is Nothing
        sr.Close()
        Return Session("dt")
    End Function
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub
    Private Sub DesHabilita()
        T_Nombre.Enabled = False
        T_Base.Enabled = False
        T_Usuario.Enabled = False
        T_Acceso.Enabled = False
        T_Servidor.Enabled = False

        Btn_Alta.Enabled = True : Btn_Alta.Focus()
        Btn_Cambio.Enabled = True
        Btn_Baja.Enabled = True
        Btn_Restaura.Enabled = False
        Btn_Guardar.Enabled = False
        Movimiento.Value = ""

        GridView1.Enabled = True
        Btn_Buscar.Enabled = True
    End Sub
    Private Sub Habilita()
        'List_Conexion.Enabled = True
        T_Base.Enabled = True
        T_Usuario.Enabled = True
        T_Acceso.Enabled = True
        T_Servidor.Enabled = True

        Btn_Alta.Enabled = False
        Btn_Cambio.Enabled = False
        Btn_Baja.Enabled = False
        Btn_Restaura.Enabled = True
        Btn_Guardar.Enabled = True

        GridView1.Enabled = False
        Btn_Buscar.Enabled = False
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Conexion_Desc").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Nombre.Text = f("Conexion_Desc")
            T_Servidor.Text = f("Servidor")
            T_Base.Text = f("BaseNombre")
            T_Usuario.Text = f("Usuario")
            T_Acceso.Text = f("Password")
        End If
    End Sub
    Protected Sub Btn_Buscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Buscar.Click
        LLenaGrid()
    End Sub

    Protected Sub Btn_Alta_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Alta.Click
        Habilita()
        T_Nombre.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Nombre.Focus()
    End Sub

    Protected Sub Btn_Baja_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Baja.Click
        If T_Nombre.Text.Trim = "" Then Exit Sub
        Habilita()
        Movimiento.Value = "Baja"
        T_Usuario.Focus()
    End Sub

    Protected Sub Btn_Cambio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Cambio.Click
        If T_Nombre.Text.Trim = "" Then Exit Sub
        Habilita()
        T_Nombre.Enabled = False
        Movimiento.Value = "Cambio"
        T_Servidor.Focus()

    End Sub

    Protected Sub Btn_Restaura_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Restaura.Click
        DesHabilita()
        LimpiaCampos()
    End Sub

    Protected Sub Btn_Guardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Guardar.Click
        Try
            If validar() = False Then Exit Sub
            WriteToFile()
            DesHabilita()
        Catch ex As Exception
            Mensaje(ex.Message.ToString)
        End Try

    End Sub

    Protected Sub Btn_Regresar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Btn_Regresar.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Default.aspx")
    End Sub

    'Protected Sub List_Servidores_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles List_Servidores.TextChanged
    '    If List_Servidores.SelectedValue = "ACCESS" Then
    '        Label16.Visible = False
    '        Label17.Visible = False
    '        T_Base.Visible = False
    '        T_Usuario.Visible = False
    '    Else
    '        Label16.Visible = True
    '        Label17.Visible = True
    '        T_Base.Visible = True
    '        T_Usuario.Visible = True
    '    End If
    'End Sub
End Class
