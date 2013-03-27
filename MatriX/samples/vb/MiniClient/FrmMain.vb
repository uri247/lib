
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Security.Cryptography.X509Certificates
Imports Matrix
Imports Matrix.Xml
Imports Matrix.Xmpp
Imports Matrix.Xmpp.Client
Imports Matrix.Xmpp.Register
Imports Matrix.Xmpp.XData
Imports Matrix.Xmpp.Roster
Imports MiniClientVB.Settings

Public Partial Class FrmMain
    Inherits Form
    'WinAPI-Declaration for SendMessage
    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(window As IntPtr, message As Integer, wparam As Integer, lparam As Integer) As IntPtr
    End Function

    Const WM_VSCROLL As Integer = &H115
    Const SB_BOTTOM As Integer = 7

    Private ReadOnly _dictContactGroups As New Dictionary(Of String, ListViewGroup)()
    Private ReadOnly _dictContats As New Dictionary(Of Jid, RosterItem)()

    Private _settings As Settings.Settings
    Private _login As Login

    Private fm As New FileTransferManager()

    Public Sub New()
        InitializeComponent()

        SetLicense()

        RegisterCustomElements()
        InitSettings()
        InitContactList()

        fm.XmppClient = xmppClient
        AddHandler fm.OnFile, AddressOf fm_OnFile
			
    End Sub


    Private Shared Sub RegisterCustomElements()
        Factory.RegisterElement(Of Settings.Settings)("ag-software:settings", "Settings")
        Factory.RegisterElement(Of Login)("ag-software:settings", "Login")
    End Sub

    Private Sub InitSettings()
        _settings = Util.LoadSettings()
        If _settings.Login Is Nothing Then
            _settings.Login = New Login()
        End If

        _login = _settings.Login

        If _login IsNot Nothing Then
            If Not String.IsNullOrEmpty(_login.User) Then
                txtUsername.Text = _login.User
            End If

            If Not String.IsNullOrEmpty(_login.Server) Then
                txtServer.Text = _login.Server
            End If

            If Not String.IsNullOrEmpty(_login.Password) Then
                txtPassword.Text = _login.Password
            End If
        End If
    End Sub

    ''' <summary>
    ''' Sets the license and activate the evaluation.
    ''' </summary>
    Private Shared Sub SetLicense()
        'const string LIC = @"YOUR LICENSE";
        'Matrix.License.LicenseManager.SetLicense(LIC);
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As System.EventArgs) Handles cmdConnect.Click
        xmppClient.SetUsername(txtUsername.Text)
        xmppClient.SetXmppDomain(txtServer.Text)
        xmppClient.Password = txtPassword.Text

        ' if you want to use BOSH as transport layer
        'xmppClient.Transport = Matrix.Net.Transport.BOSH
        'xmppClient.Uri = New System.Uri("http://your-bosh-uri/http-bind/")
        
        xmppClient.Status = "ready for chat"
        xmppClient.Show = Xmpp.Show.chat

        If Not String.IsNullOrEmpty(txtHost.Text) Then
            xmppClient.Hostname = txtHost.Text
        End If

        ' set settings
        _login.User = txtUsername.Text
        _login.Server = txtServer.Text
        _login.Password = txtPassword.Text

        ' you can also disable SRV lookups and specify the sever hostname manual
        'xmppClient.ResolveSrvRecords = false;
        'xmppClient.Hostname = "192.168.1.106";
        
xmppClient.Open()
    
    End Sub

    Private Sub xmppClient_OnPrebind(sender As Object, e As Matrix.Net.PrebindEventArgs) Handles xmppClient.OnPrebind
        DisplayEvent("OnPrebind Rid:" + e.Rid + " Sid:" + e.Sid)
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
        listContacts.Items.Clear()
    End Sub

    Private Sub xmppClient_OnRosterStart(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnRosterStart

    End Sub

    Private Sub xmppClient_OnRosterEnd(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnRosterEnd
        DisplayEvent("OnRosterEnd")
    End Sub

    Private Sub xmppClient_OnRosterItem(sender As Object, e As Matrix.Xmpp.Roster.RosterEventArgs) Handles xmppClient.OnRosterItem
        Dim version = e.Version
        DisplayEvent(String.Format("OnRosterItem" & vbTab & "{0}" & vbTab & "{1}", e.RosterItem.Jid, e.RosterItem.Name))

        If e.RosterItem.Subscription <> Subscription.remove Then
            ' set a default group name
            Dim groupname As String = "Contacts"

            ' id the contact has groups get the 1st group. In this example we don't support multiple or nested groups
            ' for contacts, but XMPP has support for this.
            If e.RosterItem.HasGroups Then
                groupname = e.RosterItem.GetGroups()(0)
            End If

            If Not _dictContactGroups.ContainsKey(groupname) Then
                Dim newGroup = New ListViewGroup(groupname)
                _dictContactGroups.Add(groupname, newGroup)
                listContacts.Groups.Add(newGroup)
            End If

            Dim listGroup = _dictContactGroups(groupname)

            ' contact already exists, this is a contact update
            If _dictContats.ContainsKey(e.RosterItem.Jid) Then
                listContacts.Items.RemoveByKey(e.RosterItem.Jid)
            End If

            'var newItem = new ListViewItem(e.RosterItem.Jid, listGroup) {Name = e.RosterItem.Jid};
            Dim newItem = New RosterListViewItem(If(e.RosterItem.Name, e.RosterItem.Jid.ToString), 0, listGroup) With { _
                    .Name = e.RosterItem.Jid.Bare _
                    }

            newItem.SubItems.AddRange(New String() { "", "" })
            listContacts.Items.Add(newItem)
        End If
    End Sub



    Private Sub xmppClient_OnPresence(sender As Object, e As PresenceEventArgs) Handles xmppClient.OnPresence
        DisplayEvent(String.Format("OnPresence" & vbTab & "{0}", e.Presence.From))


        If e.Presence.Type = PresenceType.subscribe Then

        ElseIf e.Presence.Type = PresenceType.subscribed Then

        ElseIf e.Presence.Type = PresenceType.unsubscribe Then

        ElseIf e.Presence.Type = PresenceType.unsubscribed Then
        Else
            Dim item = TryCast(listContacts.Items(e.Presence.From.Bare), RosterListViewItem)
            If item IsNot Nothing Then
                item.ImageIndex = Util.GetRosterImageIndex(e.Presence)
                Dim resource As String = e.Presence.From.Resource
                If e.Presence.Type <> PresenceType.unavailable Then
                    If Not item.Resources.Contains(resource) Then
                        item.Resources.Add(resource)
                    End If
                Else
                    If item.Resources.Contains(resource) Then
                        item.Resources.Remove(resource)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub xmppClient_OnIq(sender As Object, e As IqEventArgs) Handles xmppClient.OnIq
        DisplayEvent("OnIq")
    End Sub

    Private Sub xmppClient_OnMessage(sender As Object, e As MessageEventArgs) Handles xmppClient.OnMessage
        DisplayEvent("OnMessage")


        ' we ignore GroupChat Messages here
        If e.Message.Type = MessageType.groupchat Then
            Return
        End If

        If e.Message.Type = MessageType.[error] Then
            'Handle errors here
            ' we dont handle them in this example
            Return
        End If
        If e.Message.Body IsNot Nothing Then
            If Not Util.ChatForms.ContainsKey(e.Message.From.Bare) Then
                'get nickname from the roster listview
                Dim nick As String = e.Message.From.Bare
                Dim item = listContacts.Items(e.Message.From.Bare)
                If item IsNot Nothing Then
                    nick = item.Text
                End If

                Dim f = New FrmChat(e.Message.From, xmppClient, nick)
                f.Show()
                f.IncomingMessage(e.Message)
            End If
        End If
    End Sub

    Private Sub xmppClient_OnValidateCertificate(sender As Object, e As CertificateEventArgs) Handles xmppClient.OnValidateCertificate

        ' always accept cert
        e.AcceptCertificate = True

        ' or let the user validate the certificate
        'ValidateCertificate(e);
    End Sub

    Private Sub ValidateCertificate(e As CertificateEventArgs)
        'DisplayEvent("OnValidateCertificate");


        If e.SslPolicyErrors = System.Net.Security.SslPolicyErrors.None Then
            e.AcceptCertificate = True
        Else
            X509Certificate2UI.DisplayCertificate(New X509Certificate2(e.Certificate))
            If MessageBox.Show("Accept Certificate", "Certificate", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                e.AcceptCertificate = True
            Else
                e.AcceptCertificate = False
            End If
        End If
    End Sub

    Private Sub cmdDisconnect_Click(sender As Object, e As System.EventArgs) Handles cmdDisconnect.Click
        xmppClient.Close()
    End Sub

    Private Sub xmppClient_OnBeforeSasl(sender As Object, e As Matrix.Xmpp.Sasl.SaslEventArgs) Handles xmppClient.OnBeforeSasl
        'e.Auto = false;
        'e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.NONE;

        '
'            with the following code you can disable the SASL automatic and manual specify a mechanism.
'            
'             * e.Auto = false;
'            e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.PLAIN;
'            



        ' X_FACEBOOK_PLATFORM Facebook Auth example
        'e.Auto = false;
        'e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.X_FACEBOOK_PLATFORM;

        'const string APPLICATION_KEY = "12345678901234567890";
        'const string SECRET_KEY = "98765432109876543210";
        'e.SaslProperties = new Matrix.Xmpp.Sasl.Processor.Facebook.FacebookProperties
        '                       {
        '                           ApiKey = APPLICATION_KEY,
        '                           ApiSecret = SECRET_KEY,
        '                           SessionKey = "session_key_from_facebook_api"
        '                       };

        'const string ACCESS_TOKEN = "EwAoAq1DBAAUlbRWyAJjK5w968Ru3Cyt%2f6GvwXwAAc69FnVXb5DeERc2%2f4lo%2bl9LYkn3Ms4tmkZqFTaQUvzrOglBjYzsS0sll1g74TVD4WzPoXLTp8tV6kuRsc07WGN8cjkH15nEhoKTLj4%2bXtNiFl4Wfs9nPQd1eRolVko5MVeAcPIQfHh9ZJDJQxwHC84VklvKOLHDCqO3YggAohxUzZA0CYCp%2fEAarw3YCJ9W4Z4K%2f3uTaE061Gn6%2fDEsXwJGTt0i2%2bOL%2b%2fJQ7uqsHhjtMeuE20HxQBcQRlENnbNpA%2fpvn4q9vaCVxRdfzTizmi5Tv62ZsS6ifGhvz5By1RRP%2f9WU8AIZet7LvXaS5o8fGYSQb7omjB8C14bT4NvS5SQDZgAACC8SApeQLMny%2bAABwAdVxv4lsrQFuEen1ILLShFRNmcRzcaxgZ9QG7E8XCb5swmfqGQkD%2bjvhRQJUI2esH5NzPtXM2faRWweq38%2f4pMVAZkh%2b8BLdNN29jiVCMeSpfXyw9vx1uai6ZXM49x1kt5ZQn1juEZSCQV7mAmK3%2be2XVJmdZy2MgnF7WuqUMray21ghTcgaKhO%2fHNPq%2fIG9NH%2bGwvCnRyH4g8PD563ZfZojBoCxmjk6eD%2f632bcQ9Hs4Fotep0%2b6MGfOEnyZqf4lu4JQj%2bCDGrKnPt1N2qjarrX0qmJi8UeABRQXAUk8SLSfFJLNsh5Comh0rGoDjUgigN8TgRoAAA&token_type=bearer&expires_in=3600&scope=wl.messenger&authentication_token=eyJhbGciOiJIUzI1NiIsICJraWQiOiIwIiwgInR5cCI6IkpXVCJ9.eyJ2ZXIiOjEsICJpc3MiOiJ1cm46d2luZG93czpsaXZlaWQiLCAiZXhwIjoxMzI0MDM0NjYwLCAiYXVkIjoid3d3LmFnLXNvZnR3YXJlLmRlIiwgInVpZCI6IjM2M2VhYjA0ZTMxMDJmNDMyZDI5ZWRlZWRmODNjMDM3IiwgInVybjptaWNyb3NvZnQ6YXBwdXJpIjoiIiwgInVybjptaWNyb3NvZnQ6YXBwaWQiOiIwMDAwMDAwMDRDMDZGOUE5In0.zT1W_ZRhPW2mHNcYn5-CEbH-1Q9LjklE6gUIQNVejHM";
        'e.SaslMechanism = Matrix.Xmpp.Sasl.SaslMechanism.X_MESSENGER_OAUTH2;
        'e.SaslProperties = new Matrix.Xmpp.Sasl.Processor.LiveMessenger.LiveMessengerProperties
        '                       {
        '                           AccessToken = ACCESS_TOKEN
        '                       };
    End Sub

    Private Sub xmppClient_OnAuthError(sender As Object, e As Matrix.Xmpp.Sasl.SaslEventArgs) Handles xmppClient.OnAuthError
        DisplayEvent("OnAuthError")
        xmppClient.Close()
    End Sub

    Private Sub xmppClient_OnReceiveXml(sender As Object, e As TextEventArgs) Handles xmppClient.OnReceiveXml
        If xmppClient.Transport <> Matrix.Net.Transport.Socket Then
            Return
        End If

        rtfDebug.SelectionStart = rtfDebug.Text.Length
        rtfDebug.SelectionLength = 0
        rtfDebug.SelectionColor = Color.Red
        rtfDebug.AppendText("RECV: ")
        rtfDebug.SelectionColor = Color.Black
        rtfDebug.AppendText(e.Text)
        rtfDebug.AppendText(vbCr & vbLf)
        ScrollRtfToEnd(rtfDebug)
    End Sub


    Private Sub xmppClient_OnSendXml(sender As Object, e As TextEventArgs) Handles xmppClient.OnSendXml
        If xmppClient.Transport <> Matrix.Net.Transport.Socket Then
            Return
        End If

        rtfDebug.SelectionStart = rtfDebug.Text.Length
        rtfDebug.SelectionLength = 0
        rtfDebug.SelectionColor = Color.Blue
        rtfDebug.AppendText("SEND: ")
        rtfDebug.SelectionColor = Color.Black
        rtfDebug.AppendText(e.Text)
        rtfDebug.AppendText(vbCr & vbLf)
        ScrollRtfToEnd(rtfDebug)
    End Sub

    Private Sub ScrollRtfToEnd(rtf As RichTextBox)
        SendMessage(rtf.Handle, WM_VSCROLL, SB_BOTTOM, 0)
    End Sub

    ''' <summary>
    ''' Inits the contact list.
    ''' </summary>
    Private Sub InitContactList()
        listContacts.Clear()

        listContacts.Columns.Add("Name", 100, HorizontalAlignment.Left)
        listContacts.Columns.Add("Status", 75, HorizontalAlignment.Left)
        listContacts.Columns.Add("Resource", 75, HorizontalAlignment.Left)

        listContacts.LargeImageList = ilstStatus
    End Sub

    Private Sub xmppClient_OnStreamError(sender As Object, e As StreamErrorEventArgs) Handles xmppClient.OnStreamError
        DisplayEvent("OnStreamError")
    End Sub

    Private Sub cmdPubSub_Click(sender As Object, e As System.EventArgs) Handles cmdPubSub.Click
        Dim frm = New FrmPubSub(xmppClient)
        frm.Show()
    End Sub

#Region "<< PubSub Event >>"
    Private Sub pubSubManager1_OnEvent(sender As Object, e As MessageEventArgs) Handles pubSubManager.OnEvent
        DisplayEvent("OnPubsubEvent")
    End Sub
#End Region

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Util.SaveSettings(_settings)
    End Sub

    Private Sub chatToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles chatToolStripMenuItem.Click
        If listContacts.SelectedItems.Count > 0 Then
            Dim item = listContacts.SelectedItems(0)
            If Not Util.ChatForms.ContainsKey(item.Name) Then
                Dim f = New FrmChat(item.Name, xmppClient, item.Text)
                f.Show()
            End If
        End If
    End Sub

    Private Sub vCardToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles  vCardToolStripMenuItem.Click
        If listContacts.SelectedItems.Count > 0 Then
            Dim vcard As New FrmVCard(xmppClient, listContacts.SelectedItems(0).Name, False)
            vcard.Show()
        End If
    End Sub
        
    Private Sub listContacts_MouseUp(sender As Object, e As MouseEventArgs) Handles listContacts.MouseUp
        'Check if right clicked on a ListView Item
        If (listContacts.SelectedItems.Count <> 0) AndAlso (e.Button = MouseButtons.Right) Then
            ' dynamically adjust context menu with resources.
            sendFileToolStripMenuItem.DropDownItems.Clear()
            Dim item = TryCast(listContacts.SelectedItems(0), RosterListViewItem)
            For Each res As String In item.Resources
                Dim jid As Jid = item.Name + "/" + res
                Dim submenu = New ToolStripMenuItem(res)
                   
                AddHandler submenu.Click, Function() 
                    Dim frmSendFile As New FrmSendFile(fm, jid)
                    frmSendFile.Show()
                                          End Function
					
                sendFileToolStripMenuItem.DropDownItems.Add(submenu)
            Next
            ' show context menu
            ctxMenuRoster.Show(Cursor.Position)
        End If
    End Sub

    Private Sub xmppClient_OnRegisterInformation(sender As Object, e As RegisterEventArgs) Handles xmppClient.OnRegisterInformation
        e.Register.RemoveAll(Of Data)()

        e.Register.Username = xmppClient.Username
        e.Register.Password = xmppClient.Password
    End Sub

    Private Sub xmppClient_OnRegister(sender As Object, e As Matrix.EventArgs) Handles xmppClient.OnRegister

    End Sub

    Private Sub xmppClient_OnRegisterError(sender As Object, e As IqEventArgs) Handles xmppClient.OnRegisterError
        xmppClient.Close()
    End Sub

    Private Sub presenceManager_OnSubscribe(sender As Object, e As PresenceEventArgs) Handles presenceManager.OnSubscribe
        presenceManager.ApproveSubscriptionRequest(e.Presence.From)
        'presenceManager.DenySubscriptionRequest(e.Presence.From);
    End Sub

    Private Sub fm_OnFile(sender As Object, e As FileTransferEventArgs)
        Dim recvFile = New FrmReceiveFile(fm, e)
        recvFile.Show()
        recvFile.StartAccept()
        'e.Accept = true;

    End Sub

    Private Sub xmppClient_OnBeforeSendPresence(sender As Object, e As PresenceEventArgs) Handles xmppClient.OnBeforeSendPresence
        ' YOu can add addiotional custom content to outgoing presences here.
        'e.Presence.Add(new XElement("foo"));
    End Sub

    Private Sub cmdVcard_Click(sender As Object, e As System.EventArgs) Handles cmdVcard.Click
        Dim vcard As New FrmVCard(xmppClient, Nothing, True)
        vcard.Show()
    End Sub


    Private Sub tsmiEnterRoom_Click(sender As Object, e As System.EventArgs) Handles tsmiEnterRoom.Click
        Dim input = New FrmInputBox("Enter your Nickname for the chatroom", "Nickname", "Nickname")
        If input.ShowDialog() = DialogResult.OK Then
            Dim nickname As String = input.Result
            input = New FrmInputBox("Enter the Jid of the room to join (e.g. jdev@conference.jabber.org)", "Room")
            If input.ShowDialog() = DialogResult.OK Then
                Dim roomJid = New Jid(input.Result)
                dim frmGroupChat as New FrmGroupChat(xmppClient, roomJid, nickname)
                frmGroupChat.Show()
            End If
        End If
    End Sub
End Class