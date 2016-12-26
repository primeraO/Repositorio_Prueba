Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports System.Text
Imports System
Imports System.Collections

Public Class C_XML
    Public xml_subTotal As Double = 0
    Public Xml_total As Double = 0
    Public Xml_folio As Integer = 0
    Public Xml_folio_Alfanumerico As String = ""
    Public Xml_serie As String = ""
    Public Xml_Emisor_RFC As String = ""
    Public Xml_Receptor_RFC As String = ""
    Public Xml_Receptor_colonia As String = ""
    Public Xml_FechaTimbrado As String = ""
    Public Xml_UUID As String = ""
    Public Xml_tasa As Double = 0
    Public Xml_NuevaRuta As String = ""
    Public Xml_importe_iva As Double = 0
    Public Xml_Tx_Impuesto As String = ""
    Public Xml_Emisor_Nombre As String = ""
    Public Xml_Receptor_Nombre As String = ""
    Public Xml_Fecha_Comprobante As String = ""
    Public Xml_Cuenta_Pago_Comprobante As String = ""
    Public Function LeerXML(ByVal RutaArchivo As String) As Boolean
        LeerXML = False
        Try
            'Cargamos el archivo
            If File.Exists(RutaArchivo) Then
                Dim Reader As New XmlTextReader(RutaArchivo)
                Do While Reader.Read
                    Select Case Reader.NodeType
                        Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                            Console.Write("<" + Reader.Name)
                            Select Case Reader.Name
                                Case "cfdi:Comprobante"
                                    If Reader.HasAttributes Then 'If attributes exist
                                        While Reader.MoveToNextAttribute()
                                            'Mostrar valor y nombre del atributo
                                            Select Case Reader.Name
                                                Case "subTotal"
                                                    xml_subTotal = Reader.Value
                                                Case "total"
                                                    Xml_total = Reader.Value
                                                Case "folio"
                                                    Xml_folio = Val(Reader.Value)
                                                    Xml_folio_Alfanumerico = Reader.Value
                                                Case "serie"
                                                    Xml_serie = Reader.Value
                                                Case "fecha"
                                                    Xml_Fecha_Comprobante = Reader.Value
                                                Case "NumCtaPago"
                                                    Xml_Cuenta_Pago_Comprobante = Reader.Value

                                            End Select
                                        End While
                                    End If
                                Case "cfdi:Emisor"
                                    If Reader.HasAttributes Then 'If attributes exist
                                        While Reader.MoveToNextAttribute()
                                            'Mostrar valor y nombre del atributo
                                            Select Case Reader.Name
                                                Case "rfc"
                                                    Xml_Emisor_RFC = Reader.Value
                                                Case "nombre"
                                                    Xml_Emisor_Nombre = Reader.Value
                                            End Select
                                        End While
                                    End If
                                Case "cfdi:Receptor"
                                    If Reader.HasAttributes Then 'If attributes exist
                                        While Reader.MoveToNextAttribute()
                                            'Mostrar valor y nombre del atributo
                                            Select Case Reader.Name
                                                Case "rfc"
                                                    Xml_Receptor_RFC = Reader.Value
                                                Case "colonia"
                                                    Xml_Receptor_colonia = Reader.Value
                                                Case "nombre"
                                                    Xml_Receptor_Nombre = Reader.Value

                                            End Select
                                        End While
                                    End If

                                Case "tfd:TimbreFiscalDigital"
                                    If Reader.HasAttributes Then 'If attributes exist
                                        While Reader.MoveToNextAttribute()
                                            'Mostrar valor y nombre del atributo
                                            Select Case Reader.Name
                                                Case "FechaTimbrado"
                                                    Xml_FechaTimbrado = Reader.Value
                                                    If Xml_UUID.Trim > "" Then Exit Do
                                                Case "UUID"
                                                    Xml_UUID = Reader.Value
                                                    If Xml_FechaTimbrado.Trim > "" Then Exit Do
                                            End Select
                                        End While
                                    End If
                                Case "cfdi:Traslado"
                                    If Reader.HasAttributes Then 'If attributes exist
                                        While Reader.MoveToNextAttribute()
                                            'Mostrar valor y nombre del atributo
                                            Select Case Reader.Name
                                                Case "impuesto"
                                                    Xml_Tx_Impuesto = Reader.Value
                                                Case "tasa"
                                                    If Xml_Tx_Impuesto = "IVA" Then
                                                        Xml_tasa = Reader.Value
                                                    End If
                                                Case "importe"
                                                    If Xml_Tx_Impuesto = "IVA" Then
                                                        Xml_importe_iva += Reader.Value
                                                    End If
                                            End Select
                                        End While
                                    End If
                            End Select
                        Case XmlNodeType.Text 'Mostrar el texto de cada elemento.
                            Console.WriteLine(Reader.Value)
                        Case XmlNodeType.EndElement 'Mostrar final del elemento.
                            Console.Write("</" + Reader.Name)
                            Console.WriteLine(">")
                    End Select
                Loop
                LeerXML = True
            Else
                MessageBox.Show("No existe el archivo", "Información")
            End If
        Catch ex As Exception
            LeerXML = False
        End Try
    End Function
    Public Function Convierte_XML_String(ByVal RutaArchivo As String) As String
        Dim XML_Plano As String = ""
        Dim objReader As New StreamReader(RutaArchivo)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()
        XML_Plano = ""
        For Each sLine In arrText
            XML_Plano &= sLine
        Next
        Return XML_Plano
    End Function
    Public Function convierteXMLaUTF8(ByVal RutaArchivo As String) As Boolean
        Dim xml As String = ""
        If File.Exists(RutaArchivo) Then
            xml = Convierte_XML_String(RutaArchivo)
        End If
        xml = Encoding.ASCII.GetString(Encoding.UTF8.GetBytes(xml))
        Dim XmlDoc As New XmlDocument
        XmlDoc.LoadXml(xml)
        Dim NombreArchivo As String = Path.GetFileNameWithoutExtension(RutaArchivo)
        Dim Directorio As String = Path.GetDirectoryName(RutaArchivo)
        Xml_NuevaRuta = Directorio & "\" & NombreArchivo & "UTP8.xml"
        XmlDoc.Save(Xml_NuevaRuta)
    End Function
End Class
