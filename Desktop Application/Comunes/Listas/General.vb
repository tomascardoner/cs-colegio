Namespace Comunes.Listas
    Module General
        Friend Sub PeriodosAnios(comboBox As ComboBox, anioInicio As Short, anioFin As Short, mostrarTodos As Boolean, mostrarNoEspecificado As Boolean, orderAscending As Boolean, Optional selectIndex As Integer = -1)
            Dim items As List(Of String)

            items = Enumerable.Range(anioInicio, anioFin - anioInicio + 1).Select(Function(a) a.ToString()).ToList()
            If Not orderAscending Then
                items.Reverse()
            End If
            If mostrarNoEspecificado Then
                items.Insert(0, My.Resources.STRING_ITEM_NOT_SPECIFIED)
            End If
            If mostrarTodos Then
                items.Insert(0, My.Resources.STRING_ITEM_ALL_MALE)
            End If
            comboBox.DataSource = items
            comboBox.SelectedIndex = selectIndex
        End Sub
    End Module
End Namespace