Imports System.Data
Partial Class Comp_Compras_Requisiciones
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
            Session("dt") = New DataTable
            CrearCamposTabla()
            If G.ChekeadoFechas = True Then
                Ch_Fechas.Checked = True
            Else
                Ch_Fechas.Checked = False
            End If
            If G.FiltroComparativo <> "" Or G.ChekeadoFechas = False Then
                Pnl_Grids.Visible = True
                TB_Solicitante.Text = G.Arr_FiltroComparativo(0)
                TB_Centro_Costo.Text = G.Arr_FiltroComparativo(1)
                TB_Requisicion.Text = G.Arr_FiltroComparativo(2)
                TB_Fecha_Inicial.Text = G.Arr_FiltroComparativo(3)
                TB_Fecha_Final.Text = G.Arr_FiltroComparativo(4)
                LlenaGrid()
            Else
                'LlenaGrid()
                TB_Fecha_Final.Text = Fecha_AMD(Now)
                TB_Fecha_Inicial.Text = Fecha_AMD(Now)
            End If

        End If
        Btn_CentroCostos.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=CENTRO_COSTOS',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        Btn_Solicitante.Attributes.Add("onclick", "window.open('Bus_Cat.aspx?Catalogo=SOLICITANTE',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        TB_Requisicion.Attributes.Add("onkeydown", "javascript: PierdeFoco('" & Btn_Busca.ClientID & "');")

        Msg_Err.Visible = False
    End Sub
    Private Sub CrearCamposTabla()
        Session("dt").Columns.Add("Requisicion", Type.GetType("System.Int64")) : Session("dt").Columns("Requisicion").DefaultValue = 0
        Session("dt").Columns.Add("Solicitante", Type.GetType("System.Int64")) : Session("dt").Columns("Solicitante").DefaultValue = 0
        Session("dt").Columns.Add("Nom_Solicitante", Type.GetType("System.String")) : Session("dt").Columns("Nom_Solicitante").DefaultValue = ""
        Session("dt").Columns.Add("CenCos", Type.GetType("System.Int64")) : Session("dt").Columns("CenCos").DefaultValue = 0
        Session("dt").Columns.Add("CenCos_Descripcion", Type.GetType("System.String")) : Session("dt").Columns("CenCos_Descripcion").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Solicitud", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Solicitud").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Requiere", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Requiere").DefaultValue = ""
        Session("dt").Columns.Add("Fecha_Libera_Almacen", Type.GetType("System.String")) : Session("dt").Columns("Fecha_Libera_Almacen").DefaultValue = ""
        Session("dt").Columns.Add("Lugar_Entrega", Type.GetType("System.String")) : Session("dt").Columns("Lugar_Entrega").DefaultValue = ""
        Dim clave(0) As DataColumn
        clave(0) = Session("dt").Columns("Requisicion")
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
            G.Tsql = "Select top 200 Requisicion,Solicitante,CenCosto as CenCos,Fecha_Solicitud,Fecha_Requiere,Lugar_Entrega,Fecha_Libera_Almacen "
            G.Tsql &= ", (Select top 1 Nombre From Solicitante Where Solicitante=a.Solicitante and Obra=" & Pone_Apos(G.Sucursal) & " and Cia=" & Val(Session("Cia")) & ") as Nom_Solicitante "
            G.Tsql &= ", (Select top 1 Descripcion From Centro_Costos Where Centro_Costos=a.CenCosto and Obra=" & Pone_Apos(G.Sucursal) & " and Cia=" & Val(Session("Cia")) & ") as CenCos_Descripcion "
            G.Tsql &= " from Requisicion  a Where Tipo=0 and Estatus='00' "
            G.FiltroComparativo = ""
            If Val(TB_Solicitante.Text) <> 0 Then
                G.Tsql &= " and Solicitante =" & Val(TB_Solicitante.Text)
                G.FiltroComparativo &= " and Solicitante =" & Val(TB_Solicitante.Text)
            End If
            If Val(TB_Centro_Costo.Text) <> 0 Then
                G.Tsql &= " and CenCosto =" & Val(TB_Centro_Costo.Text)
                G.FiltroComparativo &= " and CenCosto =" & Val(TB_Centro_Costo.Text)
            End If
            If Val(TB_Requisicion.Text) <> 0 Then
                G.Tsql &= " and Requisicion=" & Val(TB_Requisicion.Text)
                G.FiltroComparativo &= " and Requisicion=" & Val(TB_Requisicion.Text)
            Else
                If Ch_Fechas.Checked = True Then
                    G.Tsql &= " and a.Fecha_Solicitud between " & Pone_Apos(TB_Fecha_Inicial.Text) & " And " & Pone_Apos(TB_Fecha_Final.Text)
                    G.FiltroComparativo &= " and a.Fecha_Solicitud between " & Pone_Apos(TB_Fecha_Inicial.Text) & " And " & Pone_Apos(TB_Fecha_Final.Text)
                End If
            End If
            G.Arr_FiltroComparativo(0) = TB_Solicitante.Text
            G.Arr_FiltroComparativo(1) = TB_Centro_Costo.Text
            G.Arr_FiltroComparativo(2) = TB_Requisicion.Text
            G.Arr_FiltroComparativo(3) = TB_Fecha_Inicial.Text
            G.Arr_FiltroComparativo(4) = TB_Fecha_Final.Text
            If Ch_Fechas.Checked Then
                G.ChekeadoFechas = True
            Else
                G.ChekeadoFechas = False
            End If
            G.Tsql &= " and Cia=" & Val(Session("Cia"))
            G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
            G.Tsql &= " and Fecha_Libera_Almacen>''"
            G.Tsql &= " Order by Requisicion Desc"
            G.com.CommandText = G.Tsql
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
            Dim clave(0) As DataColumn
            clave(0) = Session("dt").Columns("Requisicion")
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

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            If (e.CommandName.Equals("Ver")) Then
                Dim ind As Integer = Convert.ToInt32(e.CommandArgument)
                Dim Clave(0) As String
                Clave(0) = (GridView1.Rows(ind).Cells(1).Text)
                Dim f As DataRow = Session("dt").Rows.Find(Clave)
                If Not f Is Nothing Then
                    G.Num_Requisicion = f("Requisicion")
                    G.Glo_Solicitante = f("Solicitante")
                    G.Glo_Centro_Costos = f("CenCos")
                    Dim Liberados As Integer = 0
                    G.Tsql = "Select Count(Libero_Almacen) From Requisicion"
                    G.Tsql &= " where Requisicion=" & Val(f("Requisicion"))
                    G.Tsql &= " and Cia=" & Val(Session("Cia"))
                    G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                    G.Tsql &= " and Libero_Almacen='S'"
                    G.cn.Open()
                    G.com.CommandText = G.Tsql
                    Liberados = Val(G.com.ExecuteScalar)
                    G.cn.Close()
                    If Liberados > 0 Then
                        Response.Redirect("Comp_Compras_Detalle.aspx")
                    Else
                        Msg_Error("La requisición no tiene ninguna partida liberada")
                    End If
                    'Response.Redirect("Comp_Compras_Detalle.aspx?req=" & f("Requisicion") & "&ste=" & f("Solicitante") & "&cen=" & f("CenCos_Descripcion"))
                End If
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        End Try
       
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim clave(0) As String
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            clave(0) = GridView1.DataKeys(GridView1.SelectedIndex).Item("Requisicion").ToString
            Dim f As DataRow = Session("dt").Rows.Find(clave)
            If Not f Is Nothing Then
                G.Num_Requisicion = f("Requisicion")
                G.Glo_Solicitante = f("Solicitante")
                G.Glo_Centro_Costos = f("CenCos")
                Dim Liberados As Integer = 0
                G.Tsql = "Select Count(Libero_Almacen) From Requisicion"
                G.Tsql &= " where Requisicion=" & Val(f("Requisicion"))
                G.Tsql &= " and Cia=" & Val(Session("Cia"))
                G.Tsql &= " and Obra=" & Pone_Apos(Session("Obra"))
                G.Tsql &= " and Libero_Almacen='S'"
                G.cn.Open()
                G.com.CommandText = G.Tsql
                Liberados = Val(G.com.ExecuteScalar)
                G.cn.Close()
                If Liberados > 0 Then
                    Response.Redirect("Comp_Compras_Detalle.aspx")
                Else
                    Msg_Error("La requisición no tiene ninguna partida liberada")
                End If
                'Response.Redirect("Comp_Compras_Detalle.aspx?req=" & f("Requisicion") & "&ste=" & f("Solicitante") & "&cen=" & f("CenCos_Descripcion"))
            End If
        Catch ex As Exception
            Msg_Error(ex.Message.ToString)
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LlenaGrid()
        End If
    End Sub

    Protected Sub Btn_Busca_Click(sender As Object, e As System.EventArgs) Handles Btn_Busca.Click
        GridView1.PageIndex = 0
        LlenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub Btn_Salir_Click(sender As Object, e As System.EventArgs) Handles Btn_Salir.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Dim G As Glo = CType(Session("G"), Glo)
        G.FiltroComparativo = ""
        G.ChekeadoFechas = True
        For index = 0 To G.Arr_FiltroComparativo.Length - 1
            G.Arr_FiltroComparativo(index) = ""
        Next

        Response.Redirect("Menu.aspx")
    End Sub

    Protected Sub Ch_Fechas_CheckedChanged(sender As Object, e As System.EventArgs) Handles Ch_Fechas.CheckedChanged
        LlenaGrid()
        Pnl_Grids.Visible = True
    End Sub

    Protected Sub TB_Requisicion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB_Requisicion.TextChanged
        LlenaGrid()
        Pnl_Grids.Visible = True

    End Sub
End Class
