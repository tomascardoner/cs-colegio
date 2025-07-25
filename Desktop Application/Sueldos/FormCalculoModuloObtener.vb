﻿Imports System.Globalization
Imports System.Net
Imports System.Net.Http

Public Class FormCalculoModuloObtener

#Region "Declarations"

    Private _PeriodoAnio As Short
    Private _PeriodoMes As Byte

    Private Class DataGridRowData
        Public Property Codigo As String
        Public Property Concepto As String
        Public Property Importe As Decimal
    End Class

    Private _Rows As New List(Of DataGridRowData)

#End Region

#Region "Form stuff"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Rows = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub ToolStripButtonObtenerDatos_Click(sender As Object, e As EventArgs) Handles ToolStripButtonObtenerDatos.Click
        ObtenerDatos()
    End Sub

    Private Sub ToolStripButtonGuardar_Click(sender As Object, e As EventArgs) Handles ToolStripButtonGuardar.Click
        If Not VerificarDatos() Then
            Return
        End If

        Cursor = Cursors.WaitCursor
        Try
            Using dbContext As New CSColegioContext(True)
                If dbContext.SueldoCalculoModulo.Any(Function(scm) scm.Anio = _PeriodoAnio AndAlso scm.Mes = _PeriodoMes) Then
                    Cursor = Cursors.Default
                    MessageBox.Show("No se pueden guardar los datos porque ya existen para el período.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                For Each row As DataGridRowData In _Rows
                    Dim newRow As SueldoCalculoModulo = ObtenerNuevoRegistro(dbContext, row)
                    If newRow IsNot Nothing Then
                        dbContext.SueldoCalculoModulo.Add(newRow)
                    End If
                Next
                dbContext.SaveChanges()
                Comunes.RefreshLists.SueldosCalculosModulos.Refresh()
                MessageBox.Show("Se han guardado los datos de los cálculos de módulos de sueldos.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al guardar los datos de los cálculos de módulos de sueldos.")
        End Try
        Cursor = Cursors.Default
        Me.Close()
    End Sub

#End Region

#Region "Extra stuff"

    Private Function VerificarDatos() As Boolean
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show($"No hay datos para guardar.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If _PeriodoAnio = 0 OrElse _PeriodoMes = 0 Then
            MessageBox.Show($"No se ha podido determinar el período.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Function ObtenerNuevoRegistro(dbContext As CSColegioContext, row As DataGridRowData) As SueldoCalculoModulo
        Dim codigo As Short
        If Not Short.TryParse(row.Codigo, codigo) Then
            MessageBox.Show("El código del concepto no es un valor númerico.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        Try
            Dim sueldoConcepto As SueldoConcepto = dbContext.SueldoConcepto.FirstOrDefault(Function(sc) sc.Codigo.HasValue AndAlso sc.Codigo.Value = codigo)
            If sueldoConcepto Is Nothing Then
                MessageBox.Show($"No se ha encontrado el concepto a partir del código '{codigo}'.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End If

            Return New SueldoCalculoModulo With {
                .Anio = _PeriodoAnio,
                .Mes = _PeriodoMes,
                .IdSueldoConcepto = sueldoConcepto.IdSueldoConcepto,
                .Importe = Math.Abs(row.Importe),
                .IdUsuarioCreacion = pUsuario.IDUsuario,
                .FechaHoraCreacion = Now,
                .IdUsuarioModificacion = pUsuario.IDUsuario,
                .FechaHoraModificacion = Now
            }
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al generar el nuevo registro.")
            Return Nothing
        End Try
    End Function

    Private Function ObtenerParametros() As String
        Dim sb As New Text.StringBuilder
        Const ParametroFormato As String = "{0}={1}&"

        sb.AppendFormat(ParametroFormato, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_NIVEL_ID), Uri.EscapeDataString(CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_NIVEL_VALUE).ToString()))
        sb.AppendFormat(ParametroFormato, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_ESCALAFON_ID), Uri.EscapeDataString(CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_ESCALAFON_VALUE).ToString()))
        sb.AppendFormat(ParametroFormato, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_ANTIGUEDAD_ID), Uri.EscapeDataString(CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_ANTIGUEDAD_VALUE).ToString()))
        sb.AppendFormat(ParametroFormato, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_DESFAVORABILIDAD_ID), Uri.EscapeDataString(CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_DESFAVORABILIDAD_VALUE).ToString()))

        Return sb.ToString()
    End Function

    Private Function ObtenerPaginaResultado(ByRef document As HtmlAgilityPack.HtmlDocument) As Boolean
        Try
            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(ObtenerParametros())
            Dim request As HttpWebRequest = CType(WebRequest.Create(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_URL)), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            Using requestStream As IO.Stream = request.GetRequestStream()
                requestStream.Write(byteArray, 0, byteArray.Length)
            End Using
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using responseStream As IO.Stream = response.GetResponseStream()
                    document.Load(responseStream)
                End Using
            End Using
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la información desde la web.")
            Return False
        End Try
    End Function

    Private Function ReemplazarValorEnForm(ByRef document As HtmlAgilityPack.HtmlDocument, formFieldId As String, value As Integer) As Boolean
        ' Find the select element
        Dim selectNode As HtmlAgilityPack.HtmlNode = document.DocumentNode.SelectSingleNode(formFieldId)
        If selectNode Is Nothing Then
            MessageBox.Show("No se encontró el campo en la página web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            ' Replace the value in the select element
            Dim optionNode As HtmlAgilityPack.HtmlNode = selectNode.SelectSingleNode($"option[@value='{value}']")
            If optionNode Is Nothing Then
                MessageBox.Show($"No se encontró la opción con el valor en el campo de la página web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                optionNode.SetAttributeValue("selected", "selected")
                Return True
            End If
        End If
    End Function

    Private Function ReemplazarValoresEnForm(ByRef document As HtmlAgilityPack.HtmlDocument) As Boolean
        ' Find the form by ID
        Dim formNode As HtmlAgilityPack.HtmlNode = document.DocumentNode.SelectSingleNode(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_ID))
        If formNode Is Nothing Then
            MessageBox.Show("No se encontró el formulario en la página web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Replace the values in the form
        If ReemplazarValorEnForm(document, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_NIVEL_ID), CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_NIVEL_VALUE)) AndAlso
           ReemplazarValorEnForm(document, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_ESCALAFON_ID), CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_ESCALAFON_VALUE)) AndAlso
           ReemplazarValorEnForm(document, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_ANTIGUEDAD_ID), CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_ANTIGUEDAD_VALUE)) AndAlso
           ReemplazarValorEnForm(document, CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_FORM_DESFAVORABILIDAD_ID), CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_DESFAVORABILIDAD_VALUE)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ObtenerPaginaInicial(ByRef document As HtmlAgilityPack.HtmlDocument) As Boolean
        Try
            Dim HtmlWeb As New HtmlAgilityPack.HtmlWeb
            document = HtmlWeb.Load(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_URL))
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la página inicial desde la web.")
            Return False
        End Try
    End Function

    Private Function EnviarPaginaConValores(ByRef document As HtmlAgilityPack.HtmlDocument) As Boolean
        Dim httpClient As New HttpClient()
        Try
            Dim content As New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"nivel", CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_NIVEL_VALUE).ToString()},
                {"escalafon", CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_ESCALAFON_VALUE).ToString()},
                {"antiguedad", CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_ANTIGUEDAD_VALUE).ToString()},
                {"desfavorabilidad", CS_Parameter_System.GetIntegerAsInteger(Parametros.SUELDO_MODULO_OBTENER_FORM_DESFAVORABILIDAD_VALUE).ToString()},
                {"zona_fria", "N"}
            })
            Dim response As HttpResponseMessage = httpClient.PostAsync(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_URL), content).Result
            If response.IsSuccessStatusCode Then
                Dim responseContent As String = response.Content.ReadAsStringAsync().Result
                document.LoadHtml(responseContent)
                Return True
            Else
                MessageBox.Show("Error al enviar los datos a la página web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar los datos a la página web.")
            Return False
        End Try
    End Function

    Private Sub ObtenerDatos()
        Dim document As New HtmlAgilityPack.HtmlDocument
        Dim node As HtmlAgilityPack.HtmlNode
        Dim culture As New CultureInfo("es-AR")
        Dim nfi As New NumberFormatInfo() With {
            .NumberGroupSeparator = ".",
            .NumberDecimalSeparator = ",",
            .CurrencyGroupSeparator = ".",
            .CurrencyDecimalSeparator = ","
        }

        Cursor = Cursors.WaitCursor

        If Not ObtenerPaginaInicial(document) Then
            Cursor = Cursors.Default
            Return
        End If

        If Not ReemplazarValoresEnForm(document) Then
            Cursor = Cursors.Default
            Return
        End If

        If Not EnviarPaginaConValores(document) Then
            Cursor = Cursors.Default
            Return
        End If

        _Rows.Clear()

        Try
            ' Obtengo el período correspondiente al cálculo
            node = document.DocumentNode.SelectSingleNode(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_PERIODO_XPATH))
            If node Is Nothing OrElse Not HtmlAgilityPack.HtmlEntity.DeEntitize(node.InnerText).StartsWith(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_PERIODO_PREFIJO)) Then
                Cursor = Cursors.Default
                MessageBox.Show($"No se ha encontrado la información del período en la web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim periodoString As String = HtmlAgilityPack.HtmlEntity.DeEntitize(node.InnerText.Substring(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_PERIODO_PREFIJO).Length))
            periodoString = periodoString.Substring(0, periodoString.IndexOf(","c)).Trim()
            Dim periodo As Date
            If Not Date.TryParseExact(periodoString.ToLower(), "MMMM yyyy", culture, DateTimeStyles.AllowInnerWhite, periodo) Then
                Cursor = Cursors.Default
                MessageBox.Show($"No se ha encontrado la información del período en la web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            _PeriodoAnio = Convert.ToInt16(periodo.Year)
            _PeriodoMes = Convert.ToByte(periodo.Month)
            ToolStripLabelPeriodo.Text = "Período: " & periodo.ToString("MMMM \d\e yyyy")

            Dim rows As HtmlAgilityPack.HtmlNodeCollection = document.DocumentNode.SelectNodes(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_DATOS_XPATH))

            For Each row As HtmlAgilityPack.HtmlNode In rows.Skip(1)
                Dim newRow As New DataGridRowData

                ' Código
                node = row.SelectSingleNode("div[1]")
                If node Is Nothing Then
                    Continue For
                End If
                newRow.Codigo = HtmlAgilityPack.HtmlEntity.DeEntitize(node.InnerText)

                ' Concepto
                node = row.SelectSingleNode("div[2]")
                If node Is Nothing Then
                    Continue For
                End If
                newRow.Concepto = HtmlAgilityPack.HtmlEntity.DeEntitize(node.InnerText)

                ' Importe
                node = row.SelectSingleNode("div[3]")
                If node Is Nothing Then
                    Continue For
                End If
                Dim importeString As String = HtmlAgilityPack.HtmlEntity.DeEntitize(node.InnerText)
                If String.IsNullOrWhiteSpace(importeString) Then
                    MessageBox.Show("No se ha podido obtener el dato del importe desde la web.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                If Not Decimal.TryParse(importeString, NumberStyles.Any, nfi, newRow.Importe) Then
                    MessageBox.Show($"No se ha podido convertir el dato del importe desde la web ({importeString}).", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                _Rows.Add(newRow)
            Next

        Catch ex As Exception
            MessageBox.Show($"Error al obtener los importes desde la web.\n\n{ex.Message}", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        DataGridViewMain.AutoGenerateColumns = False
        DataGridViewMain.DataSource = _Rows
        DataGridViewMain.Refresh()
        Cursor = Cursors.Default
    End Sub

#End Region

End Class