Imports System.IO
Imports CrystalDecisions.Shared
Partial Class Reporte_Descarga
    Inherits System.Web.UI.Page

    Protected Sub Btn_PDF_Click(sender As Object, e As System.EventArgs) Handles Btn_PDF.Click
        Dim filename As String = Request.QueryString("filename").ToString() & ".pdf"
        Response.Clear()
        Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", filename))
        Response.ContentType = "application/octet-stream"
        Response.WriteFile(Server.MapPath(Path.Combine("~/Trabajo" & "/" & filename)))
        Response.[End]()
        Dim Archivo As String = Server.MapPath(Path.Combine("~/Trabajo" & "/" & filename))
        If (System.IO.File.Exists(Archivo)) Then
            System.IO.File.Delete(Archivo)
        End If
    End Sub

    Protected Sub Btn_Regresar_Click(sender As Object, e As System.EventArgs) Handles Btn_Regresar.Click
        Dim filename As String = Request.QueryString("filename").ToString() & ".pdf"
        Dim Archivo As String = Server.MapPath(Path.Combine("~/Trabajo" & "/" & filename))
        If (System.IO.File.Exists(Archivo)) Then
            System.IO.File.Delete(Archivo)
        End If
        If Request.QueryString("Back") = "Mult" Then
            Response.Redirect("~/Salidas_Multiples.aspx?")
        ElseIf Request.QueryString("Back") = "Alm" Then
            Response.Redirect("~/Salidas_Almacen.aspx?")
        ElseIf Request.QueryString("Back") = "Reimp" Then
            Response.Redirect("~/Salidas_Multiples_Consulta.aspx")
        ElseIf Request.QueryString("Back") = "Clasificacion" Then
            Response.Redirect("~/Salidas_Clasificacion.aspx")
        Else
            Response.Redirect("~/Menu.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))
            If Session("SesionActiva") Is Nothing Then
                Response.Redirect("Default.aspx")
            End If
            If IsPostBack = False Then
                Dim filename As String = Request.QueryString("filename").ToString() & ".pdf"
                L_Archivo.Text = filename
                'Response.Clear()
                'Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", filename))
                'Response.ContentType = "application/octet-stream"
                'Response.WriteFile(Server.MapPath(Path.Combine("~/Trabajo" & "/" & filename)))
                'Response.[End]()
                'Dim Archivo As String = Server.MapPath(Path.Combine("~/Trabajo" & "/" & filename))
                'If (System.IO.File.Exists(Archivo)) Then
                '    System.IO.File.Delete(Archivo)
                'End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
