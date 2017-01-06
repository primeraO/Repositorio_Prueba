<%@ WebHandler Language="VB" Class="Handler" %>

Imports System
Imports System.Web

Public Class Handler : Implements IHttpHandler
   
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
              
        'Dim Path As String = "C:\Fichas_Tecnicas\"
        Try
            Dim img As String = context.Request.QueryString("img")
            context.Response.ContentType = "image/jpg"
            context.Response.TransmitFile(img)
        Catch ex As Exception
            
        End Try
       
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class