Public Class Strucksell
    Private Sub Strucksell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim paramFields As New CrystalDecisions.Shared.ParameterFields()
        Dim paramField As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim paramField3 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal3 As New CrystalDecisions.Shared.ParameterDiscreteValue()

        Dim paramField4 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal4 As New CrystalDecisions.Shared.ParameterDiscreteValue()


        Dim paramField5 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteVal5 As New CrystalDecisions.Shared.ParameterDiscreteValue()

        paramField.ParameterFieldName = "totalsell"
        Dim str As String = formrest.lbltotalsell2.Text.ToString
        discreteVal.Value = str
        paramField.CurrentValues.Add(discreteVal)

        paramField3.ParameterFieldName = "pay"
        Dim str3 As String = formrest.tbpaysell.Text.ToString
        discreteVal3.Value = str3
        paramField3.CurrentValues.Add(discreteVal3)

        paramField4.ParameterFieldName = "change"
        Dim str4 As String = formrest.lblchange2.Text.ToString
        discreteVal4.Value = str4
        paramField4.CurrentValues.Add(discreteVal4)



        paramFields.Add(paramField)
        paramFields.Add(paramField3)
        paramFields.Add(paramField4)

        Reportstructview.ParameterFieldInfo = paramFields
    End Sub
End Class