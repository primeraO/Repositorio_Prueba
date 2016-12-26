Imports System.Net
Imports System.IO

' ****************************** Module Header ******************************
' Module Name:  RemoteDownload.vb
' Project:      VBASPNETRemoteUploadAndDownload
' Copyright (c) Microsoft Corporation.
' 
'   The VBASPNETRemoteUploadAndDownload sample shows how to upload and download 
' files resource from remote server in an ASP.NET. 
'
' This project is created by using WebClient and FtpWebRequest object in VB language. 
'
' WebClient and FtpWebRequest Class both provides common methods for sending data 
' to URI of server. And receiving data from a resource identified by URI as well.

' When uploading or downloading files, These classes will do webrequest to the url 
' which user types in.

' UploadData() method sends a data buffer(without encoding it) to a resource 
' using the HTTP or FTP method specified in the method parameter, and then returns 
' web response from the server. Relatively, DownloadData() method request a HTTP
' or FTP download method to remote server and get outputstream from server.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
' All other rights reserved.
'
' ***************************************************************************

Public MustInherit Class RemoteDownload

    Public Property UrlString() As String
        Get
            Return m_UrlString
        End Get
        Set(ByVal value As String)
            m_UrlString = value
        End Set
    End Property
    Private m_UrlString As String


    Public Property DestDir() As String
        Get
            Return m_DestDir
        End Get
        Set(ByVal value As String)
            m_DestDir = value
        End Set
    End Property
    Private m_DestDir As String

    Public Sub New(ByVal urlString As String, ByVal destDir As String)
        Me.UrlString = urlString
        Me.DestDir = destDir
    End Sub

    '''<summary>
    '''download file from remote server
    '''</summary>
    Public Overridable Function DownloadFile() As Boolean
        Return True
    End Function
End Class

''' <summary>
''' HttpRemoteDownload class
''' </summary>

Public Class HttpRemoteDownload
    Inherits RemoteDownload
    Public Sub New(ByVal urlString As String, ByVal descFilePath As String)

        MyBase.New(urlString, descFilePath)
    End Sub

    Public Overrides Function DownloadFile() As Boolean
        Dim fileName As String = System.IO.Path.GetFileName(Me.UrlString)
        Dim descFilePath As String = System.IO.Path.Combine(Me.DestDir, fileName)
        Try
            Dim myre As WebRequest = WebRequest.Create(Me.UrlString)
        Catch ex As Exception
            Throw New Exception("File doesn't exist on server", ex.InnerException)
        End Try
        Try
            Dim fileData As Byte()
            Using client As New WebClient()
                fileData = client.DownloadData(Me.UrlString)
            End Using
            Using fs As New FileStream(descFilePath, FileMode.OpenOrCreate)
                fs.Write(fileData, 0, fileData.Length)
            End Using
            Return True
        Catch ex As Exception
            Throw New Exception("Failed to download", ex.InnerException)
        End Try
    End Function
End Class

''' <summary>
''' FtpDownload class
''' </summary>
Public Class FtpRemoteDownload
    Inherits RemoteDownload
    Public Sub New(ByVal urlString As String, ByVal descFilePath As String)

        MyBase.New(urlString, descFilePath)
    End Sub

    Public Overrides Function DownloadFile() As Boolean
        Dim reqFTP As FtpWebRequest

        Dim fileName As String = System.IO.Path.GetFileName(Me.UrlString)
        Dim descFilePath As String = System.IO.Path.Combine(Me.DestDir, fileName)

        Try

            reqFTP = DirectCast(FtpWebRequest.Create(Me.UrlString), FtpWebRequest)
            reqFTP.Method = WebRequestMethods.Ftp.DownloadFile
            reqFTP.UseBinary = True

            Using outputStream As New FileStream(descFilePath, FileMode.OpenOrCreate)
                Using response As FtpWebResponse = DirectCast(reqFTP.GetResponse(), FtpWebResponse)
                    Using ftpStream As Stream = response.GetResponseStream()
                        Dim bufferSize As Integer = 2048
                        Dim readCount As Integer
                        Dim buffer As Byte() = New Byte(bufferSize - 1) {}
                        readCount = ftpStream.Read(buffer, 0, bufferSize)
                        While readCount > 0
                            outputStream.Write(buffer, 0, readCount)
                            readCount = ftpStream.Read(buffer, 0, bufferSize)
                        End While
                    End Using

                End Using
            End Using
            Return True

        Catch ex As Exception
            Throw New Exception("Failed to download", ex.InnerException)
        End Try
    End Function
End Class
