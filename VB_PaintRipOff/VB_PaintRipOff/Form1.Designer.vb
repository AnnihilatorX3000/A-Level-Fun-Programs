<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.pboxPaint = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnColour = New System.Windows.Forms.Button()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.clrDialog = New System.Windows.Forms.ColorDialog()
        CType(Me.pboxPaint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pboxPaint
        '
        Me.pboxPaint.BackColor = System.Drawing.Color.White
        Me.pboxPaint.Location = New System.Drawing.Point(12, 12)
        Me.pboxPaint.Name = "pboxPaint"
        Me.pboxPaint.Size = New System.Drawing.Size(779, 495)
        Me.pboxPaint.TabIndex = 0
        Me.pboxPaint.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(664, 513)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(127, 36)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(531, 513)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(127, 36)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnColour
        '
        Me.btnColour.Location = New System.Drawing.Point(161, 513)
        Me.btnColour.Name = "btnColour"
        Me.btnColour.Size = New System.Drawing.Size(127, 36)
        Me.btnColour.TabIndex = 3
        Me.btnColour.Text = "Colour"
        Me.btnColour.UseVisualStyleBackColor = True
        '
        'cmbSize
        '
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Items.AddRange(New Object() {"2", "4", "6", "8", "10"})
        Me.cmbSize.Location = New System.Drawing.Point(12, 522)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(143, 21)
        Me.cmbSize.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 566)
        Me.Controls.Add(Me.cmbSize)
        Me.Controls.Add(Me.btnColour)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pboxPaint)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pboxPaint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pboxPaint As PictureBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnColour As Button
    Friend WithEvents cmbSize As ComboBox
    Friend WithEvents clrDialog As ColorDialog
End Class
