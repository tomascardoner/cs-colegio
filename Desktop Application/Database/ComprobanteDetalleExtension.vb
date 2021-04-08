Partial Public Class ComprobanteDetalle

    Public Property DescripcionDisplay() As String
        Get
            Return Descripcion.Replace(Environment.NewLine, Constantes.NewLineCharDisplayReplacement)
        End Get
        Set(ByVal value As String)
            Descripcion = value.Replace(Constantes.NewLineCharDisplayReplacement, Environment.NewLine)
        End Set
    End Property

End Class
