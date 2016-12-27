Imports System.Data.SqlClient
Imports System.Data
Partial Class Empresa
    Inherits System.Web.UI.Page
    Private Num_Renglon As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        'Prueba de ver si jala
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If Page.IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            LLenaGrid()
        End If
    End Sub
    Private Sub LLenaGrid()
        dt = LLena_Datatable()
        If Session("dt").Rows.Count > 0 Then
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        Else
            Dim dr As DataRow = Session("dt").NewRow()
            dr("EmpresaNumero") = 0
            dr("EmpresaNombre") = ""
            dr("EmpresaRFC") = ""
            dr("Año") = ""
            Session("dt").Rows.Add(dr)
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            Dim TotalColumnas As Integer = GridView1.Rows(0).Cells.Count
            GridView1.Rows(0).Cells.Clear()
            GridView1.Rows(0).Cells.Add(New TableCell)
            GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumnas
            GridView1.Rows(0).Cells(0).Text = "No se encontró registro."
        End If
    End Sub
    Private Function LLena_Datatable() As DataTable
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            ' g.com.Connection = cn
            Session("dt") = New DataTable
            If Session("UsuarioNombre") = "Interaccion" Then
                G.com.CommandText = "Select EmpresaNumero,EmpresaNombre,EmpresaRFC,EmpresaLogo,Año from Empresas Order by EmpresaNumero"
            Else
                G.Tsql = "Select EmpresaNumero,EmpresaNombre,EmpresaRFC,EmpresaLogo,Año from Empresas "
                G.Tsql &= " Where EmpresaNumero=" & Val(Session("Empresa"))
                G.Tsql &= " Order by EmpresaNumero"
                G.com.CommandText = G.Tsql
            End If
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
        Catch ex As Exception
            Mensaje(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Return Session("dt")
    End Function

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        If Me.IsPostBack Then
            GridView1.PageIndex = e.NewPageIndex
            LLenaGrid()
        End If
    End Sub
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
        Image1.ImageUrl = "~/RetornaImagen.aspx?EmpresaNumero=" & 0
        FileUpload1.Enabled = False
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim G As Glo = CType(Session("G"), Glo)
        GridView1.EditIndex = e.NewEditIndex
        GridView1.DataSource = Session("dt")
        GridView1.DataBind()
        FileUpload1.Enabled = True
        Try
            G.cn.Open()
            ' g.com.Connection = cn
            Session("dt") = New DataTable
            If Session("UsuarioNombre") = "Interaccion" Then
                G.com.CommandText = "Select EmpresaNumero,EmpresaNombre,EmpresaRFC,EmpresaLogo,Año from Empresas Order by EmpresaNumero"
            Else
                G.Tsql = "Select EmpresaNumero,EmpresaNombre,EmpresaRFC,EmpresaLogo,Año from Empresas "
                G.Tsql &= " Where EmpresaNumero=" & Val(Session("Empresa"))
                G.Tsql &= " Order by EmpresaNumero"
                G.com.CommandText = G.Tsql
            End If
            G.dr = G.com.ExecuteReader
            Session("dt").Load(G.dr)
        Catch ex As Exception
            Mensaje(ex.Message.ToString)
        Finally
            G.cn.Close()
        End Try
        Dim EmpresaNumero As Label = CType(GridView1.Rows(e.NewEditIndex).FindControl("L_EmpresaNumero"), Label)
        Image1.ImageUrl = "~/RetornaImagen.aspx?EmpresaNumero=" & EmpresaNumero.Text
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim G As Glo = CType(Session("G"), Glo)
        If (e.CommandName.Equals("Insert")) Then
            Dim EmpresaNumero As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaNumero"), TextBox)
            Dim Empresanombre As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaNombre"), TextBox)
            Dim EmpresaRFC As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaRFC"), TextBox)
            Dim Año As TextBox = CType(GridView1.FooterRow.FindControl("T_Año"), TextBox)
            Try
                'Validar para inserción
                If Val(EmpresaNumero.Text) = 0 Then
                    Mensaje("Numero inválido") : Exit Sub
                End If
                If Empresanombre.Text.Trim = "" Then
                    Mensaje("Empresa inválida") : Exit Sub
                End If
                G.cn.Open()
                G.Tsql = "Select EmpresaNumero from Empresas Where EmpresaNumero=" & Val(EmpresaNumero.Text.Trim)
                Dim com As New SqlCommand(G.Tsql, G.cn)
                If Not G.com.ExecuteScalar Is Nothing Then
                    Mensaje("Ya existe") : Exit Sub
                End If

                G.Tsql = "Insert into Empresas (EmpresaNumero,EmpresaNombre,EmpresaRFC,Año) values ("
                G.Tsql &= Val(EmpresaNumero.Text.Trim)
                G.Tsql &= ",'" & Empresanombre.Text.Trim & "'"
                G.Tsql &= "," & Pone_Apos(EmpresaRFC.Text.Trim.ToUpper)
                G.Tsql &= "," & Val(Año.Text) & ")"
                G.com.CommandText = G.Tsql
                G.com.ExecuteNonQuery()
                ActualizarLogo(Val(EmpresaNumero.Text.Trim), FileUpload1.FileBytes)
            Catch ex As Exception
                Mensaje(ex.Message.ToString)
            Finally
                G.cn.Close()
            End Try
            LLenaGrid()
            GridView1.PageIndex = PaginadeFila(dt, Val(EmpresaNumero.Text.Trim))
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
        End If
        If (e.CommandName.Equals("Insertar")) Then
            If Session("UsuarioNombre") = "Interaccion" Then
                Dim EmpresaNumero As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaNumero"), TextBox) : EmpresaNumero.Enabled = True : EmpresaNumero.Focus()
                Dim EmpresaNombre As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaNombre"), TextBox) : EmpresaNombre.Enabled = True
                Dim EmpresaRFC As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaRFC"), TextBox) : EmpresaRFC.Enabled = True
                Dim Año As TextBox = CType(GridView1.FooterRow.FindControl("T_Año"), TextBox) : Año.Enabled = True
                'Botones Actualiza
                Dim Insertar As LinkButton = CType(GridView1.FooterRow.FindControl("lkb_Insertar"), LinkButton) : Insertar.Visible = False
                Dim Actualiza As LinkButton = CType(GridView1.FooterRow.FindControl("lkb_Actualizar"), LinkButton) : Actualiza.Visible = True
                Dim Cancelar As LinkButton = CType(GridView1.FooterRow.FindControl("lkb_Cancelar"), LinkButton) : Cancelar.Visible = True
                FileUpload1.Enabled = True
            End If
        End If
        If (e.CommandName.Equals("Cancelar")) Then
            Dim EmpresaNumero As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaNumero"), TextBox) : EmpresaNumero.Text = "" : EmpresaNumero.Enabled = False
            Dim EmpresaNombre As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaNombre"), TextBox) : EmpresaNombre.Text = "" : EmpresaNombre.Enabled = False
            Dim EmpresaRFC As TextBox = CType(GridView1.FooterRow.FindControl("T_EmpresaRFC"), TextBox) : EmpresaRFC.Text = "" : EmpresaRFC.Enabled = False
            Dim Año As TextBox = CType(GridView1.FooterRow.FindControl("T_Año"), TextBox) : Año.Text = "" : Año.Enabled = False
            'Botones Actualiza
            Dim Insertar As LinkButton = CType(GridView1.FooterRow.FindControl("lkb_Insertar"), LinkButton) : Insertar.Visible = True
            Dim Actualiza As LinkButton = CType(GridView1.FooterRow.FindControl("lkb_Actualizar"), LinkButton) : Actualiza.Visible = False
            Dim Cancelar As LinkButton = CType(GridView1.FooterRow.FindControl("lkb_Cancelar"), LinkButton) : Cancelar.Visible = False
            FileUpload1.Enabled = False
        End If
    End Sub
    Private Function PaginadeFila(ByVal dt As DataTable, ByVal EmpresaNumero As Integer) As Integer
        PaginadeFila = 0
        For Each f As DataRow In Session("dt").Rows
            If EmpresaNumero = f.Item("EmpresaNumero") Then
                Dim Indice As Integer = Session("dt").Rows.IndexOf(f)
                If Indice <= 9 Then
                    PaginadeFila = 0
                Else
                    PaginadeFila = Int((Indice + 1) / 10)
                End If
            End If
        Next
    End Function
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim G As Glo = CType(Session("G"), Glo)
        Dim EmpresaNumero As Label = CType(GridView1.Rows(e.RowIndex).FindControl("L_EmpresaNumero"), Label)
        Dim EmpresaNombre As TextBox = CType(GridView1.Rows(e.RowIndex).FindControl("T_EmpresaNombre"), TextBox)
        Dim EmpresaRFC As TextBox = CType(GridView1.Rows(e.RowIndex).FindControl("T_EmpresaRFC"), TextBox)
        Dim Año As TextBox = CType(GridView1.Rows(e.RowIndex).FindControl("T_Año"), TextBox)

        G.Tsql = "Update Empresas set EmpresaNombre='" & EmpresaNombre.Text.Trim & "'"
        G.Tsql &= ",EmpresaRFC='" & EmpresaRFC.Text.Trim.ToUpper & "'"
        G.Tsql &= ",Año=" & Val(Año.Text)
        G.Tsql &= " Where EmpresaNumero=" & Val(EmpresaNumero.Text)
        G.cn.Open()
        Dim com As New SqlCommand(G.Tsql, G.cn)
        com.ExecuteNonQuery()
        G.cn.Close()
        ActualizarLogo(Val(EmpresaNumero.Text), FileUpload1.FileBytes)
        GridView1.EditIndex = -1
        LLenaGrid()
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim G As Glo = CType(Session("G"), Glo)
        Dim EmpresaNumero As Label = CType(GridView1.Rows(e.RowIndex).FindControl("L_EmpresaNumero"), Label)
        If Session("UsuarioNombre") = "Interaccion" Then
            G.Tsql = "Delete from Empresas "
            G.Tsql &= " Where EmpresaNumero=" & Val(EmpresaNumero.Text)
            G.cn.Open()
            Dim com As New SqlCommand(G.Tsql, G.cn)
            com.ExecuteNonQuery()
            G.cn.Close()
            GridView1.EditIndex = -1
            LLenaGrid()
        End If
    End Sub
    Public Sub ActualizarLogo(ByVal EmpresaNumero As Integer, ByVal Empresalogo As Byte())
        Dim sel As String
        sel = "UPDATE Empresas" & _
            " SET EmpresaLogo = @EmpresaLogo" & _
            " WHERE EmpresaNumero = @EmpresaNumero"
        Using con As New SqlConnection(Conexion)
            Dim cmd As New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("@EmpresaNumero", EmpresaNumero)
            cmd.Parameters.AddWithValue("@EmpresaLogo", Empresalogo)
            con.Open()
            Dim t As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Console.WriteLine("Filas actualizadas: {0}", t)
        End Using
    End Sub
    Protected Sub Ima_Regresa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Ima_Regresa.Click
        Inserta_Seguimiento(CType(Session("G"), Glo), "S", Punto_Desc)
        Response.Redirect("~/Bienvenido.aspx")
    End Sub
End Class
