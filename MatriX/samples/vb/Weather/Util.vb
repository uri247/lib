Imports System
Imports System.IO
Imports Matrix.Xml

Public Class Util
	Private Shared _settingsFolder As String
	Private Shared _settingsFilename As String

	Private Shared ReadOnly Property SettingsFolder() As String
		Get
			If _settingsFolder Is Nothing Then
				Dim spath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MatriX-Examples\Weather")
				If Not Directory.Exists(spath) Then
					Directory.CreateDirectory(spath)
				End If

				_settingsFolder = spath
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
End Class
