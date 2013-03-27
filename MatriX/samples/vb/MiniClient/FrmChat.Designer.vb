
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Partial Class FrmChat
    Private components As System.ComponentModel.Container = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub




#Region "Form-Designer Code"

    Private Sub InitializeComponent()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.rtfSend = New System.Windows.Forms.RichTextBox()
        Me.splitter1 = New System.Windows.Forms.Splitter()
        Me.rtfChat = New System.Windows.Forms.RichTextBox()
        CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'statusBar1
        '
        Me.statusBar1.Location = New System.Drawing.Point(0, 236)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Size = New System.Drawing.Size(471, 24)
        Me.statusBar1.TabIndex = 5
        '
        'pictureBox1
        '
        Me.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pictureBox1.Location = New System.Drawing.Point(0, 200)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(471, 36)
        Me.pictureBox1.TabIndex = 6
        Me.pictureBox1.TabStop = false
        '
        'cmdSend
        '
        Me.cmdSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdSend.Location = New System.Drawing.Point(391, 206)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(72, 24)
        Me.cmdSend.TabIndex = 7
        Me.cmdSend.Text = "&Send"
        '
        'rtfSend
        '
        Me.rtfSend.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rtfSend.Location = New System.Drawing.Point(0, 152)
        Me.rtfSend.Name = "rtfSend"
        Me.rtfSend.Size = New System.Drawing.Size(471, 48)
        Me.rtfSend.TabIndex = 8
        Me.rtfSend.Text = ""
        '
        'splitter1
        '
        Me.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitter1.Location = New System.Drawing.Point(0, 144)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(471, 8)
        Me.splitter1.TabIndex = 9
        Me.splitter1.TabStop = false
        '
        'rtfChat
        '
        Me.rtfChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfChat.Location = New System.Drawing.Point(0, 0)
        Me.rtfChat.Name = "rtfChat"
        Me.rtfChat.Size = New System.Drawing.Size(471, 144)
        Me.rtfChat.TabIndex = 10
        Me.rtfChat.Text = ""
        '
        'FrmChat
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(471, 260)
        Me.Controls.Add(Me.rtfChat)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.rtfSend)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.statusBar1)
        Me.Name = "FrmChat"
        Me.Text = "frmChat"
        CType(Me.pictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

    End Sub
#End Region

    Private WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents cmdSend As System.Windows.Forms.Button
    Private WithEvents rtfSend As System.Windows.Forms.RichTextBox
    Private WithEvents splitter1 As System.Windows.Forms.Splitter
    Private WithEvents rtfChat As System.Windows.Forms.RichTextBox
End Class