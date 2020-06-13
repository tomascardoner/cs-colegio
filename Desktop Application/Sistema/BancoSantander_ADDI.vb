Module BancoSantander_ADDI
    Friend Function GetConnectionString() As String
        Dim DatabaseObject As New CardonerSistemas.Database.ADO.SQLServer

        With DatabaseObject
            .ApplicationName = My.Application.Info.Title
            .Datasource = pSantanderConfig.Datasource
            .InitialCatalog = pSantanderConfig.AddiDatabase
            .UserId = pSantanderConfig.UserId
            ' Desencripto la contraseña de la conexión a la base de datos que está en el archivo app.config
            Dim PasswordDecrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PUBLIC_ENCRYPTION_PASSWORD)
            Dim DecrytedPassword As String = ""
            If PasswordDecrypter.Decrypt(pSantanderConfig.Password, DecrytedPassword) Then
                .Password = DecrytedPassword
            Else
                MsgBox("La contraseña de conexión al sistema ADDI es incorrecta.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                .Password = ""
            End If
            PasswordDecrypter = Nothing
            .MultipleActiveResultsets = True
            .WorkstationID = My.Computer.Name
            .CreateConnectionString()
            Return .ConnectionString
        End With
    End Function

    Friend Function Adhesion_Get(ByRef sqlconn As SqlClient.SqlConnection, ByVal IDEntidad As Integer) As SqlClient.SqlDataReader
        Try
            Dim sqlcmd As New SqlClient.SqlCommand
            Dim sqldatrdr As SqlClient.SqlDataReader

            With sqlcmd
                .Connection = sqlconn
                .CommandText = "qryAdhesion_BuscarXPartida"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@CodEmpresa", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOEMPRESA))
                .Parameters.AddWithValue("@CodServicio", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO))
                .Parameters.AddWithValue("@Partida", IDEntidad.ToString(StrDup(CS_Parameter_System.GetIntegerAsInteger(Parametros.BANCOSANTANDER_ADDI_CODIGOCLIENTE_LONGITUD), "0"c)))
            End With

            sqldatrdr = sqlcmd.ExecuteReader()
            Return sqldatrdr

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la Adhesión en el sistema ADDI del Banco Santander Río.")
            Return Nothing
        End Try
    End Function

    Friend Function Adhesion_AltaModificacion(ByRef sqlconn As SqlClient.SqlConnection, ByVal AdhesionId As Integer, ByVal IDEntidad As Integer, ByVal CBU As String, ByVal Status As String) As Boolean
        Try
            Dim sqlcmd As New SqlClient.SqlCommand

            With sqlcmd
                .Connection = sqlconn
                .CommandText = "qryAdhesion_Insert"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@AdhesionId", AdhesionId)
                .Parameters.AddWithValue("@CodEmpresa", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOEMPRESA))
                .Parameters.AddWithValue("@CodServicio", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO))
                .Parameters.AddWithValue("@Partida", IDEntidad.ToString(StrDup(CS_Parameter_System.GetIntegerAsInteger(Parametros.BANCOSANTANDER_ADDI_CODIGOCLIENTE_LONGITUD), "0"c)))
                .Parameters.AddWithValue("@CBU", CBU)
                .Parameters.AddWithValue("@NombreAdherente", "")
                .Parameters.AddWithValue("@FechaPresentacion", DBNull.Value)
                .Parameters.AddWithValue("@UsuarioAlta", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_USUARIO))
                .Parameters.AddWithValue("@Status", IIf(AdhesionId = 0, "", Status))
                .Parameters.AddWithValue("@DiaDebito", DBNull.Value)
                .Parameters.AddWithValue("@FechaVigencia", DBNull.Value)
                .Parameters.AddWithValue("@Tipo", IIf(AdhesionId = 0, "A", "M"))
                .Parameters.AddWithValue("@ReferenciaEmpresa", "")

                .ExecuteNonQuery()
            End With
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al actualizar el CBU de la Adhesión en el sistema ADDI del Banco Santander Río.")
            Return False
        End Try
    End Function

    Friend Function Adhesion_ActualizarCBU(ByRef sqlconn As SqlClient.SqlConnection, ByVal AdhesionId As Integer, ByVal CBU As String, ByVal LoteImportacion As Integer) As Boolean
        Try
            Dim sqlcmd As New SqlClient.SqlCommand

            With sqlcmd
                .Connection = sqlconn
                .CommandText = "qryAdhesion_ModificarCBU"
                .CommandType = CommandType.StoredProcedure
                .Parameters.AddWithValue("@AdhesionId", AdhesionId)
                .Parameters.AddWithValue("@CBU", CBU)
                .Parameters.AddWithValue("@Usuario", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_USUARIO))
                .Parameters.AddWithValue("@LoteImportacion", LoteImportacion)
                .ExecuteNonQuery()
            End With
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al actualizar el CBU de la Adhesión en el sistema ADDI del Banco Santander Río.")
            Return False
        End Try
    End Function

    Friend Function Adhesion_Baja(ByRef sqlconn As SqlClient.SqlConnection, ByVal AdhesionId As Integer, ByVal Status As String) As Boolean
        Try
            Dim sqlcmd As New SqlClient.SqlCommand

            With sqlcmd
                .Connection = sqlconn
                If Status = "0" Then
                    ' La Adhesión no se envía al banco, así que directamente la borro
                    .CommandText = "qryAdhesion_Delete"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@AdhesionId", AdhesionId)
                    .ExecuteNonQuery()
                Else
                    ' La Adhesión ya fue enviada al Banco, así que pido la baja
                    .CommandText = "qryAdhesion_Baja"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.AddWithValue("@AdhesionId", AdhesionId)
                    .Parameters.AddWithValue("@Usuario", CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_USUARIO))
                    .Parameters.AddWithValue("@LoteImportacion", DBNull.Value)
                    .ExecuteNonQuery()
                End If
            End With
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al dar de baja la Adhesión en el sistema ADDI del Banco Santander Río.")
            Return False
        End Try
    End Function

End Module
