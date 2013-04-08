Imports System
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Web
Imports Matrix.Xmpp
Imports Microsoft.AspNet.SignalR

Imports Matrix.Xmpp.Client


Public Class MatrixHub
	Inherits Hub
	
    Private Shared ReadOnly XmppClients As New Dictionary(Of String, XmppClient)()

    

	Public Overrides Function OnDisconnected() As Task
		Debug.WriteLine("SignalR Disconnect: " + Context.ConnectionId)

		If XmppClients.ContainsKey(Context.ConnectionId) Then
			Dim xmppClient = XmppClients(Context.ConnectionId)

            RemoveHandler xmppClient.OnReceiveXml, AddressOf xmppClient_OnReceiveXml
			RemoveHandler xmppClient.OnSendXml, AddressOf xmppClient_OnSendXml


			RemoveHandler xmppClient.OnPresence, AddressOf xmppClient_OnPresence
			RemoveHandler xmppClient.OnMessage, AddressOf xmppClient_OnMessage
			RemoveHandler xmppClient.OnIq, AddressOf xmppClient_OnIq

			RemoveHandler xmppClient.OnRosterStart, AddressOf xmppClient_OnRosterStart
			RemoveHandler xmppClient.OnRosterItem, AddressOf xmppClient_OnRosterItem
			RemoveHandler xmppClient.OnRosterEnd, AddressOf xmppClient_OnRosterEnd

			RemoveHandler xmppClient.OnLogin,  AddressOf xmppClient_OnLogin

			RemoveHandler xmppClient.OnClose, AddressOf xmppClient_OnClose
			RemoveHandler xmppClient.OnBeforeSendPresence, AddressOf xmppClient_OnBeforeSendPresence
			RemoveHandler xmppClient.OnBeforeSasl, AddressOf xmppClient_OnBeforeSasl

			XmppClients.Remove(Context.ConnectionId)
		End If

		Return Clients.All.leave(Context.ConnectionId, DateTime.Now.ToString())
	End Function

    Public Overrides Function OnConnected() As Task
		Debug.WriteLine("SignalR Connect: " + Context.ConnectionId)

		If XmppClients.Count = 0 Then
			SetLicense()
		End If

		If Not XmppClients.ContainsKey(Context.ConnectionId) Then
			Dim xmppClient = New XmppClient()
            
			AddHandler xmppClient.OnReceiveXml, AddressOf xmppClient_OnReceiveXml
			AddHandler xmppClient.OnSendXml, AddressOf xmppClient_OnSendXml


			AddHandler xmppClient.OnPresence, AddressOf xmppClient_OnPresence
			AddHandler xmppClient.OnMessage, AddressOf xmppClient_OnMessage
			AddHandler xmppClient.OnIq, AddressOf xmppClient_OnIq

			AddHandler xmppClient.OnRosterStart, AddressOf xmppClient_OnRosterStart
			AddHandler xmppClient.OnRosterItem, AddressOf xmppClient_OnRosterItem
			AddHandler xmppClient.OnRosterEnd, AddressOf xmppClient_OnRosterEnd

			AddHandler xmppClient.OnLogin, AddressOf xmppClient_OnLogin

			AddHandler xmppClient.OnClose, AddressOf xmppClient_OnClose
			AddHandler xmppClient.OnBeforeSendPresence, AddressOf xmppClient_OnBeforeSendPresence
			AddHandler xmppClient.OnBeforeSasl, AddressOf xmppClient_OnBeforeSasl

			XmppClients.Add(Context.ConnectionId, xmppClient)
		End If

		Return Clients.All.joined(Context.ConnectionId, DateTime.Now.ToString())
	End Function

    Public Overrides Function OnReconnected() As Task
		Return Clients.All.rejoined(Context.ConnectionId, DateTime.Now.ToString())
	End Function

	Private Sub xmppClient_OnIq(sender As Object, e As IqEventArgs)
		DisplayEvent("OnIq")
	End Sub

	Private Sub xmppClient_OnMessage(sender As Object, e As MessageEventArgs)
		DisplayEvent("OnMessage")

		Clients.Client(Context.ConnectionId).onMessage(New Message() With { _
			.From = e.Message.From, _
			.Body = e.Message.Body _
		})

	End Sub

	Private Sub xmppClient_OnBeforeSasl(sender As Object, e As Matrix.Xmpp.Sasl.SaslEventArgs)
		DisplayEvent("OnBeforeSasl")
	End Sub

	Private Sub xmppClient_OnBeforeSendPresence(sender As Object, e As PresenceEventArgs)
		DisplayEvent("OnBeforeSendPresence")
	End Sub

	Private Sub xmppClient_OnClose(sender As Object, e As Matrix.EventArgs)
		DisplayEvent("OnClose")
	End Sub

	Private Sub xmppClient_OnLogin(sender As Object, e As Matrix.EventArgs)
		DisplayEvent("OnLogin")
	End Sub

	Private Sub xmppClient_OnRosterEnd(sender As Object, e As Matrix.EventArgs)
		DisplayEvent("OnRosterEnd")
	End Sub

	Private Sub xmppClient_OnRosterStart(sender As Object, e As Matrix.EventArgs)
		DisplayEvent("OnRosterStart")
	End Sub

	Private Sub xmppClient_OnPresence(sender As Object, e As PresenceEventArgs)
		DisplayEvent("OnPresence")

		Dim uniqueId As String = Matrix.Util.Hash.Sha1HashHex(e.Presence.From.Bare)
		Clients.Client(Context.ConnectionId).onPresence(uniqueId, e.Presence.From.Bare, If(e.Presence.Type = PresenceType.unavailable, "Offline", ShowToString(e.Presence.Show)), If(e.Presence.Status, ""))
	End Sub

	Private Sub xmppClient_OnRosterItem(sender As Object, e As Matrix.Xmpp.Roster.RosterEventArgs)
		DisplayEvent("OnRosterItem")

		Dim uniqueId As String = Matrix.Util.Hash.Sha1HashHex(e.RosterItem.Jid.Bare)
		Clients.Client(Context.ConnectionId).onRosterItem(uniqueId, e.RosterItem.Jid.Bare, If(e.RosterItem.Name, ""))
	End Sub

	Private Sub xmppClient_OnSendXml(sender As Object, e As Matrix.TextEventArgs)
		Dim text = HttpUtility.HtmlEncode([String].Format("Send: {0}", e.Text))

		Clients.Client(Context.ConnectionId).sendXml(text)
	End Sub

	Private Sub xmppClient_OnReceiveXml(sender As Object, e As Matrix.TextEventArgs)
		Dim text = HttpUtility.HtmlEncode([String].Format("Recv: {0}", e.Text))

		Clients.Client(Context.ConnectionId).receiveXml(text)
	End Sub

	Private Sub DisplayEvent(evt As String)
		Clients.Client(Context.ConnectionId).displayEvent(evt)
	End Sub

	Public Sub Connect(username As [String], password As [String], xmppDomain As [String])
		'SetLicense();

		Dim xmppClient As XmppClient = XmppClients(Context.ConnectionId)
		xmppClient.Username = username
		xmppClient.Password = password
		xmppClient.XmppDomain = xmppDomain

		xmppClient.Open()
	End Sub

	Public Sub Close()
		Dim xmppClient As XmppClient = XmppClients(Context.ConnectionId)
		xmppClient.Close()
	End Sub

	Private Function ShowToString(eShow As Show) As String
		Select Case eShow
			Case Show.NONE
				Return "Online"
			Case Show.away
				Return "Away"
			Case Show.xa
				Return "Extended away"
			Case Show.dnd
				Return "Do not disturb"
			Case Show.chat
				Return "I want to chat"
		End Select

		Return "Offline"
	End Function

	Private Sub SetLicense()
        '// get a trial license online at:
        '// http://www.ag-software.net/matrix-xmpp-sdk/request-demo-license/
		Const  LIC As String = "set your license key here"
		Matrix.License.LicenseManager.SetLicense(LIC)
	End Sub
End Class