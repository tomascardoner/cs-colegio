Partial Public Class Entidad

#Region "Propiedades extendidas"

    Public ReadOnly Property DomicilioCalleCompleto() As String
        Get
            Dim DomicilioCompleto As String

            DomicilioCompleto = DomicilioCalle1
            If Not DomicilioCalle1 Is Nothing Then
                If Not DomicilioNumero Is Nothing Then
                    If DomicilioCalle1.TrimStart.ToUpper.StartsWith("RUTA ") Then
                        DomicilioCompleto &= " Km. " & DomicilioNumero
                    ElseIf DomicilioCalle1.TrimStart.ToUpper.StartsWith("CALLE ") Then
                        DomicilioCompleto &= " N° " & DomicilioNumero
                    ElseIf IsNumeric(DomicilioCalle1.Trim) Then
                        DomicilioCompleto = "Calle " & DomicilioCalle1.Trim & " N° " & DomicilioNumero
                    Else
                        DomicilioCompleto &= " " & DomicilioNumero
                    End If
                End If

                If Not DomicilioPiso Is Nothing Then
                    If IsNumeric(DomicilioPiso) Then
                        DomicilioCompleto &= " P." & DomicilioPiso & "°"
                    Else
                        DomicilioCompleto &= " " & DomicilioPiso
                    End If
                End If

                If Not DomicilioDepartamento Is Nothing Then
                    DomicilioCompleto &= " Dto. """ & DomicilioDepartamento & """"
                End If

                If Not DomicilioCalle2 Is Nothing Then
                    If Not DomicilioCalle3 Is Nothing Then
                        DomicilioCompleto &= " entre " & DomicilioCalle2 & " y " & DomicilioCalle3
                    Else
                        DomicilioCompleto &= " esq. " & DomicilioCalle2
                    End If
                End If
            End If

            Return DomicilioCompleto
        End Get
    End Property

#End Region

#Region "Verificaciones"

    Public Function VerificarEmail(ByVal MostrarMensaje As Boolean) As Boolean
        If CS_Parameter_System.GetBoolean(Parametros.ENTIDAD_VERIFICAR_EMAIL_AVISO) AndAlso MostrarMensaje Then
            If VerificarEmail1 And VerificarEmail2 Then
                MsgBox("Se deben verificar las dos direcciones de e-Mail de esta Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            ElseIf VerificarEmail1 Then
                MsgBox("Se debe verificar la dirección de e-Mail 1 de esta Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            ElseIf VerificarEmail2 Then
                MsgBox("Se debe verificar la dirección de e-Mail 2 de esta Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            End If
        End If

        Return VerificarEmail1 Or VerificarEmail2
    End Function

    Private Sub VerificarDatosCompletosParaEmitirComprobante(ByVal sujetoDescripcion As String, ByRef correccionDescripcion As String)
        If IDCategoriaIVA Is Nothing Then
            correccionDescripcion &= String.Format("{1} no tiene especificada la Categoría de IVA.{0}", vbCrLf, sujetoDescripcion)
        End If

        If DocumentoNumero Is Nothing And FacturaDocumentoNumero Is Nothing Then
            correccionDescripcion &= String.Format("{1} no tiene especificado el Tipo y Número de Documento.{0}", vbCrLf, sujetoDescripcion)
        End If

        If pComprobanteConfig.RequiereDomicilioCompleto Then
            If DomicilioCalle1 Is Nothing Then
                correccionDescripcion &= String.Format("{1} no tiene especificado el Domicilio.{0}", vbCrLf, sujetoDescripcion)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifica que una Entidad tenga todos los datos correctos para emitirle un Comprobante
    ''' </summary>
    ''' <param name="anioLectivo">Año Lectivo</param>
    ''' <param name="fechaServicioDesde">Fecha de Inicio del Servicio a Facturar</param>
    ''' <param name="fechaServicioHasta">Fecha de Fin del Servicio a Facturar</param>
    ''' <param name="fechaExclusionEsError">Especifica si cuando la Entidad tiene exclusión de facturación, se genera error o simplemente se devuelve False</param>
    ''' <param name="correccionDescripcion">Por medio de este parámetro, se devuelve la leyenda de los errores encontrados</param>
    ''' <returns>Devuelve True si la Entidad tiene todos los datos correctos para facturar o False si no</returns>
    ''' <remarks></remarks>
    Public Function VerificarParaEmitirComprobante(ByVal anioLectivo As Integer, ByVal agregarAlCurso As Boolean, ByVal fechaServicioDesde As Date, ByVal fechaServicioHasta As Date, ByVal fechaExclusionEsError As Boolean, ByRef correccionDescripcion As String) As Boolean
        ' El primer paso es verificar que la Entidad especificada, sea de tipo Alumno
        If TipoAlumno = False Then
            correccionDescripcion &= "No es una Entidad del tipo Alumno." & vbCrLf
        End If

        If agregarAlCurso Then
            ' Verifico que el Alumno no esté cargado en algún Curso para el mismo Año Lectivo
            If AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = anioLectivo).Count > 0 Then
                correccionDescripcion &= "El Alumno ya está cargado en un curso para el Año Lectivo que se va a facturar." & vbCrLf
            End If
        Else
            ' Verifico que el Alumno no esté cargado en más de un Curso para el mismo Año Lectivo
            If AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = anioLectivo).Count > 1 Then
                correccionDescripcion &= "El Alumno está cargado en más de un curso para el Año Lectivo que se va a facturar." & vbCrLf
            End If
        End If

        ' Verifico a quién se le va a Facturar
        If EmitirFacturaA Is Nothing Then
            correccionDescripcion &= "No está especificado a quién se le factura." & vbCrLf
        Else
            If EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO Then
                ' Se le factura al Alumno, verifico que tenga los datos completos
                VerificarDatosCompletosParaEmitirComprobante("El Alumno", correccionDescripcion)
            End If

            If EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura al Padre (entre otros)
                If IDEntidadPadre Is Nothing Then
                    correccionDescripcion &= "Debe especificar el Padre para poder facturarle." & vbCrLf
                Else
                    EntidadPadre.VerificarDatosCompletosParaEmitirComprobante("El Padre", correccionDescripcion)
                End If
            End If

            If EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura a la Madre (entre otros)
                If IDEntidadMadre Is Nothing Then
                    correccionDescripcion &= "Debe especificar la Madre para poder facturarle." & vbCrLf
                Else
                    EntidadMadre.VerificarDatosCompletosParaEmitirComprobante("La Madre", correccionDescripcion)
                End If
            End If

            If EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura a Otro (entre otros)
                If IDEntidadTercero Is Nothing Then
                    correccionDescripcion &= "Debe especificar el Tercero para poder facturarle." & vbCrLf
                Else
                    EntidadTercero.VerificarDatosCompletosParaEmitirComprobante("El tercero a quien se le va a facturar", correccionDescripcion)
                End If
            End If
        End If

        ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
        If correccionDescripcion.Length > 0 Then
            correccionDescripcion = correccionDescripcion.Remove(correccionDescripcion.Length - vbCrLf.Length)
            Return False
        Else
            ' La Entidad está verificada, pero  falta verificar que no tenga exclusión de facturación
            ' Verifico primero la exclusión Desde
            If Not ExcluyeFacturaDesde Is Nothing Then
                ' Especifica exclusión Desde, así que la verifico
                If ExcluyeFacturaDesde.Value.CompareTo(fechaServicioHasta) < 0 Then
                    ' Está dentro de la exclusión Desde, así que verifico la exclusión Hasta
                    If ExcluyeFacturaHasta Is Nothing Then
                        ' No especifica exclusión Hasta, por ende, no se debe incluir en la Facturación
                        If fechaExclusionEsError Then
                            correccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                            Return False
                        Else
                            correccionDescripcion = ""
                            Return False
                        End If
                    ElseIf ExcluyeFacturaHasta.Value.CompareTo(fechaServicioDesde) > 0 Then
                        ' Está dentro de la exclusión Hasta, por lo tanto, se excluye
                        If fechaExclusionEsError Then
                            correccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                            Return False
                        Else
                            correccionDescripcion = ""
                            Return False
                        End If
                    Else
                        ' Está fuera de la exclusión
                        Return True
                    End If
                Else
                    ' Está fuera de la exclusión
                    Return True
                End If
            ElseIf Not ExcluyeFacturaHasta Is Nothing Then
                ' Especifica exclusión Hasta, así que la verifico
                If ExcluyeFacturaHasta.Value.CompareTo(fechaServicioDesde) > 0 Then
                    ' Está dentro de la exclusión, así que no lo agrego a la lista
                    If fechaExclusionEsError Then
                        correccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                        Return False
                    Else
                        correccionDescripcion = ""
                        Return False
                    End If
                Else
                    ' Está fuera de la exclusión
                    Return True
                End If
            Else
                ' No especifica ninguna exclusión
                Return True
            End If
        End If
    End Function

#End Region

End Class