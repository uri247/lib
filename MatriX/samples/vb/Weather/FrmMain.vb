Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Matrix
Imports Matrix.Xml
Imports Matrix.Xmpp
Imports Matrix.Xmpp.Client
Imports WeatherVB.Settings

Public Partial Class FrmMain
	Inherits Form
	Private settings As Settings.Settings
	Private login As Login

	Public Sub New()
        InitializeComponent
		SetLicense()

		RegisterCustomElements()
		InitSettings()
	End Sub

	Private Shared Sub RegisterCustomElements()
		Factory.RegisterElement(Of Weather)("ag-software:weather", "weather")

		Factory.RegisterElement(Of Settings.Settings)("ag-software:settings", "Settings")
		Factory.RegisterElement(Of Login)("ag-software:settings", "Login")
	End Sub

	Private Sub InitSettings()
		settings = Util.LoadSettings()
		If settings.Login Is Nothing Then
			settings.Login = New Login()
		End If

		login = settings.Login

		If login IsNot Nothing Then
			If Not String.IsNullOrEmpty(login.User) Then
				txtUsername.Text = login.User
			End If

			If Not String.IsNullOrEmpty(login.Server) Then
				txtServer.Text = login.Server
			End If

			If Not String.IsNullOrEmpty(login.Password) Then
				txtPassword.Text = login.Password
			End If
		End If
	End Sub

	''' <summary>
	''' Sets the license and activate the evaluation.
	''' </summary>
	Private Shared Sub SetLicense()
		'
        ' const string LIC =@"your licence code we sent you";
        ' Matrix.License.LicenseManager.SetLicense(LIC);
        '    
    End Sub

	Private Sub cmdConnect_Click(sender As Object, e As System.EventArgs) Handles cmdConnect.Click
		xmppClient.SetUsername(txtUsername.Text)
		xmppClient.SetXmppDomain(txtServer.Text)
		xmppClient.Password = txtPassword.Text

		xmppClient.Status = "I'm chatty"
		xmppClient.Show = Xmpp.Show.chat

		' set settings
		login.User = txtUsername.Text
		login.Server = txtServer.Text
		login.Password = txtPassword.Text


		xmppClient.Open()
	End Sub

	Private Sub xmppClient_OnError(sender As Object, e As ExceptionEventArgs) Handles xmppClient.OnError
		DisplayEvent("OnError")
	End Sub

	Private Sub xmppClient_OnLogin(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnLogin
		DisplayEvent("OnLogin")
	End Sub

	Private Sub DisplayEvent(ev As String)
		listEvents.Items.Add(ev)
		listEvents.SelectedIndex = listEvents.Items.Count - 1
	End Sub

	Private Sub xmppClient_OnBind(sender As Object, e As JidEventArgs) Handles xmppClient.OnBind
		DisplayEvent("OnBind")
	End Sub

	Private Sub xmppClient_OnClose(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnClose
		DisplayEvent("OnClose")
	End Sub

	Private Sub xmppClient_OnRosterStart(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnRosterStart
        DisplayEvent("OnRosterStart")
	End Sub

	Private Sub xmppClient_OnRosterEnd(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnRosterEnd
		DisplayEvent("OnRosterEnd")
	End Sub

	Private Sub xmppClient_OnRosterItem(sender As Object, e As Matrix.Xmpp.Roster.RosterEventArgs) Handles xmppClient.OnRosterItem
		DisplayEvent(String.Format("OnRosterItem" & vbTab & "{0}" & vbTab & "{1}", e.RosterItem.Jid, e.RosterItem.Name))
	End Sub

	Private Sub xmppClient_OnPresence(sender As Object, e As PresenceEventArgs) Handles xmppClient.OnPresence
		DisplayEvent(String.Format("OnPresence" & vbTab & "{0}", e.Presence.From))
	End Sub

	Private Sub xmppClient_OnIq(sender As Object, e As IqEventArgs) Handles xmppClient.OnIq
		DisplayEvent("OnIq")

		If e.Iq.Type = IqType.[get] AndAlso TypeOf e.Iq.Query Is Weather Then
			Dim weather = TryCast(e.Iq.Query, Weather)
			Dim zip As String = weather.Zip
			' here you should lookup the weather information for the given zip code in a database or webservice
			' we just return some random numbers

			Dim temp = New Random().[Next](-10, 40)
			Dim humidity = New Random().[Next](10, 90)

			Dim wiq = New WeatherIq() With { _
				.[To] = e.Iq.From, _
				.Type = IqType.result, _
				.Weather = New Weather() With { _
					.Temperature = temp, _
					.Humidity = humidity _
				} _
			}
			' send the response
			xmppClient.Send(wiq)
		End If
	End Sub

	Private Sub xmppClient_OnMessage(sender As Object, e As MessageEventArgs) Handles xmppClient.OnMessage
		DisplayEvent("OnMessage")
	End Sub

	Private Sub xmppClient_OnValidateCertificate(sender As Object, e As CertificateEventArgs) Handles xmppClient.OnValidateCertificate
		' always accept cert
		e.AcceptCertificate = True
	End Sub

	Private Sub cmdDisconnect_Click(sender As Object, e As System.EventArgs) Handles cmdDisconnect.Click
		xmppClient.Close()
	End Sub

	Private Sub xmppClient_OnAuthError(sender As Object, e As Sasl.SaslEventArgs) Handles xmppClient.OnAuthError
		DisplayEvent("OnAuthError")
		xmppClient.Close()
	End Sub

	Private Sub xmppClient_OnReceiveXml(sender As Object, e As TextEventArgs) Handles xmppClient.OnReceiveXml
		rtfDebug.SelectionStart = rtfDebug.Text.Length
		rtfDebug.SelectionLength = 0
		rtfDebug.SelectionColor = Color.Red
		rtfDebug.AppendText("RECV: ")
		rtfDebug.SelectionColor = Color.Black
		rtfDebug.AppendText(e.Text)
		rtfDebug.AppendText(vbCr & vbLf)
	End Sub

	Private Sub xmppClient_OnSendXml(sender As Object, e As TextEventArgs) Handles xmppClient.OnSendXml
		rtfDebug.SelectionStart = rtfDebug.Text.Length
		rtfDebug.SelectionLength = 0
		rtfDebug.SelectionColor = Color.Blue
		rtfDebug.AppendText("SEND: ")
		rtfDebug.SelectionColor = Color.Black
		rtfDebug.AppendText(e.Text)
		rtfDebug.AppendText(vbCr & vbLf)
	End Sub

	Private Sub xmppClient_OnStreamError(sender As Object, e As StreamErrorEventArgs) Handles xmppClient.OnStreamError
		DisplayEvent("OnStreamError")
	End Sub
    
	Private Sub cmdRequestWeatherInfo_Click(sender As Object, e As System.EventArgs) Handles cmdRequestWeatherInfo.Click
		If Not String.IsNullOrEmpty(txtZip.Text) AndAlso Not [String].IsNullOrEmpty(txtRequestFrom.Text) Then
			RequestWeatherInfo(txtRequestFrom.Text, txtZip.Text)
		End If
	End Sub

	Private Sub RequestWeatherInfo(from As Jid, zip As String)
		Dim wiq = New WeatherIq() With { _
			.Type = IqType.[get], _
			.[To] = from, _
			.Weather = New Weather() With { _
				.Zip = zip _
			} _
		}
		' we pass the zip code as state object to the IqFilter
		xmppClient.IqFilter.SendIq(wiq,AddressOf WeatherInfoResponse, zip)
	End Sub

	Private Sub WeatherInfoResponse(sender As Object, e As IqEventArgs)
		Dim iq = e.Iq

		If iq.Type = IqType.result Then
			Dim weather = iq.Element(Of Weather)()
			If weather IsNot Nothing Then
				Dim zip = TryCast(e.State, String)

				MessageBox.Show([String].Format("weather info for zip code: {0}" & vbCr & vbLf & vbCr & vbLf & "Humidity: {1}" & vbCr & vbLf & "Temperature: {2}", zip, weather.Humidity, weather.Temperature))
			End If
				' process errors here
		ElseIf iq.Type = IqType.[error] Then
		End If
	End Sub

  
    Private Sub FrmMain_FormClosing( sender As System.Object,  e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            Util.SaveSettings(settings)
    End Sub
end Class

