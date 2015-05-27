Module Constants
    '//////////////////
    '    APLICACIÓN
    '//////////////////
    Friend Const APPLICATION_DATABASE_GUID As String = "{57FC36AB-60E1-4ded-BE7A-6337258CDAED}"
    Friend Const FILTER_ACTIVO_LIST_INDEX As Long = 1

    '//////////////////
    '    BÁSICAS
    '//////////////////
    Friend Const KEY_STRINGER As String = "@"
    Friend Const KEY_DELIMITER As String = "|@|"

    Friend Const STRING_LIST_SEPARATOR As String = "|"
    Friend Const STRING_LIST_DELIMITER As String = "¬"

    Friend Const DATE_TIME_FIELD_NULL_VALUE As Date = #12:00:00 AM#


    '//////////////////
    '    PARAMETROS
    '//////////////////
    Friend Const PARAMETRO_APPLICATION_DATABASE_GUID As String = "APPLICATION_DATABASE_GUID"
    Friend Const PARAMETRO_LICENSE_COMPANY_NAME As String = "LICENSE_COMPANY_NAME"
    Friend Const PARAMETRO_PROVINCIA_PREDETERMINADA As String = "PROVINCIA_PREDETERMINADA"
    Friend Const PARAMETRO_LOCALIDAD_PREDETERMINADA As String = "LOCALIDAD_PREDETERMINADA"
    Friend Const PARAMETRO_CODIGOPOSTAL_PREDETERMINADO As String = "CODIGOPOSTAL_PREDETERMINADO"
    Friend Const PARAMETRO_CATEGORIAIVA_PREDETERMINADA As String = "CATEGORIAIVA_PREDETERMINADA"
    Friend Const PARAMETRO_ARTICULO_CUOTA_MENSUAL As String = "ARTICULO_CUOTA_MENSUAL"
    Friend Const PARAMETRO_COMPROBANTE_ENTIDAD_MAYUSCULAS As String = "COMPROBANTE_ENTIDAD_MAYUSCULAS"


    '//////////////////
    '    VARIOS
    '//////////////////
    Friend Const GENERO_NOESPECIFICA As String = "-"
    Friend Const GENERO_MASCULINO As String = "M"
    Friend Const GENERO_FEMENINO As String = "F"

    Friend Const PROVINCIA_NOESPECIFICA As Byte = 255

    Friend Const ENTIDADFACTURA_NOESPECIFICA As String = "-"
    Friend Const ENTIDADFACTURA_PADRE As String = "P"
    Friend Const ENTIDADFACTURA_MADRE As String = "M"
    Friend Const ENTIDADFACTURA_AMBOSPADRES As String = "2"
    Friend Const ENTIDADFACTURA_ALUMNO As String = "A"

    Friend Const OPERACIONTIPO_COMPRA As String = "C"
    Friend Const OPERACIONTIPO_VENTA As String = "V"
End Module
