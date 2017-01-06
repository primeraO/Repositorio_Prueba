<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu.aspx.vb" Inherits="Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server">--%>
     <link href="simple-sidebar.css" rel="stylesheet" type="text/css" />
     <link href="Ejemplo_Estilos.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="jquery.min.js"></script>
    <script language="javascript" src="bootstrapjs.min.js" type="text/javascript"></script>
    
    <form id="form1" runat="server">
    
     <nav class="navbar navbar-default" role="navigation">
      <!-- El logotipo y el icono que despliega el menú se agrupan
           para mostrarlos mejor en los dispositivos móviles -->
      <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse"
                data-target=".navbar-ex1-collapse">
          <span class="sr-only">Desplegar navegación</span>
        </button>
          <%-- <a class="navbar-brand" href="Menu.aspx">Página Principal</a>--%>
      </div>
 
      <!-- Agrupar los enlaces de navegación, los formularios y cualquier
           otro elemento que se pueda ocultar al minimizar la barra -->
          <%-- <li><a href="C_Acceso.aspx?form=Catalogo_Actividad_Obra">Actividad en Obra</a></li>--%>
      <div class="collapse navbar-collapse navbar-ex1-collapse">
       <ul class="nav nav-tabs">
          <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
              Catálogos<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
                         <li class="menu-item dropdown dropdown-submenu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Catalogos </a>
                    <ul class="dropdown-menu">
                        <li class="menu-item ">                            
                            <a href="C_Acceso.aspx?form=Catalogo_Moneda">Moneda</a>                            
                            <a href="C_Acceso.aspx?form=Catalogo_Pais">País</a>        
                            <a href="C_Acceso.aspx?form=Catalogo_Tipo_Cambio">Tipo de Cambio</a>
                          <%--  <a href="C_Acceso.aspx?form=Catalogo_Cuenta_IEPS">Cuenta IEPS</a>--%>
                            
                        <%--<a href="C_Acceso.aspx?form=C_Entradas_Detalle_IEPS">Cuenta IEPS</a>--%>

                           
                        </li>                        
                 </ul>
              </li>
             <li class="menu-item dropdown dropdown-submenu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Articulos  </a>
                    <ul class="dropdown-menu">
                        <li class="menu-item ">                            
                        <a href="C_Acceso.aspx?form=Catalogo_Articulos">Artículos</a>
                        <%--<a href="C_Acceso.aspx?form=Catalogo_Articulo_Proveedor">Artículo-Proveedor</a>--%>
                            
                            <a href="C_Acceso.aspx?form=Catalogo_Linea">Grupo</a>
                            <%--<a href="C_Acceso.aspx?form=Catalogo_Marca">Marca</a>--%>
                            <a href="C_Acceso.aspx?form=Catalogo_SubLinea">Sub-Grupo</a>                            
                        </li>                        
                 </ul>
              </li>

               <li class="menu-item dropdown dropdown-submenu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Compras  </a>
                    <ul class="dropdown-menu">
                        <li class="menu-item ">                            
                             
                             <a href="C_Acceso.aspx?form=Catalogo_Condicion_Pago">Condicion de Pago</a>                                
                             <%--<li><a href="Catalogo_Transporte.aspx">Transporte</a></li>--%>
                             <%--<a href="C_Acceso.aspx?form=Catalogo_Comprador">Comprador</a>--%>
                             <a href="C_Acceso.aspx?form=Catalogo_Lugar_Entrega">Lugar Entrega</a>
                             <a href="C_Acceso.aspx?form=Catalogo_Proveedores">Proveedor</a>
                             <a href="C_Acceso.aspx?form=Cat_Articulo_Proveedor">Articulo - Proveedor</a>
                             <a href="C_Acceso.aspx?form=Cotizacion">Cotizacion</a>
                             <a href="C_Acceso.aspx?form=Catalogo_Cliente">Cliente</a>
                             <a href="C_Acceso.aspx?form=Catalogo_Agente">Agente</a>
                        </li>                        
                 </ul>
              </li>

              
               
               <li class="menu-item dropdown dropdown-submenu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Sucursal </a>
                    <ul class="dropdown-menu">
                        <li class="menu-item ">                                                         
                          <%-- <a href="C_Acceso.aspx?form=Catalogo_Actividad_Frente" >Actividad - Frente</a>--%>
                           <a href="C_Acceso.aspx?form=Catalogo_Area">Area</a>
                           <a href="C_Acceso.aspx?form=Catalogo_Actividad_Area" >Concepto</a>
                           <%--<a href="C_Acceso.aspx?form=Catalogo_Concepto_Costo">Concepto de Costo MAQ</a>--%>
                          <%-- <a href="C_Acceso.aspx?form=Catalogo_Economico">Economico</a>--%>
                           <%--<a href="C_Acceso.aspx?form=Catalogo_Frente">Frente</a>  --%>                         
                           <a href="C_Acceso.aspx?form=Catalogo_Gasto">Gasto</a>
                          <%-- <a href="C_Acceso.aspx?form=Catalogo_Gasto_19">Gasto 19</a>--%>
                           <a href="C_Acceso.aspx?form=Catalogo_Solicitante">Solicitante</a>                                                      
                           <a href="C_Acceso.aspx?form=Catalogo_Terceros">Tercero</a>
                           <a href="C_Acceso.aspx?form=Catalogo_Tipo_Salida">Tipo de Salida</a>
                           <a href="C_Acceso.aspx?form=Catalogo_Tipo_Obra">Tipo de Sucursal</a>
                        </li>
                    </ul>
              </li>

                 <%--<li class="menu-item dropdown dropdown-submenu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Obra sub menu
                    </a>
                    <ul class="dropdown-menu">
                        <li class="menu-item ">
                            <a href="Catalogo_Obra.aspx">Obra
                            </a>
                        </li>
                        <li class="menu-item dropdown dropdown-submenu">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Level 2
                            </a>
                            <ul class="dropdown-menu">
                                <li>
                                    <a href="#">Link 3
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                 </li>--%>
                                  
            </ul>
          </li>



          <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
             Procesos<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
             
              <li><a href="C_Acceso.aspx?form=C_Entradas">Entradas</a></li>
              <li><a href="C_Acceso.aspx?form=C_Entradas_IEPS">Entradas IEPS</a></li>
             <%-- <li><a href="C_Acceso.aspx?form=C_Entradas_XML">Entradas por XML</a></li>--%>
               <li><a href="C_Acceso.aspx?form=Salidas_Almacen">Salidas</a></li>
               <li><a href="C_Acceso.aspx?form=Salidas_Multiples">Salidas Multiples</a></li>
              <%-- <li><a href="C_Acceso.aspx?form=Salidas_Clasificacion">Codificación de Salidas</a></li>    --%>                          
            </ul>
          </li>

           <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
             Compras<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
              <li><a href="C_Acceso.aspx?form=Requisiciones_Carga">Requisiciones</a></li>
              <li><a href="C_Acceso.aspx?form=Comp_Compras_Requisiciones">Comparativo</a></li>
              <li><a href="C_Acceso.aspx?form=Seleccion_Proveedor">Selección de Proveedores</a></li>              
              <li><a href="C_Acceso.aspx?form=Orden_Compra">Ordenes de Compra</a></li>
              </ul>
          </li>

          <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
             Consultas<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
              <li><a href="C_Acceso.aspx?form=C_Re_Impresion_Entradas">Reimpresión Entradas</a></li>
              <li><a href="C_Acceso.aspx?form=C_Re_Impresion_Entradas_IEPS">Reimpresión Entradas IEPS</a></li>
              <%--<li><a href="C_Acceso.aspx?form=Salidas_Multiples_Consulta">Consulta de Salidas Multiples</a></li>--%>
              <li><a href="C_Acceso.aspx?form=C_Consulta_Inventarios">Consulta Inventarios</a></li>              
              <li><a href="C_Acceso.aspx?form=C_Re_Impresion_Salidas">Reimpresión Salidas</a></li>
              <li><a href="C_Acceso.aspx?form=C_Reimpresion_Salidas_Multiples">Reimpresión Salidas Multiples</a></li>
              </ul>
          </li>
               <%--Aqui inicia el resguardo --%>
           <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
             Resguardos<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">             
              <li><a href="C_Acceso.aspx?form=C_Resguardo">Adiciona a Inventario de Resguardo</a></li>
              <li><a href="C_Acceso.aspx?form=C_Resguardo_Salidas">Salidas a Resguardo</a></li>
              <li><a href="C_Acceso.aspx?form=C_Resguardo_Entradas">Entrega de Resguardo</a></li>
            </ul>
          </li>
               <%--Temina resguardo--%>

          <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
               Reportes<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
               <li><a href="C_Acceso.aspx?form=R_0001">Caratula Por Artículo</a></li>
               <li><a href="C_Acceso.aspx?form=R_0002">Combustible Por Económico</a></li>
               <li><a href="C_Acceso.aspx?form=R_0003">Compras Por Proveedor</a></li>
               <li><a href="C_Acceso.aspx?form=R_0004">Consumo Por Artículo</a></li>
               <li><a href="C_Acceso.aspx?form=R_0005">Devoluciones Por Proveedor</a></li>
               <li><a href="C_Acceso.aspx?form=R_0006">Entradas Por Artículo Folio y Factura</a></li>
               <li><a href="C_Acceso.aspx?form=R_0007">Existencias Físicas</a></li>
               <li><a href="C_Acceso.aspx?form=R_Informe_Mensual">Informe Mensual</a></li>
               <li><a href="C_Acceso.aspx?form=R_0009">Consumo Por Económico</a></li>
               <li><a href="C_Acceso.aspx?form=R_0010">Lento Movimiento</a></li>
               <li><a href="C_Acceso.aspx?form=R_0011">Auxiliar Movimientos</a></li>
               <li><a href="C_Acceso.aspx?form=R_0012">Entradas Por Solicitante</a></li>
               <li><a href="C_Acceso.aspx?form=R_0013">Salidas Por Solicitante</a></li>

               <%-- <li><a href="R_Caratula_Por_Articulo.aspx">Caratula Por Artículo</a></li>
               <li><a href="R_Consumo_Por_Combustible.aspx">Combustible Por Económico</a></li>
                <li><a href="R_Compras_X_Proveedor.aspx">Compras Por Proveedor</a></li>
               <li><a href="R_Consumo_X_Articulo.aspx">Consumo Por Artículo</a></li>
               <li><a href="R_Devoluciones_X_Proveedor.aspx">Devoluciones Por Proveedor</a></li>
               <li><a href="R_Entradas_Articulo.aspx">Entradas Por Artículo Folio y Factura</a></li>
               <li><a href="R_Existencias_Fisicas.aspx">Existencias Físicas</a></li>
              <li><a href="R_Informe_Mensual.aspx">Informe Mensual</a></li>
                <li><a href="R_Consumo_Economico.aspx">Consumo Por Económico</a></li>
                <li><a href="R_Lento_Movimiento.aspx">Lento Movimiento</a></li>
                <li><a href="R_Auxiliar_Movimientos.aspx">Auxiliar Movimientos</a></li>
               <li><a href="R_Entradas_Solicitante.aspx">Entradas Por Solicitante</a></li>
               <li><a href="R_Salidas_Solicitante.aspx">Salidas Por Solicitante</a></li>--%>
            </ul>
          </li>
          <li class="dropdow">
            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
               Utilerias<span class="caret"></span>
            </a>
            <ul class="dropdown-menu">
             <li><a href="C_Acceso.aspx?form=Acceso">Acceso a Puntos de Menú</a></li>
             <li><a href="C_Acceso.aspx?form=Catalogo_Almacen">Almacen</a></li>
              <li><a href="C_Acceso.aspx?form=C_Ap_Cont_Inv">Aplicación Contable</a></li>
             <li><a href="C_Acceso.aspx?form=Catalogo_Claves_Autorizacion">Claves Autorización</a></li>  
             <li> <a href="C_Acceso.aspx?form=Catalogo_Compañia">Compañia</a></li>
             <li><a href="C_Acceso.aspx?form=Crea_Estructuras">Estructura</a></li>  
             <li><a href="C_Acceso.aspx?form=Catalogo_Firmas">Firmas</a></li>             
             <li><a href="C_Acceso.aspx?form=Migracion_Access_SQL">Migración bases de datos</a></li>              
             <li><a href="C_Acceso.aspx?form=Catalogo_Obra">Proyectos</a></li> 
              <li><a href="C_Acceso.aspx?form=Consulta_Seguimiento">Seguimiento</a></li>
              <li><a href="C_Acceso.aspx?form=Catalogo_Usuarios">Usuarios</a></li>             
              <li><a href="C_Acceso.aspx?form=Catalogo_Obras_Periodos">Cambio de Periodo </a></li>             
            </ul>
          </li>
          <li class="active pull-right">
                <a href="Default.aspx"><button type="button" class="Btn_Azul">Cerrar Sesión</button></a>
           </li>
        </ul>
      </div>
    </nav>
    <center >
        <img src="Imagenes/PUNTODEVENTA1.jpg" />
    </center>
    
</form>
    <%--<div id="wrapper">
		<div id="sidebar-wrapper">
            <ul class="sidebar-nav">
            	<li>
            		<a href="javascript:;" data-toggle="collapse" data-target="#demo"><i class="glyphicon glyphicon-book"></i> Catalogos </a>
            		<ul id="demo" class="collapse">
            			<li><a href="admn">Administradores</a></li>
            			<li><a href="ctes">Clientes</a></li>
						<li><a href="pais">Paises</a></li>
						<li><a href="edos">Estados</a></li>
						<li><a href="gpos">Lineas</a></li>
						<li><a href="categorias">Categorias</a></li>
						<li><a href="marcas">Marcas</a></li>
						<li><a href="arts">Productos</a></li>
						<li><a href="peds">Pedidos</a></li>
                    </ul>
                </li>
               	<li>
               		<a href="javascript:;" data-toggle="collapse" data-target="#demo1"><i class="glyphicon glyphicon-pushpin"></i> Pedidos </a>	
            		<ul id="demo1" class="collapse">
            			<li><a href="peds" class="Vis" class="text-primary"><b><span class="glyphicon glyphicon-chevron-right"></span> Surtir Pedidos</b></a></li>
            			<li><a href="reportsP" class="Vis" class="text-primary"><b><span class="glyphicon glyphicon-chevron-right"></span> Generar Reportes</b></a></li>
                    </ul>
                </li>     
                <li>
            		<a href="javascript:;" data-toggle="collapse" data-target="#demo2"><i class="glyphicon glyphicon-list-alt"></i> Reportes </a>
            		<ul id="demo2" class="collapse">
            			<li><a href="radmn" class="Vis" class="text-primary"><b>> Reporte de Usuarios.</b></a></li>
						<li><a href="rgpos" class="Vis" class="text-primary"><b>> Reporte Cat. de Lineas</b></a></li>
						<li><a href="rmarcas" class="Vis" class="text-primary"><b>> Reporte Cat. de Marcas</b></a></li>
						<li><a href="rarts" class="Vis" class="text-primary"><b>> Reporte de Articulos</b></a></li>
						<li><a href="rcat" class="Vis" class="text-primary"><b>> Reporte de Categorias</b></a></li>
                    </ul>
                </li>    
            </ul>
        </div>
    </div>--%><%--<div class="container-fluid">
    <div class="row">
        <div style="height: 100%; border-right-color: #e7e7e7; border-right-width: 1px; border-right-style: solid; width: 250px;">
            <ul class="nav nav-sidebar">
                <li class="active">
                    <a href="javascript:;"  data-toggle="collapse" data-target="#MCatalogos">Catalogos<span class="caret"></span></a>
                        <ul id="MCatalogos" class="collapse">
            			    <li><a href="Catalogo_Proveedores.aspx">Prveedores</a></li>
                            <li><a href="Catalogo_Economico.aspx">Economicos</a></li>
                            <li><a href="Catalogo_Moneda.aspx">Moneda</a></li>
                        </ul>
                </li>
                <li>
                    <a href="javascript:;"  data-toggle="collapse" data-target="#MReportes">Reportes<span class="caret"></span></a>
                    <ul id="MReportes" class="collapse">
            			    <li><a href="admn">Administradores</a></li>
                        </ul>
                </li>
                <li>
                    <a href="javascript:;"  data-toggle="collapse" data-target="#MProcesos">Procesos<span class="caret"></span></a>
                    <ul id="MProcesos" class="collapse">
            			    <li><a href="admn">Administradores</a></li>
                        </ul>
                </li>
                <li>
                    <a href="javascript:;"  data-toggle="collapse" data-target="#MUtilerias">Utilerias<span class="caret"></span></a>
                    <ul id="MUtilerias" class="collapse">
            			    <li><a href="admn">Administradores</a></li>
                        </ul>
                </li>
              </ul>
        </div>
        <div id="contenidos">

        </div>
    </div>
</div>--%>  <%--  </form>
</body>
</html>--%>
