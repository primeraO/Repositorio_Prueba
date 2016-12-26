Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Class C_Acceso
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            Dim Catalogo As String = Request.QueryString("form")
            Dim AT As Boolean
            Punto_Desc = ""
            Accion_ES = ""
            Select Case Catalogo
                Case "Catalogo_Agente"

                    Punto_Menu(Catalogo, "Catalogo de Agente", AT)
                    If AT = True Then
                        Punto_Desc = "Catalogo de Agente"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Agente.aspx")
                    End If
                Case "Catalogo_Cliente"

                    Punto_Menu(Catalogo, "Cambio de Cliente", AT)
                    If AT = True Then
                        Punto_Desc = "Cambio de Cliente"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Cliente.aspx")
                    End If
                Case "Catalogo_Obras_Periodos"
                    Punto_Menu(Catalogo, "Cambio de Periodo", AT)
                    If AT = True Then
                        Punto_Desc = "Cambio de Periodo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Obras_Periodos.aspx")
                    End If
                Case "Catalogo_Moneda"
                    Punto_Menu(Catalogo, "Moneda", AT)
                    If AT = True Then
                        Punto_Desc = "Moneda"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Moneda.aspx")
                    End If
                Case "C_Entradas_IEPS"
                    Punto_Menu(Catalogo, "Entradas IEPS", AT)
                    If AT = True Then
                        Punto_Desc = "Entradas IEPS"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Entradas_IEPS.aspx")
                    End If
                Case "Catalogo_Cuenta_IEPS"
                    Punto_Menu(Catalogo, "Cuenta IEPS", AT)
                    If AT = True Then
                        Punto_Desc = "Cuenta IEPS"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Cuenta_IEPS.aspx")
                    End If
                Case "Catalogo_Tipo_Cambio"
                    Punto_Menu(Catalogo, "Tipo de Cambio", AT)
                    If AT = True Then
                        Punto_Desc = "Tipo de Cambio"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Tipo_Cambio.aspx")
                    End If
                Case "Catalogo_Pais"
                    Punto_Menu(Catalogo, "País", AT)
                    If AT = True Then
                        Punto_Desc = "País"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Pais.aspx")
                    End If
                Case "Catalogo_Articulos"
                    Punto_Menu(Catalogo, "Artículos", AT)
                    If AT = True Then
                        Punto_Desc = "Artículos"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Articulos.aspx")
                    End If
                Case "Catalogo_Almacen"
                    Punto_Menu(Catalogo, "Almacen", AT)
                    If AT = True Then
                        Punto_Desc = "Almacen"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Almacen.aspx")
                    End If
                Case "Catalogo_Linea"
                    Punto_Menu(Catalogo, "Linea", AT)
                    If AT = True Then
                        Punto_Desc = "Línea"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Linea.aspx")
                    End If
                Case "Catalogo_Marca"
                    Punto_Menu(Catalogo, "Marca", AT)
                    If AT = True Then
                        Punto_Desc = "Marca"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Marca.aspx")
                    End If
                Case "Catalogo_SubLinea"
                    Punto_Menu(Catalogo, "Sub-Linea", AT)
                    If AT = True Then
                        Punto_Desc = "Sub-Linea"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_SubLinea.aspx")
                    End If
                Case "Catalogo_Proveedores"
                    Punto_Menu(Catalogo, "Proveedor", AT)
                    If AT = True Then
                        Punto_Desc = "Proveedor"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Proveedores.aspx")
                    End If
                Case "Catalogo_Condicion_Pago"
                    Punto_Menu(Catalogo, "Condicion de Pago", AT)
                    If AT = True Then
                        Punto_Desc = "Condición de Pago"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Condicion_Pago.aspx")
                    End If
                Case "Catalogo_Transporte"
                    Punto_Menu(Catalogo, "Transporte", AT)
                    If AT = True Then
                        Punto_Desc = "Transporte"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Transporte.aspx")
                    End If
                Case "Catalogo_Comprador"
                    Punto_Menu(Catalogo, "Comprador", AT)
                    If AT = True Then
                        Punto_Desc = "Comprador"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Comprador.aspx")
                    End If
                Case "Catalogo_Lugar_Entrega"
                    Punto_Menu(Catalogo, "Lugar Entrega", AT)
                    If AT = True Then
                        Punto_Desc = "Lugar Entrega"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Lugar_Entrega.aspx")
                    End If
                Case "Catalogo_Compañia"
                    Punto_Menu(Catalogo, "Compañia", AT)
                    If AT = True Then
                        Punto_Desc = "Compañia"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Compañia.aspx")
                    End If
                Case "Catalogo_Solicitante"
                    Punto_Menu(Catalogo, "Solicitante", AT)
                    If AT = True Then
                        Punto_Desc = "Solicitante"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Solicitante.aspx")
                    End If
                Case "Catalogo_Economico"
                    Punto_Menu(Catalogo, "Economico", AT)
                    If AT = True Then
                        Punto_Desc = "Economico"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Economico.aspx")
                    End If
                Case "Catalogo_Frente"
                    Punto_Menu(Catalogo, "Frente", AT)
                    If AT = True Then
                        Punto_Desc = "Frente"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Frente.aspx")
                    End If
                Case "Catalogo_Obra"
                    Punto_Menu(Catalogo, "Obra", AT)
                    If AT = True Then
                        Punto_Desc = "Obra"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Obras.aspx")
                    End If
                Case "Catalogo_Terceros"
                    Punto_Menu(Catalogo, "Tercero", AT)
                    If AT = True Then
                        Punto_Desc = "Tercero"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Terceros.aspx")
                    End If
                Case "Catalogo_Tipo_Salida"
                    Punto_Menu(Catalogo, "Tipo de Salida", AT)
                    If AT = True Then
                        Punto_Desc = "Tipo de Salida"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Tipo_Salida.aspx")
                    End If
                Case "Catalogo_Tipo_Obra"
                    Punto_Menu(Catalogo, "Tipo de Obra", AT)
                    If AT = True Then
                        Punto_Desc = "Tipo de Obra"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Tipo_Obra.aspx")
                    End If
                Case "Catalogo_Area"
                    Punto_Menu(Catalogo, "Area", AT)
                    If AT = True Then
                        Punto_Desc = "Area"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Area.aspx")
                    End If
                Case "Catalogo_Actividad_Area"
                    Punto_Menu(Catalogo, "Actividad - Area", AT)
                    If AT = True Then
                        Punto_Desc = "Actividad - Area"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Actividad_Area.aspx")
                    End If
                Case "Catalogo_Actividad_Frente"
                    Punto_Menu(Catalogo, "Actividad - Frente", AT)
                    If AT = True Then
                        Punto_Desc = "Actividad - Frente"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Actividad_Frente.aspx")
                    End If
                Case "Catalogo_Concepto_Costo"
                    Punto_Menu(Catalogo, "Concepto de Costo", AT)
                    If AT = True Then
                        Punto_Desc = "Concepto de Costo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Concepto_Costo.aspx")
                    End If
                Case "Catalogo_Gasto"
                    Punto_Menu(Catalogo, "Gasto", AT)
                    If AT = True Then
                        Punto_Desc = "Gasto"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Gasto.aspx")
                    End If
                Case "Catalogo_Gasto_19"
                    Punto_Menu(Catalogo, "Gasto 19", AT)
                    If AT = True Then
                        Punto_Desc = "Gasto 19"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Gasto_19.aspx")
                    End If
                Case "C_Entradas"
                    Punto_Menu(Catalogo, "Entradas", AT)
                    If AT = True Then
                        Punto_Desc = "Entradas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Entradas.aspx")
                    End If
                Case "Salidas_Almacen"
                    Punto_Menu(Catalogo, "Salidas", AT)
                    If AT = True Then
                        Punto_Desc = "Salidas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Salidas_Almacen.aspx")
                    End If
                Case "Salidas_Multiples"
                    Punto_Menu(Catalogo, "Salidas Multiples", AT)
                    If AT = True Then
                        Punto_Desc = "Salidas Multiples"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Salidas_Multiples.aspx")
                    End If
                Case "Salidas_Clasificacion"
                    Punto_Menu(Catalogo, "Codificación de Salidas", AT)
                    If AT = True Then
                        Punto_Desc = "Codificación de Salidas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Salidas_Clasificacion.aspx")
                    End If
                Case "Salidas_Multiples_Consulta"
                    Punto_Menu(Catalogo, "Consulta de Salidas Multiples", AT)
                    If AT = True Then
                        Punto_Desc = "Consulta de Salidas Multiples"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Salidas_Multiples_Consulta.aspx")
                    End If
                Case "C_Re_Impresion_Entradas"
                    Punto_Menu(Catalogo, "Reimpresión Entradas", AT)
                    If AT = True Then
                        Punto_Desc = "Reinpresión Entradas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Re_Impresion_Entradas.aspx")
                    End If
                Case "C_Re_Impresion_Entradas_IEPS"
                    Punto_Menu(Catalogo, "Reimpresión Entradas IEPS", AT)
                    If AT = True Then
                        Punto_Desc = "Reinpresión Entradas IEPS"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Re_Impresion_Entradas_IEPS.aspx")
                    End If

                Case "C_Re_Impresion_Salidas"
                    Punto_Menu(Catalogo, "Reimpresión Salidas", AT)
                    If AT = True Then
                        Punto_Desc = "Reinpresión Salidas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Re_Impresion_Salidas.aspx")
                    End If
                Case "C_Reimpresion_Salidas_Multiples"
                    Punto_Menu(Catalogo, "Reimpresión Salidas Multiples", AT)
                    If AT = True Then
                        Punto_Desc = "Reimpresión Salidas Multiples"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Reimpresion_Salidas_Multiples.aspx")
                    End If

                Case "Requisiciones_Carga"
                    Punto_Menu(Catalogo, "Requisiciones", AT)
                    If AT = True Then
                        Punto_Desc = "Requisiciones"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Requisiciones_Carga.aspx")
                    End If
                Case "Comp_Compras_Requisiciones"
                    Punto_Menu(Catalogo, "Comparativo", AT)
                    If AT = True Then
                        Punto_Desc = "Comparativo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Comp_Compras_Requisiciones.aspx")
                    End If
                Case "Seleccion_Proveedor"
                    Punto_Menu(Catalogo, "Selección de Proveedores", AT)
                    If AT = True Then
                        Punto_Desc = "Selección de Proveedores"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Seleccion_Proveedor.aspx")
                    End If
                Case "C_Consulta_Inventarios"
                    Punto_Menu(Catalogo, "Consulta Inventarios", AT)
                    If AT = True Then
                        Punto_Desc = "Consulta Inventarios"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Consulta_Inventarios.aspx")
                    End If
                Case "C_Resguardo"
                    Punto_Menu(Catalogo, "Adiciona a Inventario de Resguardo", AT)
                    If AT = True Then
                        Punto_Desc = "Adiciona a Inventario de Resguardo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Resguardo.aspx")
                    End If
                Case "C_Resguardo_Salidas"
                    Punto_Menu(Catalogo, "Salidas a Resguardo", AT)
                    If AT = True Then
                        Punto_Desc = "Salidas a Resguardo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Resguardo_Salidas.aspx")
                    End If
                Case "C_Resguardo_Entradas"
                    Punto_Menu(Catalogo, "Entrega de Resguardo", AT)
                    If AT = True Then
                        Punto_Desc = "Entrega de Resguardo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Resguardo_Entradas.aspx")
                    End If
                Case "R_0001"
                    Punto_Menu(Catalogo, "Caratula Por Artículo", AT)
                    If AT = True Then
                        Punto_Desc = "Caratula Por Artículo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0001.aspx")
                    End If
                Case "R_0002"
                    Punto_Menu(Catalogo, "Combustible Por Económico", AT)
                    If AT = True Then
                        Punto_Desc = "Combustible Por Económico"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0002.aspx")
                    End If
                Case "R_0003"
                    Punto_Menu(Catalogo, "Compras Por Proveedor", AT)
                    If AT = True Then
                        Punto_Desc = "Compras Por Proveedor"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0003.aspx")
                    End If
                Case "R_0004"
                    Punto_Menu(Catalogo, "Consumo Por Artículo", AT)
                    If AT = True Then
                        Punto_Desc = "Consumo Por Artículo"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0004.aspx")
                    End If
                Case "R_0005"
                    Punto_Menu(Catalogo, "Devoluciones Por Proveedor", AT)
                    If AT = True Then
                        Punto_Desc = "Devoluciones Por Proveedor"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0005.aspx")
                    End If
                Case "R_0006"
                    Punto_Menu(Catalogo, "Entradas Por Artículo Folio y Factura", AT)
                    If AT = True Then
                        Punto_Desc = "Entradas Por Artículo Folio y Factura"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0006.aspx")
                    End If
                Case "R_0007"
                    Punto_Menu(Catalogo, "Existencias Físicas", AT)
                    If AT = True Then
                        Punto_Desc = "Existencias Físicas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0007.aspx")
                    End If
                Case "R_Informe_Mensual"
                    Punto_Menu(Catalogo, "Informe Mensual", AT)
                    If AT = True Then
                        Punto_Desc = "Informe Mensual"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_Informe_Mensual.aspx")
                    End If
                Case "R_0009"
                    Punto_Menu(Catalogo, "Consumo Por Económico", AT)
                    If AT = True Then
                        Punto_Desc = "Consumo Por Económico"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0009.aspx")
                    End If
                Case "R_0010"
                    Punto_Menu(Catalogo, "Lento Movimiento", AT)
                    If AT = True Then
                        Punto_Desc = "Lento Movimiento"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0010.aspx")
                    End If
                Case "R_0011"
                    Punto_Menu(Catalogo, "Auxiliar Movimientos", AT)
                    If AT = True Then
                        Punto_Desc = "Auxiliar Movimientos"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0011.aspx")
                    End If
                Case "R_0012"
                    Punto_Menu(Catalogo, "Entradas Por Solicitante", AT)
                    If AT = True Then
                        Punto_Desc = "Entradas Por Solicitante"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0012.aspx")
                    End If
                Case "R_0013"
                    Punto_Menu(Catalogo, "Salidas Por Solicitante", AT)
                    If AT = True Then
                        Punto_Desc = "Salidas Por Solicitante"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/R_0013.aspx")
                    End If
                Case "Crea_Estructuras"
                    Punto_Menu(Catalogo, "Estructura", AT)
                    If AT = True Then
                        Punto_Desc = "Crea Estructura"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Crea_Estructuras.aspx")
                    End If
                Case "Catalogo_Claves_Autorizacion"
                    Punto_Menu(Catalogo, "Claves Autorización", AT)
                    If AT = True Then
                        Punto_Desc = "Claves Autorización"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Claves_Autorizacion.aspx")
                    End If
                Case "Migracion_Access_SQL"
                    Punto_Menu(Catalogo, "Migración bases de datos", AT)
                    If AT = True Then
                        Punto_Desc = "Migración bases de datos"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Migracion_Access_SQL.aspx")
                    End If
                Case "Catalogo_Usuarios"
                    Punto_Menu(Catalogo, "Usuarios", AT)
                    If AT = True Then
                        Punto_Desc = "Catálogo de Moneda"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Usuarios.aspx")
                    End If
                Case "Catalogo_Firmas"
                    Punto_Menu(Catalogo, "Firmas", AT)
                    If AT = True Then
                        Punto_Desc = "Firmas"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Firmas.aspx")
                    End If
                Case "Acceso"
                    '  Punto_Menu(Catalogo, "Acceso a Puntos de Menú", AT)
                    ' If AT = True Then
                    Punto_Desc = "Acceso a Puntos de Menú"
                    Accion_ES = "E"
                    Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                    Response.Redirect("~/Acceso.aspx")
                    ' End If
                Case "Consulta_Seguimiento"
                    Punto_Menu(Catalogo, "Consulta de Seguimiento", AT)
                    If AT = True Then
                        Punto_Desc = "Consulta de Seguimiento"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Consulta_Seguimiento.aspx")
                    End If
                Case "Orden_Compra"
                    Punto_Menu(Catalogo, "Ordenes de Compra", AT)
                    If AT = True Then
                        Punto_Desc = "Ordenes de Compra"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Orden_Compra.aspx")
                    End If
                Case "Cat_Articulo_Proveedor"
                    Punto_Menu(Catalogo, "Articulo_Proveedor", AT)
                    If AT = True Then
                        Punto_Desc = "Articulo_Proveedor"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/Catalogo_Articulo_Proveedor.aspx")
                    End If
                Case "C_Entradas_XML"
                    Punto_Menu(Catalogo, "Entradas con XML", AT)
                    If AT = True Then
                        Punto_Desc = "Entradas con XML"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Entradas_XML.aspx")
                    End If
                    'Case "Catalogo_Articulo_Proveedor"
                    '    Punto_Menu(Catalogo, "Articulo Proveedor", AT)
                    '    If AT = True Then
                    '        Punto_Desc = "Articulo Proveedor"
                    '        Accion_ES = "E"
                    '        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                    '        Response.Redirect("~/Cat_Articulo_Proveedor.aspx")
                    '    End If
                Case "C_Ap_Cont_Inv"
                    Punto_Menu(Catalogo, "Catálogo Aplicación Contable", AT)
                    If AT = True Then
                        Punto_Desc = "Catálogo Aplicación Contable"
                        Accion_ES = "E"
                        Inserta_Seguimiento(CType(Session("G"), Glo), Accion_ES, Punto_Desc)
                        Response.Redirect("~/C_Ap_Cont_Inv.aspx")
                    End If
            End Select
        End If

    End Sub

    Protected Sub Btn_Regresar_Click(sender As Object, e As System.EventArgs) Handles Btn_Regresar.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Public Sub Punto_Menu(ByVal Form As String, ByVal Descripcion As String, ByRef AT As Boolean)
        Dim G As Glo = CType(Session("G"), Glo)
        Dim res As Object = Nothing
        Dim Esta_Activo As Boolean = False
        Try
            G.cn.Open()

            'Si es Administrador tiene acceso a todo el menu
            G.com.CommandText = "Select UsuarioAdministrador from Usuarios "
            G.com.CommandText &= " Where UsuarioNumero=" & Val(G.UsuarioNumero)
            G.com.CommandText &= " and UsuarioActivo='S'"
            res = G.com.ExecuteScalar.ToString
            If res.ToString.ToUpper = "S" Then
                G.Es_Administrador = True
            Else
                G.Es_Administrador = False
            End If

            'Insertar Menu en Base si no es catalogo de seguridad
            Try
                If Form <> "Acceso" And Form <> "Catalogo_Usuarios" And Form <> "Catalogo_Puntos_Menu" And Form <> "Crea_Estructuras" Then
                    G.com.CommandText = "Insert into Punto_Menu(Clave_Punto,Descripcion_Punto) values ("
                    G.com.CommandText &= Pone_Apos(Form)
                    G.com.CommandText &= "," & Pone_Apos(Descripcion) & ")"
                    G.com.ExecuteNonQuery()
                End If
            Catch ex As Exception
            End Try
            If G.Es_Administrador Then AT = True : Exit Sub


            'Verificar si tiene acceso a un menu en especifico
            G.com.CommandText = "Select TA from Acceso Where Numero_Compañia=" & G.Empresa_Numero
            G.com.CommandText &= " and Sucursal=" & Pone_Apos(G.Sucursal)
            G.com.CommandText &= " and UsuarioNumero=" & Val(G.UsuarioNumero)
            G.com.CommandText &= " and Clave_Punto=" & Pone_Apos(Form)
            res = G.com.ExecuteScalar
            If IsDBNull(res) Or IsNothing(res) Then
                AT = False
            ElseIf res.ToString.ToUpper = "S" Then
                AT = True
            Else
                AT = False
            End If
        Catch ex As Exception
        Finally
            G.cn.Close()
        End Try
    End Sub

End Class


