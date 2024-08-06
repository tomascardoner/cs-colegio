Namespace Comunes.Forms
    Module SueldosLiquidaciones
        Friend Function InstanciaActual() As FormLiquidaciones
            Return CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), FormLiquidaciones.Name), FormLiquidaciones)
        End Function

        Friend Function InstanciaActualONueva() As FormLiquidaciones
            Return If(InstanciaActual(), New FormLiquidaciones())
        End Function
    End Module
End Namespace