Public Class formReportbuy
    Private Sub Reportbuy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim paramFields As New CrystalDecisions.Shared.ParameterFields()
        Dim paramField As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()

        paramField.ParameterFieldName = "totalbuy"
        Dim str As String = formrest.lbltotalreportbuy2.Text.ToString
        discreteVal.Value = str
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        Reportbuyview.ParameterFieldInfo = paramFields
    End Sub
End Class