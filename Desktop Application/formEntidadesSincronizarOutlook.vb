﻿Imports Microsoft.Office.Interop

Public Class formEntidadesSincronizarOutlook

#Region "Declarations"
    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Private Sub ChangeMode()
        If mIsLoading Then
            Exit Sub
        End If

        checkboxEntidadTipoPersonalColegio.Enabled = mEditMode
        checkboxEntidadTipoDocente.Enabled = mEditMode
        checkboxEntidadTipoAlumno.Enabled = mEditMode
        checkboxEntidadTipoFamiliar.Enabled = mEditMode
        checkboxEntidadTipoProveedor.Enabled = mEditMode
        checkboxEntidadTipoOtro.Enabled = mEditMode

        radiobuttonGrupoContactosIgnorar.Enabled = mEditMode
        radiobuttonGrupoContactosBorrar.Enabled = mEditMode

        radiobuttonContactosIgnorar.Enabled = mEditMode
        radiobuttonContactosBorrar.Enabled = mEditMode

        checkboxCrearGruposEntidadTipo.Enabled = mEditMode
        checkboxCrearGruposNivelYCurso.Enabled = mEditMode

        checkedlistboxAnioLectivo.Enabled = mEditMode

        buttonEditar.Visible = pUsuario.IDUsuario = USUARIO_ADMINISTRADOR
    End Sub

    Private Sub LoadOptions()
        ' Cargo las opciones
        checkboxEntidadTipoPersonalColegio.Checked = My.Settings.Outlook_ContactsSync_EntidadTipo_PersonalColegio
        checkboxEntidadTipoDocente.Checked = My.Settings.Outlook_ContactsSync_EntidadTipo_Docente
        checkboxEntidadTipoAlumno.Checked = My.Settings.Outlook_ContactsSync_EntidadTipo_Alumno
        checkboxEntidadTipoFamiliar.Checked = My.Settings.Outlook_ContactsSync_EntidadTipo_Familiar
        checkboxEntidadTipoProveedor.Checked = My.Settings.Outlook_ContactsSync_EntidadTipo_Proveedor
        checkboxEntidadTipoOtro.Checked = My.Settings.Outlook_ContactsSync_EntidadTipo_Otro

        radiobuttonGrupoContactosIgnorar.Checked = Not My.Settings.Outlook_ContactsSync_GrupoNoEncontrado_Borrar
        radiobuttonGrupoContactosBorrar.Checked = My.Settings.Outlook_ContactsSync_GrupoNoEncontrado_Borrar

        radiobuttonContactosIgnorar.Checked = Not My.Settings.Outlook_ContactsSync_ContactoNoEncontrado_Borrar
        radiobuttonContactosBorrar.Checked = My.Settings.Outlook_ContactsSync_ContactoNoEncontrado_Borrar

        checkboxCrearGruposEntidadTipo.Checked = My.Settings.Outlook_ContactsSync_CrearGrupos_EntidadTipo
        checkboxCrearGruposNivelYCurso.Checked = My.Settings.Outlook_ContactsSync_CrearGrupos_NivelYCurso
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        mEditMode = False
        ChangeMode()

        pFillAndRefreshLists.AnioLectivo(checkedlistboxAnioLectivo, False, SortOrder.Ascending)

        LoadOptions()
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub Editar(sender As Object, e As EventArgs) Handles buttonEditar.Click
        mEditMode = True
        ChangeMode()
    End Sub

    Private Sub Sincronizar(sender As Object, e As EventArgs) Handles buttonSincronizar.Click
        If Not (checkboxEntidadTipoPersonalColegio.Checked Or checkboxEntidadTipoDocente.Checked Or checkboxEntidadTipoAlumno.Checked Or checkboxEntidadTipoFamiliar.Checked Or checkboxEntidadTipoProveedor.Checked Or checkboxEntidadTipoOtro.Checked) Then
            MsgBox("Para poder sincronizar con Microsoft Outlook, es necesario que seleccione al menos un Tipo de Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If

        ' Si se modificaron, guardo las nuevas opciones de sincronización
        If mEditMode Then
            'My.Settings.Outlook_ContactsSync_EntidadTipo_PersonalColegio = checkboxEntidadTipoPersonalColegio.Checked
            'My.Settings.
            'My.Settings.Save()
        End If

        If SynchronizeWithOutlook() Then
            MsgBox("Se han sincronizado las Entidades con los contactos de Microsoft Outlook.", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Else
            progressbarMain.Visible = False
            progressbarMain.Value = 0
            labelStatus.Visible = False
            labelStatus.Text = ""
        End If
    End Sub
#End Region

#Region "Synchronize With Outlook"
    ''' <summary>
    ''' Sincroniza las Entidades de la base de datos con los Contactos de Micrsoft Outlook
    ''' </summary>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SynchronizeWithOutlook() As Boolean
        Dim otkApp As Outlook.Application = Nothing
        Dim otkContactsItems As Outlook.Items = Nothing

        Dim listGruposDeTipoVerificadosEnOutlook As New List(Of String)
        Dim listGruposDeNivelVerificadosEnOutlook As New List(Of Byte)
        Dim listGruposDeCursoVerificadosEnOutlook As New List(Of Byte)
        Dim listEntidadesVerificadasEnOutlook As New List(Of Integer)

        Me.Cursor = Cursors.WaitCursor

        If Not SynchronizeWithOutlook_InitializeApplication(otkApp, otkContactsItems) Then
            otkApp = Nothing
            otkContactsItems = Nothing
            listEntidadesVerificadasEnOutlook = Nothing
            Return False
        End If

        Using dbContext As New CSColegioContext(True)

            ' Verifico los Contactos
            If Not SynchronizeWithOutlook_VerifyContactsInOutlook(otkContactsItems, dbContext, listEntidadesVerificadasEnOutlook) Then
                otkApp = Nothing
                otkContactsItems = Nothing
                Me.Cursor = Cursors.Default
                Return False
            End If

            If Not SyncronizeWithOutlook_VerifyContactsInDatabase(otkApp, dbContext, listEntidadesVerificadasEnOutlook) Then
                otkApp = Nothing
                otkContactsItems = Nothing
                Me.Cursor = Cursors.Default
                Return False
            End If

            ' Verifico los Grupos de Contactos
            If Not SynchronizeWithOutlook_VerifyContactsGroupsInOutlook(otkContactsItems, dbContext, listGruposDeTipoVerificadosEnOutlook, listGruposDeNivelVerificadosEnOutlook, listGruposDeCursoVerificadosEnOutlook) Then
                otkApp = Nothing
                otkContactsItems = Nothing
                Me.Cursor = Cursors.Default
                Return False
            End If

            If Not SyncronizeWithOutlook_VerifyContactGroupsInDatabase(otkApp, dbContext, listGruposDeTipoVerificadosEnOutlook) Then
                otkApp = Nothing
                otkContactsItems = Nothing
                Me.Cursor = Cursors.Default
                Return False
            End If
        End Using

        listEntidadesVerificadasEnOutlook = Nothing

        otkContactsItems = Nothing
        motkApp = Nothing

        Me.Cursor = Cursors.Default
        Return True
    End Function

    ''' <summary>
    ''' Inicia los objetos para interactuar con Microsft Outlook
    ''' </summary>
    ''' <param name="otkApp"></param>
    ''' <param name="otkContactsItems"></param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SynchronizeWithOutlook_InitializeApplication(ByRef otkApp As Outlook.Application, ByRef otkContactsItems As Outlook.Items) As Boolean
        Dim otkNameSpace As Outlook.NameSpace
        Dim otkContactsFolder As Outlook.MAPIFolder

        Try
            otkApp = New Outlook.Application
            otkNameSpace = otkApp.Session
            otkContactsFolder = otkNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
            otkContactsItems = otkContactsFolder.Items
            Return True

        Catch ex As Exception
            otkNameSpace = Nothing
            otkContactsFolder = Nothing

            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error al iniciar una instancia de Microsoft Outlook.")
            Return False
        End Try
    End Function

#End Region

#Region "Synchronize With Outlook - Contacts"
    ''' <summary>
    ''' Verifico todos los contactos que hay en el Outlook, comparandolos con su respectiva Entidad
    ''' en la base de datos utilizando el campo de id de usuario especificado en los campos de usuario.
    ''' Actualizando los datos de Outlook que hayan cambiado y borrando los contactos de Outlook que no
    ''' estén en la base de datos
    ''' </summary>
    ''' <param name="otkContactsItems">Outlook Contacts collection</param>
    ''' <param name="dbContext">Database context</param>
    ''' <param name="listEntidadesVerificadasEnOutlook"></param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SynchronizeWithOutlook_VerifyContactsInOutlook(ByRef otkContactsItems As Outlook.Items, ByRef dbContext As CSColegioContext, ByRef listEntidadesVerificadasEnOutlook As List(Of Integer)) As Boolean
        Dim otkContactUserProperty As Outlook.UserProperty

        Dim IDEntidad As Integer
        Dim EntidadActual As Entidad
        Dim ContactoOutlookActualizado As Boolean
        Dim ItemIndex As Integer = 0

        Try
            progressbarMain.Value = 0
            progressbarMain.Maximum = otkContactsItems.OfType(Of Outlook.ContactItem).Count
            progressbarMain.Visible = True
            labelStatus.Text = "Verificando Contactos en Outlook..."
            labelStatus.Visible = True

            For Each otkContactItem As Outlook.ContactItem In otkContactsItems.OfType(Of Outlook.ContactItem)()
                With otkContactItem
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD)
                    If Not otkContactUserProperty Is Nothing Then
                        Integer.TryParse(otkContactUserProperty.Value.ToString, IDEntidad)
                        If IDEntidad > 0 Then
                            listEntidadesVerificadasEnOutlook.Add(IDEntidad)
                            EntidadActual = dbContext.Entidad.Find(IDEntidad)
                            If EntidadActual Is Nothing OrElse EntidadActual.EsActivo = False Then
                                ' No existe la Entidad en la base de datos o está desactivada, lo elimino de Outlook
                                .Delete()
                            ElseIf (Not (checkboxEntidadTipoPersonalColegio.Checked And EntidadActual.TipoPersonalColegio) Or (checkboxEntidadTipoDocente.Checked And EntidadActual.TipoDocente) Or (checkboxEntidadTipoAlumno.Checked And EntidadActual.TipoAlumno) Or (checkboxEntidadTipoFamiliar.Checked And EntidadActual.TipoFamiliar) Or (checkboxEntidadTipoProveedor.Checked And EntidadActual.TipoProveedor) Or (checkboxEntidadTipoOtro.Checked And EntidadActual.TipoOtro)) Then
                                ' El Contacto en Outlook no coincide con los Tipos de Entidad seleccionados, lo elimino de Outlook
                                .Delete()
                            ElseIf EntidadActual.Email1 Is Nothing And EntidadActual.Email2 Is Nothing Then
                                ' La Entidad no tiene direcciones de e-mail especificadas
                                .Delete()
                            Else
                                ' Verifico y actualizo las propiedades del contacto
                                ContactoOutlookActualizado = False

                                If .LastName <> EntidadActual.Apellido Then
                                    .LastName = EntidadActual.Apellido
                                    ContactoOutlookActualizado = True
                                End If
                                If .FirstName <> EntidadActual.Nombre Then
                                    .FirstName = EntidadActual.Nombre
                                    ContactoOutlookActualizado = True
                                End If

                                If .Email1Address <> EntidadActual.Email1 Then
                                    .Email1Address = EntidadActual.Email1
                                    SynchronizeWithOutlook_Email1_SetDisplayName(otkContactItem, EntidadActual)
                                    ContactoOutlookActualizado = True
                                End If

                                If .Email2Address <> EntidadActual.Email2 Then
                                    .Email2Address = EntidadActual.Email2
                                    SynchronizeWithOutlook_Email2_SetDisplayName(otkContactItem, EntidadActual)
                                    ContactoOutlookActualizado = True
                                End If

                                If EntidadActual.FechaNacimiento Is Nothing Then
                                    If .Birthday <> CS_Office_Outlook_EarlyBinding.CONTACT_DATE_EMPTYVALUE Then
                                        .Birthday = CS_Office_Outlook_EarlyBinding.CONTACT_DATE_EMPTYVALUE
                                        ContactoOutlookActualizado = True
                                    End If
                                ElseIf .Birthday <> EntidadActual.FechaNacimiento Then
                                    .Birthday = EntidadActual.FechaNacimiento.Value
                                    ContactoOutlookActualizado = True
                                End If

                                If ContactoOutlookActualizado Then
                                    .Save()
                                End If
                            End If
                        Else
                            ' El IDEntidad Especificado tiene un formato erroneo
                            .Delete()
                        End If
                    Else
                        ' El Contacto no pertenece al sistema, si las opciones lo indican, lo borro
                        If radiobuttonContactosBorrar.Checked Then
                            .Delete()
                        End If
                    End If
                End With

                ' Progress bar
                ItemIndex += 1
                progressbarMain.Value = ItemIndex
            Next

            otkContactUserProperty = Nothing
            Return True

        Catch ex As Exception
            otkContactUserProperty = Nothing

            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error verificando los Contactos existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Establece el valor de la propiedad DisplayName del Email1 en Outlook
    ''' </summary>
    ''' <param name="otkContact"></param>
    ''' <param name="EntidadActual"></param>
    ''' <remarks></remarks>
    Private Sub SynchronizeWithOutlook_Email1_SetDisplayName(ByRef otkContact As Outlook.ContactItem, ByRef EntidadActual As Entidad)
        If EntidadActual.Email1 Is Nothing Then
            otkContact.Email1DisplayName = Nothing
        Else
            If EntidadActual.Email2 Is Nothing Then
                otkContact.Email1DisplayName = otkContact.LastNameAndFirstName
            Else
                otkContact.Email1DisplayName = otkContact.LastNameAndFirstName & " (" & otkContact.Email1Address & ")"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Establece el valor de la propiedad DisplayName del Email2 en Outlook
    ''' </summary>
    ''' <param name="otkContact"></param>
    ''' <param name="EntidadActual"></param>
    ''' <remarks></remarks>
    Private Sub SynchronizeWithOutlook_Email2_SetDisplayName(ByRef otkContact As Outlook.ContactItem, ByRef EntidadActual As Entidad)
        If EntidadActual.Email2 Is Nothing Then
            otkContact.Email2DisplayName = Nothing
        Else
            If EntidadActual.Email1 Is Nothing Then
                otkContact.Email2DisplayName = otkContact.LastNameAndFirstName
            Else
                otkContact.Email2DisplayName = otkContact.LastNameAndFirstName & " (" & otkContact.Email1Address & ")"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifico los contactos de la base de datos para ver si hay que agregar alguno
    ''' </summary>
    ''' <param name="otkApp">Microsoft Outlook Application object</param>
    ''' <param name="dbContext">Database context object</param>
    ''' <param name="listEntidadesVerificadasEnOutlook">Lista de IDs de Entidades verificadas en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SyncronizeWithOutlook_VerifyContactsInDatabase(ByRef otkApp As Outlook.Application, ByRef dbContext As CSColegioContext, ByRef listEntidadesVerificadasEnOutlook As List(Of Integer)) As Boolean
        Dim ItemIndex As Integer = 0
        Dim qryEntidad As System.Linq.IQueryable(Of Entidad)

        Try
            If checkboxEntidadTipoPersonalColegio.Checked And checkboxEntidadTipoDocente.Checked And checkboxEntidadTipoAlumno.Checked And checkboxEntidadTipoFamiliar.Checked And checkboxEntidadTipoProveedor.Checked And checkboxEntidadTipoOtro.Checked Then
                ' Todos las Entidades
                qryEntidad = dbContext.Entidad.Where(Function(e) e.EsActivo And (Not (e.Email1 Is Nothing And e.Email2 Is Nothing)))
            Else
                qryEntidad = dbContext.Entidad.Where(Function(e) e.EsActivo And (Not (e.Email1 Is Nothing And e.Email2 Is Nothing)) And ((checkboxEntidadTipoPersonalColegio.Checked And e.TipoPersonalColegio) Or (checkboxEntidadTipoDocente.Checked And e.TipoDocente) Or (checkboxEntidadTipoAlumno.Checked And e.TipoAlumno) Or (checkboxEntidadTipoFamiliar.Checked And e.TipoFamiliar) Or (checkboxEntidadTipoProveedor.Checked And e.TipoProveedor) Or (checkboxEntidadTipoOtro.Checked And e.TipoOtro)))
            End If

            progressbarMain.Value = 0
            progressbarMain.Maximum = qryEntidad.Count
            labelStatus.Text = "Verificando Entidades en Sistema..."

            For Each EntidadActual In qryEntidad
                ' Verifico que no haya sido verificado en el paso anterior
                Dim index As Integer
                index = listEntidadesVerificadasEnOutlook.IndexOf(EntidadActual.IDEntidad)
                If index = -1 Then
                    Dim newOutlookContact As Outlook.ContactItem

                    newOutlookContact = CType(otkApp.CreateItem(Outlook.OlItemType.olContactItem), Outlook.ContactItem)
                    If Not newOutlookContact Is Nothing Then
                        With newOutlookContact
                            .LastName = EntidadActual.Apellido
                            .FirstName = EntidadActual.Nombre

                            .Email1Address = EntidadActual.Email1
                            If .Email1Address <> EntidadActual.Email1 Then
                                .Email1Address = EntidadActual.Email1
                                SynchronizeWithOutlook_Email1_SetDisplayName(newOutlookContact, EntidadActual)
                            End If

                            .Email2Address = EntidadActual.Email2
                            If .Email2Address <> EntidadActual.Email2 Then
                                .Email2Address = EntidadActual.Email2
                                SynchronizeWithOutlook_Email2_SetDisplayName(newOutlookContact, EntidadActual)
                            End If

                            .UserProperties.Add(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD, Outlook.OlUserPropertyType.olInteger).Value = EntidadActual.IDEntidad

                            .Save()
                        End With
                    End If
                End If

                ' Progress bar
                ItemIndex += 1
                progressbarMain.Value = ItemIndex
            Next

            qryEntidad = Nothing
            Return True

        Catch ex As Exception
            qryEntidad = Nothing
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error creando los Contactos no existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

#End Region

#Region "Synchronize With Outlook - Contact Groups"

    ''' <summary>
    ''' Verifica los Grupos de Contactos con el Outlook
    ''' </summary>
    ''' <param name="otkContactsItems"></param>
    ''' <param name="dbContext"></param>
    ''' <param name="listGruposDeTipoVerificadosEnOutlook"></param>
    ''' <param name="listGruposDeNivelVerificadosEnOutlook"></param>
    ''' <param name="listGruposDeCursoVerificadosEnOutlook"></param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SynchronizeWithOutlook_VerifyContactsGroupsInOutlook(ByRef otkContactsItems As Outlook.Items, ByRef dbContext As CSColegioContext, ByRef listGruposDeTipoVerificadosEnOutlook As List(Of String), ByRef listGruposDeNivelVerificadosEnOutlook As List(Of Byte), ByRef listGruposDeCursoVerificadosEnOutlook As List(Of Byte)) As Boolean
        Dim otkContactUserProperty As Outlook.UserProperty

        Dim IDNivel As Byte
        Dim NivelActual As Nivel
        Dim IDCurso As Byte
        Dim CursoActual As Curso
        Dim GrupoOutlookActualizado As Boolean

        Try
            For Each otkContactItem As Outlook.DistListItem In otkContactsItems.OfType(Of Outlook.DistListItem)()
                With otkContactItem
                    ' Verifico si es un Grupo de Tipo de Entidad
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO)
                    If Not otkContactUserProperty Is Nothing Then
                        Select Case otkContactUserProperty.Value.ToString
                            Case Constantes.ENTIDADTIPO_PERSONALCOLEGIO
                                If checkboxEntidadTipoPersonalColegio.Checked Then
                                    'otkContactItem.AddMember()
                                    If Not SynchronizeWithOutlook_ContactsGroupsOfType(otkContactItem, listGruposDeTipoVerificadosEnOutlook, Constantes.ENTIDADTIPO_PERSONALCOLEGIO) Then
                                        otkContactUserProperty = Nothing
                                        Return False
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    .Delete()
                                End If
                            Case Constantes.ENTIDADTIPO_DOCENTE
                                If checkboxEntidadTipoDocente.Checked Then
                                    If Not SynchronizeWithOutlook_ContactsGroupsOfType(otkContactItem, listGruposDeTipoVerificadosEnOutlook, Constantes.ENTIDADTIPO_DOCENTE) Then
                                        otkContactUserProperty = Nothing
                                        Return False
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    .Delete()
                                End If
                            Case Constantes.ENTIDADTIPO_ALUMNO
                                If checkboxEntidadTipoAlumno.Checked Then
                                    If Not SynchronizeWithOutlook_ContactsGroupsOfType(otkContactItem, listGruposDeTipoVerificadosEnOutlook, Constantes.ENTIDADTIPO_ALUMNO) Then
                                        otkContactUserProperty = Nothing
                                        Return False
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    .Delete()
                                End If
                            Case Constantes.ENTIDADTIPO_FAMILIAR
                                If checkboxEntidadTipoFamiliar.Checked Then
                                    If Not SynchronizeWithOutlook_ContactsGroupsOfType(otkContactItem, listGruposDeTipoVerificadosEnOutlook, Constantes.ENTIDADTIPO_FAMILIAR) Then
                                        otkContactUserProperty = Nothing
                                        Return False
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    .Delete()
                                End If
                            Case Constantes.ENTIDADTIPO_PROVEEDOR
                                If checkboxEntidadTipoProveedor.Checked Then
                                    If Not SynchronizeWithOutlook_ContactsGroupsOfType(otkContactItem, listGruposDeTipoVerificadosEnOutlook, Constantes.ENTIDADTIPO_PROVEEDOR) Then
                                        otkContactUserProperty = Nothing
                                        Return False
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    .Delete()
                                End If
                            Case Constantes.ENTIDADTIPO_OTRO
                                If checkboxEntidadTipoOtro.Checked Then
                                    If Not SynchronizeWithOutlook_ContactsGroupsOfType(otkContactItem, listGruposDeTipoVerificadosEnOutlook, Constantes.ENTIDADTIPO_OTRO) Then
                                        otkContactUserProperty = Nothing
                                        Return False
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    .Delete()
                                End If
                            Case Else
                                ' Es un grupo de Tipo pero tiene mal especificado el Tipo
                                .Delete()
                        End Select
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Nivel
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_NIVEL)
                    If Not otkContactUserProperty Is Nothing Then
                        Byte.TryParse(otkContactUserProperty.Value.ToString, IDNivel)
                        If IDNivel > 0 Then
                            listGruposDeNivelVerificadosEnOutlook.Add(IDNivel)
                            NivelActual = dbContext.Nivel.Find(IDNivel)
                            If NivelActual Is Nothing Then
                                ' No existe el Grupo en la base de datos, lo elimino de Outlook
                                .Delete()
                            Else
                                ' Verifico y actualizo las propiedades del grupo
                                GrupoOutlookActualizado = False

                                If .DLName <> String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, NivelActual.Nombre) Then
                                    .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, NivelActual.Nombre)
                                    GrupoOutlookActualizado = True
                                End If

                                If GrupoOutlookActualizado Then
                                    .Save()
                                End If
                            End If
                        Else
                            ' El IDNivel Especificado tiene un formato erroneo
                            .Delete()
                        End If
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Curso
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_CURSO)
                    If Not otkContactUserProperty Is Nothing Then
                        Byte.TryParse(otkContactUserProperty.Value.ToString, IDCurso)
                        If IDCurso > 0 Then
                            listGruposDeCursoVerificadosEnOutlook.Add(IDCurso)
                            CursoActual = dbContext.Curso.Find(IDCurso)
                            If CursoActual Is Nothing Then
                                ' No existe el Grupo en la base de datos, lo elimino de Outlook
                                .Delete()
                            Else
                                ' Verifico y actualizo las propiedades del grupo
                                GrupoOutlookActualizado = False

                                If .DLName <> String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, CursoActual.Nombre) Then
                                    .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, CursoActual.Nombre)
                                    GrupoOutlookActualizado = True
                                End If

                                If GrupoOutlookActualizado Then
                                    .Save()
                                End If
                            End If
                        Else
                            ' El IDCurso Especificado tiene un formato erroneo
                            .Delete()
                        End If
                        Continue For
                    End If

                    ' Es un Grupo que no depende del sistema, si está especificado, lo elimino
                    If radiobuttonGrupoContactosBorrar.Checked Then
                        .Delete()
                    End If
                End With
            Next
            Return True

        Catch ex As Exception
            otkContactUserProperty = Nothing

            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error verificando los Grupos de Contactos de Microsoft Outlook")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Verifica y actualiza las propiedades de un Grupo de Contactos en Outlook con el Tipo de Entidad en la Base de Datos
    ''' </summary>
    ''' <param name="otkDistListItem"></param>
    ''' <param name="listGruposDeTipoVerificadosEnOutlook"></param>
    ''' <param name="EntidadTipo"></param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SynchronizeWithOutlook_ContactsGroupsOfType(ByRef otkDistListItem As Outlook.DistListItem, ByRef listGruposDeTipoVerificadosEnOutlook As List(Of String), ByVal EntidadTipo As String) As Boolean
        Dim GrupoOutlookActualizado As Boolean

        Try
            listGruposDeTipoVerificadosEnOutlook.Add(EntidadTipo)

            ' Verifico y actualizo las propiedades del grupo
            GrupoOutlookActualizado = False

            With otkDistListItem
                If .DLName <> String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo)) Then
                    .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo))
                    GrupoOutlookActualizado = True
                End If

                If GrupoOutlookActualizado Then
                    .Save()
                End If
            End With
            Return True

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, String.Format("Error verificando el Grupo de Contactos ({0}) de Microsoft Outlook", EntidadTipoANombre(EntidadTipo)))
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Verifico los grupos de contactos de la base de datos para ver si hay que agregar alguno
    ''' </summary>
    ''' <param name="otkApp">Microsoft Outlook Application object</param>
    ''' <param name="dbContext">Database context object</param>
    ''' <param name="listGruposDeTipoVerificadosEnOutlook">Lista de IDs de Entidades verificadas en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SyncronizeWithOutlook_VerifyContactGroupsInDatabase(ByRef otkApp As Outlook.Application, ByRef dbContext As CSColegioContext, ByRef listGruposDeTipoVerificadosEnOutlook As List(Of String)) As Boolean
        Try
            If checkboxEntidadTipoPersonalColegio.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_PERSONALCOLEGIO) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_PERSONALCOLEGIO, dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoPersonalColegio)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoDocente.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_DOCENTE) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_DOCENTE, dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoDocente)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoAlumno.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_ALUMNO) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_ALUMNO, dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoAlumno)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoFamiliar.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_FAMILIAR) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_FAMILIAR, dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoFamiliar)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoProveedor.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_PROVEEDOR) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_PROVEEDOR, dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoProveedor)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoOtro.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_OTRO) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_OTRO, dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoOtro)) Then
                    Return False
                End If
            End If

            'For Each EntidadActual In dbContext.Entidad.Where(Function(e) e.TipoPersonalColegio)
            '    ' Verifico que no haya sido verificado en el paso anterior
            '    Dim index As Integer
            '    index = listEntidadesVerificadasEnOutlook.IndexOf(EntidadActual.IDEntidad)
            '    If index = -1 Then
            '        Dim newOutlookContact As Outlook.ContactItem

            '        newOutlookContact = CType(otkApp.CreateItem(Outlook.OlItemType.olContactItem), Outlook.ContactItem)
            '        If Not newOutlookContact Is Nothing Then
            '            With newOutlookContact
            '                .LastName = EntidadActual.Apellido
            '                .FirstName = EntidadActual.Nombre

            '                .Email1Address = EntidadActual.Email1
            '                If .Email1Address <> EntidadActual.Email1 Then
            '                    .Email1Address = EntidadActual.Email1
            '                    SynchronizeWithOutlook_Email1_SetDisplayName(newOutlookContact, EntidadActual)
            '                End If

            '                .Email2Address = EntidadActual.Email2
            '                If .Email2Address <> EntidadActual.Email2 Then
            '                    .Email2Address = EntidadActual.Email2
            '                    SynchronizeWithOutlook_Email2_SetDisplayName(newOutlookContact, EntidadActual)
            '                End If

            '                .UserProperties.Add(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD, Outlook.OlUserPropertyType.olInteger).Value = EntidadActual.IDEntidad

            '                .Save()
            '            End With
            '        End If
            '    End If
            'Next
            Return True

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error creando los Grupos de Contactos no existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Private Function SynchronizeWithOutlook_CreateContactGroupInOutlook(ByRef otkApp As Outlook.Application, ByVal EntidadTipo As String, ByRef qryEntidades As System.Linq.IQueryable(Of Entidad)) As Boolean
        Dim otkDistListItem As Outlook.DistListItem
        Dim otkRecipients As Outlook.Recipients = Nothing

        If Not SynchronizeWithOutlook_AddMembersToRecipientListInOutlook(otkApp, qryEntidades, otkRecipients) Then
            Return False
        End If

        Try
            otkDistListItem = CType(otkApp.CreateItem(Outlook.OlItemType.olDistributionListItem), Outlook.DistListItem)
            If Not otkDistListItem Is Nothing Then
                With otkDistListItem
                    .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo))
                    .AddMembers(otkRecipients)

                    .UserProperties.Add(OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO, Outlook.OlUserPropertyType.olText).Value = EntidadTipo

                    .Save()
                End With
            End If

            otkDistListItem = Nothing
            Return True

        Catch ex As Exception
            otkDistListItem = Nothing
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error creando el Grupo de Contactos no existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Private Function SynchronizeWithOutlook_AddMembersToRecipientListInOutlook(ByRef otkApp As Outlook.Application, ByRef qryEntidades As System.Linq.IQueryable(Of Entidad), ByRef otkRecipients As Outlook.Recipients) As Boolean
        Dim otkNameSpace As Outlook.NameSpace
        Dim otkContactsFolder As Outlook.MAPIFolder
        Dim otkContactsItems As Outlook.Items
        Dim otkMailItem As Outlook.MailItem

        Try
            otkNameSpace = otkApp.Session
            otkContactsFolder = otkNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
            otkContactsItems = otkContactsFolder.Items

            otkMailItem = CType(otkContactsItems.Add(Outlook.OlItemType.olMailItem), Outlook.MailItem)
            otkRecipients = otkMailItem.Recipients

            For Each EntidadActual In qryEntidades
                otkRecipients.Add(EntidadActual.ApellidoNombre)
            Next

            otkMailItem.Delete()
            otkMailItem = Nothing
            otkContactsItems = Nothing
            otkContactsFolder = Nothing
            otkNameSpace = Nothing

            Return otkRecipients.ResolveAll()

        Catch ex As Exception
            otkMailItem = Nothing
            otkContactsItems = Nothing
            otkContactsFolder = Nothing
            otkNameSpace = Nothing
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error al agregar los Contactos a el Grupo de Contactos en Microsoft Outlook.")
            Return False
        End Try
    End Function

#End Region

End Class