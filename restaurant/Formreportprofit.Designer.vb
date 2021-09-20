<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formreportprofit
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
        Me.reportprofitview = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'reportprofitview
        '
        Me.reportprofitview.ActiveViewIndex = -1
        Me.reportprofitview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.reportprofitview.Cursor = System.Windows.Forms.Cursors.Default
        Me.reportprofitview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reportprofitview.Location = New System.Drawing.Point(0, 0)
        Me.reportprofitview.Name = "reportprofitview"
        Me.reportprofitview.Size = New System.Drawing.Size(284, 261)
        Me.reportprofitview.TabIndex = 0
        '
        'Formreportprofit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.reportprofitview)
        Me.Name = "Formreportprofit"
        Me.Text = "Formreportprofit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents reportprofitview As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
