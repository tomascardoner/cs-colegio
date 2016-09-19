Friend Class FillAndRefreshLists

#Region "Declarations..."
    Friend dbContext As CSColegioContext

    Public Class AnioLectivoCurso_ListItem
        Public Property IDAnioLectivoCurso As Short
        Public Property Descripcion As String
        Public Property AnioLectivo As Short
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
            listAnios = (From a In dbContext.Anio
                         Join n In dbContext.Nivel On a.IDNivel Equals n.IDNivel
                         Where a.EsActivo And a.IDAnio <> Excluye_IDAnio And (IDNivel = 0 Or a.IDNivel = IDNivel)
                         Select New Anio_ListItem With {.IDAnio = a.IDAnio, .Descripcion = n.Nombre & " - " & a.Nombre}).ToList
        Else
            listAnios = (From a In dbContext.Anio
                         Where a.EsActivo And a.IDAnio <> Excluye_IDAnio And (IDNivel = 0 Or a.IDNivel = IDNivel)
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
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
                datarowRow("IDGenero") = Constantes.ENTIDAD_GENERO_NOESPECIFICA
                datarowRow("Nombre") = My.Resources.STRING_ITEM_NOT_SPECIFIED
                .Rows.Add(datarowRow)
            End If

            datarowRow = .NewRow
            datarowRow("IDGenero") = Constantes.ENTIDAD_GENERO_MASCULINO
            datarowRow("Nombre") = My.Resources.STRING_GENERO_MASCULINO
            .Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDGenero") = Constantes.ENTIDAD_GENERO_FEMENINO
            datarowRow("Nombre") = My.Resources.STRING_GENERO_FEMENINO
            .Rows.Add(datarowRow)
        End With

        ComboBoxControl.DataSource = datatableGeneros
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

        Dim qryList = From tbl In dbContext.Descuento
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

            Dim qryList = (From alc In dbContext.AnioLectivoCurso
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
            FechaInicioActividad = CS_Parameter.GetDate(Parametros.EMPRESA_INICIO_ACTIVIDAD, DateTime.Today).Value
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

    Friend Sub Mes(ByRef ComboBoxControl As ComboBox, ByVal MostrarNombreDelMes As Boolean, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        If MostrarNombreDelMes Then
            ComboBoxControl.Items.AddRange({"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Else
            ComboBoxControl.Items.AddRange({1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12})
        End If

        If AgregarItem_Todos Then
            ComboBoxControl.Items.Insert(0, My.Resources.STRING_ITEM_ALL_MALE)
        End If
        If AgregarItem_NoEspecifica Then
            ComboBoxControl.Items.Insert(0, My.Resources.STRING_ITEM_NOT_SPECIFIED)
        End If
    End Sub

    Friend Sub Nivel(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, Optional ByVal IDNivelMinimo As Byte = 0)
        ComboBoxControl.ValueMember = "IDNivel"
        ComboBoxControl.DisplayMember = "Nombre"

        Dim qryList = From tbl In dbContext.Nivel
                          Where tbl.EsActivo And tbl.IDNivel >= IDNivelMinimo
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

        Dim qryList = From tbl In dbContext.Turno
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

    Friend Sub Curso(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean, ByVal IncluyeNivelEnNombre As Boolean, Optional ByVal IDNivel As Byte = 0, Optional ByVal IDAnioMinimo As Byte = 0)
        Dim listCursos As List(Of Curso_ListItem)

        ComboBoxControl.ValueMember = "IDCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IncluyeNivelEnNombre Then
            listCursos = (From c In dbContext.Curso
                          Join a In dbContext.Anio On a.IDAnio Equals c.IDAnio
                          Join n In dbContext.Nivel On n.IDNivel Equals a.IDNivel
                          Join t In dbContext.Turno On c.IDTurno Equals t.IDTurno
                          Order By n.Nombre, a.Nombre, t.Nombre, c.Division
                          Where a.EsActivo And (IDNivel = 0 Or a.IDNivel = IDNivel) And a.IDAnio >= IDAnioMinimo
                          Select New Curso_ListItem With {.IDCurso = c.IDCurso, .Descripcion = n.Nombre & " - " & a.Nombre & " - " & t.Nombre & " - " & c.Division}).ToList
        Else
            listCursos = (From c In dbContext.Curso
                          Join a In dbContext.Anio On a.IDAnio Equals c.IDAnio
                          Join t In dbContext.Turno On c.IDTurno Equals t.IDTurno
                          Order By a.Nombre, t.Nombre, c.Division
                          Where a.EsActivo And (IDNivel = 0 Or a.IDNivel = IDNivel) And a.IDAnio >= IDAnioMinimo
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

    Friend Sub AnioLectivoCurso(ByRef ComboBoxControl As ComboBox, ByVal AnioLectivoDesde As Integer, ByVal AnioLectivoHasta As Integer, ByVal IncluyeAnioLectivoEnDescripcion As Boolean, Optional ByVal IDEntidad As Integer? = Nothing)
        Dim listAnioLectivoCursos As List(Of AnioLectivoCurso_ListItem)

        ComboBoxControl.ValueMember = "IDAnioLectivoCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        If IncluyeAnioLectivoEnDescripcion Then
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
        Else
            If IDEntidad Is Nothing Then
                listAnioLectivoCursos = (From alc In dbContext.AnioLectivoCurso
                                         Where alc.AnioLectivo >= AnioLectivoDesde And alc.AnioLectivo <= AnioLectivoHasta
                                         Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                         Select New AnioLectivoCurso_ListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo}).ToList
            Else
                listAnioLectivoCursos = (From e In dbContext.Entidad
                                         From alc In e.AniosLectivosCursos
                                         Where e.IDEntidad = IDEntidad And alc.AnioLectivo >= AnioLectivoDesde And alc.AnioLectivo <= AnioLectivoHasta
                                         Order By alc.AnioLectivo Descending, alc.Curso.Anio.Nivel.Nombre, alc.Curso.Anio.Nombre, alc.Curso.Turno.Nombre, alc.Curso.Division
                                         Select New AnioLectivoCurso_ListItem With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .Descripcion = alc.Curso.Anio.Nivel.Nombre & " - " & alc.Curso.Anio.Nombre & " - " & alc.Curso.Turno.Nombre & " - " & alc.Curso.Division, .AnioLectivo = alc.AnioLectivo}).ToList
            End If
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
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
            UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
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
            Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NOT_SPECIFIED
            listComprobanteAplicacionMotivo.Insert(0, Item_NoEspecifica)
        End If

        ComboBoxControl.DataSource = listComprobanteAplicacionMotivo
    End Sub

    Friend Sub Articulo(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listArticulos As List(Of Articulo)

        ComboBoxControl.ValueMember = "IDArticulo"
        ComboBoxControl.DisplayMember = "Nombre"

        listArticulos = dbContext.Articulo.Where(Function(cl) cl.EsActivo).OrderBy(Function(cl) cl.Nombre).ToList

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

    Friend Sub Comunicacion(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim listComunicaciones As List(Of Comunicacion)

        ComboBoxControl.ValueMember = "IDComunicacion"
        ComboBoxControl.DisplayMember = "Nombre"

        listComunicaciones = dbContext.Comunicacion.Where(Function(cl) cl.EsActivo).OrderBy(Function(cl) cl.Nombre).ToList

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

    Public Sub New()
        dbContext = New CSColegioContext(True)
    End Sub

    Protected Overrides Sub Finalize()
        dbContext.Dispose()
        MyBase.Finalize()
    End Sub
End Class
