Imports System.IO
Imports System.Windows.Forms
Imports Matrix
Imports Matrix.Xmpp.Client

Public Partial Class FrmSendFile
    Inherits Form
    Private sid As String = ""
    Private _jid As Jid
    Private WithEvents fm As FileTransferManager
		
    Public Sub New(ftm As FileTransferManager, jid As Jid)
        InitializeComponent()

        fm = ftm
        _jid = jid

        Text = "File transfer: " + jid.ToString

        AddHandler fm.OnError, AddressOf fm_OnError
        AddHandler fm.OnEnd, AddressOf fm_OnEnd
        AddHandler fm.OnStart, AddressOf fm_OnStart
        AddHandler fm.OnProgress, AddressOf fm_OnProgress
    End Sub

    Private Sub fm_OnError(sender As Object, e As ExceptionEventArgs)
        Dim ex = TryCast(e.Exception, FileTransferException)
        If ex.Sid <> sid Then
            Return
        End If

        ' file transfer failed because our contact went offline or some
        ' other errror occured.
        MessageBox.Show("file transfer failed!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        cmdChooseFile.Enabled = InlineAssignHelper(cmdAbort.Enabled, InlineAssignHelper(cmdSend.Enabled, False))
    End Sub

    Private Sub fm_OnEnd(sender As Object, e As FileTransferEventArgs)
        If e.Sid <> sid Then
            Return
        End If

        MessageBox.Show("file transfer ended with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub fm_OnStart(sender As Object, e As FileTransferEventArgs)
        If e.Sid <> sid Then
            Return
        End If
        ''' file transfer started
    End Sub

    Private Sub fm_OnProgress(sender As Object, e As FileTransferEventArgs)
        If e.Sid <> sid Then
            Return
        End If

        progressBar.Value = CInt((CDbl(e.BytesTransmitted) / CDbl(e.FileSize)) * 100)
    End Sub

    Private Sub cmdChooseFile_Click(sender As Object, e As System.EventArgs) Handles cmdChooseFile.Click 
        Dim ofd = New OpenFileDialog()
        If ofd.ShowDialog() = DialogResult.OK Then
            lblFileName.Text = ofd.FileName

            Dim fi = New FileInfo(ofd.FileName)
            lblSize.Text = Util.HumanReadableFileSize(fi.Length)

            cmdSend.Enabled = True
        End If
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As System.EventArgs) Handles cmdSend.Click
        sid = fm.Send(_jid, lblFileName.Text, txtDescription.Text)
        cmdSend.Enabled = cmdChooseFile.Enabled = False
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class