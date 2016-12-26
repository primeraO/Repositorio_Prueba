Imports System.Data
Imports Microsoft.Office.Interop
Imports System.Globalization
Partial Class Comp_Compras_Detalle
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim G As Glo = CType(Session("G"), Glo)
        If IsPostBack = False Then
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Img_Logotipo.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Img_Logotipo.Style("Height") = Int(Session("Logo_Height")) & "px"
            Img_Logotipo.Style("Width") = Int(Session("Logo_Width")) & "px"
            Lbl_Centro_Costo.Text = G.Glo_Centro_Costos
            Lbl_Requisicion.Text = G.Num_Requisicion
            Lbl_Solicitante.Text = G.Glo_Solicitante
            Session("dt") = New DataTable
            CrearCamposTabla()
            LlenaGrid()
            'Proveedores.Enabled = False
            Deshabilita()

        End If
        DibujaSpan()
        Msg_Err.Visible = False
        T_Fecha1.Attributes.Add("readonly", "true")
        T_Fecha2.Attributes.Add("readonly", "true")
        T_Fecha3.Attributes.Add("readonly", "true")
        T_Costo1.Attributes.Add("readonly", "true")
        T_Costo2.Attributes.Add("readonly", "true")
        T_Costo3.Attributes.Add("readonly", "true")
        T_Total1.Attributes.Add("readonly", "true")
        T_Total2.Attributes.Add("readonly", "true")
        T_Total3.Attributes.Add("readonly", "true")
        Btn_Moneda1.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Moneda1.Attributes.Add("style", "cursor:pointer;")
        Btn_Moneda2.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Moneda2.Attributes.Add("style", "cursor:pointer;")
        Btn_Moneda3.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=MONEDA&Num=3',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Moneda3.Attributes.Add("style", "cursor:pointer;")
        Btn_Proveedor1.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=1',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Proveedor1.Attributes.Add("style", "cursor:pointer;")
        Btn_Proveedor2.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=2',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Proveedor2.Attributes.Add("style", "cursor:pointer;")
        Btn_Proveedor3.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR&Num=3',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Proveedor3.Attributes.Add("style", "cursor:pointer;")
        '''Valida el formato de numero 
        T_Descuento1.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Descuento1.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Descuento2.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Descuento2.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Descuento3.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Descuento3.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Precio1.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Precio1.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Precio2.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Precio2.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Precio3.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Precio3.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Costo1.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Costo1.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Costo2.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Costo2.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Costo3.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Costo3.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Cantidad1.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Cantidad1.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Cantidad2.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Cantidad2.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Cantidad3.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Cantidad3.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Total1.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Total1.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Total2.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Total2.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Total3.Attributes.Add("onchange", "javascript: FormatNumber('" & T_Total3.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Tipo_Cambio1.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Tipo_Cambio1.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Tipo_Cambio2.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Tipo_Cambio2.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Tipo_Cambio3.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Tipo_Cambio3.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Flete1.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Flete1.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Flete2.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Flete2.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Flete3.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Flete3.ClientID & "'," & 4 & ",'" & True & "','" & True & "');")
        T_Tipo_Cambio1.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Tipo_Cambio1.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Tipo_Cambio2.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Tipo_Cambio2.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Tipo_Cambio3.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Tipo_Cambio3.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        '''Valida solo numeros
        T_Descuento1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Descuento1.ClientID & "');")
        T_Descuento2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Descuento2.ClientID & "');")
        T_Descuento3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Descuento3.ClientID & "');")
        T_Precio1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Precio1.ClientID & "');")
        T_Precio2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Precio2.ClientID & "');")
        T_Precio3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Precio3.ClientID & "');")
        T_Costo1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Costo1.ClientID & "');")
        T_Costo2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Costo2.ClientID & "');")
        T_Costo3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Costo3.ClientID & "');")
        T_Cantidad1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Cantidad1.ClientID & "');")
        T_Cantidad2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Cantidad2.ClientID & "');")
        T_Cantidad3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Cantidad3.ClientID & "');")
        T_Total1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Total1.ClientID & "');")
        T_Total2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Total2.ClientID & "');")
        T_Total3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Total3.ClientID & "');")
        T_Tipo_Cambio1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Tipo_Cambio1.ClientID & "');")
        T_Tipo_Cambio2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Tipo_Cambio2.ClientID & "');")
        T_Tipo_Cambio3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Tipo_Cambio3.ClientID & "');")
        T_Flete1.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Flete1.ClientID & "');")
        T_Flete2.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Flete2.ClientID & "');")
        T_Flete3.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Flete3.ClientID & "');")

        '''Asignacion de Foco
        T_Proveedor1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Moneda1.ClientID & "');")
        T_Moneda1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Precio1.ClientID & "');")
        T_Precio1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Descuento1.ClientID & "');")
        T_Descuento1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Cantidad1.ClientID & "');")
        PC_Fecha1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Flete1.ClientID & "');")
        T_Flete1.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Proveedor2.ClientID & "');")

        T_Proveedor2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Moneda2.ClientID & "');")
        T_Moneda2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Precio2.ClientID & "');")
        T_Precio2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Descuento2.ClientID & "');")
        T_Descuento2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Cantidad2.ClientID & "');")
        PC_Fecha2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Flete2.ClientID & "');")
        T_Flete2.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Proveedor3.ClientID & "');")

        T_Proveedor3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Moneda3.ClientID & "');")
        T_Moneda3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Precio3.ClientID & "');")
        T_Precio3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Descuento3.ClientID & "');")
        T_Descuento3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Cantidad3.ClientID & "');")
        PC_Fecha3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & T_Flete3.ClientID & "');")
        T_Flete3.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Guarda.ClientID & "');")

        T_Proveedor1.Attributes.Add("onfocus", "this.select();")
        T_Moneda1.Attributes.Add("onfocus", "this.select();")
        T_Precio1.Attributes.Add("onfocus", "this.select();")
        T_Descuento1.Attributes.Add("onfocus", "this.select();")
        T_Cantidad1.Attributes.Add("onfocus", "this.select();")
        T_Flete1.Attributes.Add("onfocus", "this.select();")

        T_Proveedor2.Attributes.Add("onfocus", "this.select();")
        T_Moneda2.Attributes.Add("onfocus", "this.select();")
        T_Precio2.Attributes.Add("onfocus", "this.select();")
        T_Descuento2.Attributes.Add("onfocus", "this.select();")
        T_Cantidad2.Attributes.Add("onfocus", "this.select();")
        T_Flete2.Attributes.Add("onfocus", "this.select();")

        T_Proveedor3.Attributes.Add("onfocus", "this.select();")
        T_Moneda3.Attributes.Add("onfocus", "this.select();")
        T_Precio3.Attributes.Add("onfocus", "this.select();")
        T_Descuento3.Attributes.Add("onfocus", "this.select();")
        T_Cantidad3.Attributes.Add("onfocus", "this.select();")
        T_Flete3.Attributes.Add("onfocus", "this.select();")
    End Sub
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Art_Numero", Type.GetType("System.String")) : Session("dt").Columns("Art_Numero").DefaultValue = ""
        Session("dt").Columns.Add("Art_Descripcion", Type.GetType("System.String")) : Session("dt").Columns("Art_Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Cantidad", Type.GetType("System.Double")) : Session("dt").Columns("Cantidad").DefaultValue = 0
        Session("dt").Columns.Add("Precio_Concurso", Type.GetType("System.Double")) : Session("dt").Columns("Precio_Concurso").DefaultValue = 0
        Session("dt").Columns.Add("CenCosto", Type.GetType("System.Int64")) : Session("dt").Columns("CenCosto").DefaultValue = 0
        Session("dt").Columns.Add("Solicitante", Type.GetType("System.Int64")) : Session("dt").Columns("Solicitante").DefaultValue = 0
        Session("dt").Columns.Add("Fecha_Requiere", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Requiere").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Entrega", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Entrega").DefaultValue = ""
        Session("dt").Columns.Add("Urgente", Type.GetType("System.Boolean")) : Session("dt").Columns("Urgente").DefaultValue = False
        Session("dt").Columns.Add("Generada", Type.GetType("System.Boolean")) : Session("dt").Columns("Generada").DefaultValue = False
        Session("dt").Columns.Add("Lugar_Entrega", Type.GetType("System.String")) : Session("dt").Columns("Lugar_Entrega").DefaultValue = ""
        Session("dt").Columns.Add("Asignada", Type.GetType("System.Double")) : Session("dt").Columns("Asignada").DefaultValue = 0
        Session("dt").Columns.Add("Libero_Almacen", Type.GetType("System.String")) : Session("dt").Columns("Libero_Almacen").DefaultValue = ""
        Session("dt").Columns.Add("Proveedor1", Type.GetType("System.Int64")) : Session("dt").Columns("Proveedor1").DefaultValue = 0
        Session("dt").Columns.Add("Proveedor2", Type.GetType("System.Int64")) : Session("dt").Columns("Proveedor2").DefaultValue = 0
        Session("dt").Columns.Add("Proveedor3", Type.GetType("System.Int64")) : Session("dt").Columns("Proveedor3").DefaultValue = 0
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Art_Numero")
        Session("dt").PrimaryKey = clave
    End Sub
    Private Sub desboton(ByRef boton As HyperLink)
        boton.Attributes.Add("style", "cursor:not-allowed;")
        boton.Attributes.Add("onclick", "")
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
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
            G.Tsql = "Select Art_Numero,Art_Descripcion,Cantidad,CenCosto,Solicitante,Precio_Concurso,Fecha_Requiere,Fecha1 As Fecha_Entrega"
            G.Tsql &= " ,Urgente,Proveedor1,Proveedor2,Proveedor3,Cantidad1+Cantidad2+Cantidad3 As Asignada, CAST(CASE WHEN Estatus=10 "
            G.Tsql &= " THEN 'True' ELSE 'False' END As Bit) As Generada"
            G.Tsql &= " from Requisicion"
            G.Tsql &= " Where Tipo = 1 And Requisicion = " & Val(Lbl_Requisicion.Text)
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.Tsql &= " and Art_Numero<>''"
            G.Tsql &= " and Libero_Almacen='S'"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader()
            Session("dt").Load(G.dr)
            Dim clave(0) As DataColumn
            clave(0) = Session("dt").Columns("Art_Numero")
            Session("dt").PrimaryKey = clave
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim G As Glo = CType(Session("G"), Glo)
        If (e.CommandName.Equals("Ver")) Then
            Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
            Dim Clave(0) As String
            Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
            Dim f As DataRow = Session("dt").Rows.Find(Clave)
            If Not f Is Nothing Then
                ''Proveedores.Enabled = True
                Habilita()
                Proveedores.Visible = True
                G.Glo_Articulo = f("Art_Numero")
                G.Glo_Cantidad = f("Cantidad")
                Lbl_Articulo.Text = "Articulo " & f("Art_Numero")
                Lbl_CantArticulo.Text = "Cant. Requerida " & For_Pan_Lib(Val(f("Cantidad")), 2)
                Lbl_PreConArticulo.Text = "   Precio Concurso $" & For_Pan_Lib(Val(f("Precio_Concurso")), 2)
                Lbl_DescArticulo.Text = "Descripción: " & f("Art_Descripcion")
                Proveedores.Visible = True
                P_Req_Partidas.Visible = False
                Informacion_Proveedores()
            End If
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        Dim G As Glo = CType(Session("G"), Glo)
        clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Art_Numero").ToString
        Dim f As DataRow = Session("dt").Rows.Find(clave)
        If Not f Is Nothing Then
            ''Proveedores.Enabled = True
            Habilita()
            Proveedores.Visible = True
            G.Glo_Articulo = f("Art_Numero")
            G.Glo_Cantidad = f("Cantidad")
            Informacion_Proveedores()
        End If
    End Sub
    Private Sub Habilita()
        Btn_Guarda.Enabled = True
        Btn_Guarda.CssClass = "Btn_Azul"
        Proveedores.Enabled = True
        PC_Fecha1.Enabled = True
        PC_Fecha2.Enabled = True
        PC_Fecha3.Enabled = True
    End Sub
    Private Sub Deshabilita()
        Btn_Guarda.Enabled = False
        Btn_Guarda.CssClass = "Btn_Rojo"
        Proveedores.Enabled = False
        PC_Fecha1.Enabled = False
        PC_Fecha2.Enabled = False
        PC_Fecha3.Enabled = False
    End Sub
    Private Sub PonerEnCeros()
        T_Proveedor1.Text = 0
        T_Moneda1.Text = 0
        T_Descuento1.Text = "0.00"
        T_Precio1.Text = "0.0000"
        T_Costo1.Text = "0.0000"
        T_Total1.Text = "0.00"
        T_Tipo_Cambio1.Text = "1.00"
        T_Fecha1.Text = ""
        T_Proveedor2.Text = 0
        T_Moneda2.Text = 0
        T_Descuento2.Text = "0.00"
        T_Precio2.Text = "0.0000"
        T_Costo2.Text = "0.0000"
        T_Total2.Text = "0.00"
        T_Tipo_Cambio2.Text = "2.00"
        T_Fecha2.Text = ""
        T_Proveedor3.Text = 0
        T_Moneda3.Text = 0
        T_Descuento3.Text = "0.00"
        T_Precio3.Text = "0.00000"
        T_Costo3.Text = "0.0000"
        T_Total3.Text = "0.00"
        T_Flete1.Text = "0.00"
        T_Flete2.Text = "0.00"
        T_Flete3.Text = "0.00"
        T_Tipo_Cambio3.Text = "3.00"
        T_Fecha3.Text = ""
        Ch_Cantidad1.Checked = False
        Ch_Cantidad2.Checked = False
        Ch_Cantidad3.Checked = False
        T_Cantidad1.Text = "0.00"
        T_Cantidad2.Text = "0.00"
        T_Cantidad3.Text = "0.00"

        Dim Fecha As Date = Now
        Dim Fecha2 As String = Fecha_AMD((Fecha.AddDays(2)))
        T_Fecha1.Text = Elimina_gato(Fecha2)
        T_Fecha2.Text = Elimina_gato(Fecha2)
        T_Fecha3.Text = Elimina_gato(Fecha2)
    End Sub
    Private Sub Limpiar()
        T_Proveedor1.Text = ""
        T_Moneda1.Text = ""
        T_Descuento1.Text = ""
        T_Precio1.Text = ""
        T_Costo1.Text = ""
        T_Total1.Text = ""
        T_Tipo_Cambio1.Text = ""
        T_Fecha1.Text = ""
        T_Proveedor2.Text = ""
        T_Moneda2.Text = ""
        T_Descuento2.Text = ""
        T_Precio2.Text = ""
        T_Costo2.Text = ""
        T_Total2.Text = ""
        T_Tipo_Cambio2.Text = ""
        T_Fecha2.Text = ""
        T_Proveedor3.Text = ""
        T_Moneda3.Text = ""
        T_Descuento3.Text = ""
        T_Precio3.Text = ""
        T_Costo3.Text = ""
        T_Total3.Text = ""
        T_Flete1.Text = ""
        T_Flete2.Text = ""
        T_Flete3.Text = ""
        T_Tipo_Cambio3.Text = ""
        T_Fecha3.Text = ""
        Ch_Cantidad1.Checked = False
        Ch_Cantidad2.Checked = False
        Ch_Cantidad3.Checked = False
        T_Cantidad1.Text = ""
        T_Cantidad2.Text = ""
        T_Cantidad3.Text = ""
        T_Moneda_Desc1.Text = ""
        T_Moneda_Desc2.Text = ""
        T_Moneda_Desc3.Text = ""
        T_Proveedor_Desc1.Text = ""
        T_Proveedor_Desc2.Text = ""
        T_Proveedor_Desc3.Text = ""
        T_Proveedor1_RFC.Text = ""
        T_Proveedor2_RFC.Text = ""
        T_Proveedor3_RFC.Text = ""
    End Sub
    Private Sub Informacion_Proveedores()
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            'G.Tsql &= "Select * from Articulo_Proveedor"
            G.Tsql = "Select *  from Requisicion Where Tipo=1 and Requisicion=" & Val(Lbl_Requisicion.Text)
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.Tsql &= " and Art_Numero=" & Pone_Apos(G.Glo_Articulo)
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader()
            G.dr.Read()
            If G.dr.HasRows Then
                If Ch_Limpiar.Checked = True Then
                    PonerEnCeros()
                End If
                If Val(G.dr("Proveedor1")) <> 0 Then
                    T_Proveedor1.Text = G.dr("Proveedor1").ToString
                    T_Moneda1.Text = G.dr("Moneda1").ToString
                    T_Descuento1.Text = For_Pan_Lib(G.dr("Descuento1").ToString, 2)
                    T_Precio1.Text = For_Pan_Lib(G.dr("Precio1").ToString, 2)
                    T_Cantidad1.Text = For_Pan_Lib(G.dr("Cantidad1").ToString, 2)
                    T_Costo1.Text = For_Pan_Lib(G.dr("Costo1").ToString, 2)
                    T_Total1.Text = For_Pan_Lib(G.dr("Costo1").ToString * G.Glo_Cantidad, 2)
                    T_Fecha1.Text = G.dr("Fecha1").ToString
                    T_Tipo_Cambio1.Text = For_Pan_Lib(G.dr("Tipo_Cambio1").ToString, 2)
                    T_Flete1.Text = For_Pan_Lib(Val(G.dr("Flete1").ToString), 2)
                    'Dim Tw_Tipo As String = TypeName(G.dr("Asignado1"))
                    'If Tw_Tipo = "Boolean" Then
                    If G.dr("Asignado1") = True Then
                        Ch_Cantidad1.Checked = True
                    Else
                        Ch_Cantidad1.Checked = False
                    End If
                    'Else
                    '    If G.dr.Item("Asignado1").ToString = 0 Then
                    '        Ch_Cantidad1.Checked = False
                    '    Else
                    '        Ch_Cantidad1.Checked = True
                    '    End If
                    'End If
                End If

                If Val(G.dr("Proveedor2")) <> 0 Then
                    T_Proveedor2.Text = G.dr("Proveedor2").ToString
                    T_Moneda2.Text = G.dr("Moneda2").ToString
                    T_Descuento2.Text = For_Pan_Lib(G.dr("Descuento2").ToString, 2)
                    T_Precio2.Text = For_Pan_Lib(G.dr("Precio2").ToString, 2)
                    T_Cantidad2.Text = For_Pan_Lib(G.dr("Cantidad2").ToString, 2)
                    T_Costo2.Text = For_Pan_Lib(G.dr("Costo2").ToString, 2)
                    T_Total2.Text = For_Pan_Lib(G.dr("Costo2").ToString * G.Glo_Cantidad, 2)
                    T_Fecha2.Text = G.dr("Fecha2").ToString
                    T_Tipo_Cambio2.Text = For_Pan_Lib(G.dr("Tipo_Cambio2").ToString, 2)
                    T_Flete2.Text = For_Pan_Lib(Val(G.dr("Flete2").ToString), 2)
                    'Dim Tw_Tipo As String = TypeName(G.dr("Asignado2"))
                    'If Tw_Tipo = "Boolean" Then
                    If G.dr("Asignado2") = True Then
                        Ch_Cantidad2.Checked = True
                    Else
                        Ch_Cantidad2.Checked = False
                    End If
                    '    Else
                    '        If G.dr.Item("Asignado2").ToString = 0 Then
                    '            Ch_Cantidad2.Checked = False
                    '        Else
                    '            Ch_Cantidad2.Checked = True
                    '        End If
                    '    End If
                End If
                If Val(G.dr("Proveedor3")) <> 0 Then
                    T_Proveedor3.Text = G.dr("Proveedor3").ToString
                    T_Moneda3.Text = G.dr("Moneda3").ToString
                    T_Descuento3.Text = For_Pan_Lib(G.dr("Descuento3").ToString, 2)
                    T_Precio3.Text = For_Pan_Lib(G.dr("Precio3").ToString, 2)
                    T_Cantidad3.Text = For_Pan_Lib(G.dr("Cantidad3").ToString, 2)
                    T_Costo3.Text = For_Pan_Lib(G.dr("Costo3").ToString, 2)
                    T_Total3.Text = For_Pan_Lib(G.dr("Costo3").ToString * G.Glo_Cantidad, 2)
                    T_Fecha3.Text = G.dr("Fecha3").ToString
                    T_Tipo_Cambio3.Text = For_Pan_Lib(G.dr("Tipo_Cambio3").ToString, 2)
                    T_Flete3.Text = For_Pan_Lib(Val(G.dr("Flete3").ToString), 2)
                    'Dim Tw_Tipo As String = TypeName(G.dr("Asignado3"))
                    'If Tw_Tipo = "Boolean" Then
                    If G.dr("Asignado3") = True Then
                        Ch_Cantidad3.Checked = True
                    Else
                        Ch_Cantidad3.Checked = False
                    End If
                    '    Else
                    '        If G.dr.Item("Asignado3").ToString = 0 Then
                    '            Ch_Cantidad3.Checked = False
                    '        Else
                    '            Ch_Cantidad3.Checked = True
                    '        End If
                    '    End If
                End If
                G.cn.Close()
                T_Proveedor_Desc1.Text = Buscar_Descripciones("PROVEEDOR", Val(T_Proveedor1.Text))
                T_Proveedor_Desc2.Text = Buscar_Descripciones("PROVEEDOR", Val(T_Proveedor2.Text))
                T_Proveedor_Desc3.Text = Buscar_Descripciones("PROVEEDOR", Val(T_Proveedor3.Text))
                T_Moneda_Desc1.Text = Buscar_Descripciones("MONEDA", Val(T_Moneda1.Text))
                T_Moneda_Desc2.Text = Buscar_Descripciones("MONEDA", Val(T_Moneda2.Text))
                T_Moneda_Desc3.Text = Buscar_Descripciones("MONEDA", Val(T_Moneda3.Text))
                If Val(T_Moneda1.Text) = 0 Then T_Tipo_Cambio1.Text = "1.00"
                If Val(T_Moneda2.Text) = 0 Then T_Tipo_Cambio2.Text = "1.00"
                If Val(T_Moneda3.Text) = 0 Then T_Tipo_Cambio3.Text = "1.00"
            End If
            If G.dr.IsClosed = False Then G.dr.Close()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Private Function Buscar_Descripciones(ByVal DatoBuscar As String, ByVal Valor_Busqueda As String) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Descripcion As String = ""
        Try
            Select Case (DatoBuscar)
                Case "PROVEEDOR"
                    G.Tsql = "Select Razon_Social As Descripcion From Proveedor"
                    G.Tsql &= " where Numero=" & Val(Valor_Busqueda)
                    G.Tsql &= " and Baja<>'*'"
                Case "MONEDA"
                    G.Tsql = "Select Descripcion From Moneda"
                    G.Tsql &= " where Moneda=" & Val(Valor_Busqueda)
                    G.Tsql &= " and Baja<>'*'"
            End Select
            G.cn.Open()
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dr.Read()
            If G.dr.HasRows Then
                Descripcion = G.dr("Descripcion")
            End If
            If G.dr.IsClosed = False Then G.dr.Close()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Descripcion
    End Function

    Protected Sub Btn_Regresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Regresar.Click
        Response.Redirect("Comp_Compras_Requisiciones.aspx")
    End Sub
    Private Function Validar() As Boolean
        Dim G As Glo = CType(Session("G"), Glo)
        Validar = False
        Dim Txw_Cantidad_Pedida As Double
        If Ch_Cantidad1.Checked = True Then
            If Val(Elimina_Comas(T_Cantidad1.Text)) = 0 Then
                'Msg_Error("Cantidad proveedor 1 invalida") : Exit Function
                Msg_Error("La casilla ""Asignar Cantidad"" en el formulario del Proveedor 1 está activa, la cantidad asignada al Proveedor 1 debe ser mayor a 0") : Exit Function
            End If
        Else
            If Val(Elimina_Comas(T_Cantidad1.Text)) > 0 Then
                'Msg_Error("Cantidad proveedor 1 invalida") : Exit Function
                Msg_Error("Si desea asignar una cantidad mayor de 0 al Proveedor 1, debe palomear la casilla ""Asignar Cantidad"" en el formulario del Proveedor 1") : Exit Function
                T_Cantidad1.Text = "0.00"
            End If
        End If

        If Ch_Cantidad2.Checked = True Then
            If Val(Elimina_Comas(T_Cantidad2.Text)) = 0 Then
                'Msg_Error("Cantidad proveedor 2 invalida") : Exit Function
                Msg_Error("La casilla ""Asignar Cantidad"" en el formulario del Proveedor 2 está activa, la cantidad asignada al Proveedor 2 debe ser mayor a 0") : Exit Function
            End If
        Else
            If Val(Elimina_Comas(T_Cantidad2.Text)) > 0 Then
                'MsgBox("Cantidad proveedor 2 invalida") : Exit Function
                Msg_Error("Si desea asignar una cantidad mayor de 0 al Proveedor 2, debe palomear la casilla ""Asignar Cantidad"" en el formulario del Proveedor 2") : Exit Function
                T_Cantidad2.Text = "0.00"
            End If
        End If

        If Ch_Cantidad3.Checked = True Then
            If Val(Elimina_Comas(T_Cantidad3.Text)) = 0 Then
                'Msg_Error("Cantidad proveedor 3 invalida") : Exit Function
                Msg_Error("La casilla ""Asignar Cantidad"" en el formulario del Proveedor 3 está activa, la cantidad asignada al Proveedor 3 debe ser mayor a 0") : Exit Function
            End If
        Else
            If Val(Elimina_Comas(T_Cantidad3.Text)) > 0 Then
                'Msg_Error("Cantidad proveedor 3 invalida") : Exit Function
                Msg_Error("Si desea asignar una cantidad mayor de 0 al Proveedor 3, debe palomear la casilla ""Asignar Cantidad"" en el formulario del Proveedor 3") : Exit Function
                T_Cantidad3.Text = "0.00"
            End If
        End If
        Txw_Cantidad_Pedida = Val(Elimina_Comas(T_Cantidad1.Text)) + Val(Elimina_Comas(T_Cantidad2.Text)) + Val(Elimina_Comas(T_Cantidad3.Text))
        If Txw_Cantidad_Pedida > G.Glo_Cantidad Then
            Msg_Error("La suma de cantidades asignadas a proveedores es mayor que la cantidad requerida") : Exit Function
        End If
        Return True
    End Function

    Protected Sub Btn_Guarda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Guarda.Click
        Dim G As Glo = CType(Session("G"), Glo)
        If Validar() = False Then Exit Sub
        Try
            G.Tsql = "Update Requisicion Set"
            G.Tsql &= " Proveedor1=" & Val(T_Proveedor1.Text)
            G.Tsql &= ",Fecha1=" & Pone_Apos(T_Fecha1.Text)
            G.Tsql &= ",Moneda1=" & Val(T_Moneda1.Text)
            G.Tsql &= ",Precio1=" & Elimina_Comas(T_Descuento1.Text)
            G.Tsql &= ",Cantidad1=" & Val(Elimina_Comas(T_Cantidad1.Text))
            G.Tsql &= ",Descuento1=" & Elimina_Comas(T_Precio1.Text)
            G.Tsql &= ",Costo1=" & Elimina_Comas(T_Costo1.Text)
            G.Tsql &= ",Flete1=" & Elimina_Comas(T_Flete1.Text)
            G.Tsql &= ",Tipo_Cambio1=" & Elimina_Comas(T_Tipo_Cambio1.Text)
            If Ch_Cantidad1.Checked = True Then
                G.Tsql &= ",Asignado1=1"
            Else
                G.Tsql &= ",Asignado1=0"
            End If
            G.Tsql &= ",Proveedor2=" & Val(T_Proveedor2.Text)
            G.Tsql &= " ,Fecha2=" & Pone_Apos(T_Fecha2.Text)
            G.Tsql &= ",Moneda2=" & Val(T_Moneda2.Text)
            G.Tsql &= ",Precio2=" & Elimina_Comas(T_Descuento2.Text)
            G.Tsql &= ",Descuento2=" & Elimina_Comas(T_Precio2.Text)
            G.Tsql &= ",Cantidad2=" & Val(Elimina_Comas(T_Cantidad2.Text))
            G.Tsql &= ",Costo2=" & Elimina_Comas(T_Costo2.Text)
            G.Tsql &= ",Flete2=" & Elimina_Comas(T_Flete2.Text)
            G.Tsql &= ",Tipo_Cambio2=" & Elimina_Comas(T_Tipo_Cambio2.Text)
            If Ch_Cantidad2.Checked = True Then
                G.Tsql &= ",Asignado2=1"
            Else
                G.Tsql &= ",Asignado2=0"
            End If

            G.Tsql &= ",Proveedor3=" & Val(T_Proveedor3.Text)
            G.Tsql &= ",Fecha3=" & Pone_Apos(T_Fecha3.Text)
            G.Tsql &= ",Moneda3=" & Val(T_Moneda3.Text)
            G.Tsql &= ",Precio3=" & Elimina_Comas(T_Descuento3.Text)
            G.Tsql &= ",Descuento3=" & Elimina_Comas(T_Precio3.Text)
            G.Tsql &= ",Cantidad3=" & Val(Elimina_Comas(T_Cantidad3.Text))
            G.Tsql &= ",Costo3=" & Elimina_Comas(T_Costo3.Text)
            G.Tsql &= ",Flete3=" & Elimina_Comas(T_Flete3.Text)
            G.Tsql &= ",Tipo_Cambio3=" & Elimina_Comas(T_Tipo_Cambio3.Text)
            If Ch_Cantidad3.Checked = True Then
                G.Tsql &= ",Asignado3=1"
            Else
                G.Tsql &= ",Asignado3=0"
            End If
            G.Tsql &= " Where Tipo=1 and Requisicion=" & Val(Lbl_Requisicion.Text)
            G.Tsql &= " and Art_Numero=" & Pone_Apos(G.Glo_Articulo)
            G.cn.Open()
            G.com.CommandText = G.Tsql
            G.com.ExecuteNonQuery()
            Limpiar()
            G.Glo_Articulo = ""
            G.Glo_Cantidad = 0
            Deshabilita()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        LlenaGrid()
        GridView1.Focus()
        Proveedores.Visible = False
        P_Req_Partidas.Visible = True
    End Sub

    Protected Sub T_Proveedor1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Proveedor1.TextChanged
        Busca_Proveedor(Val(T_Proveedor1.Text), 1)
        Dim G As Glo = CType(Session("G"), Glo)
        T_Proveedor_Desc1.Text = G.Nom1
        T_Moneda1.Focus()
        T_Proveedor1_RFC.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", T_Proveedor1.Text)
    End Sub

    'Private Sub CatArticulo_Proveedor()
    '    Dim G As Glo = CType(Session("G"), Glo)
    '    Try
    '        G.cn.Open()
    '        G.Tsql = "Select count(Proveedor)"
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub T_Proveedor2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Proveedor2.TextChanged
        Busca_Proveedor(Val(T_Proveedor2.Text), 2)
        Dim G As Glo = CType(Session("G"), Glo)
        T_Proveedor_Desc2.Text = G.Nom2
        T_Moneda2.Focus()
        T_Proveedor2_RFC.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", T_Proveedor2.Text)
    End Sub
    Protected Sub T_Proveedor3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Proveedor3.TextChanged
        Busca_Proveedor(Val(T_Proveedor3.Text), 3)
        Dim G As Glo = CType(Session("G"), Glo)
        T_Proveedor_Desc3.Text = G.Nom3
        T_Moneda3.Focus()
        T_Proveedor3_RFC.Text = Busca_Cat(CType(Session("G"), Glo), "PROVEEDOR_RFC", T_Proveedor3.Text)
    End Sub
    Private Sub Busca_Proveedor(ByVal Txw_Numero As Integer, ByVal Txw_Posicion As Integer)
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Select *  from Proveedor  Where Numero=" & Txw_Numero
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader()
            While G.dr.Read
                If Txw_Posicion = 1 Then
                    G.Nom1 = G.dr.Item("Razon_Social").ToString
                    G.Dir1 = G.dr.Item("Direccion").ToString.Trim & " " & G.dr.Item("Colonia").ToString.Trim & " " & G.dr.Item("Estado").ToString.Trim & " " & G.dr.Item("Pais").ToString.Trim & " C.P." & G.dr.Item("CP").ToString.Trim
                    G.Tel1 = G.dr.Item("TELEFONO_1").ToString.Trim & " " & G.dr.Item("Telefono_2").ToString.Trim
                    If G.dr.Item("Es_Corporativo").ToString = "S" Then
                        G.Cor1 = "CORPORATIVO"
                    Else
                        G.Cor1 = ""
                    End If
                End If
                If Txw_Posicion = 2 Then
                    G.Nom2 = G.dr.Item("Razon_Social").ToString
                    G.Dir2 = G.dr.Item("Direccion").ToString.Trim & " " & G.dr.Item("Colonia").ToString.Trim & " " & G.dr.Item("Estado").ToString.Trim & " " & G.dr.Item("Pais").ToString.Trim & " C.P." & G.dr.Item("CP").ToString.Trim
                    G.Tel2 = G.dr.Item("TELEFONO_1").ToString.Trim & " " & G.dr.Item("Telefono_2").ToString.Trim
                    If G.dr.Item("Es_Corporativo").ToString = "S" Then
                        G.Cor2 = "CORPORATIVO"
                    Else
                        G.Cor2 = ""
                    End If
                End If
                If Txw_Posicion = 3 Then
                    G.Nom3 = G.dr.Item("Razon_Social").ToString
                    G.Dir3 = G.dr.Item("Direccion").ToString.Trim & " " & G.dr.Item("Colonia").ToString.Trim & " " & G.dr.Item("Estado").ToString.Trim & " " & G.dr.Item("Pais").ToString.Trim & " C.P." & G.dr.Item("CP").ToString.Trim
                    G.Tel3 = G.dr.Item("TELEFONO_1").ToString.Trim & " " & G.dr.Item("Telefono_2").ToString.Trim
                    If G.dr.Item("Es_Corporativo").ToString = "S" Then
                        G.Cor3 = "CORPORATIVO"
                    Else
                        G.Cor3 = ""
                    End If
                End If
            End While
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Private Sub Calcular(ByVal Numero_Componente As Integer)
        Dim G As Glo = CType(Session("G"), Glo)
        Select Case Numero_Componente
            Case 1
                Dim Twx_Precio As Double = Elimina_Comas(T_Precio1.Text)
                Dim Twx_Descuento As Double = Elimina_Comas(T_Descuento1.Text)
                Dim Twx_Costo As Double = Twx_Precio
                If Twx_Descuento > 0 Then
                    Twx_Costo = Math.Round(Twx_Precio - (Twx_Precio * (Twx_Descuento / 100)), 4)
                End If
                T_Costo1.Text = For_Pan_Lib(Twx_Costo, 7)
                T_Total1.Text = For_Pan_Lib(G.Glo_Cantidad * Twx_Costo, 2)
            Case 2
                Dim Twx_Precio As Double = Elimina_Comas(T_Precio2.Text)
                Dim Twx_Descuento As Double = Elimina_Comas(T_Descuento2.Text)
                Dim Twx_Costo As Double = Twx_Precio
                If Twx_Descuento > 0 Then
                    Twx_Costo = Math.Round(Twx_Precio - (Twx_Precio * (Twx_Descuento / 100)), 4)
                End If
                T_Costo2.Text = For_Pan_Lib(Twx_Costo, 7)
                T_Total2.Text = For_Pan_Lib(G.Glo_Cantidad * Twx_Costo, 2)
            Case Else
                Dim Twx_Precio As Double = Elimina_Comas(T_Precio3.Text)
                Dim Twx_Descuento As Double = Elimina_Comas(T_Descuento3.Text)
                Dim Twx_Costo As Double = Twx_Precio
                If Twx_Descuento > 0 Then
                    Twx_Costo = Math.Round(Twx_Precio - (Twx_Precio * (Twx_Descuento / 100)), 4)
                End If
                T_Costo3.Text = For_Pan_Lib(Twx_Costo, 7)
                T_Total3.Text = For_Pan_Lib(G.Glo_Cantidad * Twx_Costo, 2)
        End Select
    End Sub
    Protected Sub T_Precio1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Precio1.TextChanged
        Calcular(1)
        T_Descuento1.Focus()
    End Sub
    Protected Sub T_Precio2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Precio2.TextChanged
        Calcular(2)
        T_Descuento2.Focus()
    End Sub
    Protected Sub T_Precio3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Precio3.TextChanged
        Calcular(3)
        T_Descuento3.Focus()
    End Sub
    Protected Sub T_Descuento1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Descuento1.TextChanged
        Calcular(1)
        T_Cantidad1.Focus()
    End Sub
    Protected Sub T_Descuento2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Descuento2.TextChanged
        Calcular(2)
        T_Cantidad2.Focus()
    End Sub
    Protected Sub T_Descuento3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Descuento3.TextChanged
        Calcular(3)
        T_Cantidad3.Focus()
    End Sub
    Private Sub Actualiza_Fila_Grid()

    End Sub
    Private Sub Buscar_Moneda(ByVal Tw_Moneda As Integer, ByVal Tw_Posicion As Integer)
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.Tsql = "Select a.Moneda,a.Descripcion"
            G.Tsql &= ",(Select top 1 Cambio_Compras From Tipo_Cambio b Where Moneda=a.Moneda Order by Fecha DESC ) as Tipo_Cambio"
            G.Tsql &= " From Moneda a Where Moneda=" & Tw_Moneda
            G.cn.Open()
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            G.dr.Read()
            If G.dr.HasRows Then
                If Tw_Posicion = 1 Then
                    T_Moneda_Desc1.Text = G.dr("Descripcion")
                    T_Tipo_Cambio1.Text = For_Pan_Lib(Val(G.dr("Tipo_Cambio")).ToString, 2)
                Else
                    If Tw_Posicion = 2 Then
                        T_Moneda_Desc2.Text = G.dr("Descripcion")
                        T_Tipo_Cambio2.Text = For_Pan_Lib(Val(G.dr("Tipo_Cambio")).ToString, 2)
                    Else
                        T_Moneda_Desc3.Text = G.dr("Descripcion")
                        T_Tipo_Cambio3.Text = For_Pan_Lib(Val(G.dr("Tipo_Cambio")).ToString, 2)
                    End If
                End If
            End If
            If G.dr.IsClosed = False Then G.dr.Close()
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
    Protected Sub T_Moneda1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Moneda1.TextChanged
        T_Moneda_Desc1.Text = ""
        T_Tipo_Cambio1.Text = ""
        Buscar_Moneda(Val(T_Moneda1.Text), 1)
    End Sub
    Protected Sub T_Moneda2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Moneda2.TextChanged
        T_Moneda_Desc2.Text = ""
        T_Tipo_Cambio2.Text = ""
        Buscar_Moneda(Val(T_Moneda2.Text), 2)
    End Sub
    Protected Sub T_Moneda3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Moneda3.TextChanged
        T_Moneda_Desc3.Text = ""
        T_Tipo_Cambio3.Text = ""
        Buscar_Moneda(Val(T_Moneda3.Text), 3)
    End Sub


    Private Function GridAExcel() As Boolean
        Dim G As Glo = CType(Session("G"), Glo)
        Dim Es_Urgente As Boolean = False

        'Creamos las variables
        Dim exapp As New Excel.Application
        Dim exlibro As Excel.Workbook
        Dim exhoja As Excel.Worksheet
        G.cn.Open()
        Try
            'exlibro = exapp.Workbooks.Add
            Dim Nuevo_Nombre As String = Server.MapPath("~/Trabajo/Comparativo_" & Lbl_Requisicion.Text.Trim & ".xlm")
            My.Computer.FileSystem.CopyFile(Server.MapPath("~/Trabajo/Comparativo.xls"), Nuevo_Nombre, True)
            exlibro = exapp.Workbooks.Open(Nuevo_Nombre)
            exhoja = exlibro.Worksheets(1)
            exhoja.Name = "Comparativo"



            Dim Tw_Saldo As Double = 0
            G.Tsql = "Select *  from Requisicion Where Tipo=1 and Requisicion=" & Val(Lbl_Requisicion.Text)
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.Tsql &= " and Art_Numero<>''"
            G.Tsql &= " and Libero_Almacen='S'"

            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader()
            Dim Sub_1 As Double = 0
            Dim Sub_2 As Double = 0
            Dim Sub_3 As Double = 0
            Dim Iva_1 As Double = 0
            Dim Iva_2 As Double = 0
            Dim Iva_3 As Double = 0
            Dim Prov1 As Integer = 0
            Dim Prov2 As Integer = 0
            Dim Prov3 As Integer = 0
            Dim Flete1 As Integer = 0
            Dim Flete2 As Integer = 0
            Dim Flete3 As Integer = 0
            G.Nom1 = "" : G.Nom2 = "" : G.Nom3 = "" : G.Dir1 = "" : G.Dir2 = "" : G.Dir3 = "" : G.Tel1 = "" : G.Tel2 = "" : G.Tel3 = "" : G.For1 = "" : G.For2 = "" : G.For3 = ""
            G.Cor1 = "" : G.Cor2 = "" : G.Cor3 = ""
            Dim Tw_Partida As Integer = 0
            Dim Fila As Integer = 10
            Dim Tw_Sec As Integer = 0
            Dim Tw_Saldo_Rel As Double = 0
            Fila = 5
            Do While G.dr.Read
                If G.dr.Item("Urgente").ToString = True Then
                    Es_Urgente = True
                End If
                Fila += 1
                Tw_Partida += 1
                ' exhoja.Cells.Item(Fila, 1) = Tw_Partida
                exhoja.Cells.Item(Fila, 2) = "'" & G.dr.Item("Fecha_Requiere").ToString
                exhoja.Cells.Item(Fila, 3) = G.dr.Item("Art_Descripcion").ToString
                exhoja.Cells.Item(Fila, 6) = "'" & G.dr.Item("Fecha1").ToString
                exhoja.Cells.Item(Fila, 9) = "'" & G.dr.Item("Fecha2").ToString
                exhoja.Cells.Item(Fila, 12) = "'" & G.dr.Item("Fecha3").ToString
                Fila += 1
                exhoja.Cells.Item(Fila, 2) = G.dr.Item("Unidad_Medida").ToString

                exhoja.Cells.Item(Fila, 3) = G.dr.Item("Cantidad").ToString

                If G.dr.Item("Proveedor1").ToString > 0 Then
                    exhoja.Cells.Item(Fila, 4) = For_Pan_Lib(G.dr.Item("Precio1").ToString, 2)
                    exhoja.Cells.Item(Fila, 5) = For_Pan_Lib(G.dr.Item("Descuento1").ToString, 2)
                    exhoja.Cells.Item(Fila, 6) = For_Pan_Lib(G.dr.Item("Costo1").ToString * G.dr.Item("Cantidad").ToString, 2)
                    Sub_1 += Math.Round(G.dr.Item("Costo1").ToString * G.dr.Item("Cantidad").ToString, 2)
                    Flete1 += Val(G.dr.Item("Flete1").ToString)
                End If
                If G.dr.Item("Proveedor2").ToString > 0 Then
                    exhoja.Cells.Item(Fila, 7) = For_Pan_Lib(G.dr.Item("Precio2").ToString, 2)
                    exhoja.Cells.Item(Fila, 8) = For_Pan_Lib(G.dr.Item("Descuento2").ToString, 2)
                    exhoja.Cells.Item(Fila, 9) = For_Pan_Lib(G.dr.Item("Costo2").ToString * G.dr.Item("Cantidad").ToString, 2)
                    Sub_2 += Math.Round(G.dr.Item("Costo2").ToString * G.dr.Item("Cantidad").ToString, 2)
                    Flete2 += Val(G.dr.Item("Flete2").ToString)
                End If
                If G.dr.Item("Proveedor3").ToString > 0 Then
                    exhoja.Cells.Item(Fila, 10) = For_Pan_Lib(G.dr.Item("Precio3").ToString, 2)
                    exhoja.Cells.Item(Fila, 11) = For_Pan_Lib(G.dr.Item("Descuento3").ToString, 2)
                    exhoja.Cells.Item(Fila, 12) = For_Pan_Lib(G.dr.Item("Costo3").ToString * G.dr.Item("Cantidad").ToString, 2)
                    Sub_3 += Math.Round(G.dr.Item("Costo3").ToString * G.dr.Item("Cantidad").ToString, 2)
                    Flete3 += Val(G.dr.Item("Flete3").ToString)
                End If
                If G.dr.Item("Proveedor1").ToString > 0 Then Prov1 = G.dr.Item("Proveedor1").ToString
                If G.dr.Item("Proveedor2").ToString > 0 Then Prov2 = G.dr.Item("Proveedor2").ToString
                If G.dr.Item("Proveedor3").ToString > 0 Then Prov3 = G.dr.Item("Proveedor3").ToString
                If Tw_Partida > 12 Then
                    Fila = 49
                End If
            Loop
            G.cn.Close()
            exhoja.Rows.Item(5).font.bold = 1
            Fila = 30
            exhoja.Cells.Item(Fila, 6) = For_Pan_Lib(Flete1, 2)
            exhoja.Cells.Item(Fila, 9) = For_Pan_Lib(Flete2, 2)
            exhoja.Cells.Item(Fila, 12) = For_Pan_Lib(Flete3, 2)
            Fila = 31
            'Imprime subtotal
            Sub_1 += Flete1
            Sub_2 += Flete2
            Sub_3 += Flete3
            exhoja.Cells.Item(Fila, 6) = For_Pan_Lib(Sub_1, 2)
            exhoja.Cells.Item(Fila, 9) = For_Pan_Lib(Sub_2, 2)
            exhoja.Cells.Item(Fila, 12) = For_Pan_Lib(Sub_3, 2)

            Fila += 1
            Iva_1 = Math.Round(Sub_1 * 0.16, 2)
            Iva_2 = Math.Round(Sub_2 * 0.16, 2)
            Iva_3 = Math.Round(Sub_3 * 0.16, 2)
            'Imprime Iva
            exhoja.Cells.Item(Fila, 6) = For_Pan_Lib(Iva_1, 2)
            exhoja.Cells.Item(Fila, 9) = For_Pan_Lib(Iva_2, 2)
            exhoja.Cells.Item(Fila, 12) = For_Pan_Lib(Iva_3, 2)
            ' IMPRESION DE TOTALES
            Fila += 1
            exhoja.Cells.Item(Fila, 6) = For_Pan_Lib(Sub_1 + Iva_1, 2)
            exhoja.Cells.Item(Fila, 9) = For_Pan_Lib(Sub_2 + Iva_2, 2)
            exhoja.Cells.Item(Fila, 12) = For_Pan_Lib(Sub_3 + Iva_3, 2)


            Busca_Proveedor(Prov1, 1)
            Busca_Proveedor(Prov2, 2)
            Busca_Proveedor(Prov3, 3)
            Fila = 34
            ' exhoja.Cells.Item(Fila, 1) = "PROVEEDOR"
            exhoja.Cells.Item(Fila, 4) = G.Nom1
            exhoja.Cells.Item(Fila, 7) = G.Nom2
            exhoja.Cells.Item(Fila, 10) = G.Nom3

            Fila += 1
            'exhoja.Cells.Item(Fila, 1) = "DIRECCION"
            exhoja.Cells.Item(Fila, 4) = G.Dir1
            exhoja.Cells.Item(Fila, 7) = G.Dir2
            exhoja.Cells.Item(Fila, 10) = G.Dir3

            Fila += 1
            'exhoja.Cells.Item(Fila, 1) = "TELEFONO"
            exhoja.Cells.Item(Fila, 4) = G.Tel1
            exhoja.Cells.Item(Fila, 7) = G.Tel2
            exhoja.Cells.Item(Fila, 10) = G.Tel3

            Fila += 1
            'exhoja.Cells.Item(Fila, 1) = "FORMA PAGO"
            exhoja.Cells.Item(Fila, 4) = G.For1
            exhoja.Cells.Item(Fila, 7) = G.For2
            exhoja.Cells.Item(Fila, 10) = G.For3

            Fila += 1
            exhoja.Cells.Item(Fila, 1) = "Observaciones"

            Fila = 39
            exhoja.Cells.Item(Fila, 5) = G.Cor1
            exhoja.Cells.Item(Fila, 8) = G.Cor2
            exhoja.Cells.Item(Fila, 11) = G.Cor3
            If Es_Urgente = True Then
                Fila = 40
                exhoja.Cells.Item(Fila, 3) = "ES URGENTE"
            End If
            If Tw_Partida > 12 Then
                Fila = 78
                ' exhoja.Cells.Item(Fila, 1) = "PROVEEDOR"
                exhoja.Cells.Item(Fila, 4) = G.Nom1
                exhoja.Cells.Item(Fila, 7) = G.Nom2
                exhoja.Cells.Item(Fila, 10) = G.Nom3

                Fila += 1
                'exhoja.Cells.Item(Fila, 1) = "DIRECCION"
                exhoja.Cells.Item(Fila, 4) = G.Dir1
                exhoja.Cells.Item(Fila, 7) = G.Dir2
                exhoja.Cells.Item(Fila, 10) = G.Dir3

                Fila += 1
                'exhoja.Cells.Item(Fila, 1) = "TELEFONO"
                exhoja.Cells.Item(Fila, 4) = G.Tel1
                exhoja.Cells.Item(Fila, 7) = G.Tel2
                exhoja.Cells.Item(Fila, 10) = G.Tel3

                Fila += 1
                'exhoja.Cells.Item(Fila, 1) = "FORMA PAGO"
                exhoja.Cells.Item(Fila, 4) = G.For1
                exhoja.Cells.Item(Fila, 7) = G.For2
                exhoja.Cells.Item(Fila, 10) = G.For3

                Fila += 1
                exhoja.Cells.Item(Fila, 1) = "Observaciones"

                Fila = 39
                exhoja.Cells.Item(Fila, 5) = G.Cor1
                exhoja.Cells.Item(Fila, 8) = G.Cor2
                exhoja.Cells.Item(Fila, 11) = G.Cor3
                If Es_Urgente = True Then
                    Fila = 40
                    exhoja.Cells.Item(Fila, 3) = "ES URGENTE"
                End If
            End If

            exapp.Application.Visible = True
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        Finally
            exhoja = Nothing
            exlibro = Nothing
            exapp = Nothing
            G.cn.Close()
        End Try
        Return True
    End Function
    Protected Sub Btn_Exporta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Exporta.Click
        GridAExcel()
    End Sub

    Protected Sub T_Cantidad1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles T_Cantidad1.TextChanged
        PC_Fecha1.Focus()
    End Sub

    Protected Sub Btn_Restaura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_Restaura.Click
        Pnl_Grids.Visible = True
        P_Req_Partidas.Visible = True
        Proveedores.Visible = False
        Limpiar()
        PonerEnCeros()
    End Sub

End Class
