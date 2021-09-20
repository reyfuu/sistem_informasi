Imports System.Data.OleDb

Public Class login
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        hakakses()
        Dim uname As String = ""
        Dim pword As String
        Dim username As String = ""
        Dim pass As String
        If tbname.Text = "" Or tbpass.Text = "" Then
            MessageBox.Show("Tolong isi username dan password", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbname.Focus()
        Else
            connect()
            uname = tbname.Text
            pword = tbpass.Text
            Dim querry As String = "Select password From Tuser where username= '" & uname & "';"
            Dim cmd As New OleDbCommand(querry, Conn)
            Try
                pass = cmd.ExecuteScalar().ToString
                If (pword = pass) Then
                    MessageBox.Show("Login Berhasil", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    formrest.Show()
                    If formrest.Visible Then
                        Me.Hide()
                    End If
                    disconnect()
                Else
                    MessageBox.Show("login gagal", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tbname.Clear()
                    tbpass.Clear()
                    disconnect()
                    tbname.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show("Username tidak ditemukan", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                disconnect()
                tbname.Clear()
                tbpass.Clear()
                tbname.Focus()
            End Try
        End If
    End Sub
    Sub hakakses()
        Try
            Dim master = formrest.Master
            Dim transaksi = formrest.Transaksi
            Dim report = formrest.Tabreport

            Dim status As String
            connect()
            Dim str As String = "select [position] from [Tuser] where [username]='" & tbname.Text & "'"
            CMD = New OleDbCommand(str, Conn)
            DR = CMD.ExecuteReader
            DR.Read()
            status = DR.Item("position")

            If status = "Director" Then
                formrest.tabmenu.TabPages.Remove(master)
                formrest.tabmenu.TabPages.Remove(transaksi)
            ElseIf status = "admin" Then
                formrest.tabmenu.TabPages.Remove(report)
                formrest.tabmenu.TabPages.Remove(transaksi)

            ElseIf status = "cashier" Then
                formrest.tabmenu.TabPages.Remove(master)
                formrest.tabmenu.TabPages.Remove(report)

            End If
            disconnect()
        Catch ex As Exception
            disconnect()

        End Try




    End Sub

End Class