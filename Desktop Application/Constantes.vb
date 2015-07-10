﻿Module Constantes
    '//////////////////
    '    APLICACIÓN
    '//////////////////
    Friend Const APPLICATION_DATABASE_GUID As String = "{57FC36AB-60E1-4ded-BE7A-6337258CDAED}"
    Friend Const FILTER_ACTIVO_LIST_INDEX As Long = 1
    Friend Const ENCRYPTION_PASSWORD As String = "CmcaTlMdmA,aTmP,am2CyalhdEb"
    Friend Const ENCRYPTION_VECTOR As String = "DaVsmpca#Tmd1Bv@"

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

    Friend Const EMITIRFACTURAA_NOESPECIFICA As String = "-"
    Friend Const EMITIRFACTURAA_PADRE As String = "P"
    Friend Const EMITIRFACTURAA_MADRE As String = "M"
    Friend Const EMITIRFACTURAA_AMBOSPADRES As String = "2"
    Friend Const EMITIRFACTURAA_TERCERO As String = "T"
    Friend Const EMITIRFACTURAA_TODOS As String = "3"
    Friend Const EMITIRFACTURAA_ALUMNO As String = "A"

    Friend Const OPERACIONTIPO_COMPRA As String = "C"
    Friend Const OPERACIONTIPO_VENTA As String = "V"

    Friend Const COMPROBANTE_NUMERO_CARACTERES As Byte = 8

    '//////////////////
    '    E-MAIL
    '//////////////////
    Friend Const EMAIL_CLIENT_NETDLL As String = "NETCLIENT"
    Friend Const EMAIL_CLIENT_MSOUTLOOK As String = "MSOUTLOOK"
    Friend Const EMAIL_CLIENT_CRYSTALREPORTSMAPI As String = "CRYSTALMAPI"
End Module
