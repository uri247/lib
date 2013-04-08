Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports Matrix
Imports Matrix.Xmpp.Client

Public Partial Class FrmReceiveFile
    Inherits Form
    Private haveResponse As Boolean
    Private fm As FileTransferManager
    Private ftea As FileTransferEventArgs
    Public Sub New(ftm As FileTransferManager, fea As FileTransferEventArgs)
        InitializeComponent()

        fm = ftm
        ftea = fea

        Text = "File transfer: " + ftea.Jid.ToString

        lblSize.Text = Util.HumanReadableFileSize(ftea.FileSize)
        lblFileName.Text = ftea.Filename
        lblDescription.Text = ftea.Description

        AddHandler fm.OnError, AddressOf fm_OnError
        AddHandler fm.OnEnd , AddressOf fm_OnEnd
        AddHandler fm.OnStart, AddressOf fm_OnStart
        AddHandler fm.OnProgress, AddressOf fm_OnProgress
          

    End Sub

    Public Sub StartAccept()
        While Not haveResponse
            Thread.Sleep(100)
            Application.DoEvents()
        End While
        If Not ftea.Accept Then
            Close()
        End If
    End Sub

    Private Sub fm_OnError(sender As Object, e As ExceptionEventArgs)
        Dim ex = TryCast(e.Exception, FileTransferException)
        If ex.Sid <> ftea.Sid Then
            Return
        End If

        ' file transfer failed because our contact went offline or some
        ' other errror occured.
        MessageBox.Show("file transfer failed!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    End Sub

    Private Sub fm_OnEnd(sender As Object, e As FileTransferEventArgs)
        If e.Sid <> ftea.Sid Then
            Return
        End If

        MessageBox.Show("file transfer ended with success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub fm_OnStart(sender As Object, e As FileTransferEventArgs)
        If e.Sid <> ftea.Sid Then
            Return
        End If
        ''' file transfer started
    End Sub

    Private Sub fm_OnProgress(sender As Object, e As FileTransferEventArgs)
        If e.Sid <> ftea.Sid Then
            Return
        End If

        progressBar.Value = CInt((CDbl(e.BytesTransmitted) / CDbl(e.FileSize)) * 100)
    End Sub

    Private Sub cmdAbort_Click(sender As Object, e As System.EventArgs) Handles cmdAbort.Click


    End Sub

    Private Sub cmdAccept_Click(sender As Object, e As System.EventArgs) Handles cmdAccept.Click
        ftea.Accept = True
        haveResponse = True
        cmdAccept.Enabled = False
    End Sub

    Private Sub cmdRefuse_Click(sender As Object, e As System.EventArgs) Handles cmdRefuse.Click
        ftea.Accept = False
        haveResponse = True
    End Sub

    Private Sub cmdSaveAs_Click(sender As Object, e As System.EventArgs) Handles cmdSaveAs.Click
        ' set folder and filename
        Dim sf = New SaveFileDialog()
        If sf.ShowDialog() = DialogResult.OK Then
            ftea.Directory = Path.GetDirectoryName(sf.FileName)
            ftea.Filename = Path.GetFileName(sf.FileName)
        End If
    End Sub
End Class