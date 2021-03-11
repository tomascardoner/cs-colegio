Partial Public Class Comprobante
    Public ReadOnly Property CodigoBarras() As String
        Get
            Dim value As String

            ' Código de PAGOSEduc
            value = "09370007"
            ' Importe 1er. vencimiento
            value &= ImporteTotal1.ToString("000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")
            ' Fecha 1er. vencimiento (YYJJJ) dónde JJJ son los días transcurridos desde el 1 de enero
            Dim span As TimeSpan
            span = FechaVencimiento1.Value.Subtract(New Date(FechaVencimiento1.Value.Year(), 1, 1))
            value &= FechaVencimiento1.Value.Year() & span.Days.ToString().PadLeft(3, "0"c)

            Return ""
        End Get
    End Property
End Class