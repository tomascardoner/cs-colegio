Module ModuloComprobantes
    Friend Class Alumno_AnioLectivoCurso_AFacturar
        Friend Property Alumno As Entidad
        Friend Property AnioLectivoCurso_AFacturar As AnioLectivoCurso
    End Class

    ''' <summary>
    ''' Verifica que una Entidad tenga todos los datos correctos para emitirle un Comprobante
    ''' </summary>
    ''' <param name="EntidadAVerificar">Especifica la Entidad a Verificar</param>
    ''' <param name="AnioLectivo">Año Lectivo</param>
    ''' <param name="FechaServicioDesde">Fecha de Inicio del Servicio a Facturar</param>
    ''' <param name="FechaServicioHasta">Fecha de Fin del Servicio a Facturar</param>
    ''' <param name="FechaExclusionEsError">Especifica si cuando la Entidad tiene exclusión de facturación, se genera error o simplemente se devuelve False</param>
    ''' <param name="CorreccionDescripcion">Por medio de este parámetro, se devuelve la leyenda de los errores encontrados</param>
    ''' <returns>Devuelve True si la Entidad tiene todos los datos correctos para facturar o False si no</returns>
    ''' <remarks></remarks>
    Friend Function Entidad_VerificarParaEmitirComprobante(ByRef EntidadAVerificar As Entidad, ByVal AnioLectivo As Integer, ByVal AgregarAlCurso As Boolean, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal FechaExclusionEsError As Boolean, ByRef CorreccionDescripcion As String) As Boolean
        ' El primer paso es verificar que la Entidad especificada, sea de tipo Alumno
        If EntidadAVerificar.TipoAlumno = False Then
            CorreccionDescripcion &= "No es una Entidad del tipo Alumno." & vbCrLf
        End If

        If AgregarAlCurso Then
            ' Verifico que el Alumno no esté cargado en algún Curso para el mismo Año Lectivo
            If EntidadAVerificar.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 0 Then
                CorreccionDescripcion &= "El Alumno ya está cargado en un curso para el Año Lectivo que se va a facturar." & vbCrLf
            End If
        Else
            ' Verifico que el Alumno no esté cargado en más de un Curso para el mismo Año Lectivo
            If EntidadAVerificar.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 1 Then
                CorreccionDescripcion &= "El Alumno está cargado en más de un curso para el Año Lectivo que se va a facturar." & vbCrLf
            End If
        End If

        ' Verifico a quién se le va a Facturar
        If EntidadAVerificar.EmitirFacturaA Is Nothing Then
            CorreccionDescripcion &= "No está especificado a quién se le factura." & vbCrLf
        Else
            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO Then
                ' Se le factura al Alumno, verifico que tenga los datos completos
                Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar, "El Alumno", CorreccionDescripcion)
            End If

            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura al Padre (entre otros)
                If EntidadAVerificar.IDEntidadPadre Is Nothing Then
                    CorreccionDescripcion &= "Debe especificar el Padre para poder facturarle." & vbCrLf
                Else
                    Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar.EntidadPadre, "El Padre", CorreccionDescripcion)
                End If
            End If

            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura a la Madre (entre otros)
                If EntidadAVerificar.IDEntidadMadre Is Nothing Then
                    CorreccionDescripcion &= "Debe especificar la Madre para poder facturarle." & vbCrLf
                Else
                    Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar.EntidadMadre, "La Madre", CorreccionDescripcion)
                End If
            End If

            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura a Otro (entre otros)
                If EntidadAVerificar.IDEntidadTercero Is Nothing Then
                    CorreccionDescripcion &= "Debe especificar el Tercero para poder facturarle." & vbCrLf
                Else
                    Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar.EntidadTercero, "El tercero a quien se le va a facturar", CorreccionDescripcion)
                End If
            End If
        End If

        ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
        If CorreccionDescripcion.Length > 0 Then
            CorreccionDescripcion = CorreccionDescripcion.Remove(CorreccionDescripcion.Length - vbCrLf.Length)
            Return False
        Else
            ' La Entidad está verificada, pero  falta verificar que no tenga exclusión de facturación
            ' Verifico primero la exclusión Desde
            If Not EntidadAVerificar.ExcluyeFacturaDesde Is Nothing Then
                ' Especifica exclusión Desde, así que la verifico
                If EntidadAVerificar.ExcluyeFacturaDesde.Value.CompareTo(FechaServicioHasta) < 0 Then
                    ' Está dentro de la exclusión Desde, así que verifico la exclusión Hasta
                    If EntidadAVerificar.ExcluyeFacturaHasta Is Nothing Then
                        ' No especifica exclusión Hasta, por ende, no se debe incluir en la Facturación
                        If FechaExclusionEsError Then
                            CorreccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                            Return False
                        Else
                            CorreccionDescripcion = ""
                            Return False
                        End If
                    ElseIf EntidadAVerificar.ExcluyeFacturaHasta.Value.CompareTo(FechaServicioDesde) > 0 Then
                        ' Está dentro de la exclusión Hasta, por lo tanto, se excluye
                        If FechaExclusionEsError Then
                            CorreccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                            Return False
                        Else
                            CorreccionDescripcion = ""
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
            ElseIf Not EntidadAVerificar.ExcluyeFacturaHasta Is Nothing Then
                ' Especifica exclusión Hasta, así que la verifico
                If EntidadAVerificar.ExcluyeFacturaHasta.Value.CompareTo(FechaServicioDesde) > 0 Then
                    ' Está dentro de la exclusión, así que no lo agrego a la lista
                    If FechaExclusionEsError Then
                        CorreccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                        Return False
                    Else
                        CorreccionDescripcion = ""
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

    Private Sub Entidad_VerificarDatosCompletosParaEmitirComprobante(ByRef EntidadAVerificar As Entidad, ByVal SujetoDescripcion As String, ByRef CorreccionDescripcion As String)
        If EntidadAVerificar.IDCategoriaIVA Is Nothing Then
            CorreccionDescripcion &= String.Format("{1} no tiene especificada la Categoría de IVA.{0}", vbCrLf, SujetoDescripcion)
        End If

        If EntidadAVerificar.DocumentoNumero Is Nothing And EntidadAVerificar.FacturaDocumentoNumero Is Nothing Then
            CorreccionDescripcion &= String.Format("{1} no tiene especificado el Tipo y Número de Documento.{0}", vbCrLf, SujetoDescripcion)
        End If

        If pComprobanteConfig.RequiereDomicilioCompleto Then
            If EntidadAVerificar.DomicilioCalle1 Is Nothing Then
                CorreccionDescripcion &= String.Format("{1} no tiene especificado el Domicilio.{0}", vbCrLf, SujetoDescripcion)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Genera una serie de Comprobantes (Facturas)
    ''' </summary>
    ''' <param name="listComprobantes">Objeto List de Comprobantes a Generar.</param>
    ''' <param name="IDComprobanteLote">ID del Lote a generar. 0 (cero) si no especifica Lote.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GenerarComprobantes(ByVal FechaEmision As Date, ByVal FechaVencimiento1 As Date, ByVal FechaVencimiento2 As Date, ByVal FechaVencimiento3 As Date, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal IDConcepto As Byte, ByVal IDComprobanteLote As Integer, ByVal AnioLectivoAFacturar As Short, ByVal MesAFacturar As Byte, ByVal MuestraErrores As Boolean, ByRef listAlumno_AnioLectivoCurso_AFacturar As List(Of Alumno_AnioLectivoCurso_AFacturar), ByRef listComprobantes As List(Of Comprobante)) As Boolean
        ' Parámetros
        Dim ArticuloActual As Articulo
        Dim ComprobanteEntidadMayusculas As Boolean

        ' Datos de la Factura
        Dim NextID As Integer
        Dim ComprobanteTipo As New ComprobanteTipo
        Dim ComprobanteTipoPuntoVenta As ComprobanteTipoPuntoVenta
        Dim PuntoVenta As New PuntoVenta
        Dim NextComprobanteNumero As String = ""

        Dim AlumnoActual As Entidad
        Dim AnioLectivoCursoActual As AnioLectivoCurso
        Dim TitularComprobante As Entidad

        Dim InteresTasaNominalAnual As Decimal
        Dim InteresRedondeo As Short
        Dim Vencimiento2PorcentajeInteres As Decimal
        Dim Vencimiento3PorcentajeInteres As Decimal

        Using dbContext As New CSColegioContext(True)

            ' Cargo los parámetros en variables para reducir tiempo de procesamiento
            If MesAFacturar = 0 Then
                ArticuloActual = dbContext.Articulo.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MATRICULA_ARTICULO_ID))
            Else
                ArticuloActual = dbContext.Articulo.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID))
            End If
            ComprobanteEntidadMayusculas = CS_Parameter_System.GetBoolean(Parametros.COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value

            ' Calculo las Fechas de Vencimiento y los intereses
            InteresTasaNominalAnual = CS_Parameter_System.GetDecimal(Parametros.INTERES_TASA_NOMINAL_ANUAL)
            If InteresTasaNominalAnual > 0 Then
                InteresRedondeo = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_VENCIMIENTO_INTERES_REDONDEO)
                Vencimiento2PorcentajeInteres = Math.Round(InteresTasaNominalAnual / 365 * DateAndTime.DateDiff(DateInterval.Day, FechaVencimiento1, FechaVencimiento2), 2, MidpointRounding.AwayFromZero)
                Vencimiento3PorcentajeInteres = Math.Round(InteresTasaNominalAnual / 365 * DateAndTime.DateDiff(DateInterval.Day, FechaVencimiento1, FechaVencimiento3), 2, MidpointRounding.AwayFromZero)
            End If

            For Each Alumno_AnioLectivoCurso_AFacturarActual As Alumno_AnioLectivoCurso_AFacturar In listAlumno_AnioLectivoCurso_AFacturar
                AlumnoActual = Alumno_AnioLectivoCurso_AFacturarActual.Alumno
                AnioLectivoCursoActual = Alumno_AnioLectivoCurso_AFacturarActual.AnioLectivoCurso_AFacturar

                '//////////////////////////////////////////////////////
                ' FACTURAR AL ALUMNO
                '//////////////////////////////////////////////////////
                If AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO Then
                    TitularComprobante = AlumnoActual
                    If Not GenerarComprobante(dbContext, listComprobantes, FechaEmision, InteresRedondeo, FechaVencimiento1, FechaVencimiento2, Vencimiento2PorcentajeInteres, FechaVencimiento3, Vencimiento3PorcentajeInteres, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, ComprobanteEntidadMayusculas, AlumnoActual, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores) Then
                        Return False
                    End If
                End If

                '//////////////////////////////////////////////////////
                ' FACTURAR AL PADRE
                '//////////////////////////////////////////////////////
                If AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                    TitularComprobante = AlumnoActual.EntidadPadre
                    If Not GenerarComprobante(dbContext, listComprobantes, FechaEmision, InteresRedondeo, FechaVencimiento1, FechaVencimiento2, Vencimiento2PorcentajeInteres, FechaVencimiento3, Vencimiento3PorcentajeInteres, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, ComprobanteEntidadMayusculas, AlumnoActual, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores) Then
                        Return False
                    End If
                End If

                '//////////////////////////////////////////////////////
                ' FACTURAR A LA MADRE
                '//////////////////////////////////////////////////////
                If AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                    TitularComprobante = AlumnoActual.EntidadMadre
                    If Not GenerarComprobante(dbContext, listComprobantes, FechaEmision, InteresRedondeo, FechaVencimiento1, FechaVencimiento2, Vencimiento2PorcentajeInteres, FechaVencimiento3, Vencimiento3PorcentajeInteres, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, ComprobanteEntidadMayusculas, AlumnoActual, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores) Then
                        Return False
                    End If
                End If

                '//////////////////////////////////////////////////////
                ' FACTURAR A UN TERCERO
                '//////////////////////////////////////////////////////
                If AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or AlumnoActual.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                    TitularComprobante = AlumnoActual.EntidadTercero
                    If Not GenerarComprobante(dbContext, listComprobantes, FechaEmision, InteresRedondeo, FechaVencimiento1, FechaVencimiento2, Vencimiento2PorcentajeInteres, FechaVencimiento3, Vencimiento3PorcentajeInteres, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, ComprobanteEntidadMayusculas, AlumnoActual, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores) Then
                        Return False
                    End If
                End If
            Next

            ' Ordeno la lista de Facturas por Tipo de Comprobante
            listComprobantes.OrderBy(Function(cc) cc.IDComprobanteTipo)

            ' Obtengo el ID del último Comprobante cargado
            If dbContext.Comprobante.Count = 0 Then
                NextID = 0
            Else
                NextID = (From c In dbContext.Comprobante Select c.IDComprobante).Max
            End If

            ' Recorro todas las Facturas generadas para aplicarles los ID y los Números de Comprobante
            For Each FacturaCabeceraActual As Comprobante In listComprobantes
                With FacturaCabeceraActual
                    NextID += 1
                    .IDComprobante = NextID
                    If ComprobanteTipo.IDComprobanteTipo <> .IDComprobanteTipo Then
                        ComprobanteTipo = dbContext.ComprobanteTipo.Find(.IDComprobanteTipo)
                        ComprobanteTipoPuntoVenta = ComprobanteTipo.ComprobanteTipoPuntoVenta.Where(Function(ctpv) ctpv.IDPuntoVenta = pGeneralConfig.IdPuntoVenta).FirstOrDefault
                        If ComprobanteTipoPuntoVenta Is Nothing Then
                            Exit For
                        End If
                        PuntoVenta = ComprobanteTipoPuntoVenta.PuntoVenta

                        ' Busco si ya hay un comprobante creado de este tipo para obtener el último número
                        NextComprobanteNumero = dbContext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = .IDComprobanteTipo And cc.PuntoVenta = PuntoVenta.Numero).Max(Function(cc) cc.Numero)
                        If NextComprobanteNumero Is Nothing Then
                            ' No hay ningún comprobante creado de este tipo, así que tomo el número inicial y le resto 1 porque después se lo sumo
                            NextComprobanteNumero = CStr(CInt(ComprobanteTipoPuntoVenta.NumeroInicio) - 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                        End If
                    End If
                    NextComprobanteNumero = CStr(CInt(NextComprobanteNumero) + 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                    .PuntoVenta = PuntoVenta.Numero
                    .Numero = NextComprobanteNumero
                End With
            Next

        End Using

        Return True
    End Function

    Private Function GenerarComprobante(ByRef dbContext As CSColegioContext, ByRef listComprobantes As List(Of Comprobante), ByVal FechaEmision As Date, ByVal InteresRedondeo As Short, ByVal FechaVencimiento1 As Date, ByVal FechaVencimiento2 As Date, ByVal Vencimiento2PorcentajeInteres As Decimal, ByVal FechaVencimiento3 As Date, ByVal Vencimiento3PorcentajeInteres As Decimal, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal IDConcepto As Byte, ByVal IDComprobanteLote As Integer, ByVal TitularComprobante As Entidad, ByVal TitularComprobanteMayusculas As Boolean, ByVal Alumno As Entidad, ByVal AnioLectivoCursoActual As AnioLectivoCurso, ByVal ArticuloActual As Articulo, ByVal AnioLectivoAFacturar As Short, ByVal MesAFacturar As Byte, ByVal MuestraErrores As Boolean) As Boolean
        Dim ComprobanteCabecera As Comprobante
        Dim ComprobanteDetalleActual As ComprobanteDetalle


        Dim Vencimiento2Importe As Decimal
        Dim Vencimiento3Importe As Decimal

        If Alumno.FacturaIndividual Then
            ' El Alumno especifica que se le facture individualmente
            ComprobanteCabecera = GenerarComprobanteCabecera(FechaEmision, FechaVencimiento1, FechaVencimiento2, FechaVencimiento3, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, Alumno.FacturaLeyenda, TitularComprobanteMayusculas)
            ComprobanteDetalleActual = GenerarComprobanteDetalle(ComprobanteCabecera, Alumno, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores)
            If ComprobanteDetalleActual Is Nothing Then
                Return False
            End If
            ComprobanteCabecera.ImporteSubtotal = ComprobanteDetalleActual.PrecioTotal
            ComprobanteCabecera.ImporteImpuesto = 0
            ComprobanteCabecera.ImporteTotal1 = ComprobanteCabecera.ImporteSubtotal

            listComprobantes.Add(ComprobanteCabecera)
        Else
            ' Busco si existe un Comprobante de esta Entidad Titular en la lista de Comprobantes (por otro Alumno)
            ComprobanteCabecera = listComprobantes.Find(Function(fc) fc.IDEntidad = TitularComprobante.IDEntidad)
            If ComprobanteCabecera Is Nothing Then
                ' No existe la Factura, la creo.
                ComprobanteCabecera = GenerarComprobanteCabecera(FechaEmision, FechaVencimiento1, FechaVencimiento2, FechaVencimiento3, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, Alumno.FacturaLeyenda, TitularComprobanteMayusculas)
                ComprobanteDetalleActual = GenerarComprobanteDetalle(ComprobanteCabecera, Alumno, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores)
                If ComprobanteDetalleActual Is Nothing Then
                    Return False
                End If
                ComprobanteCabecera.ImporteSubtotal = ComprobanteDetalleActual.PrecioTotal
                ComprobanteCabecera.ImporteImpuesto = 0
                ComprobanteCabecera.ImporteTotal1 = ComprobanteCabecera.ImporteSubtotal
                listComprobantes.Add(ComprobanteCabecera)
            Else
                ' Ya existe un Comprobante de ese Titular
                If dbContext.Entidad.Find(ComprobanteCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                    ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                    ComprobanteCabecera = GenerarComprobanteCabecera(FechaEmision, FechaVencimiento1, FechaVencimiento2, FechaVencimiento3, FechaServicioDesde, FechaServicioHasta, IDConcepto, IDComprobanteLote, TitularComprobante, Alumno.FacturaLeyenda, TitularComprobanteMayusculas)
                    ComprobanteDetalleActual = GenerarComprobanteDetalle(ComprobanteCabecera, Alumno, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores)
                    If ComprobanteDetalleActual Is Nothing Then
                        Return False
                    End If
                    ComprobanteCabecera.ImporteSubtotal = ComprobanteDetalleActual.PrecioTotal
                    ComprobanteCabecera.ImporteImpuesto = 0
                    ComprobanteCabecera.ImporteTotal1 = ComprobanteCabecera.ImporteSubtotal
                    listComprobantes.Add(ComprobanteCabecera)
                Else
                    ' No hay restricciones, así que sólo agrego un item al Detalle
                    ComprobanteDetalleActual = GenerarComprobanteDetalle(ComprobanteCabecera, Alumno, AnioLectivoCursoActual, ArticuloActual, AnioLectivoAFacturar, MesAFacturar, MuestraErrores)
                    If ComprobanteDetalleActual Is Nothing Then
                        Return False
                    End If
                    If Not Alumno.FacturaLeyenda Is Nothing Then
                        If ComprobanteCabecera.Leyenda Is Nothing Then
                            ComprobanteCabecera.Leyenda = Alumno.FacturaLeyenda
                        Else
                            ComprobanteCabecera.Leyenda &= vbCrLf & Alumno.FacturaLeyenda
                        End If
                    End If
                    ComprobanteCabecera.ImporteSubtotal += ComprobanteDetalleActual.PrecioTotal
                    ComprobanteCabecera.ImporteImpuesto = 0
                    ComprobanteCabecera.ImporteTotal1 = ComprobanteCabecera.ImporteSubtotal
                End If
            End If
        End If

        ' Calculo los intereses para los siguientes vencimientos
        If Vencimiento2PorcentajeInteres > 0 Then
            Vencimiento2Importe = ComprobanteCabecera.ImporteTotal1 + (ComprobanteCabecera.ImporteTotal1 * Vencimiento2PorcentajeInteres / 100)
            If InteresRedondeo > 0 Then
                Vencimiento2Importe = Math.Round(Vencimiento2Importe / InteresRedondeo, 0, MidpointRounding.AwayFromZero) * InteresRedondeo
            End If
        Else
            Vencimiento2Importe = 0
        End If
        ComprobanteCabecera.ImporteTotal2 = Vencimiento2Importe

        If Vencimiento3PorcentajeInteres > 0 Then
            Vencimiento3Importe = ComprobanteCabecera.ImporteTotal1 + (ComprobanteCabecera.ImporteTotal1 * Vencimiento3PorcentajeInteres / 100)
            If InteresRedondeo > 0 Then
                Vencimiento3Importe = Math.Round(Vencimiento3Importe / InteresRedondeo, 0, MidpointRounding.AwayFromZero) * InteresRedondeo
            End If
        Else
            Vencimiento3Importe = 0
        End If
        ComprobanteCabecera.ImporteTotal3 = Vencimiento3Importe

        Return True
    End Function

    Private Function GenerarComprobanteCabecera(ByVal FechaEmision As Date, ByVal FechaVencimiento1 As Date, ByVal FechaVencimiento2 As Date, ByVal FechaVencimiento3 As Date, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal IDConcepto As Byte, ByVal IDComprobanteLote As Integer, ByRef TitularComprobante As Entidad, ByVal LeyendaAlumno As String, ByVal TitularComprobanteMayusculas As Boolean) As Comprobante
        Dim ComprobanteCabecera As New Comprobante

        With ComprobanteCabecera
            ' Cabecera
            .IDComprobanteTipo = TitularComprobante.CategoriaIVA.IDComprobanteTipo_Factura
            .FechaEmision = FechaEmision
            .IDConcepto = IDConcepto
            .FechaServicioDesde = FechaServicioDesde
            .FechaServicioHasta = FechaServicioHasta

            ' Entidad
            .IDEntidad = TitularComprobante.IDEntidad
            If TitularComprobanteMayusculas Then
                .ApellidoNombre = TitularComprobante.ApellidoNombre.ToUpper
            Else
                .ApellidoNombre = TitularComprobante.ApellidoNombre
            End If

            ' Tipo y Número de Documento
            If Not TitularComprobante.FacturaIDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = TitularComprobante.FacturaIDDocumentoTipo.Value
                .DocumentoNumero = TitularComprobante.FacturaDocumentoNumero
            ElseIf Not TitularComprobante.IDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = TitularComprobante.IDDocumentoTipo.Value
                .DocumentoNumero = TitularComprobante.DocumentoNumero
            Else
                .IDDocumentoTipo = CS_Parameter_System.GetIntegerAsByte(Parametros.CONSUMIDORFINAL_DOCUMENTOTIPO_ID)
                .DocumentoNumero = CS_Parameter_System.GetString(Parametros.CONSUMIDORFINAL_DOCUMENTONUMERO)
            End If
            .IDCategoriaIVA = TitularComprobante.IDCategoriaIVA.Value

            ' Domicilio
            .DomicilioCalleCompleto = TitularComprobante.DomicilioCalleCompleto()
            .DomicilioCodigoPostal = TitularComprobante.DomicilioCodigoPostal
            .DomicilioIDProvincia = TitularComprobante.DomicilioIDProvincia
            .DomicilioIDLocalidad = TitularComprobante.DomicilioIDLocalidad

            If IDComprobanteLote = 0 Then
                .IDComprobanteLote = Nothing
            Else
                .IDComprobanteLote = IDComprobanteLote
            End If

            .Leyenda = TitularComprobante.FacturaLeyenda
            If Not LeyendaAlumno Is Nothing Then
                If .Leyenda Is Nothing Then
                    .Leyenda = LeyendaAlumno
                Else
                    .Leyenda &= vbCrLf & LeyendaAlumno
                End If
            End If

            ' Vencimientos
            .FechaVencimiento1 = FechaVencimiento1
            .FechaVencimiento2 = FechaVencimiento2
            .FechaVencimiento3 = FechaVencimiento3

            ' Auditoría
            .IDUsuarioCreacion = pUsuario.IDUsuario
            .FechaHoraCreacion = System.DateTime.Now
            .IDUsuarioModificacion = pUsuario.IDUsuario
            .FechaHoraModificacion = .FechaHoraCreacion
        End With

        Return ComprobanteCabecera
    End Function

    ''' <summary>
    ''' Esta función genera el Detalle del Comprobante con toda la información especificada en los parámetros
    ''' </summary>
    ''' <param name="ComprobanteCabecera">Objeto FacturaCabecera previamente creado</param>
    ''' <param name="Alumno">Entidad que debe figurar en el Detalle (no es la Entidad de la Cabecera)</param>
    ''' <param name="AnioLectivoCursoActual">Objeto AnioLectivoCurso sobre el que se va a emitir la factura</param>
    ''' <param name="ArticuloActual">Objeto Articulo correspondiente al artículo a facturar</param>
    ''' <param name="AnioLectivoAFacturar">El año lectivo que se va a facturar</param>
    ''' <param name="MesAFacturar">En caso de facturar matrícula, especificar cero, si es cuota, el número del mes correspondiente</param>
    ''' <param name="MuestraErrores">Especifica si se va a mostrar un MessageBox cuando no se pueda crear el Detalle por algún motivo, como falta de precios</param>
    ''' <returns>El objeto ComprobanteDetalle creado o Nothing si no se pudo crear</returns>
    ''' <remarks></remarks>
    Private Function GenerarComprobanteDetalle(ByRef ComprobanteCabecera As Comprobante, ByRef Alumno As Entidad, ByRef AnioLectivoCursoActual As AnioLectivoCurso, ByRef ArticuloActual As Articulo, ByVal AnioLectivoAFacturar As Short, ByVal MesAFacturar As Byte, ByVal MuestraErrores As Boolean) As ComprobanteDetalle
        Dim ComprobanteDetalleActual As New ComprobanteDetalle
        Dim AnioLectivo As Short
        Dim AnioLectivoCuotaActual As AnioLectivoCuota
        Dim MesAFacturarNombre As String

        AnioLectivo = AnioLectivoCursoActual.AnioLectivo
        If MesAFacturar = 0 Then
            Dim MesParaPrecio As Byte
            MesParaPrecio = CByte(ComprobanteCabecera.FechaEmision.Month)
            AnioLectivoCuotaActual = AnioLectivoCursoActual.Curso.CuotaTipo.AnioLectivoCuotas.Where(Function(alci) alci.AnioLectivo = AnioLectivo And alci.MesInicio <= MesParaPrecio).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
        Else
            AnioLectivoCuotaActual = AnioLectivoCursoActual.Curso.CuotaTipo.AnioLectivoCuotas.Where(Function(alci) alci.AnioLectivo = AnioLectivo And alci.MesInicio <= MesAFacturar).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
        End If

        If Not AnioLectivoCursoActual Is Nothing Then
            With ComprobanteDetalleActual
                .Indice = CByte(ComprobanteCabecera.ComprobanteDetalle.Count + 1)
                .IDArticulo = ArticuloActual.IDArticulo
                .IDEntidad = Alumno.IDEntidad
                .IDAnioLectivoCurso = AnioLectivoCursoActual.IDAnioLectivoCurso
                If MesAFacturar = 0 Then
                    .CuotaMes = Nothing
                    MesAFacturarNombre = ""
                Else
                    .CuotaMes = MesAFacturar
                    MesAFacturarNombre = DateAndTime.MonthName(MesAFacturar)
                End If
                .Cantidad = 1
                .Descripcion = String.Format(ArticuloActual.Descripcion, vbCrLf, ArticuloActual.Nombre, Alumno.IDEntidad, Alumno.Apellido, Alumno.Nombre, Alumno.ApellidoNombre, AnioLectivoAFacturar, MesAFacturarNombre)

                ' Precios
                If MesAFacturar = 0 Then
                    Select Case Alumno.EmitirFacturaA
                        Case Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO, Constantes.ENTIDAD_EMITIRFACTURAA_PADRE, Constantes.ENTIDAD_EMITIRFACTURAA_MADRE, Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO
                            .PrecioUnitario = AnioLectivoCuotaActual.ImporteMatricula
                        Case Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
                            .PrecioUnitario = Decimal.Round(AnioLectivoCuotaActual.ImporteMatricula / 2, pGeneralConfig.DecimalesEnImportes, MidpointRounding.ToEven)
                        Case Constantes.ENTIDAD_EMITIRFACTURAA_TODOS
                            .PrecioUnitario = Decimal.Round(AnioLectivoCuotaActual.ImporteMatricula / 3, pGeneralConfig.DecimalesEnImportes, MidpointRounding.ToEven)
                    End Select
                Else
                    Select Case Alumno.EmitirFacturaA
                        Case Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO, Constantes.ENTIDAD_EMITIRFACTURAA_PADRE, Constantes.ENTIDAD_EMITIRFACTURAA_MADRE, Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO
                            .PrecioUnitario = AnioLectivoCuotaActual.ImporteCuota
                        Case Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
                            .PrecioUnitario = Decimal.Round(AnioLectivoCuotaActual.ImporteCuota / 2, pGeneralConfig.DecimalesEnImportes, MidpointRounding.ToEven)
                        Case Constantes.ENTIDAD_EMITIRFACTURAA_TODOS
                            .PrecioUnitario = Decimal.Round(AnioLectivoCuotaActual.ImporteCuota / 3, pGeneralConfig.DecimalesEnImportes, MidpointRounding.ToEven)
                    End Select
                End If

                ' Descuentos
                If Alumno.IDDescuento Is Nothing Then
                    .PrecioUnitarioDescuentoPorcentaje = 0
                    .PrecioUnitarioDescuentoImporte = 0
                Else
                    .PrecioUnitarioDescuentoPorcentaje = Alumno.Descuento.Porcentaje
                    .PrecioUnitarioDescuentoImporte = Decimal.Round(.PrecioUnitario * .PrecioUnitarioDescuentoPorcentaje / 100, pGeneralConfig.DecimalesEnImportes, MidpointRounding.ToEven)
                End If
                .PrecioUnitarioFinal = .PrecioUnitario - .PrecioUnitarioDescuentoImporte
                .PrecioTotal = .PrecioUnitarioFinal
            End With

            ComprobanteCabecera.ComprobanteDetalle.Add(ComprobanteDetalleActual)

            Return ComprobanteDetalleActual
        Else
            If MuestraErrores Then
                MsgBox("No hay precios cargados para la(s) Factura(s) que se intentan emitir.", MsgBoxStyle.Information, My.Application.Info.Title)
            End If
            Return Nothing
        End If
    End Function

    Friend Function TransmitirAFIP_Inicializar(ByRef Objeto_AFIP_WS As CS_AFIP_WS.AFIP_WS, ByVal ModoHomologacion As Boolean) As Boolean
        With Objeto_AFIP_WS
            If pAfipWebServicesConfig.LogEnabled Then
                .LogPath = CardonerSistemas.SpecialFolders.ProcessString(pAfipWebServicesConfig.LogFolder)
                If Not .LogPath.EndsWith("\") Then
                    .LogPath &= "\"
                End If
                .LogPath &= DateTime.Today.Year & "\" & DateTime.Today.Month.ToString.PadLeft(2, "0"c) & "\"
                .LogFileName = CardonerSistemas.Files.ProcessFilename(pAfipWebServicesConfig.LogFileName)
            End If

            ' Leo los valores comunes a todas las facturas
            If ModoHomologacion Then
                .Certificado = pAfipWebServicesConfig.CertificadoHomologacion
                .WSAA_URL = CS_Parameter_System.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION)
                .WSFEv1_URL = CS_Parameter_System.GetString(Parametros.AFIP_WS_FE_HOMOLOGACION)
            Else
                .Certificado = pAfipWebServicesConfig.CertificadoProduccion
                .WSAA_URL = CS_Parameter_System.GetString(Parametros.AFIP_WS_AA_PRODUCCION)
                .WSFEv1_URL = CS_Parameter_System.GetString(Parametros.AFIP_WS_FE_PRODUCCION)
            End If
            .ClavePrivada = pAfipWebServicesConfig.ClavePrivada

            .InternetProxy = CS_Parameter_System.GetString(Parametros.INTERNET_PROXY, "")
            .CUIT_Emisor = CS_Parameter_System.GetString(Parametros.EMPRESA_CUIT)

            Using dbContext As New CSColegioContext(True)
                .MonedaLocal = dbContext.Moneda.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
                If .MonedaLocal Is Nothing Then
                    MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
                    Return False
                End If
                .MonedaLocalCotizacion = dbContext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = .MonedaLocal.IDMoneda).FirstOrDefault
                If .MonedaLocalCotizacion Is Nothing Then
                    MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
                    Return False
                End If
            End Using
        End With
        Return True
    End Function

    Friend Function TransmitirAFIP_IniciarSesion(ByRef Objeto_AFIP_WS As CS_AFIP_WS.AFIP_WS) As Boolean
        Return Objeto_AFIP_WS.FacturaElectronica_Login()
    End Function

    Friend Function TransmitirAFIP_ConectarServicio(ByRef Objeto_AFIP_WS As CS_AFIP_WS.AFIP_WS) As Boolean
        Return Objeto_AFIP_WS.FacturaElectronica_Conectar()
    End Function

    Friend Function TransmitirAFIP_Comprobante(ByRef Objeto_AFIP_WS As CS_AFIP_WS.AFIP_WS, ByVal IDComprobanteActual As Integer) As Boolean
        Dim AFIP_Factura As New CS_AFIP_WS.FacturaElectronicaCabecera
        Dim ComprobanteActual As Comprobante
        Dim ComprobanteTipoActual As New ComprobanteTipo

        Dim ArticuloActual As Articulo
        Dim IDConcepto As Byte = 0

        If IDComprobanteActual <> 0 Then

            Using dbContext As New CSColegioContext(True)
                ComprobanteActual = dbContext.Comprobante.Find(IDComprobanteActual)

                If ComprobanteActual.CAE Is Nothing Then
                    With AFIP_Factura
                        ' Cargo el Tipo de Comprobante si es distinto al anterior
                        If ComprobanteActual.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
                            ComprobanteTipoActual = dbContext.ComprobanteTipo.Find(ComprobanteActual.IDComprobanteTipo)
                        End If

                        ' Esto es para determinar el Concepto a especificar en el pedido del CAE
                        If ComprobanteActual.ComprobanteDetalle.Count > 0 Then
                            For Each CDetalle As ComprobanteDetalle In ComprobanteActual.ComprobanteDetalle
                                ArticuloActual = dbContext.Articulo.Find(CDetalle.IDArticulo)
                                Select Case IDConcepto
                                    Case CByte(0)
                                        ' Es el primer Artículo, así que lo guardo
                                        IDConcepto = ArticuloActual.ArticuloGrupo.IDConcepto
                                    Case ArticuloActual.ArticuloGrupo.IDConcepto
                                        ' Es el mismo Concepto que el/los Artículos anteriores, no hago nada

                                    Case Else
                                        If (IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO Or IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS) And (ArticuloActual.ArticuloGrupo.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO Or ArticuloActual.ArticuloGrupo.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS) Then
                                            ' Hay Productos y Servicios, así que utilizo el Concepto correspondiente
                                            IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTOSYSERVICIOS
                                            Exit For
                                        End If
                                End Select
                            Next
                        Else
                            IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO
                        End If
                        .Concepto = IDConcepto

                        ' Documento del Titular
                        .TipoDocumento = CShort(ComprobanteActual.IDDocumentoTipo)
                        .DocumentoNumero = CLng(CS_ValueTranslation.FromStringToOnlyDigitsString(ComprobanteActual.DocumentoNumero))

                        ' Tipo de Comprobante
                        .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

                        ' Datos de la Cabecera
                        .PuntoVenta = CShort(ComprobanteActual.PuntoVenta)
                        .ComprobanteDesde = CInt(ComprobanteActual.Numero)
                        .ComprobanteHasta = CInt(ComprobanteActual.Numero)
                        .ComprobanteFecha = ComprobanteActual.FechaEmision

                        ' Importes
                        .ImporteTotal = ComprobanteActual.ImporteTotal1
                        .ImporteTotalConc = 0
                        .ImporteNeto = ComprobanteActual.ImporteTotal1
                        .ImporteOperacionesExentas = 0
                        .ImporteTributos = 0
                        .ImporteIVA = ComprobanteActual.ImporteImpuesto

                        ' Fechas
                        If ComprobanteActual.FechaServicioDesde.HasValue Then
                            .FechaServicioDesde = ComprobanteActual.FechaServicioDesde.Value
                        End If
                        If ComprobanteActual.FechaServicioHasta.HasValue Then
                            .FechaServicioHasta = ComprobanteActual.FechaServicioHasta.Value
                        End If
                        If ComprobanteActual.FechaVencimiento1.HasValue Then
                            .FechaVencimientoPago = ComprobanteActual.FechaVencimiento1.Value
                        End If

                        ' Moneda
                        .MonedaID = Objeto_AFIP_WS.MonedaLocal.CodigoAFIP
                        .MonedaCotizacion = Objeto_AFIP_WS.MonedaLocalCotizacion.CotizacionVenta

                        ' Comprobantes Aplicados
                        For Each ComprobanteAplicacionActual As ComprobanteAplicacion In ComprobanteActual.ComprobanteAplicacion_Aplicados
                            Dim AFIP_ComprobanteAsociado As New ComprobanteAsociado
                            AFIP_ComprobanteAsociado.TipoComprobante = ComprobanteAplicacionActual.ComprobanteAplicado.ComprobanteTipo.CodigoAFIP
                            AFIP_ComprobanteAsociado.ComprobanteNumero = CInt(ComprobanteAplicacionActual.ComprobanteAplicado.Numero)
                            AFIP_ComprobanteAsociado.PuntoVenta = CShort(ComprobanteAplicacionActual.ComprobanteAplicado.PuntoVenta)
                            .ComprobantesAsociados.Add(AFIP_ComprobanteAsociado)
                        Next
                    End With

                    ' Obtengo el CAE
                    With Objeto_AFIP_WS
                        If .FacturaElectronica_ObtenerCAE(AFIP_Factura) Then
                            If .UltimoResultadoCAE.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                                ComprobanteActual.CAE = .UltimoResultadoCAE.Numero
                                ComprobanteActual.CAEVencimiento = .UltimoResultadoCAE.FechaVencimiento
                                ComprobanteActual.IDUsuarioTransmisionAFIP = pUsuario.IDUsuario
                                ComprobanteActual.FechaHoraTransmisionAFIP = DateTime.Now

                                dbContext.SaveChanges()

                                Return True
                            Else
                                Return False
                            End If
                        Else
                            Return False
                        End If
                    End With
                Else
                    Return False
                End If
            End Using
        Else
            Return False
        End If
    End Function

    Friend Function CalcularInteresesSobreAplicaciones(ByVal FechaCalculo As Date, ByRef ComprobanteAplicaciones As List(Of ComprobanteAplicacion)) As Decimal
        If ComprobanteAplicaciones.Count > 0 AndAlso CS_Parameter_System.GetBoolean(Parametros.VENTA_INTERES_CALCULAR) Then
            Dim DiasTranscurridos As Long
            Dim PorcentajeInteresDiario As Decimal
            Dim PorcentajeInteresAplicar As Decimal
            Dim ImporteInteresAcumulado As Decimal = 0

            PorcentajeInteresDiario = CS_Parameter_System.GetDecimal(Parametros.VENTA_INTERES_MENSUAL) / 30

            Using dbContext As New CSColegioContext(True)
                Dim ComprobanteAplicadoActual As Comprobante

                For Each ComprobanteAplicacionActual As ComprobanteAplicacion In ComprobanteAplicaciones
                    ComprobanteAplicadoActual = dbContext.Comprobante.Find(ComprobanteAplicacionActual.IDComprobanteAplicado)

                    If ComprobanteAplicadoActual.FechaVencimiento1.HasValue Then
                        DiasTranscurridos = DateDiff(DateInterval.Day, ComprobanteAplicadoActual.FechaVencimiento1.Value, FechaCalculo)
                        If DiasTranscurridos > 0 AndAlso DiasTranscurridos > CS_Parameter_System.GetIntegerAsInteger(Parametros.VENTA_INTERES_DIASTOLERANCIA) Then
                            PorcentajeInteresAplicar = DiasTranscurridos * PorcentajeInteresDiario
                            ImporteInteresAcumulado += ComprobanteAplicacionActual.Importe * PorcentajeInteresAplicar / 100
                        End If
                    End If
                Next
            End Using

            Return ImporteInteresAcumulado
        Else
            Return 0
        End If
    End Function
End Module
