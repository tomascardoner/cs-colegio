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

        Friend Sub Grupos(comboBox As ComboBox, dbContext As CSColegioContext, mostrarTodos As Boolean, mostrarNoEspecificado As Boolean)
            Dim items As List(Of EntidadGrupo)

            Try
                items = dbContext.EntidadGrupo.AsNoTracking().Where(Function(e) e.EsActivo).OrderBy(Function(e) e.Nombre).ToList()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los grupos de entidades")
                Return
            End Try

            If mostrarNoEspecificado Then
                items.Insert(0, New EntidadGrupo With {
                             .IdEntidadGrupo = CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE,
                             .Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
                })
            End If
            If mostrarTodos Then
                items.Insert(0, New EntidadGrupo With {
                             .IdEntidadGrupo = CardonerSistemas.Constants.FIELD_VALUE_ALL_BYTE,
                             .Nombre = My.Resources.STRING_ITEM_ALL_MALE
                })
            End If

            comboBox.ValueMember = "IDEntidadGrupo"
            comboBox.DisplayMember = "Nombre"
            comboBox.DataSource = items
        End Sub
    End Module
End Namespace
