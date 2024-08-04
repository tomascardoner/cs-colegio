Imports System.Globalization

Friend Class FillAndRefreshLists

#Region "Declarations"

    Friend mdbContext As CSColegioContext

    Public Sub New()
        mdbContext = New CSColegioContext(True)
    End Sub

    Protected Overrides Sub Finalize()
        mdbContext.Dispose()
        MyBase.Finalize()
    End Sub

    Public Class AnioLectivoCursoListItem
        Public Property IDAnioLectivoCurso As Short
        Public Property Descripcion As String
        Public Property AnioLectivo As Short
        Public Property IDCurso As Byte
    End Class

    Public Class Anio_ListItem
        Public Property IDAnio As Byte
        Public Property Descripcion As String
    End Class

    Public Class Curso_ListItem
        Public Property IDCurso As Byte
        Public Property Descripcion As String
    End Class

#End Region

    Friend Sub Anio(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, ByVal IncluyeNivelEnNombre As Boolean, Optional ByVal Excluye_IDAnio As Byte = 0, Optional ByVal IDNivel As Byte = 0)
        Dim listAnios As List(Of Anio_ListItem)

        ComboBoxControl.ValueMember = "IDAnio"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IncluyeNivelEnNombre Then
            listAnios = (From a In mdbContext.Anio
                         Join n In mdbContext.Nivel On a.IDNivel Equals n.IDNivel
                         Where a.EsActivo AndAlso a.IDAnio <> Excluye_IDAnio AndAlso (IDNivel = 0 OrElse a.IDNivel = IDNivel)
                         Select New Anio_ListItem With {.IDAnio = a.IDAnio, .Descripcion = n.Nombre & " - " & a.Nombre}).ToList
        Else
            listAnios = (From a In mdbContext.Anio
                         Where a.EsActivo AndAlso a.IDAnio <> Excluye_IDAnio AndAlso (IDNivel = 0 OrElse a.IDNivel = IDNivel)
                         Select New Anio_ListItem With {.IDAnio = a.IDAnio, .Descripcion = a.Nombre}).ToList
        End If

        If AgregarItem_Todos Then
            Dim Item_Todos As New Anio_ListItem
            Item_Todos.IDAnio = 0
            Item_Todos.Descripcion = My.Resources.STRING_ITEM_ALL_MALE
            listAnios.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Anio_ListItem
            Item_NoEspecifica.IDAnio = 0
            Item_NoEspecifica.Descripcion = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listAnios.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listAnios
    End Sub

    Friend Sub DocumentoTipo(ByRef control As ComboBox, ByVal mostrarItemNoEspecifica As Boolean)
        Dim listDocumentoTipo As List(Of DocumentoTipo)

        control.ValueMember = "IDDocumentoTipo"
        control.DisplayMember = "Nombre"

        listDocumentoTipo = mdbContext.DocumentoTipo.Where(Function(dt) dt.EsActivo).OrderBy(Function(dt) dt.Nombre).ToList()

        If mostrarItemNoEspecifica Then
            Dim itemNoEspecifica As New DocumentoTipo

            itemNoEspecifica.IDDocumentoTipo = CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE
            itemNoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            itemNoEspecifica.VerificaModulo11 = False
            listDocumentoTipo.Insert(0, itemNoEspecifica)
        End If

        control.DataSource = listDocumentoTipo

        listDocumentoTipo = Nothing
    End Sub

    Friend Sub CategoriaIVA(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDCategoriaIVA"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.CategoriaIVA
                      Where tbl.EsActivo
                      Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New CategoriaIVA
            UnspecifiedItem.IDCategoriaIVA = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Banco(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        Dim listBancos As List(Of Banco)

        ComboBoxControl.ValueMember = "IDBanco"
        ComboBoxControl.DisplayMember = "Nombre"

        listBancos = (From tbl In mdbContext.Banco
                      Where tbl.EsActivo
                      Order By tbl.Nombre).ToList

        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Banco
            UnspecifiedItem.IDBanco = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listBancos.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = listBancos
    End Sub

    Friend Sub Provincia(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDProvincia"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.Provincia
                      Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Provincia
            UnspecifiedItem.IDProvincia = Constantes.PROVINCIA_NOESPECIFICA
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Localidad(ByRef ComboBoxControl As ComboBox, ByVal IDProvincia As Byte, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDLocalidad"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.Localidad
                      Where tbl.IDProvincia = IDProvincia
                      Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Localidad
            UnspecifiedItem.IDLocalidad = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub ComprobanteTipo(ByRef ComboBoxControl As ComboBox, ByVal OperacionTipo As String, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim localList As List(Of ComprobanteTipo)

        ComboBoxControl.ValueMember = "IDComprobanteTipo"

        If String.IsNullOrEmpty(OperacionTipo) Then
            ComboBoxControl.DisplayMember = "NombreCompleto"

            Dim qryList = From tbl In mdbContext.ComprobanteTipo
                          Where tbl.EsActivo
                          Order By tbl.NombreCompleto

            localList = qryList.ToList
        Else
            ComboBoxControl.DisplayMember = "NombreConLetra"

            Dim qryList = From tbl In mdbContext.ComprobanteTipo
                          Where tbl.OperacionTipo = OperacionTipo AndAlso tbl.EsActivo
                          Order By tbl.NombreConLetra

            localList = qryList.ToList
        End If

        If AgregarItem_Todos Then
            Dim AllItem As New ComprobanteTipo
            AllItem.IDComprobanteTipo = Byte.MaxValue
            AllItem.NombreConLetra = My.Resources.STRING_ITEM_ALL_MALE
            AllItem.NombreCompleto = My.Resources.STRING_ITEM_ALL_MALE
            localList.Insert(0, AllItem)
        End If
        If AgregarItem_NoEspecifica Then
            Dim UnspecifiedItem As New ComprobanteTipo
            UnspecifiedItem.IDComprobanteTipo = Byte.MinValue
            UnspecifiedItem.NombreConLetra = My.Resources.STRING_ITEM_NOT_SPECIFIED
            UnspecifiedItem.NombreCompleto = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
        ComboBoxControl.SelectedIndex = -1
    End Sub

    Friend Sub Genero(ByRef comboBoxControl As ComboBox, ByVal mostrarItemNoEspecifica As Boolean)
        Dim datatableGeneros As New DataTable("Generos")
        Dim datarowRow As DataRow

        comboBoxControl.ValueMember = "IDGenero"
        comboBoxControl.DisplayMember = "Nombre"

        With datatableGeneros
            .Columns.Add("IDGenero", System.Type.GetType("System.String"))
            .Columns.Add("Nombre", System.Type.GetType("System.String"))

            If mostrarItemNoEspecifica Then
                datarowRow = .NewRow
                datarowRow("IDGenero") = Constantes.EntidadGeneroNoEspecifica
                datarowRow("Nombre") = My.Resources.STRING_ITEM_NOT_SPECIFIED
                .Rows.Add(datarowRow)
            End If

            datarowRow = .NewRow
            datarowRow("IDGenero") = Constantes.EntidadGeneroMasculino
            datarowRow("Nombre") = My.Resources.STRING_GENERO_MASCULINO
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDGenero") = Constantes.EntidadGeneroFemenino
            datarowRow("Nombre") = My.Resources.STRING_GENERO_FEMENINO
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDGenero") = Constantes.EntidadGeneroEmpresa
            datarowRow("Nombre") = My.Resources.STRING_GENERO_EMPRESA
            .Rows.Add(datarowRow)
        End With

        comboBoxControl.DataSource = datatableGeneros
    End Sub

    Friend Sub Entidad_ComprobanteEnviarEmail(ByRef ComboBoxControl As ComboBox)
        Dim datatableComprobanteEnviarEmail As New DataTable("ComprobanteEnviarEmail")
        Dim datarowRow As DataRow

        ComboBoxControl.ValueMember = "IDComprobanteEnviarEmail"
        ComboBoxControl.DisplayMember = "Nombre"

        With datatableComprobanteEnviarEmail
            .Columns.Add("IDComprobanteEnviarEmail", System.Type.GetType("System.String"))
            .Columns.Add("Nombre", System.Type.GetType("System.String"))

            datarowRow = .NewRow
            datarowRow("IDComprobanteEnviarEmail") = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDComprobanteEnviarEmail") = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDComprobanteEnviarEmail") = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDComprobanteEnviarEmail") = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDComprobanteEnviarEmail") = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
            .Rows.Add(datarowRow)
        End With

        ComboBoxControl.DataSource = datatableComprobanteEnviarEmail
    End Sub

    Friend Sub Entidad_EmitirFacturaA(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        Dim datatableEntidadFactura As New DataTable("EntidadFactura")
        Dim datarowRow As DataRow

        ComboBoxControl.ValueMember = "IDEmitirFacturaA"
        ComboBoxControl.DisplayMember = "Nombre"

        With datatableEntidadFactura
            .Columns.Add("IDEmitirFacturaA", System.Type.GetType("System.String"))
            .Columns.Add("Nombre", System.Type.GetType("System.String"))

            If ShowUnspecifiedItem Then
                datarowRow = .NewRow
                datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA
                datarowRow("Nombre") = My.Resources.STRING_ITEM_NOT_SPECIFIED
                .Rows.Add(datarowRow)
            End If

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_EMITIRFACTURAA_PADRE
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_EMITIRFACTURAA_MADRE
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_EMITIRFACTURAA_TERCERO
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_EMITIRFACTURAA_TODOS
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEmitirFacturaA") = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO
            datarowRow("Nombre") = My.Resources.STRING_ENTIDAD_EMITIRFACTURAA_ALUMNO
            .Rows.Add(datarowRow)
        End With

        ComboBoxControl.DataSource = datatableEntidadFactura
    End Sub

    Friend Sub Descuento(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDDescuento"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.Descuento
                      Where tbl.EsActivo
                      Order By tbl.Nombre

        Dim localList = qryList.ToList
        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Descuento
            UnspecifiedItem.IDDescuento = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub AnioLectivo(ByRef ComboBoxControl As ComboBox, ByVal LeerDesdeBaseDeDatos As Boolean, Optional ByVal Orden As SortOrder = SortOrder.Ascending)
        If LeerDesdeBaseDeDatos Then
            ComboBoxControl.ValueMember = "AnioLectivo"
            ComboBoxControl.DisplayMember = "AnioLectivo"

            Dim qryList = (From alc In mdbContext.AnioLectivoCurso
                           Order By alc.AnioLectivo
                           Select alc.AnioLectivo
                           Distinct).ToList

            If Orden = SortOrder.Ascending Then
                ComboBoxControl.DataSource = qryList.OrderBy(Function(al) al).ToList
            Else
                ComboBoxControl.DataSource = qryList.OrderByDescending(Function(al) al).ToList
            End If
        Else
            Dim FechaInicioActividad As Date

            ' Cargo de acuerdo a la Fecha de Inicio de Actividades o al Año actual, en su defecto
            FechaInicioActividad = CS_Parameter_System.GetDate(Parametros.EMPRESA_INICIO_ACTIVIDAD, DateTime.Today).Value
            If Orden = SortOrder.Ascending Then
                For AnioActual As Integer = FechaInicioActividad.Year To DateTime.Today.AddYears(1).Year
                    ComboBoxControl.Items.Add(AnioActual.ToString)
                Next
            Else
                For AnioActual As Integer = DateTime.Today.AddYears(1).Year To FechaInicioActividad.Year Step -1
                    ComboBoxControl.Items.Add(AnioActual.ToString)
                Next
            End If
        End If
    End Sub

    Friend Sub AnioLectivo(ByRef ListBoxControl As ListBox, ByVal LeerDesdeBaseDeDatos As Boolean, Optional ByVal Orden As SortOrder = SortOrder.Ascending)
        If LeerDesdeBaseDeDatos Then
            ListBoxControl.ValueMember = "AnioLectivo"
            ListBoxControl.DisplayMember = "AnioLectivo"

            Dim qryList = (From alc In mdbContext.AnioLectivoCurso
                           Order By alc.AnioLectivo
                           Select alc.AnioLectivo
                           Distinct).ToList

            If Orden = SortOrder.Ascending Then
                ListBoxControl.DataSource = qryList.OrderBy(Function(al) al).ToList
            Else
                ListBoxControl.DataSource = qryList.OrderByDescending(Function(al) al).ToList
            End If
        Else
            Dim FechaInicioActividad As Date

            ' Cargo de acuerdo a la Fecha de Inicio de Actividades o al Año actual, en su defecto
            FechaInicioActividad = CS_Parameter_System.GetDate(Parametros.EMPRESA_INICIO_ACTIVIDAD, DateTime.Today).Value
            If Orden = SortOrder.Ascending Then
                For AnioActual As Integer = FechaInicioActividad.Year To DateTime.Today.AddYears(1).Year
                    ListBoxControl.Items.Add(AnioActual.ToString)
                Next
            Else
                For AnioActual As Integer = DateTime.Today.AddYears(1).Year To FechaInicioActividad.Year Step -1
                    ListBoxControl.Items.Add(AnioActual.ToString)
                Next
            End If
        End If
    End Sub

    Friend Sub AnioLectivo(ByRef ListBoxControl As CheckedListBox, ByVal LeerDesdeBaseDeDatos As Boolean, Optional ByVal Orden As SortOrder = SortOrder.Ascending)
        If LeerDesdeBaseDeDatos Then
            ListBoxControl.ValueMember = "AnioLectivo"
            ListBoxControl.DisplayMember = "AnioLectivo"

            Dim qryList = (From alc In mdbContext.AnioLectivoCurso
                           Order By alc.AnioLectivo
                           Select alc.AnioLectivo
                           Distinct).ToList

            If Orden = SortOrder.Ascending Then
                ListBoxControl.DataSource = qryList.OrderBy(Function(al) al).ToList
            Else
                ListBoxControl.DataSource = qryList.OrderByDescending(Function(al) al).ToList
            End If
        Else
            Dim FechaInicioActividad As Date

            ' Cargo de acuerdo a la Fecha de Inicio de Actividades o al Año actual, en su defecto
            FechaInicioActividad = CS_Parameter_System.GetDate(Parametros.EMPRESA_INICIO_ACTIVIDAD, DateTime.Today).Value
            If Orden = SortOrder.Ascending Then
                For AnioActual As Integer = FechaInicioActividad.Year To DateTime.Today.AddYears(1).Year
                    ListBoxControl.Items.Add(AnioActual.ToString)
                Next
            Else
                For AnioActual As Integer = DateTime.Today.AddYears(1).Year To FechaInicioActividad.Year Step -1
                    ListBoxControl.Items.Add(AnioActual.ToString)
                Next
            End If
        End If
    End Sub

    Friend Sub MesNumeros(ByRef comboBoxControl As ComboBox, agregarItemTodos As Boolean, agregarItemNoEspecifica As Boolean)
        comboBoxControl.Items.Clear()
        comboBoxControl.Items.AddRange({1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})

        If agregarItemTodos Then
            comboBoxControl.Items.Insert(0, My.Resources.STRING_ITEM_ALL_MALE)
        End If
        If agregarItemNoEspecifica Then
            comboBoxControl.Items.Insert(0, My.Resources.STRING_ITEM_NOT_SPECIFIED)
        End If
    End Sub

    Friend Sub MesNombres(ByRef comboBoxControl As ComboBox, primeraLetraMayuscula As Boolean, agregarItemTodos As Boolean, agregarItemNoEspecifica As Boolean)
        comboBoxControl.Items.Clear()
        For mesNumero As Integer = 1 To 12
            Dim fullMonthName As String = New DateTime(2024, mesNumero, 1, 0, 0, 0, DateTimeKind.Local).ToString("MMMM", CultureInfo.CreateSpecificCulture("es-AR"))
            If primeraLetraMayuscula Then
                comboBoxControl.Items.Add(fullMonthName.ToTitleCase())
            Else
                comboBoxControl.Items.Add(fullMonthName)
            End If
        Next

        If agregarItemTodos Then
            comboBoxControl.Items.Insert(0, My.Resources.STRING_ITEM_ALL_MALE)
        End If
        If agregarItemNoEspecifica Then
            comboBoxControl.Items.Insert(0, My.Resources.STRING_ITEM_NOT_SPECIFIED)
        End If
    End Sub

    Friend Sub Nivel(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, Optional ByVal IDNivelMinimo As Byte = 0)
        ComboBoxControl.ValueMember = "IDNivel"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.Nivel
                      Where tbl.EsActivo AndAlso tbl.IDNivel >= IDNivelMinimo
                      Order By tbl.Nombre

        Dim localList = qryList.ToList
        If AgregarItem_Todos Then
            Dim Item_Todos As New Nivel
            Item_Todos.IDNivel = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            localList.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Nivel
            Item_NoEspecifica.IDNivel = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Turno(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        ComboBoxControl.ValueMember = "IDTurno"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.Turno
                      Where tbl.EsActivo
                      Order By tbl.Nombre
        Dim localList = qryList.ToList
        If AgregarItem_Todos Then
            Dim Item_Todos As New Turno
            Item_Todos.IDTurno = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            localList.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Turno
            Item_NoEspecifica.IDTurno = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub CuotaTipo(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        ComboBoxControl.ValueMember = "IDCuotaTipo"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In mdbContext.CuotaTipo
                      Where tbl.EsActivo
                      Order By tbl.Nombre

        Dim localList = qryList.ToList
        If AgregarItem_Todos Then
            Dim Item_Todos As New CuotaTipo
            Item_Todos.IDCuotaTipo = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            localList.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New CuotaTipo
            Item_NoEspecifica.IDCuotaTipo = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Curso(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, ByVal IncluyeNivelEnNombre As Boolean, Optional ByVal IDNivel As Byte = 0, Optional ByVal IDAnioMinimo As Byte = 0)
        Dim listCursos As List(Of Curso_ListItem)

        ComboBoxControl.ValueMember = "IDCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IncluyeNivelEnNombre Then
            listCursos = (From c In mdbContext.Curso
                          Join a In mdbContext.Anio On a.IDAnio Equals c.IDAnio
                          Join n In mdbContext.Nivel On n.IDNivel Equals a.IDNivel
                          Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
                          Order By n.Nombre, a.Nombre, t.Nombre, c.Division
                          Where a.EsActivo AndAlso (IDNivel = 0 OrElse a.IDNivel = IDNivel) AndAlso a.IDAnio >= IDAnioMinimo
                          Select New Curso_ListItem With {.IDCurso = c.IDCurso, .Descripcion = n.Nombre & " - " & a.Nombre & " - " & t.Nombre & " - " & c.Division}).ToList
        Else
            listCursos = (From c In mdbContext.Curso
                          Join a In mdbContext.Anio On a.IDAnio Equals c.IDAnio
                          Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
                          Order By a.Nombre, t.Nombre, c.Division
                          Where a.EsActivo AndAlso (IDNivel = 0 OrElse a.IDNivel = IDNivel) AndAlso a.IDAnio >= IDAnioMinimo
                          Select New Curso_ListItem With {.IDCurso = c.IDCurso, .Descripcion = a.Nombre & " - " & t.Nombre & " - " & c.Division}).ToList
        End If

        If AgregarItem_Todos Then
            Dim Item_Todos As New Curso_ListItem
            Item_Todos.IDCurso = 0
            Item_Todos.Descripcion = My.Resources.STRING_ITEM_ALL_MALE
            listCursos.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Curso_ListItem
            Item_NoEspecifica.IDCurso = 0
            Item_NoEspecifica.Descripcion = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listCursos.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listCursos
    End Sub

    Friend Sub CursoPorAnioLectivoYNivel(ByRef ComboBoxControl As ComboBox, ByVal AnioLectivo As Integer, Optional ByVal IDNivel As Byte? = Nothing)
        ComboBoxControl.ValueMember = "IDCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IDNivel Is Nothing Then
            Dim qryList = From tbl In mdbContext.AnioLectivoCurso
                          Where tbl.AnioLectivo = AnioLectivo
                          Order By tbl.AnioLectivo, tbl.Curso.Anio.Nivel.Nombre, tbl.Curso.Anio.Nombre, tbl.Curso.Turno.Nombre, tbl.Curso.Division
                          Select tbl.IDCurso, Descripcion = tbl.Curso.Anio.Nivel.Nombre & " - " & tbl.Curso.Anio.Nombre & " - " & tbl.Curso.Turno.Nombre & " - " & tbl.Curso.Division
            ComboBoxControl.DataSource = qryList.ToList
        Else
            Dim qryList = From tbl In mdbContext.AnioLectivoCurso
                          Where tbl.AnioLectivo = AnioLectivo AndAlso tbl.Curso.Anio.IDNivel = IDNivel
                          Order By tbl.AnioLectivo, tbl.Curso.Anio.Nombre, tbl.Curso.Turno.Nombre, tbl.Curso.Division
                          Select tbl.IDCurso, Descripcion = tbl.Curso.Anio.Nombre & " - " & tbl.Curso.Turno.Nombre & " - " & tbl.Curso.Division
            ComboBoxControl.DataSource = qryList.ToList
        End If
    End Sub

    Friend Sub AnioLectivoCurso(ByRef ComboBoxControl As ComboBox, ByVal AnioLectivoDesde As Integer, ByVal AnioLectivoHasta As Integer, ByVal IncluyeAnioLectivoEnDescripcion As Boolean, Optional ByVal IDEntidad As Integer? = Nothing)
        Dim listAnioLectivoCursos As List(Of AnioLectivoCursoListItem)

        ComboBoxControl.ValueMember = "IDAnioLectivoCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IncluyeAnioLectivoEnDescripcion Then
            If IDEntidad Is Nothing Then
                listAnioLectivoCursos = (From alc In mdbContext.AnioLectivoCurso
                                         Where alc.AnioLectivo >= AnioLectivoDesde AndAlso alc.AnioLectivo <= AnioLectivoHasta
                                         Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                         Select New AnioLectivoCursoListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.AnioLectivo.ToString & " - " & alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo, .IDCurso = alc.IDCurso}).ToList
            Else
                listAnioLectivoCursos = (From e In mdbContext.Entidad
                                         From alc In e.AniosLectivosCursos
                                         Where e.IDEntidad = IDEntidad AndAlso alc.AnioLectivo >= AnioLectivoDesde AndAlso alc.AnioLectivo <= AnioLectivoHasta
                                         Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                         Select New AnioLectivoCursoListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.AnioLectivo.ToString & " - " & alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo, .IDCurso = alc.IDCurso}).ToList
            End If
        Else
            If IDEntidad Is Nothing Then
                listAnioLectivoCursos = (From alc In mdbContext.AnioLectivoCurso
                                         Where alc.AnioLectivo >= AnioLectivoDesde AndAlso alc.AnioLectivo <= AnioLectivoHasta
                                         Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                         Select New AnioLectivoCursoListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo, .IDCurso = alc.IDCurso}).ToList
            Else
                listAnioLectivoCursos = (From e In mdbContext.Entidad
                                         From alc In e.AniosLectivosCursos
                                         Where e.IDEntidad = IDEntidad AndAlso alc.AnioLectivo >= AnioLectivoDesde AndAlso alc.AnioLectivo <= AnioLectivoHasta
                                         Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                         Select New AnioLectivoCursoListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo, .IDCurso = alc.IDCurso}).ToList
            End If
        End If

        ComboBoxControl.DataSource = listAnioLectivoCursos
    End Sub

    Friend Sub ComprobanteLote(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listComprobanteLote As List(Of ComprobanteLote)

        ComboBoxControl.ValueMember = "IDComprobanteLote"
        ComboBoxControl.DisplayMember = "Nombre"

        listComprobanteLote = mdbContext.ComprobanteLote.OrderByDescending(Function(cl) cl.FechaHora).ToList

        If AgregarItem_Todos Then
            Dim Item_Todos As New ComprobanteLote
            Item_Todos.IDComprobanteLote = -1
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listComprobanteLote.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New ComprobanteLote
            Item_NoEspecifica.IDComprobanteLote = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listComprobanteLote.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listComprobanteLote
    End Sub

    Friend Sub MedioPago(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean, ByVal EsChequeMostrar As Boolean, ByVal NoEsChequeMostrar As Boolean)
        Dim listMediosPago As List(Of MedioPago)

        ComboBoxControl.ValueMember = "IDMedioPago"
        ComboBoxControl.DisplayMember = "Nombre"

        If EsChequeMostrar AndAlso NoEsChequeMostrar Then
            listMediosPago = (From tbl In mdbContext.MedioPago
                              Where tbl.EsActivo
                              Order By tbl.Nombre).ToList
        ElseIf EsChequeMostrar Then
            listMediosPago = (From tbl In mdbContext.MedioPago
                              Where tbl.EsActivo AndAlso tbl.EsCheque
                              Order By tbl.Nombre).ToList
        ElseIf NoEsChequeMostrar Then
            listMediosPago = (From tbl In mdbContext.MedioPago
                              Where tbl.EsActivo AndAlso Not tbl.EsCheque
                              Order By tbl.Nombre).ToList
        Else
            listMediosPago = New List(Of MedioPago)
        End If

        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New MedioPago With {
                .IDMedioPago = 0,
                .Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            }
            listMediosPago.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = listMediosPago
    End Sub

    Friend Sub ChequeMotivoRechazo(ByRef ComboBoxControl As ComboBox, ByVal MostrarNombreCompleto As Boolean, ByVal AgregarItem_Todos As Boolean)
        Dim localList As List(Of ChequeMotivoRechazo)

        ComboBoxControl.ValueMember = "IDChequeMotivoRechazo"

        If MostrarNombreCompleto Then
            ComboBoxControl.DisplayMember = "NombreCompleto"
            localList = mdbContext.ChequeMotivoRechazo.Where(Function(cmr) cmr.EsActivo).OrderBy(Function(cmr) cmr.NombreCompleto).ToList
        Else
            ComboBoxControl.DisplayMember = "Nombre"
            localList = mdbContext.ChequeMotivoRechazo.Where(Function(cmr) cmr.EsActivo).OrderBy(Function(cmr) cmr.Nombre).ToList
        End If

        If AgregarItem_Todos Then
            localList.Insert(0, New ChequeMotivoRechazo With {
                .IDChequeMotivoRechazo = 0,
                .Nombre = My.Resources.STRING_ITEM_ALL_MALE,
                .NombreCompleto = My.Resources.STRING_ITEM_ALL_MALE
            })
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub Caja(ByRef ComboBoxControl As ComboBox, ByVal IDMedioPago As Byte?, ByVal ShowUnspecifiedItem As Boolean)
        Dim localList As List(Of Caja)

        ComboBoxControl.ValueMember = "IDCaja"
        ComboBoxControl.DisplayMember = "Nombre"

        If IDMedioPago Is Nothing OrElse IDMedioPago = 0 Then
            localList = (From c In mdbContext.Caja
                         Where c.EsActivo
                         Order By c.Nombre).ToList
        Else
            localList = (From c In mdbContext.Caja
                         From mp In c.MedioPago
                         Where c.EsActivo AndAlso mp.IDMedioPago = IDMedioPago
                         Order By c.Nombre
                         Select c).ToList
        End If

        If ShowUnspecifiedItem Then
            Dim UnspecifiedItem As New Caja
            UnspecifiedItem.IDCaja = 0
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            localList.Insert(0, UnspecifiedItem)
        End If

        ComboBoxControl.DataSource = localList
    End Sub

    Friend Sub ComprobanteAplicacionMotivo(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listComprobanteAplicacionMotivo As List(Of ComprobanteAplicacionMotivo)

        ComboBoxControl.ValueMember = "IDComprobanteAplicacionMotivo"
        ComboBoxControl.DisplayMember = "Nombre"

        listComprobanteAplicacionMotivo = mdbContext.ComprobanteAplicacionMotivo.OrderBy(Function(cl) cl.Nombre).ToList

        If AgregarItem_Todos Then
            Dim Item_Todos As New ComprobanteAplicacionMotivo
            Item_Todos.IDComprobanteAplicacionMotivo = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listComprobanteAplicacionMotivo.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New ComprobanteAplicacionMotivo
            Item_NoEspecifica.IDComprobanteAplicacionMotivo = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listComprobanteAplicacionMotivo.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listComprobanteAplicacionMotivo
    End Sub

    Friend Sub Articulo(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, Optional ByVal IDComprobanteTipo As Byte = 0)
        Dim listArticulos As List(Of Articulo)

        ComboBoxControl.ValueMember = "IDArticulo"
        ComboBoxControl.DisplayMember = "Nombre"

        If IDComprobanteTipo = 0 Then
            listArticulos = mdbContext.Articulo.Where(Function(a) a.EsActivo).OrderBy(Function(a) a.Nombre).ToList
        Else
            listArticulos = (From a In mdbContext.Articulo
                             Join ag In mdbContext.ArticuloGrupo On a.IDArticuloGrupo Equals ag.IDArticuloGrupo
                             Where a.EsActivo AndAlso ag.ComprobanteTipos.Where(Function(ct) ct.IDComprobanteTipo = IDComprobanteTipo).Any()
                             Order By a.Nombre
                             Select a).ToList
        End If

        If AgregarItem_Todos Then
            Dim Item_Todos As New Articulo
            Item_Todos.IDArticulo = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listArticulos.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Articulo
            Item_NoEspecifica.IDArticulo = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listArticulos.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listArticulos
    End Sub

    Friend Sub Comunicacion(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, Optional ByVal OrdenAscendente As Boolean = True)
        Dim listComunicaciones As List(Of Comunicacion)

        ComboBoxControl.ValueMember = "IDComunicacion"
        ComboBoxControl.DisplayMember = "Nombre"

        If OrdenAscendente Then
            listComunicaciones = mdbContext.Comunicacion.Where(Function(cl) cl.EsActivo).OrderBy(Function(cl) cl.Nombre).ToList
        Else
            listComunicaciones = mdbContext.Comunicacion.Where(Function(cl) cl.EsActivo).OrderByDescending(Function(cl) cl.Nombre).ToList
        End If

        If AgregarItem_Todos Then
            Dim Item_Todos As New Comunicacion
            Item_Todos.IDComunicacion = 0
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_FEMALE
            listComunicaciones.Insert(0, Item_Todos)
        End If
        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New Comunicacion
            Item_NoEspecifica.IDComunicacion = 0
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listComunicaciones.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listComunicaciones
    End Sub

    Friend Sub Comprobantes(ByVal IDComprobante As Integer)
        ' Refresco la lista de Comprobantes para mostrar los cambios
        If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "formComprobantes") Then
            Dim formComprobantes As formComprobantes = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "formComprobantes"), formComprobantes)
            formComprobantes.RefreshData(IDComprobante)
            formComprobantes = Nothing
        End If
    End Sub

    Friend Sub UsuarioGrupo(ByRef ComboBoxControl As ComboBox, ByVal MostrarGrupoAdministradores As Boolean, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listItems As List(Of UsuarioGrupo)

        ComboBoxControl.ValueMember = "IDUsuarioGrupo"
        ComboBoxControl.DisplayMember = "Nombre"

        If MostrarGrupoAdministradores Then
            listItems = mdbContext.UsuarioGrupo.Where(Function(ug) ug.EsActivo).OrderBy(Function(ug) ug.Nombre).ToList
        Else
            listItems = mdbContext.UsuarioGrupo.Where(Function(ug) ug.EsActivo AndAlso ug.IDUsuarioGrupo <> USUARIOGRUPO_ADMINISTRADORES_ID).OrderBy(Function(ug) ug.Nombre).ToList
        End If

        If AgregarItem_Todos Then
            Dim Item_Todos As New UsuarioGrupo
            Item_Todos.IDUsuarioGrupo = CardonerSistemas.Constants.FIELD_VALUE_ALL_BYTE
            Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
            listItems.Insert(0, Item_Todos)
        End If

        If AgregarItem_NoEspecifica Then
            Dim Item_NoEspecifica As New UsuarioGrupo
            Item_NoEspecifica.IDUsuarioGrupo = CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listItems.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listItems
    End Sub

    Friend Sub SueldoConcepto(ByRef comboBoxControl As ComboBox, agregarItemTodos As Boolean, agregarItemNoEspecifica As Boolean)
        Dim listItems As List(Of SueldoConcepto)

        comboBoxControl.ValueMember = "IdSueldoConcepto"
        comboBoxControl.DisplayMember = "Nombre"

        listItems = mdbContext.SueldoConcepto.Where(Function(sc) sc.EsActivo).OrderBy(Function(sc) sc.Nombre).ToList

        If agregarItemTodos Then
            listItems.Insert(0, New SueldoConcepto With {
                .IdSueldoConcepto = CardonerSistemas.Constants.FIELD_VALUE_ALL_SHORT,
                .Nombre = My.Resources.STRING_ITEM_ALL_MALE
            })
        End If

        If agregarItemNoEspecifica Then
            listItems.Insert(0, New SueldoConcepto With {
                .IdSueldoConcepto = CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE,
                .Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            })
        End If

        comboBoxControl.DataSource = listItems
    End Sub

End Class
