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

Partial Public Class EntidadPersonalColegio
    Public Property IdEntidad As Integer
    Public Property IdEntidadGrupo As Byte
    Public Property AdicionalAntiguedad As Nullable(Of Decimal)
    Public Property Adicional1 As Nullable(Of Decimal)
    Public Property Adicional2 As Nullable(Of Decimal)

    Public Overridable Property Entidad As Entidad
    Public Overridable Property EntidadGrupo As EntidadGrupo
    Public Overridable Property EntidadPersonalColegioAntiguedadDetalle As ICollection(Of EntidadPersonalColegioAntiguedadDetalle) = New HashSet(Of EntidadPersonalColegioAntiguedadDetalle)

End Class