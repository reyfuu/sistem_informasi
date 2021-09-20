Imports System.Data.OleDb

Module connection
    Public Conn As OleDbConnection
    Public DA As OleDbDataAdapter
    Public DS As DataSet
    Public CMD As OleDbCommand
    Public DR As OleDbDataReader
    Public DT As New DataTable
    Public datarw As DataRow

    Public Sub connect()
        Try
            Conn = New OleDbConnection("provider= Microsoft.JET.OLEDB.4.0;Data source = dbrestaurant.mdb")
            Conn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub disconnect()
        Conn.Close()
    End Sub
End Module
