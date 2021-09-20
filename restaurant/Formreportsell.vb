Public Class Formreportsell
    Private Sub Formreportsell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim paramFields As New CrystalDecisions.Shared.ParameterFields()
        Dim paramField As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()

        paramField.ParameterFieldName = "totalsell"
        Dim str As String = formrest.lbltotalreportsell2.Text.ToString
        discreteVal.Value = str
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reportsellviewer.ParameterFieldInfo = paramFields
    End Sub
End Class