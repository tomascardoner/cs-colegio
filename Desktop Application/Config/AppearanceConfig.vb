Public Class AppearanceConfig
    Public Property EnableVisualStyles As Boolean
    Public Property MinimumSplashScreenDisplaySeconds As Integer
    Public Property ShowLastLoggedInUser As Boolean
    Public Property UseCustomDialogForErrorMessage As Boolean
    Public Property ListsFontName As String
    Public Property ListsFontSize As Single
    Public Property ListsFontBold As Boolean

    Private _ListsFont As Font

    Friend Property ListsFont As Font
        Get
            If _ListsFont Is Nothing Then
                If ListsFontName.Length > 0 AndAlso ListsFontSize > 0 Then
                    Try
                        _ListsFont = New Font(ListsFontName, ListsFontSize, CType(IIf(ListsFontBold, FontStyle.Bold, FontStyle.Regular), FontStyle))
                    Catch ex As Exception

                    End Try
                End If
            End If
            Return _ListsFont
        End Get
        Set(value As Font)
            _ListsFont = value
            If _ListsFont Is Nothing Then
                ListsFontName = ""
                ListsFontSize = 0
                ListsFontBold = False
            Else
                ListsFontName = _ListsFont.Name
                ListsFontSize = _ListsFont.Size
                ListsFontBold = _ListsFont.Bold
            End If
        End Set
    End Property

End Class
