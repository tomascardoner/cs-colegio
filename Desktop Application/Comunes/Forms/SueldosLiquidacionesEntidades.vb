Namespace Comunes.Forms
    Module SueldosLiquidacionesEntidades
        Friend Function InstanciaActual() As FormLiquidacionesEntidades
            Return CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), FormLiquidacionesEntidades.Name), FormLiquidacionesEntidades)
        End Function

        Friend Function InstanciaActualONueva() As FormLiquidacionesEntidades
            Return If(InstanciaActual(), New FormLiquidacionesEntidades())
        End Function
    End Module
End Namespace