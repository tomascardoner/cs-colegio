﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public ReadOnly Property EnableVisualStyles() As Boolean
            Get
                Return CType(Me("EnableVisualStyles"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public ReadOnly Property MinimumSplashScreenDisplaySeconds() As Byte
            Get
                Return CType(Me("MinimumSplashScreenDisplaySeconds"),Byte)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LastUserLoggedIn() As String
            Get
                Return CType(Me("LastUserLoggedIn"),String)
            End Get
            Set
                Me("LastUserLoggedIn") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public ReadOnly Property ShowLastUserLoggedIn() As Boolean
            Get
                Return CType(Me("ShowLastUserLoggedIn"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Microsoft Sans Serif, 11.25pt")>  _
        Public ReadOnly Property GridsAndListsFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("GridsAndListsFont"),Global.System.Drawing.Font)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public ReadOnly Property SingleInstanceApplication() As Boolean
            Get
                Return CType(Me("SingleInstanceApplication"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public ReadOnly Property UseCustomDialogForErrorMessage() As Boolean
            Get
                Return CType(Me("UseCustomDialogForErrorMessage"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public ReadOnly Property LoteComprobantes_PreseleccionarTodos() As Boolean
            Get
                Return CType(Me("LoteComprobantes_PreseleccionarTodos"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10")>  _
        Public ReadOnly Property PermiteGenerarMatriculaMesDesde() As Byte
            Get
                Return CType(Me("PermiteGenerarMatriculaMesDesde"),Byte)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Users\Tomas\Dropbox\Colegio Horizonte\CS-Colegio\Certificados\administracion_h"& _ 
            "omologacion.crt")>  _
        Public ReadOnly Property AFIP_WS_Certificado_Homologacion() As String
            Get
                Return CType(Me("AFIP_WS_Certificado_Homologacion"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Users\Tomas\Dropbox\Colegio Horizonte\CS-Colegio\Certificados\cardonersistemas"& _ 
            ".key")>  _
        Public ReadOnly Property AFIP_WS_ClavePrivada() As String
            Get
                Return CType(Me("AFIP_WS_ClavePrivada"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
        Public ReadOnly Property IDPuntoVenta() As Byte
            Get
                Return CType(Me("IDPuntoVenta"),Byte)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2400")>  _
        Public ReadOnly Property AFIP_WS_TTLTicketRequerimientoAcceso() As Short
            Get
                Return CType(Me("AFIP_WS_TTLTicketRequerimientoAcceso"),Short)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%ApplicationFolder%\Log\AFIP")>  _
        Public ReadOnly Property AFIP_WS_LogFolder() As String
            Get
                Return CType(Me("AFIP_WS_LogFolder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%DateTimeUniversalNoSlashes%.log")>  _
        Public ReadOnly Property AFIP_WS_LogFileName() As String
            Get
                Return CType(Me("AFIP_WS_LogFileName"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public ReadOnly Property AFIP_WS_ModoHomologacion() As Boolean
            Get
                Return CType(Me("AFIP_WS_ModoHomologacion"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Users\Tomas\Dropbox\Cardoner Sistemas\CS-Colegio\Reportes")>  _
        Public ReadOnly Property ReportsPath() As String
            Get
                Return CType(Me("ReportsPath"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("2")>  _
        Public ReadOnly Property DecimalesEnImportes() As Byte
            Get
                Return CType(Me("DecimalesEnImportes"),Byte)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("localhost")>  _
        Public ReadOnly Property DBConnection_Datasource() As String
            Get
                Return CType(Me("DBConnection_Datasource"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("CSColegio")>  _
        Public ReadOnly Property DBConnection_Database() As String
            Get
                Return CType(Me("DBConnection_Database"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("sa")>  _
        Public ReadOnly Property DBConnection_UserID() As String
            Get
                Return CType(Me("DBConnection_UserID"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("43ubKjbAQCxR+foIcEK/PcLRw0VHFqfd")>  _
        Public ReadOnly Property DBConnection_Password() As String
            Get
                Return CType(Me("DBConnection_Password"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("System.Data.SqlClient")>  _
        Public ReadOnly Property DBConnection_Provider() As String
            Get
                Return CType(Me("DBConnection_Provider"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("NETCLIENT")>  _
        Public ReadOnly Property LoteComprobantes_EnviarEmail_Metodo() As String
            Get
                Return CType(Me("LoteComprobantes_EnviarEmail_Metodo"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Colegio Horizonte de Lobos - Administracion")>  _
        Public ReadOnly Property Email_DisplayName() As String
            Get
                Return CType(Me("Email_DisplayName"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("tomascardoner@me.com")>  _
        Public ReadOnly Property Email_Address() As String
            Get
                Return CType(Me("Email_Address"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("mail.horizontedelobos.com.ar")>  _
        Public ReadOnly Property Email_SMTP_Server() As String
            Get
                Return CType(Me("Email_SMTP_Server"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("administracion@horizontedelobos.com.ar")>  _
        Public ReadOnly Property Email_SMTP_Username() As String
            Get
                Return CType(Me("Email_SMTP_Username"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("yW4DfKMkoW1G6xeH/A+Jj9jGeAXMiW9Xk4NW/87/C7kP9+IdAyHtUw==")>  _
        Public ReadOnly Property Email_SMTP_Password() As String
            Get
                Return CType(Me("Email_SMTP_Password"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("25")>  _
        Public ReadOnly Property Email_SMTP_Port() As Short
            Get
                Return CType(Me("Email_SMTP_Port"),Short)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public ReadOnly Property Email_SMTP_UseSSL() As Boolean
            Get
                Return CType(Me("Email_SMTP_UseSSL"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("30000")>  _
        Public ReadOnly Property Email_SMTP_Timeout() As Integer
            Get
                Return CType(Me("Email_SMTP_Timeout"),Integer)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("{0} N° {1}")>  _
        Public ReadOnly Property Comprobante_EnviarEmail_Subject() As String
            Get
                Return CType(Me("Comprobante_EnviarEmail_Subject"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Adjuntamos el Comprobante solicitado.{0}{0}Atentamente.")>  _
        Public ReadOnly Property Comprobante_EnvioEmail_Body() As String
            Get
                Return CType(Me("Comprobante_EnvioEmail_Body"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("{0}{0}Colegio Horizonte de Lobos{0}Administración{0}Castelli 193 - Lobos{0}Tel.: "& _ 
            "+54 2227 42-4656{0}administracion@horizontedelobos.com.ar{0}www.horizontedelobos"& _ 
            ".com.ar")>  _
        Public ReadOnly Property Email_Signature() As String
            Get
                Return CType(Me("Email_Signature"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Users\Tomas\Dropbox\Colegio Horizonte\CS-Colegio\Certificados\administracion_p"& _ 
            "roduccion.crt")>  _
        Public ReadOnly Property AFIP_WS_Certificado_Produccion() As String
            Get
                Return CType(Me("AFIP_WS_Certificado_Produccion"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("NETCLIENT")>  _
        Public ReadOnly Property Comprobante_EnviarEmail_Metodo() As String
            Get
                Return CType(Me("Comprobante_EnviarEmail_Metodo"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public ReadOnly Property AFIP_WS_LogEnabled() As Boolean
            Get
                Return CType(Me("AFIP_WS_LogEnabled"),Boolean)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("200")>  _
        Public ReadOnly Property Email_MaxPerHour() As Short
            Get
                Return CType(Me("Email_MaxPerHour"),Short)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("%ApplicationFolder%\Intercambio\Salida")>  _
        Public ReadOnly Property Exchange_Outbound_Folder() As String
            Get
                Return CType(Me("Exchange_Outbound_Folder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Santander_ADDI")>  _
        Public ReadOnly Property Exchange_Outbound_Santander_ADDI_SubFolder() As String
            Get
                Return CType(Me("Exchange_Outbound_Santander_ADDI_SubFolder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("PagoMisCuentas")>  _
        Public Property Exchange_Outbound_PagoMisCuentas_SubFolder() As String
            Get
                Return CType(Me("Exchange_Outbound_PagoMisCuentas_SubFolder"),String)
            End Get
            Set
                Me("Exchange_Outbound_PagoMisCuentas_SubFolder") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.CSColegio.DesktopApplication.My.MySettings
            Get
                Return Global.CSColegio.DesktopApplication.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
