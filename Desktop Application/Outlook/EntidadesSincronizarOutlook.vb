Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlook
    ''' <summary>
    ''' Sincroniza las Entidades de la base de datos con los Contactos de Micrsoft Outlook
    ''' </summary>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function Sincronizar(ByVal Opciones As EntidadesSincronizarOutlookOpciones, ByRef LabelEstado As Label, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookApplication As Outlook.Application = Nothing
        Dim OutlookContacts As Outlook.Items = Nothing

        Dim IDEntidadesVerificadasEnOutlook As New List(Of Integer)
        Dim Entidades As List(Of Entidad)

        Dim GruposDeTipoVerificadosEnOutlook As New List(Of String)
        Dim GruposDeNivelVerificadosEnOutlook As New List(Of Byte)
        Dim GruposDeCursoVerificadosEnOutlook As New List(Of Byte)

        LabelEstado.Text = "Iniciando instancia de Microsoft Outlook..."
        LabelEstado.Visible = True
        Application.DoEvents()

        If InicializarAplicacion(OutlookApplication, OutlookContacts) Then
            ProgressBarProgreso.Value = 0
            ProgressBarProgreso.Visible = True
            Application.DoEvents()

            Using dbContext As New CSColegioContext(True)
                ' Verifico los Contactos de Outlook
                LabelEstado.Text = "Verificando Contactos existentes en Outlook..."
                Application.DoEvents()

                If EntidadesSincronizarOutlookContactos.VerificarContactosEnOutlook(OutlookContacts, dbContext, IDEntidadesVerificadasEnOutlook, Opciones, ProgressBarProgreso) Then
                    Try
                        If Opciones.EntidadTipoPersonalColegio AndAlso Opciones.EntidadTipoDocente AndAlso Opciones.EntidadTipoAlumno AndAlso Opciones.EntidadTipoFamiliar AndAlso Opciones.EntidadTipoProveedor AndAlso Opciones.EntidadTipoOtro Then
                            ' Todas las Entidades
                            Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo AndAlso (Not (e.Email1 Is Nothing AndAlso e.Email2 Is Nothing))).ToList
                        Else
                            ' Sólo las seleccionadas
                            Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo AndAlso (Not (e.Email1 Is Nothing AndAlso e.Email2 Is Nothing)) AndAlso ((Opciones.EntidadTipoPersonalColegio AndAlso e.TipoPersonalColegio) OrElse (Opciones.EntidadTipoDocente AndAlso e.TipoDocente) OrElse (Opciones.EntidadTipoAlumno AndAlso e.TipoAlumno) OrElse (Opciones.EntidadTipoFamiliar AndAlso e.TipoFamiliar) OrElse (Opciones.EntidadTipoProveedor AndAlso e.TipoProveedor) OrElse (Opciones.EntidadTipoOtro AndAlso e.TipoOtro))).ToList
                        End If
                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener las Entidades de la base de datos.")
                        OutlookApplication = Nothing
                        OutlookContacts = Nothing
                        IDEntidadesVerificadasEnOutlook = Nothing
                        Entidades = Nothing
                        GruposDeTipoVerificadosEnOutlook = Nothing
                        GruposDeNivelVerificadosEnOutlook = Nothing
                        GruposDeCursoVerificadosEnOutlook = Nothing
                        Return False
                    End Try

                    ' Verifico los Contactos en la Base de Datos para ver si falta agregar alguno
                    LabelEstado.Text = "Verificando Entidades en el Sistema..."
                    Application.DoEvents()
                    If EntidadesSincronizarOutlookContactos.VerificarContactosEnBaseDeDatos(OutlookApplication, Entidades, IDEntidadesVerificadasEnOutlook, ProgressBarProgreso) Then

                        ' Verifico los Grupos de Contactos
                        LabelEstado.Text = "Verificando Grupos de Contactos existentes en Outlook..."
                        If EntidadesSincronizarOutlookGruposExistentes.VerificarGrupos(OutlookApplication, OutlookContacts, dbContext, GruposDeTipoVerificadosEnOutlook, GruposDeNivelVerificadosEnOutlook, GruposDeCursoVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then

                            LabelEstado.Text = "Verificando Grupos de Contactos en el Sistema (Tipos)..."
                            If EntidadesSincronizarOutlookGruposInexistentes.VerificarYCrearGruposDeTiposDeEntidad(OutlookApplication, Entidades, GruposDeTipoVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then

                                LabelEstado.Text = "Verificando Grupos de Contactos en el Sistema (Cursos)..."
                                'If EntidadesSincronizarOutlookGruposInexistentes.VerificarYCrearGrupoDeCurso(OutlookApplication, Entidades, GruposDeTipoVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then

                                '    LabelEstado.Text = "Verificando Grupos de Contactos en el Sistema (Nivel)..."
                                '    If EntidadesSincronizarOutlookGruposInexistentes.VerificarYCrearGruposDeNiveles(OutlookApplication, dbContext, Entidades, GruposDeTipoVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then
                                '        OutlookApplication = Nothing
                                '        OutlookContacts = Nothing
                                '        IDEntidadesVerificadasEnOutlook = Nothing
                                '        Entidades = Nothing
                                '        GruposDeTipoVerificadosEnOutlook = Nothing
                                '        GruposDeNivelVerificadosEnOutlook = Nothing
                                '        GruposDeCursoVerificadosEnOutlook = Nothing
                                '        Return True
                                '    End If

                                'End If

                            End If

                        End If

                    End If

                End If
            End Using
        End If

        OutlookApplication = Nothing
        OutlookContacts = Nothing
        IDEntidadesVerificadasEnOutlook = Nothing
        Entidades = Nothing
        GruposDeTipoVerificadosEnOutlook = Nothing
        GruposDeNivelVerificadosEnOutlook = Nothing
        GruposDeCursoVerificadosEnOutlook = Nothing
        Return False
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

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al iniciar una instancia de Microsoft Outlook.")
            Return False
        End Try
    End Function
End Module
