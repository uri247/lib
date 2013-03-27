

Partial Class FrmReceiveFile
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
        Me.label2 = New System.Windows.Forms.Label()
        Me.cmdAbort = New System.Windows.Forms.Button()
        Me.lblDescriptionSize = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.cmdAccept = New System.Windows.Forms.Button()
        Me.cmdRefuse = New System.Windows.Forms.Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.cmdSaveAs = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = true
        Me.lblFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblFileName.Location = New System.Drawing.Point(9, 20)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(57, 13)
        Me.lblFileName.TabIndex = 2
        Me.lblFileName.Text = "Filename"
        '
        'label2
        '
        Me.label2.AutoSize = true
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label2.Location = New System.Drawing.Point(10, 75)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(75, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Description:"
        '
        'cmdAbort
        '
        Me.cmdAbort.Enabled = false
        Me.cmdAbort.Location = New System.Drawing.Point(321, 153)
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
        'cmdAccept
        '
        Me.cmdAccept.Location = New System.Drawing.Point(159, 153)
        Me.cmdAccept.Name = "cmdAccept"
        Me.cmdAccept.Size = New System.Drawing.Size(75, 23)
        Me.cmdAccept.TabIndex = 9
        Me.cmdAccept.Text = "Accept"
        Me.cmdAccept.UseVisualStyleBackColor = true
        '
        'cmdRefuse
        '
        Me.cmdRefuse.Location = New System.Drawing.Point(240, 153)
        Me.cmdRefuse.Name = "cmdRefuse"
        Me.cmdRefuse.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefuse.TabIndex = 10
        Me.cmdRefuse.Text = "Refuse"
        Me.cmdRefuse.UseVisualStyleBackColor = true
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = true
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDescription.Location = New System.Drawing.Point(91, 75)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(41, 13)
        Me.lblDescription.TabIndex = 11
        Me.lblDescription.Text = "0 bytes"
        '
        'cmdSaveAs
        '
        Me.cmdSaveAs.Location = New System.Drawing.Point(321, 20)
        Me.cmdSaveAs.Name = "cmdSaveAs"
        Me.cmdSaveAs.Size = New System.Drawing.Size(75, 23)
        Me.cmdSaveAs.TabIndex = 12
        Me.cmdSaveAs.Text = "save as ..."
        Me.cmdSaveAs.UseVisualStyleBackColor = true
        '
        'FrmReceiveFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 188)
        Me.Controls.Add(Me.cmdSaveAs)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.cmdRefuse)
        Me.Controls.Add(Me.cmdAccept)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblDescriptionSize)
        Me.Controls.Add(Me.cmdAbort)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.lblFileName)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmReceiveFile"
        Me.Text = "FrmReceiveFile"
        Me.ResumeLayout(false)
        Me.PerformLayout

    End Sub

#End Region

    Private WithEvents progressBar As System.Windows.Forms.ProgressBar
    Private WithEvents lblFileName As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cmdAbort As System.Windows.Forms.Button
    Private WithEvents lblDescriptionSize As System.Windows.Forms.Label
    Private WithEvents lblSize As System.Windows.Forms.Label
    Private WithEvents cmdAccept As System.Windows.Forms.Button
    Private WithEvents cmdRefuse As System.Windows.Forms.Button
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents cmdSaveAs As System.Windows.Forms.Button
End Class