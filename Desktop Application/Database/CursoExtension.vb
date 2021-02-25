Partial Public Class Curso
    Public ReadOnly Property Nombre() As String
        Get
            Return String.Format("{1} - {2} - {3}", Me.Anio.Nivel.Nombre, Me.Anio.Nombre, Me.Turno.Nombre, Me.Division)
        End Get
    End Property
End Class