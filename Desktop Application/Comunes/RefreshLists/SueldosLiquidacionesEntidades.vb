Namespace Comunes.RefreshLists
    Module SueldosLiquidacionesEntidades
        Friend Sub Refresh(Optional idEntidad As Integer = 0)
            Forms.SueldosLiquidacionesEntidades.InstanciaActual?.ReadData(idEntidad)
        End Sub
    End Module
End Namespace