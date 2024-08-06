Namespace Comunes.Listas
    Module Entidades
        Friend Sub ConSueldos(comboBox As ComboBox, dbContext As CSColegioContext)
            Dim items As List(Of Entidad)

            Try
                items = dbContext.Entidad.AsNoTracking().Where(Function(e) e.EsActivo AndAlso e.TipoPersonalColegio OrElse e.TipoDocente).OrderBy(Function(e) e.ApellidoNombre).ToList()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer las entidades")
                Return
            End Try

            comboBox.ValueMember = "IDEntidad"
            comboBox.DisplayMember = "ApellidoNombre"
            comboBox.DataSource = items
        End Sub
    End Module
End Namespace
