Imports System.Data.Entity
Imports System.Data.EntityClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

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

Partial Public Class Reporte
    Friend Property ReportObject As ReportDocument

    Private mRecordSelectionFormula As String

    Friend Property RecordSelectionFormula() As String
        Get
            Return mRecordSelectionFormula
        End Get
        Set(ByVal value As String)
            mRecordSelectionFormula = value
            ReportObject.RecordSelectionFormula = value
        End Set
    End Property

    Friend Function Open(ByVal PathAndFileName As String) As Boolean
        If Not My.Computer.FileSystem.FileExists(PathAndFileName) Then
            Return False
        End If

        Try
            ReportObject = New ReportDocument

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al crear el objeto del reporte." & vbCrLf & "Probablemente, esto se deba a que no estan correctamente instaladas las librerías de Crystal Reports.")
            Return False
        End Try

        Try
            ReportObject.Load(PathAndFileName)

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al cargar el reporte.")
            Return False
        End Try

        For Each ParametroActual As ReporteParametro In Me.ReporteParametro
            For Each ParameterFieldActual As ParameterField In ReportObject.ParameterFields
                With ParameterFieldActual
                    If CStr(IIf(.ParameterType = ParameterType.StoreProcedureParameter, "@", "")) & ParametroActual.IDParametro.TrimEnd = .ParameterFieldName Then
                        Select Case ParametroActual.Tipo
                            'Case REPORTE_PARAMETRO_TIPO_COMPANY
                            '    .AddCurrentValue pParametro.CompanyName
                            'Case REPORTE_PARAMETRO_TIPO_TITLE
                            '    .AddCurrentValue Titulo
                            'Case REPORTE_PARAMETRO_TIPO_CONDITION_TEXT
                            '    .AddCurrentValue GetConditionText()
                            Case Else
                                Select Case .ParameterValueType
                                    Case ParameterValueKind.CurrencyParameter, ParameterValueKind.NumberParameter
                                        If ParametroActual.Valor Is Nothing Then
                                            .CurrentValues.AddValue(Nothing)
                                        Else
                                            .CurrentValues.AddValue(CDbl(ParametroActual.Valor))
                                        End If
                                    Case ParameterValueKind.DateTimeParameter, ParameterValueKind.DateParameter, ParameterValueKind.TimeParameter
                                        If ParametroActual.Valor Is Nothing Then
                                            .CurrentValues.AddValue(New Date(9999, 1, 1))
                                        Else
                                            Select Case ParametroActual.Tipo
                                                Case Constantes.REPORTE_PARAMETRO_TIPO_DATETIME
                                                    .CurrentValues.AddValue(CDate(ParametroActual.Valor))
                                                Case Constantes.REPORTE_PARAMETRO_TIPO_DATE
                                                    .CurrentValues.AddValue(CDate(ParametroActual.Valor))
                                                Case Constantes.REPORTE_PARAMETRO_TIPO_TIME
                                                    .CurrentValues.AddValue(CDate("1900/01/01 " & CStr(ParametroActual.Valor)))
                                                Case Constantes.REPORTE_PARAMETRO_TIPO_YEAR_MONTH_FROM, Constantes.REPORTE_PARAMETRO_TIPO_YEAR_MONTH_TO
                                                    .CurrentValues.AddValue(CDate(ParametroActual.Valor))
                                            End Select
                                        End If
                                    Case ParameterValueKind.StringParameter
                                        .CurrentValues.AddValue(CStr(ParametroActual.Valor))
                                    Case ParameterValueKind.BooleanParameter
                                        .CurrentValues.AddValue(CBool(ParametroActual.Valor))
                                End Select
                        End Select
                        Exit For
                    End If
                End With
            Next
        Next

        'ReportObject.EnableParameterPrompting = False
        Return True

    End Function

    Friend Function SetDatabaseConnection(ByVal ServerName As String, ByVal DatabaseName As String, ByVal UserID As String, ByVal Password As String) As Boolean
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        With crConnectionInfo
            .ServerName = ServerName
            .DatabaseName = DatabaseName
            .UserID = UserID
            .Password = Password
        End With

        Try
            CrTables = ReportObject.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al establecer la conexión a la base de datos del Reporte.")
            Return False
        End Try
    End Function
End Class

Partial Public Class ReporteParametro
    Public Property Valor As Object
    Public Property ValorParaMostrar As String
End Class