<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportbuy
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
        Me.Reportbuyview = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Reportbuyview
        '
        Me.Reportbuyview.ActiveViewIndex = -1
        Me.Reportbuyview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Reportbuyview.Cursor = System.Windows.Forms.Cursors.Default
        Me.Reportbuyview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Reportbuyview.Location = New System.Drawing.Point(0, 0)
        Me.Reportbuyview.Name = "Reportbuyview"
        Me.Reportbuyview.Size = New System.Drawing.Size(694, 372)
        Me.Reportbuyview.TabIndex = 0
        '
        'Reportbuy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 372)
        Me.Controls.Add(Me.Reportbuyview)
        Me.Name = "Reportbuy"
        Me.Text = "Reportbuy"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Reportbuyview As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
