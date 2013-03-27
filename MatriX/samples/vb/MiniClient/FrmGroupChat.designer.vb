

Partial Class FrmGroupChat
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

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

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvwRoster = New System.Windows.Forms.ListView()
        Me.headerNickname = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.headerStatus = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.headerRole = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.headerAffiliation = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ilsRoster = New System.Windows.Forms.ImageList(Me.components)
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtfChat = New System.Windows.Forms.RichTextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdChangeSubject = New System.Windows.Forms.Button()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtfSend = New System.Windows.Forms.RichTextBox()
        Me.cmdSend = New System.Windows.Forms.Button()
        CType(Me.splitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.splitContainer1.Panel1.SuspendLayout
        Me.splitContainer1.Panel2.SuspendLayout
        Me.splitContainer1.SuspendLayout
        CType(Me.splitContainer2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.splitContainer2.Panel1.SuspendLayout
        Me.splitContainer2.Panel2.SuspendLayout
        Me.splitContainer2.SuspendLayout
        Me.tableLayoutPanel2.SuspendLayout
        Me.tableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'statusBar1
        '
        Me.statusBar1.Location = New System.Drawing.Point(0, 417)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Size = New System.Drawing.Size(781, 24)
        Me.statusBar1.TabIndex = 6
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.lvwRoster)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.splitContainer2)
        Me.splitContainer1.Size = New System.Drawing.Size(781, 417)
        Me.splitContainer1.SplitterDistance = 294
        Me.splitContainer1.TabIndex = 7
        '
        'lvwRoster
        '
        Me.lvwRoster.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.headerNickname, Me.headerStatus, Me.headerRole, Me.headerAffiliation})
        Me.lvwRoster.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwRoster.Location = New System.Drawing.Point(0, 0)
        Me.lvwRoster.Name = "lvwRoster"
        Me.lvwRoster.Size = New System.Drawing.Size(294, 417)
        Me.lvwRoster.SmallImageList = Me.ilsRoster
        Me.lvwRoster.TabIndex = 0
        Me.lvwRoster.UseCompatibleStateImageBehavior = false
        Me.lvwRoster.View = System.Windows.Forms.View.Details
        '
        'headerNickname
        '
        Me.headerNickname.Text = "Nickname"
        Me.headerNickname.Width = 82
        '
        'headerStatus
        '
        Me.headerStatus.Text = "Status"
        Me.headerStatus.Width = 73
        '
        'headerRole
        '
        Me.headerRole.Text = "Role"
        '
        'headerAffiliation
        '
        Me.headerAffiliation.Text = "Affiliation"
        '
        'ilsRoster
        '
        Me.ilsRoster.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilsRoster.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilsRoster.TransparentColor = System.Drawing.Color.Transparent
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer2.Name = "splitContainer2"
        Me.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.tableLayoutPanel2)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.tableLayoutPanel1)
        Me.splitContainer2.Size = New System.Drawing.Size(483, 417)
        Me.splitContainer2.SplitterDistance = 339
        Me.splitContainer2.TabIndex = 0
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 3
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80!))
        Me.tableLayoutPanel2.Controls.Add(Me.rtfChat, 0, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.label1, 0, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.cmdChangeSubject, 2, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.txtSubject, 1, 0)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 2
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(483, 339)
        Me.tableLayoutPanel2.TabIndex = 0
        '
        'rtfChat
        '
        Me.tableLayoutPanel2.SetColumnSpan(Me.rtfChat, 3)
        Me.rtfChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfChat.Location = New System.Drawing.Point(3, 33)
        Me.rtfChat.Name = "rtfChat"
        Me.rtfChat.Size = New System.Drawing.Size(477, 303)
        Me.rtfChat.TabIndex = 3
        Me.rtfChat.Text = ""
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label1.Location = New System.Drawing.Point(3, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 30)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Subject:"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdChangeSubject
        '
        Me.cmdChangeSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdChangeSubject.Location = New System.Drawing.Point(406, 3)
        Me.cmdChangeSubject.Name = "cmdChangeSubject"
        Me.cmdChangeSubject.Size = New System.Drawing.Size(74, 24)
        Me.cmdChangeSubject.TabIndex = 6
        Me.cmdChangeSubject.Text = "change"
        Me.cmdChangeSubject.UseVisualStyleBackColor = true
        '
        'txtSubject
        '
        Me.txtSubject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSubject.Location = New System.Drawing.Point(73, 3)
        Me.txtSubject.Multiline = true
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(327, 24)
        Me.txtSubject.TabIndex = 5
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel1.Controls.Add(Me.rtfSend, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.cmdSend, 0, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(483, 74)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'rtfSend
        '
        Me.rtfSend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfSend.Location = New System.Drawing.Point(3, 3)
        Me.rtfSend.Name = "rtfSend"
        Me.rtfSend.Size = New System.Drawing.Size(477, 38)
        Me.rtfSend.TabIndex = 0
        Me.rtfSend.Text = ""
        '
        'cmdSend
        '
        Me.cmdSend.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cmdSend.Location = New System.Drawing.Point(400, 47)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(80, 24)
        Me.cmdSend.TabIndex = 1
        Me.cmdSend.Text = "&Send"
        Me.cmdSend.UseVisualStyleBackColor = true
        '
        'FrmGroupChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 441)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.statusBar1)
        Me.Name = "FrmGroupChat"
        Me.Text = "Group Chat"
        Me.splitContainer1.Panel1.ResumeLayout(false)
        Me.splitContainer1.Panel2.ResumeLayout(false)
        CType(Me.splitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.splitContainer1.ResumeLayout(false)
        Me.splitContainer2.Panel1.ResumeLayout(false)
        Me.splitContainer2.Panel2.ResumeLayout(false)
        CType(Me.splitContainer2,System.ComponentModel.ISupportInitialize).EndInit
        Me.splitContainer2.ResumeLayout(false)
        Me.tableLayoutPanel2.ResumeLayout(false)
        Me.tableLayoutPanel2.PerformLayout
        Me.tableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)

    End Sub

#End Region

    Private WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents splitContainer2 As System.Windows.Forms.SplitContainer
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents rtfSend As System.Windows.Forms.RichTextBox
    Private WithEvents lvwRoster As System.Windows.Forms.ListView
    Private WithEvents headerNickname As System.Windows.Forms.ColumnHeader
    Private WithEvents headerStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents cmdSend As System.Windows.Forms.Button
    Private WithEvents ilsRoster As System.Windows.Forms.ImageList
    Private WithEvents tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents txtSubject As System.Windows.Forms.TextBox
    Private WithEvents rtfChat As System.Windows.Forms.RichTextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmdChangeSubject As System.Windows.Forms.Button
    Private WithEvents headerRole As System.Windows.Forms.ColumnHeader
    Private WithEvents headerAffiliation As System.Windows.Forms.ColumnHeader

End Class