<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Strucksell
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
        Me.Reportstructview = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Reportstructview
        '
        Me.Reportstructview.ActiveViewIndex = -1
        Me.Reportstructview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Reportstructview.Cursor = System.Windows.Forms.Cursors.Default
        Me.Reportstructview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Reportstructview.Location = New System.Drawing.Point(0, 0)
        Me.Reportstructview.Name = "Reportstructview"
        Me.Reportstructview.Size = New System.Drawing.Size(754, 426)
        Me.Reportstructview.TabIndex = 0
        '
        'Strucksell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 426)
        Me.Controls.Add(Me.Reportstructview)
        Me.Name = "Strucksell"
        Me.Text = "Strucksell"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Reportstructview As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
