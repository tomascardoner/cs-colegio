Namespace Comunes.RefreshLists
    Module SueldosCalculosModulos
        Friend Sub Refresh(Optional mes As Byte = 0, Optional idSueldoConcepto As Short = 0)
            Forms.SueldosCalculosModulos.InstanciaActual?.ReadData(mes, idSueldoConcepto)
        End Sub
    End Module
End Namespace