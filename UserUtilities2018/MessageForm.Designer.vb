<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageForm
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
        Me.UserMessageBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'UserMessageBox
        '
        Me.UserMessageBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserMessageBox.Location = New System.Drawing.Point(0, 0)
        Me.UserMessageBox.Name = "UserMessageBox"
        Me.UserMessageBox.Size = New System.Drawing.Size(667, 73)
        Me.UserMessageBox.TabIndex = 0
        Me.UserMessageBox.Text = ""
        '
        'MessageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 73)
        Me.Controls.Add(Me.UserMessageBox)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MessageForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Message"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserMessageBox As RichTextBox
End Class
