Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Drawing
Partial Class Catalogo_Claves_Autorizacion
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
            Img_Logotipo.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Img_Logotipo.Style("Height") = Int(Session("Logo_Height")) & "px"
            Img_Logotipo.Style("Width") = Int(Session("Logo_Width")) & "px"
            CrearCamposTabla()
            LlenaGrid()
            Habilita()
        End If
        Msg_Err.Visible = False
        DibujaSpan()
        T_Nombre.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Clave.ClientID & "');")
        T_Clave.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & fileUploader1.ClientID & "');")
        fileUploader1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Departamento.ClientID & "');")
        T_Departamento.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")
        T_Numero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Numero.ClientID & "');")
    End Sub
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Nombre", Type.GetType("System.String")) : Session("dt").Columns("Nombre").DefaultValue = ""
        Session("dt").Columns.Add("Firma", Type.GetType("System.String")) : Session("dt").Columns("Firma").DefaultValue = ""
        Session("dt").Columns.Add("Clave_Seguridad", Type.GetType("System.String")) : Session("dt").Columns("Clave_Seguridad").DefaultValue = ""
        Session("dt").Columns.Add("Departamento", Type.GetType("System.String")) : Session("dt").Columns("Departamento").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
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
    Private Sub LlenaGrid()
        Session("dt") = Llena_DataTable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        Else
            DibujaSpan()
        End If
    End Sub
    Private Function Llena_DataTable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            Session("dt").Rows.Clear()
            G.cn.Open()
            G.Tsql = "Select Numero,Nombre,Clave_Seguridad,Firma,Departamento From Autorizacion_Claves "
            If Ch_Baja.Checked = True Then
                G.Tsql &= " Where Baja='*'"
            Else
                G.Tsql &= " Where Baja<>'*'"
            End If
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
            Dim clave(0) As DataColumn
            clave(0) = Session("dt").Columns("Numero")
            Session("dt").PrimaryKey = clave
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Protected Sub Btn_Alta_Click(sender As Object, e As System.EventArgs) Handles Btn_Alta.Click
        Movimiento.Value = "Alta"
        Deshabilita()
        Limpia_Campos()
        T_Numero.Text = Busca_Siguiente()
        T_Numero.Enabled = False
        Me.T_Nombre.Focus()
    End Sub
    Private Sub Habilita()
        Movimiento.Value = ""
        Btn_Alta.Enabled = True
        Btn_Restaura.Enabled = False
        Btn_Guarda.Enabled = False
        P_Campos.Enabled = False
        GridView1.Enabled = True
        P_Campos.Visible = False
        Pnl_Grids.Visible = True
        Btn_Guarda.Enabled = False
        Btn_Guarda.CssClass = "Btn_Rojo"
        Btn_Alta.CssClass = "Btn_Azul"
        Btn_Alta.Enabled = True
    End Sub
    Private Sub Deshabilita()
        Btn_Alta.Enabled = False
        Btn_Alta.CssClass = "Btn_Rojo"
        Btn_Guarda.CssClass = "Btn_Azul"
        Btn_Guarda.Enabled = True
        P_Campos.Visible = True
        Pnl_Grids.Visible = False
        Btn_Alta.Enabled = False
        Btn_Restaura.Enabled = True
        Btn_Guarda.Enabled = True
        P_Campos.Enabled = True
        GridView1.Enabled = False
    End Sub
    Private Sub Limpia_Campos()
            T_Numero.Text = 0
            T_Nombre.Text = ""
            T_Clave.Text = ""
            T_Departamento.Text = ""
    End Sub
    Private Function Busca_Siguiente() As Double
        Dim G As Glo = CType(Session("G"), Glo)
        Busca_Siguiente = 0
        Try
            G.Tsql = "Select max(Numero) As Siguiente From Autorizacion_Claves"
            G.Tsql &= " Where Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            Dim Reg As Boolean = False
            G.cn.Open()
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Busca_Siguiente = 1
            G.dr.Read()
            If G.dr.HasRows Then
                Busca_Siguiente = Val(G.dr.Item("Siguiente").ToString) + 1
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Function
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(0).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Numero.Text = f("Numero")
                T_Nombre.Text = f("Nombre")
                T_Clave.Text = f("Clave_Seguridad")
                T_Departamento.Text = f("Departamento")
                Nombre_Imagen.Value = f("Firma")
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Deshabilita()
                P_Campos.Enabled = False
                GridView1.Enabled = False
            End If

            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Numero.Focus()
                Deshabilita()
                T_Numero.Enabled = False
                GridView1.Enabled = False
            End If
        End If
    End Sub
    Public Function Imagen_A_Bytes(ByVal ruta As String) As Byte()
        Dim foto As New FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim arreglo(0 To foto.Length - 1) As Byte
        Dim reader As New BinaryReader(foto)
        arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length))
        foto.Flush()
        foto.Close()
        Return arreglo
    End Function
    Private Function GuardarArchivo(file As HttpPostedFile) As String
        Dim ruta As String = Server.MapPath("~/Trabajo")
        Dim archivo As String = String.Format("{0}\\{1}", ruta, file.FileName)
        GuardarArchivo = ""
        If Directory.Exists(ruta) Then
            If IO.File.Exists(archivo) Then
                IO.File.Delete(archivo)
                file.SaveAs(ruta & "/" & file.FileName)

                'Msg_Error("Vuelve a Seleccionar tu archivo")
            Else
                file.SaveAs(ruta & "/" & file.FileName)
                GuardarArchivo = file.FileName
            End If
        Else
            Directory.CreateDirectory(ruta)
        End If
    End Function

    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        Limpia_Campos()
        Habilita()
    End Sub
    Protected Sub Btn_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        Dim ext As String
        Try
            If fileUploader1.PostedFile Is Nothing Then
                ext = ""
            Else
                ext = fileUploader1.PostedFile.FileName
            End If
            Dim formatos() As String = {"jpg", "jpeg", "bmp", "png", "gif"}
            Dim nombre As String = fileUploader1.FileName
            Dim Firma As String = ""

            If fileUploader1.HasFile Then
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
                If Array.IndexOf(formatos, ext) < 0 Then
                    Msg_Error("Formato de imagen inválido.") : Exit Sub
                Else
                    GuardarArchivo(fileUploader1.PostedFile)
                    If Msg_Err.Text = "Vuelve a Seleccionar tu archivo" Then
                        Exit Sub
                    End If

                    Firma = fileUploader1.FileName
                End If
            End If
            If Movimiento.Value = "Alta" Then
                G.cn.Open()
                'Tsql = "Select Razon_Social from Compañias where Razon_Social=" & Pone_Apos(T_Razon_Social.Text)
                'G.com.CommandText = Tsql
                'If Not G.com.ExecuteScalar Is Nothing Then
                '    Msg_Error("Ya existe el La Rason Social") : Exit Sub
                'End If
                G.Tsql = "Insert into Autorizacion_Claves (Numero,Nombre,Clave_Seguridad,Cve_Seg,Fecha_Seg,Hora_Seg,Baja,Firma,Fecha_Cambio,Cia,Obra) values ("
                G.Tsql &= Val(T_Numero.Text.Trim)
                G.Tsql &= "," & Pone_Apos(T_Nombre.Text)
                G.Tsql &= "," & Pone_Apos(T_Clave.Text)
                G.Tsql &= "," & Pone_Apos(Session("Contraseña"))
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= "," & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",''"
                G.Tsql &= "," & Pone_Apos(Firma)
                G.Tsql &= "," & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= "," & Val(Session("Cia"))
                G.Tsql &= "," & Pone_Apos(Session("Obra"))
                G.Tsql &= ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid()
                Limpia_Campos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.cn.Open()
                G.Tsql = "Update Autorizacion_Claves "
                G.Tsql &= "set Nombre=" & Pone_Apos(T_Nombre.Text)
                G.Tsql &= ",Departamento=" & Pone_Apos(T_Departamento.Text)
                G.Tsql &= ",Clave_Seguridad=" & Pone_Apos(T_Clave.Text)
                G.Tsql &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Firma=" & Pone_Apos(nombre)
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= ",Baja=''"
                G.Tsql &= " where Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                If Ch_Baja.Checked = True Then
                    EliminaFilaGrid()
                End If
                CambiaFilaGrid()
                Limpia_Campos()
            End If
            If Movimiento.Value = "Baja" Then
                G.cn.Open()
                G.Tsql = "Update Autorizacion_Claves "
                G.Tsql &= "set Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                G.Tsql &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= ",Hora_Seg=" & Pone_Apos(DateTime.Now.ToString("H:mm:ss", CultureInfo.InvariantCulture))
                G.Tsql &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(Now))
                G.Tsql &= ",Baja='*'"
                G.Tsql &= " where Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid()
                Limpia_Campos()
            End If
            'Deshabilita()
            Habilita()
        Catch ex As Exception
            Msg_Error(ex.Message)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Private Sub AñadeFilaGrid()
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Val(T_Numero.Text)
        f("Nombre") = T_Nombre.Text
        f("Clave_Seguridad") = T_Clave.Text
        f("Firma") = fileUploader1.FileName
        f("Departamento") = T_Departamento.Text
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub CambiaFilaGrid()
        Dim clave(0) As String
        clave(0) = Val(T_Numero.Text)
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Numero") = Val(T_Numero.Text)
            f("Nombre") = T_Nombre.Text
            f("Clave_Seguridad") = T_Clave.Text
            f("Firma") = fileUploader1.FileName
            f("Departamento") = T_Departamento.Text
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub
    Private Sub EliminaFilaGrid()
        Dim clave(0) As String
        clave(0) = Val(T_Numero.Text)
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Protected Sub Btn_Regresa_Click(sender As Object, e As System.EventArgs) Handles Btn_Regresa.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Ch_Baja_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        LlenaGrid()
    End Sub
End Class
