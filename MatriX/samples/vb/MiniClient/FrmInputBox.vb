Imports System
Imports System.Windows.Forms

Public Partial Class FrmInputBox
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(prompt As String, title As String)
        Me.New(prompt, title, "")
    End Sub

    Public Sub New(prompt As String, title As String, text As String)
        Me.New()
        lblMessage.Text = prompt
        Text = title
        txtInput.Text = text
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Public ReadOnly Property Result() As String
        Get
            Return txtInput.Text
        End Get
    End Property
End Class