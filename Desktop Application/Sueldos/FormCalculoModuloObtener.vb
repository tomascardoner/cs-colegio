Imports System.Net

Public Class FormCalculoModuloObtener

#Region "Declarations"

    Private Class DataGridRowData
        Public Property Codigo As String
        Public Property Concepto As String
        Public Property Importe As Decimal
    End Class

    Private _Rows As New List(Of DataGridRowData)

#End Region

#Region "Form stuff"

    Public Sub New(Anio As Short, Mes As Byte)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeForm(Anio, Mes)
    End Sub

    Private Sub InitializeForm(Anio As Short, Mes As Byte)
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)

        pFillAndRefreshLists.AnioLectivo(ToolStripComboBoxAnio.ComboBox, False, SortOrder.Descending)
        ToolStripComboBoxAnio.SelectedIndex = ToolStripComboBoxAnio.FindStringExact(Anio.ToString)
        pFillAndRefreshLists.MesNombres(ToolStripComboBoxMes.ComboBox, True, False, False)
        ToolStripComboBoxMes.SelectedIndex = CInt(IIf(Mes = 0, DateTime.Today.Month, Mes)) - 1
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
                If dbContext.SueldoCalculoModulo.Any(Function(scm) scm.Anio = CShort(ToolStripComboBoxAnio.Text) AndAlso scm.Mes = ToolStripComboBoxMes.SelectedIndex + 1) Then
                    Cursor = Cursors.Default
                    MessageBox.Show("No se pueden guardar los datos porque ya existen para el período seleccionado.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                For Each row As DataGridRowData In _Rows
                    Dim newRow As SueldoCalculoModulo = ObtenerNuevoRegistro(dbContext, row)
                    If newRow IsNot Nothing Then
                        dbContext.SueldoCalculoModulo.Add(newRow)
                    End If
                Next
                dbContext.SaveChanges()
                FormCalculosModulos.RefreshData()
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
        If ToolStripComboBoxAnio.SelectedIndex = -1 Then
            MsgBox("Debe especificar el año.", MsgBoxStyle.Information, My.Application.Info.Title)
            ToolStripComboBoxAnio.Focus()
            Return False
        End If
        If ToolStripComboBoxMes.SelectedIndex = -1 Then
            MsgBox("Debe especificar el mes.", MsgBoxStyle.Information, My.Application.Info.Title)
            ToolStripComboBoxMes.Focus()
            Return False
        End If
        If ToolStripComboBoxAnio.SelectedIndex = 0 AndAlso ToolStripComboBoxMes.SelectedIndex + 1 = DateTime.Today.Month Then
            MessageBox.Show("El mes del período no puede ser mayor al actual.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                .Anio = Convert.ToInt16(ToolStripComboBoxAnio.Text),
                .Mes = Convert.ToByte(ToolStripComboBoxMes.SelectedIndex + 1),
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

    Private Sub ObtenerDatos()
        Dim document As New HtmlAgilityPack.HtmlDocument

        Cursor = Cursors.WaitCursor

        If Not ObtenerPaginaResultado(document) Then
            Cursor = Cursors.Default
            Return
        End If

        _Rows.Clear()

        Try
            Dim rows As HtmlAgilityPack.HtmlNodeCollection = document.DocumentNode.SelectNodes(CS_Parameter_System.GetString(Parametros.SUELDO_MODULO_OBTENER_XPATH))
            Dim node As HtmlAgilityPack.HtmlNode

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
                If Not String.IsNullOrWhiteSpace(importeString) Then
                    Decimal.TryParse(importeString, newRow.Importe)
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