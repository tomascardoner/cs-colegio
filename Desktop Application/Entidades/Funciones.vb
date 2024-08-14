Namespace Entidades

    Module Funciones

        Friend Function ObtenerAntiguedadAnios(dbContext As CSColegioContext, idEntidad As Integer, fecha As Date) As Integer?
            Try
                Dim dias As Integer
                For Each detalle In dbContext.EntidadPersonalColegioAntiguedadDetalle.Where(Function(epcad) epcad.IdEntidad = idEntidad)
                    dias += Convert.ToInt32(DateDiff(DateInterval.Day, detalle.FechaDesde, If(detalle.FechaHasta, fecha)) + 1)
                Next
                Return ObtenerAniosCompletosTranscurridos(dias)
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al calcular los años de antigüedad.")
                Return Nothing
            End Try
        End Function

        Friend Function ObtenerAntiguedadPorcentaje(dbContext As CSColegioContext, idEntidad As Integer, fecha As Date) As Decimal?
            Dim anios As Integer? = ObtenerAntiguedadAnios(dbContext, idEntidad, fecha)

            If anios Is Nothing Then
                Return Nothing
            End If

            Try
                Return dbContext.SueldoAntiguedad.AsNoTracking().Where(Function(sa) sa.AntiguedadDesde <= anios.Value).OrderByDescending(Function(sa) sa.AntiguedadDesde).Select(Function(sa) sa.Porcentaje).FirstOrDefault()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al calcular el porcentaje de antigüedad.")
                Return Nothing
            End Try
        End Function

    End Module

End Namespace
