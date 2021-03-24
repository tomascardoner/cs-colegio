Partial Public Class Comprobante

#Region "Codigo de barras SEPSA"

    Public Function CalcularCodigoBarrasSepsa() As Boolean
        Dim idCliente As Integer
        Dim value As String

        idCliente = CS_Parameter_System.GetIntegerAsInteger(Parametros.EMPRESA_PAGOSEDUC_NUMERO)
        If idCliente = 0 Then
            Return False
        End If

        ' Código de PAGOSEduc
        value = "09370007"
        ' Importe 1er. vencimiento
        value &= ImporteTotal1.ToString("000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")
        ' Fecha 1er. vencimiento (YYJJJ) dónde JJJ son los días transcurridos desde el 1 de enero
        Dim span As TimeSpan
        span = FechaVencimiento1.Value.Subtract(New Date(FechaVencimiento1.Value.Year(), 1, 1))
        value &= FechaVencimiento1.Value.ToString("yy") & span.Days.ToString().PadLeft(3, "0"c)
        ' Código de cliente
        value &= idCliente.ToString().PadLeft(5, "0"c)
        ' Cliente
        value &= DocumentoNumero.PadLeft(14, "0"c)
        ' Moneda
        value &= "0"
        ' 2do. vencimiento
        If ImporteTotal2.HasValue AndAlso ImporteTotal2.Value > 0 Then
            ' Importe 2do. vencimiento
            value &= ImporteTotal2.Value.ToString("00000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")
            ' Fecha 2do. vencimiento
            value &= DateDiff(DateInterval.Day, FechaVencimiento1.Value, FechaVencimiento2.Value).ToString("00")
        Else
            value &= "0000000" & "00"
        End If

        ' 3er. vencimiento
        If ImporteTotal3.HasValue AndAlso ImporteTotal3.Value > 0 Then
            ' Importe 3er. vencimiento
            value &= ImporteTotal3.Value.ToString("00000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")
            ' Fecha 3er. vencimiento
            value &= DateDiff(DateInterval.Day, FechaVencimiento1.Value, FechaVencimiento3.Value).ToString("00")
        Else
            value &= "0000000" & "00"
        End If


        ' Dígitos verificadores
        value &= ObtenerDigitosVerificadores(value)

        CodigoBarrasSepsa = value

        Return True
    End Function

    Private Function ObtenerDigitosVerificadores(ByVal value As String) As String
        Dim secuencia As String
        Dim sumaProductos As Integer = 0
        Dim primerDigito As Integer
        Dim segundoDigito As Integer

        ' Primer dígito verificador
        ' =========================
        secuencia = CompletarSecuencias(value)
        sumaProductos = SumarProductos(value, secuencia)

        primerDigito = (sumaProductos \ 2) Mod 10
        value &= primerDigito

        ' Segundo dígito verificador
        ' ==========================
        secuencia = CompletarSecuencias(value)
        sumaProductos = SumarProductos(value, secuencia)

        segundoDigito = (sumaProductos \ 2) Mod 10

        Return primerDigito & segundoDigito
    End Function

    Private Function CompletarSecuencias(ByVal value As String) As String
        Const PrimeraSecuencia As String = "13579"
        Const SegundaSecuencia As String = "3579"

        Dim secuencia As String
        Dim longitud As Integer

        ' Primera secuencia
        If value.Length < PrimeraSecuencia.Length Then
            longitud = value.Length
        Else
            longitud = PrimeraSecuencia.Length
        End If
        secuencia = PrimeraSecuencia.Substring(0, longitud)

        ' Segunda secuencia
        Do While secuencia.Length < value.Length
            If (value.Length - secuencia.Length) < SegundaSecuencia.Length Then
                longitud = value.Length - secuencia.Length
            Else
                longitud = SegundaSecuencia.Length
            End If
            secuencia &= SegundaSecuencia.Substring(0, longitud)
        Loop

        Return secuencia
    End Function

    Private Function SumarProductos(ByVal value As String, ByVal secuencia As String) As Integer
        Dim suma As Integer = 0

        ' Sumo los productos de cada dígito de la secuencia con cada dígito del dato
        For index As Integer = 0 To value.Length - 1
            suma += (CByte(value.Substring(index, 1)) * CByte(secuencia.Substring(index, 1)))
        Next

        Return suma
    End Function

#End Region

End Class