

Partial Class FrmSendFile
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
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.cmdChooseFile = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.cmdAbort = New System.Windows.Forms.Button()
        Me.lblDescriptionSize = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = true
        Me.lblFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblFileName.Location = New System.Drawing.Point(9, 20)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(311, 13)
        Me.lblFileName.TabIndex = 2
        Me.lblFileName.Text = "press the ""choose File"" button to select a file to send"
        '
        'cmdChooseFile
        '
        Me.cmdChooseFile.Location = New System.Drawing.Point(13, 145)
        Me.cmdChooseFile.Name = "cmdChooseFile"
        Me.cmdChooseFile.Size = New System.Drawing.Size(75, 23)
        Me.cmdChooseFile.TabIndex = 3
        Me.cmdChooseFile.Text = "choose file"
        Me.cmdChooseFile.UseVisualStyleBackColor = true
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(91, 72)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(304, 20)
        Me.txtDescription.TabIndex = 4
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = true
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDescription.Location = New System.Drawing.Point(10, 75)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(75, 13)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Description:"
        '
        'cmdAbort
        '
        Me.cmdAbort.Enabled = false
        Me.cmdAbort.Location = New System.Drawing.Point(239, 145)
        Me.cmdAbort.Name = "cmdAbort"
        Me.cmdAbort.Size = New System.Drawing.Size(75, 23)
        Me.cmdAbort.TabIndex = 6
        Me.cmdAbort.Text = "Abort"
        Me.cmdAbort.UseVisualStyleBackColor = true
        '
        'lblDescriptionSize
        '
        Me.lblDescriptionSize.AutoSize = true
        Me.lblDescriptionSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDescriptionSize.Location = New System.Drawing.Point(10, 48)
        Me.lblDescriptionSize.Name = "lblDescriptionSize"
        Me.lblDescriptionSize.Size = New System.Drawing.Size(35, 13)
        Me.lblDescriptionSize.TabIndex = 7
        Me.lblDescriptionSize.Text = "Size:"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = true
        Me.lblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblSize.Location = New System.Drawing.Point(91, 48)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(41, 13)
        Me.lblSize.TabIndex = 8
        Me.lblSize.Text = "0 bytes"
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(12, 107)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(383, 23)
        Me.progressBar.TabIndex = 9
        '
        'cmdSend
        '
        Me.cmdSend.Enabled = false
        Me.cmdSend.Location = New System.Drawing.Point(320, 145)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(75, 23)
        Me.cmdSend.TabIndex = 10
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = true
        '
        'FrmSendFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 188)
        Me.Controls.Add(Me.cmdSend)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblDescriptionSize)
        Me.Controls.Add(Me.cmdAbort)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.cmdChooseFile)
        Me.Controls.Add(Me.lblFileName)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmSendFile"
        Me.Text = "FrmSendFile"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

#End Region


    
    Private WithEvents lblFileName As System.Windows.Forms.Label
    Private WithEvents cmdChooseFile As System.Windows.Forms.Button
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents cmdAbort As System.Windows.Forms.Button
    Private WithEvents lblDescriptionSize As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents progressBar As System.Windows.Forms.ProgressBar
    Private WithEvents cmdSend As System.Windows.Forms.Button
End Class