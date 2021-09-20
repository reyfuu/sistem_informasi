Public Class Formreportprofit
    Private Sub Formreportprofit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim paramFields As New CrystalDecisions.Shared.ParameterFields()
        Dim paramField As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim paramField2 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim paramField3 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal3 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim paramField4 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal4 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        Dim paramField5 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal5 As New CrystalDecisions.Shared.ParameterDiscreteValue()



        paramField.ParameterFieldName = "totalbuy"
        Dim str As String = formrest.lblreporttotalbuy2.Text.ToString
        discreteVal.Value = str
        paramField.CurrentValues.Add(discreteVal)
        paramFields.Add(paramField)

        paramField2.ParameterFieldName = "totalsell"
        Dim str2 As String = formrest.lblreporttotalsell2.Text.ToString
        discreteVal2.Value = str2
        paramField2.CurrentValues.Add(discreteVal2)
        paramFields.Add(paramField2)

        paramField3.ParameterFieldName = "month"
        Dim str3 As String = formrest.cmbfilterprofit.Text.ToString
        discreteVal3.Value = str3
        paramField3.CurrentValues.Add(discreteVal3)
        paramFields.Add(paramField3)

        paramField4.ParameterFieldName = "profit"
        Dim str4 As String = formrest.lblprofit2.Text.ToString
        discreteVal4.Value = str4
        paramField4.CurrentValues.Add(discreteVal4)
        paramFields.Add(paramField4)

        paramField5.ParameterFieldName = "loss"
        Dim str5 As String = formrest.lbllost2.Text.ToString
        discreteVal5.Value = str5
        paramField5.CurrentValues.Add(discreteVal5)
        paramFields.Add(paramField5)

        reportprofitview.ParameterFieldInfo = paramFields
    End Sub
End Class