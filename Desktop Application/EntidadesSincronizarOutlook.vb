Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlook
    ''' <summary>
    ''' Sincroniza las Entidades de la base de datos con los Contactos de Micrsoft Outlook
    ''' </summary>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function Sincronizar(ByVal Opciones As EntidadesSincronizarOutlookOpciones, ByRef LabelEstado As Label, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookAplicacion As Outlook.Application = Nothing
        Dim OutlookContacts As Outlook.Items = Nothing

        Dim EntidadesVerificadasEnOutlook As New List(Of Integer)

        Dim qryEntidades As System.Linq.IQueryable(Of Entidad)

        Dim listGruposDeTipoVerificadosEnOutlook As New List(Of String)
        Dim listGruposDeNivelVerificadosEnOutlook As New List(Of Byte)
        Dim listGruposDeCursoVerificadosEnOutlook As New List(Of Byte)

        LabelEstado.Text = "Iniciando instancia de Microsoft Outlook..."
        LabelEstado.Visible = True
        ProgressBarProgreso.Value = 0
        ProgressBarProgreso.Visible = True
        Application.DoEvents()

        If Not InicializarAplicacion(OutlookAplicacion, OutlookContacts) Then
            OutlookAplicacion = Nothing
            OutlookContacts = Nothing
            EntidadesVerificadasEnOutlook = Nothing
            Return False
        End If


        Using dbContext As New CSColegioContext(True)
            ' Verifico los Contactos
            LabelEstado.Text = "Verificando Contactos existentes en Outlook..."
            Application.DoEvents()

            If Not EntidadesSincronizarOutlookContactos.VerificarContactosEnOutlook(OutlookContacts, dbContext, EntidadesVerificadasEnOutlook, OpcionContactoHuerfanoBorrar, ProgressBarProgreso) Then
                OutlookAplicacion = Nothing
                OutlookContacts = Nothing
                Return False
            End If

            Try
                If checkboxEntidadTipoPersonalColegio.Checked And checkboxEntidadTipoDocente.Checked And checkboxEntidadTipoAlumno.Checked And checkboxEntidadTipoFamiliar.Checked And checkboxEntidadTipoProveedor.Checked And checkboxEntidadTipoOtro.Checked Then
                    ' Todas las Entidades
                    qryEntidades = dbContext.Entidad.Where(Function(e) e.EsActivo And (Not (e.Email1 Is Nothing And e.Email2 Is Nothing)))
                Else
                    ' Sólo las seleccionadas
                    qryEntidades = dbContext.Entidad.Where(Function(e) e.EsActivo And (Not (e.Email1 Is Nothing And e.Email2 Is Nothing)) And ((checkboxEntidadTipoPersonalColegio.Checked And e.TipoPersonalColegio) Or (checkboxEntidadTipoDocente.Checked And e.TipoDocente) Or (checkboxEntidadTipoAlumno.Checked And e.TipoAlumno) Or (checkboxEntidadTipoFamiliar.Checked And e.TipoFamiliar) Or (checkboxEntidadTipoProveedor.Checked And e.TipoProveedor) Or (checkboxEntidadTipoOtro.Checked And e.TipoOtro)))
                End If
            Catch ex As Exception
                CS_Error.ProcessError(ex, "Error al obtener las Entidades de la base de datos.")
                OutlookAplicacion = Nothing
                OutlookContacts = Nothing
                Return False
            End Try
            If Not SyncronizeWithOutlook_VerifyContactsInDatabase(otkApp, qryEntidades, listEntidadesVerificadasEnOutlook) Then
                otkApp = Nothing
                OutlookContacts = Nothing
                Return False
            End If

            ' Verifico los Grupos de Contactos
            If Not SynchronizeWithOutlook_VerifyContactsGroupsInOutlook(otkContactsItems, dbContext, listGruposDeTipoVerificadosEnOutlook, listGruposDeNivelVerificadosEnOutlook, listGruposDeCursoVerificadosEnOutlook) Then
                otkApp = Nothing
                OutlookContacts = Nothing
                Return False
            End If

            If Not SyncronizeWithOutlook_VerifyContactGroupsInDatabase(otkApp, qryEntidades, listGruposDeTipoVerificadosEnOutlook) Then
                otkApp = Nothing
                OutlookContacts = Nothing
                Return False
            End If
        End Using

        motkApp = Nothing
        OutlookContacts = Nothing
        listEntidadesVerificadasEnOutlook = Nothing

        Return True
    End Function

    ''' <summary>
    ''' Inicia los objetos para interactuar con Microsft Outlook
    ''' </summary>
    ''' <param name="OutlookApplication">Instancia al objeto Outlook Application</param>
    ''' <param name="OutlookContacts">Carpeta de Contactos de Outlook</param>
    ''' <returns>True si se pudo incializar</returns>
    ''' <remarks></remarks>
    Private Function InicializarAplicacion(ByRef OutlookApplication As Outlook.Application, ByRef OutlookContacts As Outlook.Items) As Boolean
        Dim OutlookSession As Outlook.NameSpace
        Dim OutlookFolderContacts As Outlook.MAPIFolder

        Try
            OutlookApplication = New Outlook.Application
            OutlookSession = OutlookApplication.Session
            OutlookFolderContacts = OutlookSession.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
            OutlookContacts = OutlookFolderContacts.Items
            Return True

        Catch ex As Exception
            OutlookSession = Nothing
            OutlookFolderContacts = Nothing

            CS_Error.ProcessError(ex, "Error al iniciar una instancia de Microsoft Outlook.")
            Return False
        End Try
    End Function
End Module
