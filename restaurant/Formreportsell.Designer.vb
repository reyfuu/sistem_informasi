<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formreportsell
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
        Me.Reportsellviewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Reportsellviewer
        '
        Me.Reportsellviewer.ActiveViewIndex = -1
        Me.Reportsellviewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Reportsellviewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.Reportsellviewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Reportsellviewer.Location = New System.Drawing.Point(0, 0)
        Me.Reportsellviewer.Name = "Reportsellviewer"
        Me.Reportsellviewer.Size = New System.Drawing.Size(701, 348)
        Me.Reportsellviewer.TabIndex = 0
        '
        'Formreportsell
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 348)
        Me.Controls.Add(Me.Reportsellviewer)
        Me.Name = "Formreportsell"
        Me.Text = "Formreportsell"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Reportsellviewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
