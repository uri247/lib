

Partial Class FrmPubSub
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
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmdInstantNode = New System.Windows.Forms.Button()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.txtNode = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cboService = New System.Windows.Forms.ComboBox()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.label6 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.treeNodes = New System.Windows.Forms.TreeView()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.lblNode = New System.Windows.Forms.Label()
        Me.lblJid = New System.Windows.Forms.Label()
        Me.contextMenuStripNodes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.deleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.subscribeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.publishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.splitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.splitContainer1.Panel1.SuspendLayout
        Me.splitContainer1.Panel2.SuspendLayout
        Me.splitContainer1.SuspendLayout
        Me.tableLayoutPanel1.SuspendLayout
        Me.contextMenuStripNodes.SuspendLayout
        Me.SuspendLayout
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.cmdInstantNode)
        Me.splitContainer1.Panel1.Controls.Add(Me.cmdCreate)
        Me.splitContainer1.Panel1.Controls.Add(Me.txtNode)
        Me.splitContainer1.Panel1.Controls.Add(Me.label2)
        Me.splitContainer1.Panel1.Controls.Add(Me.label1)
        Me.splitContainer1.Panel1.Controls.Add(Me.cboService)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.tableLayoutPanel1)
        Me.splitContainer1.Size = New System.Drawing.Size(717, 274)
        Me.splitContainer1.SplitterDistance = 360
        Me.splitContainer1.TabIndex = 6
        '
        'cmdInstantNode
        '
        Me.cmdInstantNode.Location = New System.Drawing.Point(118, 95)
        Me.cmdInstantNode.Name = "cmdInstantNode"
        Me.cmdInstantNode.Size = New System.Drawing.Size(130, 24)
        Me.cmdInstantNode.TabIndex = 10
        Me.cmdInstantNode.Text = "create instant node"
        Me.cmdInstantNode.UseVisualStyleBackColor = true
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(118, 65)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(130, 24)
        Me.cmdCreate.TabIndex = 9
        Me.cmdCreate.Text = "create node"
        Me.cmdCreate.UseVisualStyleBackColor = true
        '
        'txtNode
        '
        Me.txtNode.Location = New System.Drawing.Point(118, 39)
        Me.txtNode.Name = "txtNode"
        Me.txtNode.Size = New System.Drawing.Size(227, 20)
        Me.txtNode.TabIndex = 8
        '
        'label2
        '
        Me.label2.AutoSize = true
        Me.label2.Location = New System.Drawing.Point(10, 47)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(36, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Node:"
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Location = New System.Drawing.Point(10, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "PubSub Services:"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cboService
        '
        Me.cboService.FormattingEnabled = true
        Me.cboService.Location = New System.Drawing.Point(118, 3)
        Me.cboService.Name = "cboService"
        Me.cboService.Size = New System.Drawing.Size(228, 21)
        Me.cboService.TabIndex = 5
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tableLayoutPanel1.Controls.Add(Me.label6, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.lblName, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.treeNodes, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label3, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.label4, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.lblNode, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.lblJid, 1, 2)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 4
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(353, 274)
        Me.tableLayoutPanel1.TabIndex = 7
        '
        'label6
        '
        Me.label6.AutoSize = true
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label6.Location = New System.Drawing.Point(3, 254)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(43, 13)
        Me.label6.TabIndex = 13
        Me.label6.Text = "Name:"
        '
        'lblName
        '
        Me.lblName.AutoSize = true
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblName.Location = New System.Drawing.Point(83, 254)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 13)
        Me.lblName.TabIndex = 12
        Me.lblName.Text = "lblName"
        '
        'treeNodes
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.treeNodes, 2)
        Me.treeNodes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeNodes.Location = New System.Drawing.Point(3, 3)
        Me.treeNodes.Name = "treeNodes"
        Me.treeNodes.Size = New System.Drawing.Size(347, 208)
        Me.treeNodes.TabIndex = 7
        '
        'label3
        '
        Me.label3.AutoSize = true
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label3.Location = New System.Drawing.Point(3, 214)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 13)
        Me.label3.TabIndex = 8
        Me.label3.Text = "Node:"
        '
        'label4
        '
        Me.label4.AutoSize = true
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label4.Location = New System.Drawing.Point(3, 234)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(27, 13)
        Me.label4.TabIndex = 9
        Me.label4.Text = "Jid:"
        '
        'lblNode
        '
        Me.lblNode.AutoSize = true
        Me.lblNode.Location = New System.Drawing.Point(83, 214)
        Me.lblNode.Name = "lblNode"
        Me.lblNode.Size = New System.Drawing.Size(43, 13)
        Me.lblNode.TabIndex = 10
        Me.lblNode.Text = "lblNode"
        '
        'lblJid
        '
        Me.lblJid.AutoSize = true
        Me.lblJid.Location = New System.Drawing.Point(83, 234)
        Me.lblJid.Name = "lblJid"
        Me.lblJid.Size = New System.Drawing.Size(30, 13)
        Me.lblJid.TabIndex = 11
        Me.lblJid.Text = "lblJid"
        '
        'contextMenuStripNodes
        '
        Me.contextMenuStripNodes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.deleteToolStripMenuItem, Me.subscribeToolStripMenuItem, Me.publishToolStripMenuItem})
        Me.contextMenuStripNodes.Name = "contextMenuStripNodes"
        Me.contextMenuStripNodes.Size = New System.Drawing.Size(153, 92)
        '
        'deleteToolStripMenuItem
        '
        Me.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem"
        Me.deleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.deleteToolStripMenuItem.Text = "Delete"
        '
        'subscribeToolStripMenuItem
        '
        Me.subscribeToolStripMenuItem.Name = "subscribeToolStripMenuItem"
        Me.subscribeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.subscribeToolStripMenuItem.Text = "Subscribe"
        '
        'publishToolStripMenuItem
        '
        Me.publishToolStripMenuItem.Name = "publishToolStripMenuItem"
        Me.publishToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.publishToolStripMenuItem.Text = "Publish"
        '
        'FrmPubSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 274)
        Me.Controls.Add(Me.splitContainer1)
        Me.Name = "FrmPubSub"
        Me.Text = "create PubSub node"
        Me.splitContainer1.Panel1.ResumeLayout(false)
        Me.splitContainer1.Panel1.PerformLayout
        Me.splitContainer1.Panel2.ResumeLayout(false)
        CType(Me.splitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.splitContainer1.ResumeLayout(false)
        Me.tableLayoutPanel1.ResumeLayout(false)
        Me.tableLayoutPanel1.PerformLayout
        Me.contextMenuStripNodes.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

#End Region

    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents cmdCreate As System.Windows.Forms.Button
    Private WithEvents txtNode As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cboService As System.Windows.Forms.ComboBox
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents treeNodes As System.Windows.Forms.TreeView
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents lblNode As System.Windows.Forms.Label
    Private WithEvents lblJid As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents contextMenuStripNodes As System.Windows.Forms.ContextMenuStrip
    Private WithEvents deleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmdInstantNode As System.Windows.Forms.Button
    Private WithEvents subscribeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents publishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class