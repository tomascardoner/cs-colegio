Namespace Comunes.RefreshLists
    Module SueldosLiquidaciones
        Friend Sub Refresh(Optional idLiquidacionSueldo As Short = 0)
            Forms.SueldosLiquidaciones.InstanciaActual?.ReadData(idLiquidacionSueldo)
        End Sub
    End Module
End Namespace