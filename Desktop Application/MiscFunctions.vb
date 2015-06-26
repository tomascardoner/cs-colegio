Module MiscFunctions
    Friend Function ObtenerDomicilioCalleCompleto(ByVal Calle1 As String, ByVal Numero As String, ByVal Piso As String, ByVal Departamento As String, ByVal Calle2 As String, ByVal Calle3 As String) As String
        Dim DomicilioCompleto As String

        DomicilioCompleto = Calle1
        If Not Calle1 Is Nothing Then
            If Not Numero Is Nothing Then
                If Numero.TrimStart.ToUpper.StartsWith("RUTA ") Then
                    DomicilioCompleto &= " Km. " & Numero
                ElseIf Numero.TrimStart.ToUpper.StartsWith("CALLE ") Then
                    DomicilioCompleto &= " N° " & Numero
                Else
                    DomicilioCompleto &= " " & Numero
                End If
            End If

            If Not Piso Is Nothing Then
                If IsNumeric(Piso) Then
                    DomicilioCompleto &= " P." & Piso & "°"
                Else
                    DomicilioCompleto &= " " & Piso
                End If
            End If

            If Not Departamento Is Nothing Then
                DomicilioCompleto &= " Dto. """ & Departamento & """"
            End If

            If Not Calle2 Is Nothing Then
                If Not Calle3 Is Nothing Then
                    DomicilioCompleto &= " entre " & Calle2 & " y " & Calle3
                Else
                    DomicilioCompleto &= " esq. " & Calle2
                End If
            End If
        End If

        Return DomicilioCompleto
    End Function

End Module
