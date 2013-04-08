Imports System.Linq
Imports System.Windows.Forms
Imports Matrix
Imports Matrix.Xmpp.Client
Imports Matrix.Xmpp.Vcard

Public Partial Class FrmVCard
    Inherits Form
    Private ReadOnly xmppClient As XmppClient


    Public Sub New(xc As XmppClient, jid As Jid, own As Boolean)
        InitializeComponent()

        xmppClient = xc

        If own Then
            Text = "My VCard"
            cmdPublish.Enabled = True
            GetMyVcard()
        Else
            Text = "VCard: " + jid.ToString()
            GetVcard(jid)

        End If
    End Sub

    Private Sub GetVcard(jid As Jid)
        Dim viq = New VcardIq() With { _
                .[To] = jid, _
                .Type = Xmpp.IqType.[get] _
                }
        xmppClient.IqFilter.SendIq(viq, AddressOf VcardResponse)
    End Sub

    Private Sub GetMyVcard()
        Dim viq = New VcardIq() With { _
                .Type = Xmpp.IqType.[get] _
                }
        xmppClient.IqFilter.SendIq(viq, AddressOf VcardResponse)
    End Sub

    Private Sub VcardResponse(sender As Object, e As IqEventArgs)
        If e.Iq.Type = Xmpp.IqType.result Then
            Dim vc = TryCast(e.Iq.Query, Vcard)
            txtName.Text = vc.Fullname
            txtNickname.Text = vc.Nickname

            Dim email = vc.GetEmails().FirstOrDefault(Function(m) m.IsInternet)
            If email IsNot Nothing Then
                txtEmail.Text = email.Address
            End If
        End If
    End Sub


    Private Sub SetMyVcard()
        Dim viq = New VcardIq() With { _
                .Type = Xmpp.IqType.[set] _
                }

        If Not String.IsNullOrEmpty(txtName.Text) Then
            viq.Vcard.Fullname = txtName.Text
        End If

        If Not String.IsNullOrEmpty(txtNickname.Text) Then
            viq.Vcard.Nickname = txtNickname.Text
        End If

        If Not String.IsNullOrEmpty(txtEmail.Text) Then
            viq.Vcard.AddEmail(New Email() With { _
                                  .IsInternet = True, _
                                  .Address = txtEmail.Text _
                                  })
        End If

        xmppClient.IqFilter.SendIq(viq, AddressOf VcardUpdateResponse)
    End Sub

    Private Sub VcardUpdateResponse(sender As Object, e As IqEventArgs)
        If e.Iq.Type = Xmpp.IqType.result Then
            MessageBox.Show("The VCard was updated successful!!")
        End If
    End Sub

    Private Sub cmdPublish_Click(sender As Object, e As System.EventArgs) Handles cmdPublish.Click
        SetMyVcard()
    End Sub
End Class