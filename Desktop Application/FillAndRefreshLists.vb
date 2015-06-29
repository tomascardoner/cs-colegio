Module FillAndRefreshLists
    Friend Sub DocumentoTipo(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDDocumentoTipo"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.DocumentoTipo
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
        End Using
    End Sub

    Friend Sub CategoriaIVA(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDCategoriaIVA"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.CategoriaIVA
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
        End Using
    End Sub

    Friend Sub Provincia(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDProvincia"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.Provincia
                          Order By tbl.Nombre

            Dim localList = qryList.ToList
            If ShowUnspecifiedItem Then
                Dim UnspecifiedItem As New Provincia
                UnspecifiedItem.IDProvincia = Constantes.PROVINCIA_NOESPECIFICA
                UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
                localList.Insert(0, UnspecifiedItem)
            End If

            ComboBoxControl.DataSource = localList
        End Using
    End Sub

    Friend Sub Localidad(ByRef ComboBoxControl As ComboBox, ByVal IDProvincia As Byte, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDLocalidad"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.Localidad
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
        End Using
    End Sub

    Friend Sub ComprobanteTipo(ByRef ComboBoxControl As ComboBox, ByVal OperacionTipo As String, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        Dim localList As List(Of ComprobanteTipo)

        ComboBoxControl.ValueMember = "IDComprobanteTipo"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            If OperacionTipo = "" Then
                Dim qryList = From tbl In dbcontext.ComprobanteTipo
                              Where tbl.EsActivo
                              Order By tbl.Nombre

                localList = qryList.ToList
            Else
                Dim qryList = From tbl In dbcontext.ComprobanteTipo
                              Where tbl.OperacionTipo = OperacionTipo And tbl.EsActivo
                              Order By tbl.Nombre

                localList = qryList.ToList
            End If

            If AgregarItem_Todos Then
                Dim UnspecifiedItem As New ComprobanteTipo
                UnspecifiedItem.IDComprobanteTipo = Byte.MaxValue
                UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_ALL_MALE
                localList.Insert(0, UnspecifiedItem)
            End If
            If AgregarItem_NoEspecifica Then
                Dim UnspecifiedItem As New ComprobanteTipo
                UnspecifiedItem.IDComprobanteTipo = Byte.MinValue
                UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
                localList.Insert(0, UnspecifiedItem)
            End If

            ComboBoxControl.DataSource = localList
        End Using
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

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.Descuento
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
        End Using
    End Sub

    Friend Sub AnioLectivo(ByRef ComboBoxControl As ComboBox, Optional ByVal Orden As SortOrder = SortOrder.Ascending)
        ComboBoxControl.ValueMember = "AnioLectivo"
        ComboBoxControl.DisplayMember = "AnioLectivo"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.AnioLectivoCurso
                          Select tbl.AnioLectivo
                          Distinct

            If Orden = SortOrder.Descending Then
                ComboBoxControl.DataSource = qryList.OrderByDescending(Function(al) al).ToList
            Else
                ComboBoxControl.DataSource = qryList.OrderBy(Function(al) al).ToList
            End If
        End Using
    End Sub

    Friend Sub Nivel(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDNivel"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.Nivel
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
        End Using
    End Sub

    Friend Sub CursoPorAnioLectivoYNivel(ByRef ComboBoxControl As ComboBox, ByVal AnioLectivo As Integer, Optional ByVal IDNivel As Byte? = Nothing)
        ComboBoxControl.ValueMember = "IDCurso"
        ComboBoxControl.DisplayMember = "Descripcion"

        Using dbcontext As New CSColegioContext(True)
            If IDNivel Is Nothing Then
                Dim qryList = From tbl In dbcontext.AnioLectivoCurso
                              Where tbl.AnioLectivo = AnioLectivo
                              Order By tbl.Curso.Anio.Nivel.Nombre, tbl.Curso.Anio.Nombre, tbl.Curso.Turno.Nombre, tbl.Curso.Division
                              Select tbl.IDCurso, Descripcion = tbl.Curso.Anio.Nivel.Nombre & " - " & tbl.Curso.Anio.Nombre & " - " & tbl.Curso.Turno.Nombre & " - " & tbl.Curso.Division
                ComboBoxControl.DataSource = qryList.ToList
            Else
                Dim qryList = From tbl In dbcontext.AnioLectivoCurso
                              Where tbl.AnioLectivo = AnioLectivo And tbl.Curso.Anio.IDNivel = IDNivel
                              Order By tbl.Curso.Anio.Nombre, tbl.Curso.Turno.Nombre, tbl.Curso.Division
                              Select tbl.IDCurso, Descripcion = tbl.Curso.Anio.Nombre & " - " & tbl.Curso.Turno.Nombre & " - " & tbl.Curso.Division
                ComboBoxControl.DataSource = qryList.ToList
            End If
        End Using
    End Sub

    Friend Sub ComprobanteLote(ByRef ComboBoxControl As ComboBox, ByVal AgregarItem_Todos As Boolean, ByVal AgregarItem_NoEspecifica As Boolean)
        ComboBoxControl.ValueMember = "IDComprobanteLote"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbcontext As New CSColegioContext(True)
            Dim qryList = From tbl In dbcontext.ComprobanteLote
                          Order By tbl.FechaHora Descending

            Dim localList = qryList.ToList

            If AgregarItem_Todos Then
                Dim Item_Todos As New ComprobanteLote
                Item_Todos.IDComprobanteLote = -1
                Item_Todos.Nombre = My.Resources.STRING_ITEM_ALL_MALE
                localList.Insert(0, Item_Todos)
            End If
            If AgregarItem_NoEspecifica Then
                Dim Item_NoEspecifica As New ComprobanteLote
                Item_NoEspecifica.IDComprobanteLote = 0
                Item_NoEspecifica.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
                localList.Insert(0, Item_NoEspecifica)
            End If

            ComboBoxControl.DataSource = localList
        End Using
    End Sub
End Module
