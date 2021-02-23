﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class CSColegioContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CSColegioContext")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Anio() As DbSet(Of Anio)
    Public Overridable Property Articulo() As DbSet(Of Articulo)
    Public Overridable Property ArticuloGrupo() As DbSet(Of ArticuloGrupo)
    Public Overridable Property Banco() As DbSet(Of Banco)
    Public Overridable Property CategoriaIVA() As DbSet(Of CategoriaIVA)
    Public Overridable Property Curso() As DbSet(Of Curso)
    Public Overridable Property DocumentoTipo() As DbSet(Of DocumentoTipo)
    Public Overridable Property Entidad() As DbSet(Of Entidad)
    Public Overridable Property EntidadEntidad() As DbSet(Of EntidadEntidad)
    Public Overridable Property Localidad() As DbSet(Of Localidad)
    Public Overridable Property Log() As DbSet(Of Log)
    Public Overridable Property MedioPago() As DbSet(Of MedioPago)
    Public Overridable Property Movimiento() As DbSet(Of Movimiento)
    Public Overridable Property MovimientoGrupo() As DbSet(Of MovimientoGrupo)
    Public Overridable Property Nivel() As DbSet(Of Nivel)
    Public Overridable Property Parametro() As DbSet(Of Parametro)
    Public Overridable Property Provincia() As DbSet(Of Provincia)
    Public Overridable Property RelacionTipo() As DbSet(Of RelacionTipo)
    Public Overridable Property Turno() As DbSet(Of Turno)
    Public Overridable Property Usuario() As DbSet(Of Usuario)
    Public Overridable Property UsuarioGrupo() As DbSet(Of UsuarioGrupo)
    Public Overridable Property ComprobanteImpuesto() As DbSet(Of ComprobanteImpuesto)
    Public Overridable Property ComprobanteTipo() As DbSet(Of ComprobanteTipo)
    Public Overridable Property Impuesto() As DbSet(Of Impuesto)
    Public Overridable Property ComprobanteDetalle() As DbSet(Of ComprobanteDetalle)
    Public Overridable Property UsuarioGrupoPermiso() As DbSet(Of UsuarioGrupoPermiso)
    Public Overridable Property AnioLectivoCurso() As DbSet(Of AnioLectivoCurso)
    Public Overridable Property Concepto() As DbSet(Of Concepto)
    Public Overridable Property CondicionIVA() As DbSet(Of CondicionIVA)
    Public Overridable Property ImpuestoOtro() As DbSet(Of ImpuestoOtro)
    Public Overridable Property Moneda() As DbSet(Of Moneda)
    Public Overridable Property UnidadMedida() As DbSet(Of UnidadMedida)
    Public Overridable Property Descuento() As DbSet(Of Descuento)
    Public Overridable Property ComprobanteTipoPuntoVenta() As DbSet(Of ComprobanteTipoPuntoVenta)
    Public Overridable Property PuntoVenta() As DbSet(Of PuntoVenta)
    Public Overridable Property ComprobanteLote() As DbSet(Of ComprobanteLote)
    Public Overridable Property MonedaCotizacion() As DbSet(Of MonedaCotizacion)
    Public Overridable Property Reporte() As DbSet(Of Reporte)
    Public Overridable Property ReporteGrupo() As DbSet(Of ReporteGrupo)
    Public Overridable Property Feriado() As DbSet(Of Feriado)
    Public Overridable Property Caja() As DbSet(Of Caja)
    Public Overridable Property Comprobante() As DbSet(Of Comprobante)
    Public Overridable Property ComprobanteMedioPago() As DbSet(Of ComprobanteMedioPago)
    Public Overridable Property Cheque() As DbSet(Of Cheque)
    Public Overridable Property ComprobanteAplicacion() As DbSet(Of ComprobanteAplicacion)
    Public Overridable Property ChequeMotivoRechazo() As DbSet(Of ChequeMotivoRechazo)
    Public Overridable Property Chequera() As DbSet(Of Chequera)
    Public Overridable Property ComprobanteAplicacionMotivo() As DbSet(Of ComprobanteAplicacionMotivo)
    Public Overridable Property ReporteParametro() As DbSet(Of ReporteParametro)
    Public Overridable Property TarjetaCredito() As DbSet(Of TarjetaCredito)
    Public Overridable Property TarjetaCreditoBanco() As DbSet(Of TarjetaCreditoBanco)
    Public Overridable Property ArticuloTalle() As DbSet(Of ArticuloTalle)
    Public Overridable Property Comunicacion() As DbSet(Of Comunicacion)
    Public Overridable Property ComunicacionEntidad() As DbSet(Of ComunicacionEntidad)
    Public Overridable Property EmailEnvio() As DbSet(Of EmailEnvio)
    Public Overridable Property CuotaTipo() As DbSet(Of CuotaTipo)
    Public Overridable Property AnioLectivoCuota() As DbSet(Of AnioLectivoCuota)
    Public Overridable Property ListaPrecio() As DbSet(Of ListaPrecio)
    Public Overridable Property ListaPrecioArticulo() As DbSet(Of ListaPrecioArticulo)
    Public Overridable Property ListaPrecioArticuloTalle() As DbSet(Of ListaPrecioArticuloTalle)

End Class
