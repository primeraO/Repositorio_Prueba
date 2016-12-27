Imports System.Data

Partial Class Bus_Cat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then
            G.dt2 = New DataTable
            CrearCamposTabla()
            LlenaGrid()
            GridView1.DataSource = G.dt2
            GridView1.DataBind()
            Cabecera.DataSource = New List(Of String)
            Cabecera.DataBind()
        End If
        T_Numero.Attributes.Add("onfocus", "this.select();")
        T_Descipcion.Attributes.Add("onfocus", "this.select();")

        DibujaSpan()
    End Sub
    Private Sub DibujaSpan()
        Dim G As Glo = CType(Session("G"), Glo)
        Dim dtspan As New DataTable
        dtspan = G.dt2.Copy
        If G.dt2.Rows.Count = 0 Then
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
    Private Sub CrearCamposTabla()
        Dim Catalogo As String = Request.QueryString("Catalogo")
        Dim Cia As String = Request.QueryString("Cia")

        Dim G As Glo = CType(Session("G"), Glo)
        G.Elemento = Request.QueryString("Elemento")
        Select Case Catalogo
            Case "RESPONSABLE"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Nombre"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "LINEA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Grupo"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)

                'G.dt2.Columns.Add("Aplicacion", Type.GetType("System.String")) : G.dt2.Columns("Aplicacion").DefaultValue = ""
                'Dim col As New BoundField
                'col.HeaderText = "Aplicación"
                'col.DataField = "Aplicacion"
                'GridView1.Columns.Add(col)
                'Cabecera.Columns.Add(col1)

            Case "OBRA", "OBRA3"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "AREA", "AREA_SALIDA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "FRENTE", "FRENTE_SALIDA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "SOLICITANTE", "SOLICITANTE_SALIDA", "AUTORIZA1", "AUTORIZA2", "AUTORIZA3", "AUTORIZA4", "REQ_SOLICITANTE"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Nombre"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "ARTICULO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Articulo Descripción"
                col1.DataField = "Descripcion"
                ' col1.HeaderStyle.HorizontalAlign = HorizontalAlign.Left                
                col1.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
                Dim col2 As New BoundField
                G.dt2.Columns.Add("Precio_Unitario", Type.GetType("System.Double")) : G.dt2.Columns("Precio_Unitario").DefaultValue = 0
                col2.HeaderText = "Precio Unitario"
                col2.DataField = "Precio_Unitario"
                col2.DataFormatString = "{0:N2}"
                GridView1.Columns.Add(col2)
                Cabecera.Columns.Add(col2)
            Case "TIPO_SALIDA", "TIPO_SALIDA_2"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                G.dt2.Columns.Add("Catalogo", Type.GetType("System.Int16")) : G.dt2.Columns("Catalogo").DefaultValue = 0
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
                Dim col2 As New BoundField
                col2.HeaderText = "Catalogo"
                col2.DataField = "Catalogo"
                GridView1.Columns.Add(col2)
                Cabecera.Columns.Add(col2)
            Case "REFERENCIA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Nombre"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "OBRA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "PROVEEDOR"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Razon_Social"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "TERCERO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "ECONOMICO_SALIDA", "ECONOMICO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "CONCEPTO_COSTO_SALIDA", "GASTO", "GASTO_19"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "LINEA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Grupo"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "MARCA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "SUB_LINEA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "AREA_ACTIVIDAD", "FRENTE_ACTIVIDAD", "ECONOMICO_ACTIVIDAD"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Concepto"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
                Dim col2 As New BoundField
            Case "ALMACEN", "ALMACEN2", "CLAVE_MOVIMIENTOS_INVENTARIO", "ALMACEN", "MONEDA", "CENTRO_COSTOS", "ALMACEN_DESTINO", "EMPLEADOS", "LUGAR_ENTREGA", "CLAVE_MOVIMIENTOS_INVENTARIO_ENTRADAS"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripción"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "COND_PAGO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "PAIS"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "COMPRADOR"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Nombre"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "TRANSPORTE"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int16")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "RESGUARDO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Articulo", GetType(System.String)) : G.dt2.Columns("Articulo").DefaultValue = ""
                G.dt2.Columns.Add("Descripcion", GetType(System.String)) : G.dt2.Columns("Descripcion").DefaultValue = ""
                G.dt2.Columns.Add("Serie", GetType(System.String)) : G.dt2.Columns("Serie").DefaultValue = ""
                Crea_Columna_Grid("Articulo", "Artículo")
                Crea_Columna_Grid("Descripcion", "Descripción")
                Crea_Columna_Grid("Serie", "Serie")
            Case "ORDENES_COMPRA", "ORDENES_COMPRA_NS"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Proveedor", Type.GetType("System.Int64")) : G.dt2.Columns("Proveedor").DefaultValue = 0
                G.dt2.Columns.Add("Proveedor_Desc", Type.GetType("System.String")) : G.dt2.Columns("Proveedor_Desc").DefaultValue = ""
                Crea_Columna_Grid("Proveedor", "Núm Proveedor")
                Crea_Columna_Grid("Proveedor_Desc", "Proveedor")
            Case "REQ_COSTOS", "REQ_SOLICITANTE", "REQ_ECONOMICO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripción"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)

            Case "CVE_MOVIMIENTO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripción"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)
            Case "USUARIO"
                G.dt2.Columns.Add("Numero", Type.GetType("System.String")) : G.dt2.Columns("Numero").DefaultValue = ""
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                G.dt2.Columns.Add("Usuario", Type.GetType("System.String")) : G.dt2.Columns("Usuario").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)

            Case "COMPAÑIA"
                G.dt2.Columns.Add("Numero", Type.GetType("System.Int64")) : G.dt2.Columns("Numero").DefaultValue = 0
                G.dt2.Columns.Add("Descripcion", Type.GetType("System.String")) : G.dt2.Columns("Descripcion").DefaultValue = ""
                G.dt2.Columns.Add("Usuario", Type.GetType("System.String")) : G.dt2.Columns("Usuario").DefaultValue = ""
                Dim col1 As New BoundField
                col1.HeaderText = "Descripcion"
                col1.DataField = "Descripcion"
                GridView1.Columns.Add(col1)
                Cabecera.Columns.Add(col1)

        End Select
        Dim Tipo_Dato As String = ""
        For Each c As DataColumn In G.dt2.Columns
            If c.ColumnName = "Numero" Then
                Tipo_Dato = c.DataType.ToString
                Exit For
            End If
        Next

        If Tipo_Dato = "System.String" Then
            GridView1.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Left
        Else
            GridView1.Columns(1).ItemStyle.HorizontalAlign = HorizontalAlign.Right
        End If

        Dim clave(0) As DataColumn
        clave(0) = G.dt2.Columns("Numero")
        G.dt2.PrimaryKey = clave
    End Sub


    Private Sub LlenaGrid()
        Dim Catalogo As String = Request.QueryString("Catalogo")
        Dim Cia As String = Request.QueryString("Cia")
        Dim Elemento As String = Request.QueryString("Elemento")
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.dt2.Rows.Clear()
            Select Case Catalogo
                Case "COMPAÑIA"
                    G.Tsql = "Select TOP(200) Cia as Numero,Razon_Social as Descripcion"
                    G.Tsql &= " from Compañias"
                    'G.Tsql &= " and Obra=" & Val(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= Es_Where(G.Tsql)
                        G.Tsql &= " and Cia=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= Es_Where(G.Tsql)
                        G.Tsql &= " and Razon_Social like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "RESPONSABLE"
                    G.Tsql = "Select TOP(200) Responsable as Numero,Nombre as Descripcion"
                    G.Tsql &= " from Responsable Where Numero_Compañia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Val(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Responsable=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Nombre like '%" & T_Descipcion.Text & "%'"
                    End If

                Case "EMPLEADOS"
                    G.Tsql = "Select TOP(200) Numero,Nombre as Descripcion "
                    G.Tsql &= "from Empleados "
                    G.Tsql &= "Where Numero>0  and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal)
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Nombre like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "LINEA"
                    G.Tsql = "Select TOP(200) Numero, Descripcion, Aplicacion"
                    G.Tsql &= " from Linea Where Empresa=" & Val(G.Empresa_Numero)
                    G.Tsql &= " and Sucursal=" & Val(G.Sucursal)
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If

                Case "OBRA", "OBRA2"
                    G.Tsql = "Select TOP(200) Obra as Numero,Descripcion"
                    G.Tsql &= " from Obra Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Obra like '%" & T_Numero.Text.Trim & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"
                Case "OBRA3"
                    G.Tsql = "Select TOP(200) Num_Sucursal as Numero,Descripcion"
                    G.Tsql &= " from Sucursal Where Num_Compañia=" & Cia
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Num_Sucursal like '%" & T_Numero.Text.Trim & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    'G.Tsql &= " and Baja<>'*'"

                Case "AREA", "AREA_SALIDA"
                    G.Tsql = "Select TOP(200) Area as Numero, Descripcion"
                    G.Tsql &= " from Area Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Area=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "LUGAR_ENTREGA"
                    G.Tsql = "Select TOP(200) Numero,Descripcion From Lugar_Entrega where baja<>'*' "
                    If Val(T_Numero.Text.Trim) > 0 Then
                        G.Tsql += " and Numero = " + Me.T_Numero.Text
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql += " and Descripcion like '%" + T_Descipcion.Text + "%'"
                    End If
                    G.Tsql += " Order by Numero"

                Case "FRENTE", "FRENTE_SALIDA"
                    G.Tsql = "Select TOP(200) Frente as Numero, Descripcion"
                    G.Tsql &= " from Frente Where Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Frente=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If

                Case "SOLICITANTE", "SOLICITANTE_SALIDA"
                    G.Tsql = "Select TOP(200) Solicitante as Numero,Nombre As Descripcion"
                    G.Tsql &= " from Solicitante Where Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Baja<>'*'"
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Solicitante=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Nombre like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "ARTICULO"
                    G.Tsql = "Select Top 200 Numero,Art_Descripcion as Descripcion"
                    G.Tsql &= " from Articulos Where  baja<>'*' and Obra=" & Pone_Apos(G.Sucursal) & " and Cia=" & Val(Session("Cia"))

                    If T_Numero.Text.Trim > "" Then
                        G.Tsql &= " and Numero like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Art_Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " Order by Numero"
                Case "TIPO_SALIDA"
                    G.Tsql = "Select TOP(200) Tipo as Numero,Descripcion,Catalogo"
                    G.Tsql &= " from Tipo_Salida Where Baja<>'*'"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Tipo=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    If G.Elemento = "1322" Then
                        G.Tsql &= " and Tipo=13 Or Tipo=22"
                    End If
                Case "TIPO_SALIDA_2"
                    G.Tsql = "Select TOP(200) Tipo as Numero,Descripcion,Catalogo"
                    G.Tsql &= " from Tipo_Salida Where Baja<>'*' and Tipo<>16"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Tipo=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    If G.Elemento = "1322" Then
                        G.Tsql &= " and Tipo=13 Or Tipo=22"
                    End If
                Case "REFERENCIA"
                    G.Tsql = "Select TOP(200) Referencia_Contable as Numero,Descripcion"
                    G.Tsql &= " from Referencia_Contable Where Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Baja<>'*'"
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Referencia_Contable=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "OBRA"
                    G.Tsql = "Select TOP(200) Obra as Numero, Descripcion"
                    G.Tsql &= " from Obra Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Obra like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"
                Case "OBRA_SALIDA"
                    G.Tsql = "Select TOP(200) Obra as Numero, Descripcion"
                    G.Tsql &= " from Obra Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Obra like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"
                    '' '' ''Case "OBRA"
                    '' '' ''    G.Tsql = "Select Obra as Numero, Descripcion"
                    '' '' ''    G.Tsql &= " from Obra Where Cia=" & Val(Session("Cia"))
                    '' '' ''    If Val(T_Numero.Text) > 0 Then
                    '' '' ''        G.Tsql &= " and Obra like '%" & T_Numero.Text.Trim & "%'"
                    '' '' ''    End If
                    '' '' ''    If T_Descipcion.Text.Trim <> "" Then
                    '' '' ''        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    '' '' ''    End If
                    '' '' ''    G.Tsql &= " and Baja<>'*'"
                Case "PROVEEDOR"
                    G.Tsql = "Select TOP(200) Numero,Razon_Social as Descripcion"
                    G.Tsql &= " from Proveedor Where Baja<>'*'"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Razon_Social like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "TERCERO"
                    G.Tsql = "Select TOP(200) Tercero as Numero,Descripcion"
                    G.Tsql &= " from Terceros Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Tercero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                Case "ECONOMICO_SALIDA", "REQ_ECONOMICO"
                    G.Tsql = "Select TOP(200) Numero,Descripcion from Economico"
                    G.Tsql &= " Where Baja<>'*'"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                Case "CONCEPTO_COSTO_SALIDA"
                    G.Tsql = "Select TOP(200) Concepto as Numero,Descripcion from Concepto_Costo"
                    G.Tsql &= " from Concepto_Costo"
                    G.Tsql &= " Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Concepto=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                Case "AREA_ACTIVIDAD"
                    G.Tsql = "Select TOP(200) b.Actividad as Numero, b.Descripcion "
                    G.Tsql &= "from Area a left join Actividad_Area b "
                    G.Tsql &= "on a.Area=b.Area "
                    G.Tsql &= "Where b.Baja<>'*' "
                    G.Tsql &= "and b.Area=" & Val(G.Elemento)
                    G.Tsql &= " and b.Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and b.Obra=" & Pone_Apos(Session("Obra"))
                Case "FRENTE_ACTIVIDAD"
                    G.Tsql = "Select TOP(200) b.Actividad as Numero, b.Descripcion "
                    G.Tsql &= "from Frente a left join Actividad_Frente b "
                    G.Tsql &= "on a.Frente=b.Frente "
                    G.Tsql &= "Where b.Baja<>'*' "
                    G.Tsql &= "and b.Frente=" & Val(G.Elemento)
                    G.Tsql &= " and b.Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and b.Obra=" & Pone_Apos(Session("Obra"))
                Case "ECONOMICO_ACTIVIDAD"
                    G.Tsql = "Select TOP(200) Concepto as Numero, Descripcion "
                    G.Tsql &= "from Concepto_Costo "
                    G.Tsql &= "Where Baja<>'*' "
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                    If Val(T_Numero.Text) <> 0 Then
                        G.Tsql &= " and Concepto=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text.Trim & "%' "
                    End If
                Case "GASTO_19"
                    G.Tsql = "Select TOP(200) Gasto as Numero, Descripcion "
                    G.Tsql &= "from Gasto_19"
                    G.Tsql &= " Where Baja<>'*' "
                    If Val(T_Numero.Text) <> 0 Then
                        G.Tsql &= " and Gasto=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion=" & Pone_Apos(T_Descipcion.Text.Trim)
                    End If
                Case "GASTO"
                    G.Tsql = "Select TOP(200) Gasto as Numero, Descripcion "
                    G.Tsql &= "from Gasto "
                    G.Tsql &= "Where Baja<>'*'"
                    If Val(T_Numero.Text) <> 0 Then
                        G.Tsql &= " and Gasto=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text.Trim & "%' "
                    End If
                Case "CLAVE_MOVIMIENTOS_INVENTARIO"
                    G.Tsql = "Select TOP(200) Numero, Descripcion "
                    G.Tsql &= "from Clave_Movimiento_Inventario "
                    G.Tsql &= "Where Numero>0"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"


                Case "CLAVE_MOVIMIENTOS_INVENTARIO_ENTRADAS"
                    G.Tsql = "Select TOP(200) Numero, Descripcion "
                    G.Tsql &= "from Clave_Movimiento_Inventario "
                    G.Tsql &= "Where Numero>0 AND Entradas=1"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " and Baja<>'*'"
                Case "ALMACEN", "ALMACEN2", "ALMACEN_DESTINO"
                    G.Tsql = "Select TOP(200) Almacen as Numero, Descripcion "
                    G.Tsql &= "from Almacen "
                    G.Tsql &= "Where Cia=" & Session("Cia") & " and Obra=" & Pone_Apos(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Almacen=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "MONEDA"
                    G.Tsql = "Select TOP(200) Moneda as Numero, Descripcion "
                    G.Tsql &= "from Moneda "
                    G.Tsql &= "Where Moneda>=0"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Moneda=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "CENTRO_COSTOS", "REQ_COSTOS"
                    G.Tsql = "Select TOP(200) Centro_Costos as Numero, Descripcion "
                    G.Tsql &= "from Centro_Costos "
                    G.Tsql &= "Where Cia=" & Session("Cia") & " and Obra=" & Pone_Apos(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Centro_Costos=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "LINEA"
                    G.Tsql = "Select TOP(200)  Linea as Numero, Descripcion, Aplicacion"
                    G.Tsql &= " from Linea Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Linea=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "MARCA"
                    G.Tsql = "Select TOP(200)  Marca as Numero, Descripcion"
                    G.Tsql &= " from Marca Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Marca=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "SUB_LINEA"
                    G.Tsql = "Select TOP(200)  Numero, Descripcion"
                    G.Tsql &= " from Sub_Linea where Lin_Numero=" & Val(Session("Linea"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "COND_PAGO"
                    G.Tsql = "Select TOP(200) Condicion as Numero, Descripcion"
                    G.Tsql &= " from Condicion_Pago Where Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Val(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Condicion=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "PAIS"
                    G.Tsql = "Select TOP(200) Numero, Descripcion"
                    G.Tsql &= " from Pais Where Cia=" & Val(Session("Cia"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Numero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "COMPRADOR"
                    G.Tsql = "Select TOP(200)  Comprador as Numero,Nombre as Descripcion"
                    G.Tsql &= " from Comprador Where Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Val(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Comprador=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Nombre like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "TRANSPORTE"
                    G.Tsql = "Select TOP(200) Transporte as Numero,Descripcion"
                    G.Tsql &= " from Transporte Where Cia=" & Val(Session("Cia"))
                    G.Tsql &= " AND Obra=" & Val(Session("Obra"))
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and Transporte=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If

                Case "RESGUARDO"
                    G.Tsql = "Select TOP(200) Consecutivo as Numero,Articulo,Descripcion,Serie"
                    G.Tsql &= " from Resguardo "
                    G.Tsql &= " Where E_S=" & Pone_Apos(Request.QueryString("E_S"))
                    If T_Numero.Text.Trim <> "" Then
                        G.Tsql &= " and Articulo like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "ORDENES_COMPRA"
                    G.Tsql = "Select TOP(200) a.Numero_Orden as Numero,a.Proveedor,b.Razon_Social as Proveedor_Desc"
                    G.Tsql &= " from Ordenes_Compra a left join Proveedor b on a.Proveedor=b.Numero"
                    G.Tsql &= " Where a.Numero_Orden<>''"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and a.Numero_Orden like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and b.Razon_Social like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " Group by a.Numero_Orden,a.Proveedor,b.Razon_Social"
                Case "ORDENES_COMPRA_NS"
                    G.Tsql = "Select TOP(200) a.Numero_Orden as Numero,a.Proveedor,b.Razon_Social as Proveedor_Desc"
                    G.Tsql &= " from Ordenes_Compra a left join Proveedor b on a.Proveedor=b.Numero"
                    G.Tsql &= " Where a.Numero_Orden<>''"
                    G.Tsql &= " and Cantidad<>Cantidad_Recibida"
                    If Val(T_Numero.Text) > 0 Then
                        G.Tsql &= " and a.Numero_Orden like '%" & T_Numero.Text & "%'"
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and b.Razon_Social like '%" & T_Descipcion.Text & "%'"
                    End If
                    G.Tsql &= " Group by a.Numero_Orden,a.Proveedor,b.Razon_Social"
                Case "AUTORIZA1", "AUTORIZA2", "AUTORIZA3", "AUTORIZA4"
                    G.Tsql = "Select TOP(200)  Numero,Nombre as Descripcion From Autorizacion_Claves where baja<>'*' "
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                    If Val(T_Numero.Text.Trim) > 0 Then
                        G.Tsql &= " and Numero=" + Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and Nombre like '%" + T_Descipcion.Text + "%'"
                    End If
                    G.Tsql &= " Order by Numero"
                Case "CVE_MOVIMIENTO"
                    G.Tsql = "Select TOP(200) Numero,Descripcion from Clave_Movimiento_Inventario"
                    If Val(T_Numero.Text.Trim) > 0 Then
                        G.Tsql &= " where Numero=" & Val(T_Numero.Text)
                        If T_Descipcion.Text.Trim <> "" Then
                            G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text.Trim & "%'"
                        End If
                        G.Tsql &= " and Baja<>'*'"
                    Else
                        If T_Descipcion.Text.Trim <> "" Then
                            G.Tsql &= " where Descripcion like '%" & T_Descipcion.Text.Trim & "%'"
                            G.Tsql &= " and Baja<>'*'"
                        End If
                    End If
                    If T_Descipcion.Text.Trim = "" And Val(T_Numero.Text.Trim) = 0 Then
                        G.Tsql &= " where Baja<>'*'"
                    End If
                    G.Tsql &= " Order by Numero"
                Case "USUARIO"
                    G.Tsql = "Select TOP(200) UsuarioReal As Descripcion,UsuarioNumero as Numero,UsuarioNombre As Usuario"
                    G.Tsql &= " from Usuarios where Baja<>'*'"
                    If Val(T_Numero.Text) <> 0 Then
                        G.Tsql &= " and UsuarioNumero=" & Val(T_Numero.Text)
                    End If
                    If T_Descipcion.Text.Trim <> "" Then
                        G.Tsql &= " and UsuarioReal like '%" & T_Descipcion.Text & "%'"
                    End If
                Case "ECONOMICO"
                    G.Tsql = "Select TOP(200) Numero,Descripcion from Economico where Baja<>'*'"
                    If T_Numero.Text <> "" Then
                        G.Tsql &= " and Numero like '%" & T_Numero.Text & "%' "
                    End If
                    If T_Descipcion.Text <> "" Then
                        G.Tsql &= " and Descripcion like '%" & T_Descipcion.Text & "%' "
                    End If
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
            End Select
            ' Se llena el Datatable
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dt2.Load(G.dr)
            If G.dr.IsClosed = False Then G.dr.Close()
            If G.dt2.Rows.Count > 0 Then
                GridView1.DataSource = G.dt2
                GridView1.DataBind()
            Else
                DibujaSpan()
            End If
        Catch ex As Exception
            Mensaje(ex.ToString)
        Finally
            G.cn.Close()
        End Try
        GridView1.DataSource = G.dt2
        GridView1.DataBind()
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LlenaGrid()
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Hiper As ImageButton = CType(e.Row.FindControl("Seleccionar"), ImageButton)
            Dim Catalogo As String = Request.QueryString("Catalogo")
            Dim Numero As String = ""
            If Request.QueryString("Num") <> "" Then
                Numero = Request.QueryString("Num")
            End If
            Select Case Catalogo
                Case "COMPAÑIA"
                    Hiper.Attributes.Add("onclick", "javascript:Compañia(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")


                Case "RESPONSABLE"
                    Hiper.Attributes.Add("onclick", "javascript:Responsable(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                Case "AREA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Area(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Area2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                    End If
                Case "FRENTE"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Frente(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Frente2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                    End If
                    'Case "OBRA"
                    '    Hiper.Attributes.Add("onclick", "javascript:Obra(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "SOLICITANTE"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Solicitante(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Solicitante1(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    End If


                Case "TIPO_SALIDA", "TIPO_SALIDA_2"
                    Hiper.Attributes.Add("onclick", "javascript:TipoSalida(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "'," + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + ")")
                Case "REFERENCIA"
                    Hiper.Attributes.Add("onclick", "javascript:Salida_elemento(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Referencia')")
                Case "AREA_ACTIVIDAD"
                    Hiper.Attributes.Add("onclick", "javascript:Area_Actividad(" + "'" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "FRENTE_ACTIVIDAD"
                    Hiper.Attributes.Add("onclick", "javascript:Frente_Actividad(" + "'" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "ECONOMICO_ACTIVIDAD"
                    Hiper.Attributes.Add("onclick", "javascript:Economico_Actividad(" + "'" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "CLAVE_MOVIMIENTOS_INVENTARIO"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Clave_Movimientos_Inventario(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Clave_Movimientos_Inventario2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    End If
                Case "CLAVE_MOVIMIENTOS_INVENTARIO_ENTRADAS"
                    Hiper.Attributes.Add("onclick", "javascript:Clave_Movimientos_Inventario_Entradas(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                Case "ALMACEN"
                    Hiper.Attributes.Add("onclick", "javascript:Almacen(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "ALMACEN2"
                    Hiper.Attributes.Add("onclick", "javascript:Almacen2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    ''Case "MONEDA"
                    ''    Hiper.Attributes.Add("onclick", "javascript:Moneda(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "CENTRO_COSTOS"
                    Hiper.Attributes.Add("onclick", "javascript:Centro_Costos(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "ALMACEN_DESTINO"
                    Hiper.Attributes.Add("onclick", "javascript:Almacen_Destino(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "GASTO", "GASTO_19"
                    Hiper.Attributes.Add("onclick", "javascript:Salida_elemento(" + "'" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Clasificacion')")
                Case "EMPLEADOS"
                    Hiper.Attributes.Add("onclick", "javascript:Empleados(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    'Case "LINEA"
                    '    Hiper.Attributes.Add("onclick", "javascript:Linea(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "MARCA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Marca(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Marca1(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    End If
                Case "SUB_LINEA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Sub_Linea(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Sub_Linea2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    End If
                Case "COND_PAGO"
                    Hiper.Attributes.Add("onclick", "javascript:Cond_Pago(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "PAIS"
                    Hiper.Attributes.Add("onclick", "javascript:Pais(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "COMPRADOR"
                    Hiper.Attributes.Add("onclick", "javascript:Comprador(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "TRANSPORTE"
                    Hiper.Attributes.Add("onclick", "javascript:Transporte(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    'Case "OBRA2", "OBRA3"
                    '    Hiper.Attributes.Add("onclick", "javascript:Obra('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "OBRA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Obra('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Obra2('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                    End If
                Case "OBRA3"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Obra3('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:BObra3('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    End If
                Case "AREA_SALIDA", "PROVEEDOR_SALIDA", "TERCERO_SALIDA", "FRENTE_SALIDA", "SOLICITANTE_SALIDA", "CONCEPTO_COSTO_SALIDA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Salida_elemento(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Elemento')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Salida_elementos(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Elemento','" + Numero + "')")
                    End If

                Case "TERCERO"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Tercero(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Elemento')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Tercero2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Elemento')")

                    End If

                    'Case "OBRA_SALIDA"
                    '    Hiper.Attributes.Add("onclick", "javascript:Salida_elemento('" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Elemento')")
                Case "ECONOMICO_SALIDA", "OBRA_SALIDA"
                    Hiper.Attributes.Add("onclick", "javascript:Salida_elemento(" + "'" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','Elemento')")
                Case "RESGUARDO"
                    Hiper.Attributes.Add("onclick", "javascript:Resguardo('" + e.Row.Cells(1).Text + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(4).Text) + "')")
                Case "LUGAR_ENTREGA"
                    Hiper.Attributes.Add("onclick", "javascript:Lugar_Entrega(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "ORDENES_COMPRA"
                    Hiper.Attributes.Add("onclick", "javascript:Ordenes_Compra('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")
                Case "ORDENES_COMPRA_NS"
                    Hiper.Attributes.Add("onclick", "javascript:Ordenes_Compra_Ns('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")
                Case "AUTORIZA1"
                    Hiper.Attributes.Add("onclick", "javascript:Autoriza1(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "AUTORIZA2"
                    Hiper.Attributes.Add("onclick", "javascript:Autoriza2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "AUTORIZA3"
                    Hiper.Attributes.Add("onclick", "javascript:Autoriza3(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "AUTORIZA4"
                    Hiper.Attributes.Add("onclick", "javascript:Autoriza4(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                Case "PROVEEDOR"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Proveedor(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                    ElseIf Numero = 2 Then
                        Hiper.Attributes.Add("onclick", "javascript:Proveedor2(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + Numero + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Proveedores(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + Numero + "')")

                    End If
                Case "MONEDA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Moneda(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Monedas(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + Numero + "')")
                    End If
                Case "LUGAR_ENTREGA"
                    Hiper.Attributes.Add("onclick", "javascript:Lugar_Entrega(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "ARTICULO"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Articulo('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Articulos('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(3).Text) + "','" + Numero + "')")
                    End If
                Case "CVE_MOVIMIENTO"
                    Hiper.Attributes.Add("onclick", "javascript:Clave_Movimientos_Inventario(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "LINEA"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Linea(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Lineas(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "','" + Numero + "')")
                    End If
                Case "USUARIO"
                    Hiper.Attributes.Add("onclick", "javascript:Usuario(" + e.Row.Cells(1).Text + ",'" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                Case "ECONOMICO"
                    If Numero = "" Then
                        Hiper.Attributes.Add("onclick", "javascript:Economico('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")
                    Else
                        Hiper.Attributes.Add("onclick", "javascript:Economico2('" + HttpUtility.HtmlDecode(e.Row.Cells(1).Text) + "','" + HttpUtility.HtmlDecode(e.Row.Cells(2).Text) + "')")

                    End If

            End Select
        End If
    End Sub

    Private Sub Crea_Columna_Grid(ByVal Datafield As String, ByVal Header As String)
        Dim col As New BoundField
        col.DataField = Datafield
        col.HeaderText = Header
        GridView1.Columns.Add(col)
        Cabecera.Columns.Add(col)

    End Sub

    Protected Sub Ima_Busca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ima_Busca.Click
        LlenaGrid()
    End Sub
End Class

