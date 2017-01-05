Imports System.Data
Imports System.IO
Imports System.Globalization
Imports System.Drawing

Partial Class C_Productos
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim script As String = "CargarDeNuevo();"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "CargarDeNuevo", script, True)
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            'If G.EmpresaNumero = 0 Or G.Almacen = "" Then Response.Redirect("Default.aspx")
            Lbl_Compañia.Text = "Empresa: Herramientas Laguna"
            Lbl_Usuario.Text = "Usuario: Sin Nombre de Usuario"
            Session("dt") = New DataTable
            CrearCamposTabla()
            DesHabilita()
            Pnl_Grids.Visible = False
            If IsNothing(Session("Imagen")) Then
                Image1.ImageUrl = "~/Imagenes/logo_Inter_Original.jpg"
            Else
                Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
                Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
                Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
            End If
            TB_Articulo.Focus()
        End If

        Msg_Err.Visible = False
        DibujaSpan()

        T_Descripicion.Attributes.Add("readonly", "true")
        TB_Articulo.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Descripcion.ClientID & "','" & TB_Articulo.ClientID & "');")
        TB_Descripcion.Attributes.Add("onkeydown", "javascript: PierdeFoco_1('" & TB_Articulo.ClientID & "','" & TB_Descripcion.ClientID & "');")
        T_Articulo.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Descripicion.ClientID & "');")
        T_Descripicion.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")

        T_Descripicion.Attributes.Add("onfocus", "this.select();")
        T_Articulo.Attributes.Add("onfocus", "this.select();")
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
        Session("dt").Columns.Add("Articulo", Type.GetType("System.String")) : Session("dt").Columns("Articulo").DefaultValue = ""
        Session("dt").Columns.Add("Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Ruta_Foto", Type.GetType("System.String")) : Session("dt").Columns("Ruta_Foto").DefaultValue = ""
        Session("dt").Columns.Add("Ficha_Tecnica", Type.GetType("System.String")) : Session("dt").Columns("Ficha_Tecnica").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Articulo")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub DesHabilita()
        Pnl_Busqueda.Visible = True
        Pnl_Registro.Visible = False
        GridView1.Enabled = True
        Pnl_Grids.Visible = True

        T_Articulo.Enabled = False
        T_Descripicion.Enabled = False

        Btn_Restaura.Enabled = False
        Btn_Guarda.Enabled = False
        Btn_Alta.Enabled = True
        Btn_Busca.Enabled = True
        Btn_Restaura.CssClass = "Btn_Rojo"
        Btn_Guarda.CssClass = "Btn_Rojo"
        Btn_Alta.CssClass = "Btn_Azul"
        Btn_Busca.CssClass = "Btn_Azul"
        TB_Descripcion.Enabled = True
        TB_Articulo.Enabled = True
        Ch_Baja.Enabled = True

    End Sub
    Private Sub Habilita()
        Pnl_Registro.Visible = True
        Pnl_Busqueda.Visible = False
        Pnl_Grids.Visible = False
        GridView1.Enabled = False
        ''GridView1.Visible = False

        T_Articulo.Enabled = True
        T_Descripicion.Enabled = True
        Btn_Restaura.Enabled = True
        Btn_Guarda.Enabled = True
        Btn_Alta.Enabled = False
        Btn_Busca.Enabled = False
        Btn_Restaura.CssClass = "Btn_Azul"
        Btn_Guarda.CssClass = "Btn_Azul"
        Btn_Alta.CssClass = "Btn_Rojo"
        Btn_Busca.CssClass = "Btn_Rojo"
        TB_Descripcion.Enabled = False
        TB_Articulo.Enabled = False
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
            G.Tsql = "Select top 200 Numero as Articulo,Art_Descripcion as Descripcion,Ruta_Foto,Ficha_Tecnica from Articulos"
            If Ch_Baja.Checked = True Then
                G.Tsql &= " Where Baja='*'"
            Else
                G.Tsql &= " Where Baja<>'*' "
            End If
            If TB_Articulo.Text.Trim <> "" Then
                G.Tsql &= " and Numero like'%" & Quita_Apos(TB_Articulo.Text.Trim) & "%'"
            End If
            If TB_Descripcion.Text.Trim <> "" Then
                G.Tsql &= " and Art_Descripcion like '%" & Quita_Apos(TB_Descripcion.Text.Trim) & "%'"
            End If
            G.Tsql &= " and Empresa=" & Val(G.Empresa_Numero)
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
        T_Articulo.Text = ""
        T_Descripicion.Text = ""
        TB_Articulo.Text = ""
        TB_Descripcion.Text = ""
    End Sub

    Private Function validar() As Boolean
        validar = False
        If T_Descripicion.Text.Trim = "" Then
            T_Descripicion.Focus()
            Msg_Error("Descripción Invalida") : Exit Function
        End If
        If T_Articulo.Text.Trim = "" Then
            T_Articulo.Focus()
            Msg_Error("Clave Artículo Invalida") : Exit Function
        End If
        If Lbl_Ruta_Imagen.Text.Trim = "" Then
            Lbl_Ruta_Imagen.Text = "Herramientas/imagen-no.png"
        End If
        If Lbl_Ficha_Tecnica.Text.Trim = "" Then
            Lbl_Ficha_Tecnica.Text = "Herramientas/imagen-no.png"
        End If
        Return True
    End Function

    Private Function Existe_Articulo() As Boolean
        Dim G As Glo = CType(Session("G"), Glo)
        Existe_Articulo = False
        Try
            G.Tsql = "Select Count(Numero)"
            G.Tsql &= " from Articulos Where Numero=" & Pone_Apos(Quita_Apos(T_Articulo.Text))
            G.Tsql &= " and Empresa=" & Val(G.Empresa_Numero)
            G.com.CommandText = G.Tsql
            G.cn.Open()
            Dim chec As Object
            chec = G.com.ExecuteScalar
            If IsNumeric(chec) Then
                If Val(chec) > 0 Then
                    Existe_Articulo = True
                End If
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Function
        Finally
            G.cn.Close()
        End Try
    End Function

    Protected Sub Ima_Alta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Alta.Click
        Habilita()
        T_Articulo.Enabled = True
        LimpiaCampos()
        Movimiento.Value = "Alta"
        T_Articulo.Focus()
        GridView1.Enabled = False
        Pnl_Registro.Enabled = True
    End Sub

    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Nombre As String, ByVal Ruta_Foto As String, ByVal Ficha_Tecnica As String)
        Session("dt").Rows.Clear()
        Dim f As DataRow = Session("dt").NewRow()
        f("Articulo") = UCase(Numero)
        f("Descripcion") = UCase(Nombre)
        f("Ruta_Foto") = Ruta_Foto
        f("Ficha_Tecnica") = Ficha_Tecnica
        Session("dt").Rows.Add(f)
        GridView1.PageIndex = Int((Session("dt").Rows.Count) / 10)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Private Sub CambiaFilaGrid(ByVal Numero As String, ByVal Nombre As String, ByVal Ruta_Foto As String, ByVal Ficha_Tecnica As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Descripcion") = UCase(Nombre)
            f("Ruta_Foto") = Ruta_Foto
            f("Ficha_Tecnica") = Ficha_Tecnica
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Private Sub EliminaFilaGrid(ByVal Numero As String)
        Dim clave(0) As String
        clave(0) = Numero
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
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

    Private Function GuardarArchivo(file As HttpPostedFile, Imagen_Subida As String) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Dim ruta As String = "C:/images"
        Dim archivo As String = String.Format("{0}\\{1}", ruta, file.FileName)
        GuardarArchivo = ""
        If IO.File.Exists(archivo) Then
            IO.File.Delete(archivo)
        End If

        Dim bytes As Byte() = New Byte(file.InputStream.Length - 1) {}
        file.InputStream.Read(bytes, 0, bytes.Length)
        bytes = ResizeImage(bytes, 300, 300)
        Using ms As New MemoryStream(bytes)
            Dim img As Image = Image.FromStream(ms)
            img.Save(archivo, System.Drawing.Imaging.ImageFormat.Png)
            GuardarArchivo = file.FileName
            Session("Imagen") = file.FileName
            If Imagen_Subida = "Ficha" Then
                Lbl_Ficha_Tecnica.Text = "/Herramientas/" & file.FileName
            Else
                Lbl_Ruta_Imagen.Text = "/Herramientas/" & file.FileName
            End If

            ms.Flush()
            ms.Close()
        End Using
    End Function

    Public Shared Function ResizeImage(source As Byte(), Optional newH As Integer = 0, Optional newW As Integer = 0) As Byte()
        Dim res As Byte() = Nothing
        ' Se define un tamaño predeterminado, para el caso de que no se le dé valor a la variable size
        ' El arreglo de bytes será convertido a un Stream dentro del método, el cual será vaciado al final de la operación para liberar la imagen.
        ' Esto es muy útil cuando se está leyendo la imagen desde un archivo del disco, pues si el objeto Stream queda abierto, el archivo puede ser bloqueado.
        Using ms As New MemoryStream(source, 0, source.Length)
            ' Se utiliza un objeto Image para leer el contenido de la imagen
            Dim img As Image = Image.FromStream(ms)
            Dim h As Integer = img.Height, w As Integer = img.Width
            If h <> newH And w <> newW Or h = newH And w <> newW Or h <> newH And w = newW Then
                ' Para cambiar el tamaño de la imagen, usamos un nuevo objeto Image, dentro del cual guardaremos la imagen redimensionada
                Using newImg As New Bitmap(img, newW, newH)
                    Using g As Graphics = Graphics.FromImage(newImg)
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
                        g.DrawImage(img, 0, 0, newImg.Width, newImg.Height)
                    End Using
                    ' El objeto res será el contenido en bytes de la imagen nueva
                    res = DirectCast(New ImageConverter().ConvertTo(newImg, GetType(Byte())), Byte())
                End Using
            Else
                ' Si no hay diferencias entre el tamaño anterior y el nuevo, el objeto res será el contenido de la imagen original
                res = DirectCast(New ImageConverter().ConvertTo(img, GetType(Byte())), Byte())
            End If
            ' Aquí cerramos el objeto Stream para liberar la imagen. Este paso es necesario para evitar que la imagen se bloquee.
            ms.Flush()
            ms.Close()
        End Using
        Return res
    End Function

    Private Sub SubirFoto()
        'Guardar Imagen Principal De Articulo
        Dim ruta As String = "C:/images/imagen-no.png"
        Dim ext As String
        If FU_Ruta_Foto.PostedFile Is Nothing Then
            ext = ""
        Else
            ext = FU_Ruta_Foto.PostedFile.FileName
        End If
        Dim formatos() As String = {"jpg", "jpeg", "bmp", "png", "gif"}
        Dim nombre As String = FU_Ruta_Foto.FileName
        Dim Logo_Cia As String = ""
        If Lbl_Ruta_Imagen.Text > "" Then Logo_Cia = Lbl_Ruta_Imagen.Text

        If FU_Ruta_Foto.HasFile Then
            ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
            If Array.IndexOf(formatos, ext) < 0 Then
                Msg_Error("Formato de imagen inválido.") : Exit Sub
            Else
                GuardarArchivo(FU_Ruta_Foto.PostedFile, "Foto")
                Lbl_Ruta_Imagen.Text = FU_Ruta_Foto.FileName
            End If
        End If

    End Sub
    Private Sub Subir_Ficha()
        'Guardar Imagen De Ficha Tecnica
        Dim ruta As String = "C:/images/imagen-no.png"
        Dim ext As String
        If FU_Ficha_Tecncia.PostedFile Is Nothing Then
            ext = ""
        Else
            ext = FU_Ficha_Tecncia.PostedFile.FileName
        End If
        Dim formatos() As String = {"jpg", "jpeg", "bmp", "png", "gif"}
        Dim nombre As String = FU_Ficha_Tecncia.FileName
        Dim Logo_Cia As String = ""
        If Lbl_Ficha_Tecnica.Text > "" Then Logo_Cia = Lbl_Ficha_Tecnica.Text

        If FU_Ficha_Tecncia.HasFile Then
            Lbl_Ficha_Tecnica.Text = FU_Ficha_Tecncia.PostedFile.FileName
            ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
            If Array.IndexOf(formatos, ext) < 0 Then
                Msg_Error("Formato de imagen inválido.") : Exit Sub
            Else
                GuardarArchivo(FU_Ficha_Tecncia.PostedFile, "Ficha")
                Lbl_Ficha_Tecnica.Text = FU_Ruta_Foto.FileName
            End If
        End If
    End Sub
    Protected Sub Ima_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Tsql As String = ""
        SubirFoto()
        Subir_Ficha()
        Try
            If validar() = False Then Exit Sub
            G.cn.Open()
            If Movimiento.Value = "Alta" Then
                G.Tsql = "Insert into Articulos (Articulo,Art_Descripcion,Ruta_Foto,Ficha_Tecnica,Empresa) values ("
                G.Tsql &= "," & Pone_Apos(UCase(Quita_Apos(T_Articulo.Text.Trim)))
                G.Tsql &= "," & Pone_Apos(UCase(Quita_Apos(T_Descripicion.Text.Trim)))
                G.Tsql &= "," & Pone_Apos(Quita_Apos(Lbl_Ruta_Imagen.Text))
                G.Tsql &= "," & Pone_Apos(Quita_Apos(Lbl_Ficha_Tecnica.Text))
                G.Tsql &= "," & Val(G.Empresa_Numero)
                G.Tsql &= ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                LimpiaCampos()
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Articulos set "
                G.Tsql &= " Art_Descripcion=" & Pone_Apos(UCase(Quita_Apos(T_Descripicion.Text.Trim)))
                G.Tsql &= ",Ruta_Foto=" & Pone_Apos(Lbl_Ruta_Imagen.Text)
                G.Tsql &= ",Ficha_Tecnica=" & Pone_Apos(Lbl_Ficha_Tecnica.Text)
                G.Tsql &= " Where Numero=" & Pone_Apos(Quita_Apos(T_Articulo.Text))
                G.Tsql &= " and Empresa=" & Val(G.Empresa_Numero)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                LimpiaCampos()
                Ch_Baja.Checked = False
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Articulos set "
                G.Tsql &= " Art_Descripcion=" & Pone_Apos(UCase(Quita_Apos(T_Descripicion.Text.Trim)))
                G.Tsql &= ",Ruta_Foto=" & Pone_Apos(Quita_Apos(Lbl_Ruta_Imagen.Text))
                G.Tsql &= ",Ficha_Tecnica=" & Pone_Apos(Lbl_Ficha_Tecnica.Text)
                G.Tsql &= " Where Numero=" & Pone_Apos(Quita_Apos(T_Articulo.Text))
                G.Tsql &= " and Empresa=" & Val(G.Empresa_Numero)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                LimpiaCampos()
                Imagen.ImageUrl = "Handler.ashx?img=" & Lbl_Ruta_Imagen.Text
            End If
            DesHabilita()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        LLenaGrid()
    End Sub

    Protected Sub Ima_Salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Or (e.CommandName.Equals("Seleccion")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(0).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                T_Articulo.Text = f("Articulo")
                T_Descripicion.Text = f("Descripcion")
                Lbl_Ruta_Imagen.Text = f("Ruta_Foto")
                Lbl_Ficha_Tecnica.Text = f("Ficha_Tecnica")
                GridView1.Enabled = False
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                Habilita()
                Pnl_Registro.Enabled = False
            End If
            If (e.CommandName.Equals("Seleccion")) Then
                Pnl_Registro.Enabled = False
                Habilita()
                Btn_Guarda.Enabled = False
                Btn_Guarda.CssClass = "Btn_Rojo"
            End If

            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                T_Descripicion.Focus()
                Habilita()
                Pnl_Registro.Enabled = True
                Btn_Guarda.Enabled = True
                Btn_Guarda.CssClass = "Btn_Azul"
                T_Articulo.Enabled = False
            End If
        End If
    End Sub

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Busca.Click
        LLenaGrid()
        Pnl_Grids.Visible = True
    End Sub
    Protected Sub Ima_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Restaura.Click
        DesHabilita()
        LimpiaCampos()
    End Sub

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex)("Articulo").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Articulo.Text = f("Articulo")
            T_Descripicion.Text = f("Art_Descripcion")
            Lbl_Ruta_Imagen.Text = f("Ruta_Foto")
            Lbl_Ficha_Tecnica.Text = f("Ficha_Tecnica")
            'Lbl_Ficha_Tecnica.Text = f("Ficha_Tecnica")
        End If
    End Sub
    Protected Sub Ch_Baja_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ch_Baja.CheckedChanged
        Pnl_Grids.Visible = True
        LLenaGrid()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub TB_Descripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Descripcion.TextChanged, TB_Articulo.TextChanged
        Pnl_Grids.Visible = True
        LLenaGrid()
    End Sub

End Class
