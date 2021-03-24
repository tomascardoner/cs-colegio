'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Usuario
    Public Property IDUsuario As Short
    Public Property Nombre As String
    Public Property Descripcion As String
    Public Property Password As String
    Public Property Genero As String
    Public Property IDUsuarioGrupo As Byte
    Public Property EsActivo As Boolean
    Public Property IDUsuarioCreacion As Short
    Public Property FechaHoraCreacion As Date
    Public Property IDUsuarioModificacion As Short
    Public Property FechaHoraModificacion As Date

    Public Overridable Property UsuarioGrupo As UsuarioGrupo
    Public Overridable Property EntidadesCreadas As ICollection(Of Entidad) = New HashSet(Of Entidad)
    Public Overridable Property EntidadesModificadas As ICollection(Of Entidad) = New HashSet(Of Entidad)
    Public Overridable Property ComprobantesCreados As ICollection(Of Comprobante) = New HashSet(Of Comprobante)
    Public Overridable Property ComprobantesModificados As ICollection(Of Comprobante) = New HashSet(Of Comprobante)
    Public Overridable Property Log As ICollection(Of Log) = New HashSet(Of Log)
    Public Overridable Property ComprobantesEnviadosPorEmail As ICollection(Of Comprobante) = New HashSet(Of Comprobante)
    Public Overridable Property ComunicacionesCreadas As ICollection(Of Comunicacion) = New HashSet(Of Comunicacion)
    Public Overridable Property ComunicacionesModificadas As ICollection(Of Comunicacion) = New HashSet(Of Comunicacion)
    Public Overridable Property ComunicacionesEntidadesEnviadas As ICollection(Of ComunicacionEntidad) = New HashSet(Of ComunicacionEntidad)
    Public Overridable Property CuotaTipos As ICollection(Of CuotaTipo) = New HashSet(Of CuotaTipo)
    Public Overridable Property CuotaTipo1 As ICollection(Of CuotaTipo) = New HashSet(Of CuotaTipo)
    Public Overridable Property AniosCreados As ICollection(Of Anio) = New HashSet(Of Anio)
    Public Overridable Property AniosModificados As ICollection(Of Anio) = New HashSet(Of Anio)
    Public Overridable Property ArticulosCreados As ICollection(Of Articulo) = New HashSet(Of Articulo)
    Public Overridable Property ArticulosModificados As ICollection(Of Articulo) = New HashSet(Of Articulo)
    Public Overridable Property ArticuloGruposCreados As ICollection(Of ArticuloGrupo) = New HashSet(Of ArticuloGrupo)
    Public Overridable Property ArticuloGruposModificados As ICollection(Of ArticuloGrupo) = New HashSet(Of ArticuloGrupo)
    Public Overridable Property BancosCreados As ICollection(Of Banco) = New HashSet(Of Banco)
    Public Overridable Property BancosModificados As ICollection(Of Banco) = New HashSet(Of Banco)
    Public Overridable Property CajasCreadas As ICollection(Of Caja) = New HashSet(Of Caja)
    Public Overridable Property CajasModificadas As ICollection(Of Caja) = New HashSet(Of Caja)
    Public Overridable Property ChequerasCreadas As ICollection(Of Chequera) = New HashSet(Of Chequera)
    Public Overridable Property ChequerasModificadas As ICollection(Of Chequera) = New HashSet(Of Chequera)
    Public Overridable Property ComprobantesAnulados As ICollection(Of Comprobante) = New HashSet(Of Comprobante)
    Public Overridable Property ComprobantesTransmitidosAFIP As ICollection(Of Comprobante) = New HashSet(Of Comprobante)
    Public Overridable Property ComprobanteLotesCreados As ICollection(Of ComprobanteLote) = New HashSet(Of ComprobanteLote)
    Public Overridable Property ComprobanteLotesModificados As ICollection(Of ComprobanteLote) = New HashSet(Of ComprobanteLote)
    Public Overridable Property ComprobanteTiposCreados As ICollection(Of ComprobanteTipo) = New HashSet(Of ComprobanteTipo)
    Public Overridable Property ComprobanteTiposModificados As ICollection(Of ComprobanteTipo) = New HashSet(Of ComprobanteTipo)
    Public Overridable Property CursosCreados As ICollection(Of Curso) = New HashSet(Of Curso)
    Public Overridable Property CursosModificados As ICollection(Of Curso) = New HashSet(Of Curso)
    Public Overridable Property EntidadEntidadesCreadas As ICollection(Of EntidadEntidad) = New HashSet(Of EntidadEntidad)
    Public Overridable Property EntidadEntidadesModificadas As ICollection(Of EntidadEntidad) = New HashSet(Of EntidadEntidad)
    Public Overridable Property ImpuestosCreados As ICollection(Of Impuesto) = New HashSet(Of Impuesto)
    Public Overridable Property ImpuestosModificados As ICollection(Of Impuesto) = New HashSet(Of Impuesto)
    Public Overridable Property ListasPreciosCreadas As ICollection(Of ListaPrecio) = New HashSet(Of ListaPrecio)
    Public Overridable Property ListasPreciosModificadas As ICollection(Of ListaPrecio) = New HashSet(Of ListaPrecio)
    Public Overridable Property ListaPrecioArticulosCreados As ICollection(Of ListaPrecioArticulo) = New HashSet(Of ListaPrecioArticulo)
    Public Overridable Property ListaPrecioArticulosModificados As ICollection(Of ListaPrecioArticulo) = New HashSet(Of ListaPrecioArticulo)
    Public Overridable Property MediosPagoCreados As ICollection(Of MedioPago) = New HashSet(Of MedioPago)
    Public Overridable Property MediosPagoModificados As ICollection(Of MedioPago) = New HashSet(Of MedioPago)
    Public Overridable Property MovimientosCreados As ICollection(Of Movimiento) = New HashSet(Of Movimiento)
    Public Overridable Property MovimientosModificados As ICollection(Of Movimiento) = New HashSet(Of Movimiento)
    Public Overridable Property MovimientoGruposCreados As ICollection(Of MovimientoGrupo) = New HashSet(Of MovimientoGrupo)
    Public Overridable Property MovimientoGruposModificados As ICollection(Of MovimientoGrupo) = New HashSet(Of MovimientoGrupo)
    Public Overridable Property NivelesCreados As ICollection(Of Nivel) = New HashSet(Of Nivel)
    Public Overridable Property NivelesModificados As ICollection(Of Nivel) = New HashSet(Of Nivel)
    Public Overridable Property RelacionTiposCreados As ICollection(Of RelacionTipo) = New HashSet(Of RelacionTipo)
    Public Overridable Property RelacionTiposModificados As ICollection(Of RelacionTipo) = New HashSet(Of RelacionTipo)
    Public Overridable Property TurnosCreados As ICollection(Of Turno) = New HashSet(Of Turno)
    Public Overridable Property TurnosModificados As ICollection(Of Turno) = New HashSet(Of Turno)
    Public Overridable Property UsuariosCreados As ICollection(Of Usuario) = New HashSet(Of Usuario)
    Public Overridable Property UsuarioCreacion As Usuario
    Public Overridable Property UsuariosModificados As ICollection(Of Usuario) = New HashSet(Of Usuario)
    Public Overridable Property UsuarioModificacion As Usuario
    Public Overridable Property UsuarioGruposCreados As ICollection(Of UsuarioGrupo) = New HashSet(Of UsuarioGrupo)
    Public Overridable Property UsuarioGruposModificados As ICollection(Of UsuarioGrupo) = New HashSet(Of UsuarioGrupo)
    Public Overridable Property ArticuloTallesCreados As ICollection(Of ArticuloTalle) = New HashSet(Of ArticuloTalle)
    Public Overridable Property ArticuloTallesModificados As ICollection(Of ArticuloTalle) = New HashSet(Of ArticuloTalle)
    Public Overridable Property ListaPrecioArticuloTallesCreados As ICollection(Of ListaPrecioArticuloTalle) = New HashSet(Of ListaPrecioArticuloTalle)
    Public Overridable Property ListaPrecioArticuloTallesModificados As ICollection(Of ListaPrecioArticuloTalle) = New HashSet(Of ListaPrecioArticuloTalle)
    Public Overridable Property MonedasCreadas As ICollection(Of Moneda) = New HashSet(Of Moneda)
    Public Overridable Property MonedasModificadas As ICollection(Of Moneda) = New HashSet(Of Moneda)
    Public Overridable Property MonedaCotizacionesCreadas As ICollection(Of MonedaCotizacion) = New HashSet(Of MonedaCotizacion)
    Public Overridable Property MonedaCotizacionesModificadas As ICollection(Of MonedaCotizacion) = New HashSet(Of MonedaCotizacion)

End Class
