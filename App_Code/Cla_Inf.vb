Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Text
Imports System.Web
Imports System
Imports System.Collections

Imports System.Globalization

Public Module Cla_Inf
    Public Accion_ES As String = ""
    Public Punto_Desc As String = ""

    Public Catalogo As String
    Public Conexion_Estructura As String
    ' Public Conexion As String = "Server=192.168.10.10;uid=bernardo;pwd=Ale2336;database=Fact_Web"
    Public Con_Fact As String = "Server=192.168.10.10;uid=bernardo;pwd=Ale2336;database=PtoVta_Alv2012"
    Public Conexion As String
    Public Conexion2 As String
    Public Conexion3 As String

    

    Public Conexion_Acces As String
    Public Archivo_Imprimir As String = ""
    ' Public Conexion As String = "Server=14097-pc;uid=bernardo;pwd=Ale2336;database=Fact_Web"
    ' Public Conexion As String = "Server=(local);uid=Interaccion;pwd=IOP010820NAA;database=Fact_Web"
    ' Public Conexion As String = "Server=inter-optorreon.dyndns.org;uid=Interaccion;pwd=IOP010820NAA;database=Fact_Web"
    ' Public Conexion As String = "Server=192.168.10.10;uid=Interaccion;pwd=IOP010820NAA;database=Fact_Web"
    ' Public Conexion As String = "Server=192.168.50.10;uid=bernardo;pwd=B150958m;database=Fact_Web"
    ' Public Conexion As String = "Server=JAVIER-F7A71147;uid=bernardo;pwd=ale2336;database=Bitacora"
    ' Public Conexion As String = "Data Source=facturacionweb.db.4903432.hostedresource.com;initial Catalog=facturacionweb;Use ID=facturacionweb; Password=B150958m"
    Public dt As DataTable
    'Public Tsql As String
    'Public cn As New SqlConnection
    'Public dr As SqlDataReader
    'Public com As New SqlCommand("", cn)
    Public dtCliente As New DataTable
    Public dtArticulo As New DataTable
    Public dtDocumento As New DataTable
    Public dtCotizacion As New DataTable
    Public dtUsuario As New DataTable
    Public dtTarea As New DataTable
    Public dtImagen As New DataTable
    Public dtGenerador As New DataTable
    Public dtTrabajo As New DataTable
    Public dtspan As New DataTable
    Public dtBanco As New DataTable
    Public DtConexiones As New DataTable

    'Public Vg_Abreviatura As String
    Public Regresa As Boolean
    Public Conn_Ser(50, 5) As String
    Public Arr_Iva(10, 2) As Double

    '''Variables de Requisiciones


    Public Class Glo
        Public rfcproveedor As String = ""
        Public valor_inventario As Double = 0
        Public Mensaje As String = ""
        Public dt_ProveedoresRequisicion As DataTable
        Public FiltroGenerico As String = ""
        Public ChekeadoFechas As Boolean = True
        Public Arr_FiltroComparativo(4) As String
        Public FiltroComparativo As String = ""
        Public FiltroReq(10) As String
        Public Nombre_Imagen As String
        Public Filtro_Guardado As String = ""
        Public Filtro As String = ""
        ''variables orden de compra
        Public Num_Orden As Integer
        Public Prov_Atencion As String = ""
        Public Prov_Tiempo_Entrega As Integer = 0
        Public Tg_Moneda As Integer
        Public Formulo As String = ""
        Public Reviso As String = ""
        Public Autorizo As String = ""
        Public Cuarta As String = ""
        Public Formulo_Num As String = ""
        Public Reviso_Num As String = ""
        Public Autorizo_Num As String = ""
        Public Cuarta_Num As String = ""
        Public Fecha_Orden As String = ""
        Public Tw_Partida As Integer = 0
        Public Estatus_Orden As String = ""
        Public Departamento As String = ""
        Public Lugar_Entrega As String = ""
        Public Flete As String = ""
        Public Costo_Devolucion As String = ""
        Public Condicion_Pago As String = ""
        Public Direccion As String = ""
        Public RFC As String = ""
        Public Localidad As String = ""
        Public Descripcion As String = ""
        Public I_Formulo As String = ""
        Public I_Autorizo As String = ""
        Public I_Reviso As String = ""
        Public I_Cuarta As String = ""

        Public Tsql As String = ""
        Public CadSql As String = ""
        Public Avance_DiarioN As Integer = 0
        Public ClienteNumero As Integer = 0
        Public RazonSocial As String = ""
        Public Poliza_Numero As Integer = 0
        Public Tipo_Poliza As String = ""
        Public Año As Integer = 0
        Public Mes As Integer = 0
        Public Tipo_Descarga As String = ""
        Public Nombre_Catalogo As String = ""
        Public Fecha As String = ""
        Public Hora As String = ""
        Public dtPedidoDetalle As DataTable
        Public cn As New SqlConnection
        Public com As New SqlCommand("", cn)

        Public cn2 As New SqlConnection
        Public com2 As New SqlCommand("", cn2)
        Public dr2 As SqlDataReader

        Public cn3 As New SqlConnection
        Public com3 As New SqlCommand("", cn3)
        Public dr3 As SqlDataReader

        Public dr As SqlDataReader
        Public dt As New DataTable
        Public dt2 As New DataTable
        Public dt3 As New DataTable
        Public EmpresaRFC As String
        Public Empresa_Numero As Integer
        Public Elemento As String
        Public Nombre_Solicitante As String
        Public Existencia As Double = 0
        Public Ultimo_Registro_Articulo As Integer
        Public Numero_Lote As Integer = 0
        Public Fecha_Lote As String = ""
        Public Sucursal As String = ""
        Public Sucursal_Desc As String = ""
        Public Almacen As Integer
        Public Almacen_Desc As String
        Public Control As String = ""
        '' Manejo de requisiciones
        Public Num_Requisicion As Integer
        Public Fecha_Requiere As String
        Public Fecha_Solicita As String
        Public Glo_RequisicionP1 As String
        Public Glo_RequisicionP2 As String
        Public Glo_RequisicionP3 As String
        Public Glo_RequisicionP4 As String
        Public Glo_Te_Sup As String
        Public Glo_Te_Alm As String
        Public Glo_Te_Adm As String
        Public Glo_Te_Ger As String
        Public Glo_ComprasP1 As String
        Public Glo_ComprasP2 As String
        Public Glo_ComprasP3 As String
        Public Glo_ComprasP4 As String
        Public Glo_Economico As String
        Public Glo_Requisicion As Integer
        Public Glo_Solicitante As Integer
        Public Glo_Centro_Costos As Integer
        Public Glo_Lugar_Entrega As String
        Public Glo_Clave_Almacen_Liberacion As Boolean
        Public Tw_Sup, Tw_Alm, Tw_Adm, Tw_Ger, Tw_Req As Integer
        Public Empresa As String = ""

        Public Ini_Entrada, Fin_Entrada, Ini_Almacen, Fin_Almacen, Ini_Salida, Fin_Salida As Integer
        Public Ch_Fechas As Boolean
        Public Fecha_Ini, Fecha_Fin, Lote As String

        Public Maquina, NumEco, Marca, Modelo, Serie, Motor, Motor_Marca, Motor_Modelo, Motor_Serie As String
        Public Proveedor, Proveedor_Desc, Proveedor_Direccion, Proveedor_RFC, Proveedor_Localidad, Cond_Pago, Unidad_Medida As String
        Public Nombre_Sup, Nombre_Alm, Nombre_Adm, Nombre_Ger As String
        Public Fletero As Integer = 0
        Public Fletero_Desc As String = ""
        Public Importe_Flete As Double = 0
        Public Imagen As String
        Public Solicitante As Double = 0
        Public Orden_Compra As String = ""
        Public Referencia As String = ""
        Public UUID As String = ""
        Public Solicitante_Desc As String = ""
        Public Glo_Cantidad As Double
        Public Glo_Articulo As String
        Public Nom1, Dir1, Tel1, For1, Nom2, Dir2, Tel2, For2, Nom3, Dir3, Tel3, For3, Cor1, Cor2, Cor3 As String
        ''Variables Impresion de Salidas
        Public VF_Folio_Salida As String = ""
        Public VF_Lote As Integer = 0
        Public VF_Solicitante As String = ""
        Public VF_Nombre_Solicitante As String = ""
        Public VF_Elemento As String = ""
        Public VF_Elemento_Descripcion As String = ""
        Public VF_Actividad_Descripcion As String = "No Aplica"
        Public VF_Fecha_Lote As String = ""
        Public VF_Almacen As String = ""
        Public VF_Compañia As String = ""
        Public VF_Clas As String = ""
        Public VF_Clas_Desc As String = ""
        Public VF_Ref As String = ""
        Public VF_Ref_Des As String = ""
        Public VF_Tipo_Elemento As String = ""
        Public VF_Salida As String = ""
        Public VF_EDT As String = ""
        Public VF_Salida_Desc As String = ""
        Public VF_Cuenta As String = ""
        Public VF_Fecha As String = ""

        ''' Variables Asigna Proveedor
        Public Glo_Articulo_Descripcion As String
        'Public Proveedor_Desc As String
        'Public Fletero As Integer
        'Public Fletero_Desc As String
        Public Tw_Departamento As String
        Public Tw_Pro_Articulo, Tw_Pro_Art_Descripcion As String
        Public Tw_Impuesto, Tw_Tiempo_Entrega, Tw_Condicion_Pago, Tw_Transporte As Integer
        Public Tw_Catalogo, Tw_Figura, Tw_Pagina As String
        Public Olecn As New OleDb.OleDbConnection(Conexion_Acces)
        Public Olecom As New OleDb.OleDbCommand("", Olecn)
        Public Oledr As OleDb.OleDbDataReader = Nothing
        Public Conexion_Acces As String = ""
        Public Obra As String
        Public UsuarioNumero As Integer = 0
        Public Es_Administrador As Boolean = False
        Public UsuarioReal As String = ""
        Public Usuario_Activo As String = ""
        Public Glo_Contraseña As String = ""
        Public Empresa_Numero2 As Integer = 0
        Public Art_I As String = ""
        Public Art_F As String = ""
        Public TpCos As String = ""
        Public Elem_F As String = ""
        Public Elem_I As String = ""
        Public Act As String = ""
        Public Pro_F As String = ""
        Public Pro_I As String = ""
        Public CL As String = ""
        Public Mov As String = ""
        Public LinF As String = ""
        Public LinI As String = ""
        Public D As String = ""
        Public Detalle As String = ""
        Public Lote_Ini, Lote_Fin, Movimiento_Ini, Movimiento_Fin, Marca_Ini, Marca_Fin, Linea_Ini, Linea_Fin, Sub_Linea_Ini, Sub_Linea_Fin As Integer
        Public Articulo_Ini, Articulo_Fin, Referencia_Ini, Referencia_Fin, Seleccion As String
        Public Proveedor_Ini, Proveedor_Fin As Integer
        Public Elemento_Buscat As String
        Public ES_Buscat As String
        Public Num_Buscat As String
        Public Catalogo_Buscat As String
        Public Cia_Buscat As String
        Public IEPS As String = ""
        Public Elemento_Val As String
        Public Elemento_Desc As String
        Public Actividad_Val As String
        Public Actividad_Desc As String
        Public Clasificacion_Val As String
        Public Clasificacion_Desc As String
        Public periodo As String
        Public año_proceso, mes_proceso As String






        Public Enum Emisor
            Nombre
            RFC

        End Enum
        Public dtEmpresaEmite As New DataTable
        Public dtF_Utilizado As New DataTable

        Public Sub Ejecuta_Est(ByVal tsql As String)
            Try
                com.CommandText = tsql
                cn.Open()
                com.ExecuteNonQuery()
            Catch ex As Exception
            Finally
                cn.Close()
            End Try
        End Sub
    End Class
  
    Public Function Es_Where(ByVal Txm_Sql As String) As String
        Txm_Sql = Txm_Sql.ToUpper
        If InStr(Txm_Sql, "WHERE") Then
            Es_Where = " and "
        Else
            Es_Where = " Where "
        End If
    End Function
    Public Sub Inserta_Seguimiento(ByRef G As Glo, ByVal ES As String, ByVal Punto As String)
        'Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Insert into Seguimiento(Cia, Obra, Almacen,Usuario,Descripcion_Punto,Fecha,Hora,E_S) Values("
            'G.Tsql &= Val(Session("Cia"))
            G.Tsql &= Val(G.Empresa_numero)
            G.Tsql &= "," & Pone_Apos(G.Sucursal)
            G.Tsql &= "," & Val(G.Almacen)
            G.Tsql &= "," & Pone_Apos(G.UsuarioReal)
            G.Tsql &= "," & Pone_Apos(Punto)
            G.Tsql &= "," & Pone_Apos(Fecha_AMD(Now))
            G.Tsql &= "," & Pone_Apos(Format(Now, "HH:mm:ss"))
            G.Tsql &= "," & Pone_Apos(ES) & ")"
            G.com.CommandText = G.Tsql
            G.com.ExecuteNonQuery()
        Catch ex As Exception
            Exit Sub
        Finally
            G.cn.Close()
        End Try
        'Punto_Desc = ""
        'Accion_ES = ""
    End Sub

    Public Function Elimina_comilla(ByVal Descripcion As String) As String
        Dim Leng As Integer
        Dim T_Co As Integer = 0
        Dim Descripcion_Final As String = ""
        Leng = Len(Descripcion)
        For T_Co = 1 To Leng
            If Mid(Descripcion, T_Co, 1) <> "'" Then
                Descripcion_Final = Descripcion_Final & Mid(Descripcion, T_Co, 1)
            End If
        Next
        Elimina_comilla = Descripcion_Final
    End Function

    Public Function Pone_Ceros(ByVal Importe As Double, ByVal Longitud As Integer) As String
        Dim Tw_Len As Integer
        Dim Pon_Cer As String
        Tw_Len = Len(Importe.ToString.Trim)
        Pon_Cer = ""
        For Tw_Coun1 As Integer = 1 To Longitud - Tw_Len
            Pon_Cer = Pon_Cer & "0"
        Next
        Pone_Ceros = Pon_Cer & Importe.ToString.Trim
    End Function
    Public Sub Mensaje(ByVal sMensaje As String)
        ' Envia mensajes para asp en forma directa para representar informacion  en pantalla
        Dim sb As New StringBuilder
        sMensaje = sMensaje.Replace("'", "")
        sMensaje = sMensaje.Replace("""", "")
        sMensaje = sMensaje.Replace(vbCrLf, "")
        sb.Append("<script language=" + "'javascript'" + ">")
        sb.Append("window.alert( """ + sMensaje.Trim + """ );")
        sb.Append("</script>")
        HttpContext.Current.Response.Write(sb)
    End Sub
    Public Function Busca_Cat(ByRef G As Glo, ByVal Catalogo As String, ByVal Clave As String, Optional ByVal Clave2 As String = "") As String
        Busca_Cat = ""
        Dim Tsql As String = ""
        Try
            G.cn.Open()
            Select Case Catalogo.ToUpper
                Case "ALMACEN"
                    Tsql = "Select Descripcion "
                    Tsql &= "from Almacen "
                    Tsql &= "Where Cia=" & G.Empresa_Numero & " and Obra=" & Pone_Apos(G.Sucursal)
                    Tsql &= " and Almacen=" & Val(Clave)
                Case "MOVIMIENTO"
                    Tsql = "Select Descripcion from Clave_Movimiento_Inventario where Numero=" & Pone_Apos(Clave)
                Case "MONEDA"
                    Tsql = "Select Descripcion"
                    Tsql &= " from Moneda"
                    Tsql &= " Where Moneda=" & Val(Clave)
                Case "PROVEEDOR"
                    Tsql = "Select Razon_Social"
                    Tsql &= " from Proveedor where Baja<>'*'"
                    Tsql &= " and Numero=" & Val(Clave)
                Case "PROVEEDOR_RFC"
                    Tsql = "Select Rfc"
                    Tsql &= " from Proveedor where Baja<>'*'"
                    Tsql &= " and Numero=" & Val(Clave)
                Case "ARTICULO"
                    Tsql = "Select Art_Descripcion as Descripcion"
                    Tsql &= " from Articulos Where Baja<>'*' "
                    Tsql &= " and Numero=" & Pone_Apos(Clave)
                    Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                    Tsql &= " Order by Numero"
                Case "PAIS"
                    Tsql = "Select Descripcion from Pais where Numero=" & Val(Clave)
                    Tsql &= " and Cia=" & G.Empresa_Numero
                Case "COMPRADOR"
                    Tsql = "Select Nombre from Comprador where Comprador=" & Pone_Apos(Clave)
                Case "CONDICION_PAGO"
                    Tsql = "Select Descripcion from Condicion_Pago where Condicion=" & Pone_Apos(Clave)
                    Tsql &= " and Sucursal =" & Pone_Apos(G.Sucursal)
                Case "TRANSPORTE"
                    Tsql = "Select Descripcion from Transporte where Transporte=" & Pone_Apos(Clave)
                Case "MARCA"
                    Tsql = "Select Descripcion from Marca where Marca=" & Pone_Apos(Clave)
                Case "LINEA"
                    Tsql = "Select Descripcion from Linea where Numero=" & Pone_Apos(Clave)
                    Tsql &= " and Sucursal=" & Pone_Apos(G.Sucursal)
                Case "SOLICITANTE"
                    Tsql = "Select Nombre from Solicitante where Solicitante=" & Pone_Apos(Clave)
                    Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
                    Tsql &= " and Cia=" & Pone_Apos(G.Empresa_Numero)
                Case "SUBLINEA"
                    Tsql = "Select Descripcion from Sub_Linea where Lin_Numero=" & Pone_Apos(Clave2)
                    Tsql &= " and Numero=" & Pone_Apos(Clave)
                Case "TIPO_COSTO"
                    Tsql = "Select Descripcion from Tipo_Salida where Tipo=" & Pone_Apos(Clave)
            End Select
            If Tsql <> "" Then
                Dim com As New SqlCommand(Tsql, G.cn)
                Busca_Cat = AString(com.ExecuteScalar)
            End If
        Catch ex As Exception
        Finally
            G.cn.Close()
        End Try
    End Function
    Public Function Mes_Nombre(ByVal Txw_Mes As Integer) As String
        Mes_Nombre = ""
        Select Case Txw_Mes
            Case 1
                Mes_Nombre = "ENERO"
            Case 2
                Mes_Nombre = "FEBRERO"
            Case 3
                Mes_Nombre = "MARZO"
            Case 4
                Mes_Nombre = "ABRIL"
            Case 5
                Mes_Nombre = "MAYO"
            Case 6
                Mes_Nombre = "JUNIO"
            Case 7
                Mes_Nombre = "JULIO"
            Case 8
                Mes_Nombre = "AGOSTO"
            Case 9
                Mes_Nombre = "SEPTIEMBRE"
            Case 10
                Mes_Nombre = "OCTUBRE"
            Case 11
                Mes_Nombre = "NOVIEMBRE"
            Case 12
                Mes_Nombre = "DICIEMBRE"

        End Select
    End Function
    Public Function NuloADouble(ByVal valor As Object) As Double
        If valor Is DBNull.Value Then
            NuloADouble = 0
        Else
            NuloADouble = CDbl(valor)
        End If
    End Function
    Public Function For_Pan_Lib(ByVal Txw_Numero As Double, ByVal Txw_Formato As Integer) As String
        Dim Txw_String As String
        Select Case Txw_Formato
            Case 2
                Txw_String = Format(Txw_Numero, "#,##0.00;-#,##0.00")
            Case 0
                Txw_String = Format(Int(Txw_Numero), "#,##0")
            Case 1
                Txw_String = Format(Int(Txw_Numero), "#,###;-#,###")
            Case 3
                Txw_String = Format(Int(Txw_Numero), "$####;$-####")
            Case 4
                Txw_String = Format(Int(Txw_Numero), "$#,###;$-#,###")
            Case 5
                Txw_String = Format(Txw_Numero, "$#,##0.00;$-#,##0.00")
            Case 6
                Txw_String = Format(Int(Txw_Numero), "%###;%-###")
            Case 7
                Txw_String = Format(Txw_Numero, "#,##0.0000;-#,##0.0000")
            Case 8
                Txw_String = Format(Txw_Numero, "#,##0.0;-#,##0.0")
            Case 9
                Txw_String = Format(Txw_Numero, "#####;-#####")
            Case 10
                Txw_String = Format(Int(Txw_Numero), "%#.00;-%#.00")
            Case 11
                Txw_String = Format(Txw_Numero, "#0.000;-#0.000")
            Case 12
                Txw_String = Format(Txw_Numero, "#,##0.00000;-#,##0.00000")
            Case 13
                Txw_String = Format(Txw_Numero, "#,##0.000000;-#,##0.000000")
            Case Else
                Txw_String = Format(Txw_Numero, "$#,##0.00;$-#,##0.00")
        End Select
        For_Pan_Lib = Txw_String
    End Function
    Public Sub QuitaNulos(ByVal dt As DataTable, ByVal Nombre_Columna1 As String, Optional ByVal Nombre_Columna2 As String = "", Optional ByVal Nombre_Columna3 As String = "")
        If dt Is Nothing Then Exit Sub
        For Each f As DataRow In dt.Rows
            If IsDBNull(f(Nombre_Columna1)) Then
                f(Nombre_Columna1) = 0
            End If
            If Nombre_Columna2 <> "" Then
                If IsDBNull(f(Nombre_Columna2)) Then
                    f(Nombre_Columna2) = 0
                End If
            End If
            If Nombre_Columna3 <> "" Then
                If IsDBNull(f(Nombre_Columna3)) Then
                    f(Nombre_Columna3) = 0
                End If
            End If
        Next
    End Sub
    Function ExtraerImagen(ByVal EmpresaNumero As Integer, ByRef cn As SqlConnection) As Byte()
        Dim arr As Byte() = New Byte() {0}
        Dim com As New SqlCommand("", cn)
        Dim SqlSelect As String = "Select EmpresaLogo From Empresas Where EmpresaNumero = " & EmpresaNumero
        com.CommandText = SqlSelect
        Dim res As Object = com.ExecuteScalar()
        If res Is DBNull.Value Then
            ExtraerImagen = arr
        Else
            ExtraerImagen = CType(res, Byte())
        End If
        Return ExtraerImagen
    End Function

    Public Function SumaColumna(ByVal dt As DataTable, ByVal Nombre_Columna As String) As Double
        SumaColumna = 0
        For Each f As DataRow In dt.Rows
            If IsNumeric(f(Nombre_Columna)) Then
                SumaColumna += f(Nombre_Columna)
            End If
        Next
        Return SumaColumna
    End Function
    Public Sub Confirmacion(ByVal sMensaje As String)
        ' Envia mensajes para asp en forma directa para representar informacion  en pantalla
        Dim sb As New StringBuilder
        sMensaje = sMensaje.Replace("'", "")
        sMensaje = sMensaje.Replace("""", "")
        sMensaje = sMensaje.Replace(vbCrLf, "")
        'sb.Append("<script language=" + "'javascript'" + ">")
        sb.Append("Return Confirm( """ + sMensaje.Trim + """ );")
        'sb.Append("</script>")
        HttpContext.Current.Response.Write(sb)
    End Sub

    Function Alltrim(ByVal Tm_Campo As String) As String
        Tm_Campo = LTrim(Tm_Campo)
        Alltrim = Trim(Tm_Campo)
    End Function
    Public Function DevuelveT_F(ByVal valor As String) As Boolean
        If valor = "S" Then
            DevuelveT_F = True
        Else
            DevuelveT_F = False
        End If
    End Function
    Public Function Fecha_AMD(ByVal Tw_Fecha As Date) As String
        Fecha_AMD = Tw_Fecha.Year & "/" & Format(Tw_Fecha.Month, "0#") & "/" & Format(Tw_Fecha.Day, "0#")
    End Function
    'Public Function Checar_Periodo(ByRef G As Glo, ByVal Fecha As String) As Boolean


    'End Function
    Public Function Encripta(ByVal Pass As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Clave = "BFMAFB"
        Pass2 = ""
        For i = 1 To Len(Pass)
            CAR = Mid(Pass, i, 1)
            Codigo = Mid(Clave, ((i - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Right("0" & Hex(Asc(Codigo) Xor Asc(CAR)), 2)
        Next i
        Encripta = Pass2
    End Function
    Public Function DesEncripta(ByVal Pass As String) As String
        Dim Clave As String, i As Integer, Pass2 As String
        Dim CAR As String, Codigo As String
        Dim j As Integer
        Clave = "BFMAFB"
        Pass2 = ""
        j = 1
        For i = 1 To Len(Pass) Step 2
            CAR = Mid(Pass, i, 2)
            Codigo = Mid(Clave, ((j - 1) Mod Len(Clave)) + 1, 1)
            Pass2 = Pass2 & Chr(Asc(Codigo) Xor Val("&h" + CAR))
            j = j + 1
        Next i
        DesEncripta = Pass2
    End Function
    'Public Sub Ejecuta_Est(ByVal tsql As String)
    '    Try
    '        com.CommandText = tsql
    '        cn.Open()
    '        com.ExecuteNonQuery()

    '    Catch ex As Exception
    '    Finally
    '        cn.Close()
    '    End Try
    'End Sub
    Public Function For_Num(ByVal Valor As String, ByVal Formato As Integer) As Double
        For_Num = 0
        Select Case Formato
            Case 2
                For_Num = Math.Round(Val(Elimina_Comas(Valor)), 2)
            Case 0
                For_Num = Math.Round(Val(Elimina_Comas(Valor)), 0)
            Case 1
                For_Num = Math.Round(Val(Elimina_Comas(Valor)), 1)
        End Select
        Return For_Num
    End Function
    Public Function DevuelveS_N(ByVal valor As Boolean) As String
        If valor = True Then
            DevuelveS_N = "S"
        Else
            DevuelveS_N = "N"
        End If
    End Function
    Public Function Pone_Apos(ByVal Txm_Texto As String) As String

        Txm_Texto = Replace(Txm_Texto, "'", "")
        If Txm_Texto Is Nothing Then
            Pone_Apos = "''"
        Else

            Pone_Apos = "'" & Txm_Texto.Trim & "'"
        End If

        'Txm_Texto = Replace(Txm_Texto, "'", "")
        'Pone_Apos = "'" & Txm_Texto.Trim & "'"
    End Function
    Public Function Elimina_Comas(ByVal txw_Impor As String) As String
        Dim T_Ultpos As Integer
        Dim Tw_Numero As String
        Dim T_Len As Integer
        Dim T_Co As Integer = 0
        T_Ultpos = 1
        Tw_Numero = ""
        txw_Impor = LTrim(RTrim(txw_Impor))
        T_Len = Len(txw_Impor)
        For T_Co = 1 To T_Len
            If Mid(txw_Impor, T_Co, 1) <> "," Then
                If Mid(txw_Impor, T_Co, 1) <> "$" Then
                    If Mid(txw_Impor, T_Co, 1) <> "/" Then
                        Tw_Numero = Tw_Numero & Mid(txw_Impor, T_Co, 1)
                    End If
                End If
            End If
        Next
        Elimina_Comas = Tw_Numero
    End Function
    Public Function Elimina_gato(ByVal txw_Impor As String) As String
        Dim T_Ultpos As Integer
        Dim Tw_Numero As String
        Dim T_Len As Integer
        Dim T_Co As Integer = 0
        T_Ultpos = 1
        Tw_Numero = ""
        txw_Impor = LTrim(RTrim(txw_Impor))
        T_Len = Len(txw_Impor)
        For T_Co = 1 To T_Len
            If Mid(txw_Impor, T_Co, 1) <> "#" Then
                Tw_Numero = Tw_Numero & Mid(txw_Impor, T_Co, 1)
            End If
        Next
        Elimina_gato = Tw_Numero
    End Function
    'Public Function Buscar_Cat(ByVal Txw_Catalogo As String, ByVal Txw_Campo As String) As String
    '    Txw_Catalogo = Txw_Catalogo.ToString.ToUpper
    '    Buscar_Cat = ""
    '    Select Case Txw_Catalogo
    '        Case "MONEDA"
    '            Tsql = "Select Nombre,Abreviatura  From Moneda Where  MonedaNumero=" & Val(Txw_Campo)
    '    End Select
    '    Dim dr As SqlDataReader
    '    Dim cn As New SqlConnection(Conexion)
    '    Dim com As New SqlCommand(Tsql, cn)
    '    cn.Open()
    '    dr = com.ExecuteReader
    '    If dr.Read = True Then
    '        Select Case Txw_Catalogo
    '            Case "MONEDA"
    '                Buscar_Cat = dr.Item("Nombre").ToString
    '                Vg_Abreviatura = dr.Item("Abreviatura").ToString
    '        End Select
    '    End If
    '    cn.Close()
    'End Function
    Public Function Num_A_Let(ByVal TW_IMPORTE As Double, ByVal Nom_Moneda As String, ByVal Abreviatura As String) As String
        ' Convierte de numeros a letras
        Dim Tw_Dato As String
        Dim Tw_Dato_sinpun As String
        Dim Dat As Integer
        Dim Tw_PosPun As Integer
        Dim Tw_Decimales As String
        Dim Tw_Long As Integer
        Dim Tw_Ponlon As Integer
        Dim DatX As String = ""
        Dim Dat1 As Integer
        If TW_IMPORTE = 0 Then
            Num_A_Let = "CERO"
            'Exit Sub
        End If
        If Math.Abs(Val(TW_IMPORTE)) < 0.01 Then
            Num_A_Let = "CERO"
            'Exit Sub
        End If
        Tw_Dato = Str(TW_IMPORTE)
        Tw_PosPun = InStr(1, Trim(Tw_Dato), ".")
        Tw_Dato_sinpun = IIf(Tw_PosPun > 0, Mid(Tw_Dato, 1, Tw_PosPun), Tw_Dato)
        Tw_Decimales = IIf(Tw_PosPun > 0, Mid(Tw_Dato, Tw_PosPun + 2, 2), "00")
        Tw_Decimales = IIf(Len(Tw_Decimales) = 1, Trim(Tw_Decimales) & "0", Tw_Decimales)
        'TW_DECIMAL = IIf(TW_DECIMALES < 10, "0" & Trim(TW_DECIMALES), Trim(TW_DECIMALES))
        Tw_Long = Len(Tw_Dato_sinpun)
        Tw_Ponlon = 12 - Tw_Long
        Tw_Dato_sinpun = Space(Tw_Ponlon) & Tw_Dato_sinpun
        Dim Res As String
        Res = "("
        For Tw_co As Integer = 1 To 11
            ' Toma las centenas de cada parte del numero
            If Tw_co = 1 Or Tw_co = 4 Or Tw_co = 7 Or Tw_co = 10 Then
                Dat = Val(Mid(Tw_Dato_sinpun, Tw_co, 1))
                Select Case Dat
                    Case 1
                        Res = IIf(Val(Mid(Tw_Dato_sinpun, Tw_co + 1, 2)) > 0, Res & "CIENTO ", Res & "CIEN ")
                    Case 2
                        Res = Res & "DOSCIENTOS "
                    Case 3
                        Res = Res & "TRESCIENTOS "
                    Case 4
                        Res = Res & "CUATROCIENTOS "
                    Case 5
                        Res = Res & "QUINIENTOS "
                    Case 6
                        Res = Res & "SEISCIENTOS "
                    Case 7
                        Res = Res & "SETECIENTOS "
                    Case 8
                        Res = Res & "OCHOCIENTOS "
                    Case 9
                        Res = Res & "NOVECIENTOS "
                End Select
            End If
            ' TOMA DECENAS
            If Tw_co = 2 Or Tw_co = 5 Or Tw_co = 8 Or Tw_co = 11 Then
                Dat = Val(Mid(Tw_Dato_sinpun, Tw_co, 2))

                If Tw_co = 2 Then
                    DatX = "MIL "
                End If
                If Tw_co = 5 And Val(Mid(Tw_Dato_sinpun, 4, 3)) > 1 Then
                    DatX = "MILLONES "
                End If
                If Tw_co = 5 And Val(Mid(Tw_Dato_sinpun, 4, 3)) = 1 Then
                    DatX = "MILLON "
                End If
                DatX = IIf(Tw_co = 8, "MIL ", DatX)
                DatX = IIf(Tw_co = 11, " ", DatX)
                If Dat > 10 And Dat < 16 Or Dat > 20 And Dat < 30 Then
                    Select Case Dat
                        Case 11
                            Res = Res & "ONCE " & DatX
                        Case 12
                            Res = Res & "DOCE " & DatX
                        Case 13
                            Res = Res & "TRECE " & DatX
                        Case 14
                            Res = Res & "CATORCE " & DatX
                        Case 15
                            Res = Res & "QUINCE " & DatX
                        Case 21
                            Res = Res & "VEINTIUN " & DatX
                        Case 22
                            Res = Res & "VEINTIDOS " & DatX
                        Case 23
                            Res = Res & "VEINTITRES " & DatX
                        Case 24
                            Res = Res & "VEINTICUATRO " & DatX
                        Case 25
                            Res = Res & "VEINTICINCO " & DatX
                        Case 26
                            Res = Res & "VEINTISEIS " & DatX
                        Case 27
                            Res = Res & "VEINTISIETE " & DatX
                        Case 28
                            Res = Res & "VEINTIOCHO " & DatX
                        Case 29
                            Res = Res & "VEINTINUEVE " & DatX
                    End Select
                    'Res = Res & DATX
                Else
                    Dat1 = Val(Mid(Tw_Dato_sinpun, Tw_co, 1))
                    Select Case Dat1
                        Case 1
                            Res = Res & "DIEZ "
                        Case 2
                            Res = Res & "VEINTE "
                        Case 3
                            Res = Res & "TREINTA "
                        Case 4
                            Res = Res & "CUARENTA "
                        Case 5
                            Res = Res & "CINCUENTA "
                        Case 6
                            Res = Res & "SESENTA "
                        Case 7
                            Res = Res & "SETENTA "
                        Case 8
                            Res = Res & "OCHENTA "
                        Case 9
                            Res = Res & "NOVENTA "
                    End Select
                    If Tw_co = 2 Or Tw_co = 5 Or Tw_co = 8 Or Tw_co = 11 Then
                        Dat1 = Val(Mid(Tw_Dato_sinpun, Tw_co + 1, 1))
                        If Dat1 > 0 And Val(Mid(Tw_Dato_sinpun, Tw_co, 1)) > 0 Then
                            Res = Res & "Y "
                        End If
                        Select Case Tw_co
                            Case 2
                                Res = IIf(Dat1 = 0 And Val(Mid(Tw_Dato_sinpun, 1, 3)) > 0, Res & "MIL MILLONES ", Res)
                                DatX = "MIL "
                            Case 5
                                If Val(Mid(Tw_Dato_sinpun, 4, 3)) <> 1 Then
                                    Res = IIf(Dat1 = 0 And Val(Mid(Tw_Dato_sinpun, 4, 3)) > 0, Res & "MILLONES ", Res)
                                    DatX = "MILLONES "
                                Else
                                    If Val(Mid(Tw_Dato_sinpun, 4, 3)) = 1 Then
                                        Res = IIf(Dat1 = 0 And Val(Mid(Tw_Dato_sinpun, 4, 3)) > 0, Res & "MILLONES ", Res)
                                        DatX = "MILLON "
                                    Else
                                        If Mid(Tw_Dato_sinpun, 4, 3) = "000" Then
                                            Res = Res & "MILLONES "
                                            DatX = "MILLONES "
                                        End If
                                    End If
                                End If
                            Case 8
                                If Val(Mid(Tw_Dato_sinpun, 7, 2)) > 0 And Val(Mid(Tw_Dato_sinpun, 9, 1)) = 0 Then
                                    Res = IIf(Val(Mid(Tw_Dato_sinpun, 7, 3)) > 0, Res & "MIL ", Res)
                                End If
                                DatX = "MIL "
                        End Select
                        Select Case Dat1
                            Case 1
                                Res = IIf(Res <> " ", Res & "UN " & DatX, Res & "UN " & DatX)
                            Case 2
                                Res = Res & "DOS " & DatX
                            Case 3
                                Res = Res & "TRES " & DatX
                            Case 4
                                Res = Res & "CUATRO " & DatX
                            Case 5
                                Res = Res & "CINCO " & DatX
                            Case 6
                                Res = Res & "SEIS " & DatX
                            Case 7
                                Res = Res & "SIETE " & DatX
                            Case 8
                                Res = Res & "OCHO " & DatX
                            Case 9
                                Res = Res & "NUEVE " & DatX
                        End Select
                    End If
                End If
            End If
            Dim Len_Datos As Integer
            Dim Cer_Dat As String

            If Tw_co = 11 Then
                Cer_Dat = Tw_Dato_sinpun.Trim
                Len_Datos = Len(Cer_Dat)
                Cer_Dat = Mid(Cer_Dat, 2, Len_Datos)
                Dat1 = Val(Tw_Dato_sinpun)
                Res = IIf(Res = "", "CERO ", Res)
                'Dim Nom_Moneda As String
                'Nom_Moneda = Buscar_Cat("MONEDA", Twx_Moneda)
                If Val(Cer_Dat) = 0 And Val(Dat1) > 999999 Then
                    Res = Trim(Res) & " DE " & Nom_Moneda
                Else
                    If Nom_Moneda.ToUpper = "DOLAR" Then Nom_Moneda = "Dolares"
                    Res = IIf(Dat1 = 1 And Trim(Res) = "UN", Trim(Res) & " PESO ", Trim(Res) & " " & Nom_Moneda)
                End If
                Res = Res & " " & Tw_Decimales & "/100 " & Abreviatura & ")"
            End If
        Next
        Num_A_Let = Res
    End Function



    'Public Function EjecutaTransaccion_Ant(ByVal ListaSentencias As ArrayList) As Boolean
    '    EjecutaTransaccion_Ant = False
    '    Dim otransaccion As SqlTransaction = Nothing
    '    Dim sentencia As String
    '    Try
    '        otransaccion = cn.BeginTransaction
    '        com.CommandText = Tsql
    '        com.Transaction = otransaccion
    '        For Each strSentencia In ListaSentencias
    '            sentencia = strSentencia.ToString()
    '            com.CommandText = sentencia.ToString()
    '            com.Transaction = otransaccion
    '            com.ExecuteNonQuery()
    '        Next
    '        otransaccion.Commit()
    '        Return True
    '    Catch ex As Exception
    '        If Not otransaccion Is Nothing Then
    '            otransaccion.Rollback() 'deshacer transaccion 
    '        End If
    '        Return False
    '    End Try
    'End Function
    Public Function EjecutaTransaccion(ByVal ListaSentencias As ArrayList, ByRef cn As SqlConnection) As Boolean
        EjecutaTransaccion = False
        Dim com As New SqlCommand("", cn)
        Dim otransaccion As SqlTransaction = Nothing
        Dim sentencia As String
        Try
            otransaccion = cn.BeginTransaction
            com.Transaction = otransaccion
            For Each strSentencia As String In ListaSentencias
                sentencia = strSentencia.ToString()
                com.CommandText = sentencia.ToString()
                com.Transaction = otransaccion
                com.ExecuteNonQuery()
            Next
            otransaccion.Commit()
            Return True
        Catch ex As Exception
            If Not otransaccion Is Nothing Then
                otransaccion.Rollback() 'deshacer transaccion 
            End If
            Return False
        End Try
    End Function

    'Public Sub Genera_Poliza_Contabilidad(ByVal com As SqlCommand, ByVal Tw_Cuenta_Contable As String, ByVal Tw_Importe As Double, ByVal Tw_Cargo_Abono As String, ByVal Tw_Concepto As String, _
    '                                  ByVal Tw_Descripcion As String, ByVal Tww_Fecha_Dias As String, ByVal Tww_Hor_Min_Seg As String, ByVal Tww_Sec_Poliza As String, _
    '                                  ByVal Tww_Numero_compañia As Integer, ByVal Tww_Tipo_Poliza As String, ByVal Tww_Numero_Poliza As Integer, ByVal Tww_Ref_Cont As String)
    '    Tsql = "Insert into Movimientos" & Val(Mid(Tww_Fecha_Dias.Trim, 6, 2))
    '    Tsql += "  (Numero_Compañia,Numero_Periodo,Tipo_Poliza,Numero_Poliza,Secuencia_Poliza,Numero_cuenta,"
    '    Tsql += "Descripcion_Movimiento,Fecha_Poliza,Cargo_Abono,Importe_Movimiento,Referencia,Fecha_Referencia"
    '    Tsql += ",Descripcion) Values ("
    '    Dim Descripcion As String
    '    If Tw_Descripcion.Trim = "" Then
    '        Descripcion = Tw_Concepto.Trim & " " & Tww_Hor_Min_Seg.Trim
    '    Else
    '        Descripcion = Tw_Descripcion.Trim
    '    End If

    '    'Tww_Sec_Poliza += 1
    '    Descripcion = UCase(Descripcion)

    '    Tsql += Tww_Numero_compañia & ","
    '    Tsql += Val(Mid(Tww_Fecha_Dias.Trim, 6, 2)) & ","
    '    Tsql += Pone_Apos(Tww_Tipo_Poliza) & ","
    '    Tsql += Tww_Numero_Poliza & ","
    '    Tsql += Tww_Sec_Poliza & ","
    '    Tsql += Pone_Apos(Tw_Cuenta_Contable) & ","
    '    Tsql += Pone_Apos(Descripcion) & ","
    '    Tsql += Pone_Apos(Tww_Fecha_Dias) & ","
    '    Tsql += Pone_Apos(Tw_Cargo_Abono) & ","
    '    Tsql += Tw_Importe & ","
    '    Tsql += Pone_Apos(Tww_Ref_Cont) & ","
    '    Tsql += Pone_Apos(Tww_Fecha_Dias) & ","
    '    Tsql += Pone_Apos(Mid(Descripcion, 1, 55)) & ")"
    '    com.CommandText = Tsql
    '    com.ExecuteNonQuery()
    'End Sub
    Public Function Consulta_Valor(ByVal com As SqlCommand, ByVal Tsql As String) As Object
        Consulta_Valor = ""
        com.CommandText = Tsql
        Consulta_Valor = com.ExecuteScalar()
    End Function
    Public Function AString(ByVal valor As Object) As String
        If valor Is DBNull.Value Or valor Is Nothing Then
            AString = ""
        Else
            AString = valor
        End If
    End Function

End Module
