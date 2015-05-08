Public Class formLogin
    Private Intentos As Byte = 0

    Private Sub formLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.ShowLastUserLoggedIn Then
            If My.Settings.LastUserLoggedIn <> "" Then
                textboxNombre.Text = My.Settings.LastUserLoggedIn
                labelPassword.TabIndex = 0
                textboxPassword.TabIndex = 1
                labelNombre.TabIndex = 6
                textboxNombre.TabIndex = 7
            End If
        End If
    End Sub

    Private Sub textboxNombre_GotFocus(sender As Object, e As EventArgs) Handles textboxNombre.GotFocus
        textboxNombre.SelectAll()
    End Sub

    Private Sub textboxPassword_GotFocus(sender As Object, e As EventArgs) Handles textboxPassword.GotFocus
        textboxPassword.SelectAll()
    End Sub

    Private Sub buttonAceptar_Click(sender As Object, e As EventArgs) Handles buttonAceptar.Click
        textboxNombre.Text.Trim()

        If textboxNombre.TextLength = 0 Then
            MsgBox("Debe ingresar el Nombre del Usuario.", vbInformation, My.Application.Info.Title)
            textboxNombre.Focus()
            Exit Sub
        End If

        If textboxNombre.TextLength < 4 Then
            MsgBox("El Nombre del Usuario debe contener al menos 4 carcateres.", vbInformation, My.Application.Info.Title)
            textboxNombre.Focus()
            Exit Sub
        End If

        If textboxPassword.TextLength = 0 Then
            MsgBox("Debe ingresar la Contraseña.", vbInformation, My.Application.Info.Title)
            textboxPassword.Focus()
            Exit Sub
        End If
        If My.Settings.UserPasswordSecureRequired Then
            If textboxPassword.TextLength < My.Settings.UserPasswordMinimumLenght Then
                MsgBox(String.Format("La Contraseña debe contener al menos {0} caracteres.", My.Settings.UserPasswordMinimumLenght), vbInformation, My.Application.Info.Title)
                textboxPassword.Focus()
                Exit Sub
            End If
        Else
            If textboxPassword.TextLength < 4 Then
                MsgBox("La Contraseña debe contener al menos 4 caracteres.", vbInformation, My.Application.Info.Title)
                textboxPassword.Focus()
                Exit Sub
            End If
        End If

        ' Está todo OK, busco el Usuario en la Base de Datos
        Me.Cursor = Cursors.WaitCursor

        Using dbContext As New CSColegioContext
            Dim qryUsuarios = From u In dbContext.Usuario
                    Where u.Nombre = textboxNombre.Text
                    Select u

            Dim UsuarioCurrent As Usuario = qryUsuarios.SingleOrDefault()

            If UsuarioCurrent Is Nothing Then
                My.Application.Log.WriteEntry(String.Format("Se intentó iniciar sesión con el Usuario '{0}', pero es inexistente.", pUsuario.Nombre), TraceEventType.Warning)
                MsgBox("El Nombre de Usuario ingresado no existe.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                textboxNombre.SelectAll()
                textboxNombre.Focus()
                UsuarioCurrent = Nothing
                qryUsuarios = Nothing
                Me.Cursor = Cursors.Default
                Intentos = Intentos + CByte(1)
                If Intentos > 3 Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If
                Exit Sub
            End If
            If String.Compare(textboxPassword.Text, UsuarioCurrent.Password, False) <> 0 Then
                My.Application.Log.WriteEntry(String.Format("Se intentó iniciar sesión con el Usuario '{0}', pero la Contraseña es incorrecta.", pUsuario.Nombre), TraceEventType.Warning)
                MsgBox("La Contraseña ingresada es incorrecta.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                textboxPassword.SelectAll()
                textboxPassword.Focus()
                UsuarioCurrent = Nothing
                qryUsuarios = Nothing
                Me.Cursor = Cursors.Default
                Intentos = Intentos + CByte(1)
                If Intentos > 3 Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                End If
                Exit Sub
            End If

            pUsuario = UsuarioCurrent
            UsuarioCurrent = Nothing
            qryUsuarios = Nothing
        End Using

        ' Guardo el Nombre de Usuario para mostrarlo la próxima vez
        My.Settings.LastUserLoggedIn = textboxNombre.Text
        My.Settings.Save()

        ' Muestro los datos del Usuario en el Status del form principal
        If pUsuario.Genero = GENERO_MASCULINO Then
            formMDIMain.labelUsuarioNombre.Image = My.Resources.IMAGE_USUARIO_HOMBRE_16
        ElseIf pUsuario.Genero = GENERO_FEMENINO Then
            formMDIMain.labelUsuarioNombre.Image = My.Resources.IMAGE_USUARIO_MUJER_16
        Else
            formMDIMain.labelUsuarioNombre.Image = Nothing
        End If
        formMDIMain.labelUsuarioNombre.Text = pUsuario.Descripcion

        My.Application.Log.WriteEntry(String.Format("El Usuario '{0}' ha iniciado sesión.", pUsuario.Nombre), TraceEventType.Information)

        Me.Cursor = Cursors.Default

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class