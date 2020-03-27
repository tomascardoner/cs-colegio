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
                Return ""
        End Select
    End Function

End Module
