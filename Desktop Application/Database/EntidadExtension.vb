Partial Public Class Entidad
    Public ReadOnly Property DomicilioCalleCompleto() As String
        Get
            Dim DomicilioCompleto As String

            DomicilioCompleto = DomicilioCalle1
            If Not DomicilioCalle1 Is Nothing Then
                If Not DomicilioNumero Is Nothing Then
                    If DomicilioCalle1.TrimStart.ToUpper.StartsWith("RUTA ") Then
                        DomicilioCompleto &= " Km. " & DomicilioNumero
                    ElseIf DomicilioCalle1.TrimStart.ToUpper.StartsWith("CALLE ") Then
                        DomicilioCompleto &= " N° " & DomicilioNumero
                    ElseIf IsNumeric(DomicilioCalle1.Trim) Then
                        DomicilioCompleto = "Calle " & DomicilioCalle1.Trim & " N° " & DomicilioNumero
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

    Public Function VerificarEmail(ByVal MostrarMensaje As Boolean) As Boolean
        If CS_Parameter_System.GetBoolean(Parametros.ENTIDAD_VERIFICAR_EMAIL_AVISO) AndAlso MostrarMensaje Then
            If VerificarEmail1 And VerificarEmail2 Then
                MsgBox("Se deben verificar las dos direcciones de e-Mail de esta Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            ElseIf VerificarEmail1 Then
                MsgBox("Se debe verificar la dirección de e-Mail 1 de esta Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            ElseIf VerificarEmail2 Then
                MsgBox("Se debe verificar la dirección de e-Mail 2 de esta Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If
        End If

        Return VerificarEmail1 Or VerificarEmail2
    End Function
End Class
