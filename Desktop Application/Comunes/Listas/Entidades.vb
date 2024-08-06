﻿Namespace Comunes.Listas
    Module Entidades
        Friend Sub PersonalColegio(comboBox As ComboBox, dbContext As CSColegioContext)
            Dim items As List(Of Entidad)

            Try
                items = dbContext.Entidad.AsNoTracking().Where(Function(e) e.TipoPersonalColegio).OrderBy(Function(e) e.ApellidoNombre).ToList()
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
