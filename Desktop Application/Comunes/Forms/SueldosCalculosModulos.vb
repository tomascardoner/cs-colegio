Namespace Comunes.Forms
    Module SueldosCalculosModulos
        Friend Function InstanciaActual() As FormCalculosModulos
            Return CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), FormCalculosModulos.Name), FormCalculosModulos)
        End Function

        Friend Function InstanciaActualONueva() As FormCalculosModulos
            Return If(InstanciaActual(), New FormCalculosModulos())
        End Function
    End Module
End Namespace