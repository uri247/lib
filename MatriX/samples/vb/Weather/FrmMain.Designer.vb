<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.cmdRequestWeatherInfo = New System.Windows.Forms.Button()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtRequestFrom = New System.Windows.Forms.TextBox()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.listEvents = New System.Windows.Forms.ListBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.rtfDebug = New System.Windows.Forms.RichTextBox()
        Me.cmdDisconnect = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.xmppClient = New Matrix.Xmpp.Client.XmppClient()
        Me.groupBox2.SuspendLayout
        Me.tabPage1.SuspendLayout
        Me.tabControl1.SuspendLayout
        Me.tabPage2.SuspendLayout
        Me.groupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(14, 110)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(75, 23)
        Me.cmdConnect.TabIndex = 13
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = true
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPassword.Location = New System.Drawing.Point(70, 39)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(152, 20)
        Me.txtPassword.TabIndex = 4
        '
        'label3
        '
        Me.label3.AutoSize = true
        Me.label3.Location = New System.Drawing.Point(6, 75)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Server:"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(64, 72)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(157, 20)
        Me.txtZip.TabIndex = 15
        '
        'label6
        '
        Me.label6.AutoSize = true
        Me.label6.Location = New System.Drawing.Point(6, 75)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 14
        Me.label6.Text = "Zip code:"
        '
        'label5
        '
        Me.label5.AutoSize = true
        Me.label5.Location = New System.Drawing.Point(6, 46)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(159, 13)
        Me.label5.TabIndex = 13
        Me.label5.Text = "eg: user@server.com/Resource"
        '
        'txtServer
        '
        Me.txtServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtServer.Location = New System.Drawing.Point(70, 68)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(152, 20)
        Me.txtServer.TabIndex = 5
        '
        'cmdRequestWeatherInfo
        '
        Me.cmdRequestWeatherInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cmdRequestWeatherInfo.Location = New System.Drawing.Point(250, 110)
        Me.cmdRequestWeatherInfo.Name = "cmdRequestWeatherInfo"
        Me.cmdRequestWeatherInfo.Size = New System.Drawing.Size(108, 23)
        Me.cmdRequestWeatherInfo.TabIndex = 18
        Me.cmdRequestWeatherInfo.Text = "Request"
        Me.cmdRequestWeatherInfo.UseVisualStyleBackColor = true
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.txtZip)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.txtRequestFrom)
        Me.groupBox2.Location = New System.Drawing.Point(249, 2)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(228, 102)
        Me.groupBox2.TabIndex = 19
        Me.groupBox2.TabStop = false
        Me.groupBox2.Text = "request weather info"
        '
        'label4
        '
        Me.label4.AutoSize = true
        Me.label4.Location = New System.Drawing.Point(6, 20)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(33, 13)
        Me.label4.TabIndex = 12
        Me.label4.Text = "From:"
        '
        'txtRequestFrom
        '
        Me.txtRequestFrom.Location = New System.Drawing.Point(45, 17)
        Me.txtRequestFrom.Name = "txtRequestFrom"
        Me.txtRequestFrom.Size = New System.Drawing.Size(176, 20)
        Me.txtRequestFrom.TabIndex = 11
        '
        'statusStrip1
        '
        Me.statusStrip1.Location = New System.Drawing.Point(0, 385)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(489, 22)
        Me.statusStrip1.TabIndex = 17
        Me.statusStrip1.Text = "statusStrip1"
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.listEvents)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(459, 217)
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
        Me.listEvents.Size = New System.Drawing.Size(453, 211)
        Me.listEvents.TabIndex = 0
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtUsername.Location = New System.Drawing.Point(70, 13)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(152, 20)
        Me.txtUsername.TabIndex = 1
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(10, 139)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(467, 243)
        Me.tabControl1.TabIndex = 15
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.rtfDebug)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(459, 217)
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
        Me.rtfDebug.Size = New System.Drawing.Size(453, 211)
        Me.rtfDebug.TabIndex = 0
        Me.rtfDebug.Text = ""
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.Location = New System.Drawing.Point(95, 110)
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.cmdDisconnect.TabIndex = 14
        Me.cmdDisconnect.Text = "DisConnect"
        Me.cmdDisconnect.UseVisualStyleBackColor = true
        '
        'label2
        '
        Me.label2.AutoSize = true
        Me.label2.Location = New System.Drawing.Point(6, 46)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(56, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Password:"
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.txtServer)
        Me.groupBox1.Controls.Add(Me.txtPassword)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.txtUsername)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(14, 2)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(229, 102)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = false
        Me.groupBox1.Text = "Credentials"
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Location = New System.Drawing.Point(6, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Username:"
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
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 407)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.cmdRequestWeatherInfo)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.cmdDisconnect)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "FrmMain"
        Me.Text = "Form1"
        Me.groupBox2.ResumeLayout(false)
        Me.groupBox2.PerformLayout
        Me.tabPage1.ResumeLayout(false)
        Me.tabControl1.ResumeLayout(false)
        Me.tabPage2.ResumeLayout(false)
        Me.groupBox1.ResumeLayout(false)
        Me.groupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents cmdConnect As System.Windows.Forms.Button
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtZip As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtServer As System.Windows.Forms.TextBox
    Private WithEvents cmdRequestWeatherInfo As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtRequestFrom As System.Windows.Forms.TextBox
    Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents listEvents As System.Windows.Forms.ListBox
    Private WithEvents txtUsername As System.Windows.Forms.TextBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents rtfDebug As System.Windows.Forms.RichTextBox
    Private WithEvents cmdDisconnect As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents xmppClient As Matrix.Xmpp.Client.XmppClient

End Class
