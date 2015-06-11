Module Constantes
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
