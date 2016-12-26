Imports System.Data
Imports Microsoft.Reporting.WebForms
Imports System.Globalization
Partial Class Visor_Reporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        Dim Tsql As String = ""
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Dim Reporte As String = Request.QueryString("REPORTE")
            Dim Detalle As String = Request.QueryString("Detalle")
            Dim Fecha_Inicio As String = Request.QueryString("Fecha_Inicio")
            Dim Fecha_Fin As String = Request.QueryString("Fecha_Fin")
            Dim Lote As String = Request.QueryString("LOTE")
            Dim Impresora As String = Request.QueryString("Impresora")
            'Dim Elemento As String = Request.QueryString("Elem_I").ToString
            'Dim Elemento_Final As String = Request.QueryString("Elem_F").ToString
            'Dim Articulo As String = Request.QueryString("Art_I").ToString
            'Dim Articulo_Final As String = Request.QueryString("Art_F").ToString
            ReportViewer1.LocalReport.EnableExternalImages = True
            Try
                Select Case Reporte
                    Case "R_VSalidaDevoluciones"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New dsCrystal.Salida_NormalDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(18) As ReportParameter
                        Parametros(0) = New ReportParameter("Folio_Salida", G.Numero_Lote)
                        Parametros(1) = New ReportParameter("Nombre_Solicitante", G.VF_Solicitante)
                        Parametros(2) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)
                        Parametros(3) = New ReportParameter("Num_Elemento", G.VF_Elemento)
                        Parametros(4) = New ReportParameter("Desc_Elemento", G.VF_Elemento_Descripcion)
                        Parametros(5) = New ReportParameter("Desc_Actividad", G.VF_Actividad_Descripcion)
                        Parametros(6) = New ReportParameter("Fecha_Lote", G.VF_Fecha_Lote)
                        Parametros(7) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(8) = New ReportParameter("Logotipo", Server.MapPath("./Trabajo/" & Session("Imagen")))
                        Parametros(9) = New ReportParameter("Tipo_Elemento", G.VF_Tipo_Elemento)
                        Parametros(10) = New ReportParameter("Salida", G.VF_Salida)
                        Parametros(11) = New ReportParameter("Salida_Desc", G.VF_Salida_Desc)
                        Parametros(12) = New ReportParameter("Clasificacion_Desc", G.VF_Clas_Desc)
                        Parametros(13) = New ReportParameter("Referencia_Desc", G.VF_Ref_Des)
                        Parametros(14) = New ReportParameter("Cuenta", G.VF_Cuenta)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(15) = New ReportParameter("Imagen", Imagen)
                        Dim ObraReporte As String = G.Sucursal & " " & G.Sucursal_Desc
                        Parametros(16) = New ReportParameter("Obra", ObraReporte)
                        Parametros(18) = New ReportParameter("rfcproveedor", G.VF_Cuenta & G.Sucursal & G.rfcproveedor)

                        G.Tsql = "Select Articulo,Descripcion,Unidad_Medida,Cantidad,Precio_Unitario,Costo_Total"
                        G.Tsql &= " from Movimientos_Inventario left join Compañias"
                        G.Tsql &= " on Movimientos_Inventario.Compania=Compañias.Cia"
                        G.Tsql &= " where Movimientos_Inventario.Lote=" & G.Numero_Lote
                        G.Tsql &= " and Movimientos_Inventario.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Movimientos_Inventario.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and Movimientos_Inventario.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and E_S='S'"
                        G.Tsql &= " and Partida>0"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Detalle_Salida As New DataTable
                        dt_Detalle_Salida.Load(G.dr)
                        Dim f As DataRow
                        Dim total As Double = 0
                        For Each f In dt_Detalle_Salida.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Unidad_Medida") = f("Unidad_Medida")
                            nf("Cantidad") = f("Cantidad")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("Costo_Total") = f("Costo_Total")
                            dt.Rows.Add(nf)
                            total = total + nf("Costo_Total")
                        Next
                        Parametros(17) = New ReportParameter("Importe_Total", total)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_VSalidaDevoluciones.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_VSalidaDevoluciones.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()

                    Case "ORDEN_COMPRA"
                        Dim dt As New dsCrystal.Ordenes_CompraDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(47) As ReportParameter
                        Tsql = "Select Razon_Social from Proveedor where Numero=" & Val(G.Proveedor)
                        G.cn.Open()
                        G.com.CommandText = Tsql
                        G.Proveedor_Desc = G.com.ExecuteScalar
                        G.cn.Close()

                        Parametros(0) = New ReportParameter("Empresa", G.RazonSocial)
                        Parametros(1) = New ReportParameter("Direccion", G.Direccion)
                        Parametros(2) = New ReportParameter("Localidad", G.Localidad)
                        Parametros(3) = New ReportParameter("RFC", G.RFC)
                        ''MAQUINA
                        Parametros(4) = New ReportParameter("Maquina", G.Maquina)
                        Parametros(5) = New ReportParameter("NumEco", G.NumEco)
                        Parametros(6) = New ReportParameter("Marca", G.Marca)
                        Parametros(7) = New ReportParameter("Modelo", G.Modelo)
                        Parametros(8) = New ReportParameter("Serie", G.Serie)
                        ''MOTOR
                        Parametros(9) = New ReportParameter("Motor", G.Motor)
                        Parametros(10) = New ReportParameter("Motor_Marca", G.Motor_Marca)
                        Parametros(11) = New ReportParameter("Motor_Modelo", G.Motor_Modelo)
                        Parametros(12) = New ReportParameter("Motor_Serie", G.Motor_Serie)
                        ''POROVEEDOR
                        Parametros(13) = New ReportParameter("Proveedor", G.Proveedor)
                        Parametros(14) = New ReportParameter("Proveedor_Direccion", G.Proveedor_Direccion)
                        Parametros(15) = New ReportParameter("Proveedor_Localidad", G.Proveedor_Localidad)
                        Parametros(16) = New ReportParameter("Proveedor_RFC", G.Proveedor_RFC)
                        Parametros(17) = New ReportParameter("Prov_Atencion", G.Prov_Atencion)
                        Parametros(18) = New ReportParameter("Prov_Tiempo_Entrega", G.Prov_Tiempo_Entrega)
                        Parametros(19) = New ReportParameter("Cond_Pago", G.Cond_Pago)
                        ''ORDEN
                        Parametros(20) = New ReportParameter("Requisicion", G.Num_Requisicion)
                        Parametros(21) = New ReportParameter("Orden", G.Num_Orden)
                        Parametros(22) = New ReportParameter("Costo_Devolucion", G.Costo_Devolucion)
                        Parametros(23) = New ReportParameter("Lugar_Entrega", G.Lugar_Entrega)
                        Parametros(24) = New ReportParameter("Flete", G.Flete)
                        Parametros(25) = New ReportParameter("Departamento", G.Departamento)
                        Parametros(26) = New ReportParameter("Condicion_Pago", G.Condicion_Pago)
                        ''CALCULOS

                        Session("dt").Rows.Clear()
                        G.Tsql = "Select a.Numero_Orden as Orden,(Select b.Descripcion from Moneda b where b.Moneda=a.Moneda) as Moneda, a.Partida, a.Art_Numero as Articulo,a.Art_Descripcion as Descripcion,"
                        G.Tsql &= "(Select c.Dias_Entrega from Articulo_Proveedor c where c.Art_Numero=a.Art_Numero And Pro_Numero=" & Val(G.Proveedor) & "and c.Cia=a.Cia and c.Obra=a.Obra) as Dias_Entrega"
                        G.Tsql &= ",a.Cantidad,a.Costo,(a.Cantidad*a.Costo) as Total,(a.Cantidad*a.Costo*(a.Iva/100)) as Iva"
                        G.Tsql &= ",a.Catalogo,a.Figura,a.Pagina"
                        G.Tsql &= ",(Select top 1 Unidad_Medida From Articulos Where Numero=a.Art_Numero) As Unidad_Medida "
                        G.Tsql &= " from Ordenes_Compra  a Where Numero_Orden =" & Pone_Apos(G.Num_Orden)
                        G.Tsql &= " and Cia=" & Val(Session("Cia"))
                        G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Rep As New DataTable
                        dt_Rep.Load(G.dr)
                        Dim Subtotal As Double = 0
                        Dim Total As Double = 0
                        Dim Iva As Double = 0
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In dt_Rep.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Orden") = f("Orden")
                            nf("Partida") = f("Partida")
                            nf("Cantidad") = f("Cantidad")
                            nf("Unidad_Medida") = f("Unidad_Medida")
                            nf("Catalogo") = f("Catalogo")
                            nf("Pagina") = f("Pagina")
                            nf("Dias_Entrega") = f("Dias_Entrega")
                            nf("Figura") = f("Figura")
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Costo") = f("Costo")
                            nf("Total") = f("Total")
                            nf("Moneda") = f("Moneda")
                            nf("Iva") = f("Iva")
                            Iva = Iva + f("Iva")
                            Subtotal = Subtotal + Val(f("Total"))
                            Total = Subtotal + Iva
                            dt.Rows.Add(nf)
                        Next

                        Parametros(27) = New ReportParameter("Subtotal", Subtotal)
                        Parametros(28) = New ReportParameter("Iva", Iva)
                        Parametros(29) = New ReportParameter("Total_Orden", Total)
                        Parametros(30) = New ReportParameter("Importe_Letra", G.Tg_Moneda)
                        Parametros(31) = New ReportParameter("Fecha_Orden", G.Fecha_Orden)
                        ''FIRMAS
                        Parametros(32) = New ReportParameter("For_Nombre", G.Formulo)
                        Parametros(33) = New ReportParameter("Rev_Nombre", G.Reviso)
                        Parametros(34) = New ReportParameter("Aut_Nombre", G.Autorizo)
                        Parametros(35) = New ReportParameter("Cuarta_Nombre", G.Cuarta)
                        Parametros(36) = New ReportParameter("Puesto1", G.Glo_ComprasP1)
                        Parametros(37) = New ReportParameter("Puesto2", G.Glo_ComprasP2)
                        Parametros(38) = New ReportParameter("Puesto3", G.Glo_ComprasP3)
                        Parametros(39) = New ReportParameter("Puesto4", G.Glo_ComprasP4)
                        Dim anexo As String = LeeAnexo()
                        Parametros(40) = New ReportParameter("Anexo", anexo)
                        anexo = LeeAnexo2()
                        Parametros(41) = New ReportParameter("Anexo2", anexo)
                        Parametros(42) = New ReportParameter("I_Formulo", "file:" & G.I_Formulo)
                        Parametros(43) = New ReportParameter("I_Reviso", "file:" & G.I_Reviso)
                        Parametros(44) = New ReportParameter("I_Autorizo", "file:" & G.I_Autorizo)
                        Parametros(45) = New ReportParameter("I_Cuarta", "file:" & G.I_Cuarta)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(46) = New ReportParameter("Imagen", Imagen)
                        Parametros(47) = New ReportParameter("Proveedor_Desc", G.Proveedor_Desc)

                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Orden.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Orden.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "RELACION_ORDENES"
                        Dim dt As New dsCrystal.Ordenes_Compra_GeneralDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(7) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Parametros(4) = New ReportParameter("Estatus", G.Estatus_Orden)
                        Parametros(5) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(7) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.cn.Open()
                        G.Tsql = " Select a.* "
                        G.Tsql &= ",(Select top 1 Unidad_Medida  From Articulos Where Numero=a.Art_Numero) As Unidad_Medida"
                        G.Tsql &= ",(Select top 1 Razon_Social  From Proveedor Where Numero=a.Proveedor) As Nom_Prov"
                        G.Tsql &= " from Ordenes_Compra a Where a.Cia=" & Val(Session("Cia"))
                        G.Tsql &= " and a.Obra=" & Pone_Apos(Session("Obra"))
                        If G.Estatus_Orden = "Surtidas" Then
                            Tsql &= " and a.Cantidad_Recibida > 0 "
                        End If
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Rel As New DataTable
                        dt_Rel.Load(G.dr)
                        Dim Dias As Integer
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In dt_Rel.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Numero_Orden") = f("Numero_Orden")
                            nf("Requisicion") = f("Requisicion")
                            nf("Art_Numero") = f("Art_Numero")
                            nf("Art_Descripcion") = f("Art_Descripcion")
                            nf("Cantidad") = f("Cantidad")
                            nf("Unidad_Medida") = f("Unidad_Medida")
                            nf("Fecha_Recepcion") = f("Fecha_Recepcion")
                            nf("Cantidad_Recibida") = f("Cantidad_Recibida")
                            nf("Fecha_Solicitud") = f("Fecha_Solicitud")
                            nf("Fecha_Requiere") = f("Fecha_Requiere")
                            If f("Fecha_Recepcion").ToString.Trim <> "" Then
                                Dim Txw_Fec_Ini As Date = Fecha_AMD(f("Fecha_Recepcion"))
                                Dim Txw_Fec_Fin As Date = Fecha_AMD(f("Fecha_Solicitud"))
                                Dias = DateDiff("d", Txw_Fec_Fin, Txw_Fec_Ini)
                            Else
                                Dim Txw_Fec_Ini As Date = Fecha_AMD(Now)
                                Dim Txw_Fec_Fin As Date = Fecha_AMD(f("Fecha_Solicitud"))
                                Dias = DateDiff("d", Txw_Fec_Fin, Txw_Fec_Ini)
                            End If
                            nf("Dias") = Dias
                            nf("Precio") = f("Precio")
                            nf("Total") = nf("Precio") * nf("Cantidad")
                            nf("CenCosto") = f("CenCosto")
                            nf("Nom_Prov") = f("Nom_Prov")
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Ordenes_General.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Ordenes_General.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "C_Resguardo"
                        Dim dt As New dsCrystal.Resguardo_EntradasDataTable
                        Dim RD As New ReportDataSource
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim Parametros(6) As ReportParameter
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Imagen)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(5) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(6) = New ReportParameter("Almacen", G.Almacen_Desc)
                        For Each f As DataRow In Session("dt").rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Cantidad") = f("Cantidad")
                            nf("Descripcion") = f("Descripcion")
                            nf("Trabajador") = f("Trabajador")
                            nf("Observaciones") = f("Observaciones")
                            nf("Consecutivo") = f("Consecutivo")
                            If f("E_S") = "E" Then
                                nf("Disponible") = "Si"
                            Else
                                nf("Disponible") = "No"
                            End If
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Resguardo_Prueba.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Resguardo_Prueba.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_EResguardo"
                        Dim dt As New dsCrystal.Resguardo_EntradasDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(5) As ReportParameter
                        Parametros(0) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(3) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(4) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(5) = New ReportParameter("Almacen", G.Almacen_Desc)
                        For Each f In Session("dt_Resguardo").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Resguardo") = f("Resguardo")
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Fecha") = f("Fecha")
                            nf("Trabajador") = f("Trabajador")
                            nf("Serie") = f("Serie")
                            nf("Entregado") = f("Entregado")
                            nf("Trabajador_Desc") = f("Trabajador_Desc")
                            nf("Consecutivo") = f("Consecutivo")
                            nf("Observaciones") = f("Observaciones")
                            nf("Cantidad") = 0
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Resguardo_Salidas.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Resguardo_Salidas.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_SResguardo"
                        Dim dt As New dsCrystal.Resguardo_EntradasDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(5) As ReportParameter
                        Parametros(0) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(3) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(4) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(5) = New ReportParameter("Almacen", G.Almacen_Desc)
                        For Each f In Session("dt_Resguardo").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Resguardo") = f("Resguardo")
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Fecha") = f("Fecha")
                            nf("Trabajador") = f("Trabajador")
                            nf("Serie") = f("Serie")
                            nf("Trabajador_Desc") = f("Trabajador_Desc")
                            nf("Consecutivo") = f("Consecutivo")
                            nf("Observaciones") = f("Observaciones")
                            nf("Cantidad") = 0
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Resguardo_Entradas.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Resguardo_Entradas.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()

                    Case "REQUISICION"
                        Dim dt As New Requisiciones.Partidas_RequisicionDataTable
                        Dim RD As New ReportDataSource
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim Parametros(23) As ReportParameter
                        Dim Fecha_Impresion As String
                        Fecha_Impresion = Now.Day & " de " & Mes_Nombre(Now.Month) & " del " & Now.Year
                        G.cn.Open()
                        G.com.CommandText = "Select Descripcion from Centro_Costos where Centro_Costos=" & Val(G.Glo_Centro_Costos)
                        Dim DescCentroCostos As String = AString(G.com.ExecuteScalar)
                        Parametros(0) = New ReportParameter("Empresa", G.RazonSocial)
                        Parametros(1) = New ReportParameter("Centro_Costos", DescCentroCostos)
                        Parametros(2) = New ReportParameter("Requisicion", G.Num_Requisicion)
                        Parametros(3) = New ReportParameter("Fecha_Emision", Fecha_Impresion)
                        Parametros(4) = New ReportParameter("Maquina", G.Maquina)
                        Parametros(5) = New ReportParameter("NoEconomico", G.NumEco)
                        Parametros(6) = New ReportParameter("Maq_Marca", G.Marca)
                        Parametros(7) = New ReportParameter("Maq_Modelo", G.Modelo)
                        Parametros(8) = New ReportParameter("Maq_Serie", G.Serie)
                        Parametros(9) = New ReportParameter("Motor", G.Motor)
                        Parametros(10) = New ReportParameter("Motor_Marca", G.Motor_Marca)
                        Parametros(11) = New ReportParameter("Motor_Modelo", G.Motor_Modelo)
                        Parametros(12) = New ReportParameter("Motor_Serie", G.Motor_Serie)
                        Parametros(13) = New ReportParameter("Solicitante", G.Nombre_Sup)
                        Parametros(14) = New ReportParameter("Almacen", G.Nombre_Alm)
                        Parametros(15) = New ReportParameter("Administrativo", G.Nombre_Adm)
                        Parametros(16) = New ReportParameter("Superintendente", G.Nombre_Ger)
                        Parametros(17) = New ReportParameter("Puesto1", G.Glo_RequisicionP1.ToUpper)
                        Parametros(18) = New ReportParameter("Puesto2", G.Glo_RequisicionP2.ToUpper)
                        Parametros(19) = New ReportParameter("Puesto3", G.Glo_RequisicionP3.ToUpper)
                        Parametros(20) = New ReportParameter("Puesto4", G.Glo_RequisicionP4.ToUpper)
                        'Dim arreglo() As Char = G.Imagen.ToCharArray
                        'Dim temp As String = G.Imagen
                        'Dim myArray As Array = temp.Split(".")
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & G.Imagen)
                        Parametros(21) = New ReportParameter("Imagen", Imagen)
                        Parametros(22) = New ReportParameter("Proyecto", G.Sucursal_Desc)
                        Parametros(23) = New ReportParameter("Solicitante_Desc", G.Solicitante_Desc)
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        G.Tsql = "Select Art_Numero,Art_Descripcion,Unidad_Medida,Cantidad,Observacion,Catalogo,Pagina,Figura"
                        G.Tsql &= " from Requisicion Where Requisicion=" & Val(G.Num_Requisicion)
                        G.Tsql &= " and Art_Numero<>''"
                        G.Tsql &= " and Cia=" & Val(Session("Cia"))
                        G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt").rows.clear()
                        Session("dt").Load(G.dr)
                        G.cn.Close()
                        For Each f As DataRow In Session("dt").rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Art_Numero") = f("Art_Numero")
                            nf("Cantidad") = f("Cantidad")
                            nf("Art_Descripcion") = f("Art_Descripcion")
                            nf("Unidad_Medida") = f("Unidad_Medida")
                            nf("Catalogo") = f("Catalogo")
                            nf("Pagina") = f("Pagina")
                            nf("Figura") = f("Figura")
                            nf("Observacion") = f("Observacion")
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "Requisiciones"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Requisicion.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Requisicion.rdlc"
                        ReportViewer1.LocalReport.Refresh()

                    Case "R_Informe_Mensual"
                        Dim dt As New dsCrystal.Informe_MensualDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(6) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Parametros(4) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(5) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(6) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select Distinct a.Linea as Lin_Numero,a.Sub_Linea as Sub_Numero"
                        G.Tsql &= ",a.Articulo as Numero"
                        G.Tsql &= ",c.Descripcion as Sublinea_Desc,b.Descripcion as Linea_Desc"
                        G.Tsql &= ",IsNull((Select top 1 d.Existencia from Movimientos_Inventario d Where d.Compania=a.Compania and d.Obra=a.Obra and d.Almacen=a.Almacen and a.Linea=d.Linea and a.Sub_Linea=d.Sub_Linea and a.Articulo=d.Articulo and d.Fecha_Lote<" & Pone_Apos(Fecha_AMD(Fecha_Inicio)) & " order by d.Numero_Secuencial Desc),0) as Existencia_Inicial,"
                        G.Tsql &= " IsNull((Select top 1 h.Valor_Inventario from Movimientos_Inventario h Where h.Compania=a.Compania and h.Obra=a.Obra and h.Almacen=a.Almacen and a.Linea=h.Linea and a.Sub_Linea=h.Sub_Linea and a.Articulo=h.Articulo and h.Fecha_Lote<" & Pone_Apos(Fecha_AMD(Fecha_Inicio)) & " order by h.Numero_Secuencial Desc),0) as CT_Existencia_Ini,"
                        G.Tsql &= " IsNull((Select sum(e.Cantidad) from Movimientos_Inventario e Where e.Compania=a.Compania and e.Obra=a.Obra and e.Almacen=a.Almacen and a.Linea=e.Linea and a.Sub_Linea=e.Sub_Linea and a.Articulo=e.Articulo and e.E_S='E' and (e.Fecha_Lote>=" & Pone_Apos(Fecha_AMD(Fecha_Inicio)) & " and e.Fecha_Lote<=" & Pone_Apos(Fecha_AMD(Fecha_Fin)) & ")),0) as Entradas,"
                        G.Tsql &= " IsNull((Select sum(g.Cantidad* g.Precio_Unitario) from Movimientos_Inventario g Where g.Compania=a.Compania and G.Sucursal=a.Obra and g.Almacen=a.Almacen and a.Linea=g.Linea and a.Sub_Linea=g.Sub_Linea and a.Articulo=g.Articulo and g.E_S='E' and (g.Fecha_Lote>=" & Pone_Apos(Fecha_AMD(Fecha_Inicio)) & " and g.Fecha_Lote<=" & Pone_Apos(Fecha_AMD(Fecha_Fin)) & ")),0) as CT_Entradas,"
                        G.Tsql &= " IsNull((Select sum(f.Cantidad_Salida) from Movimientos_Inventario f Where f.Compania=a.Compania and f.Obra=a.Obra and f.Almacen=a.Almacen and a.Linea=f.Linea and a.Sub_Linea=f.Sub_Linea and a.Articulo=f.Articulo  and f.E_S='S' and (f.Fecha_Lote>=" & Pone_Apos(Fecha_AMD(Fecha_Inicio)) & " and f.Fecha_Lote<=" & Pone_Apos(Fecha_AMD(Fecha_Fin)) & ")),0) as Salidas, "
                        G.Tsql &= " IsNull((Select sum(i.Costo_Total) from Movimientos_Inventario i Where i.Compania=a.Compania and i.Obra=a.Obra and i.Almacen=a.Almacen and a.Linea=i.Linea and a.Sub_Linea=i.Sub_Linea and a.Articulo=i.Articulo  and i.E_S='S' and (i.Fecha_Lote>=" & Pone_Apos(Fecha_AMD(Fecha_Inicio)) & " and i.Fecha_Lote<=" & Pone_Apos(Fecha_AMD(Fecha_Fin)) & ")),0) as CT_Salidas,"
                        G.Tsql &= "(Select top 1 b.Art_Descripcion from Articulos b Where a.Articulo=b.Numero and b.Cia=" & Val(Session("Cia")) & " and b.Obra=" & Pone_Apos(Session("Obra")) & ") as Art_Descripcion"
                        G.Tsql &= " from Movimientos_Inventario a "
                        G.Tsql &= " left join Linea b on a.Compania=b.Cia and a.Obra=b.Obra and a.Linea=b.Linea"
                        G.Tsql &= " left join Sub_Linea c on a.Linea=c.Lin_Numero and a.Sub_Linea=c.Numero"
                        G.Tsql &= " Where a.Compania=" & G.Empresa_Numero
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & G.Almacen
                        G.Tsql &= " and a.Linea>0 and a.Sub_Linea>0"
                        G.Tsql &= " ORDER BY a.Linea,a.Sub_Linea,a.Articulo"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)

                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Lin_Numero") = f("Lin_Numero")
                            nf("Linea_Desc") = f("Linea_Desc")
                            nf("Sub_Numero") = f("Sub_Numero")
                            nf("SubLinea_Desc") = f("SubLinea_Desc")
                            nf("Numero") = f("Numero")
                            nf("Art_Descripcion") = f("Art_Descripcion")
                            nf("Existencia_Inicial") = NuloADouble(f("Existencia_Inicial"))
                            nf("Entradas_Valuadas") = NuloADouble(f("Entradas"))
                            nf("Salidas_Valuadas") = NuloADouble(f("Salidas"))
                            nf("Existencia_Final") = NuloADouble(f("Existencia_Inicial")) + NuloADouble(f("Entradas")) - NuloADouble(f("Salidas"))
                            nf("CT_Entradas") = f("CT_Entradas")
                            nf("CT_Salidas") = f("CT_Salidas")
                            nf("CT_Existencia_Ini") = f("CT_Existencia_Ini")
                            nf("CT_Existencia_Fin") = NuloADouble(f("CT_Existencia_Ini")) + NuloADouble(f("CT_Entradas")) - NuloADouble(f("CT_Salidas"))
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        If Detalle = "True" Then
                            ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Informe_Mensual3.rdlc"
                            ReportViewer1.LocalReport.ReportPath = "R_Informe_Mensual3.rdlc"
                        Else
                            ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Informe_Mensual.rdlc"
                            ReportViewer1.LocalReport.ReportPath = "R_Informe_Mensual.rdlc"
                        End If
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "NOTA_ENTRADA_IEPS"
                        Dim dt As New dsCrystal.Nota_EntradaDataTable
                        Dim RD As New ReportDataSource
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim Parametros(17) As ReportParameter
                        Dim Fecha_Impresion As String
                        Fecha_Impresion = Fecha_AMD(Now)
                        G.cn.Open()
                        Dim Doc As Object = Nothing
                        G.Tsql = "Select top 1 a.Nombre from Solicitante a inner join Movimientos_Entradas b"
                        G.Tsql &= " on a.Solicitante=b.Solicitante where b.Lote=" & Val(Lote)
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        'If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Imagen)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Entrada", Lote)
                        Parametros(5) = New ReportParameter("Provedor", G.Proveedor_Desc.ToString.ToUpper)
                        'Parametros(7) = New ReportParameter("Solicitante", G.Solicitante_Desc.ToString.ToUpper)
                        If IsNothing(Doc) Then
                            Parametros(6) = New ReportParameter("Solicitante", "")
                        Else
                            Parametros(6) = New ReportParameter("Solicitante", Doc.ToString.ToUpper)
                        End If
                        G.Tsql = "Select a.Articulo,a.Descripcion,a.Cantidad,a.Remision_Factura,a.Precio_Unitario as Precio,Costo_Total,a.Iva_Importe,a.IEPS,a.Base,a.Cuota_Adicional,a.Base_Iva"
                        G.Tsql &= ",(Select r.Unidad_Medida from Articulos r Where r.Cia=" & Session("Cia") & " and r.Obra=" & Pone_Apos(Session("Obra")) & " and r.Numero=a.Articulo) as Unidad_Medida "
                        G.Tsql &= " from Movimientos_Entradas a Where a.Lote=" & Val(Lote)
                        G.Tsql &= " and a.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and a.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and a.Almacen=" & Val(Session("Almacen"))
                        G.Tsql &= " and a.Partida>0"
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        dt.Load(G.dr)
                        If G.dr.IsClosed = False Then G.dr.Close()
                        G.Tsql = "Select top 1 Numero_Documento from Movimientos_Entradas where Lote=" & Val(Lote)
                        G.Tsql &= " and Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and Almacen=" & Val(Session("Almacen"))
                        G.Tsql &= " and Partida >0"
                        G.Tsql &= " and Numero_Documento<>0"
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        If IsNumeric(Doc) Then
                            G.Orden_Compra = Val(Doc)
                        End If
                        If G.dr.IsClosed = False Then G.dr.Close()
                        G.Tsql = "Select top 1 a.Descripcion from Moneda a inner join Movimientos_Entradas b"
                        G.Tsql &= " on a.Moneda=b.Moneda where b.Lote=" & Val(Lote)
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        Parametros(7) = New ReportParameter("Moneda", Doc.ToString.ToUpper)
                        Parametros(8) = New ReportParameter("Requisicion", Val(G.Orden_Compra))
                        Dim Costo_Total As Double = NuloADouble(dt.Compute("Sum(Costo_Total)", ""))
                        Dim Iva_Importe As Double = NuloADouble(dt.Compute("Sum(Iva_Importe)", ""))
                        Dim Sub_Total As Double = NuloADouble(dt.Compute("Sum(Base_IVA)", ""))
                        Parametros(9) = New ReportParameter("Iva_Importe", Iva_Importe)
                        Parametros(17) = New ReportParameter("Subtotal", Sub_Total)
                        Parametros(10) = New ReportParameter("Costo_Total", Costo_Total)
                        Parametros(11) = New ReportParameter("Importe_Flete", G.Importe_Flete)
                        Parametros(12) = New ReportParameter("Referencia", G.Referencia)
                        Parametros(13) = New ReportParameter("UUID", G.UUID)
                        Parametros(14) = New ReportParameter("Proyecto", G.Sucursal_Desc)
                        Parametros(15) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(16) = New ReportParameter("Almacen", G.Almacen_Desc)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Nota_Entradas_IEPS.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Nota_Entradas_IEPS.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "NOTA_ENTRADA"
                        Dim dt As New dsCrystal.Nota_EntradaDataTable
                        Dim RD As New ReportDataSource
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim Parametros(17) As ReportParameter
                        Dim Fecha_Impresion As String
                        Fecha_Impresion = Fecha_AMD(Now)
                        G.cn.Open()
                        Dim Doc As Object = Nothing
                        G.Tsql = "Select top 1 a.Nombre from Solicitante a inner join Movimientos_Entradas b"
                        G.Tsql &= " on a.Solicitante=b.Solicitante where b.Lote=" & Val(Lote)
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        'If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Imagen)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Entrada", Lote)
                        Parametros(5) = New ReportParameter("Provedor", G.Proveedor_Desc.ToString.ToUpper)
                        'Parametros(7) = New ReportParameter("Solicitante", G.Solicitante_Desc.ToString.ToUpper)
                        If IsNothing(Doc) Then
                            Parametros(6) = New ReportParameter("Solicitante", "")
                        Else
                            Parametros(6) = New ReportParameter("Solicitante", Doc.ToString.ToUpper)
                        End If
                        G.Tsql = "Select a.Articulo,a.Descripcion,a.Cantidad,a.Remision_Factura,a.Precio_Unitario as Precio,(a.Cantidad*a.Precio_Unitario) as Importe,a.Iva_Importe"
                        G.Tsql &= ",(Select r.Unidad_Medida from Articulos r Where r.Cia=" & Session("Cia") & " and r.Obra=" & Pone_Apos(Session("Obra")) & " and r.Numero=a.Articulo) as Unidad_Medida "
                        G.Tsql &= " from Movimientos_Entradas a Where a.Lote=" & Val(Lote)
                        G.Tsql &= " and a.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and a.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and a.Almacen=" & Val(Session("Almacen"))
                        G.Tsql &= " and a.Partida>0"
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        dt.Load(G.dr)
                        If G.dr.IsClosed = False Then G.dr.Close()
                        G.Tsql = "Select top 1 Numero_Documento from Movimientos_Entradas where Lote=" & Val(Lote)
                        G.Tsql &= " and Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and Almacen=" & Val(Session("Almacen"))
                        G.Tsql &= " and Partida >0"
                        G.Tsql &= " and Numero_Documento<>0"
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        If IsNumeric(Doc) Then
                            G.Orden_Compra = Val(Doc)
                        End If
                        If G.dr.IsClosed = False Then G.dr.Close()
                        G.Tsql = "Select top 1 a.Descripcion from Moneda a inner join Movimientos_Entradas b"
                        G.Tsql &= " on a.Moneda=b.Moneda where b.Lote=" & Val(Lote)
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        Parametros(7) = New ReportParameter("Moneda", Doc.ToString.ToUpper)
                        Parametros(8) = New ReportParameter("Requisicion", Val(G.Orden_Compra))
                        Dim Importe As Double = NuloADouble(dt.Compute("Sum(Importe)", ""))
                        Dim Iva_Importe As Double = NuloADouble(dt.Compute("Sum(Iva_Importe)", ""))
                        Dim Total As Double = Importe + Iva_Importe
                        Parametros(9) = New ReportParameter("Importe", Importe)
                        Parametros(10) = New ReportParameter("Iva", Iva_Importe)
                        Parametros(11) = New ReportParameter("Total", Total)
                        Parametros(12) = New ReportParameter("Importe_Flete", G.Importe_Flete)
                        Parametros(13) = New ReportParameter("Referencia", G.Referencia)
                        Parametros(14) = New ReportParameter("UUID", G.UUID)
                        Parametros(15) = New ReportParameter("Proyecto", G.Sucursal_Desc)
                        Parametros(16) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(17) = New ReportParameter("Almacen", G.Almacen_Desc)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Nota_Entrada.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Nota_Entrada.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0002"
                        Dim dt As New dsCrystal.Consumo_X_CombustibleDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)

                        G.Tsql = "Select a.Elemento, a.Articulo as Articulo2, a.Articulo,a.Tipo_Costo,a.Lote as Referencia"
                        G.Tsql &= ",a.Descripcion,a.Cantidad,a.Costo,a.Fecha_Lote,a.Movimiento"
                        G.Tsql &= ",(Select top 1  Catalogo from Tipo_Salida b where b.Tipo=a.Movimiento) as Tipo_Elemento"
                        G.Tsql &= " from Movimientos_Inventario a Where a.E_S='S'"
                        G.Tsql &= " and a.Compania=" & G.Empresa_Numero
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & G.Almacen
                        G.Tsql &= " and a.Partida>0"
                        G.Tsql &= " and Movimiento<>0"
                        If Val(Request.QueryString("TpCos").ToString) <> 0 Then
                            G.Tsql &= " and a.Movimiento=" & Val(Request.QueryString("TpCos").ToString)
                        End If
                        If Request.QueryString("Elem_F").ToString <> "" Then
                            G.Tsql &= " and a.Elemento Between " & Pone_Apos(Request.QueryString("Elem_I").ToString) & " and " & Pone_Apos(Request.QueryString("Elem_F").ToString)
                        Else
                            If Request.QueryString("Elem_I").ToString <> "" Then
                                G.Tsql &= " and a.Elemento=" & Pone_Apos(Request.QueryString("Elem_I").ToString)
                            End If
                        End If
                        If Val(Request.QueryString("Act").ToString) <> 0 Then
                            G.Tsql &= " and a.Actividad=" & Val(Request.QueryString("Act").ToString)
                        End If
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        'G.Tsql &= " Order By a.Elemento,a.Articulo,a.Tipo_Costo"
                        G.Tsql &= " Order by Tipo_Costo,Elemento,Articulo"
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.cn.Open()

                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader

                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)

                        If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Elemento As String = ""
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Articulo2") = f("Articulo2")
                            nf("Elemento") = f("Elemento")
                            nf("Tipo_Costo") = f("Tipo_Costo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Referencia") = f("Referencia")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Movimiento") = f("Movimiento")
                            nf("Precio_Unitario") = Val(f("Costo")) / Val(f("Cantidad"))
                            Select Case Val(f("Tipo_Elemento"))
                                Case 0
                                    nf("Tipo_Elemento") = "Económico"
                                    G.Tsql = "Select Descripcion from Economico where Numero=" & Pone_Apos(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                                Case 1
                                    nf("Tipo_Elemento") = "Frente"
                                    G.Tsql = "Select Descripcion from Frente where Frente=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case 2
                                    nf("Tipo_Elemento") = "Obra"
                                    G.Tsql = "Select Descripcion from Obra where Obra=" & Pone_Apos(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                Case 3
                                    nf("Tipo_Elemento") = "Proveedor"
                                    G.Tsql = "Select Razon_Social from Proveedor where Numero=" & Val(f("Elemento"))
                                Case 4
                                    nf("Tipo_Elemento") = "Solicitante"
                                    G.Tsql = "Select Nombre from Solicitante where Solicitante=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case 5
                                    nf("Tipo_Elemento") = "Tercero"
                                    G.Tsql = "Select Descripcion from Terceros where Tercero=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case 6
                                    nf("Tipo_Elemento") = "Area"
                                    G.Tsql = "Select Descripcion from Area where Area=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case Else
                            End Select
                            G.com.CommandText = G.Tsql
                            nf("Elemento_Desc") = AString(G.com.ExecuteScalar)
                            dt.Rows.Add(nf)
                        Next
                        If G.dr.IsClosed = False Then G.dr.Close()
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0002.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0002.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0001"
                        ''Caratula por articulos
                        Dim dt As New dsCrystal.Caratula_ArticulosDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        'Dim cantidad As Double
                        G.Tsql = "Select  a.Articulo,a.Lote,a.Fecha_Lote,a.E_S,a.Cantidad,a.Cantidad_Salida,a.Existencia,a.Precio_Unitario,a.Valor_Inventario,a.Costo_Total as Costo,(a.Existencia*Precio_Unitario) as Total,"
                        G.Tsql &= " ISNULL((Select top 1  b.Existencia from Movimientos_Inventario b where b.Articulo=a.Articulo and b.Numero_Secuencial<a.Numero_Secuencial order by b.Numero_Secuencial DESC ),0) as Saldo_Anterior,"
                        G.Tsql &= " ISNULL((Select top 1  b.Valor_Inventario from Movimientos_Inventario b where b.Articulo=a.Articulo and b.Numero_Secuencial<a.Numero_Secuencial order by b.Numero_Secuencial DESC ),0) as Valor_Anterior,"
                        G.Tsql &= "(Select top 1 b.Art_Descripcion from Articulos b Where a.Articulo=b.Numero and b.Cia=" & Val(Session("Cia")) & " and b.Obra=" & Pone_Apos(Session("Obra")) & ") as Descripcion"
                        G.Tsql &= " from Movimientos_Inventario a Where a.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and a.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and a.Almacen=" & Val(Session("Almacen"))
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and Partida>0 "
                        G.Tsql &= " and Articulo>''"
                        G.Tsql &= " Order by a.Articulo,a.Numero_Secuencial,a.Fecha_Lote,a.E_S,a.Lote"

                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Lote") = f("Lote")
                            nf("Existencia") = f("Existencia")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("saldo_Anterior") = f("Saldo_Anterior")
                            nf("Valor_Anterior") = f("Valor_Anterior")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            'nf("Cantidad") = f("Cantidad") + cantidad
                            If f("E_S") = "E" Then
                                nf("CantidadE") = NuloADouble(f("Cantidad"))
                                nf("CostoE") = NuloADouble(f("Costo"))
                                nf("CantidadS") = "0"
                                nf("CostoS") = "0.00"
                            Else
                                nf("CantidadS") = NuloADouble(f("Cantidad_Salida"))
                                nf("CostoS") = NuloADouble(f("Costo"))
                                nf("CantidadE") = "0"
                                nf("CostoE") = "0.00"
                            End If
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0001.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0001.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0003"
                        ''Compras por proveedor
                        Dim dt As New dsCrystal.Compras_ProveedorDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        G.Tsql = "Select Distinct a.Proveedor, a.Elemento, a.Articulo,a.Tipo_Costo"
                        G.Tsql &= ",a.Descripcion,a.Referencia,a.Cantidad,a.Costo_Total as Costo,a.Fecha_Lote,a.Remision_Factura"
                        G.Tsql &= ",a.Lote,a.Actividad,(Select top 1 b.Razon_Social from Proveedor b where b.Numero=a.Proveedor)"
                        G.Tsql &= " from Movimientos_Inventario a"
                        G.Tsql &= " Where a.Compania=" & G.Empresa_Numero
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & G.Almacen
                        G.Tsql &= " and Proveedor<>0"
                        G.Tsql &= " and Partida>0"
                        If Request.QueryString("Pro_F").ToString <> "" Then
                            G.Tsql &= " and a.Proveedor Between " & Val(Request.QueryString("Pro_I").ToString) & " and " & Val(Request.QueryString("Pro_F").ToString)
                        Else
                            If Request.QueryString("Pro_I").ToString <> "" Then
                                G.Tsql &= " and a.Proveedor=" & Val(Request.QueryString("Pro_I").ToString)
                            End If
                        End If
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        G.Tsql &= " Order By a.Proveedor,a.Fecha_Lote,a.Remision_Factura,a.Articulo"
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.cn.Open()

                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader

                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)

                        If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Elemento As String = ""
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Elemento") = f("Elemento")
                            nf("Referencia") = f("Referencia")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Actividad") = f("Actividad")
                            nf("Tipo_Costo") = f("Tipo_Costo")
                            nf("Remision_Factura") = f("Remision_Factura")
                            nf("Proveedor") = f("Proveedor")
                            nf("Lote") = f("Lote")
                            G.Tsql = "Select Razon_Social from Proveedor where Numero=" & Val(f("Proveedor"))
                            G.com.CommandText = G.Tsql
                            nf("Razon_Social") = AString(G.com.ExecuteScalar)
                            dt.Rows.Add(nf)
                        Next
                        If G.dr.IsClosed = False Then G.dr.Close()
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0003.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0003.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0004"
                        ''Consumo porarticulo
                        Dim dt As New dsCrystal.Cosumo_ArticuloDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        G.Tsql = "Select Distinct a.Articulo, a.Elemento, a.Ref_Aplica,a.Tipo_Costo"
                        G.Tsql &= ",a.Descripcion,a.Cantidad,a.Costo,a.Fecha_Lote,a.Aplicacion"
                        G.Tsql &= ",a.Lote,a.Actividad,(Select top 1 Catalogo from Tipo_Salida b where b.Tipo=a.Movimiento) as Tipo_Elemento"
                        G.Tsql &= " from Movimientos_Inventario a"
                        G.Tsql &= " Where a.Compania=" & G.Empresa_Numero
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & G.Almacen
                        G.Tsql &= " and E_S='S'"
                        G.Tsql &= " and Partida>0"
                        If Val(Request.QueryString("TpCos").ToString) <> 0 Then
                            G.Tsql &= " and a.Movimiento=" & Val(Request.QueryString("TpCos").ToString)
                        End If
                        If Request.QueryString("Elem_F").ToString <> "" Then
                            G.Tsql &= " and a.Elemento Between " & Pone_Apos(Request.QueryString("Elem_I").ToString) & " and " & Pone_Apos(Request.QueryString("Elem_F").ToString)
                        Else
                            If Request.QueryString("Elem_I").ToString <> "" Then
                                G.Tsql &= " and a.Elemento=" & Pone_Apos(Request.QueryString("Elem_I").ToString)
                            End If
                        End If
                        If Val(Request.QueryString("Act").ToString) <> 0 Then
                            G.Tsql &= " and a.Actividad=" & Val(Request.QueryString("Act").ToString)
                        End If
                        If Val(Request.QueryString("Cl").ToString) <> 0 Then
                            G.Tsql &= " and Clasificacion=" & Val(Request.QueryString("Cl").ToString)
                        End If
                        If Val(Request.QueryString("Ref").ToString) <> 0 Then
                            G.Tsql &= " and Ref_Aplica=" & Val(Request.QueryString("Ref").ToString)
                        End If
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        G.Tsql &= " Order By a.Articulo,a.Lote,a.Fecha_Lote"
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.cn.Open()

                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader

                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)

                        If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Elemento As String = ""
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Elemento") = f("Elemento")
                            nf("Tipo_Costo") = f("Tipo_Costo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Cantidad") = Val(f("Cantidad"))
                            nf("Costo") = Val(f("Costo"))
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Lote") = f("Lote")
                            nf("Aplicacion") = f("Aplicacion")
                            nf("Ref_Aplica") = f("Ref_Aplica")
                            nf("Actividad") = f("Actividad")
                            dt.Rows.Add(nf)
                        Next
                        If G.dr.IsClosed = False Then G.dr.Close()
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0004.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0004.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0005"
                        ''Compras por proveedor
                        Dim dt As New dsCrystal.Compras_ProveedorDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        G.Tsql = "Select Distinct a.Proveedor, a.Elemento, a.Articulo,a.Tipo_Costo"
                        G.Tsql &= ",a.Descripcion,a.Referencia,a.Cantidad,a.Costo_Total as Costo,a.Fecha_Lote,a.Remision_Factura"
                        G.Tsql &= ",a.Lote,a.Actividad,(Select top 1 b.Razon_Social from Proveedor b where b.Numero=a.Proveedor)"
                        G.Tsql &= " from Movimientos_Inventario a"
                        G.Tsql &= " Where a.Compania=" & G.Empresa_Numero
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & G.Almacen
                        'G.Tsql &= " and Proveedor<>0"
                        G.Tsql &= " and a.Movimiento=" & Val(Request.QueryString("Mov"))
                        G.Tsql &= " and Partida>0"
                        G.Tsql &= " and E_S='S'"
                        If Request.QueryString("Pro_F").ToString <> "" Then
                            G.Tsql &= " and a.Proveedor Between " & Val(Request.QueryString("Pro_I").ToString) & " and " & Val(Request.QueryString("Pro_F").ToString)
                        Else
                            If Request.QueryString("Pro_I").ToString <> "" Then
                                G.Tsql &= " and a.Proveedor=" & Val(Request.QueryString("Pro_I").ToString)
                            End If
                        End If
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        G.Tsql &= " Order By a.Proveedor,a.Fecha_Lote,a.Remision_Factura,a.Articulo"
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.cn.Open()

                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader

                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)

                        If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Elemento As String = ""
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Elemento") = f("Elemento")
                            nf("Referencia") = f("Referencia")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Actividad") = f("Actividad")
                            nf("Tipo_Costo") = f("Tipo_Costo")
                            nf("Remision_Factura") = f("Remision_Factura")
                            nf("Proveedor") = f("Proveedor")
                            nf("Lote") = f("Lote")
                            G.Tsql = "Select Razon_Social from Proveedor where Numero=" & Val(f("Proveedor"))
                            G.com.CommandText = G.Tsql
                            nf("Razon_Social") = AString(G.com.ExecuteScalar)
                            dt.Rows.Add(nf)
                        Next
                        If G.dr.IsClosed = False Then G.dr.Close()
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0005.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0005.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0006"
                        ''Entradas por articulos
                        Dim dt As New dsCrystal.Compras_ProveedorDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Articulo, a.Elemento, a.Proveedor,a.Tipo_Costo"
                        G.Tsql &= ",a.Descripcion,a.Referencia,a.Cantidad,a.Costo_Total as Costo,a.Fecha_Lote,a.Remision_Factura"
                        G.Tsql &= ",a.Lote,a.Actividad,(Select top 1 b.Razon_Social from Proveedor b where b.Numero=a.Proveedor) as Razon_Social"
                        G.Tsql &= " from Movimientos_Inventario a Where a.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and a.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and a.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and E_S='E'"
                        G.Tsql &= " and Proveedor>0"
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and Partida>0 Order by a.Articulo,a.Lote"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Elemento") = f("Elemento")
                            nf("Referencia") = f("Referencia")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Actividad") = f("Actividad")
                            nf("Tipo_Costo") = f("Tipo_Costo")
                            nf("Remision_Factura") = f("Remision_Factura")
                            nf("Proveedor") = f("Proveedor")
                            nf("Lote") = f("Lote")
                            nf("Razon_Social") = AString(f("Razon_Social"))
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0006.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0006.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "EXISTENCIAS_FISICAS", "R_0007"
                        Dim dt As New dsCrystal.Lento_MovimientoDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(7) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Dim fecha_hoy As Date = Fecha_AMD(Now)
                        Parametros(4) = New ReportParameter("Fecha1", Fecha_AMD(Now))
                        Parametros(5) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(7) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select distinct a.Articulo, a.Linea, a.Sub_Linea as Sublinea"
                        'G.Tsql &= ",(Select top 1 b.Precio_Unitario from Movimientos_Inventario b Where b.Compania=a.Compania and b.Obra=a.Obra and b.Almacen=a.Almacen"
                        'G.Tsql &= " and a.Linea=b.Linea and a.Sub_Linea=b.Sub_Linea and a.Articulo=b.Articulo order by b.Numero_Secuencial desc ) as Precio_Unitario"
                        G.Tsql &= ",(Select top 1 c.Existencia from Movimientos_Inventario c Where c.Compania=a.Compania and c.Obra=a.Obra and c.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=c.Linea and a.Sub_Linea=c.Sub_Linea and a.Articulo=c.Articulo order by c.Numero_Secuencial desc ) as Existencia"
                        G.Tsql &= ",(Select top 1 d.Valor_Inventario from Movimientos_Inventario d Where d.Compania=a.Compania and d.Obra=a.Obra and d.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=d.Linea and a.Sub_Linea=d.Sub_Linea and a.Articulo=d.Articulo order by d.Numero_Secuencial desc ) as Valor_Inventario"
                        G.Tsql &= ",(Select top 1 d.Fecha_Lote from Movimientos_Inventario d Where d.Compania=a.Compania and d.Obra=a.Obra and d.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=d.Linea and a.Sub_Linea=d.Sub_Linea and a.Articulo=d.Articulo and E_S='S' order by d.Numero_Secuencial desc ) as Ultima_Salida"
                        G.Tsql &= ",(Select top 1 f.Descripcion from Linea f where f.Linea=a.Linea and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(Session("Obra")) & ") as Linea_Descripcion"
                        G.Tsql &= ",(Select top 1 g.Descripcion from Sub_Linea g where g.Numero=a.Sub_Linea and g.Lin_Numero=a.Linea) as Sublinea_Descripcion"
                        'G.Tsql &= ",(Select top 1 b.Unidad_Medida from Movimientos_Inventario b Where b.Compania=a.Compania and b.Obra=a.Obra and b.Almacen=a.Almacen"
                        'G.Tsql &= " and a.Linea=b.Linea and a.Sub_Linea=b.Sub_Linea and a.Articulo=b.Articulo order by b.Numero_Secuencial desc ) as Unidad_Medida"
                        G.Tsql &= ",(Select top 1 b.Unidad_Medida from Articulos b Where a.Articulo=b.Numero and b.Cia=" & Val(Session("Cia")) & " and b.Obra=" & Pone_Apos(Session("Obra")) & ") as Unidad_Medida"
                        G.Tsql &= ",(Select top 1 b.Art_Descripcion from Articulos b Where a.Articulo=b.Numero and b.Cia=" & Val(Session("Cia")) & " and b.Obra=" & Pone_Apos(Session("Obra")) & ") as Descripcion"
                        G.Tsql &= " from Movimientos_Inventario a Where a.Compania=" & Val(Session("Cia")) & "and a.Existencia>0 and a.Obra=" & Session("Obra") & " and a.Almacen=" & Val(Session("Almacen")) & " and a.Linea>0 and a.Sub_Linea>0"
                        If Request.QueryString("LinF").ToString <> "" Then
                            G.Tsql &= " and a.Linea Between " & Pone_Apos(Request.QueryString("LinI").ToString) & " and " & Pone_Apos(Request.QueryString("LinF").ToString)
                        Else
                            If Request.QueryString("LinI").ToString <> "" Then
                                G.Tsql &= " and a.Linea=" & Pone_Apos(Request.QueryString("LinI").ToString)
                            End If
                        End If
                        'G.Tsql &= " and (a.Fecha_Lote>=" & Pone_Apos(G.Fecha_Ini) & " and a.Fecha_Lote<=" & Pone_Apos(G.Fecha_Fin) & ")"
                        G.Tsql &= " ORDER BY a.Linea,a.Sub_Linea,a.Articulo"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)
                        Dim Ultima_Salida As Date
                        Dim dias As Integer
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            If f("Existencia") > 0 Then
                                Dim nf As DataRow = dt.NewRow
                                nf("Articulo") = f("Articulo").ToString.ToUpper
                                nf("Descripcion") = f("Descripcion").ToString.ToUpper
                                nf("Linea") = f("Linea")
                                nf("Linea_Descripcion") = f("Linea_Descripcion").ToString.ToUpper
                                nf("Sublinea") = f("Sublinea")
                                nf("Sublinea_Descripcion") = f("Sublinea_Descripcion").ToString.ToUpper
                                nf("Existencia") = f("Existencia")
                                nf("Valor_Inventario") = f("Valor_Inventario")
                                'nf("Precio_Unitario") = f("Precio_Unitario")
                                nf("Precio_Unitario") = Math.Round(f("Valor_Inventario") / f("Existencia"), 4)
                                nf("Unidad_Medida") = f("Unidad_Medida").ToString.ToUpper
                                If AString(f("Ultima_Salida")) <> "" Then
                                    Ultima_Salida = f("Ultima_Salida")
                                    dias = DateDiff(DateInterval.Day, Ultima_Salida, fecha_hoy)
                                    nf("Dias_Diferencia") = dias
                                Else
                                    nf("Dias_Diferencia") = 0
                                End If
                                dt.Rows.Add(nf)
                            End If
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0007.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0007.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0010"
                        'Lento Movimiento'
                        Dim dt As New dsCrystal.Lento_MovimientoDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(7) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Dim fecha_hoy As Date = Fecha_AMD(Now)
                        Parametros(4) = New ReportParameter("Fecha1", Fecha_AMD(Now))
                        Parametros(5) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(7) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select distinct a.Articulo, a.Linea, a.Sub_Linea as Sublinea, a.Descripcion"
                        G.Tsql &= ",(Select top 1 b.Precio_Unitario from Movimientos_Inventario b Where b.Compania=a.Compania and b.Obra=a.Obra and b.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=b.Linea and a.Sub_Linea=b.Sub_Linea and a.Articulo=b.Articulo order by b.Numero_Secuencial desc ) as Precio_Unitario"
                        G.Tsql &= ",(Select top 1 c.Existencia from Movimientos_Inventario c Where c.Compania=a.Compania and c.Obra=a.Obra and c.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=c.Linea and a.Sub_Linea=c.Sub_Linea and a.Articulo=c.Articulo order by c.Numero_Secuencial desc ) as Existencia"
                        G.Tsql &= ",(Select top 1 d.Valor_Inventario from Movimientos_Inventario d Where d.Compania=a.Compania and d.Obra=a.Obra and d.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=d.Linea and a.Sub_Linea=d.Sub_Linea and a.Articulo=d.Articulo order by d.Numero_Secuencial desc ) as Valor_Inventario"
                        G.Tsql &= ",(Select top 1 d.Fecha_Lote from Movimientos_Inventario d Where d.Compania=a.Compania and d.Obra=a.Obra and d.Almacen=a.Almacen"
                        G.Tsql &= " and a.Linea=d.Linea and a.Sub_Linea=d.Sub_Linea and a.Articulo=d.Articulo and E_S='S' order by d.Numero_Secuencial desc ) as Ultima_Salida"
                        G.Tsql &= ",(Select top 1 f.Descripcion from Linea f where f.Linea=a.Linea and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(Session("Obra")) & ") as Linea_Descripcion"
                        G.Tsql &= ",(Select top 1 g.Descripcion from Sub_Linea g where g.Numero=a.Sub_Linea and g.Lin_Numero=a.Linea) as Sublinea_Descripcion"
                        'G.Tsql &= ",(Select top 1 b.Unidad_Medida from Movimientos_Inventario b Where b.Compania=a.Compania and b.Obra=a.Obra and b.Almacen=a.Almacen"
                        'G.Tsql &= " and a.Linea=b.Linea and a.Sub_Linea=b.Sub_Linea and a.Articulo=b.Articulo order by b.Numero_Secuencial desc ) as Unidad_Medida"
                        G.Tsql &= ",(Select top 1 b.Unidad_Medida from Articulos b Where a.Articulo=b.Numero and b.Cia=" & Val(Session("Cia")) & " and b.obra=" & Pone_Apos(G.Sucursal) & ") as Unidad_Medida"
                        G.Tsql &= " from Movimientos_Inventario a Where a.Compania=1 and a.Obra='OBRA1' and a.Almacen=3 and a.Linea>0 "
                        If Request.QueryString("LinF").ToString <> "" Then
                            G.Tsql &= " and a.Linea Between " & Pone_Apos(Request.QueryString("LinI").ToString) & " and " & Pone_Apos(Request.QueryString("LinF").ToString)
                        Else
                            If Request.QueryString("LinI").ToString <> "" Then
                                G.Tsql &= " and a.Linea=" & Pone_Apos(Request.QueryString("LinI").ToString)
                            End If
                        End If
                        G.Tsql &= " ORDER BY a.Linea,a.Sub_Linea,a.Articulo"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)
                        Dim Ultima_Salida As Date
                        Dim dias As Integer
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo").ToString.ToUpper
                            nf("Descripcion") = f("Descripcion").ToString.ToUpper
                            nf("Linea") = f("Linea")
                            nf("Linea_Descripcion") = f("Linea_Descripcion").ToString.ToUpper
                            nf("Sublinea") = f("Sublinea")
                            nf("Sublinea_Descripcion") = f("Sublinea_Descripcion").ToString.ToUpper
                            nf("Existencia") = f("Existencia")
                            nf("Valor_Inventario") = f("Valor_Inventario")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("Unidad_Medida") = f("Unidad_Medida").ToString.ToUpper
                            If AString(f("Ultima_Salida")) <> "" Then
                                Ultima_Salida = f("Ultima_Salida")
                                dias = DateDiff(DateInterval.Day, Ultima_Salida, fecha_hoy)
                                nf("Dias_Diferencia") = dias
                            Else
                                nf("Dias_Diferencia") = 0
                            End If
                            dt.Rows.Add(nf)
                        Next
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0010.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0010.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0009"
                        Dim dt As New dsCrystal.Consumo_X_CombustibleDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(8) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        G.Tsql = "Select distinct a.Elemento, a.Articulo as Articulo2, a.Articulo,a.Tipo_Costo,a.Lote as Referencia"
                        G.Tsql &= ",a.Descripcion,a.Cantidad,a.Costo,a.Fecha_Lote,a.Movimiento"
                        G.Tsql &= ",(Select top 1 Catalogo from Tipo_Salida b where b.Tipo=a.Movimiento) as Tipo_Elemento"
                        G.Tsql &= " from Movimientos_Inventario a Where a.E_S='S'"
                        G.Tsql &= " and a.Compania=" & G.Empresa_Numero
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & G.Almacen
                        G.Tsql &= " and a.Partida>0"
                        G.Tsql &= " and Movimiento<>0"
                        If Val(Request.QueryString("TpCos").ToString) <> 0 Then
                            G.Tsql &= " and a.Movimiento=" & Val(Request.QueryString("TpCos").ToString)
                        End If
                        If Request.QueryString("Elem_F").ToString <> "" Then
                            G.Tsql &= " and a.Elemento Between " & Pone_Apos(Request.QueryString("Elem_I").ToString) & " and " & Pone_Apos(Request.QueryString("Elem_F").ToString)
                        Else
                            If Request.QueryString("Elem_I").ToString <> "" Then
                                G.Tsql &= " and a.Elemento=" & Pone_Apos(Request.QueryString("Elem_I").ToString)
                            End If
                        End If
                        If Val(Request.QueryString("Act").ToString) <> 0 Then
                            G.Tsql &= " and a.Actividad=" & Val(Request.QueryString("Act").ToString)
                        End If
                        If Request.QueryString("Art_F").ToString <> "" Then
                            G.Tsql &= " and a.Articulo Between " & Pone_Apos(Request.QueryString("Art_I").ToString) & " and " & Pone_Apos(Request.QueryString("Art_F").ToString)
                        Else
                            If Request.QueryString("Art_I").ToString <> "" Then
                                G.Tsql &= " and a.Articulo=" & Pone_Apos(Request.QueryString("Art_I").ToString)
                            End If
                        End If
                        G.Tsql &= " and a.Fecha_Lote Between " & Pone_Apos(Request.QueryString("Fecha_Inicio").ToString) & " and " & Pone_Apos(Request.QueryString("Fecha_Fin").ToString)
                        'G.Tsql &= " Order By a.Elemento,a.Articulo,a.Tipo_Costo"
                        G.Tsql &= " Order by Tipo_Costo,Elemento,Articulo"
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Parametros(6) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(7) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(8) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.cn.Open()

                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader

                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)

                        If G.dr.IsClosed = False Then G.dr.Close()
                        Dim Elemento As String = ""
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Articulo2") = f("Articulo2")
                            nf("Elemento") = f("Elemento")
                            nf("Tipo_Costo") = f("Tipo_Costo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Referencia") = f("Referencia")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Movimiento") = f("Movimiento")
                            nf("Precio_Unitario") = Val(f("Costo")) / Val(f("Cantidad"))
                            Select Case Val(f("Tipo_Elemento"))
                                Case 0
                                    nf("Tipo_Elemento") = "Económico"
                                    G.Tsql = "Select Descripcion from Economico where Numero=" & Pone_Apos(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                                Case 1
                                    nf("Tipo_Elemento") = "Frente"
                                    G.Tsql = "Select Descripcion from Frente where Frente=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case 2
                                    nf("Tipo_Elemento") = "Obra"
                                    G.Tsql = "Select Descripcion from Obra where Obra=" & Pone_Apos(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                Case 3
                                    nf("Tipo_Elemento") = "Proveedor"
                                    G.Tsql = "Select Razon_Social from Proveedor where Numero=" & Val(f("Elemento"))
                                Case 4
                                    nf("Tipo_Elemento") = "Solicitante"
                                    G.Tsql = "Select Nombre from Solicitante where Solicitante=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case 5
                                    nf("Tipo_Elemento") = "Tercero"
                                    G.Tsql = "Select Descripcion from Terceros where Tercero=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case 6
                                    nf("Tipo_Elemento") = "Area"
                                    G.Tsql = "Select Descripcion from Area where Area=" & Val(f("Elemento"))
                                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                                Case Else
                            End Select
                            G.com.CommandText = G.Tsql
                            nf("Elemento_Desc") = AString(G.com.ExecuteScalar)
                            dt.Rows.Add(nf)
                        Next
                        If G.dr.IsClosed = False Then G.dr.Close()
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0009.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0009.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0012"
                        Dim dt As New dsCrystal.Movimientos_SolicitanteDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(9) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Dim Solicitante As String
                        G.Tsql = "Select Nombre from Solicitante where Solicitante=" & Val(Request.QueryString("Sol"))
                        G.Tsql &= " and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(Session("Obra"))
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        Solicitante = AString(G.com.ExecuteScalar)
                        Parametros(6) = New ReportParameter("Solicitante", Solicitante)
                        Parametros(7) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(8) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(9) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Articulo, a.Descripcion, a.Costo_Total as Costo, a.Cantidad,a.Lote,a.Fecha_Lote,a.Remision_Factura,a.Solicitante"
                        G.Tsql &= " from Movimientos_Inventario a"
                        G.Tsql &= " where a.Compania=" & Val(Session("Cia")) & " and a.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and a.Solicitante=" & Val(Request.QueryString("Sol"))
                        G.Tsql &= " and a.E_S='E'"
                        G.Tsql &= " and Partida>0"
                        G.Tsql &= " Order by a.Fecha_Lote,a.Lote,a.Articulo"
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")
                            nf("Factura") = f("Remision_Factura")
                            nf("Lote") = f("Lote")
                            nf("Solicitante") = f("Solicitante")
                            dt.Rows.Add(nf)
                        Next
                        If Session("dt").Rows.Count = 0 Then
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = ""
                            nf("Descripcion") = ""
                            nf("Cantidad") = 0.0
                            nf("Costo") = 0.0
                            nf("Fecha_Lote") = ""
                            nf("Factura") = ""
                            nf("Lote") = ""
                            nf("Solicitante") = Val(Request.QueryString("Sol"))
                            dt.Rows.Add(nf)
                        End If

                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0012.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0012.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_0013"
                        Dim dt As New dsCrystal.Movimientos_SolicitanteDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(9) As ReportParameter
                        Parametros(0) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(1) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Parametros(4) = New ReportParameter("Fecha_Inicial", Request.QueryString("Fecha_Inicio").ToString)
                        Parametros(5) = New ReportParameter("Fecha_Final", Request.QueryString("Fecha_Fin").ToString)
                        Dim Solicitante As String
                        G.Tsql = "Select Nombre from Solicitante where Solicitante=" & Val(Request.QueryString("Sol"))
                        G.Tsql &= " and Cia=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(Session("Obra"))
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        Solicitante = AString(G.com.ExecuteScalar)
                        Parametros(6) = New ReportParameter("Solicitante", Solicitante)
                        Parametros(7) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(8) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(9) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Articulo, a.Descripcion, a.Costo as Costo, a.Cantidad,a.Lote,a.Fecha_Lote,a.Remision_Factura,a.Solicitante"
                        G.Tsql &= " from Movimientos_Inventario a"
                        G.Tsql &= " where a.Compania=" & Val(Session("Cia")) & " and a.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and a.Solicitante=" & Val(Request.QueryString("Sol"))
                        G.Tsql &= " and a.E_S='S'"
                        G.Tsql &= " and Partida>0"
                        G.Tsql &= " Order by a.Fecha_Lote,a.Lote,a.Articulo"
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader
                        Session("dt") = New DataTable
                        Session("dt").load(G.dr)
                        If G.dr.IsClosed = False Then G.dr.Close()
                        For Each f As DataRow In Session("dt").Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Cantidad") = f("Cantidad")
                            nf("Costo") = f("Costo")
                            nf("Fecha_Lote") = f("Fecha_Lote")

                            nf("Factura") = f("Remision_Factura")
                            nf("Lote") = f("Lote")
                            nf("Solicitante") = f("Solicitante")
                            dt.Rows.Add(nf)
                        Next
                        If Session("dt").Rows.Count = 0 Then
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = ""
                            nf("Descripcion") = ""
                            nf("Cantidad") = 0.0
                            nf("Costo") = 0.0
                            nf("Fecha_Lote") = ""
                            nf("Factura") = ""
                            nf("Lote") = ""
                            nf("Solicitante") = Val(Request.QueryString("Sol"))
                            dt.Rows.Add(nf)
                        End If

                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_0013.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_0013.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "ENTRADAS_ALMACEN"
                        Dim dt As New Ds_Entradas.MovimientosDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(5) As ReportParameter
                        G.cn.Open()
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Dim ObraReporte As String = G.Sucursal & " - " & G.Sucursal_Desc
                        Parametros(4) = New ReportParameter("Obra", ObraReporte)
                        Parametros(5) = New ReportParameter("Almacen", G.Almacen)
                        G.com.CommandText = "Select Lote,Partida,Fecha_Lote,Articulo,Descripcion,Cantidad,Almacen,Centro_Costos,Referencia"
                        G.com.CommandText &= " from Movimientos_Entradas Where Compania=" & Session("Cia")
                        G.com.CommandText &= " and Obra=" & Pone_Apos(G.Sucursal)
                        G.com.CommandText &= " and Almacen=" & Val(G.Almacen)
                        G.com.CommandText &= " and Partida>0 and E_S='E' "
                        G.com.CommandText &= " and Lote=" & Val(Lote)
                        G.dr = G.com.ExecuteReader
                        Dim dt_Datos As New DataTable
                        dt_Datos.Load(G.dr)
                        G.cn.Close()
                        If dt_Datos.Rows.Count > 0 Then
                            For Each f As DataRow In dt_Datos.Rows
                                Dim nf As DataRow = dt.NewRow
                                nf("Lote") = AString(f("Lote"))
                                nf("Partida") = AString(f("Partida"))
                                nf("Fecha") = AString(f("Fecha_Lote"))
                                nf("Articulo") = AString(f("Articulo"))
                                nf("Descripcion") = AString(f("Descripcion"))
                                nf("Cantidad") = AString(f("Cantidad"))
                                nf("Almacen") = AString(f("Almacen"))
                                nf("Centro_Costos") = AString(f("Centro_Costos"))
                                nf("Referencia") = AString(f("Referencia"))
                                dt.Rows.Add(nf)
                            Next
                        End If
                        RD.Value = dt
                        RD.Name = "Movimientos"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Movimientos.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Movimientos.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "ALMACEN_DETALLE"
                        Dim dt As New Ds_Entradas.MovimientosDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(5) As ReportParameter
                        G.cn.Open()
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Hora", Format(Now, "HH:mm:ss"))
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(3) = New ReportParameter("Imagen", Imagen)
                        Dim ObraReporte As String = G.Sucursal & " " & G.Sucursal_Desc
                        Parametros(4) = New ReportParameter("Obra", ObraReporte)
                        Parametros(5) = New ReportParameter("Almacen", G.Almacen)
                        G.com.CommandText = "Select a.Lote,a.Partida,a.Fecha_Lote,a.Articulo,a.Descripcion,a.Cantidad,a.Almacen,a.Centro_Costos,a.Referencia,"
                        G.com.CommandText &= "(Select top 1 UUID from Movimientos_Entradas Where Compania=a.Compania and Obra=a.Obra and Almacen=a.Almacen and E_S='E' and Lote=a.Lote and Partida=0) as UUID"
                        G.com.CommandText &= " from Movimientos_Entradas a Where E_S='E' and Compania=" & Session("Cia") & " and Obra=" & Pone_Apos(Session("Obra"))
                        G.com.CommandText &= " and a.Almacen=" & Val(G.Almacen)
                        If Val(G.Ini_Entrada) > 0 And Val(G.Fin_Entrada) > 0 Then
                            G.com.CommandText &= " and a.Lote>=" & Val(G.Ini_Entrada)
                            G.com.CommandText &= " and a.Lote<=" & Val(G.Fin_Entrada)
                        End If
                        If Val(G.Ini_Almacen) > 0 And Val(G.Fin_Almacen) > 0 Then
                            G.com.CommandText &= " and a.Almacen>=" & Val(G.Ini_Almacen)
                            G.com.CommandText &= " and a.Almacen<=" & Val(G.Fin_Almacen)
                        End If
                        If G.Ch_Fechas = True Then
                            If G.Fecha_Ini <> "" And G.Fecha_Fin <> "" Then
                                G.com.CommandText &= " and a.Fecha_Lote>=" & Pone_Apos(G.Fecha_Ini)
                                G.com.CommandText &= " and a.Fecha_Lote<=" & Pone_Apos(G.Fecha_Fin)
                            End If
                        End If
                        G.dr = G.com.ExecuteReader
                        Dim dt_Datos As New DataTable
                        dt_Datos.Load(G.dr)
                        G.cn.Close()

                        If dt_Datos.Rows.Count > 0 Then
                            For Each f As DataRow In dt_Datos.Rows
                                Dim nf As DataRow = dt.NewRow
                                nf("Lote") = AString(f("Lote"))
                                nf("Partida") = AString(f("Partida"))
                                nf("Fecha") = AString(f("Fecha_Lote"))
                                nf("Articulo") = AString(f("Articulo"))
                                nf("Descripcion") = AString(f("Descripcion"))
                                nf("Cantidad") = AString(f("Cantidad"))
                                nf("Almacen") = AString(f("Almacen"))
                                nf("Centro_Costos") = AString(f("Centro_Costos"))
                                nf("Referencia") = AString(f("Referencia"))
                                nf("UUID") = AString(f("UUID"))
                                dt.Rows.Add(nf)
                            Next
                        End If
                        RD.Value = dt
                        RD.Name = "Movimientos02"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Movimientos02.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Movimientos02.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_VSalida"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New dsCrystal.Salida_NormalDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(17) As ReportParameter
                        Parametros(0) = New ReportParameter("Folio_Salida", G.Numero_Lote)
                        Parametros(1) = New ReportParameter("Nombre_Solicitante", G.VF_Solicitante)
                        Parametros(2) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)
                        Parametros(3) = New ReportParameter("Num_Elemento", G.VF_Elemento)
                        Parametros(4) = New ReportParameter("Desc_Elemento", G.VF_Elemento_Descripcion)
                        Parametros(5) = New ReportParameter("Desc_Actividad", G.VF_Actividad_Descripcion)
                        Parametros(6) = New ReportParameter("Fecha_Lote", G.VF_Fecha_Lote)
                        Parametros(7) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(8) = New ReportParameter("Logotipo", Server.MapPath("./Trabajo/" & Session("Imagen")))
                        Parametros(9) = New ReportParameter("Tipo_Elemento", G.VF_Tipo_Elemento)
                        Parametros(10) = New ReportParameter("Salida", G.VF_Salida)
                        Parametros(11) = New ReportParameter("Salida_Desc", G.VF_Salida_Desc)
                        Parametros(12) = New ReportParameter("Clasificacion_Desc", G.VF_Clas_Desc)
                        Parametros(13) = New ReportParameter("Referencia_Desc", G.VF_Ref_Des)
                        Parametros(14) = New ReportParameter("Cuenta", G.VF_Cuenta)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(15) = New ReportParameter("Imagen", Imagen)
                        Dim ObraReporte As String = G.Sucursal & " " & G.Sucursal_Desc
                        Parametros(16) = New ReportParameter("Obra", ObraReporte)

                        G.Tsql = "Select Articulo,Descripcion,Unidad_Medida,Cantidad,Precio_Unitario,Costo_Total"
                        G.Tsql &= " from Movimientos_Inventario left join Compañias"
                        G.Tsql &= " on Movimientos_Inventario.Compania=Compañias.Cia"
                        G.Tsql &= " where Movimientos_Inventario.Lote=" & G.Numero_Lote
                        G.Tsql &= " and Movimientos_Inventario.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Movimientos_Inventario.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and Movimientos_Inventario.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and E_S='S'"
                        G.Tsql &= " and Partida>0"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Detalle_Salida As New DataTable
                        dt_Detalle_Salida.Load(G.dr)
                        Dim f As DataRow
                        Dim total As Double = 0
                        For Each f In dt_Detalle_Salida.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Unidad_Medida") = f("Unidad_Medida")
                            nf("Cantidad") = f("Cantidad")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("Costo_Total") = f("Costo_Total")
                            dt.Rows.Add(nf)
                            total = total + nf("Costo_Total")
                        Next
                        Parametros(17) = New ReportParameter("Importe_Total", total)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_VSalida.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_VSalida.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_MSalida"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New dsCrystal.Salida_MultipleDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(9) As ReportParameter
                        Parametros(0) = New ReportParameter("Folio_Salida", G.Numero_Lote)
                        Parametros(1) = New ReportParameter("Nombre_Solicitante", G.VF_Solicitante)
                        Parametros(2) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)
                        Parametros(3) = New ReportParameter("Fecha_Lote", G.Fecha_Lote)
                        Parametros(4) = New ReportParameter("Compañia", G.RazonSocial)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(5) = New ReportParameter("Imagen", Imagen)
                        Parametros(6) = New ReportParameter("Salida", G.VF_Salida)
                        Parametros(7) = New ReportParameter("Salida_Desc", G.VF_Salida_Desc)
                        Dim ObraReporte As String = G.Sucursal & " " & G.Sucursal_Desc
                        Parametros(8) = New ReportParameter("Obra", ObraReporte)
                        Dim Total_Salida As Double = 0
                        G.Tsql = "Select Elemento,Articulo,Descripcion,Cantidad,Precio_Unitario,Costo_Total AS Total,Logo"
                        G.Tsql &= " from Movimientos_Inventario left join Compañias"
                        G.Tsql &= " on Movimientos_Inventario.Compania=Compañias.Cia"
                        G.Tsql &= " where Movimientos_Inventario.Lote=" & G.Numero_Lote
                        G.Tsql &= " and Movimientos_Inventario.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Movimientos_Inventario.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and Movimientos_Inventario.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and E_S='S'"
                        G.Tsql &= " and Partida>0"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Detalle_Salida As New DataTable
                        dt_Detalle_Salida.Load(G.dr)
                        Dim f As DataRow
                        For Each f In dt_Detalle_Salida.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Elemento") = f("Elemento")
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Cantidad") = f("Cantidad")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("Total") = f("Total")
                            nf("Logo") = f("Logo")
                            dt.Rows.Add(nf)
                            Total_Salida = Total_Salida + nf("Total")
                        Next
                        Parametros(9) = New ReportParameter("Importe_Total", Total_Salida)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_MSalida.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_MSalida.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_RE_SALIDAM"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New dsCrystal.Salida_MultipleDataTable
                        Dim RD As New ReportDataSource
                        Dim Parametros(9) As ReportParameter
                        Parametros(0) = New ReportParameter("Folio_Salida", G.Numero_Lote)
                        G.Tsql = "Select top 1 Nombre from Solicitante d inner join Movimientos_Inventario a on d.Solicitante=a.Solicitante Where d.Cia=a.Compania and d.Obra=a.Obra and a.Lote=" & Val(G.Numero_Lote)
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.VF_Solicitante = G.com.ExecuteScalar
                        G.cn.Close()
                        Parametros(1) = New ReportParameter("Nombre_Solicitante", G.VF_Solicitante)
                        Parametros(2) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)
                        Parametros(3) = New ReportParameter("Fecha_Lote", G.Fecha_Lote)
                        Parametros(4) = New ReportParameter("Compañia", G.RazonSocial)

                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(5) = New ReportParameter("Imagen", Imagen)
                        Parametros(6) = New ReportParameter("Salida", G.VF_Salida)
                        Parametros(7) = New ReportParameter("Salida_Desc", G.VF_Salida_Desc)
                        Dim ObraReporte As String = G.Sucursal & " " & G.Sucursal_Desc
                        Parametros(8) = New ReportParameter("Obra", ObraReporte)
                        Dim Total_Salida As Double = 0
                        G.Tsql = "Select Elemento,Articulo,Descripcion,Cantidad,Precio_Unitario,Costo_Total AS Total,Logo"
                        G.Tsql &= " from Movimientos_Inventario left join Compañias"
                        G.Tsql &= " on Movimientos_Inventario.Compania=Compañias.Cia"
                        G.Tsql &= " where Movimientos_Inventario.Lote=" & G.Numero_Lote
                        G.Tsql &= " and Movimientos_Inventario.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Movimientos_Inventario.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and Movimientos_Inventario.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and E_S='S'"
                        G.Tsql &= " and Partida>0"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Detalle_Salida As New DataTable
                        dt_Detalle_Salida.Load(G.dr)
                        Dim f As DataRow
                        For Each f In dt_Detalle_Salida.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Elemento") = f("Elemento")
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Cantidad") = f("Cantidad")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("Total") = f("Total")
                            nf("Logo") = f("Logo")
                            dt.Rows.Add(nf)
                            Total_Salida = Total_Salida + nf("Total")
                        Next
                        Parametros(9) = New ReportParameter("Importe_Total", Total_Salida)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Impresion_Salidas_Multiple.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Impresion_Salidas_Multiple.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_MOVIMIENTOS"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New ds_Movimientos.MovimientosDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        Dim Parametros(14) As ReportParameter
                        Dim Image1 As String = "file:" & MapPath("~/Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Image1)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Hora)
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Usuario", G.UsuarioReal)
                        Parametros(5) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(7) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Lote,a.Partida,a.Flete,a.Fecha_Lote,a.Articulo,a.Descripcion,Precio_Unitario as Precio,a.Remision_Factura,a.Iva_Importe,(Cantidad*Precio_Unitario) as Importe,a.Cantidad,a.Almacen,a.Centro_Costos,a.Referencia,a.Numero_Documento as Orden_Compra,"
                        G.Tsql &= "IsNull((Select top 1 UUID from Movimientos_Entradas Where Compania=a.Compania and Obra=a.Obra and Almacen=a.Almacen and E_S='E' and Lote=a.Lote and Partida=0),'') as UUID"
                        G.Tsql &= ",(Select r.Unidad_Medida from Articulos r Where r.Cia=" & Session("Cia") & " and r.Obra=" & Pone_Apos(Session("Obra")) & " and r.Numero=a.Articulo) as Unidad_Medida "
                        G.Tsql &= ",IsNull((Select Razon_Social from Proveedor Where Numero=a.Proveedor),'') as Proveedor_Desc"
                        G.Tsql &= ",IsNull((Select Nombre from Solicitante d Where d.Solicitante=a.Solicitante and d.Cia=a.Compania and d.Obra=a.Obra),'') as Solicitante_Desc"
                        G.Tsql &= " from Movimientos_Inventario a "

                        G.Tsql &= " Where a.E_S='E' and a.Compania=" & Session("Cia") & " and a.Obra=" & Pone_Apos(Session("Obra"))
                        If Val(G.Ini_Entrada) > 0 And Val(G.Fin_Entrada) > 0 Then
                            G.Tsql &= " and a.Lote>=" & Val(G.Ini_Entrada)
                            G.Tsql &= " and a.Lote<=" & Val(G.Fin_Entrada)
                        End If
                        If Val(G.Ini_Almacen) > 0 And Val(G.Fin_Almacen) > 0 Then
                            G.Tsql &= " and a.Almacen>=" & Val(G.Ini_Almacen)
                            G.Tsql &= " and a.Almacen<=" & Val(G.Fin_Almacen)
                        End If
                        If G.Ch_Fechas = True Then
                            If G.Fecha_Ini <> "" And G.Fecha_Fin <> "" Then
                                G.Tsql &= " and (a.Fecha_Lote>=" & Pone_Apos(G.Fecha_Ini)
                                G.Tsql &= " and a.Fecha_Lote<=" & Pone_Apos(G.Fecha_Fin) & ")"
                            End If
                        End If
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()

                        Dim Solicitante_Desc As String = ""
                        Dim UUID As String = ""
                        Dim Referencia As String = ""
                        Dim Lote_Entrada As Integer = 0
                        If G.dr.HasRows Then
                            Do While G.dr.Read
                                If G.dr!Partida = 0 Then
                                    Solicitante_Desc = G.dr!Solicitante_Desc
                                    UUID = G.dr!UUID
                                    Referencia = G.dr!Referencia
                                    Lote_Entrada = G.dr!Lote
                                    G.Importe_Flete = G.dr!Flete
                                Else
                                    Dim nf As DataRow = dt.NewRow
                                    nf("Lote") = G.dr!Lote
                                    nf("Partida") = G.dr!Partida
                                    nf("Fecha_Lote") = G.dr!Fecha_Lote
                                    nf("Articulo") = G.dr!Articulo
                                    nf("Descripcion") = G.dr!Descripcion
                                    nf("Cantidad") = G.dr!Cantidad
                                    nf("Almacen") = G.dr!Almacen
                                    nf("Centro_Costos") = G.dr!Centro_Costos
                                    nf("Referencia") = G.dr!Referencia
                                    nf("UUID") = G.dr!UUID
                                    nf("Proveedor_Desc") = G.dr!Proveedor_Desc
                                    nf("Orden_Compra") = G.dr!Orden_Compra
                                    nf("Solicitante_Desc") = Solicitante_Desc
                                    nf("Unidad_Medida") = G.dr!Unidad_Medida
                                    nf("Precio") = G.dr!Precio
                                    nf("Importe") = G.dr!Importe
                                    nf("Iva_Importe") = G.dr!Iva_Importe
                                    dt.Rows.Add(nf)
                                End If
                            Loop
                        End If
                        Dim Importe As Double = NuloADouble(dt.Compute("Sum(Importe)", ""))
                        Dim Iva_Importe As Double = NuloADouble(dt.Compute("Sum(Iva_Importe)", ""))

                        Dim Total As Double = Importe + Iva_Importe
                        Parametros(8) = New ReportParameter("Importe", Importe)
                        Parametros(9) = New ReportParameter("Iva", Iva_Importe)
                        Parametros(10) = New ReportParameter("Total", Total)
                        Parametros(11) = New ReportParameter("UUID", UUID)
                        Parametros(12) = New ReportParameter("Referencia", Referencia)
                        Dim Doc As Object = Nothing
                        If G.dr.IsClosed = False Then G.dr.Close()
                        G.Tsql = "Select top 1 a.Descripcion from Moneda a inner join Movimientos_Inventario b"
                        G.Tsql &= " on a.Moneda=b.Moneda where b.Lote=" & Val(Lote_Entrada)
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        Parametros(13) = New ReportParameter("Moneda", Doc.ToString.ToUpper)
                        Parametros(14) = New ReportParameter("Importe_Flete", G.Importe_Flete)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Impresion_Entradas.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Impresion_Entradas.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()


                    Case "R_MOVIMIENTOS_IEPS"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New ds_Movimientos.Movimientos_IEPSDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        Dim Parametros(14) As ReportParameter
                        Dim Image1 As String = "file:" & MapPath("~/Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Image1)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Hora)
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Usuario", G.UsuarioReal)
                        Parametros(5) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(7) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Lote,a.Partida,a.Flete,a.Fecha_Lote,a.Articulo,a.Descripcion,a.IEPS,a.Costo_Total,Precio_Unitario as Precio,a.Remision_Factura,a.Iva_Importe,Base,a.Cantidad,a.Almacen,a.Centro_Costos,a.Referencia,a.Numero_Documento as Orden_Compra,a.Base_Iva,a.Cuota_Adicional,"
                        G.Tsql &= "IsNull((Select top 1 UUID from Movimientos_Entradas Where Compania=a.Compania and Obra=a.Obra and Almacen=a.Almacen and E_S='E' and Lote=a.Lote and Partida=0),'') as UUID"
                        G.Tsql &= ",(Select r.Unidad_Medida from Articulos r Where r.Cia=" & Session("Cia") & " and r.Obra=" & Pone_Apos(Session("Obra")) & " and r.Numero=a.Articulo) as Unidad_Medida "
                        G.Tsql &= ",IsNull((Select Razon_Social from Proveedor Where Numero=a.Proveedor),'') as Proveedor_Desc"
                        G.Tsql &= ",IsNull((Select Nombre from Solicitante d Where d.Solicitante=a.Solicitante and d.Cia=a.Compania and d.Obra=a.Obra),'') as Solicitante_Desc"
                        G.Tsql &= " from Movimientos_Inventario a "

                        G.Tsql &= " Where a.E_S='E' and a.Compania=" & Session("Cia") & " and a.Obra=" & Pone_Apos(Session("Obra"))
                        If Val(G.Ini_Entrada) > 0 And Val(G.Fin_Entrada) > 0 Then
                            G.Tsql &= " and a.Lote>=" & Val(G.Ini_Entrada)
                            G.Tsql &= " and a.Lote<=" & Val(G.Fin_Entrada)
                        End If
                        If Val(G.Ini_Almacen) > 0 And Val(G.Fin_Almacen) > 0 Then
                            G.Tsql &= " and a.Almacen>=" & Val(G.Ini_Almacen)
                            G.Tsql &= " and a.Almacen<=" & Val(G.Fin_Almacen)
                        End If
                        If G.Ch_Fechas = True Then
                            If G.Fecha_Ini <> "" And G.Fecha_Fin <> "" Then
                                G.Tsql &= " and (a.Fecha_Lote>=" & Pone_Apos(G.Fecha_Ini)
                                G.Tsql &= " and a.Fecha_Lote<=" & Pone_Apos(G.Fecha_Fin) & ")"
                            End If
                        End If
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()

                        Dim Solicitante_Desc As String = ""
                        Dim UUID As String = ""
                        Dim Referencia As String = ""
                        Dim Lote_Entrada As Integer = 0
                        If G.dr.HasRows Then
                            Do While G.dr.Read
                                If G.dr!Partida = 0 Then
                                    Solicitante_Desc = G.dr!Solicitante_Desc
                                    UUID = G.dr!UUID
                                    Referencia = G.dr!Referencia
                                    Lote_Entrada = G.dr!Lote
                                    G.Importe_Flete = G.dr!Flete
                                Else
                                    Dim nf As DataRow = dt.NewRow
                                    nf("Lote") = G.dr!Lote
                                    nf("Partida") = G.dr!Partida
                                    nf("Fecha_Lote") = G.dr!Fecha_Lote
                                    nf("Articulo") = G.dr!Articulo
                                    nf("Descripcion") = G.dr!Descripcion
                                    nf("Cantidad") = G.dr!Cantidad
                                    nf("Almacen") = G.dr!Almacen
                                    nf("Centro_Costos") = G.dr!Centro_Costos
                                    nf("Referencia") = G.dr!Referencia
                                    nf("UUID") = G.dr!UUID
                                    nf("Proveedor_Desc") = G.dr!Proveedor_Desc
                                    nf("Orden_Compra") = G.dr!Orden_Compra
                                    nf("Solicitante_Desc") = Solicitante_Desc
                                    nf("Unidad_Medida") = G.dr!Unidad_Medida
                                    nf("Precio") = G.dr!Precio
                                    nf("Base") = G.dr!Base
                                    nf("Cuota_Adicional") = G.dr!Cuota_Adicional
                                    nf("Base_Iva") = G.dr!Base_Iva
                                    nf("Costo_Total") = G.dr!Costo_Total
                                    nf("Iva_Importe") = G.dr!Iva_Importe
                                    nf("Remision_Factura") = G.dr!Remision_Factura
                                    nf("IEPS") = G.dr!IEPS
                                    dt.Rows.Add(nf)
                                End If
                            Loop
                        End If
                        Dim Costo_Total As Double = NuloADouble(dt.Compute("Sum(Costo_Total)", ""))
                        Dim Iva_Importe As Double = NuloADouble(dt.Compute("Sum(Iva_Importe)", ""))
                        Dim Sub_Total As Double = NuloADouble(dt.Compute("Sum(Base_IVA)", ""))
                        Parametros(8) = New ReportParameter("Iva_Importe", Iva_Importe)
                        Parametros(9) = New ReportParameter("Subtotal", Sub_Total)
                        Parametros(10) = New ReportParameter("Costo_Total", Costo_Total)
                        Parametros(11) = New ReportParameter("UUID", UUID)
                        Parametros(12) = New ReportParameter("Referencia", Referencia)
                        Dim Doc As Object = Nothing
                        If G.dr.IsClosed = False Then G.dr.Close()
                        G.Tsql = "Select top 1 a.Descripcion from Moneda a inner join Movimientos_Inventario b"
                        G.Tsql &= " on a.Moneda=b.Moneda where b.Lote=" & Val(Lote_Entrada)
                        G.com.CommandText = G.Tsql
                        Doc = G.com.ExecuteScalar
                        Parametros(13) = New ReportParameter("Moneda", Doc.ToString.ToUpper)
                        Parametros(14) = New ReportParameter("Importe_Flete", G.Importe_Flete)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Impresion_Entradas_IEPS.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Impresion_Entradas_IEPS.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()

                    Case "R_MOVIMIENTOS_S"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New dsCrystal.Salida_NormalDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        G.cn.Open()
                        G.Tsql = "Select * from Movimientos_Inventario a where Lote=" & Val(G.Numero_Lote) & " and Compania=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal) & " and Partida=0"
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim Dt_datos As New DataTable
                        Dt_datos.Load(G.dr)
                        Dim dato As DataRow
                        For Each dato In Dt_datos.Rows
                            G.VF_Fecha_Lote = dato("Fecha_Lote")
                            G.VF_EDT = dato("EDT")
                            G.VF_Elemento = dato("Elemento")
                        Next
                        G.cn.Close()
                        Dim Parametros(18) As ReportParameter
                        Parametros(0) = New ReportParameter("Folio_Salida", G.Numero_Lote)
                        Parametros(1) = New ReportParameter("Nombre_Solicitante", G.VF_Solicitante)
                        Parametros(2) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)
                        Parametros(3) = New ReportParameter("Num_Elemento", G.Elemento_Val)
                        Parametros(4) = New ReportParameter("Desc_Elemento", G.Elemento_Desc)
                        Parametros(5) = New ReportParameter("Desc_Actividad", G.Actividad_Desc)
                        Parametros(6) = New ReportParameter("Fecha_Lote", G.VF_Fecha_Lote)
                        Parametros(7) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(8) = New ReportParameter("Logotipo", Server.MapPath("./Trabajo/" & Session("Imagen")))
                        Parametros(9) = New ReportParameter("Tipo_Elemento", G.Elemento)
                        Parametros(10) = New ReportParameter("Salida", G.VF_Salida)
                        Parametros(11) = New ReportParameter("Salida_Desc", G.VF_Salida_Desc)
                        Parametros(12) = New ReportParameter("Clasificacion_Desc", G.Clasificacion_Desc)
                        Parametros(13) = New ReportParameter("Referencia_Desc", G.VF_Ref_Des)
                        G.Tsql = "Select Cuenta from Movimientos_Inventario where Lote=" & Val(G.Numero_Lote) & " and Fecha_Lote=" & Pone_Apos(G.VF_Fecha_Lote)
                        G.Tsql &= " and E_S='S' and Compania=" & Val(Session("Cia")) & " and Obra=" & Pone_Apos(G.Sucursal) & " and Partida=0"
                        G.com.CommandText = G.Tsql
                        G.cn.Open()
                        G.VF_Cuenta = G.com.ExecuteScalar
                        G.cn.Close()
                        Parametros(14) = New ReportParameter("Cuenta", G.VF_Cuenta)
                        Dim Imagen As String = "file:" & MapPath("Trabajo/" & Session("Imagen"))
                        Parametros(15) = New ReportParameter("Imagen", Imagen)
                        Parametros(17) = New ReportParameter("Obra_Num", G.Sucursal)
                        Parametros(18) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)



                        G.Tsql = "Select Articulo,Descripcion,Unidad_Medida,Cantidad,Precio_Unitario,Costo_Total"
                        G.Tsql &= " from Movimientos_Inventario left join Compañias"
                        G.Tsql &= " on Movimientos_Inventario.Compania=Compañias.Cia"
                        G.Tsql &= " where Movimientos_Inventario.Lote=" & G.Numero_Lote
                        G.Tsql &= " and Movimientos_Inventario.Compania=" & Val(Session("Cia"))
                        G.Tsql &= " and Movimientos_Inventario.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and Movimientos_Inventario.Obra=" & Pone_Apos(Session("Obra"))
                        G.Tsql &= " and E_S='S'"
                        G.Tsql &= " and Partida>0"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        Dim dt_Detalle_Salida As New DataTable
                        dt_Detalle_Salida.Load(G.dr)
                        Dim f As DataRow
                        Dim total As Double = 0
                        For Each f In dt_Detalle_Salida.Rows
                            Dim nf As DataRow = dt.NewRow
                            nf("Articulo") = f("Articulo")
                            nf("Descripcion") = f("Descripcion")
                            nf("Unidad_Medida") = f("Unidad_Medida")
                            nf("Cantidad") = f("Cantidad")
                            nf("Precio_Unitario") = f("Precio_Unitario")
                            nf("Costo_Total") = f("Costo_Total")
                            dt.Rows.Add(nf)
                            total = total + nf("Costo_Total")
                        Next
                        Parametros(16) = New ReportParameter("Importe_Total", total)
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Impresion_Salidas.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Impresion_Salidas.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()


                    Case "R_MOVIMIENTOS_DETALLE"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New ds_Movimientos.MovimientosDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        Dim Parametros(7) As ReportParameter
                        Dim Image1 As String = "file:" & MapPath("~/Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Image1)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Hora)
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Usuario", G.UsuarioReal)
                        Parametros(5) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(7) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Lote,a.Partida,a.Fecha_Lote,a.Articulo,a.Descripcion,a.Cantidad,a.Almacen,a.Centro_Costos,a.Referencia,"
                        G.Tsql &= "(Select top 1 UUID from Movimientos_Inventario Where Compania=a.Compania and Obra=a.Obra and Almacen=a.Almacen and E_S='E' and Lote=a.Lote and Partida=0) as UUID"
                        G.Tsql &= " from Movimientos_Inventario a Where a.Partida>0 and a.E_S='E' and a.Compania=" & Session("Cia")
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and a.Partida>0 and a.E_S='E' "
                        G.Tsql &= " and a.Lote=" & Val(G.Lote)
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        'Dim dt_Movimientos As New DataTable
                        'dt_Movimientos.Load(G.dr)
                        If G.dr.HasRows Then
                            Do While G.dr.Read
                                Dim nf As DataRow = dt.NewRow
                                nf("Lote") = G.dr!Lote
                                nf("Partida") = G.dr!Partida
                                nf("Fecha_Lote") = G.dr!Fecha_Lote
                                nf("Articulo") = G.dr!Articulo
                                nf("Descripcion") = G.dr!Descripcion
                                nf("Cantidad") = G.dr!Cantidad
                                nf("Almacen") = G.dr!Almacen
                                nf("Centro_Costos") = G.dr!Centro_Costos
                                nf("Referencia") = G.dr!Referencia
                                nf("UUID") = G.dr!UUID
                                dt.Rows.Add(nf)
                                'G.dr.NextResult()
                            Loop
                        End If
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Impresion_Entradas.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Impresion_Entradas.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "R_AUX_ARTICULOS"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New Ds_Entradas.dt_Aux_MovDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        Dim Parametros(7) As ReportParameter
                        Dim Image1 As String = "file:" & MapPath("~/Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Imagen", Image1)
                        Parametros(1) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(2) = New ReportParameter("Hora", Hora)
                        Parametros(3) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(4) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(5) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(6) = New ReportParameter("Almacen", G.Almacen_Desc)
                        G.Tsql = "Select a.Almacen,a.Marca,b.Descripcion as Marca_Desc,a.Linea,c.Descripcion as Linea_Desc,a.Movimiento,a.Lote,a.Partida,a.Fecha_Lote,a.Articulo,a.Descripcion,a.Cantidad,"
                        G.Tsql &= "a.Centro_Costos,a.Referencia,a.Remision_Factura,a.Proveedor,a.Numero_Documento,a.E_S,a.Existencia"
                        G.Tsql &= " from Movimientos_Inventario a left join Marca b on b.Cia=a.Compania and b.Obra=a.Obra and b.Marca=a.Marca "
                        G.Tsql &= " left join Linea c on c.Cia=a.Compania and c.Obra=a.Obra and c.Linea=a.Linea "
                        G.Tsql &= " Where a.Partida>0 and a.Compania=" & Session("Cia")
                        G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                        G.Tsql &= " and a.Almacen=" & Val(G.Almacen)
                        G.Tsql &= " and a.Marca>0"
                        If G.Articulo_Ini > "" And G.Articulo_Fin > "" Then
                            G.Tsql &= " and a.Articulo>=" & Pone_Apos(G.Articulo_Ini)
                            G.Tsql &= " and a.Articulo<=" & Pone_Apos(G.Articulo_Fin)
                        End If
                        If Val(G.Ini_Almacen) > 0 And Val(G.Fin_Almacen) > 0 Then
                            G.Tsql &= " and a.Almacen>=" & Val(G.Ini_Almacen)
                            G.Tsql &= " and a.Almacen<=" & Val(G.Fin_Almacen)
                        End If
                        If Val(G.Linea_Ini) > 0 And Val(G.Linea_Fin) > 0 Then
                            G.Tsql &= " and a.Linea>=" & Val(G.Linea_Ini)
                            G.Tsql &= " and a.Linea<=" & Val(G.Linea_Fin)
                        End If
                        If Val(G.Marca_Ini) > 0 And Val(G.Marca_Fin) > 0 Then
                            G.Tsql &= " and a.Marca>=" & Val(G.Marca_Ini)
                            G.Tsql &= " and a.Marca<=" & Val(G.Marca_Fin)
                        End If
                        'If G.Ch_Fechas = True Then
                        '    If G.Fecha_Ini <> "" And G.Fecha_Fin <> "" Then
                        '        G.Tsql &= " and a.Fecha_Lote>=" & Pone_Apos(G.Fecha_Ini)
                        '        G.Tsql &= " and a.Fecha_Lote<=" & Pone_Apos(G.Fecha_Fin)
                        '    End If
                        'End If
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        'Dim dt_Movimientos As New DataTable
                        'dt_Movimientos.Load(G.dr)
                        If G.dr.HasRows Then
                            Do While G.dr.Read
                                Dim nf As DataRow = dt.NewRow
                                nf("Almacen") = G.dr!Almacen
                                nf("Marca") = G.dr!Marca
                                nf("Marca_Desc") = G.dr!Marca_Desc
                                nf("Linea") = G.dr!Linea
                                nf("Linea_Desc") = G.dr!Linea_Desc
                                nf("Movimiento") = G.dr!Movimiento
                                nf("Lote") = G.dr!Lote
                                nf("Fecha_Lote") = G.dr!Fecha_Lote
                                nf("Articulo") = G.dr!Articulo
                                nf("Descripcion") = G.dr!Descripcion
                                If G.dr!E_S = "E" Then
                                    nf("Cant_Entradas") = G.dr!Cantidad
                                    nf("Existencia_I") = G.dr!Existencia - G.dr!Cantidad
                                Else
                                    nf("Cant_Salidas") = G.dr!Cantidad
                                    nf("Existencia_I") = G.dr!Existencia + G.dr!Cantidad
                                End If
                                nf("Referencia") = G.dr!Referencia
                                nf("Remision_Factura") = G.dr!Remision_Factura
                                nf("Proveedor") = G.dr!Proveedor
                                nf("Numero_Documento") = G.dr!Numero_Documento
                                nf("Existencia") = G.dr!Existencia
                                dt.Rows.Add(nf)
                                'G.dr.NextResult()
                            Loop
                        End If
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Aux_Articulos.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Aux_Articulos.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "SALIDAS_VAL"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New Ds_Entradas.dt_Sal_ValDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        Dim Parametros(6) As ReportParameter
                        Dim Image1 As String = "file:" & MapPath("~/Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(1) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)
                        Parametros(2) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(3) = New ReportParameter("Hora", Hora)
                        Parametros(4) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(5) = New ReportParameter("Imagen", Image1)
                        Parametros(6) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)

                        G.Tsql = "Select Articulo,Lote,Almacen,Fecha_Lote,Partida,Movimiento,Descripcion,Cantidad,Centro_Costos,Precio_Unitario,Referencia,Proveedor,Almacen_Destin,E_S,Iva"
                        G.Tsql &= ",Remision_Factura from Movimientos_Inventario where Partida>0"
                        If Val(G.Lote_Fin) > 0 And Val(G.Lote_Ini) > 0 Then
                            G.Tsql &= " and Lote Between " & G.Lote_Ini & " and " & G.Lote_Fin
                        ElseIf Val(G.Lote_Ini) > 0 And Val(G.Lote_Fin) <= 0 Then
                            G.Tsql &= " and Lote=" & Val(G.Lote_Ini)
                        End If
                        If G.Proveedor_Ini <> 0 And G.Proveedor_Fin <> 0 Then
                            G.Tsql &= " and Proveedor Between " & Val(G.Proveedor_Ini) & " and " & Val(G.Proveedor_Fin)
                            'ElseIf Val(G.Proveedor_Fin <= 0) Then
                            '    G.Tsql &= " and Proveedor=" & Val(G.Proveedor_Ini)
                        End If
                        If G.Referencia_Ini <> "" Then
                            G.Tsql &= " and Referencia Between " & Pone_Apos(G.Referencia_Ini) & " and " & Pone_Apos(G.Referencia_Fin)
                            'ElseIf G.Referencia_Fin = "" Then
                            '    G.Tsql &= " and Referencia=" & Pone_Apos(G.Referencia_Ini)
                        End If

                        If G.Articulo_Ini > "" And G.Articulo_Fin > "" Then
                            G.Tsql &= " and Articulo>=" & Pone_Apos(G.Articulo_Ini)
                            G.Tsql &= " and Articulo<=" & Pone_Apos(G.Articulo_Fin)
                        End If
                        If Val(G.Ini_Almacen) > 0 And Val(G.Fin_Almacen) > 0 Then
                            G.Tsql &= " and Almacen>=" & Val(G.Ini_Almacen)
                            G.Tsql &= " and Almacen<=" & Val(G.Fin_Almacen)
                        End If
                        If Val(G.Linea_Ini) > 0 And Val(G.Linea_Fin) > 0 Then
                            G.Tsql &= " and Linea>=" & Val(G.Linea_Ini)
                            G.Tsql &= " and Linea<=" & Val(G.Linea_Fin)
                        End If
                        If Val(G.Marca_Ini) > 0 And Val(G.Marca_Fin) > 0 Then
                            G.Tsql &= " and Marca>=" & Val(G.Marca_Ini)
                            G.Tsql &= " and Marca<=" & Val(G.Marca_Fin)
                        End If
                        If G.Ch_Fechas = True Then
                            G.Tsql &= " and Fecha_Lote Between " & Pone_Apos(G.Fecha_Ini) & " and " & Pone_Apos(G.Fecha_Fin)
                        End If
                        G.Tsql &= "Order By Lote,Partida"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        If G.dr.HasRows Then
                            Do While G.dr.Read
                                Dim nf As DataRow = dt.NewRow
                                nf("Articulo") = G.dr!Articulo
                                nf("Lote") = G.dr!Lote
                                nf("Almacen") = G.dr!Almacen
                                nf("Fecha_Lote") = G.dr!Fecha_Lote
                                nf("Partida") = G.dr!Partida
                                nf("Movimiento") = G.dr!Movimiento
                                nf("Descripcion") = G.dr!Descripcion
                                nf("Cantidad") = G.dr!Cantidad
                                nf("Centro_Costos") = G.dr!Centro_Costos
                                nf("Precio_Unitario") = G.dr!Precio_Unitario
                                nf("Referencia") = G.dr!Referencia
                                nf("Proveedor") = G.dr!Proveedor
                                nf("Almacen_Destin") = G.dr!Almacen_Destin
                                nf("E_S") = G.dr!E_S
                                nf("Iva") = G.dr!Iva
                                nf("Remision_Factura") = G.dr!Remision_Factura
                                'nf("Precio_Venta") = G.dr!Precio_Venta
                                dt.Rows.Add(nf)
                            Loop
                        End If
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Salidas_Val.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Salidas_Val.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                    Case "IMP_CONSULTA"
                        ReportViewer1.LocalReport.EnableExternalImages = True
                        Dim dt As New Ds_Entradas.dt_Sal_ValDataTable
                        Dim RD As New ReportDataSource
                        Dim Hora As String = Format(Now, "HH:mm:ss")
                        Dim Parametros(6) As ReportParameter
                        Dim Image1 As String = "file:" & MapPath("~/Trabajo/" & Session("Imagen"))
                        Parametros(0) = New ReportParameter("Compañia", G.RazonSocial)
                        Parametros(1) = New ReportParameter("Obra", G.Sucursal)
                        Parametros(2) = New ReportParameter("Fecha", Fecha_AMD(Now))
                        Parametros(3) = New ReportParameter("Hora", Hora)
                        Parametros(4) = New ReportParameter("Imagen", Image1)
                        Parametros(5) = New ReportParameter("Almacen_Nombre", G.Almacen_Desc)
                        Parametros(6) = New ReportParameter("Obra_Desc", G.Sucursal_Desc)

                        G.Tsql = "Select Articulo,Lote,Almacen,Fecha_Lote,Partida,Movimiento,Descripcion,Cantidad,Centro_Costos,Precio_Unitario,Referencia,Proveedor,Almacen_Destin,E_S where Partida>0"
                        If Val(G.Lote_Fin) > 0 And Val(G.Lote_Ini) > 0 Then
                            G.Tsql &= " and Lote Between " & G.Lote_Ini & " and " & G.Lote_Fin
                        ElseIf Val(G.Lote_Ini) > 0 And Val(G.Lote_Fin) <= 0 Then
                            G.Tsql &= " and Lote=" & Val(G.Lote_Ini)
                        End If
                        If G.Proveedor_Ini <> 0 And G.Proveedor_Fin <> 0 Then
                            G.Tsql &= " and Proveedor Between " & Val(G.Proveedor_Ini) & " and " & Val(G.Proveedor_Fin)
                            'ElseIf Val(G.Proveedor_Fin <= 0) Then
                            '    G.Tsql &= " and Proveedor=" & Val(G.Proveedor_Ini)
                        End If
                        If G.Referencia_Ini <> "" Then
                            G.Tsql &= " and Referencia Between " & Pone_Apos(G.Referencia_Ini) & " and " & Pone_Apos(G.Referencia_Fin)
                        End If
                        If Val(G.Movimiento_Ini) > 0 And Val(G.Movimiento_Fin) > 0 Then
                            G.Tsql &= " and Movimiento Between " & Val(G.Movimiento_Ini) & " and " & Val(G.Movimiento_Fin)
                        End If
                        If G.Articulo_Ini > "" And G.Articulo_Fin > "" Then
                            G.Tsql &= " and Articulo>=" & Pone_Apos(G.Articulo_Ini)
                            G.Tsql &= " and Articulo<=" & Pone_Apos(G.Articulo_Fin)
                        End If
                        If Val(G.Ini_Almacen) > 0 And Val(G.Fin_Almacen) > 0 Then
                            G.Tsql &= " and Almacen>=" & Val(G.Ini_Almacen)
                            G.Tsql &= " and Almacen<=" & Val(G.Fin_Almacen)
                        End If
                        If Val(G.Linea_Ini) > 0 And Val(G.Linea_Fin) > 0 Then
                            G.Tsql &= " and Linea>=" & Val(G.Linea_Ini)
                            G.Tsql &= " and Linea<=" & Val(G.Linea_Fin)
                        End If
                        If Val(G.Marca_Ini) > 0 And Val(G.Marca_Fin) > 0 Then
                            G.Tsql &= " and Marca>=" & Val(G.Marca_Ini)
                            G.Tsql &= " and Marca<=" & Val(G.Marca_Fin)
                        End If
                        If G.Ch_Fechas = True Then
                            G.Tsql &= " and Fecha_Lote Between " & Pone_Apos(G.Fecha_Ini) & " and " & Pone_Apos(G.Fecha_Fin)
                        End If

                        G.Tsql &= "Order By Lote,Partida"
                        G.cn.Open()
                        G.com.CommandText = G.Tsql
                        G.dr = G.com.ExecuteReader()
                        If G.dr.HasRows Then
                            Do While G.dr.Read
                                Dim nf As DataRow = dt.NewRow
                                nf("Articulo") = G.dr!Articulo
                                nf("Lote") = G.dr!Lote
                                nf("Almacen") = G.dr!Almacen
                                nf("Fecha_Lote") = G.dr!Fecha_Lote
                                nf("Partida") = G.dr!Partida
                                nf("Movimiento") = G.dr!Movimiento
                                nf("Descripcion") = G.dr!Descripcion
                                nf("Cantidad") = G.dr!Cantidad
                                nf("Centro_Costos") = G.dr!Centro_Costos
                                nf("Precio_Unitario") = G.dr!Precio_Unitario
                                nf("Referencia") = G.dr!Referencia
                                nf("Proveedor") = G.dr!Proveedor
                                nf("Almacen_Destin") = G.dr!Almacen_Destin
                                nf("E_S") = G.dr!E_S
                                'nf("Iva") = G.dr!Iva
                                'nf("Remision_Factura") = G.dr!Remision_Factura
                                'nf("Precio_Venta") = G.dr!Precio_Venta
                                dt.Rows.Add(nf)
                            Loop
                        End If
                        RD.Value = dt
                        RD.Name = "DataSet1"
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(RD)
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "R_Salidas_Val.rdlc"
                        ReportViewer1.LocalReport.ReportPath = "R_Salidas_Val.rdlc"
                        ReportViewer1.LocalReport.SetParameters(Parametros)
                        ReportViewer1.LocalReport.Refresh()
                End Select
                If Impresora = "S" Then
                    Dim warnings As Warning() = Nothing
                    Dim streamids As String() = Nothing
                    Dim mimeType As String = Nothing
                    Dim encoding As String = Nothing
                    Dim extension As String = Nothing
                    '                Dim deviceInfo As String = "<DeviceInfo>" & _
                    '    "<OutputFormat>EMF</OutputFormat>" & _
                    '"<PageWidth>11in</PageWidth>" & _
                    '"<PageHeight>8.5in</PageHeight>" & _
                    '"<MarginTop>0in</MarginTop>" & _
                    '"<MarginLeft>0in</MarginLeft>" & _
                    '"<MarginRight>0in</MarginRight>" & _
                    '"<MarginBottom>0in</MarginBottom>" & _
                    '"</DeviceInfo>"

                    Dim bytes As Byte()
                    bytes = ReportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
                    Dim ms As New System.IO.MemoryStream(bytes)
                    Response.ContentType = "Application/pdf"
                    Response.BinaryWrite(ms.ToArray())
                    'Response.End()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                If G.cn.State = ConnectionState.Open Then G.cn.Close()
            End Try
        End If
    End Sub
    Private Function LeeAnexo() As String
        LeeAnexo = "1. OBJETO" & Chr(10)

        LeeAnexo &= "Los términos y condiciones de este pedido y sus anexos, constituyen un Contrato de Compra-Venta Mercantil entre " & Chr(34) & "LA COMPRADORA" & Chr(34) & " y " & Chr(34) & "LA VENDEDORA" & Chr(34) & ", cuyo objeto es el suministro de los artículos, servicios o trabajos descritos en este pedido y los anexos , que firmados por las partes se agregan formando parte integrante del mismo. Las modificaciones que se hicieran posteriormente a las condiciones pactadas en el pedido, sólo serán obligatorias para ambas partes si las mismas se hicieran por escrito y fueran firmadas por un representante autorizado de " & Chr(34) & "LA COMPRADORA " & Chr(34) & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "2.FIRMA" & Chr(10)
        LeeAnexo &= "La firma del representante de " & Chr(34) & "LA VENDEDORA " & Chr(34) & " al calce de este pedido confirma la aceptación por parte de " & Chr(34) & "LA VENDEDORA " & Chr(34) & " de todas las condiciones que se consignan  en estas condiciones generales de compra, y en consecuencia cualquier declaración establecida en las condiciones generales de venta, llámense presupuesto, especificaciones o cualquier otra de " & Chr(34) & "LA VENDEDORA" & Chr(34) & " que se opongan a estas condiciones son nulas y sin efecto alguno en relación a este pedido." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= " 3.PLAZO DE ENTREGA" & Chr(10)

        LeeAnexo &= Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a cumplir las obligaciones señaladas en este pedido, en la forma y términos en el precisados sin que por ningún concepto puedan variarse. En caso de que " & Chr(34) & "LA VENDEDORA" & Chr(34) & " llegare a incurrir en mora por cualquier causa no imputable a " & Chr(34) & "LA COMPRADORA" & Chr(34) & " se obliga a cubrir a ésta última una pena convencional consistente en el 10% del precio total  del pedido, para resarcirle de los perjuicios que dicho incumplimiento le llegare a causar, pena que se estipula por el simple retardo en el cumplimiento de las obligaciones de " & Chr(34) & "LA VENDEDORA" & Chr(34) & ", toda vez que el tiempo de entrega es una de las condiciones esenciales de este pedido." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "4.INCUMPLIMIENTO" & Chr(10)

        LeeAnexo &= "El incumplimiento por parte de " & Chr(34) & "LA VENDEDORA" & Chr(34) & " a cualquiera de las obligaciones contraídas tanto en este contrato o pedido como en sus anexos, planos, especificaciones, lista de precios y demás cotizaciones que forman parte integrante del mismo dará acción a " & Chr(34) & "LA COMPRADORA" & Chr(34) & " para declarar de pleno derecho y sin necesidad de declaración judicial la rescisión del presente contrato o pedido y demás documentos integrantes del mismo, sin perjuicio de hacer efectiva la pena estipulada en el punto anterior." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "5.RESCISION" & Chr(10)

        LeeAnexo &= "Es potestativo para " & Chr(34) & "LA COMPRADORA" & Chr(34) & " exigir en caso de incumplimiento por parte de " & Chr(34) & "LA VENDEDORA" & Chr(34) & " el cumplimiento forzoso del presente contrato o pedido o declarar la rescisión del mismo pero en ambos casos " & Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a pagar a " & Chr(34) & "LA COMPRADORA" & Chr(34) & " los daños y perjuicios que tal incumplimiento le ocasiones. Si " & Chr(34) & "LA COMPRADORA" & Chr(34) & "  rescinde  este  contrato  o pedido por causas Imputables a " & Chr(34) & "LA VENDEDORA" & Chr(34) & " ésta deberá devolver a " & Chr(34) & "LA COMPRADORA" & Chr(34) & " la cantidad que le hubiere entregado a cuenta del precio correspondiente más la cantidad que resulte de sumar 25 puntos al costo porcentual promedio de capación que el Banco de México publique en el Diario Oficial de la Federación mensualmente, por concepto de intereses moratorio computados diariamente desde la fecha en que fue entregada hasta aquella e que " & Chr(34) & "LA COMPRADORA" & Chr(34) & " se de por recibida de dicha cantidad a su entera satisfacción." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "6.CESIÓN" & Chr(10)

        LeeAnexo &= "Este contrato o pedido no podrá ser cedido total o parcialmente por " & Chr(34) & "LA VENDEDORA" & Chr(34) & " sin el previo consentimiento de " & Chr(34) & "LA COMPRADORA" & Chr(34) & ", otorgado por escrito." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "7.VIOLACIÓN" & Chr(10)

        LeeAnexo &= Chr(34) & "LA VENDEDORA" & Chr(34) & " garantiza a " & Chr(34) & "LA COMPRADORA" & Chr(34) & " que los artículos, servicios o trabajos objeto de este contrato o pedido, así como la venta o el uso, no violan ninguna patente, nombre comercial, certificado de invención o cualquier otro derecho de terceros, por lo que " & Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a sacarla a paz y a salvo a " & Chr(34) & "LA COMPRADORA" & Chr(34) & " de cualquier juicio o reclamación que se iniciare en su contra por cualquier persona por los motivos indicados y a indemnizarlos de los daños y perjuicios que sufriere." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "8.CUMPLIMIENTO" & Chr(10)

        LeeAnexo &= Chr(34) & "LA VENDEDORA" & Chr(34) & " conviene en cumplir con todas las leyes, reglamentos y demás disposiciones que en cualquier forma se relacionen con objeto de este contrato o pedido por lo que " & Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a responder frente a " & Chr(34) & "LA COMPRADORA" & Chr(34) & "  de  cualquier  daño  o  perjuicio  que por tal motivo llegare a sufrir y a reembolsarle cualquier gasto que tenga que erogar, incluyendo multas o cualquier otra sanción pecuniaria." & Chr(10)
        LeeAnexo &= " " & Chr(10)
        LeeAnexo &= "9.INSPECCION" & Chr(10)
        LeeAnexo &= "Los materiales que utilice " & Chr(34) & "LA VENDEDORA" & Chr(34) & " en la fabricación de los artículos objeto del presente contrato o pedido serán nuevos y de la mejor calidad que exista en el mercado, los cuales deberán reunir las especificaciones y datos técnicos contenidos en los anexos que forman parte de el. " & Chr(34) & "LA COMPRADORA" & Chr(34) & " podrá inspeccionar cuantas veces estime necesario o conveniente los materiales y la mano de obra que utilice " & Chr(34) & "LA VENDEDORA" & Chr(34) & " para cumplir con el presente contrato o pedido. Si los materiales o mano de obra empleados por " & Chr(34) & "LA VENDEDORA" & Chr(34) & " no se sujetan a las especificaciones del presente contrato o pedido, será potestativo para " & Chr(34) & "LA COMPRADORA" & Chr(34) & " exigir la reposición o rescisión del contrato o pedido más la devolución de las cantidades que hubiera entregado y el pago de daños y perjuicios " & Chr(34) & "LA VENDEDORA" & Chr(34) & " deberá retirar de inmediato los artículos o materiales que sean rechazados por " & Chr(34) & "LA COMPRADORA" & Chr(34) & " por no llenar las características, especificaciones o datos técnicos que se mencionan en este contrato o pedido y sus anexos. Todos los gastos para retirar dichos materiales incluyendo los de transportación serán por cuenta de " & Chr(34) & "LA VENDEDORA" & Chr(34) & "." & Chr(10)
    End Function
    Private Function LeeAnexo2() As String
        LeeAnexo2 = "10.CAMBIOS" & Chr(10)
        LeeAnexo2 &= Chr(34) & "LA COMPRADORA" & Chr(34) & " tendrá en cualquier momento el derecho de efectuar cambios de cantidades, especificaciones, dibujos o lugar de entrega. Si tales cambios originan un aumento o disminución en la cantidad o en el importe requerido para la ejecución, se hará el ajuste equitativo. Cualquier reclamación de ajuste conforme a esta estipulación deberá hacer valer " & Chr(34) & "LA VENDEDORA" & Chr(34) & " dentro de los 10 (diez) días siguientes a la fecha en que " & Chr(34) & "LA COMPRADORA" & Chr(34) & " solicite el cambio. Transcurrido dicho termino " & Chr(34) & "LA VENDEDORA" & Chr(34) & " no podrá formular reclamación alguna por este concepto." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "11.PAGOS" & Chr(10)
        LeeAnexo2 &= "" & Chr(34) & "LA COMPRADORA" & Chr(34) & " se obliga a pagar a " & Chr(34) & "LA VENDEDORA" & Chr(34) & " el importe de este pedido en su oficina matriz, de acuerdo con las condiciones de pago que se ha señalado en la carátula de este pedido. A efecto de que " & Chr(34) & "LA COMPRADORA" & Chr(34) & " pueda realizar los pagos en la forma y términos convenidos, " & Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a presentar con 10 (diez) días de anticipación para su revisión la o las facturas que amparen cada pago. Si por cualquier circunstancia " & Chr(34) & "LA VENDEDORA" & Chr(34) & " se retrasa en la presentación de las facturas, el término de pagos se vera ampliado en igual número de días hábiles." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "12.FACTURACION" & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "Para los efectos del punto anterior " & Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a presentar la o las facturas debidamente requisitazas en los términos de ley y debiendo en todos los casos presentar por separado el precio o importe del impuesto al valor agregado, que en su caso esté trasladando en los términos de la Ley de la Materia." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "13.FIANZAS" & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "" & Chr(34) & "LA VENDEDORA" & Chr(34) & " se obliga a constituir a favor de " & Chr(34) & "LA COMPRADORA" & Chr(34) & " las siguientes garantías: Fianza que garantice el buen uso del anticipo al 100% de la misma, y en su caso los intereses que se causen por incumplimiento de " & Chr(34) & "LA VENDEDORA" & Chr(34) & " y otra fianza por el equivalente al 10% del precio total de este contrato o pedido para garantizar la entrega, el pago de la pena convencional y en general el fiel y exacto cumplimiento de todas y cada una de las obligaciones a cargo de " & Chr(34) & "LA VENDEDORA" & Chr(34) & ", así como el buen funcionamiento, la reparación o sustitución del objeto convenido o de sus elementos que estén en mal estado por defectos de fabricación, vicios ocultos o por cualquier otro motivo imputable a " & Chr(34) & "LA VENDEDORA" & Chr(34) & " la cual estará en vigor por el término de un año a partir de la fecha de recepción, y solo podrá ser cancelada mediante la autorización por escrito de " & Chr(34) & "LA COMPRADORA" & Chr(34) & "." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "14.ENTREGA DEL OBJETO"
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "La entrega de los artículos, servicios o trabajos objeto de este contrato o pedido será real y se llevará a cabo en el lugar indicado en el anverso y su recepción estará sujeta a la inspección de " & Chr(34) & "LA COMPRADORA" & Chr(34) & " que podrá rechazar aquellos elementos que no satisfagan las calidades y especificaciones establecidas, en cuyo caso no se darán por recibidas y en consecuencia será imputable a " & Chr(34) & "LA VENDEDORA" & Chr(34) & " el atraso que sobrevenga. La recepción ya sea total o parcial se hará constar en el recibo que " & Chr(34) & "LA COMPRADORA" & Chr(34) & " suscribirá en el que se manifestará lo conducente." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "15.GARANTÍA" & Chr(10)
        'LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "Independientemente de la aceptación o inspección de " & Chr(34) & "LA COMPRADORA" & Chr(34) & " y de cualquier otro termino o condiciones establecidos en este contrato " & Chr(34) & "LA VENDEDORA" & Chr(34) & " garantiza por el termino de un año la buena calidad de diseño de fabricación de materiales y de la mano de obra y demás elementos que dichos artículos requieren para u fabricación, colocación, transportación, etc. Y se ajustan a las especificaciones proporcionadas por " & Chr(34) & "LA COMPRADORA" & Chr(34) & " y en los casos en que hubiere especificaciones que los artículos son adecuados y propios para el uso previsto por " & Chr(34) & "LA COMPRADORA" & Chr(34) & " y que los mismos cumplen con las normas técnicas y comerciales normalmente aceptadas en el mercado." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "16.RESPONSABILIDAD(LABORAL)" & Chr(10)
        'LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "Teniendo " & Chr(34) & "LA VENDEDORA" & Chr(34) & " el carácter de comerciante establecido que habitualmente celebra este tipo de contratos o pedidos asume incondicionalmente el carácter de patrón durante la fabricación, suministro, colocación, transporte, etc., de los artículos o materiales a que este contrato o pedido se refiere y por lo mismo todos sus trabajadores y empleados que intervengan en ello dependerán exclusivamente de ella, quien será la única responsable de los contratos de trabajo, de los accidentes de trabajo que llegaren a sufrir dichas personas, del pago de sus salarios y demás prestaciones laborales, de las aportaciones del Infonavit, cuotas obrero patronales, del Instituto Mexicano del Seguro Social, Impuesto Sobre la Renta, etc." & Chr(10)
        LeeAnexo2 &= " " & Chr(10)
        LeeAnexo2 &= "17.JURISDICCION" & Chr(10)
        LeeAnexo2 &= "En lo previsto en este contrato las partes se someten expresamente a las disposiciones aplicables en el Distrito Federal y específicamente a las disposiciones contenidas en el Código del Comercio y del Código Civil para el Distrito Federal supletoriamente las partes convienen  someterse en un caso de controversia a la jurisdicción de los tribunales de la Ciudad de México Distrito Federal, renunciando expresamente a cualquier fuero que pudiera corresponderles en razón a su domicilio presente o futuro. "

    End Function
End Class
