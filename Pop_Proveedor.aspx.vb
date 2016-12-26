Imports System.Drawing
Partial Class Pop_Proveedor
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
        If Session("SesionActiva") Is Nothing Then
            Response.Redirect("Default.aspx")
        End If
        If IsPostBack = False Then
            Dim G As Glo = CType(Session("G"), Glo)
            Try
                G.cn.Open()
                G.Tsql = "Select a.Lote,a.Fecha_Lote,a.Flete as Importe_Flete,a.Fletero,b.Razon_Social as Fletero_Desc,a.Iva_Flete,a.Descuento,a.ref_flete "
                G.Tsql &= " From Movimientos_Entradas a left join Proveedor b on a.Fletero=b.Numero"
                G.Tsql &= " where a.Compania=" & Session("Cia")
                G.Tsql &= " and a.Obra=" & Pone_Apos(G.Sucursal)
                G.Tsql &= " and a.Almacen=" & Val(G.Almacen)
                G.Tsql &= " and a.E_S='E' and a.Partida=0 "
                G.Tsql &= " and a.Lote=" & Val(Request.QueryString("Lote"))
                G.Tsql &= " Order by a.Lote"
                G.com.CommandText = G.Tsql
                G.dr = G.com.ExecuteReader
                If G.dr.Read Then
                    T_Fletero.Text = G.dr("Fletero")
                    T_Fletero_Desc.Text = G.dr("Fletero_Desc")
                    T_Importe.Text = For_Pan_Lib(G.dr("Importe_Flete"), 2)
                    T_Iva.Text = For_Pan_Lib(G.dr("Iva_Flete"), 2)
                    T_Descuento.Text = For_Pan_Lib(G.dr("Descuento"), 2)
                    T_Referencia.Text = G.dr("ref_flete")
                End If
            Catch ex As Exception
                Msg_Error(ex.ToString)
            Finally
                G.cn.Close()
            End Try
            Lbl_Compañia.Text = "Compañia: " & G.Empresa_Numero & " - " & G.RazonSocial
            Lbl_Obra.Text = "Proyecto: " & G.Sucursal & " - " & G.Sucursal_Desc
            Lbl_Usuario.Text = "Usuario: " & G.UsuarioReal
            Image1.ImageUrl = "~/Trabajo/" & Session("Imagen")
            Image1.Style("Height") = Int(Session("Logo_Height")) & "px"
            Image1.Style("Width") = Int(Session("Logo_Width")) & "px"
        End If
        H_Fletero.Attributes.Add("onclick", "window.open('Bus_Cat_Proveedor.aspx?Catalogo=PROVEEDOR',null,'left=400, top=100, height=450, width= 800, status=no, resizable=no, scrollbars=no, toolbar=no,location= no, menubar=no');")
        H_Fletero.Attributes.Add("style", "cursor:pointer;")
        T_Fletero.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Fletero.ClientID & "');")

        T_Importe.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Importe.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Importe.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Importe.ClientID & "');")
        T_Importe.Attributes.Add("onFocus", "javascript: QuitaComas('" & T_Importe.ClientID & "');")

        T_Iva.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Iva.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Iva.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Iva.ClientID & "');")
        T_Iva.Attributes.Add("onFocus", "javascript: QuitaComas('" & T_Iva.ClientID & "');")

        T_Descuento.Attributes.Add("onblur", "javascript: FormatNumber('" & T_Descuento.ClientID & "'," & 2 & ",'" & True & "','" & True & "');")
        T_Descuento.Attributes.Add("onkeypress", "javascript: ValidaSoloNumeros('" & T_Descuento.ClientID & "');")
        T_Descuento.Attributes.Add("onFocus", "javascript: QuitaComas('" & T_Descuento.ClientID & "');")

        Msg_Err.Visible = False
    End Sub
    Protected Sub Msg_Error(ByVal Txw_Msg As String)
        Msg_Err.Text = "..... " & Txw_Msg & " ....."
        Msg_Err.Visible = True
    End Sub

    Protected Sub Ima_Salir_Click(sender As Object, e As System.EventArgs) Handles Ima_Salir.Click
        Response.Redirect("~/C_Entradas.aspx")
    End Sub

    Protected Sub Ima_Guardar_Click(sender As Object, e As System.EventArgs) Handles Ima_Guardar.Click
        Dim G As Glo = CType(Session("G"), Glo)
        Try
            G.cn.Open()
            G.Tsql = "Update Movimientos_Entradas set Flete=" & Val(Elimina_Comas(T_Importe.Text))
            G.Tsql &= ",Fletero=" & Val(T_Fletero.Text)
            G.Tsql &= ",Iva_Flete=" & Val(Elimina_Comas(T_Iva.Text))
            G.Tsql &= ",Descuento=" & Val(Elimina_Comas(T_Descuento.Text))
            G.Tsql &= ",ref_flete=" & Pone_Apos(T_Referencia.Text.Trim)
            G.Tsql &= " where Compania=" & Session("Cia")
            G.Tsql &= " and Obra=" & Pone_Apos(G.Sucursal)
            G.Tsql &= " and Almacen=" & Val(G.Almacen)
            G.Tsql &= " and E_S='E' "
            G.Tsql &= " and Lote=" & Val(Request.QueryString("Lote"))
            G.com.CommandText = G.Tsql
            G.com.ExecuteNonQuery()
            Msg_Err.BackColor = Drawing.Color.Aqua
            Msg_Error("Sus cambios han sido guardados")
        Catch ex As Exception
            Msg_Err.BackColor = Color.Yellow
            Msg_Error(ex.ToString)
        Finally
            G.cn.Close()
        End Try
    End Sub
End Class
