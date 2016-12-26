Imports System.Data
Imports System.IO
Imports System.Globalization
Partial Class Migracion_Access_SQL
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
            Btn_Restaura_Click(Nothing, Nothing)
            LLenaGrid()

        End If
        DibujaSpan()
        Msg_Err.Visible = False
        
        T_Proyecto_Desc.Attributes.Add("reaonly", "true")
        T_Almacen_Desc.Attributes.Add("readonly", "true")
    End Sub

    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Numero", Type.GetType("System.Int64")) : Session("dt").Columns("Numero").DefaultValue = 0
        Session("dt").Columns.Add("Nombre_Base", Type.GetType("System.String")) : Session("dt").Columns("Nombre_Base").DefaultValue = ""
        Session("dt").Columns.Add("Ruta", Type.GetType("System.String")) : Session("dt").Columns("Ruta").DefaultValue = ""
        Session("dt").Columns.Add("Clave", Type.GetType("System.String")) : Session("dt").Columns("Clave").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Numero")
        Session("dt").PrimaryKey = clave
    End Sub

    Private Sub DibujaSpan()
        Dim dtspan As New DataTable
        dtspan = Session("dt").Copy
        If Session("dt").Rows.Count = 0 Then
            Dim f As DataRow = dtspan.NewRow()
            f("Numero") = 0
            f("Nombre_Base") = ""
            f("Ruta") = ""
            f("Clave") = ""
            'f("Baja") = ""
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
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            Session("dt") = New DataTable
            G.Tsql = "Select * from Bases_Importa  "
            G.Tsql &= " Order by Numero"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
            Session("dt").PrimaryKey = New DataColumn() {Session("dt").Columns("Numero")}
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function




    Protected Sub Btn_Salir_Click(sender As Object, e As System.EventArgs) Handles Btn_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Btn_Migrar_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar.Click
        ''Dim G As Glo = CType(Session("G"), Glo)
        ''''MIGRAR CON FILEUPLOAD
        ''Dim ext As String = ""
        ''Dim formatos() As String = {"mdb"}

        ''If Not FileUploader.HasFile Then
        ''    Msg_Error("No se ha seleccionado una base de origen") : Exit Sub
        ''Else

        ''    ext = FileUploader.PostedFile.FileName
        ''    ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower()
        ''    If Array.IndexOf(formatos, ext) < 0 Then
        ''        Msg_Error("Formato de Archivo Inválido.") : Exit Sub
        ''    End If
        ''End If
        ''Dim nombre_archivo As String = FileUploader.FileName
        ''Dim Ruta As String = Server.MapPath("~/Trabajo/")
        ''G.Ruta = Ruta & nombre_archivo
        ' ''G.Ruta = G.Ruta & nombre_archivo
        ''Dim Arch_Nom As String = String.Format("{0}\\{1}", Ruta, nombre_archivo)
        ''If Directory.Exists(Ruta) Then
        ''    If IO.File.Exists(Arch_Nom) Then
        ''        IO.File.Delete(Arch_Nom)
        ''        FileUploader.PostedFile.SaveAs(G.Ruta)
        ''    Else
        ''        FileUploader.PostedFile.SaveAs(G.Ruta)
        ''    End If
        ''Else
        ''    Directory.CreateDirectory(Ruta)
        ''    FileUploader.PostedFile.SaveAs(G.Ruta)
        ''End If
        ''G.Conexion_Acces = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & G.Ruta & ";Jet OLEDB:Database Password=jchoag01;"
        ''G.Olecn.ConnectionString = G.Conexion_Acces
        ''G.Olecom.Connection = G.Olecn

        ''Try
        ''    Migra_Articulos()
        ''Catch ex As Exception
        ''    Msg_Error(ex.Message.ToString)
        ''End Try


        ''''MIGRAR SIN USAR FILEUPLOAD
        'Try
        '    If IO.File.Exists(Archivo.Value) Then
        '        G.Conexion_Acces = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Archivo.Value & ";Jet OLEDB:Database Password=jchoag01;"
        '        G.Olecn.ConnectionString = G.Conexion_Acces
        '        G.Olecom.Connection = G.Olecn
        '    Else
        '        Msg_Error("No Existe el Archivo en la Ruta Especificada")
        '        Exit Sub
        '    End If
        '    ''Migra_Articulos()
        'Catch ex As Exception
        '    Msg_Error(ex.Message.ToString)
        'End Try
        Conexion_Access()
        Btn_Migrar.Enabled = False
        Btn_Migrar.CssClass = "Btn_Azul"
        'GridView1.Visible = False
        Pnl_Botones_Migrar.Visible = True
        Pnl_Tablas.Visible = False
    End Sub
    Private Sub Conexion_Access()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            If IO.File.Exists(Archivo.Value) Then
                G.Conexion_Acces = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Archivo.Value & ";Jet OLEDB:Database Password=jchoag01;"
                'G.Conexion_Acces = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Archivo.Value & ";Jet OLEDB:Database Password=jchoag01;"

                G.Olecn.ConnectionString = G.Conexion_Acces
                G.Olecom.Connection = G.Olecn
            Else
                Msg_Error("No Existe el Archivo en la Ruta Especificada")
                Exit Sub
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Migra_Articulos()
        ''Conexion_Access()
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Articulos_Access As New DataTable
        Dim dt_Articulos_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Articulos where Numero<>'' and Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " Order by Numero"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Articulos_Sql.Load(G.dr)
            dt_Articulos_Sql.PrimaryKey = New DataColumn() {dt_Articulos_Sql.Columns("Cia"), dt_Articulos_Sql.Columns("Obra"), dt_Articulos_Sql.Columns("Numero")}

            ''''Tabla de Access
            G.Tsql = "Select * from Articulos where Numero<>'' and Baja<>'*' Order by Numero"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Articulos_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Articulos_Access.Rows.Count
            Dim f_Sql As DataRow
            ''''Se recorre la tabla de Access y se verifica si la fila existe acutlamente en Sql
            For Each f_Access As DataRow In dt_Articulos_Access.Rows
                If Registro_Anterior <> f_Access("Numero") Then
                    f_Sql = dt_Articulos_Sql.Rows.Find(New Object() {Val(T_Compañia.Text), T_Proyecto.Text, f_Access("Numero")})
                    If f_Sql Is Nothing Then
                        Tw_Registros += 1
                        Query &= " Insert Into Articulos(Cia,Obra,Numero,Art_Descripcion,Aplicacion_Contable,Back_Order,Baja,Clasifica_Inventario,Concentrador"
                        Query &= ",Contenido,Costo_Estandar,Costo_MExtranjera,Costo_PS,Costo_PT,Costo_UltimaCompra,Descripcion,Descripcion_Amp"
                        Query &= ",Dias_Sobre_Pedido,DPMH,Elemento,Entradas,Existencia,Fecha_Alta,Fecha_Ventas,IVA,Lin_Numero,Lista_Precio,Localizacion"
                        Query &= ",Lote_Minimo,Maneja_IEPS,Mar_Numero,Maximo,Minimo,Modelo1,Modelo10,Modelo11,Modelo12,Modelo2,Modelo3,Modelo4,Modelo5"
                        Query &= ",Modelo6,Modelo7,Modelo8,Modelo9,Mon_Numero,Multiplos,Numero_Aplicacion,Pedido,Pedimento,Peso,Politica_Maximo"
                        Query &= ",Politica_Minimo,Punto_Reorden,Ref_Sub_Desc,Ref_Sub_Num,Ruta_Foto,Salidas,Sobre_Pedido,Sub_Numero,Tiempo_Entrega"
                        Query &= ",Tipo_CMExtranjera,Tipo_Etiqueta,Unidad_Medida,Catalogo,Figura,Pagina,Fecha_Cambio,Precio_Concurso"
                        Query &= ") values("
                        Query &= Val(T_Compañia.Text)
                        Query &= "," & Pone_Apos(T_Proyecto.Text)
                        Query &= "," & Pone_Apos(f_Access("Numero"))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Art_Descripcion")))
                        Query &= "," & Pone_Apos(f_Access("Aplicacion_Contable"))
                        Query &= "," & Val(f_Access("Back_Order"))
                        Query &= "," & Pone_Apos(f_Access("Baja"))
                        Query &= "," & Pone_Apos(f_Access("Clasifica_Inventario"))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Concentrador")))

                        Query &= "," & Val(f_Access("Contenido"))
                        Query &= "," & Val(f_Access("Costo_Estandar"))
                        Query &= "," & Val(f_Access("Costo_MExtranjera"))
                        Query &= "," & Val(f_Access("Costo_PS"))
                        Query &= "," & Val(f_Access("Costo_PT"))
                        Query &= "," & Val(f_Access("Costo_UltimaCompra"))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Descripcion")))
                        'Query &= "," & Val(f_Access("Descripcion_Amp"))
                        If IsDBNull(f_Access("Descripcion_Amp")) Or Val(f_Access("Descripcion_Amp")) = 0 Then
                            Query &= ",0"
                        Else
                            Query &= ",1"
                        End If

                        Query &= "," & Val(f_Access("Dias_Sobre_Pedido"))
                        Query &= "," & Val(f_Access("DPMH"))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Elemento")))
                        Query &= "," & Val(f_Access("Entradas"))
                        Query &= "," & Val(f_Access("Existencia"))
                        Query &= "," & Pone_Apos(f_Access("Fecha_Alta"))
                        Query &= "," & Pone_Apos(f_Access("Fecha_Ventas"))
                        Query &= "," & Val(f_Access("IVA"))
                        Query &= "," & Val(f_Access("Lin_Numero"))
                        ''Query &= "," & Val(f_Access("Lista_Precio"))
                        If IsDBNull(f_Access("Lista_Precio")) Or Val(f_Access("Lista_Precio")) = 0 Then
                            Query &= ",0"
                        Else
                            Query &= ",1"
                        End If
                        Query &= "," & Pone_Apos(f_Access("Localizacion"))
                        Query &= "," & Val(f_Access("Lote_Minimo"))
                        'Query &= "," & Pone_Apos(f_Access("Maneja_IEPS"))
                        If Val(f_Access("Maneja_IEPS")) = 0 Or IsDBNull(f_Access("Maneja_IEPS")) Then
                            Query &= ",0"
                        Else
                            Query &= ",1"
                        End If
                        Query &= "," & Val(f_Access("Mar_Numero"))
                        Query &= "," & Val(f_Access("Maximo"))
                        Query &= "," & Val(f_Access("Minimo"))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo1")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo10")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo11")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo12")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo2")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo3")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo4")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo5")))

                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo6")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo7")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo8")))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Modelo9")))
                        Query &= "," & Val(f_Access("Mon_Numero"))
                        Query &= "," & Val(f_Access("Multiplos"))
                        Query &= "," & Val(f_Access("Numero_Aplicacion"))
                        ' ''If Val(f_Access("Pasado_Costo")) = 0 Or IsDBNull(f_Access("Pasado_Costo")) Or f_Access("Pasado_Costo") = "" Or f_Access("Pasado_Costo") = "No" Then
                        ' ''    Query &= ",0"
                        ' ''Else
                        ' ''    Query &= ",1"
                        ' ''End If
                        Query &= "," & Val(f_Access("Pedido"))
                        'Query &= "," & Val(f_Access("Pedimento"))
                        If IsDBNull(f_Access("Pedimento")) Or Val(f_Access("Pedimento")) = 0 Then
                            Query &= ",0"
                        Else
                            Query &= ",1"
                        End If
                        Query &= "," & Val(f_Access("Peso"))
                        Query &= "," & Val(f_Access("Politica_Maximo"))

                        Query &= "," & Val(f_Access("Politica_Minimo"))
                        Query &= "," & Val(f_Access("Punto_Reorden"))
                        Query &= "," & Pone_Apos(f_Access("Ref_Sub_Desc"))
                        Query &= "," & Pone_Apos(f_Access("Ref_Sub_Num"))
                        Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Ruta_Foto")))
                        Query &= "," & Val(f_Access("Salidas"))
                        'Query &= "," & Val(f_Access("Sobre_Pedido"))
                        If IsDBNull(f_Access("Sobre_Pedido")) Or Val(f_Access("Sobre_Pedido")) = 0 Then
                            Query &= ",0"
                        Else
                            Query &= ",1"
                        End If
                        Query &= "," & Val(f_Access("Sub_Numero"))
                        Query &= "," & Val(f_Access("Tiempo_Entrega"))

                        Query &= "," & Val(f_Access("Tipo_CMExtranjera"))
                        Query &= "," & Val(f_Access("Tipo_Etiqueta"))
                        Query &= "," & Pone_Apos(f_Access("Unidad_Medida"))
                        Query &= "," & Pone_Apos(AString(f_Access("Catalogo")))
                        Query &= "," & Pone_Apos(AString(f_Access("Figura")))
                        Query &= "," & Pone_Apos(AString(f_Access("Pagina")))
                        Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        If IsDBNull(f_Access("Precio_Concurso")) Then
                            Query &= ",0"
                        Else
                            Query &= "," & Val(f_Access("Precio_Concurso"))
                        End If
                        Query &= ")" & Chr(13)
                        Tw_Ren += 1
                        'If Tw_Ren > 200 Then
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                        Query = ""
                        Tw_Ren = 0
                        'End If
                    Else
                        Dim Iguales As Boolean = True
                        For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                            If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                                Iguales = False
                                Exit For
                            End If
                        Next
                        If Iguales = False Then
                            Query &= " Update Articulos set"
                            Query &= " Art_Descripcion=" & Pone_Apos(Elimina_comilla(f_Access("Art_Descripcion")))
                            Query &= ",Aplicacion_Contable=" & Pone_Apos(f_Access("Aplicacion_Contable"))
                            Query &= ",Back_Order=" & Val(f_Access("Back_Order"))
                            Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                            Query &= ",Clasifica_Inventario=" & Pone_Apos(f_Access("Clasifica_Inventario"))
                            Query &= ",Concentrador=" & Pone_Apos(Elimina_comilla(f_Access("Concentrador")))

                            Query &= ",Contenido=" & Val(f_Access("Contenido"))
                            Query &= ",Costo_Estandar=" & Val(f_Access("Costo_Estandar"))
                            Query &= ",Costo_MExtranjera=" & Val(f_Access("Costo_MExtranjera"))
                            Query &= ",Costo_PS=" & Val(f_Access("Costo_PS"))
                            Query &= ",Costo_PT=" & Val(f_Access("Costo_PT"))
                            Query &= ",Costo_UltimaCompra=" & Val(f_Access("Costo_UltimaCompra"))
                            Query &= ",Descripcion=" & Pone_Apos(Elimina_comilla(f_Access("Descripcion")))
                            ''Query &= ",Descripcion_Amp=" & Val(f_Access("Descripcion_Amp"))
                            If f_Access("Descripcion_Amp") = False Then
                                Query &= ",Descripcion_Amp=0"
                            Else
                                Query &= ",Descripcion_Amp=1"
                            End If
                            Query &= ",Dias_Sobre_Pedido=" & Val(f_Access("Dias_Sobre_Pedido"))
                            Query &= ",DPMH=" & Val(f_Access("DPMH"))
                            Query &= ",Elemento=" & Pone_Apos(Elimina_comilla(f_Access("Elemento")))
                            Query &= ",Entradas=" & Val(f_Access("Entradas"))
                            Query &= ",Existencia=" & Val(f_Access("Existencia"))
                            Query &= ",Fecha_Alta=" & Pone_Apos(f_Access("Fecha_Alta"))
                            Query &= ",Fecha_Ventas=" & Pone_Apos(f_Access("Fecha_Ventas"))
                            Query &= ",IVA=" & Val(f_Access("IVA"))
                            Query &= ",Lin_Numero=" & Val(f_Access("Lin_Numero"))
                            'Query &= ",Lista_Precio=" & Val(f_Access("Lista_Precio"))
                            If IsDBNull(f_Access("Lista_Precio")) Or Val(f_Access("Lista_Precio")) = 0 Then
                                Query &= ",Lista_Precio=0"
                            Else
                                Query &= ",Lista_Precio=1"
                            End If
                            Query &= ",Localizacion=" & Pone_Apos(f_Access("Localizacion"))

                            Query &= ",Lote_Minimo=" & Val(f_Access("Lote_Minimo"))
                            'Query &= ",Maneja_IEPS=" & Val(f_Access("Maneja_IEPS"))
                            If Val(f_Access("Maneja_IEPS")) = 0 Or IsDBNull(f_Access("Maneja_IEPS")) Then
                                Query &= ",Maneja_IEPS=0"
                            Else
                                Query &= ",Maneja_IEPS=1"
                            End If
                            Query &= ",Mar_Numero=" & Val(f_Access("Mar_Numero"))
                            Query &= ",Maximo=" & Val(f_Access("Maximo"))
                            Query &= ",Minimo=" & Val(f_Access("Minimo"))
                            Query &= ",Modelo1=" & Pone_Apos(Elimina_comilla(f_Access("Modelo1")))
                            Query &= ",Modelo10=" & Pone_Apos(Elimina_comilla(f_Access("Modelo10")))
                            Query &= ",Modelo11=" & Pone_Apos(Elimina_comilla(f_Access("Modelo11")))
                            Query &= ",Modelo12=" & Pone_Apos(Elimina_comilla(f_Access("Modelo12")))
                            Query &= ",Modelo2=" & Pone_Apos(Elimina_comilla(f_Access("Modelo2")))
                            Query &= ",Modelo3=" & Pone_Apos(Elimina_comilla(f_Access("Modelo3")))
                            Query &= ",Modelo4=" & Pone_Apos(Elimina_comilla(f_Access("Modelo4")))
                            Query &= ",Modelo5=" & Pone_Apos(Elimina_comilla(f_Access("Modelo5")))

                            Query &= ",Modelo6=" & Pone_Apos(Elimina_comilla(f_Access("Modelo6")))
                            Query &= ",Modelo7=" & Pone_Apos(Elimina_comilla(f_Access("Modelo7")))
                            Query &= ",Modelo8=" & Pone_Apos(Elimina_comilla(f_Access("Modelo8")))
                            Query &= ",Modelo9=" & Pone_Apos(Elimina_comilla(f_Access("Modelo9")))
                            Query &= ",Mon_Numero=" & Val(f_Access("Mon_Numero"))
                            Query &= ",Multiplos=" & Val(f_Access("Multiplos"))
                            Query &= ",Numero_Aplicacion=" & Val(f_Access("Numero_Aplicacion"))
                            'Query &= ",Pasado_Costo=" & Pone_Apos(f_Access("Pasado_Costo"))
                            ''If Val(f_Access("Pasado_Costo")) = 0 Or IsDBNull(f_Access("Pasado_Costo")) Or f_Access("Pasado_Costo") = "" Or f_Access("Pasado_Costo") = "No" Then
                            ''    Query &= ",Pasado_Costo=0"
                            ''Else
                            ''    Query &= ",Pasado_Costo=1"
                            ''End If
                            Query &= ",Pedido=" & Val(f_Access("Pedido"))
                            'Query &= ",Pedimento=" & Val(f_Access("Pedimento"))
                            If IsDBNull(f_Access("Pedimento")) Or Val(f_Access("Pedimento")) = 0 Then
                                Query &= ",Pedimento=0"
                            Else
                                Query &= ",Pedimento=1"
                            End If
                            Query &= ",Peso=" & Val(f_Access("Peso"))
                            Query &= ",Politica_Maximo=" & Val(f_Access("Politica_Maximo"))

                            Query &= ",Politica_Minimo=" & Val(f_Access("Politica_Minimo"))
                            Query &= ",Punto_Reorden=" & Val(f_Access("Punto_Reorden"))
                            Query &= ",Ref_Sub_Desc=" & Pone_Apos(f_Access("Ref_Sub_Desc"))
                            Query &= ",Ref_Sub_Num=" & Pone_Apos(f_Access("Ref_Sub_Num"))
                            Query &= ",Ruta_Foto=" & Pone_Apos(Elimina_comilla(f_Access("Ruta_Foto")))
                            Query &= ",Salidas=" & Val(f_Access("Salidas"))
                            'Query &= ",Sobre_Pedido=" & Val(f_Access("Sobre_Pedido"))
                            If IsDBNull(f_Access("Sobre_Pedido")) Or Val(f_Access("Sobre_Pedido")) = 0 Then
                                Query &= ",Sobre_Pedido=0"
                            Else
                                Query &= ",Sobre_Pedido=1"
                            End If
                            Query &= ",Sub_Numero=" & Val(f_Access("Sub_Numero"))
                            Query &= ",Tiempo_Entrega=" & Val(f_Access("Tiempo_Entrega"))

                            Query &= ",Tipo_CMExtranjera=" & Val(f_Access("Tipo_CMExtranjera"))
                            Query &= ",Tipo_Etiqueta=" & Val(f_Access("Tipo_Etiqueta"))
                            Query &= ",Unidad_Medida=" & Pone_Apos(f_Access("Unidad_Medida"))
                            Query &= ",Catalogo=" & Pone_Apos(AString(f_Access("Catalogo")))
                            Query &= ",Figura=" & Pone_Apos(AString(f_Access("Figura")))
                            Query &= ",Pagina=" & Pone_Apos(AString(f_Access("Pagina")))
                            Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                            If IsDBNull(f_Access("Precio_Concurso")) Then
                                Query &= ",Precio_Concurso=0"
                            Else
                                Query &= ",Precio_Concurso=" & Val(f_Access("Precio_Concurso"))
                            End If
                            Query &= " Where Numero=" & Pone_Apos(f_Access("Numero"))
                            Query &= " and Cia=" & Val(T_Compañia.Text)
                            Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                            Tw_Ren += 1
                            '  If Tw_Ren > 200 Then

                            Try
                                G.com.CommandText = Query
                                G.com.ExecuteNonQuery()

                            Catch ex As Exception

                            End Try
                            Query = ""
                            Tw_Ren = 0
                            ' End If
                        End If
                    End If
                End If
                Registro_Anterior = f_Access("Numero")
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                Try
                    G.com.CommandText = Query
                    G.com.ExecuteNonQuery()
                Catch ex As Exception

                End Try
                Query = ""
                Tw_Ren = 0
            End If

        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Actividad_Area()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Actividad_Area  Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " Order by Actividad,Area"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Actividad"), dt_Sql.Columns("Area"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Actividad_Area  Where Baja<>'*'   Order by Actividad,Area"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Actividad")), Val(f_Access("Area")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Actividad_Area(Cia,Obra,Actividad,Area,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Actividad"))
                    Query &= "," & Val(f_Access("Area"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= ",''"
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Actividad_Area set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=''"
                        Query &= " Where Actividad=" & Val(f_Access("Actividad"))
                        Query &= " and Area=" & Val(f_Access("Area"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Centro_Costos()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Centro_Costos   Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " Order by Centro_Costos"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Centro_Costos"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Centro_Costos  Where Baja<>'*'  Order by Numero"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Centro_Costos(Cia,Obra,Centro_Costos,Descripcion,Departamento,Baja,Aplicacion) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(f_Access("Departamento"))
                    Query &= ",''"
                    Query &= "," & Pone_Apos(f_Access("Aplicacion"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        'G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Centro_Costos set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Departamento=" & Pone_Apos(f_Access("Departamento"))
                        Query &= ",Baja=''"
                        Query &= ",Aplicacion=" & Pone_Apos(f_Access("Aplicacion"))
                        Query &= " Where Centro_Costos=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Actividad_Frente()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Actividad_Frente   Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  Order by Actividad,Frente"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Actividad"), dt_Sql.Columns("Frente"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            G.Tsql = "Select * from Actividad_Frente   Where Baja<>'*' Order by Actividad,Frente"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {f_Access("Actividad"), Val(f_Access("Frente")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Actividad_Frente(Cia,Obra,Actividad,Frente,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Pone_Apos(f_Access("Actividad"))
                    Query &= "," & Val(f_Access("Frente"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= ",''"
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Actividad_Frente set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=''"
                        Query &= " Where Actividad=" & Pone_Apos(f_Access("Actividad"))
                        Query &= " and Frente=" & Val(f_Access("Frente"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Autoriza_Orden_Compra()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Autoriza_Orden_Compra  Where  Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  Order by Numero_Orden"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            'dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero_Orden"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero_Orden")}
            G.Tsql = "Select * from Autoriza_Orden_Compra    Order by Numero_Orden"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                'f_Sql = dt_Sql.Rows.Find(New Object() {f_Access("Numero_Orden"), Val(T_Compañia.Text), T_Proyecto.Text})
                f_Sql = dt_Sql.Rows.Find(New Object() {f_Access("Numero_Orden")})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Autoriza_Orden_Compra(Cia,Obra,Numero_Orden,Formulo,For_Fecha,For_Hora,For_Nombre"
                    Query &= ",Reviso,Rev_Fecha,Rev_Hora,Rev_Nombre,Autorizo,Aut_Fecha,Aut_Hora,Aut_Nombre"
                    Query &= ",Fecha_Cambio,Cuarta,Cuarta_Fecha,Cuarta_Hora,Cuarta_Nombre"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Pone_Apos(f_Access("Numero_Orden"))
                    Query &= "," & Val(f_Access("Formulo"))
                    Query &= "," & Pone_Apos(AString(f_Access("For_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("For_Hora")))
                    Query &= "," & Pone_Apos(AString(f_Access("For_Nombre")))
                    Query &= "," & Val(f_Access("Reviso"))
                    Query &= "," & Pone_Apos(AString(f_Access("Rev_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Rev_Hora")))
                    Query &= "," & Pone_Apos(AString(f_Access("Rev_Nombre")))
                    Query &= "," & Val(f_Access("Autorizo"))
                    Query &= "," & Pone_Apos(AString(f_Access("Aut_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Aut_Hora")))
                    Query &= "," & Pone_Apos(AString(f_Access("Aut_Nombre")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    If IsDBNull(f_Access("Cuarta")) = True Then
                        Query &= "," & 0
                    Else
                        Query &= "," & Val(f_Access("Cuarta"))

                    End If
                    Query &= "," & Pone_Apos(AString(f_Access("Cuarta_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Cuarta_Hora")))
                    Query &= "," & Pone_Apos(AString(f_Access("Cuarta_Nombre")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try
                    Query = ""
                    Tw_Ren = 0

                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Autoriza_Orden_compra set"
                        Query &= " Formulo=" & Val(f_Access("Formulo"))
                        Query &= ",For_Fecha=" & Pone_Apos(AString(f_Access("For_Fecha")))
                        Query &= ",For_Hora=" & Pone_Apos(AString(f_Access("For_Hora")))
                        Query &= ",For_Nombre=" & Pone_Apos(AString(f_Access("For_Nombre")))
                        Query &= ",Reviso=" & Val(f_Access("Reviso"))
                        Query &= ",Rev_Fecha=" & Pone_Apos(AString(f_Access("Rev_Fecha")))
                        Query &= ",Rev_Hora=" & Pone_Apos(AString(f_Access("Rev_Hora")))
                        Query &= ",Rev_Nombre=" & Pone_Apos(AString(f_Access("Rev_Nombre")))
                        Query &= ",Autorizo=" & Val(f_Access("Autorizo"))
                        Query &= ",Aut_Fecha=" & Pone_Apos(AString(f_Access("Aut_Fecha")))
                        Query &= ",Aut_Hora=" & Pone_Apos(AString(f_Access("Aut_Hora")))
                        Query &= ",Aut_Nombre=" & Pone_Apos(AString(f_Access("Aut_Nombre")))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        If IsDBNull(f_Access("Cuarta")) = True Then
                            Query &= ",Cuarta=" & 0
                        Else
                            Query &= ",Cuarta=" & Val(f_Access("Cuarta"))
                        End If
                        Query &= ",Cuarta_Fecha=" & Pone_Apos(AString(f_Access("Cuarta_Fecha")))
                        Query &= ",Cuarta_Hora=" & Pone_Apos(AString(f_Access("Cuarta_Hora")))
                        Query &= ",Cuarta_Nombre=" & Pone_Apos(AString(f_Access("Cuarta_Nombre")))
                        Query &= " Where Numero_Orden=" & Pone_Apos(f_Access("Numero_Orden")) & Chr(13)
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try

                        Query = ""
                        Tw_Ren = 0
                    End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Autoriza_Requisicion()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Autoriza_Requisicion  Where  Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " Order by Requisicion"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Requisicion"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Autoriza_Requisicion  Order by Requisicion"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Requisicion")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Autoriza_Requisicion(Cia,Obra,Requisicion,Superintendente,Sup_Fecha,Sup_Hora"
                    Query &= ",Almacen,Alm_Fecha,Alm_Hora,Administracion,Adm_Fecha,Adm_Hora,Gerente,Ger_Fecha,Ger_Hora"
                    Query &= ",Sup_Nombre,Alm_Nombre,Adm_Nombre,Fecha_Cambio"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Requisicion"))
                    Query &= "," & Val(f_Access("Superintendente"))
                    Query &= "," & Pone_Apos(AString(f_Access("Sup_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Sup_Hora")))
                    Query &= "," & Val(f_Access("Almacen"))
                    Query &= "," & Pone_Apos(AString(f_Access("Alm_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Alm_Hora")))
                    Query &= "," & Val(f_Access("Administracion"))
                    Query &= "," & Pone_Apos(AString(f_Access("Adm_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Adm_Hora")))
                    Query &= "," & Val(f_Access("Gerente"))
                    Query &= "," & Pone_Apos(AString(f_Access("Ger_Fecha")))
                    Query &= "," & Pone_Apos(AString(f_Access("Ger_Hora")))
                    Query &= "," & Pone_Apos(AString(f_Access("Sup_Nombre")))
                    Query &= "," & Pone_Apos(AString(f_Access("Alm_Nombre")))
                    Query &= "," & Pone_Apos(AString(f_Access("Adm_Nombre")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try
                    Query = ""
                    Tw_Ren = 0

                Else
                Dim Iguales As Boolean = True
                For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                    If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                        Iguales = False
                        Exit For
                    End If
                Next
                If Iguales = False Then
                    Query &= " Update Autoriza_Requisicion set"
                    Query &= " Superintendente=" & Val(f_Access("Superintendente"))
                        Query &= ",Sup_Fecha=" & Pone_Apos(AString(f_Access("Sup_Fecha")))
                        Query &= ",Sup_Hora=" & Pone_Apos(AString(f_Access("Sup_Hora")))
                    Query &= ",Almacen=" & Val(f_Access("Almacen"))
                        Query &= ",Alm_Fecha=" & Pone_Apos(AString(f_Access("Alm_Fecha")))
                        Query &= ",Alm_Hora=" & Pone_Apos(AString(f_Access("Alm_Hora")))
                    Query &= ",Administracion=" & Val(f_Access("Administracion"))
                        Query &= ",Adm_Fecha=" & Pone_Apos(AString(f_Access("Adm_Fecha")))
                        Query &= ",Adm_Hora=" & Pone_Apos(AString(f_Access("Adm_Hora")))
                        Query &= ",Gerente=" & Val(f_Access("Gerente"))
                        Query &= ",Ger_Fecha=" & Pone_Apos(AString(f_Access("Ger_Fecha")))
                        Query &= ",Ger_Hora=" & Pone_Apos(AString(f_Access("Ger_Hora")))
                        Query &= ",Sup_Nombre=" & Pone_Apos(AString(f_Access("Sup_Nombre")))
                        Query &= ",Alm_Nombre=" & Pone_Apos(AString(f_Access("Alm_Nombre")))
                        Query &= ",Adm_Nombre=" & Pone_Apos(AString(f_Access("Adm_Nombre")))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= " Where Requisicion=" & Val(f_Access("Requisicion"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                    Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                    Tw_Ren += 1

                        Try

                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                        Catch ex As Exception

                        End Try

                        Query = ""
                        Tw_Ren = 0                    
                End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Autorizacion_Claves()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Autorizacion_Claves  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " Order by Numero"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Autorizacion_Claves  Where Baja<>'*' Order by Numero"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Autorizacion_Claves(Cia,Obra,Numero,Clave_Seguridad,Cve_Seg,Fecha_seg,Hora_Seg"
                    Query &= ",Baja,Firma,Fecha_Cambio,Departamento,Nombre"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(AString(f_Access("Clave_Seguridad")))
                    Query &= "," & Pone_Apos(AString(f_Access("Cve_Seg")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Seg")))
                    Query &= "," & Pone_Apos(AString(f_Access("Hora_Seg")))
                    Query &= "," & Pone_Apos(AString(f_Access("Baja")))
                    Query &= "," & Pone_Apos(AString(f_Access("Firma")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= "," & Pone_Apos(AString(f_Access("Departamento")))
                    Query &= "," & Pone_Apos(AString(f_Access("Nombre")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Autorizacion_Claves set"
                        Query &= " Clave_Seguridad=" & Pone_Apos(AString(f_Access("Clave_Seguridad")))
                        Query &= ",Cve_Seg=" & Pone_Apos(AString(f_Access("Cve_Seg")))
                        Query &= ",Fecha_Seg=" & Pone_Apos(AString(f_Access("Fecha_Seg")))
                        Query &= ",Hora_Seg=" & Pone_Apos(AString(f_Access("Hora_Seg")))
                        Query &= ",Baja=" & Pone_Apos(AString(f_Access("Baja")))
                        Query &= ",Firma=" & Pone_Apos(AString(f_Access("Firma")))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        Query &= ",Departamento=" & Pone_Apos(AString(f_Access("Departamento")))
                        Query &= ",Nombre=" & Pone_Apos(AString(f_Access("Nombre")))
                        Query &= " Where Numero=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Compañias()
        'If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Compañias  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Cia")}

            ''''Tabla de Access
            G.Tsql = "Select * from Compañias  Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero_Compañia"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Compañias(Cia,Razon_Social,Adicional,RFC,Colonia,Direccion,Estado,Codigo_Postal"
                    Query &= ",Telefono,Folio_Cancelacion,Folio_Resguardo,Folio_Salidas,Formato_Orden,Formato_Requisicion"
                    Query &= ",Maximo_Pedido,Maximo_Registros,Mes_Proceso,Numero_Lote,Numero_Orden,Numero_Requisicion,Almacen"
                    Query &= ",Clave_Acceso,Logo,Ruta_Logo_Catalogos,Height,Width"
                    Query &= ") values("
                    Query &= Val(f_Access("Numero_Compañia"))
                    Query &= "," & Pone_Apos(f_Access("Razon_Social"))
                    Query &= "," & Pone_Apos(f_Access("Adicional"))
                    Query &= "," & Pone_Apos(f_Access("RFC"))
                    Query &= "," & Pone_Apos(f_Access("Colonia"))
                    Query &= "," & Pone_Apos(f_Access("Direccion"))
                    Query &= "," & Pone_Apos(f_Access("Estado"))
                    Query &= "," & Pone_Apos(f_Access("Codigo_Postal"))
                    Query &= "," & Pone_Apos(f_Access("Telefono"))
                    Query &= "," & Val(f_Access("Folio_Cancelacion"))
                    Query &= "," & Val(f_Access("Folio_Resguardo"))
                    Query &= "," & Val(f_Access("Folio_Salidas"))
                    Query &= "," & Val(f_Access("Formato_Orden"))
                    Query &= "," & Val(f_Access("Formato_Requisicion"))
                    Query &= "," & Val(f_Access("Maximo_Pedido"))
                    Query &= "," & Val(f_Access("Maximo_Registros"))
                    Query &= "," & Val(f_Access("Mes_Proceso"))
                    Query &= "," & Val(f_Access("Numero_Lote"))
                    Query &= "," & Val(f_Access("Numero_Orden"))
                    Query &= "," & Val(f_Access("Numero_Requisicion"))
                    Query &= "," & Val(f_Access("Almacen"))
                    Query &= "," & Pone_Apos(f_Access("Clave_Acceso"))
                    Query &= "," & Pone_Apos(f_Access("Logo"))
                    Query &= ",''"
                    Query &= ",60"
                    Query &= ",60"
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Compañias set"
                        Query &= " Razon_Social=" & Pone_Apos(f_Access("Razon_Social"))
                        Query &= ",Adicional=" & Pone_Apos(f_Access("Adicional"))
                        Query &= ",RFC=" & Pone_Apos(f_Access("RFC"))
                        Query &= ",Colonia=" & Pone_Apos(f_Access("Colonia"))
                        Query &= ",Direccion=" & Pone_Apos(f_Access("Direccion"))
                        Query &= ",Estado=" & Pone_Apos(f_Access("Estado"))
                        Query &= ",Codigo_Postal=" & Pone_Apos(f_Access("Codigo_Postal"))
                        Query &= ",Telefono=" & Pone_Apos(f_Access("Telefono"))
                        Query &= ",Folio_Cancelacion=" & Val(f_Access("Folio_Cancelacion"))
                        Query &= ",Folio_Resguardo=" & Val(f_Access("Folio_Resguardo"))
                        Query &= ",Folio_Salidas=" & Val(f_Access("Folio_Salidas"))
                        Query &= ",Formato_Orden=" & Val(f_Access("Formato_Orden"))
                        Query &= ",Formato_Requisicion=" & Val(f_Access("Formato_Requisicion"))
                        Query &= ",Maximo_Pedido=" & Val(f_Access("Maximo_Pedido"))
                        Query &= ",Maximo_Registros=" & Val(f_Access("Maximo_Registros"))
                        Query &= ",Mes_Proceso=" & Val(f_Access("Mes_Proceso"))
                        Query &= ",Numero_Lote=" & Val(f_Access("Numero_Lote"))
                        Query &= ",Numero_Orden=" & Val(f_Access("Numero_Orden"))
                        Query &= ",Numero_Requisicion=" & Val(f_Access("Numero_Requisicion"))
                        Query &= ",Almacen=" & Val(f_Access("Almacen"))
                        Query &= ",Clave_Acceso=" & Pone_Apos(f_Access("Clave_Acceso"))
                        Query &= ",Logo=" & Pone_Apos(f_Access("Logo"))
                        Query &= ",Ruta_Logo_Catalogos=''"
                        Query &= ",Height=60"
                        Query &= ",Width=60"
                        Query &= " Where Cia=" & Val(f_Access("Numero_Compañia"))
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Compradores()
        '' '' '' ''If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        '' '' '' ''Dim Tw_Ren As Integer = 0
        '' '' '' ''Dim Tw_Registros As Integer = 0
        '' '' '' ''Dim Num_Reg As Integer = 0
        '' '' '' ''Dim Registro_Anterior As String = ""
        '' '' '' ''Dim Descripcion As String = ""

        '' '' '' ''Dim dt_Access As New DataTable
        '' '' '' ''Dim dt_Sql As New DataTable
        '' '' '' ''Dim Query As String = ""
        '' '' '' ''Dim G As Glo = CType(Session("G"), Glo)
        '' '' '' ''Try
        '' '' '' ''    G.Tsql = "Select * from Comprador  Where Baja<>'*' "
        '' '' '' ''    G.cn.Open()
        '' '' '' ''    G.Olecn.Open()
        '' '' '' ''    ''''Tabla Actual de SQL
        '' '' '' ''    G.com.CommandText = G.Tsql
        '' '' '' ''    G.dr = G.com.ExecuteReader
        '' '' '' ''    dt_Sql.Load(G.dr)
        '' '' '' ''    dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Comprador"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

        '' '' '' ''    ''''Tabla de Access
        '' '' '' ''    G.Olecom.CommandText = G.Tsql
        '' '' '' ''    G.Oledr = G.Olecom.ExecuteReader
        '' '' '' ''    dt_Access.Load(G.Oledr)
        '' '' '' ''    'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
        '' '' '' ''    Dim Total_Registros As Integer = dt_Access.Rows.Count
        '' '' '' ''    Dim f_Sql As DataRow
        '' '' '' ''    For Each f_Access As DataRow In dt_Access.Rows
        '' '' '' ''        f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
        '' '' '' ''        If f_Sql Is Nothing Then
        '' '' '' ''            Query &= " Insert into Comprador(Cia,Obra,Comprador,Nombre,Cve_Seg,Fecha_seg,Hora_Seg,Baja"
        '' '' '' ''            Query &= ") values("
        '' '' '' ''            Query &= Val(T_Compañia.Text)
        '' '' '' ''            Query &= "," & Pone_Apos(T_Proyecto.Text)
        '' '' '' ''            Query &= "," & Val(f_Access("Numero"))
        '' '' '' ''            Query &= "," & Pone_Apos(f_Access("Nombre"))
        '' '' '' ''            Query &= "," & Pone_Apos(Session("Contraseña"))
        '' '' '' ''            Query &= "," & Pone_Apos(Fecha_AMD(Now))
        '' '' '' ''            Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
        '' '' '' ''            Query &= "," & Pone_Apos(f_Access("Baja"))
        '' '' '' ''            Query &= ")" & Chr(13)
        '' '' '' ''            Tw_Ren += 1
        '' '' '' ''            If Tw_Ren > 100 Then
        '' '' '' ''                G.com.CommandText = Query
        '' '' '' ''                G.com.ExecuteNonQuery()
        '' '' '' ''                Query = ""
        '' '' '' ''                Tw_Ren = 0
        '' '' '' ''            End If
        '' '' '' ''        Else
        '' '' '' ''            Dim Iguales As Boolean = True
        '' '' '' ''            For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
        '' '' '' ''                If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
        '' '' '' ''                    Iguales = False
        '' '' '' ''                    Exit For
        '' '' '' ''                End If
        '' '' '' ''            Next
        '' '' '' ''            If Iguales = False Then
        '' '' '' ''                Query &= " Update Comprador set"
        '' '' '' ''                Query &= " Nombre=" & Pone_Apos(f_Access("Nombre"))
        '' '' '' ''                Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
        '' '' '' ''                Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
        '' '' '' ''                Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
        '' '' '' ''                Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
        '' '' '' ''                Query &= " Where Comprador=" & Val(f_Access("Numero"))
        '' '' '' ''                Query &= " and Cia=" & Val(T_Compañia.Text)
        '' '' '' ''                Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
        '' '' '' ''                Tw_Ren += 1
        '' '' '' ''                If Tw_Ren > 100 Then
        '' '' '' ''                    G.com.CommandText = Query
        '' '' '' ''                    G.com.ExecuteNonQuery()
        '' '' '' ''                    Query = ""
        '' '' '' ''                    Tw_Ren = 0
        '' '' '' ''                End If
        '' '' '' ''            End If
        '' '' '' ''        End If
        '' '' '' ''    Next
        '' '' '' ''    Total_Registros = Total_Registros
        '' '' '' ''    If Query.Trim > "" Then
        '' '' '' ''        G.com.CommandText = Query
        '' '' '' ''        G.com.ExecuteNonQuery()
        '' '' '' ''        Query = ""
        '' '' '' ''        Tw_Ren = 0
        '' '' '' ''    End If
        '' '' '' ''Catch ex As Exception
        '' '' '' ''    Msg_Error(ex.Message.ToString)
        '' '' '' ''    Exit Sub
        '' '' '' ''Finally
        '' '' '' ''    G.cn.Close()
        '' '' '' ''    G.Olecn.Close()
        '' '' '' ''End Try
    End Sub

    Private Sub Condicion_Pago()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Condicion_Pago  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Condicion"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Condicion_Pago  Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Condicion_Pago(Cia,Obra,Condicion,Descripcion,Cve_Seg,Fecha_seg,Hora_Seg,Baja"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Condicion_Pago set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Condicion=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Economico()
        'If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Economico  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & " "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero")}

            ''''Tabla de Access
            G.Tsql = "Select * from Economico  Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {f_Access("Numero")})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Economico(Cia,Obra,Numero,Descripcion,Marca,Modelo,Serie,Aplicacion,Baja,Motor_Descripcion"
                    Query &= ",Motor_Serie,Motor_Marca,Motor_Modelo,Fecha_Cambio"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Pone_Apos(f_Access("Numero"))
                    Query &= "," & Pone_Apos(AString(f_Access("Descripcion")))
                    Query &= "," & Pone_Apos(AString(f_Access("Marca")))
                    Query &= "," & Pone_Apos(AString(f_Access("Modelo")))
                    Query &= "," & Pone_Apos(AString(f_Access("Serie")))
                    Query &= "," & Pone_Apos(AString(f_Access("Aplicacion")))
                    Query &= "," & Pone_Apos(AString(f_Access("Baja")))
                    Query &= "," & Pone_Apos(AString(f_Access("Motor_Descripcion")))
                    Query &= "," & Pone_Apos(AString(f_Access("Motor_Serie")))
                    Query &= "," & Pone_Apos(AString(f_Access("Motor_Marca")))
                    Query &= "," & Pone_Apos(AString(f_Access("Motor_Modelo")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Economico set"
                        Query &= " Descripcion=" & Pone_Apos(AString(f_Access("Descripcion")))
                        Query &= ",Marca=" & Pone_Apos(AString(f_Access("Marca")))
                        Query &= ",Modelo=" & Pone_Apos(AString(f_Access("Modelo")))
                        Query &= ",Serie=" & Pone_Apos(AString(f_Access("Serie")))
                        Query &= ",Aplicacion=" & Pone_Apos(AString(f_Access("Aplicacion")))
                        Query &= ",Baja=" & Pone_Apos(AString(f_Access("Baja")))
                        Query &= ",Motor_Descripcion=" & Pone_Apos(AString(f_Access("Motor_Descripcion")))
                        Query &= ",Motor_Serie=" & Pone_Apos(AString(f_Access("Motor_Serie")))
                        Query &= ",Motor_Marca=" & Pone_Apos(AString(f_Access("Motor_Marca")))
                        Query &= ",Motor_Modelo=" & Pone_Apos(AString(f_Access("Motor_Modelo")))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        Query &= " Where Numero=" & Pone_Apos(AString(f_Access("Numero")))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Configuracion()
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Configuracion  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero_Configuracion")}

            ''''Tabla de Access
            G.Tsql = "Select * from Configuracion  Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero_Configuracion"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Configuracion(Numero_Configuracion,Descripcion_Configuracion,Texto_Configuracion,Valor_Configuracion"
                    Query &= ") values("
                    Query &= Val(f_Access("Numero_Configuracion"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion_Configuracion"))
                    Query &= "," & Pone_Apos(f_Access("Texto_Configuracion"))
                    Query &= "," & Val(f_Access("Valor_Configuracion"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Configuracion set"
                        Query &= " Descripcion_Condiguracion=" & Pone_Apos(f_Access("Descripcion_Configuracion"))
                        Query &= ",Texto_Configuracion=" & Pone_Apos(f_Access("Texto_Configuracion"))
                        Query &= ",Valor_Configuracion=" & Pone_Apos(f_Access("Valor_Configuracion"))
                        Query &= " Where Numero_Configuracion=" & Val(f_Access("Numero_Configuracion"))
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Ejecutivos()
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Ejecutivo  Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero")}

            G.Tsql = "Select * from Ejecutivo  Where Baja<>'*'"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Ejecutivo(Cia,Obra,Numero,Nombre,Baja,Fecha_Cambio"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Nombre"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Ejecutivo set"
                        Query &= " Nombre=" & Pone_Apos(f_Access("Nombre"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= " Where Numero=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Frente()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Frente Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Frente"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Frente Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Frente(Cia,Obra,Frente,Descripcion,Aplicacion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(AString(f_Access("Descripcion")))
                    Query &= "," & Val(f_Access("Aplicacion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try


                    Query = ""
                    Tw_Ren = 0

                Else
                Dim Iguales As Boolean = True
                For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                    If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                        Iguales = False
                        Exit For
                    End If
                Next
                If Iguales = False Then
                    Query &= " Update Frente set"
                    Query &= " Descripcion=" & Pone_Apos(AString(f_Access("Descripcion")))
                    Query &= ",Aplicacion=" & Val(f_Access("Aplicacion"))
                    Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                    Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                    Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                    Query &= " Where Frente=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                    Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                    Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try

                        Query = ""
                        Tw_Ren = 0

                End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Gastos()
        'If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Gasto Where Baja<>'*'"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Gasto")}

            ''''Tabla de Access
            G.Tsql = "Select * from Gasto Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Gasto"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Gasto(Gasto,Descripcion,Baja"
                    Query &= ") values("
                    Query &= Val(f_Access("Gasto"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Gasto set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Gasto=" & Val(f_Access("Gasto")) & Chr(13)
                        'Query &= " and Cia=" & Val(T_Compañia.Text)
                        'Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Area()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub

        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Area Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Area"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Area Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Area")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Area(Cia,Obra,Area,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Area"))
                    Query &= "," & Pone_Apos(AString(f_Access("Descripcion")))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try


                    Query = ""
                    Tw_Ren = 0

                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Area set"
                        Query &= " Descripcion=" & Pone_Apos(AString(f_Access("Descripcion")))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Area=" & Val(f_Access("Area"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try

                        Query = ""
                        Tw_Ren = 0

                    End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Concepto_Costo()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub

        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Concepto_Costo Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Concepto"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Concepto_Costo Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Concepto")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Concepto_Costo(Cia,Obra,Concepto,Descripcion,Fecha_Seg,Hora_Seg,Baja"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Concepto"))
                    Query &= "," & Pone_Apos(AString(f_Access("Descripcion")))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try


                    Query = ""
                    Tw_Ren = 0

                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Concepto_Costo set"
                        Query &= " Descripcion=" & Pone_Apos(AString(f_Access("Descripcion")))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Concepto=" & Val(f_Access("Concepto"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try

                        Query = ""
                        Tw_Ren = 0

                    End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Gastos_19()
        'If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Gasto_19 Where Baja<>'*'  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Gasto")}

            ''''Tabla de Access
            G.Tsql = "Select * from Gasto_19 Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Gasto"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Gasto_19(Gasto,Descripcion,Fecha_Cambio,Baja"
                    Query &= ") values("
                    Query &= Val(f_Access("Gasto"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Gasto_19 set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Gasto=" & Val(f_Access("Gasto")) & Chr(13)
                        'Query &= " and Cia=" & Val(T_Compañia.Text)
                        'Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Empleados()
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Empleados Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero")}

            ''''Tabla de Access
            G.Tsql = "Select * from Empleados Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Empleados(Cia,Obra,Numero,Nombre,Baja,Fecha_Cambio,Categoria"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Nombre"))
                    Query &= ",''"
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= "," & Pone_Apos(AString(f_Access("Categoria")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Empleados set"
                        Query &= " Nombre=" & Pone_Apos(f_Access("Nombre"))
                        Query &= ",Baja=''"
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        Query &= ",Categoria=" & Pone_Apos(AString(f_Access("Categoria")))
                        Query &= " Where Numero=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Linea()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Linea Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Linea"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Linea Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Linea(Cia,Obra,Linea,Descripcion,Responsable,Aplicacion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Val(f_Access("Responsable"))
                    Query &= "," & Pone_Apos(f_Access("Aplicacion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try
                    Query = ""
                    Tw_Ren = 0
                    'End If
                Else
                Dim Iguales As Boolean = True
                For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                    If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                        Iguales = False
                        Exit For
                    End If
                Next
                If Iguales = False Then
                    Query &= " Update Linea set"
                    Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                    Query &= ",Responsable=" & Val(f_Access("Responsable"))
                    Query &= ",Aplicacion=" & Pone_Apos(f_Access("Aplicacion"))
                    Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                    Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                    Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                    Query &= " Where Linea=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                    Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                    Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                        Query = ""
                        Tw_Ren = 0
                    End If
                End If
            Next
            Total_Registros = Total_Registros

        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Lugar_Entrega()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Lugar_Entrega Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Lugar_Entrega Where Baja<>'*'"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Lugar_Entrega(Cia,Obra,Numero,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Lugar_Entrega set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Numero=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Marca()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Marca Where Baja<>'*'   and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Marca"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Marca Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Marca(Cia,Obra,Marca,Descripcion,Aplicacion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(f_Access("Aplicacion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Query = ""
                    Tw_Ren = 0                
                Else
                Dim Iguales As Boolean = True
                For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                    If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                        Iguales = False
                        Exit For
                    End If
                Next
                If Iguales = False Then
                    Query &= " Update Marca set"
                    Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                    Query &= ",Aplicacion=" & Pone_Apos(f_Access("Aplicacion"))
                    Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                    Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                    Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                    Query &= " Where Marca =" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                    Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Query = ""
                    Tw_Ren = 0
                End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Obra()
        'If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Obra Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & ""
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Obra Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(T_Compañia.Text), Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Obra(Cia,Obra,Descripcion,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Obra set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Obra =" & Pone_Apos(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Ordenes_Compra()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Ordenes_Compra    Where  Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Requisicion"), dt_Sql.Columns("Numero_Orden"), dt_Sql.Columns("Art_Numero"), dt_Sql.Columns("Obra"), dt_Sql.Columns("Numero_Compañia")}

            ''''Tabla de Access
            G.Tsql = "Select * from Ordenes_Compra   "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Requisicion")), f_Access("Numero_orden"), f_Access("Art_Numero"), T_Proyecto.Text, Val(T_Compañia.Text)})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Ordenes_Compra(Almacen,Art_Descripcion,Art_Numero,Cantidad,Cantidad_Recibida,CenCosto,Cond_Pago,Costo,Desc1,Desc2,Desc3,Desc4,Desc5,Desc6,Desc7"
                    Query &= ",Descuento,Embarque,Estatus,Fecha_Orden,Fecha_Promesa,Fecha_ProxEntrega,Fecha_Recibido,Fecha_Requiere,Fecha_Solicitud,IVA,Linea,Marca,Moneda"
                    Query &= ",Numero_Orden,Observacion,Partida,Precio,Pro_Art_Descripcion,Pro_Articulo,Proveedor,Requisicion,Solicitante,Tipo,Tipo_Cambio,Transporte"
                    Query &= ",Unidad_Medida,Via,Economico,Catalogo,Figura,Pagina,Comprador,Costo_Devolucion,Fecha_Recepcion,Fecha_Cambio,Lugar_Entrega,Flete_Proveedor,Departamento"
                    Query &= ",D_Condicion_Pago,Notas_Firma,Orden_Numero,Numero_compañia,Obra,Cia"
                    Query &= ") values("
                    Query &= Val(T_Almacen.Text)
                    Query &= "," & Pone_Apos(Elimina_comilla(f_Access("Art_Descripcion")))
                    Query &= "," & Pone_Apos(f_Access("Art_Numero"))
                    Query &= "," & Val(f_Access("Cantidad"))
                    Query &= "," & Val(f_Access("Cantidad_Recibida"))
                    Query &= "," & Val(f_Access("CenCosto"))
                    Query &= "," & Val(f_Access("Cond_Pago"))
                    Query &= "," & Val(f_Access("Costo"))
                    Query &= "," & Val(f_Access("Desc1"))
                    Query &= "," & Val(f_Access("Desc2"))
                    Query &= "," & Val(f_Access("Desc3"))
                    Query &= "," & Val(f_Access("Desc4"))
                    Query &= "," & Val(f_Access("Desc5"))
                    Query &= "," & Val(f_Access("Desc6"))
                    Query &= "," & Val(f_Access("Desc7"))

                    Query &= "," & Val(f_Access("Descuento"))
                    Query &= "," & Val(f_Access("Embarque"))
                    Query &= "," & Pone_Apos(f_Access("Estatus"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Orden"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Promesa"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_ProxEntrega"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Recibido"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Requiere"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Solicitud"))
                    Query &= "," & Val(f_Access("IVA"))
                    Query &= "," & Val(f_Access("Linea"))
                    Query &= "," & Val(f_Access("Marca"))
                    Query &= "," & Val(f_Access("Moneda"))

                    Query &= "," & Pone_Apos(f_Access("Numero_Orden"))
                    Query &= "," & Pone_Apos(f_Access("Observacion"))
                    Query &= "," & Val(f_Access("Partida"))
                    Query &= "," & Val(f_Access("Precio"))
                    Query &= "," & Pone_Apos(f_Access("Pro_Art_Descripcion"))
                    Query &= "," & Pone_Apos(f_Access("Pro_Articulo"))
                    Query &= "," & Val(f_Access("Proveedor"))
                    Query &= "," & Val(f_Access("Requisicion"))
                    Query &= "," & Val(f_Access("Solicitante"))
                    Query &= "," & Val(f_Access("Tipo"))
                    Query &= "," & Val(f_Access("Tipo_Cambio"))
                    Query &= "," & Val(f_Access("Transporte"))

                    Query &= "," & Pone_Apos(f_Access("Unidad_Medida"))
                    Query &= "," & Val(f_Access("Via"))
                    Query &= "," & Pone_Apos(f_Access("Economico"))
                    Query &= "," & Pone_Apos(AString(f_Access("Catalogo")))
                    Query &= "," & Pone_Apos(AString(f_Access("Figura")))
                    Query &= "," & Pone_Apos(AString(f_Access("Pagina")))
                    Query &= "," & Val(f_Access("Comprador"))
                    Query &= "," & Pone_Apos(f_Access("Costo_Devolucion"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Recepcion"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Cambio"))

                    Query &= "," & Pone_Apos(f_Access("Lugar_Entrega"))
                    Query &= "," & Pone_Apos(f_Access("Flete_Proveedor"))
                    Query &= "," & Pone_Apos(f_Access("Departamento"))
                    Query &= "," & Pone_Apos(f_Access("D_Condicion_Pago"))
                    Query &= "," & Pone_Apos(AString(f_Access("Notas_Firma")))
                    'If IsDBNull(f_Access("Notas_Firmas")) Then
                    '    Query &= ",''"
                    'Else
                    '    Query &= "," & Pone_Apos(f_Access("Notas_Firma"))
                    'End If
                    ''Query &= "," & Val(f_Access("Orden_Numero"))
                    If IsDBNull(f_Access("Orden_Numero")) Then
                        Query &= ",0"
                    Else
                        Query &= "," & Pone_Apos(f_Access("Orden_Numero"))
                    End If
                    Query &= "," & Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(T_Compañia.Text)
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    '   If Tw_Ren > 100 Then
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception

                    End Try

                    Query = ""
                    Tw_Ren = 0
                    ' End If
                Else
                Dim Iguales As Boolean = True
                For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                    If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                        Iguales = False
                        Exit For
                    End If
                Next
                If Iguales = False Then
                    Query &= " Update Ordenes_Compra set"
                        Query &= " Almacen=" & Val(T_Almacen.Text)
                    Query &= ",Art_Descripcion=" & Pone_Apos(Elimina_comilla(f_Access("Art_Descripcion")))
                    Query &= ",Cantidad=" & Val(f_Access("Cantidad"))
                    Query &= ",Cantidad_Recibida=" & Val(f_Access("Cantidad_Recibida"))
                    Query &= ",CenCosto=" & Val(f_Access("CenCosto"))
                    Query &= ",Cond_Pago=" & Val(f_Access("Cond_Pago"))
                    Query &= ",Costo=" & Val(f_Access("Costo"))
                    Query &= ",Desc1=" & Val(f_Access("Desc1"))
                    Query &= ",Desc2=" & Val(f_Access("Desc2"))
                    Query &= ",Desc3=" & Val(f_Access("Desc3"))
                    Query &= ",Desc4=" & Val(f_Access("Desc4"))
                    Query &= ",Desc5=" & Val(f_Access("Desc5"))
                    Query &= ",Desc6=" & Val(f_Access("Desc6"))
                    Query &= ",Desc7=" & Val(f_Access("Desc7"))

                    Query &= ",Descuento=" & Val(f_Access("Descuento"))
                    Query &= ",Embarque=" & Val(f_Access("Embarque"))
                    Query &= ",Estatus=" & Pone_Apos(f_Access("Estatus"))
                    Query &= ",Fecha_Orden=" & Pone_Apos(f_Access("Fecha_Orden"))
                    Query &= ",Fecha_Promesa=" & Pone_Apos(f_Access("Fecha_Promesa"))
                    Query &= ",Fecha_ProxEntrega=" & Pone_Apos(f_Access("Fecha_ProxEntrega"))
                    Query &= ",Fecha_Recibido=" & Pone_Apos(f_Access("Fecha_Recibido"))
                    Query &= ",Fecha_Requiere=" & Pone_Apos(f_Access("Fecha_Requiere"))
                    Query &= ",Fecha_Solicitud=" & Pone_Apos(f_Access("Fecha_Solicitud"))
                    Query &= ",IVA=" & Val(f_Access("IVA"))
                    Query &= ",Linea=" & Val(f_Access("Linea"))
                    Query &= ",Marca=" & Val(f_Access("Marca"))
                    Query &= ",Moneda=" & Val(f_Access("Moneda"))

                    Query &= ",Observacion=" & Pone_Apos(f_Access("Observacion"))
                    Query &= ",Partida=" & Val(f_Access("Partida"))
                    Query &= ",Precio=" & Val(f_Access("Precio"))
                    Query &= ",Pro_Art_Descripcion=" & Pone_Apos(f_Access("Pro_Art_Descripcion"))
                    Query &= ",Pro_Articulo=" & Pone_Apos(f_Access("Pro_Articulo"))
                    Query &= ",Proveedor=" & Val(f_Access("Proveedor"))
                    Query &= ",Solicitante=" & Val(f_Access("Solicitante"))
                    Query &= ",Tipo=" & Val(f_Access("Tipo"))
                    Query &= ",Tipo_Cambio=" & Val(f_Access("Tipo_Cambio"))
                    Query &= ",Transporte=" & Val(f_Access("Transporte"))

                    Query &= ",Unidad_Medida=" & Pone_Apos(f_Access("Unidad_Medida"))
                    Query &= ",Via=" & Val(f_Access("Via"))
                    Query &= ",Economico=" & Pone_Apos(f_Access("Economico"))
                    Query &= ",Catalogo=" & Pone_Apos(AString(f_Access("Catalogo")))
                    Query &= ",Figura=" & Pone_Apos(AString(f_Access("Figura")))
                    Query &= ",Pagina=" & Pone_Apos(AString(f_Access("Pagina")))
                    Query &= ",Comprador=" & Val(f_Access("Comprador"))
                    Query &= ",Costo_Devolucion=" & Pone_Apos(f_Access("Costo_Devolucion"))
                    Query &= ",Fecha_Recepcion=" & Pone_Apos(f_Access("Fecha_Recepcion"))
                    Query &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(Now))

                    Query &= ",Lugar_Entrega=" & Pone_Apos(f_Access("Lugar_Entrega"))
                    Query &= ",Flete_Proveedor=" & Pone_Apos(f_Access("Flete_Proveedor"))
                    Query &= ",Departamento=" & Pone_Apos(f_Access("Departamento"))
                    Query &= ",D_Condicion_Pago=" & Pone_Apos(f_Access("D_Condicion_Pago"))
                    Query &= ",Notas_Firma=" & Pone_Apos(AString(f_Access("Notas_Firma")))
                    'If IsDBNull(f_Access("Notas_Firmas")) Then
                    '    Query &= ",Notas_Firmas=''"
                    'Else
                    '    Query &= ",Notas_Firmas=" & Pone_Apos(f_Access("Notas_Firma"))
                    'End If
                    'Query &= ",Orden_Numero=" & Val(f_Access("Orden_Numero"))
                    If IsDBNull(f_Access("Orden_Numero")) Then
                        Query &= ",Orden_Numero=0"
                    Else
                        Query &= ",Orden_Numero=" & Pone_Apos(f_Access("Orden_Numero"))
                    End If
                    Query &= " Where Obra =" & Pone_Apos(T_Proyecto.Text)
                        Query &= " and Numero_compañia=" & Val(T_Compañia.Text)
                    Query &= " and Requisicion=" & Val(f_Access("Requisicion"))
                    Query &= " and Numero_Orden=" & Pone_Apos(f_Access("Numero_Orden"))
                    Query &= " and Art_Numero=" & Pone_Apos(f_Access("Art_Numero"))
                    Tw_Ren += 1
                        '   If Tw_Ren > 100 Then
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()

                        Catch ex As Exception

                        End Try
                        Query = ""
                        Tw_Ren = 0
                        'End If
                End If
                End If
            Next
            Total_Registros = Total_Registros
            'If Query.Trim > "" Then
            '    G.com.CommandText = Query
            '    G.com.ExecuteNonQuery()
            '    Query = ""
            '    Tw_Ren = 0
            'End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Responsable()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Responsable Where Baja<>'*'  and Numero_Compañia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "   "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero_Compañia"), dt_Sql.Columns("Obra"), dt_Sql.Columns("Responsable")}

            ''''Tabla de Access
            G.Tsql = "Select * from Responsable Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(T_Compañia.Text), T_Proyecto.Text, Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Responsable(Numero_Compañia,Obra,Responsable,Nombre,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Nombre"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    'If Tw_Ren > 100 Then
                    G.com.CommandText = Query
                    G.com.ExecuteNonQuery()
                    Query = ""
                    Tw_Ren = 0
                    'End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Responsable set"
                        Query &= " Nombre=" & Pone_Apos(f_Access("Nombre"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Responsable=" & Val(f_Access("Numero"))
                        Query &= " and Numero_Compañia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        'If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                        'End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            'If Query.Trim > "" Then
            '    G.com.CommandText = Query
            '    G.com.ExecuteNonQuery()
            '    Query = ""
            '    Tw_Ren = 0
            'End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Transporte()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Transporte Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra"), dt_Sql.Columns("Transporte")}

            ''''Tabla de Access
            G.Tsql = "Select * from Transporte Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(T_Compañia.Text), T_Proyecto.Text, Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Transporte(Cia,Obra,Transporte,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Transporte set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Transporte=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Requisicion()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Total_Registros As Integer = 0
        Try
            G.Tsql = "Select * from Requisicion  Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra"), dt_Sql.Columns("Art_Numero"), dt_Sql.Columns("Requisicion")}

            ''''Tabla de Access
            G.Tsql = "Select * from Requisicion "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Total_Registros = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                If Total_Registros = 23556 Then
                    Msg_Error("Llego")
                End If
                Total_Registros = Total_Registros - 1
                If IsDBNull(f_Access("Requisicion")) Then
                    Continue For
                End If
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(T_Compañia.Text), T_Proyecto.Text, f_Access("Art_Numero"), Val(f_Access("Requisicion"))})
                If f_Sql Is Nothing Then
                    If Total_Registros = 23556 Then
                        Msg_Error("Llego")
                    End If
                    Query &= " Insert into Requisicion(Cia,Obra,Requisicion,Art_Numero,Almacen,Art_Descripcion,Asignado1,Asignado2,Asignado3"
                    Query &= ",Cantidad,Cantidad_Recibida,Cantidad1,Cantidad2,Cantidad3,CenCosto,Comprador,Costo1,Costo2,Costo3"
                    Query &= ",Descuento1,Descuento2,Descuento3,Estatus,Fecha_Requiere,Fecha_Solicitud,Fecha1,Fecha2,Fecha3,Linea,Marca"
                    Query &= ",Moneda1,Moneda2,Moneda3,Observacion,Precio1,Precio2,Precio3,Proveedor1,Proveedor2,Proveedor3,Solicitante,Tipo"
                    Query &= ",Tipo_Cambio1,Tipo_Cambio2,Tipo_Cambio3,Unidad_Medida,Urgente,Economico,Catalogo,Figura,Pagina,Precio_Concurso"
                    Query &= ",Fecha_Recepcion,Lugar_Entrega,Libera_Almacen,Fecha_Libera_Almacen,Libero_Almacen,Flete1,Flete2,Flete3"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Requisicion"))
                    Query &= "," & Pone_Apos(AString(f_Access("Art_Numero")))
                    Query &= "," & Val(f_Access("Almacen"))
                    Query &= "," & Pone_Apos(Elimina_comilla(AString(f_Access("Art_Descripcion"))))
                    If Val(f_Access("Asignado1")) = 0 Then
                        Query &= "," & Pone_Apos("false")
                    Else
                        Query &= "," & Pone_Apos("true")
                    End If
                    If Val(f_Access("Asignado2")) = 0 Then
                        Query &= "," & Pone_Apos("false")
                    Else
                        Query &= "," & Pone_Apos("true")
                    End If
                    If Val(f_Access("Asignado3")) = 0 Then
                        Query &= "," & Pone_Apos("false")
                    Else
                        Query &= "," & Pone_Apos("true")
                    End If

                    Query &= "," & Val(f_Access("Cantidad"))
                    Query &= "," & Val(f_Access("Cantidad_Recibida"))
                    Query &= "," & Val(f_Access("Cantidad1"))
                    Query &= "," & Val(f_Access("Cantidad2"))
                    Query &= "," & Val(f_Access("Cantidad3"))
                    Query &= "," & Val(f_Access("CenCosto"))
                    Query &= "," & Val(f_Access("Comprador"))
                    Query &= "," & Val(f_Access("Costo1"))
                    Query &= "," & Val(f_Access("Costo2"))
                    Query &= "," & Val(f_Access("Costo3"))

                    Query &= "," & Val(f_Access("Descuento1"))
                    Query &= "," & Val(f_Access("Descuento2"))
                    Query &= "," & Val(f_Access("Descuento3"))
                    Query &= "," & Pone_Apos(AString(f_Access("Estatus")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Requiere")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Solicitud")))
                    Query &= "," & Pone_Apos(AString(AString(f_Access("Fecha1"))))
                    Query &= "," & Pone_Apos(AString(AString(f_Access("Fecha2"))))
                    Query &= "," & Pone_Apos(AString(AString(f_Access("Fecha3"))))
                    Query &= "," & Val(f_Access("Linea"))
                    Query &= "," & Val(f_Access("Marca"))

                    Query &= "," & Val(f_Access("Moneda1"))
                    Query &= "," & Val(f_Access("Moneda2"))
                    Query &= "," & Val(f_Access("Moneda3"))
                    Query &= "," & Pone_Apos(AString(f_Access("Observacion")))
                    Query &= "," & Val(f_Access("Precio1"))
                    Query &= "," & Val(f_Access("Precio2"))
                    Query &= "," & Val(f_Access("Precio3"))
                    Query &= "," & Val(f_Access("Proveedor1"))
                    Query &= "," & Val(f_Access("Proveedor2"))
                    Query &= "," & Val(f_Access("Proveedor3"))
                    Query &= "," & Val(f_Access("Solicitante"))
                    Query &= "," & Val(f_Access("Tipo"))

                    Query &= "," & Val(f_Access("Tipo_Cambio1"))
                    Query &= "," & Val(f_Access("Tipo_Cambio2"))
                    Query &= "," & Val(f_Access("Tipo_Cambio3"))
                    Query &= "," & Pone_Apos(AString(f_Access("Unidad_Medida")))
                    If Val(f_Access("Urgente")) = 0 Then
                        Query &= "," & Pone_Apos("false")
                    Else
                        Query &= "," & Pone_Apos("true")
                    End If
                    Query &= "," & Pone_Apos(f_Access("Economico"))
                    Query &= "," & Pone_Apos(AString(f_Access("Catalogo")))
                    Query &= "," & Pone_Apos(AString(f_Access("Figura")))
                    Query &= "," & Pone_Apos(AString(f_Access("Pagina")))
                    Query &= "," & Val(f_Access("Precio_Concurso"))

                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Recepcion")))
                    Query &= "," & Pone_Apos(AString(f_Access("Lugar_Entrega")))
                    Query &= "," & Pone_Apos(AString(f_Access("Libera_Almacen")))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Libera_Almacen")))
                    If IsDBNull(f_Access("Libero_Almacen")) Then
                        Query &= "," & Pone_Apos("N")
                    Else
                        Query &= "," & Pone_Apos("S")
                    End If
                    If IsDBNull(f_Access("Flete1")) Then Query &= "," & 0 Else Query &= "," & Val(f_Access("Flete1"))
                    If IsDBNull(f_Access("Flete2")) Then Query &= "," & 0 Else Query &= "," & Val(f_Access("Flete2"))
                    If IsDBNull(f_Access("Flete3")) Then Query &= "," & 0 Else Query &= "," & Val(f_Access("Flete3"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 200 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next

                    If Iguales = False Then
                        If Total_Registros = 23556 Then
                            Msg_Error("Llego")
                        End If
                        Query &= " Update Requisicion set"
                        Query &= " Almacen=" & Val(f_Access("Almacen"))
                        Query &= ",Art_Descripcion=" & Pone_Apos(AString(Elimina_comilla(f_Access("Art_Descripcion"))))
                        If Val(f_Access("Asignado1")) = 0 Then
                            Query &= ",Asignado1=" & Pone_Apos("false")
                        Else
                            Query &= ",Asignado1=" & Pone_Apos("true")
                        End If
                        If Val(f_Access("Asignado2")) = 0 Then
                            Query &= ",Asignado2=" & Pone_Apos("false")
                        Else
                            Query &= ",Asignado2=" & Pone_Apos("true")
                        End If
                        If Val(f_Access("Asignado3")) = 0 Then
                            Query &= ",Asignado3=" & Pone_Apos("false")
                        Else
                            Query &= ",Asignado3=" & Pone_Apos("true")
                        End If

                        Query &= ",Cantidad=" & Val(f_Access("Cantidad"))
                        Query &= ",Cantidad_Recibida=" & Val(f_Access("Cantidad_Recibida"))
                        Query &= ",Cantidad1=" & Val(f_Access("Cantidad1"))
                        Query &= ",Cantidad2=" & Val(f_Access("Cantidad2"))
                        Query &= ",Cantidad3=" & Val(f_Access("Cantidad3"))
                        Query &= ",CenCosto=" & Val(f_Access("CenCosto"))
                        Query &= ",Comprador=" & Val(f_Access("Comprador"))
                        Query &= ",Costo1=" & Val(f_Access("Costo1"))
                        Query &= ",Costo2=" & Val(f_Access("Costo2"))
                        Query &= ",Costo3=" & Val(f_Access("Costo3"))

                        Query &= ",Descuento1=" & Val(f_Access("Descuento1"))
                        Query &= ",Descuento2=" & Val(f_Access("Descuento2"))
                        Query &= ",Descuento3=" & Val(f_Access("Descuento3"))
                        Query &= ",Estatus=" & Pone_Apos(AString(f_Access("Estatus")))
                        Query &= ",Fecha_Requiere=" & Pone_Apos(AString(f_Access("Fecha_Requiere")))
                        Query &= ",Fecha_Solicitud=" & Pone_Apos(AString(f_Access("Fecha_Solicitud")))
                        Query &= ",Fecha1=" & Pone_Apos(AString(f_Access("Fecha1")))
                        Query &= ",Fecha2=" & Pone_Apos(AString(f_Access("Fecha2")))
                        Query &= ",Fecha3=" & Pone_Apos(AString(f_Access("Fecha3")))
                        Query &= ",Linea=" & Val(f_Access("Linea"))
                        Query &= ",Marca=" & Val(f_Access("Marca"))

                        Query &= ",Moneda1=" & Val(f_Access("Moneda1"))
                        Query &= ",Moneda2=" & Val(f_Access("Moneda2"))
                        Query &= ",Moneda3=" & Val(f_Access("Moneda3"))
                        Query &= ",Observacion=" & Pone_Apos(AString(f_Access("Observacion")))
                        Query &= ",Precio1=" & Val(f_Access("Precio1"))
                        Query &= ",Precio2=" & Val(f_Access("Precio2"))
                        Query &= ",Precio3=" & Val(f_Access("Precio3"))
                        Query &= ",Proveedor1=" & Val(f_Access("Proveedor1"))
                        Query &= ",Proveedor2=" & Val(f_Access("Proveedor2"))
                        Query &= ",Proveedor3=" & Val(f_Access("Proveedor3"))
                        Query &= ",Solicitante=" & Val(f_Access("Solicitante"))
                        Query &= ",Tipo=" & Val(f_Access("Tipo"))

                        Query &= ",Tipo_Cambio1=" & Val(f_Access("Tipo_Cambio1"))
                        Query &= ",Tipo_Cambio2=" & Val(f_Access("Tipo_Cambio2"))
                        Query &= ",Tipo_Cambio3=" & Val(f_Access("Tipo_Cambio3"))
                        Query &= ",Unidad_Medida=" & Pone_Apos(AString(f_Access("Unidad_Medida")))
                        If Val(f_Access("Urgente")) = 0 Then
                            Query &= ",Urgente=" & Pone_Apos("false")
                        Else
                            Query &= ",Urgente=" & Pone_Apos("true")
                        End If
                        Query &= ",Economico=" & Pone_Apos(AString(f_Access("Economico")))
                        Query &= ",Catalogo=" & Pone_Apos(AString(f_Access("Catalogo")))
                        Query &= ",Figura=" & Pone_Apos(AString(f_Access("Figura")))
                        Query &= ",Pagina=" & Pone_Apos(AString(f_Access("Pagina")))
                        Query &= ",Precio_Concurso=" & Val(f_Access("Precio_Concurso"))

                        Query &= ",Fecha_Recepcion=" & Pone_Apos(AString(f_Access("Fecha_Recepcion")))
                        Query &= ",Lugar_Entrega=" & Pone_Apos(AString(f_Access("Lugar_Entrega")))
                        Query &= ",Libera_Almacen=" & Pone_Apos(AString(f_Access("Libera_Almacen")))
                        Query &= ",Fecha_Libera_Almacen=" & Pone_Apos(AString(f_Access("Fecha_Libera_Almacen")))
                        If IsDBNull(f_Access("Libero_Almacen")) Then
                            Query &= ",Libero_Almacen=" & Pone_Apos("N")
                        Else
                            Query &= ",Libero_Almacen=" & Pone_Apos("S")
                        End If
                        Query &= ",Flete1=" & Val(f_Access("Flete1"))
                        Query &= ",Flete2=" & Val(f_Access("Flete2"))
                        Query &= ",flete3=" & Val(f_Access("Flete3"))
                        Query &= " where Requisicion=" & Val(f_Access("Requisicion"))
                        Query &= " and Art_Numero=" & Pone_Apos(f_Access("Art_Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 200 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString & " " & Total_Registros)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Tipo_Cambio()
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Tipo_Cambio  Where Baja<>'*'  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Mon_Numero"), dt_Sql.Columns("Fecha")}

            ''''Tabla de Access
            G.Tsql = "Select * from Tipo_Cambio  Where Baja<>'*'"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Mon_Numero")), f_Access("Fecha")})

                If f_Sql Is Nothing Then
                    Query &= " Insert into Tipo_Cambio(Mon_Numero,Fecha,Cambio,Cambio_Compras,Fecha_Cambio,Baja) values("
                    Query &= Val(f_Access("Mon_Numero"))
                    Query &= "," & Pone_Apos(f_Access("Fecha"))
                    Query &= "," & Val(f_Access("Cambio"))
                    Query &= "," & Val(f_Access("Cambio_Compras"))
                    Query &= "," & Pone_Apos(f_Access("Fecha_Cambio"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Tipo_Cambio set"
                        Query &= " Cambio=" & Val(f_Access("Cambio"))
                        Query &= ",Cambio_Compras=" & Val(f_Access("Cambio_Compras"))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(f_Access("Fecha_Cambio"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Mon_Numero=" & Val(f_Access("Mon_Numero"))
                        Query &= " and Fecha=" & Pone_Apos(Pone_Apos("Fecha")) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub
    Private Sub Terceros()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Terceros Where Baja<>'*'   and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Tercero"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Terceros Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Terceros(Cia,Obra,Tercero,Descripcion,RFC,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(f_Access("RFC"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("BAJA"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Query = ""
                    Tw_Ren = 0
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Terceros set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",RFC=" & Pone_Apos(f_Access("RFC"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Tercero =" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Query = ""
                        Tw_Ren = 0
                    End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub
    Private Sub Referencia()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Referencia_Contable Where Baja<>'*'   and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Referencia_Contable"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Referencia_Contable Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Referencia")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Referencia_Contable(Cia,Obra,Referencia_Contable,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja) values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Referencia"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("BAJA"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Query = ""
                    Tw_Ren = 0
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Referencia_Contable set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Referencia_Contable =" & Val(f_Access("Referencia"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Query = ""
                        Tw_Ren = 0
                    End If
                End If
            Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub
    Private Sub Sub_Linea()
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Sub_Linea Where Baja<>'*'"
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Lin_Numero"), dt_Sql.Columns("Numero")}

            ''''Tabla de Access
            G.Tsql = "Select * from Sub_Linea Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Lin_Numero")), Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Sub_Linea(Lin_Numero,Numero,Descripcion,Baja,Fecha_Cambio) values("
                    Query &= Val(f_Access("Lin_Numero"))
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(f_Access("Descripcion"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 200 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Sub_Linea set"
                        Query &= " Descripcion=" & Pone_Apos(f_Access("Descripcion"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= " Where Lin_Numero=" & Val(f_Access("Lin_Numero"))
                        Query &= " and Numero=" & Val(f_Access("Numero")) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 200 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Solicitantes()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Solicitante  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text) & "  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Solicitante"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Solicitante  Where Baja<>'*'"
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Solicitante(Cia,Obra,Solicitante,Nombre,RFC,Cve_Seg,Fecha_Seg,Hora_Seg,Baja"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(AString(f_Access("Nombre")))
                    Query &= "," & Pone_Apos(AString(f_Access("RFC")))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Solicitante set"
                        Query &= " Nombre=" & Pone_Apos(AString(f_Access("Nombre")))
                        Query &= ",RFC=" & Pone_Apos(AString(f_Access("RFC")))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Solicitante=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Proveedor()
        ''If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Total_Registros As Integer = 0
        Try
            G.Tsql = "Select * from Proveedor Where Baja<>'*'  "
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero")}

            ''''Tabla de Access
            G.Tsql = "Select * from Proveedor Where Baja<>'*' "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Total_Registros = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                Total_Registros = Total_Registros - 1
                If IsDBNull(f_Access("Numero")) Then
                    Continue For
                End If
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero"))})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Proveedor(Numero,Atencion,Baja,Colonia,Comprador,Cond_Pago,CP"
                    Query &= ",Desc_1,Desc_2,Desc_3,Desc_4,Desc_5,Desc_6,Desc_7,DesEsp_1,DesEsp_2,DesEsp_3,DesEsp_4,DesEsp_5,DesEsp_6,DesEsp_7"
                    Query &= ",Direccion,Estado,FacEsp,Factor,Factor_Ajuste,Fax,Garantia,Mail,Niv_Cantid,Niv_Cumpli,Niv_Entre,Pais"
                    Query &= ",Pronto_Pago,Razon_Social,Rfc,Telefono_1,Telefono_2,Tiempo_Entrega,Tipo_Cambio,Transporte,Fecha_Cambio,Es_Corporativo"
                    Query &= ") values("
                    Query &= Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(AString("Atencion"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= "," & Pone_Apos(AString(f_Access("Colonia")))
                    Query &= "," & Val(f_Access("Comprador"))
                    Query &= "," & Val(f_Access("Cond_Pago"))
                    Query &= "," & Val(f_Access("CP"))

                    Query &= "," & Val(f_Access("Desc_1"))
                    Query &= "," & Val(f_Access("Desc_2"))
                    Query &= "," & Val(f_Access("Desc_3"))
                    Query &= "," & Val(f_Access("Desc_4"))
                    Query &= "," & Val(f_Access("Desc_5"))
                    Query &= "," & Val(f_Access("Desc_6"))
                    Query &= "," & Val(f_Access("Desc_7"))
                    Query &= "," & Val(f_Access("DesEsp_1"))
                    Query &= "," & Val(f_Access("DesEsp_2"))
                    Query &= "," & Val(f_Access("DesEsp_3"))
                    Query &= "," & Val(f_Access("DesEsp_4"))
                    Query &= "," & Val(f_Access("DesEsp_5"))
                    Query &= "," & Val(f_Access("DesEsp_6"))
                    Query &= "," & Val(f_Access("DesEsp_7"))

                    Query &= "," & Pone_Apos(AString(f_Access("Direccion")))
                    Query &= "," & Pone_Apos(AString(f_Access("Estado")))
                    Query &= "," & Val(f_Access("FacEsp"))
                    Query &= "," & Val(f_Access("Factor"))
                    Query &= "," & Val(f_Access("Factor_Ajuste"))
                    Query &= "," & Pone_Apos(AString(f_Access("Fax")))
                    Query &= "," & Pone_Apos(AString(f_Access("Garantia")))
                    Query &= "," & Pone_Apos(AString(f_Access("Mail")))
                    Query &= "," & Val(f_Access("Niv_Cantid"))
                    Query &= "," & Val(f_Access("Niv_Cumpli"))
                    Query &= "," & Val(f_Access("Niv_Entre"))
                    Query &= "," & Val(f_Access("Pais"))

                    Query &= "," & Val(f_Access("Pronto_Pago"))
                    Query &= "," & Pone_Apos(AString(f_Access("Razon_Social")))
                    Query &= "," & Pone_Apos(AString(f_Access("Rfc")))
                    Query &= "," & Pone_Apos(AString(f_Access("Telefono_1")))
                    Query &= "," & Pone_Apos(AString(f_Access("Telefono_2")))
                    Query &= "," & Val(f_Access("Tiempo_Entrega"))
                    Query &= "," & Val(f_Access("Tipo_Cambio"))
                    Query &= "," & Val(f_Access("Transporte"))
                    Query &= "," & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                    Query &= "," & Pone_Apos(AString(f_Access("Es_Corporativo")))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 200 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Proveedor set"
                        Query &= " Atencion=" & Pone_Apos(AString("Atencion"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= ",Colonia=" & Pone_Apos(AString(f_Access("Colonia")))
                        Query &= ",Comprador=" & Val(f_Access("Comprador"))
                        Query &= ",Cond_Pago=" & Val(f_Access("Cond_Pago"))
                        Query &= ",CP=" & Val(f_Access("CP"))

                        Query &= ",Desc_1=" & Val(f_Access("Desc_1"))
                        Query &= ",Desc_2=" & Val(f_Access("Desc_2"))
                        Query &= ",Desc_3=" & Val(f_Access("Desc_3"))
                        Query &= ",Desc_4=" & Val(f_Access("Desc_4"))
                        Query &= ",Desc_5=" & Val(f_Access("Desc_5"))
                        Query &= ",Desc_6=" & Val(f_Access("Desc_6"))
                        Query &= ",Desc_7=" & Val(f_Access("Desc_7"))
                        Query &= ",DesEsp_1=" & Val(f_Access("DesEsp_1"))
                        Query &= ",DesEsp_2=" & Val(f_Access("DesEsp_2"))
                        Query &= ",DesEsp_3=" & Val(f_Access("DesEsp_3"))
                        Query &= ",DesEsp_4=" & Val(f_Access("DesEsp_4"))
                        Query &= ",DesEsp_5=" & Val(f_Access("DesEsp_5"))
                        Query &= ",DesEsp_6=" & Val(f_Access("DesEsp_6"))
                        Query &= ",DesEsp_7=" & Val(f_Access("DesEsp_7"))

                        Query &= ",Direccion=" & Pone_Apos(AString(f_Access("Direccion")))
                        Query &= ",Estado=" & Pone_Apos(AString(f_Access("Estado")))
                        Query &= ",FacEsp=" & Val(f_Access("FacEsp"))
                        Query &= ",Factor=" & Val(f_Access("Factor"))
                        Query &= ",Factor_Ajuste=" & Val(f_Access("Factor_Ajuste"))
                        Query &= ",Fax=" & Pone_Apos(AString(f_Access("Fax")))
                        Query &= ",Garantia=" & Pone_Apos(AString(f_Access("Garantia")))
                        Query &= ",Mail=" & Pone_Apos(AString(f_Access("Mail")))
                        Query &= ",Niv_Cantid=" & Val(f_Access("Niv_Cantid"))
                        Query &= ",Niv_Cumpli=" & Val(f_Access("Niv_Cumpli"))
                        Query &= ",Niv_Entre=" & Val(f_Access("Niv_Entre"))
                        Query &= ",Pais=" & Val(f_Access("Pais"))

                        Query &= ",Pronto_Pago=" & Val(f_Access("Pronto_Pago"))
                        Query &= ",Razon_Social=" & Pone_Apos(AString(f_Access("Razon_Social")))
                        Query &= ",Rfc=" & Pone_Apos(AString(f_Access("Rfc")))
                        Query &= ",Telefono_1=" & Pone_Apos(AString(f_Access("Telefono_1")))
                        Query &= ",Telefono_2=" & Pone_Apos(AString(f_Access("Telefono_2")))
                        Query &= ",Tiempo_Entrega=" & Val(f_Access("Tiempo_Entrega"))
                        Query &= ",Tipo_Cambio=" & Val(f_Access("Tipo_Cambio"))
                        Query &= ",Transporte=" & Val(f_Access("Transporte"))
                        Query &= ",Fecha_Cambio=" & Pone_Apos(AString(f_Access("Fecha_Cambio")))
                        Query &= ",Es_Corporativo=" & Pone_Apos(AString(f_Access("Es_Corporativo")))
                        Query &= " where Numero=" & Val(f_Access("Numero")) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 200 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString & " " & Total_Registros)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Paises()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select * from Pais  Where Baja<>'*'  and Cia=" & Val(T_Compañia.Text)
            G.cn.Open()
            G.Olecn.Open()
            ''''Tabla Actual de SQL
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            dt_Sql.Load(G.dr)
            dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Numero"), dt_Sql.Columns("Cia"), dt_Sql.Columns("Obra")}

            ''''Tabla de Access
            G.Tsql = "Select * from Pais  Where Baja<>'*' and Cia=" & Val(T_Compañia.Text)
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            'dt_Articulos_Access.PrimaryKey = New DataColumn() {dt_Articulos_Access.Columns("Numero")}
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            Dim f_Sql As DataRow
            For Each f_Access As DataRow In dt_Access.Rows
                f_Sql = dt_Sql.Rows.Find(New Object() {Val(f_Access("Numero")), Val(T_Compañia.Text), T_Proyecto.Text})
                If f_Sql Is Nothing Then
                    Query &= " Insert into Pais(Cia,Numero,Descripcion,Cve_Seg,Fecha_Seg,Hora_Seg,Baja"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)                    
                    Query &= "," & Val(f_Access("Numero"))
                    Query &= "," & Pone_Apos(AString(f_Access("Descripcion")))
                    Query &= "," & Pone_Apos(Session("Contraseña"))
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
                    Query &= "," & Pone_Apos(f_Access("Baja"))
                    Query &= ")" & Chr(13)
                    Tw_Ren += 1
                    If Tw_Ren > 100 Then
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                        Query = ""
                        Tw_Ren = 0
                    End If
                Else
                    Dim Iguales As Boolean = True
                    For Tw_Count As Integer = 0 To f_Access.ItemArray.Length - 1
                        If f_Access.ItemArray(Tw_Count).ToString.Trim <> f_Sql.ItemArray(Tw_Count).ToString.Trim Then
                            Iguales = False
                            Exit For
                        End If
                    Next
                    If Iguales = False Then
                        Query &= " Update Pais set"
                        Query &= " Descripcion=" & Pone_Apos(AString(f_Access("Descripcion")))
                        Query &= ",Cve_Seg=" & Pone_Apos(Session("Contraseña"))
                        Query &= ",Fecha_Seg=" & Pone_Apos(Fecha_AMD(Now))
                        Query &= ",Hora_Seg=" & Pone_Apos(Format(Now, "HH:mm:ss"))
                        Query &= ",Baja=" & Pone_Apos(f_Access("Baja"))
                        Query &= " Where Numero=" & Val(f_Access("Numero"))
                        Query &= " and Cia=" & Val(T_Compañia.Text)
                        Query &= " and Obra=" & Pone_Apos(T_Proyecto.Text) & Chr(13)
                        Tw_Ren += 1
                        If Tw_Ren > 100 Then
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                            Query = ""
                            Tw_Ren = 0
                        End If
                    End If
                End If
            Next
            Total_Registros = Total_Registros
            If Query.Trim > "" Then
                G.com.CommandText = Query
                G.com.ExecuteNonQuery()
                Query = ""
                Tw_Ren = 0
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Private Sub Inventario_Inicial()
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenece el Inventario") : Exit Sub
        If Val(T_Almacen.Text.Trim) = 0 Then Msg_Error("Es Necesario Indicar el Almacen a Inventariar") : Exit Sub
        Dim Tw_Ren As Integer = 0
        Dim Tw_Registros As Integer = 0
        Dim Num_Reg As Integer = 0
        Dim Registro_Anterior As String = ""
        Dim Descripcion As String = ""

        Dim dt_Access As New DataTable
        Dim dt_Sql As New DataTable
        Dim Query As String = ""
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Numero_Secuencial As Integer = 0
        Dim Numero_Lote As Integer = 0
        Try
            'G.Tsql = "Select * from Movimientos_Entradas "
            G.cn.Open()
            G.Olecn.Open()
            ' ''''Tabla Actual de SQL
            'G.com.CommandText = G.Tsql
            'G.dr = G.com.ExecuteReader
            'dt_Sql.Load(G.dr)
            'dt_Sql.PrimaryKey = New DataColumn() {dt_Sql.Columns("Compania"), dt_Sql.Columns("Obra"), dt_Sql.Columns("Almacen"), dt_Sql.Columns("E_S"), dt_Sql.Columns("Lote"), dt_Sql.Columns("Partida")}

            ''''Tabla de Access
            'G.Tsql = "Select * from Articulos_Almacen"
            G.Tsql = "Select Articulo_Almacen.*, Articulos.Mar_Numero,Articulos.Unidad_Medida,Articulos.Art_Descripcion,Articulos.Sub_Numero from Articulo_Almacen  inner join Articulos  on Articulos.Numero=Articulo_Almacen.Art_Numero "
            '   G.Tsql = "Select a.*, b.Mar_Numero,b.Sub_Numero,b.Unidad_Medida,b.Art_Descripcion from Articulo_Almacen a inner join Articulos b on a.Numero=b.Art_Numero "
            G.Olecom.CommandText = G.Tsql
            G.Oledr = G.Olecom.ExecuteReader
            dt_Access.Load(G.Oledr)
            Dim Total_Registros As Integer = dt_Access.Rows.Count
            'Dim f_Sql As DataRow



            Numero_Lote = 1
            For Each f_Access As DataRow In dt_Access.Rows
                'Numero_Secuencial = Numero_Secuencial + 1

                '   For i = 0 To 1
                'Numero_Lote = Numero_Lote + 1
                If f_Access("Existencia_Inicial") <> 0 Then
                    Numero_Secuencial = Numero_Secuencial + 1
                    '                    f_Sql = dt_Sql.Rows.Find(New Object() {Val(T_Compañia.Text), T_Proyecto.Text, Val(T_Almacen.Text), "E", Numero_Lote, i})
                    '                    If f_Sql Is Nothing Then
                    If Numero_Secuencial = 1 Then
                        Query &= " Insert into Movimientos_Entradas(Compania,Obra,Movimiento,Almacen,E_S,Lote,Partida,Numero_Secuencial,Fecha_Lote"
                        Query &= ") values("
                        Query &= Val(T_Compañia.Text)
                        Query &= "," & Pone_Apos(T_Proyecto.Text)
                        Query &= ",3"
                        Query &= "," & Val(T_Almacen.Text)
                        Query &= ",'E'"
                        Query &= "," & Val(Numero_Lote)
                        Query &= ",0"
                        Query &= "," & Val(Numero_Secuencial)
                        Query &= "," & Pone_Apos(Fecha_AMD(Now))
                        Query &= ")" & Chr(13)
                        Try
                            G.com.CommandText = Query
                            G.com.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        Query = ""
                        Tw_Ren = 0

                    End If
                    Query &= " Insert into Movimientos_Entradas(Compania,Obra,Movimiento,Almacen,E_S,Lote,Partida,Numero_Secuencial,Fecha_Lote"
                    Query &= ",Articulo,Linea,Cantidad,Existencia,Valor_Inventario,Costo,Costo_Total,Precio_Unitario"
                    Query &= ",Descripcion,Marca,Sub_Linea,Unidad_Medida"
                    Query &= ") values("
                    Query &= Val(T_Compañia.Text)
                    Query &= "," & Pone_Apos(T_Proyecto.Text)
                    Query &= ",3"
                    Query &= "," & Val(T_Almacen.Text)
                    Query &= ",'E'"
                    Query &= "," & Val(Numero_Lote)
                    Query &= "," & Numero_Secuencial
                    Query &= "," & Val(Numero_Secuencial)
                    Query &= "," & Pone_Apos(Fecha_AMD(Now))
                    Query &= "," & Pone_Apos(f_Access("Art_Numero"))
                    Query &= "," & Val(f_Access("Linea"))
                    Query &= "," & Math.Round(Val(f_Access("Existencia_Inicial")), 4)
                    Query &= "," & Math.Round(Val(f_Access("Existencia_Inicial")), 4)
                    Query &= "," & Math.Round(Val(f_Access("Existencia_Inicial_Valuada")), 2)
                    Query &= "," & Math.Round(Val(f_Access("Existencia_Inicial_Valuada")), 2)
                    Query &= "," & Math.Round(Val(f_Access("Existencia_Inicial_Valuada")), 2)
                    Query &= "," & Math.Round(Val(f_Access("Costo_Promedio")), 4)
                    Query &= "," & Pone_Apos(AString(f_Access("Art_Descripcion")))
                    Query &= "," & Val(f_Access("Mar_Numero"))
                    Query &= "," & Val(f_Access("Sub_Numero"))
                    Query &= "," & Pone_Apos(AString(f_Access("Unidad_Medida")))
                    Query &= ")" & Chr(13)
                    Try
                        G.com.CommandText = Query
                        G.com.ExecuteNonQuery()
                    Catch ex As Exception
                    End Try
                    Query = ""
                    Tw_Ren = 0
                End If

            Next ''Terminacion For PAra hacer la partida 0 y la partida 1
            'Next
            Total_Registros = Total_Registros
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
            G.Olecn.Close()
        End Try
    End Sub

    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."

        Msg_Err.Visible = True
    End Sub

    Protected Sub Btn_Alta_Click(sender As Object, e As System.EventArgs) Handles Btn_Alta.Click
        T_Nombre_Archivo.Enabled = True
        GridView1.Enabled = False
        Pnl_Tablas.Enabled = False

        Btn_Alta.Enabled = False
        Btn_Alta.CssClass = "Btn_Rojo"
        Btn_Guarda0.Enabled = True
        Btn_Guarda0.CssClass = "Btn_Azul"
        Btn_Restaura.Enabled = True
        Btn_Restaura.CssClass = "Btn_Azul"
        Btn_Salir.Enabled = False
        Btn_Salir.CssClass = "Btn_Rojo"
        Btn_Migrar.Enabled = False
        Btn_Migrar.CssClass = "Btn_Rojo"

        Movimiento.Value = "Alta"
    End Sub

    Private Function Numero_Base() As Integer
        Numero_Base = 0
        Dim G As Glo = CType(Session("G"), Glo)
        G.com.CommandText = "Select Max(Numero) from Bases_Importa"
        Dim Num As Integer = 0
        If Not IsDBNull(G.com.ExecuteScalar) Then
            Num = Val(G.com.ExecuteScalar)
        Else
            Num = 0
        End If
        Numero_Base = Num
    End Function

    Protected Sub Btn_Guarda0_Click(sender As Object, e As System.EventArgs) Handles Btn_Guarda0.Click
        If Valida() = False Then Exit Sub
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            Dim Numero As Integer = Numero_Base() + 1
            If Movimiento.Value = "Alta" Then
                G.Tsql = "Insert into Bases_Importa(Numero,Nombre_Base,Ruta,Clave,Baja) values("
                G.Tsql &= Numero
                G.Tsql &= "," & Pone_Apos(T_Nombre_Archivo.Text)
                G.Tsql &= "," & Pone_Apos("C:\BD_Importa_Inventario\" & T_Nombre_Archivo.Text)
                G.Tsql &= ",'',''"
                G.Tsql &= ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                AñadeFilaGrid(Numero, T_Nombre_Archivo.Text, "C:\BD_Importa_Inventario\" & T_Nombre_Archivo.Text, "")
            End If
            If Movimiento.Value = "Cambio" Then
                G.Tsql = "Update Bases_Importa Set"
                G.Tsql &= " Nombre_Base=" & Pone_Apos(T_Nombre_Archivo.Text)
                G.Tsql &= ",Ruta=" & Pone_Apos("C:\BD_Importa_Inventario\" & T_Nombre_Archivo.Text)
                G.Tsql &= ",Baja=''"
                G.Tsql &= " Where Numero=" & Val(Base_Numero.Value)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                CambiaFilaGrid(T_Nombre_Archivo.Text)
            End If
            If Movimiento.Value = "Baja" Then
                G.Tsql = "Update Bases_Importa Set"
                'G.Tsql &= " Nombre_Base=" & Pone_Apos(T_Nombre_Archivo.Text)
                'G.Tsql &= ",Ruta=" & Pone_Apos("C:\BD_Importa_Inventario\" & T_Nombre_Archivo.Text)
                G.Tsql &= " Baja='*'"
                G.Tsql &= " Where Numero=" & Val(Base_Numero.Value)
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                EliminaFilaGrid()
            End If
            T_Nombre_Archivo.Text = ""
            Movimiento.Value = ""
            Btn_Restaura_Click(Nothing, Nothing)
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
        End Try
    End Sub

    Private Sub AñadeFilaGrid(ByVal Numero As String, ByVal Descripcion As String, ByVal ruta As String, ByVal Clave As String)
        Dim f As DataRow = Session("dt").NewRow()
        f("Numero") = Numero
        f("Nombre_Base") = Descripcion
        f("Ruta") = ruta
        f("Clave") = Clave
        Session("dt").Rows.Add(f)
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Private Sub CambiaFilaGrid(ByVal Nombre_Base As String)
        Dim clave(0) As String
        clave(0) = Val(Base_Numero.Value)
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f("Nombre_Base") = T_Nombre_Archivo.Text
            f("Ruta") = Archivo.Value
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Private Sub EliminaFilaGrid()
        Dim clave(0) As String
        clave(0) = Val(Base_Numero.Value)
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            f.Delete()
        End If
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
    End Sub

    Private Function Valida() As Boolean
        Valida = False
        Dim Extencion As String = ""
        Extencion = T_Nombre_Archivo.Text
        Extencion = Extencion.Substring(Extencion.LastIndexOf(".") + 1).ToLower()
        If Extencion = T_Nombre_Archivo.Text Then
            Msg_Error("El Nombre de Archivo Debe Contener Extención")
            Exit Function
        End If
        If UCase(Extencion) <> "MDB" Then ''Puediera marcar error si se tiene una extencion diferente de MDB(Access 2007)
            Msg_Error("El Nombre de Archivo Debe Tener Extención de Archivo de Base de Datos Access")
            Exit Function
        End If
        Dim Leng As Integer
        Dim T_Co As Integer = 0
        Dim Cant_Puntos As Integer = 0
        Leng = Len(T_Nombre_Archivo.Text)
        For T_Co = 1 To Leng
            If Mid(T_Nombre_Archivo.Text, T_Co, 1) = "/" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = "\" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = "*" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = ":" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = "?" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = "<" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = ">" Or
                Mid(T_Nombre_Archivo.Text, T_Co, 1) = Chr(34) Then
                Msg_Error("El Nombre de Archivo no Debe Contener los caractere \ / * : ? < >")
                Exit Function
            End If
        Next
        If T_Nombre_Archivo.Text = "" Then Msg_Error("Nombre de Base de Access Inválido") : Exit Function
        Valida = True
    End Function

    Private Sub Deshabilita()
        Btn_Migrar.Enabled = True
        Btn_Migrar.CssClass = "Btn_Azul"
        Btn_Restaura.Enabled = True
        Btn_Restaura.CssClass = "Btn_Azul"
        Btn_Guarda0.Enabled = False
        Btn_Guarda0.CssClass = "Btn_Rojo"
        Btn_Alta.Enabled = False
        Btn_Alta.CssClass = "Btn_Rojo"
        Btn_Salir.Enabled = False
        Btn_Salir.CssClass = "Btn_Rojo"
        GridView1.Enabled = False
        Pnl_Botones_Migrar.Visible = True
        Pnl_Tablas.Visible = False
       
        H_Compañia.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=COMPAÑIA',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Compañia.Attributes.Add("style", "cursor:pointer;")
        T_Compañia.Enabled = True
        T_Proyecto.Enabled = True
        H_Almacen.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=ALMACEN',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Almacen.Attributes.Add("style", "cursor:pointer;")
        T_Almacen.Enabled = True
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName.Equals("Baja")) Or (e.CommandName.Equals("Cambio")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                Base_Numero.Value = f("Numero")
                T_Nombre_Archivo.Text = f("Nombre_Base")
                Archivo.Value = f("Ruta")
                Base_Clave.Value = f("Clave")
                Deshabilita()
                Btn_Guarda0.Enabled = True
                Btn_Guarda0.CssClass = "Btn_Azul"
            End If
            If (e.CommandName.Equals("Baja")) Then
                Movimiento.Value = "Baja"
                H_Proyecto.Attributes.Add("style", "cursor:not-allowed;")
                H_Proyecto.Attributes.Add("onclick", "")
                T_Proyecto.Enabled = False
                H_Almacen.Attributes.Add("style", "cursor:not-allowed;")
                H_Almacen.Attributes.Add("onclick", "")
                H_Almacen.Enabled = False
                T_Nombre_Archivo.Enabled = False
                Pnl_Botones_Migrar.Visible = False
                Pnl_Tablas.Visible = False
            End If
            If (e.CommandName.Equals("Cambio")) Then
                Movimiento.Value = "Cambio"
                Pnl_Botones_Migrar.Visible = False
                Pnl_Tablas.Visible = False
                T_Nombre_Archivo.Enabled = True
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        'Btn_Migrar.Enabled = True
        'Btn_Migrar.CssClass = "Btn_Azul"
        'Btn_Restaura.Enabled = True
        'Btn_Restaura.CssClass = "Btn_Azul"
        'Btn_Guarda0.Enabled = False
        'Btn_Guarda0.CssClass = "Btn_Rojo"
        'Btn_Alta.Enabled = False
        'Btn_Alta.CssClass = "Btn_Rojo"
        'Btn_Salir.Enabled = False
        'Btn_Salir.CssClass = "Btn_Rojo"
        'GridView1.Enabled = False

        Dim clave(0) As String
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Numero").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            T_Nombre_Archivo.Text = f("Nombre_Base")
            Archivo.Value = f("Ruta")
        End If
        Conexion_Access()
        If Msg_Err.Text = " ..... No Existe el Archivo en la Ruta Especificada ....." Then
            Exit Sub
        End If
        Btn_Migrar.Enabled = False
        Btn_Migrar.CssClass = "Btn_Azul"
        Deshabilita()

    End Sub

    Protected Sub Btn_Restaura_Click(sender As Object, e As System.EventArgs) Handles Btn_Restaura.Click
        Btn_Migrar.Enabled = False
        Btn_Migrar.CssClass = "Btn_Rojo"
        Btn_Restaura.Enabled = False
        Btn_Restaura.CssClass = "Btn_Rojo"
        Btn_Guarda0.Enabled = False
        Btn_Guarda0.CssClass = "Btn_Rojo"
        Btn_Alta.Enabled = True
        Btn_Alta.CssClass = "Btn_Azul"
        Btn_Salir.Enabled = True
        Btn_Salir.CssClass = "Btn_Azul"
        GridView1.Enabled = True
        ''GridView1.Visible = True
        Pnl_Botones_Migrar.Visible = False
        Pnl_Tablas.Enabled = True
        Pnl_Tablas.Visible = True
        T_Proyecto.Enabled = False
        T_Almacen.Enabled = False
        T_Compañia.Enabled = False
        T_Nombre_Archivo.Enabled = False
        H_Proyecto.Attributes.Add("style", "cursor:not-allowed;")
        H_Proyecto.Attributes.Add("onclick", "")
        H_Almacen.Attributes.Add("style", "cursor:not-allowed;")
        H_Almacen.Attributes.Add("onclick", "")
        T_Almacen.Text = ""
        T_Almacen_Desc.Text = ""
        T_Nombre_Archivo.Text = ""
        T_Proyecto.Text = ""
        T_Proyecto_Desc.Text = ""
        Movimiento.Value = ""
        Base_Clave.Value = ""
        Base_Numero.Value = ""
    End Sub

    Protected Sub Btn_Migrar_Articulos_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Articulos.Click
        If Valida() = False Then Exit Sub
        Migra_Articulos()
    End Sub

    Protected Sub Btn_Migrar_Act_Area_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Act_Area.Click
        If Valida() = False Then Exit Sub
        Actividad_Area()
    End Sub

    Protected Sub T_Proyecto_TextChanged(sender As Object, e As System.EventArgs) Handles T_Proyecto.TextChanged
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select Descripcion from Obra where Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " and Cia=" & Pone_Apos(T_Compañia.Text)
            G.com.CommandText = G.Tsql
            Dim Descripcion As String = ""
            Descripcion = G.com.ExecuteScalar
            If IsDBNull(G.com.ExecuteScalar) Then
                T_Proyecto_Desc.Text = ""
                Msg_Error("Obra Inválida")
                Exit Sub
            Else
                T_Proyecto_Desc.Text = Descripcion
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Btn_Migrar_Act_Fte_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Act_Fte.Click
        If Valida() = False Then Exit Sub
        Actividad_Frente()
    End Sub

    Protected Sub Btn_Migrar_Aut_Ordenes_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Aut_Ordenes.Click
        If Valida() = False Then Exit Sub
        Autoriza_Orden_Compra()
    End Sub

    Protected Sub Btn_Migrar_Autoriza_Req_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Autoriza_Req.Click
        If Valida() = False Then Exit Sub
        Autoriza_Requisicion()
    End Sub

    Protected Sub Btn_Migrar_Auto_Claves_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Auto_Claves.Click
        If Valida() = False Then Exit Sub
        Autorizacion_Claves()
    End Sub

    Protected Sub Btn_Migrar_Cen_Cos_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Cen_Cos.Click
        If Valida() = False Then Exit Sub
        Centro_Costos()
    End Sub

    Protected Sub Btn_Migrar_Comprador_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Comprador.Click
        If Valida() = False Then Exit Sub
        Compradores()
    End Sub

    Protected Sub Btn_Migrar_Cond_Pago_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Cond_Pago.Click
        If Valida() = False Then Exit Sub
        Condicion_Pago()
    End Sub

    Protected Sub Btn_Migrar_Eco_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Eco.Click
        If Valida() = False Then Exit Sub
        Economico()
    End Sub

    Protected Sub Btn_Migrar_Eject_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Eject.Click
        If Valida() = False Then Exit Sub
        Ejecutivos()
    End Sub

    Protected Sub Btn_Migrar_Empl_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Empl.Click
        If Valida() = False Then Exit Sub
        Empleados()
    End Sub

    Protected Sub Btn_Migrar_Frente_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Frente.Click
        If Valida() = False Then Exit Sub
        Frente()
    End Sub

    Protected Sub Btn_Migrar_Gastos_19_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Gastos_19.Click
        If Valida() = False Then Exit Sub
        Gastos_19()
    End Sub

    Protected Sub Btn_Migrar_Linea_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Linea.Click
        If Valida() = False Then Exit Sub
        Linea()
    End Sub

    Protected Sub Btn_Migrar_Lug_Ent_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Lug_Ent.Click
        If Valida() = False Then Exit Sub
        Lugar_Entrega()
    End Sub

    Protected Sub Btn_Migrar_Marca_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Marca.Click
        If Valida() = False Then Exit Sub
        Marca()
    End Sub

    Protected Sub Btn_Migrar_Obra_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Obra.Click
        If Valida() = False Then Exit Sub
        Obra()
    End Sub

    Protected Sub Btn_Migrar_Ordenes_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Ordenes.Click
        If Valida() = False Then Exit Sub
        Ordenes_Compra()
    End Sub

    Protected Sub Btn_Migrar_Transporte_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Transporte.Click
        If Valida() = False Then Exit Sub
        Transporte()
    End Sub

    Protected Sub Btn_Migrar_Requisicion_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Requisicion.Click
        If Valida() = False Then Exit Sub
        Requisicion()
    End Sub

    Protected Sub Btn_Migrar_Tipo_Camb_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Tipo_Camb.Click
        If Valida() = False Then Exit Sub
        Tipo_Cambio()
    End Sub

    Protected Sub Btn_Migrar_Sublinea_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Sublinea.Click
        If Valida() = False Then Exit Sub
        Sub_Linea()
    End Sub

    Protected Sub Btn_Migrar_Solicitante_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Solicitante.Click
        If Valida() = False Then Exit Sub
        Solicitantes()
    End Sub

    Protected Sub Btn_Migrar_Proveedor_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Proveedor.Click
        If Valida() = False Then Exit Sub
        Proveedor()
    End Sub

    Protected Sub Btn_Migrar_Pais_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Pais.Click
        If Valida() = False Then Exit Sub
        Paises()
    End Sub

    Protected Sub Btn_Migrar_Inventario_Inicial_Click(sender As Object, e As System.EventArgs) Handles Btn_Migrar_Inventario_Inicial.Click
        If Valida() = False Then Exit Sub
        Inventario_Inicial()
    End Sub

    Protected Sub Btn_Responsable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Responsable.Click
        If Valida() = False Then Exit Sub
        Responsable()
    End Sub

    Protected Sub Btn_Borrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Borrar.Click
        Borrar_Registros_Importa()
    End Sub

    Private Sub Borrar_Registros_Importa()
        If Valida() = False Then Exit Sub
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto del que Desea Eliminar Los Registros") : Exit Sub
        If Val(T_Almacen.Text.Trim) = 0 Then Msg_Error("Es Necesario Indicar el Almacen del que Desea Eliminar Los Registros") : Exit Sub
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            '''' TABLAS SIN LLAVE COMPAÑIA Y OBRA
            G.Tsql &= " Delete From Ejecutivo  Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Empleados  Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            '  G.Tsql &= " Delete From Gasto_19"
            '  G.Tsql &= " Delete From Gasto"
            '  G.Tsql &= " Delete From Proveedor"
            '  G.Tsql &= " Delete From Sub_Linea "
            'G.Tsql &= " Delete From Tipo_Cambio"

            G.Tsql &= " Delete From Articulos  Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Economico  Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Actividad_Area Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Actividad_Frente Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Autoriza_Orden_Compra"
            G.Tsql &= " Delete From Autoriza_Requisicion Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Autorizacion_Claves Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Centro_Costos Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Comprador Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Condicion_Pago Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Frente Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Linea Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Lugar_Entrega Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Marca Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Pais Where Cia=" & Val(T_Compañia.Text)
            G.Tsql &= " Delete From Requisicion Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Ordenes_Compra Where Numero_Compañia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Responsable Where Numero_Compañia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Transporte Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Movimientos_Inventario Where Compania=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Solicitante Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Area Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)
            G.Tsql &= " Delete From Concepto_Costo Where Cia=" & Val(T_Compañia.Text) & " and Obra=" & Pone_Apos(T_Proyecto.Text)

            G.com.CommandText = G.Tsql
            G.com.ExecuteNonQuery()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Btn_Importar_Todo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Importar_Todo.Click
        Importar_Todo()
    End Sub

    Private Sub Importar_Todo()
        If Valida() = False Then Exit Sub
        If T_Proyecto.Text.Trim = "" Then Msg_Error("Es Necesario Indicar el Proyecto al que Pertenecerán los Datos Migrados") : Exit Sub
        If Val(T_Almacen.Text.Trim) = 0 Then Msg_Error("Es Necesario Indicar el Almacen a Inventariar") : Exit Sub
        Try
            Migra_Articulos()
            Actividad_Area()
            Actividad_Frente()
            Autoriza_Orden_Compra()
            Autoriza_Requisicion()
            Autorizacion_Claves()
            Centro_Costos()
            Compradores()
            Condicion_Pago()
            Economico()
            Ejecutivos()
            Empleados()
            Frente()
            Gastos_19()
            Inventario_Inicial()
            Linea()
            Lugar_Entrega()
            Marca()
            Ordenes_Compra()
            Paises()
            Proveedor()
            Requisicion()
            Responsable()
            Solicitantes()
            Sub_Linea()
            Tipo_Cambio()
            Transporte()
            Concepto_Costo()
            Gastos()
            Area()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
            Exit Sub
        End Try
    End Sub

    Protected Sub Btn_Area_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Area.Click
        If Valida() = False Then Exit Sub
        Area()
    End Sub

    Protected Sub Btn_Gastos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Gastos.Click
        If Valida() = False Then Exit Sub
        Gastos()
    End Sub

    Protected Sub Btn_Concepto_Costo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Concepto_Costo.Click
        If Valida() = False Then Exit Sub
        Concepto_Costo()
    End Sub

    Protected Sub Btn_Terceros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Terceros.Click
        If Valida() = False Then Exit Sub
        Terceros()
    End Sub

    Protected Sub Btn_Referencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Referencia.Click
        If Valida() = False Then Exit Sub
        Referencia()
    End Sub

   
    Protected Sub T_Compañia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Compañia.TextChanged
        H_Proyecto.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=OBRA3&Cia=" & Val(T_Compañia.Text) & "',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Proyecto.Attributes.Add("style", "cursor:pointer;")
    End Sub
End Class
