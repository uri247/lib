Imports System
Imports System.Collections
Imports System.IO
Imports System.Text
Imports Matrix.Xml
Imports Matrix.Xmpp
Imports Matrix.Xmpp.Client

Public Class Util

    Private Shared _settingsFolder As String
    Private Shared _settingsFilename As String
    Private Shared _chatForms As New Hashtable()
    
    Public Shared ReadOnly Property ChatForms() As Hashtable
        Get
            Return _chatForms
        End Get
    End Property

    Private Shared ReadOnly Property SettingsFolder() As String
        Get
            If _settingsFolder Is Nothing Then
                Dim sPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MiniClient")
                If Not Directory.Exists(sPath) Then
                    Directory.CreateDirectory(sPath)
                End If
                _settingsFolder = sPath
            End If
            Return _settingsFolder
        End Get
    End Property

    Private Shared ReadOnly Property SettingsFilename() As String
        Get
            If _settingsFilename Is Nothing Then
                _settingsFilename = Path.Combine(SettingsFolder, "settings.xml")
            End If

            Return _settingsFilename
        End Get
    End Property

    Public Shared Function LoadSettings() As Settings.Settings
        Dim settings As XmppXElement = Nothing
        If File.Exists(SettingsFilename) Then

            settings = XmppXElement.LoadXml(File.ReadAllText(SettingsFilename))
        End If
        If TypeOf settings Is Settings.Settings Then
            Return TryCast(settings, Settings.Settings)
        End If

        Return New Settings.Settings()
    End Function

    Public Shared Sub SaveSettings(settings As Settings.Settings)
        settings.Save(SettingsFilename)
    End Sub

    Public Shared Function GetRosterImageIndex(pres As Presence) As Integer
        If pres.Type = PresenceType.unavailable Then
            Return 0
        End If

        Select Case pres.Show
            Case Show.chat
                Return 1
            Case Show.away
                Return 2
            Case Show.xa
                Return 2
            Case Show.dnd
                Return 3
            Case Else
                Return 1
        End Select
    End Function

    ''' <summary>
    ''' Converts the Numer of bytes to a human readable string
    ''' </summary>
    ''' <param name="lBytes"></param>
    ''' <returns></returns>
    Public Shared Function HumanReadableFileSize(lBytes As Long) As String
        Dim sb = New StringBuilder()
        Dim strUnits As String = "Bytes"
        Dim fAdjusted As Single = 0F

        If lBytes > 1024 Then
            If lBytes < 1024 * 1024 Then
                strUnits = "KB"
                fAdjusted = Convert.ToSingle(lBytes) / 1024
            Else
                strUnits = "MB"
                fAdjusted = Convert.ToSingle(lBytes) / 1048576
            End If
            sb.AppendFormat("{0:0.0} {1}", fAdjusted, strUnits)
        Else
            fAdjusted = Convert.ToSingle(lBytes)
            sb.AppendFormat("{0:0} {1}", fAdjusted, strUnits)
        End If

        Return sb.ToString()
    End Function

End Class