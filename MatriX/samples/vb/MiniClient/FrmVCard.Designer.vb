

Partial Class FrmVCard
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
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNickname = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblNickname = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdPublish = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(84, 16)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(199, 20)
        Me.txtName.TabIndex = 0
        '
        'txtNickname
        '
        Me.txtNickname.Location = New System.Drawing.Point(84, 53)
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(199, 20)
        Me.txtNickname.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = true
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblName.Location = New System.Drawing.Point(12, 23)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(39, 13)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "Name"
        '
        'lblNickname
        '
        Me.lblNickname.AutoSize = true
        Me.lblNickname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblNickname.Location = New System.Drawing.Point(12, 60)
        Me.lblNickname.Name = "lblNickname"
        Me.lblNickname.Size = New System.Drawing.Size(63, 13)
        Me.lblNickname.TabIndex = 3
        Me.lblNickname.Text = "Nickname"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(84, 90)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(199, 20)
        Me.txtEmail.TabIndex = 4
        '
        'label1
        '
        Me.label1.AutoSize = true
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label1.Location = New System.Drawing.Point(12, 97)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(37, 13)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Email"
        '
        'cmdPublish
        '
        Me.cmdPublish.Enabled = false
        Me.cmdPublish.Location = New System.Drawing.Point(97, 132)
        Me.cmdPublish.Name = "cmdPublish"
        Me.cmdPublish.Size = New System.Drawing.Size(134, 36)
        Me.cmdPublish.TabIndex = 6
        Me.cmdPublish.Text = "Publish"
        Me.cmdPublish.UseVisualStyleBackColor = true
        '
        'FrmVCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(312, 180)
        Me.Controls.Add(Me.cmdPublish)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.lblNickname)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtNickname)
        Me.Controls.Add(Me.txtName)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmVCard"
        Me.Text = "FrmVCard"
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub

#End Region

    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents txtNickname As System.Windows.Forms.TextBox
    Private WithEvents lblName As System.Windows.Forms.Label
    Private WithEvents lblNickname As System.Windows.Forms.Label
    Private WithEvents txtEmail As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmdPublish As System.Windows.Forms.Button
End Class