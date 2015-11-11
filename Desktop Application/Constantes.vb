Module Constantes
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

    Friend Const MOVIMIENTOTIPO_CREDITO As String = "C"
    Friend Const MOVIMIENTOTIPO_DEBITO As String = "D"

    Friend Const COMPROBANTE_PUNTOVENTA_CARACTERES As Byte = 4
    Friend Const COMPROBANTE_NUMERO_CARACTERES As Byte = 8

    Friend Const COMPROBANTE_CONCEPTO_PRODUCTO As Byte = 1
    Friend Const COMPROBANTE_CONCEPTO_SERVICIOS As Byte = 2
    Friend Const COMPROBANTE_CONCEPTO_PRODUCTOSYSERVICIOS As Byte = 3
    Friend Const COMPROBANTE_CONCEPTO_OTROS As Byte = 4

    Friend Const CHEQUE_ESTADO_ENCARTERA As String = "EC"
    Friend Const CHEQUE_ESTADO_ENTREGADO As String = "ET"
    Friend Const CHEQUE_ESTADO_ENTREGADO_RECHAZADO As String = "ER"
    Friend Const CHEQUE_ESTADO_COBRADOPORVENTANILLA As String = "CV"
    Friend Const CHEQUE_ESTADO_NEGOCIADO As String = "NE"
    Friend Const CHEQUE_ESTADO_DEPOSITADO_PENDIENTE As String = "DP"
    Friend Const CHEQUE_ESTADO_DEPOSITADO_ACREDITADO As String = "DA"
    Friend Const CHEQUE_ESTADO_DEPOSITADO_RECHAZADO_ENBANCO As String = "DR"
    Friend Const CHEQUE_ESTADO_DEPOSITADO_RECHAZADO_ENCARTERA As String = "DC"
    Friend Const CHEQUE_ESTADO_DEPOSITADO_RECHAZADO_DEVUELTO As String = "DV"

    '//////////////////
    '    E-MAIL
    '//////////////////
    Friend Const EMAIL_CLIENT_NETDLL As String = "NETCLIENT"
    Friend Const EMAIL_CLIENT_MSOUTLOOK As String = "MSOUTLOOK"
    Friend Const EMAIL_CLIENT_CRYSTALREPORTSMAPI As String = "CRYSTALMAPI"

    '///////////////////////////////////
    '    PARÁMETROS DE LOS REPORTES
    '///////////////////////////////////
    Friend Const REPORTE_PARAMETRO_ENTIDAD As String = "ENTI"
    Friend Const REPORTE_PARAMETRO_ENTIDAD_PERSONALCOLEGIO As String = "ENPC"
    Friend Const REPORTE_PARAMETRO_ENTIDAD_DOCENTE As String = "ENDO"
    Friend Const REPORTE_PARAMETRO_ENTIDAD_ALUMNO As String = "ENAL"
    Friend Const REPORTE_PARAMETRO_ENTIDAD_FAMILIAR As String = "ENFA"
    Friend Const REPORTE_PARAMETRO_ENTIDAD_PROVEEDOR As String = "ENPR"

    Friend Const REPORTE_PARAMETRO_TIPO_NUMBER_INTEGER As String = "NUIN"
    Friend Const REPORTE_PARAMETRO_TIPO_NUMBER_DECIMAL As String = "NUDE"
    Friend Const REPORTE_PARAMETRO_TIPO_MONEY As String = "MONY"
    Friend Const REPORTE_PARAMETRO_TIPO_DATETIME As String = "DATI"
    Friend Const REPORTE_PARAMETRO_TIPO_DATE As String = "DATE"
    Friend Const REPORTE_PARAMETRO_TIPO_TIME As String = "TIME"
    Friend Const REPORTE_PARAMETRO_TIPO_YEAR_MONTH_FROM As String = "YMFR"
    Friend Const REPORTE_PARAMETRO_TIPO_YEAR_MONTH_TO As String = "YMTO"
    Friend Const REPORTE_PARAMETRO_TIPO_SINO As String = "SINO"
End Module
