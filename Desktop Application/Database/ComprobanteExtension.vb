Partial Public Class Comprobante

#Region "Codigo de barras SEPSA"

    Public Function CalcularCodigoBarrasSepsa(ByVal documentoNumero As String) As Boolean
        Dim idCliente As Integer
        Dim value As String
        Const Importe1Maximo As Decimal = CDec(9999999.99)
        Const Importe2Maximo As Decimal = CDec(9999999.99)

        idCliente = CS_Parameter_System.GetIntegerAsInteger(Parametros.EMPRESA_PAGOSEDUC_NUMERO)
        If idCliente = 0 Then
            Return False
        End If
        If ImporteTotal1 > Importe1Maximo Then
            MessageBox.Show($"El importe del 1er. vencimiento de la factura ({FormatCurrency(ImporteTotal1)}) es mayor al máximo permitido por el código SEPSA ({FormatCurrency(Importe1Maximo)}).{vbCrLf}{vbCrLf}Titular: {ApellidoNombre}", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If ImporteTotal2.HasValue AndAlso ImporteTotal2.Value > Importe2Maximo Then
            MessageBox.Show($"El importe del 2do. vencimiento de la factura ({FormatCurrency(ImporteTotal2)}) es mayor al máximo permitido por el código SEPSA ({FormatCurrency(Importe2Maximo)}).{vbCrLf}{vbCrLf}Titular: {ApellidoNombre}", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Código de PAGOSEduc
        value = "09370007"
        ' Importe 1er. vencimiento
        value &= ImporteTotal1.ToString("0000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")
        ' Fecha 1er. vencimiento (YYJJJ) dónde JJJ son los días transcurridos desde el 1 de enero
        Dim span As TimeSpan
        span = FechaVencimiento1.Value.Subtract(New Date(FechaVencimiento1.Value.Year(), 1, 1))
        value &= FechaVencimiento1.Value.ToString("yy") & span.Days.ToString().PadLeft(3, "0"c)
        ' Código de cliente
        value &= idCliente.ToString().PadLeft(5, "0"c)
        ' Cliente
        value &= documentoNumero.RemoveNotNumbers().Truncate(14).PadLeft(14, "0"c)
        ' 2do. vencimiento
        If ImporteTotal2.HasValue AndAlso ImporteTotal2.Value > 0 Then
            ' Importe 2do. vencimiento
            value &= ImporteTotal2.Value.ToString("0000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")
            ' Fecha 2do. vencimiento
            value &= DateDiff(DateInterval.Day, FechaVencimiento1.Value, FechaVencimiento2.Value).ToString("00")
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
        Dim sumaProductos As Integer
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