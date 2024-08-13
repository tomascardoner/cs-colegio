Module MiscFunctions

    Friend Function EntidadTipoANombre(ByVal EntidadTipo As String) As String
        Select Case EntidadTipo
            Case Constantes.ENTIDADTIPO_PERSONALCOLEGIO
                Return My.Resources.STRING_ENTIDADTIPO_PERSONALCOLEGIO
            Case Constantes.ENTIDADTIPO_DOCENTE
                Return My.Resources.STRING_ENTIDADTIPO_DOCENTE
            Case Constantes.ENTIDADTIPO_ALUMNO
                Return My.Resources.STRING_ENTIDADTIPO_ALUMNO
            Case Constantes.ENTIDADTIPO_FAMILIAR
                Return My.Resources.STRING_ENTIDADTIPO_FAMILIAR
            Case Constantes.ENTIDADTIPO_PROVEEDOR
                Return My.Resources.STRING_ENTIDADTIPO_PROVEEDOR
            Case Constantes.ENTIDADTIPO_OTRO
                Return My.Resources.STRING_ENTIDADTIPO_OTRO
            Case Else
                Return String.Empty
        End Select
    End Function

    Friend Function ObtenerPeriodoTranscurrido(desde As Date, hasta As Date?) As String
        If hasta Is Nothing Then
            hasta = DateAndTime.Now.Date
        End If
        Return ObtenerPeriodoTranscurrido(Convert.ToInt32(DateDiff(DateInterval.Day, desde, hasta.Value) + 1))
    End Function

    Friend Function ObtenerPeriodoTranscurrido(dias As Integer) As String
        Dim diasPorAnio As Decimal
        Dim anios As Integer
        Dim meses As Integer
        Dim resultado As String = String.Empty

        If dias > 1460 Then
            diasPorAnio = 365.25D
        Else
            diasPorAnio = 365
        End If

        ' Calculo los años completos y días restantes
        anios = Convert.ToInt32(Decimal.Truncate(dias / diasPorAnio))
        dias = Convert.ToInt32(dias Mod diasPorAnio)

        ' Calculo los meses completos y días restantes
        meses = Convert.ToInt32(dias \ 30)
        dias = Convert.ToInt32(dias Mod 30)

        If anios > 0 Then
            resultado = $"{anios} año" & If(anios > 1, "s", String.Empty)
        End If
        If meses > 0 Then
            If resultado.Length > 0 Then
                resultado &= If(dias = 0, " y ", ", ")
            End If
            resultado &= $"{meses} mes" & If(meses > 1, "es", String.Empty)
        End If
        If dias > 0 Then
            If resultado.Length > 0 Then
                resultado &= " y "
            End If
            resultado &= $"{dias} día" & If(dias > 1, "s", String.Empty)
        End If
        If resultado.Length > 0 Then
            resultado &= "."
        End If
        Return resultado
    End Function

    Friend Function ObtenerAniosCompletosTranscurridos(dias As Integer) As Integer
        Dim diasPorAnio As Decimal

        If dias > 1460 Then
            diasPorAnio = 365.25D
        Else
            diasPorAnio = 365
        End If

        Return Convert.ToInt32(Decimal.Truncate(dias / diasPorAnio))
    End Function
End Module
