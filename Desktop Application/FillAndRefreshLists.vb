Friend Class FillAndRefreshLists

#Region "Declarations..."
    Friend dbContext As CSColegioContext

    Public Class AnioLectivoCurso_ListItem
        Public Property IDAnioLectivoCurso As Short
        Public Property Descripcion As String
        Public Property AnioLectivo As Short
    End Class
#End Region

    Friend Sub DocumentoTipo(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDDocumentoTipo"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.DocumentoTipo
                          Where tbl.EsActivo
                          Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New DocumentoTipo
            UnspecifiedItem.IDDocumentoTipo = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            UnspecifiedItem.VerificaModulo11 = False
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub CategoriaIVA(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDCategoriaIVA"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.CategoriaIVA
                          Where tbl.EsActivo
                          Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New CategoriaIVA
            UnspecifiedItem.IDCategoriaIVA = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Banco(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        Dim listBancos As List(Of Banco)

        ComboBoxControl.ValueMember = "IDBanco"
        ComboBoxControl.DisplayMember = "Nombre"

        listBancos = (From tbl In dbContext.Banco
                      Where tbl.EsActivo
                      Order By tbl.Nombre).ToList

        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Banco
            UnspecifiedItem.IDBanco = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            listBancos.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = listBancos
    End Sub

    Friend Sub Provincia(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDProvincia"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.Provincia
                          Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Provincia
            UnspecifiedItem.IDProvincia = Constantes.PROVINCIA_NOESPECIFICA
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Localidad(ByRef ComboBoxControl As ComboBox, ByVal IDProvincia As Byte, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDLocalidad"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.Localidad
                          Where tbl.IDProvincia = IDProvincia
                          Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Localidad
            UnspecifiedItem.IDLocalidad = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub ComprobanteTipo(ByRef ComboBoxControl As ComboBox, ByVal OperacionTipo As String, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim localList As List(Of ComprobanteTipo)

        ComboBoxControl.ValueMember = "IDComprobanteTipo"

        If String.IsNullOrEmpty(OperacionTipo) Then
            ComboBoxControl.DisplayMember = "NombreCompleto"

            Dim qryList = From tbl In dbContext.ComprobanteTipo
                          Where tbl.EsActivo
                          Order By tbl.NombreCompleto

            localList = qryList.ToList
        Else
            ComboBoxControl.DisplayMember = "NombreConLetra"

            Dim qryList = From tbl In dbContext.ComprobanteTipo
                          Where tbl.OperacionTipo = OperacionTipo And tbl.EsActivo
                          Order By tbl.NombreConLetra

            localList = qryList.ToList
        End If

        If AgregarItem_Todos Then
            Dim UnspecifiedItem As New ComprobanteTipo
            UnspecifiedItem.IDComprobanteTipo = Byte.MaxValue
            UnspecifiedItem.NombreConLetra = My.Resources.STRING_ITEM_ALL_MALE
            UnspecifiedItem.NombreCompleto = My.Resources.STRING_ITEM_ALL_MALE
            localList.Insert(0, UnspecifiedItem)
        End If
        If AgregarItem_NoEspecifica Then
            Dim AllItem As New ComprobanteTipo
            AllItem.IDComprobanteTipo = Byte.MinValue
            AllItem.NombreConLetra = My.Resources.STRING_ITEM_NON_SPECIFIED
            AllItem.NombreCompleto = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, AllItem)
        End If

        ComboBoxControl.DataSource = localList
        ComboBoxControl.SelectedIndex = -1
    End Sub

    Friend Sub Genero(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        Dim datatableGeneros As New DataTable("Generos")
        Dim datarowRow As DataRow

        ComboBoxControl.ValueMember = "IDGenero"
        ComboBoxControl.DisplayMember = "Nombre"

        With datatableGeneros
            .Columns.Add("IDGenero", System.Type.GetType("System.String"))
            .Columns.Add("Nombre", System.Type.GetType("System.String"))

            If ShowUnspecifiedItem Then
                datarowRow = .NewRow
                datarowRow("IDGenero") = Constantes.GENERO_NOESPECIFICA
                datarowRow("Nombre") = My.Resources.STRING_ITEM_NON_SPECIFIED
                datatableGeneros.Rows.Add(datarowRow)
            End If

            datarowRow = .NewRow
            datarowRow("IDGenero") = "M"
            datarowRow("Nombre") = My.Resources.STRING_GENERO_MASCULINO
            datatableGeneros.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDGenero") = "F"
            datarowRow("Nombre") = My.Resources.STRING_GENERO_FEMENINO
            datatableGeneros.Rows.Add(datarowRow)
        End With

        ComboBoxControl.DataSource = datatableGeneros
    End Sub

    Friend Sub EmitirFacturaA(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        Dim datatableEntidadFactura As New DataTable("EntidadFactura")
        Dim datarowRow As DataRow

        ComboBoxControl.ValueMember = "IDEmitirFacturaA"
        ComboBoxControl.DisplayMember = "Nombre"

        With datatableEntidadFactura
            .Columns.Add("IDEmitirFacturaA", System.Type.GetType("System.String"))
            .Columns.Add("Nombre", System.Type.GetType("System.String"))

            If ShowUnspecifiedItem Then
                datarowRow = .NewRow
                datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_NOESPECIFICA
                datarowRow("Nombre") = My.Resources.STRING_ITEM_NON_SPECIFIED
                datatableEntidadFactura.Rows.Add(datarowRow)
            End If

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_PADRE
            datarowRow("Nombre") = My.Resources.STRING_EMITIRFACTURAA_PADRE
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_MADRE
            datarowRow("Nombre") = My.Resources.STRING_EMITIRFACTURAA_MADRE
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_AMBOSPADRES
            datarowRow("Nombre") = My.Resources.STRING_EMITIRFACTURAA_AMBOSPADRES
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_TERCERO
            datarowRow("Nombre") = My.Resources.STRING_EMITIRFACTURAA_TERCERO
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_TODOS
            datarowRow("Nombre") = My.Resources.STRING_EMITIRFACTURAA_TODOS
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.EMITIRFACTURAA_ALUMNO
            datarowRow("Nombre") = My.Resources.STRING_EMITIRFACTURAA_ALUMNO
            datatableEntidadFactura.Rows.Add(datarowRow)
        End With

        ComboBoxControl.DataSource = datatableEntidadFactura
    End Sub

    Friend Sub Descuento(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDDescuento"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.Descuento
                          Where tbl.EsActivo
                          Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Descuento
            UnspecifiedItem.IDDescuento = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub AnioLectivo(ByRef ComboBoxControl As ComboBox, Optional ByVal Orden As SortOrder = SortOrder.Ascending)
        ComboBoxControl.ValueMember = "AnioLectivo"
        ComboBoxControl.DisplayMember = "AnioLectivo"

        Dim qryList = From tbl In dbContext.AnioLectivoCurso
                          Select tbl.AnioLectivo
                          Distinct

        If Orden = SortOrder.Descending Then
            ComboBoxControl.DataSource = qryList.OrderByDescending(Function(al) al).ToList
        Else
            ComboBoxControl.DataSource = qryList.OrderBy(Function(al) al).ToList
        End If
    End Sub

    Friend Sub Nivel(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDNivel"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.Nivel
                          Where tbl.EsActivo
                          Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Nivel
            UnspecifiedItem.IDNivel = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub CursoPorAnioLectivoYNivel(ByRef ComboBoxControl As ComboBox, ByVal AnioLectivo As Integer, Optional ByVal IDNivel As Byte? = Nothing)
        ComboBoxControl.ValueMember = "IDCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IDNivel Is Nothing Then
            Dim qryList = From tbl In dbContext.AnioLectivoCurso
                          Where tbl.AnioLectivo = AnioLectivo
                          Order By tbl.AnioLectivo, tbl.Curso.Anio.Nivel.Nombre, tbl.Curso.Anio.Nombre, tbl.Curso.Turno.Nombre, tbl.Curso.Division
                          Select tbl.IDCurso, Descripcion = tbl.Curso.Anio.Nivel.Nombre & " - " & tbl.Curso.Anio.Nombre & " - " & tbl.Curso.Turno.Nombre & " - " & tbl.Curso.Division
            ComboBoxControl.DataSource = qryList.ToList
        Else
            Dim qryList = From tbl In dbContext.AnioLectivoCurso
                          Where tbl.AnioLectivo = AnioLectivo And tbl.Curso.Anio.IDNivel = IDNivel
                          Order By tbl.AnioLectivo, tbl.Curso.Anio.Nombre, tbl.Curso.Turno.Nombre, tbl.Curso.Division
                          Select tbl.IDCurso, Descripcion = tbl.Curso.Anio.Nombre & " - " & tbl.Curso.Turno.Nombre & " - " & tbl.Curso.Division
            ComboBoxControl.DataSource = qryList.ToList
        End If
    End Sub

    Friend Sub AnioLectivoCurso(ByRef ComboBoxControl As ComboBox, ByVal AnioLectivoDesde As Integer, ByVal AnioLectivoHasta As Integer, Optional ByVal IDEntidad As Integer? = Nothing)
        Dim listAnioLectivoCursos As List(Of AnioLectivoCurso_ListItem)

        ComboBoxControl.ValueMember = "IDAnioLectivoCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IDEntidad Is Nothing Then
            listAnioLectivoCursos = (From alc In dbContext.AnioLectivoCurso
                                     Where alc.AnioLectivo >= AnioLectivoDesde And alc.AnioLectivo <= AnioLectivoHasta
                                     Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                     Select New AnioLectivoCurso_ListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.AnioLectivo.ToString & " - " & alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo}).ToList
        Else
            listAnioLectivoCursos = (From e In dbContext.Entidad
                                     From alc In e.AniosLectivosCursos
                                     Where e.IDEntidad = IDEntidad And alc.AnioLectivo >= AnioLectivoDesde And alc.AnioLectivo <= AnioLectivoHasta
                                     Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                     Select New AnioLectivoCurso_ListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.AnioLectivo.ToString & " - " & alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo}).ToList
        End If

        ComboBoxControl.DataSource = listAnioLectivoCursos
    End Sub

    Friend Sub ComprobanteLote(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listComprobanteLote As List(Of ComprobanteLote)

        ComboBoxControl.ValueMember = "IDComprobanteLote"
        ComboBoxControl.DisplayMember = "Nombre"

        listComprobanteLote = dbContext.ComprobanteLote.OrderByDescending(Function(cl) cl.FechaHora).ToList

        If AgregarItem_Todos Then
            Dim Item_Todos As New ComprobanteLote
            Item_Todos.IDComprobanteLote = -1
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listComprobanteLote.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New ComprobanteLote
            Item_NoEspecifica.IDComprobanteLote = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            listComprobanteLote.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listComprobanteLote
    End Sub

    Friend Sub MedioPago(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean, ByVal EsChequeMostrar As Boolean, ByVal NoEsChequeMostrar As Boolean)
        Dim listMediosPago As List(Of MedioPago)

        ComboBoxControl.ValueMember = "IDMedioPago"
        ComboBoxControl.DisplayMember = "Nombre"

        If EsChequeMostrar And NoEsChequeMostrar Then
            listMediosPago = (From tbl In dbContext.MedioPago
                              Where tbl.EsActivo
                              Order By tbl.Nombre).ToList
        ElseIf EsChequeMostrar Then
            listMediosPago = (From tbl In dbContext.MedioPago
                              Where tbl.EsActivo And tbl.EsCheque
                              Order By tbl.Nombre).ToList
        ElseIf NoEsChequeMostrar Then
            listMediosPago = (From tbl In dbContext.MedioPago
                              Where tbl.EsActivo And Not tbl.EsCheque
                              Order By tbl.Nombre).ToList
        Else
            listMediosPago = Nothing
        End If

        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New MedioPago
            UnspecifiedItem.IDMedioPago = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            listMediosPago.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = listMediosPago
    End Sub

    Friend Sub ChequeMotivoRechazo(ByRef ComboBoxControl As ComboBox, ByVal MostrarNombreCompleto As Boolean, ByVal AgregarItem_Todos As Boolean)
        Dim localList As List(Of ChequeMotivoRechazo)

        ComboBoxControl.ValueMember = "IDChequeMotivoRechazo"

        If MostrarNombreCompleto Then
            ComboBoxControl.DisplayMember = "NombreCompleto"
            localList = dbContext.ChequeMotivoRechazo.Where(Function(cmr) cmr.EsActivo).OrderBy(Function(cmr) cmr.NombreCompleto).ToList
        Else
            ComboBoxControl.DisplayMember = "Nombre"
            localList = dbContext.ChequeMotivoRechazo.Where(Function(cmr) cmr.EsActivo).OrderBy(Function(cmr) cmr.Nombre).ToList
        End If

        If AgregarItem_Todos Then
            Dim UnspecifiedItem As New ChequeMotivoRechazo
            UnspecifiedItem.IDChequeMotivoRechazo = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            UnspecifiedItem.NombreCompleto = My.Resources.STRING_ITEM_ALL_MALE
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Caja(ByRef ComboBoxControl As ComboBox, ByVal IDMedioPago As Byte?, ByVal ShowUnspecifiedItem As Boolean)
        Dim localList As List(Of Caja)

        ComboBoxControl.ValueMember = "IDCaja"
        ComboBoxControl.DisplayMember = "Nombre"

        If IDMedioPago Is Nothing OrElse IDMedioPago = 0 Then
            localList = (From c In dbContext.Caja
                         Where c.EsActivo
                         Order By c.Nombre).ToList
        Else
            localList = (From c In dbContext.Caja
                         From mp In c.MedioPago
                         Where c.EsActivo AndAlso mp.IDMedioPago = IDMedioPago
                         Order By c.Nombre
                         Select c).ToList
        End If

        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Caja
            UnspecifiedItem.IDCaja = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub ComprobanteAplicacionMotivo(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listComprobanteAplicacionMotivo As List(Of ComprobanteAplicacionMotivo)

        ComboBoxControl.ValueMember = "IDComprobanteAplicacionMotivo"
        ComboBoxControl.DisplayMember = "Nombre"

        listComprobanteAplicacionMotivo = dbContext.ComprobanteAplicacionMotivo.OrderBy(Function(cl) cl.Nombre).ToList

        If AgregarItem_Todos Then
            Dim Item_Todos As New ComprobanteAplicacionMotivo
            Item_Todos.IDComprobanteAplicacionMotivo = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listComprobanteAplicacionMotivo.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New ComprobanteAplicacionMotivo
            Item_NoEspecifica.IDComprobanteAplicacionMotivo = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            listComprobanteAplicacionMotivo.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listComprobanteAplicacionMotivo
    End Sub

    Friend Sub Articulo(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listArticulos As List(Of Articulo)

        ComboBoxControl.ValueMember = "IDArticulo"
        ComboBoxControl.DisplayMember = "Nombre"

        listArticulos = dbContext.Articulo.OrderBy(Function(cl) cl.Nombre).ToList

        If AgregarItem_Todos Then
            Dim Item_Todos As New Articulo
            Item_Todos.IDArticulo = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listArticulos.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Articulo
            Item_NoEspecifica.IDArticulo = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
            listArticulos.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listArticulos
    End Sub

    Public Sub New()
        dbContext = New CSColegioContext(True)
    End Sub

    Protected Overrides Sub Finalize()
        dbContext.Dispose()
        MyBase.Finalize()
    End Sub
End Class
