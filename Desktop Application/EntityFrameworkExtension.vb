Imports System.Data.Entity
Imports System.Data.EntityClient

Partial Public Class CSColegioContext
    Inherits DbContext

    Public Shared Property ConnectionString As String

    Public Sub New(ByVal UseCustomConnectionString As Boolean)
        MyBase.New(ConnectionString)
    End Sub

    Public Shared Sub CreateConnectionString(ByVal Provider As String, ByVal ProviderConnectionString As String)
        Dim ecb As EntityConnectionStringBuilder = New EntityConnectionStringBuilder()

        ecb.Metadata = String.Format("res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", "CSColegio")
        ecb.Provider = Provider
        ecb.ProviderConnectionString = ProviderConnectionString

        ConnectionString = ecb.ConnectionString
    End Sub
End Class

Partial Public Class Entidad
    Public ReadOnly Property DomicilioCalleCompleto() As String
        Get
            Dim DomicilioCompleto As String

            DomicilioCompleto = DomicilioCalle1
            If Not DomicilioCalle1 Is Nothing Then
                If Not DomicilioNumero Is Nothing Then
                    If DomicilioNumero.TrimStart.ToUpper.StartsWith("RUTA ") Then
                        DomicilioCompleto &= " Km. " & DomicilioNumero
                    ElseIf DomicilioNumero.TrimStart.ToUpper.StartsWith("CALLE ") Then
                        DomicilioCompleto &= " N° " & DomicilioNumero
                    Else
                        DomicilioCompleto &= " " & DomicilioNumero
                    End If
                End If

                If Not DomicilioPiso Is Nothing Then
                    If IsNumeric(DomicilioPiso) Then
                        DomicilioCompleto &= " P." & DomicilioPiso & "°"
                    Else
                        DomicilioCompleto &= " " & DomicilioPiso
                    End If
                End If

                If Not DomicilioDepartamento Is Nothing Then
                    DomicilioCompleto &= " Dto. """ & DomicilioDepartamento & """"
                End If

                If Not DomicilioCalle2 Is Nothing Then
                    If Not DomicilioCalle3 Is Nothing Then
                        DomicilioCompleto &= " entre " & DomicilioCalle2 & " y " & DomicilioCalle3
                    Else
                        DomicilioCompleto &= " esq. " & DomicilioCalle2
                    End If
                End If
            End If

            Return DomicilioCompleto
        End Get
    End Property
End Class