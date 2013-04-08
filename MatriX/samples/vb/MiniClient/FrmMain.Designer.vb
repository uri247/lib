

Partial Class FrmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.cmdDisconnect = New System.Windows.Forms.Button()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabContacts = New System.Windows.Forms.TabPage()
        Me.listContacts = New System.Windows.Forms.ListView()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.listEvents = New System.Windows.Forms.ListBox()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.rtfDebug = New System.Windows.Forms.RichTextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.cmdPubSub = New System.Windows.Forms.Button()
        Me.cmdVcard = New System.Windows.Forms.Button()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.groupChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEnterRoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.xmppClient = New Matrix.Xmpp.Client.XmppClient()
        Me.mucManager = New Matrix.Xmpp.Client.MucManager()
        Me.pubSubManager = New Matrix.Xmpp.Client.PubSubManager()
        Me.presenceManager = New Matrix.Xmpp.Client.PresenceManager()
        Me.ctxMenuRoster = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.chatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.sendFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.vCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ilstStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.tabControl1.SuspendLayout
        Me.tabContacts.SuspendLayout
        Me.tabPage1.SuspendLayout
        Me.tabPage2.SuspendLayout
        Me.groupBox1.SuspendLayout
        Me.menuStrip1.SuspendLayout
        Me.ctxMenuRoster.SuspendLayout
        Me.SuspendLayout
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(14, 138)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(75, 23)
        Me.cmdConnect.TabIndex = 0
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = true
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.Location = New System.Drawing.Point(95, 138)
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.cmdDisconnect.TabIndex = 1
        Me.cmdDisconnect.Text = "DisConnect"
        Me.cmdDisconnect.UseVisualStyleBackColor = true
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabContacts)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(10, 169)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(477, 284)
        Me.tabControl1.TabIndex = 4
        '
        'tabContacts
        '
        Me.tabContacts.Controls.Add(Me.listContacts)
        Me.tabContacts.Location = New System.Drawing.Point(4, 22)
        Me.tabContacts.Name = "tabContacts"
        Me.tabContacts.Padding = New System.Windows.Forms.Padding(3)
        Me.tabContacts.Size = New System.Drawing.Size(469, 258)
        Me.tabContacts.TabIndex = 2
        Me.tabContacts.Text = "Contacts"
        Me.tabContacts.UseVisualStyleBackColor = true
        '
        'listContacts
        '
        Me.listContacts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listContacts.Location = New System.Drawing.Point(3, 3)
        Me.listContacts.Name = "listContacts"
        Me.listContacts.ShowItemToolTips = true
        Me.listContacts.Size = New System.Drawing.Size(463, 252)
        Me.listContacts.TabIndex = 0
        Me.listContacts.UseCompatibleStateImageBehavior = false
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.listEvents)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(469, 258)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Events"
        Me.tabPage1.UseVisualStyleBackColor = true
        '
        'listEvents
        '
        Me.listEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listEvents.Font = New System.Drawing.Font("Courier New", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.listEvents.FormattingEnabled = true
        Me.listEvents.ItemHeight = 15
        Me.listEvents.Location = New System.Drawing.Point(3, 3)
        Me.listEvents.Name = "listEvents"
        Me.listEvents.Size = New System.Drawing.Size(463, 252)
        Me.listEvents.TabIndex = 0
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.rtfDebug)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(469, 258)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Debug XML"
        Me.tabPage2.UseVisualStyleBackColor = true
        '
        'rtfDebug
        '
        Me.rtfDebug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfDebug.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.rtfDebug.Location = New System.Drawing.Point(3, 3)
        Me.rtfDebug.Name = "rtfDebug"
        Me.rtfDebug.Size = New System.Drawing.Size(463, 252)
        Me.rtfDebug.TabIndex = 0
        Me.rtfDebug.Text = ""
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.txtHost)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.txtServer)
        Me.groupBox1.Controls.Add(Me.txtPassword)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.txtUsername)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(14, 31)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(473, 94)
        Me.groupBox1.TabIndex = 6
        Me.groupBox1.TabStop = false
        Me.groupBox1.Text = "Credentials"
        '
        'txtHost
        '
        Me.txtHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHost.Location = New System.Drawing.Point(303, 68)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(129, 20)
        Me.txtHost.TabIndex = 7
        '
        'label4
        '
        Me.label4.AutoSize = true
        Me.label4.Location = New System.Drawing.Point(219, 71)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(78, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Host (optional):"
        '
        'txtServer
        '
        Me.txtServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtServer.Location = New System.Drawing.Point(70, 68)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(129, 20)
        Me.txtServer.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPassword.Location = New System.Drawing.Point(70, 39)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(129, 20)
        Me.txtPassword.TabIndex = 4
        '
        'label3
        '
        Me.label3.AutoSize = true
        Me.label3.Location = New System.Drawing.Point(6, 71)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Server:"
        '
        'label2
        '
        Me.label2.AutoSize = true
        Me.label2.Location = New System.Drawing.Point(8, 42)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(56, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtUsername.Location = New System.Drawing.Point(70, 13)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(129, 20)
        Me.txtUsername.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Location = New System.Drawing.Point(6, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Username:"
        '
        'statusStrip1
        '
        Me.statusStrip1.Location = New System.Drawing.Point(0, 456)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(502, 22)
        Me.statusStrip1.TabIndex = 8
        Me.statusStrip1.Text = "statusStrip1"
        '
        'cmdPubSub
        '
        Me.cmdPubSub.Location = New System.Drawing.Point(176, 138)
        Me.cmdPubSub.Name = "cmdPubSub"
        Me.cmdPubSub.Size = New System.Drawing.Size(75, 23)
        Me.cmdPubSub.TabIndex = 10
        Me.cmdPubSub.Text = "PubSub"
        Me.cmdPubSub.UseVisualStyleBackColor = true
        '
        'cmdVcard
        '
        Me.cmdVcard.Location = New System.Drawing.Point(257, 138)
        Me.cmdVcard.Name = "cmdVcard"
        Me.cmdVcard.Size = New System.Drawing.Size(75, 23)
        Me.cmdVcard.TabIndex = 11
        Me.cmdVcard.Text = "Vcard"
        Me.cmdVcard.UseVisualStyleBackColor = true
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.groupChatToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(502, 24)
        Me.menuStrip1.TabIndex = 14
        Me.menuStrip1.Text = "menuStrip1"
        '
        'groupChatToolStripMenuItem
        '
        Me.groupChatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiEnterRoom})
        Me.groupChatToolStripMenuItem.Name = "groupChatToolStripMenuItem"
        Me.groupChatToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.groupChatToolStripMenuItem.Text = "Group Chat"
        '
        'tsmiEnterRoom
        '
        Me.tsmiEnterRoom.Name = "tsmiEnterRoom"
        Me.tsmiEnterRoom.Size = New System.Drawing.Size(208, 22)
        Me.tsmiEnterRoom.Text = "Enter or create chat room"
        '
        'xmppClient
        '
        Me.xmppClient.Compression = false
        Me.xmppClient.Dispatcher = Nothing
        Me.xmppClient.Hostname = Nothing
        Me.xmppClient.ProxyHostname = Nothing
        Me.xmppClient.ProxyPass = Nothing
        Me.xmppClient.ProxyPort = 1080
        Me.xmppClient.ProxyType = Matrix.Net.Proxy.ProxyType.None
        Me.xmppClient.ProxyUser = Nothing
        Me.xmppClient.ResolveSrvRecords = true
        Me.xmppClient.Status = ""
        Me.xmppClient.Transport = Matrix.Net.Transport.Socket
        Me.xmppClient.Uri = Nothing
        '
        'mucManager
        '
        Me.mucManager.XmppClient = Me.xmppClient
        '
        'pubSubManager
        '
        Me.pubSubManager.XmppClient = Me.xmppClient
        '
        'presenceManager
        '
        Me.presenceManager.XmppClient = Me.xmppClient
        '
        'ctxMenuRoster
        '
        Me.ctxMenuRoster.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.chatToolStripMenuItem, Me.sendFileToolStripMenuItem, Me.vCardToolStripMenuItem})
        Me.ctxMenuRoster.Name = "ctxMenuRoster"
        Me.ctxMenuRoster.Size = New System.Drawing.Size(121, 70)
        '
        'chatToolStripMenuItem
        '
        Me.chatToolStripMenuItem.Name = "chatToolStripMenuItem"
        Me.chatToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.chatToolStripMenuItem.Text = "chat"
        '
        'sendFileToolStripMenuItem
        '
        Me.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem"
        Me.sendFileToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.sendFileToolStripMenuItem.Text = "send File"
        '
        'vCardToolStripMenuItem
        '
        Me.vCardToolStripMenuItem.Name = "vCardToolStripMenuItem"
        Me.vCardToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.vCardToolStripMenuItem.Text = "VCard"
        '
        'ilstStatus
        '
        Me.ilstStatus.ImageStream = CType(resources.GetObject("ilstStatus.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ilstStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.ilstStatus.Images.SetKeyName(0, "status_grey.png")
        Me.ilstStatus.Images.SetKeyName(1, "status_green.png")
        Me.ilstStatus.Images.SetKeyName(2, "status_yellow.png")
        Me.ilstStatus.Images.SetKeyName(3, "status_red.png")
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 478)
        Me.Controls.Add(Me.cmdVcard)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.cmdPubSub)
        Me.Controls.Add(Me.cmdDisconnect)
        Me.Controls.Add(Me.cmdConnect)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "FrmMain"
        Me.Text = "MiniClient"
        Me.tabControl1.ResumeLayout(false)
        Me.tabContacts.ResumeLayout(false)
        Me.tabPage1.ResumeLayout(false)
        Me.tabPage2.ResumeLayout(false)
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.menuStrip1.ResumeLayout(false)
        Me.menuStrip1.PerformLayout
        Me.ctxMenuRoster.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

#End Region

    Private WithEvents cmdConnect As System.Windows.Forms.Button
    Private WithEvents cmdDisconnect As System.Windows.Forms.Button
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents listEvents As System.Windows.Forms.ListBox
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtUsername As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtServer As System.Windows.Forms.TextBox
    Private WithEvents rtfDebug As System.Windows.Forms.RichTextBox
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents xmppClient As Matrix.Xmpp.Client.XmppClient
    Private WithEvents mucManager As Matrix.Xmpp.Client.MucManager
    Private WithEvents tabContacts As System.Windows.Forms.TabPage
    Private WithEvents listContacts As System.Windows.Forms.ListView
		
    Private WithEvents cmdPubSub As System.Windows.Forms.Button
    Private WithEvents pubSubManager As Matrix.Xmpp.Client.PubSubManager
		
		
    Private WithEvents presenceManager As Matrix.Xmpp.Client.PresenceManager
		
		
    Private WithEvents cmdVcard As System.Windows.Forms.Button
    Private WithEvents txtHost As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents groupChatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmiEnterRoom As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ctxMenuRoster As System.Windows.Forms.ContextMenuStrip
    Private WithEvents chatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents sendFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents vCardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ilstStatus As System.Windows.Forms.ImageList
End Class