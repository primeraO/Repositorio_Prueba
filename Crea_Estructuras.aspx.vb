Imports System.Data
Imports System.Data.SqlClient
Partial Class Crea_Estructuras
    Inherits System.Web.UI.Page
    Private Nom_Tabla As String

    Private Sub Crea_Tablas()

        Nom_Tabla = "Almacen"        
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Lote_Entrada Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Lote_Salida Int not null default(0)")

        Nom_Tabla = "Autorizacion_Claves"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Obra],[Numero])  ON [PRIMARY]")

        Nom_Tabla = "Autoriza_Requisicion"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Obra],[Requisicion])  ON [PRIMARY]")

        Nom_Tabla = "Articulo_Proveedor "
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Obra],[Pro_Numero],[Art_Numero])  ON [PRIMARY]")


        Nom_Tabla = "Seguimiento"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( Numero integer  IDENTITY (1, 1)  not null )")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Almacen Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Usuario Nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion_Punto nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Hora nvarchar(8) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add E_S nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Numero])  ON [PRIMARY]")




        Nom_Tabla = "Compañias"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Height Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Width Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Logo nvarchar(150) not null default('')")

        Nom_Tabla = "Tipo_Obra"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( Cia integer  not null default(0))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tipo_Obra integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion nvarchar(60) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Baja nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Tipo_Obra])  ON [PRIMARY]")

        Nom_Tabla = "Facturas_XML"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( UUID nvarchar(60) not null default(''))")        
        Ejecuta_Est("Alter table " & Nom_Tabla & " add RFC_Emisor	nvarchar(13) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add RFC_Receptor	nvarchar(13) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Timbre	nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add SubTotal float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Total float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add XML	nvarchar(MAX) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Serie nvarchar(30) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Folio Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tasa_Iva float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add IEPS float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tasa_IEPS float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([UUID])  ON [PRIMARY]")




        Nom_Tabla = "Economico"        
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Entrada nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Salida nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Estatus nvarchar(10) not null default('')")



        Nom_Tabla = "Gasto"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Gasto integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Gasto])  ON [PRIMARY]")

        Nom_Tabla = "Gasto_19"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Gasto integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Gasto])  ON [PRIMARY]")

        Nom_Tabla = "Lugar_Entrega"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia Int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Obra],[Numero])  ON [PRIMARY]")


        Nom_Tabla = "Movimientos_Inventario"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Multiple_Normal nvarchar(1) not null default('')")


        Nom_Tabla = "Obra"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion nvarchar(150) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Requisicion float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Orden float not null default(0)")



        Nom_Tabla = "Responsable"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tarjeta nvarchar(30) not null default('')")



        Nom_Tabla = "Requisicion"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Obra],[Requisicion],[Art_Numero])  ON [PRIMARY]")




        Nom_Tabla = "Resguardo"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Consecutivo integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Articulo nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cantidad float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add E_S nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Trabajador integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Observaciones nvarchar(250) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Serie nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Salida_Anterior integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Impreso nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Resguardo])  ON [PRIMARY]")

        Nom_Tabla = "Resguardo_Movimientos"
        Ejecuta_Est("Create table " & Nom_Tabla & " (Resguardo integer not null default(0))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Consecutivo integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Articulo nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add E_S nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Trabajador integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Observaciones nvarchar(250) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Consecutivo],[Resguardo])  ON [PRIMARY]")


        Nom_Tabla = "Solicitante"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tarjeta nvarchar(30) not null default('')")


        Nom_Tabla = "Tipo_Cambio"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( Mon_Numero integer not null default(0))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cambio float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cambio_Compras float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Cambio nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Baja nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Mon_Numero],[Fecha])  ON [PRIMARY]")


        Nom_Tabla = "Ordenes_Compra"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cia integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Orden nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Requisicion integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Art_Numero nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Cia],[Obra],[Numero_Orden],[Requisicion],[Art_Numero])  ON [PRIMARY]")


        Nom_Tabla = "Proveedor"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Contacto_Nombre nvarchar(60) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Contacto_Mail nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Contacto_Telefono nvarchar(20) not null default('')")

        Nom_Tabla = "Sub_Linea"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Clas_Corta nvarchar(5) not null default('')")

        Nom_Tabla = "Obra"
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Direccion nvarchar(250) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Colonia nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Ciudad nvarchar(30) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Estado nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Delegacion nvarchar(30) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add CP nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pais smallint not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Telefono nvarchar(18) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fax nvarchar(18) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Sup_Maq nvarchar(40) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Sup_con nvarchar(40) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Dir_Maq nvarchar(40) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Dir_Con nvarchar(40) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Ger_Con nvarchar(40) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Abreviatura nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Mail_Sup_Maq nvarchar(150) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Mail_Sup_Con nvarchar(150) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Mail_dir_Maq nvarchar(150) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Mail_Dir_Con nvarchar(150) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Mail_Ger_Con nvarchar(150) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Prefijo_Envio nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Folio_Envio int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Orden_Trabajo int not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Nombre nvarchar(60) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Activa nvarchar(1) not null default('')")


        Nom_Tabla = "Usuarios"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( UsuarioNumero integer not null default(0))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioClave nvarchar(300) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioNombre nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioReal nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioActivo nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioAdministrador nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioMail nvarchar(100) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Baja nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([UsuarioNumero])  ON [PRIMARY]")


        Nom_Tabla = "Punto_Menu"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( Clave_Punto nvarchar(250) not null default(''))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Clave_Modulo nvarchar(2) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion_Punto nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Baja nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Clave_Punto],[Clave_Modulo])  ON [PRIMARY]")


        Nom_Tabla = "Acceso"
        Ejecuta_Est("Create table " & Nom_Tabla & " ( Numero_Compañia integer not null default(0))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UsuarioNumero integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Clave_Punto nvarchar(250) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion_Punto nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Altas nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Bajas nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cambios nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Impresion nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Clave_Modulo nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_1 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_2 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_3 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_4 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_5 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_6 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_7 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pes_8 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add TA nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Numero_Compañia],[Obra],[UsuarioNumero],[Clave_Punto])  ON [PRIMARY]")

        '' ''Nom_Tabla = "Movimientos_Inventario"
        '' ''Ejecuta_Est("Create table " & Nom_Tabla & " ( Compania integer not null default(0))")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Almacen integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add E_S nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Lote integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Partida integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Secuencial integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Lote nvarchar(10) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Movimiento integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Articulo nvarchar(20) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Marca integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Linea integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Sub_Linea integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion nvarchar(20) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Unidad_Medida nvarchar(5) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Cantidad float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Cantidad_Salida float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Moneda integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Tipo_Cambio float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Precio_Unitario float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Proveedor integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Pais_Proveedor nvarchar(35) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Remision_Factura nvarchar(35) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Referencia nvarchar(35) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Movimiento nvarchar(10) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Documento integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Partida integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Almacen_Destin integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Existencia float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Valor_Inventario float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Costo float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Costo_Total float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Fletero integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add IEPS float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Pedimento nvarchar(20) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Entrada nvarchar(10) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Puerto_entrada nvarchar(50) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Procesada nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Proceso1 nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Proceso2 nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Proceso3 nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Tipo_Costo integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Elemento nvarchar(20) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Solicitante integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva_Flete float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Actividad nvarchar(50) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Descuento float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Pasa_Cont nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Ref_Flete nvarchar(30) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Ref_Aplica nvarchar(30) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Aplicacion integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add PU_Moneda float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva_Importe float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Mes integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Cambio nvarchar(10) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Es_Resguardo nvarchar(1) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add EDT nvarchar(20) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add UUID nvarchar(50) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Serie nvarchar(20) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add RFC nvarchar(13) not null default('')")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Tasa_Iva float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Total_Factura float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Sub_Total_Factura float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva_Factura float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Flete float not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add Centro_Costos integer not null default(0)")
        '' ''Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Compania],[Obra],[Almacen],[E_S],[Lote],[Partida])  ON [PRIMARY]")



    End Sub
    Public Sub Crea_Movimientos(ByVal Tw_Tabla As String)
        Nom_Tabla = Tw_Tabla
        Ejecuta_Est("Create table " & Nom_Tabla & " ( Compania integer not null default(0))")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Obra nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Almacen integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add E_S nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Lote integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Partida integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Secuencial integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Lote nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Movimiento integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Articulo nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Marca integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Linea integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Sub_Linea integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descripcion nvarchar(60) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Unidad_Medida nvarchar(5) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cantidad float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Cantidad_Salida float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Moneda integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tipo_Cambio float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Precio_Unitario float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Proveedor integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pais_Proveedor nvarchar(35) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Remision_Factura nvarchar(35) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Referencia nvarchar(35) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Movimiento nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Documento integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Partida integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Almacen_Destin integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Existencia float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Valor_Inventario float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Costo float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Costo_Total float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fletero integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add IEPS float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Pedimento nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Entrada nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Puerto_entrada nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Procesada nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Proceso1 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Proceso2 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Proceso3 nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tipo_Costo integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Elemento nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Solicitante integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva_Flete float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Actividad nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Descuento float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Pasa_Cont nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Ref_Flete nvarchar(30) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Ref_Aplica nvarchar(30) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Aplicacion integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PU_Moneda float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva_Importe float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Mes integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Fecha_Cambio nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Es_Resguardo nvarchar(1) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add EDT nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add UUID nvarchar(50) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Serie nvarchar(20) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add RFC nvarchar(13) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Tasa_Iva float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Total_Factura float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Sub_Total_Factura float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Iva_Factura float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Flete float not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Centro_Costos integer not null default(0)")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add Numero_Orden nvarchar(10) not null default('')")
        Ejecuta_Est("Alter table " & Nom_Tabla & " add PRIMARY KEY CLUSTERED ([Compania],[Obra],[Almacen],[E_S],[Lote],[Partida])  ON [PRIMARY]")

    End Sub

    Public Sub Ejecuta_Est(ByVal tsql As String)
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.com.CommandText = tsql
            G.cn.Open()
            G.com.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            G.cn.Close()
        End Try
    End Sub

    Protected Sub Btn_Salir_Click(sender As Object, e As System.EventArgs) Handles Btn_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Menu.aspx")
    End Sub

    Protected Sub Btn_Todas_Click(sender As Object, e As System.EventArgs) Handles Btn_Todas.Click
        Crea_Tablas()
        Crea_Movimientos("Movimientos_Inventario")
        Crea_Movimientos("Movimientos_Entradas")
        Crea_Movimientos("Movimientos_Salidas")
        Crea_Movimientos("Movimientos_Salida_Multiple")
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class
