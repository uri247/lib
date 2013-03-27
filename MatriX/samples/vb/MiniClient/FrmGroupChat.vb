Imports System.Drawing
Imports System.Windows.Forms
Imports Matrix
Imports Matrix.Xmpp
Imports Matrix.Xmpp.Client

Public Partial Class FrmGroupChat
    Inherits Form
    Private mm As MucManager
		
    Public Sub New(xmppClient As XmppClient, roomJid As Jid, nickname As String)
        InitializeComponent()

        _roomJid = roomJid
        _xmppClient = xmppClient
        _nickname = nickname

        mm = New MucManager(xmppClient)

        ' Setup new Message Callback using the MessageFilter
        _xmppClient.MessageFilter.Add(roomJid, New BareJidComparer(), AddressOf MessageCallback)

        ' Setup new Presence Callback using the PresenceFilter

        _xmppClient.PresenceFilter.Add(roomJid, New BareJidComparer(),AddressOf PresenceCallback)
    End Sub
		
    Private ReadOnly _roomJid As Jid
    Private ReadOnly _xmppClient As XmppClient
    Private ReadOnly _nickname As String

    Private Sub FrmGroupChat_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        If _roomJid IsNot Nothing Then
            mm.EnterRoom(_roomJid, _nickname)
        End If
    End Sub

    Private Sub FrmGroupChat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If _roomJid IsNot Nothing Then
            mm.ExitRoom(_roomJid, _nickname)

            ' Remove the Message Callback in the MessageFilter
            _xmppClient.MessageFilter.Remove(_roomJid)

            ' Remove the Presence Callback in the MessageFilter
            _xmppClient.PresenceFilter.Remove(_roomJid)
        End If

    End Sub

    Private Sub MessageCallback(sender As Object, e As MessageEventArgs)
        If e.Message.Type = MessageType.groupchat Then
            IncomingMessage(e.Message)
        End If
    End Sub


    Private Sub PresenceCallback(sender As Object, e As PresenceEventArgs)

        Dim mucX = e.Presence.MucUser

        ' check for status code 201, this means the room is not ready to use yet
        ' we request an instant room and accept the and accept the default configuration by the server
        If mucX.HasStatus(201) Then
            ' 201 =  room is awaiting configuration.
            mm.RequestInstantRoom(_roomJid)
        End If


        Dim lvi = FindListViewItem(e.Presence.From)
        If lvi IsNot Nothing Then
            If e.Presence.Type = PresenceType.unavailable Then
                lvi.Remove()
            Else
                Dim imageIdx As Integer = Util.GetRosterImageIndex(e.Presence)
                lvi.ImageIndex = imageIdx
                lvi.SubItems(1).Text = (If(e.Presence.Status, ""))

                Dim u = e.Presence.MucUser
                If u IsNot Nothing Then
                    lvi.SubItems(2).Text = u.Item.Affiliation.ToString()
                    lvi.SubItems(3).Text = u.Item.Role.ToString()
                End If
            End If
        Else
            Dim imageIdx As Integer = Util.GetRosterImageIndex(e.Presence)

            Dim lv = New ListViewItem(e.Presence.From.Resource) With { _
                    .Tag = e.Presence.From.ToString() _
                    }

            lv.SubItems.Add(If(e.Presence.Status, ""))

            Dim u = e.Presence.MucUser
            If u IsNot Nothing Then
                lv.SubItems.Add(u.Item.Affiliation.ToString())
                lv.SubItems.Add(u.Item.Role.ToString())
            End If
            lv.ImageIndex = imageIdx
            lvwRoster.Items.Add(lv)
        End If
    End Sub

    Private Function FindListViewItem(jid As Jid) As ListViewItem
        For Each lvi As ListViewItem In lvwRoster.Items
            If jid.ToString().ToLower() = lvi.Tag.ToString().ToLower() Then
                Return lvi
            End If
        Next
        Return Nothing
    End Function

    Private Sub IncomingMessage(msg As Matrix.Xmpp.Client.Message)
        If msg.Type = MessageType.[error] Then
            'Handle errors here
            ' we dont handle them in this example
            Return
        End If

        If msg.Subject IsNot Nothing Then
            txtSubject.Text = msg.Subject

            rtfChat.SelectionColor = Color.DarkGreen
            ' The Nickname of the sender is in GroupChat in the Resource of the Jid
            rtfChat.AppendText(msg.From.Resource + " changed subject: ")
            rtfChat.SelectionColor = Color.Black
            rtfChat.AppendText(msg.Subject)
            rtfChat.AppendText(vbCr & vbLf)
        Else
            If msg.Body Is Nothing Then
                Return
            End If

            rtfChat.SelectionColor = Color.Red
            ' The Nickname of the sender is in GroupChat in the Resource of the Jid
            rtfChat.AppendText(msg.From.Resource + " said: ")
            rtfChat.SelectionColor = Color.Black
            rtfChat.AppendText(msg.Body)
            rtfChat.AppendText(vbCr & vbLf)
        End If
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As System.EventArgs) Handles cmdSend.Click
        ' Make sure that the users send no empty messages
        If rtfSend.Text.Length > 0 Then
            Dim msg = New Matrix.Xmpp.Client.Message() With { _
                    .Type = MessageType.groupchat, _
                    .[To] = _roomJid, _
                    .Body = rtfSend.Text _
                    }

            _xmppClient.Send(msg)

            rtfSend.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Changing the subject in a chatroom in MUC rooms this could return an error when you are a normal user and not allowed
    ''' to change the subject.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdChangeSubject_Click(sender As Object, e As System.EventArgs) Handles cmdChangeSubject.Click
        Dim msg = New Matrix.Xmpp.Client.Message() With { _
                .Type = MessageType.groupchat, _
                .[To] = _roomJid, _
                .Subject = txtSubject.Text _
                }

        _xmppClient.Send(msg)
    End Sub
End Class