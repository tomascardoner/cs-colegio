Module FillAndRefreshLists
    Friend Sub DocumentoTipo(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDDocumentoTipo"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbContext As New CSColegioContext
            Dim qryList = From tbl In dbContext.DocumentoTipo
                          Where tbl.Activo
                          Order By tbl.Nombre

            Dim localList = qryList.ToList
            If ShowUnspecifiedItem Then
                Dim UnspecifiedItem As New DocumentoTipo
                UnspecifiedItem.IDDocumentoTipo = 0
                UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
                localList.Insert(0, UnspecifiedItem)
            End If

            ComboBoxControl.DataSource = localList
        End Using
    End Sub

    Friend Sub CategoriaIVA(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDCategoriaIVA"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbContext As New CSColegioContext
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
        End Using
    End Sub

    Friend Sub Provincia(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDProvincia"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbContext As New CSColegioContext
            Dim qryList = From tbl In dbContext.Provincia
                          Order By tbl.Nombre

            Dim localList = qryList.ToList
            If ShowUnspecifiedItem Then
                Dim UnspecifiedItem As New Provincia
                UnspecifiedItem.IDProvincia = "-"
                UnspecifiedItem.Nombre = My.Resources.STRING_ITEM_NON_SPECIFIED
                localList.Insert(0, UnspecifiedItem)
            End If

            ComboBoxControl.DataSource = localList
        End Using
    End Sub

    Friend Sub Localidad(ByRef ComboBoxControl As ComboBox, ByVal IDProvincia As String, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDLocalidad"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbContext As New CSColegioContext
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
        End Using
    End Sub

    Friend Sub ComprobanteTipo(ByRef ComboBoxControl As ComboBox, ByVal OperacionTipo As String, ByVal ShowUnspecifiedItem As Boolean)
        ComboBoxControl.ValueMember = "IDComprobanteTipo"
        ComboBoxControl.DisplayMember = "Nombre"

        Using dbContext As New CSColegioContext
            Dim qryList = From tbl In dbContext.ComprobanteTipo
                          Where tbl.OperacionTipo = OperacionTipo And tbl.EsActivo
                          Order By tbl.Nombre

            Dim localList = qryList.ToList
            If ShowUnspecifiedItem Then
                Dim UnspecifiedItem As New ComprobanteTipo
                UnspecifiedItem.IDComprobanteTipo = 0
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
                datarowRow("IDGenero") = "-"
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

    Friend Sub EntidadFactura(ByRef ComboBoxControl As ComboBox, ByVal ShowUnspecifiedItem As Boolean)
        Dim datatableEntidadFactura As New DataTable("EntidadFactura")
        Dim datarowRow As DataRow

        ComboBoxControl.ValueMember = "IDEntidadFactura"
        ComboBoxControl.DisplayMember = "Nombre"

        With datatableEntidadFactura
            .Columns.Add("IDEntidadFactura", System.Type.GetType("System.String"))
            .Columns.Add("Nombre", System.Type.GetType("System.String"))

            If ShowUnspecifiedItem Then
                datarowRow = .NewRow
                datarowRow("IDEntidadFactura") = "-"
                datarowRow("Nombre") = My.Resources.STRING_ITEM_NON_SPECIFIED
                datatableEntidadFactura.Rows.Add(datarowRow)
            End If

            datarowRow = .NewRow
            datarowRow("IDEntidadFactura") = "P"
            datarowRow("Nombre") = My.Resources.STRING_ENTIDADFACTURA_PADRE
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEntidadFactura") = "M"
            datarowRow("Nombre") = My.Resources.STRING_ENTIDADFACTURA_MADRE
            datatableEntidadFactura.Rows.Add(datarowRow)

            datarowRow = .NewRow
            datarowRow("IDEntidadFactura") = "A"
            datarowRow("Nombre") = My.Resources.STRING_ENTIDADFACTURA_ALUMNO
            datatableEntidadFactura.Rows.Add(datarowRow)
        End With

        ComboBoxControl.DataSource = datatableEntidadFactura
    End Sub
End Module
