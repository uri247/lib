Imports System.Drawing
Imports System.Windows.Forms
Imports Matrix
Imports Matrix.Xmpp
Imports Matrix.Xmpp.Client


Public Partial Class FrmChat
    Inherits Form
    Private _xmppClient As XmppClient
    Private _jid As Jid
    Private ReadOnly _nickname As String


    Public Sub New(jid As Jid, con As XmppClient, nickname As String)
        _jid = jid
        _xmppClient = con
        _nickname = nickname

        InitializeComponent()

        Text = "Chat with " + nickname

        Util.ChatForms.Add(_jid.Bare.ToLower(), Me)

        ' Setup new Message Callback
        con.MessageFilter.Add(jid, New BareJidComparer(), AddressOf OnMessage)
    End Sub

    Private Sub OutgoingMessage(msg As Client.Message)
        rtfChat.SelectionColor = Color.Blue
        rtfChat.AppendText("Me said: ")
        rtfChat.SelectionColor = Color.Black
        rtfChat.AppendText(msg.Body)
        rtfChat.AppendText(vbCr & vbLf)
    End Sub

    Public Sub IncomingMessage(msg As Client.Message)
        rtfChat.SelectionColor = Color.Red
        rtfChat.AppendText(_nickname + " said: ")
        rtfChat.SelectionColor = Color.Black
        rtfChat.AppendText(msg.Body)
        rtfChat.AppendText(vbCr & vbLf)
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As System.EventArgs) Handles cmdSend.Click
        Dim msg = New Client.Message() With { _
                .Type = MessageType.chat, _
                .[To] = _jid, _
                .Body = rtfSend.Text _
                }

        _xmppClient.Send(msg)
        OutgoingMessage(msg)
        rtfSend.Text = ""
    End Sub

    Private Sub OnMessage(sender As Object, e As MessageEventArgs)
        If e.Message.Body IsNot Nothing Then
            IncomingMessage(e.Message)
        End If
    End Sub

    Private Sub FrmChat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Util.ChatForms.Remove(_jid.Bare.ToLower())
        _xmppClient.MessageFilter.Remove(_jid)
        _xmppClient = Nothing
    End Sub
End Class