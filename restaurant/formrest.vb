Imports System.Data.OleDb
Imports System.ComponentModel


Public Class formrest
    Private Sub Formcust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disable()
        showw()
        disableemp()
        food_autocomplete()
        id_sell()
        price_food()
        drink_autocomplete()
        disableuser()
        emptyuser()
        pos_autocomplete()
        posuser_autocomplete()
        date2()
        id_buy()
    End Sub
    Private Sub btncust_Click(sender As Object, e As EventArgs) Handles btncust.Click
        gbcust.Visible = True
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False

        empty()
    End Sub

    Private Sub btnemp_Click(sender As Object, e As EventArgs) Handles btnemp.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = True
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False

        showemp()
        emptyemp()
    End Sub

    Private Sub btnmenu_Click(sender As Object, e As EventArgs) Handles btnmenu.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = True
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False

        menu_autocomplete()
        disablemenu()
        showmenu()
        emptymenu()
    End Sub

    Private Sub btnuser_Click(sender As Object, e As EventArgs) Handles btnuser.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = True
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False
        emptyuser()
        showuser()

    End Sub



    Private Sub btnsell_Click(sender As Object, e As EventArgs) Handles btnsell.Click
        gbcust.Visible = False
        gbsell.Visible = True
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False
        clean_sell()

    End Sub

    Private Sub btnpay_Click(sender As Object, e As EventArgs) Handles btnpay.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        gbpay.Visible = True
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False
        showpay()
        name_autocomplete()
    End Sub
#Region "Master customer"
    Public strDateTime As String = String.Empty
    Sub empty()
        tbname.Text = ""
        lblid2.Text = ""
        tbnohp.Text = ""
        cmbgen.Text = ""
        tbaddress.Text = ""
        tbdate.Clear()
        lblid2.Focus()
    End Sub

    Sub disable()
        tbname.Enabled = False
        tbnohp.Enabled = False
        tbdate.Enabled = False
        tbaddress.Enabled = False
        cmbgen.Enabled = False
    End Sub

    Sub enable()
        tbname.Enabled = True
        tbnohp.Enabled = True
        tbdate.Enabled = True
        tbaddress.Enabled = True
        cmbgen.Enabled = True
    End Sub

    Sub showw()
        connect()
        DA = New OleDbDataAdapter("select * from Tcust", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgv.DataSource = DS.Tables(0)
        dgv.ReadOnly = True

    End Sub


    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        enable()
        empty()
        id_cust()

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        disable()
        empty()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If tbname.Text = "" Or tbnohp.Text = "" Or tbaddress.Text = "" Or cmbgen.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()
            Try
                Dim simpan As String
                simpan = "insert into Tcust values ('" & lblid2.Text & "','" & tbname.Text & "','" & tbdate.Text & "','" & cmbgen.Text & "','" & tbnohp.Text & "','" & tbaddress.Text & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("input data sukses")

            Catch ex As Exception
                MsgBox("input data gagal ")
            End Try

            Call disable()
            Call empty()
            Call showw()
            Call disconnect()
        End If
    End Sub
    Sub id_cust()
        connect()
        CMD = New OleDbCommand("select * from Tcust where ID_cust in (select max(ID_cust) from Tcust)", Conn)
        Dim urutanID As String
        Dim hitung As Long
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            urutanID = "0001"
        Else
            hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 3) + 1
            urutanID = Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        lblid2.Text = "CS" + urutanID
        Exit Sub

    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If tbname.Text = "" Or tbnohp.Text = "" Or tbaddress.Text = "" Or tbdate.Text = "" Or cmbgen.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()

            CMD = New OleDbCommand("UPDATE Tcust set [name_cust]='" & tbname.Text & "',[HP]='" & tbnohp.Text & "',[date_cust]='" & tbdate.Text & "',[address]='" & tbaddress.Text & "',[gender]='" & cmbgen.Text & "' where ID_cust='" & lblid2.Text & "'", Conn)
            CMD.ExecuteNonQuery()
            MsgBox("update data sukses")

            Call disable()
            Call empty()
            Call showw()
            Call disconnect()

        End If
    End Sub

    Private Sub dgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseClick
        lblid2.Text = dgv.Rows(e.RowIndex).Cells(0).Value
        tbname.Text = dgv.Rows(e.RowIndex).Cells(1).Value
        tbdate.Text = dgv.Rows(e.RowIndex).Cells(2).Value
        cmbgen.Text = dgv.Rows(e.RowIndex).Cells(3).Value
        tbnohp.Text = dgv.Rows(e.RowIndex).Cells(4).Value
        tbaddress.Text = dgv.Rows(e.RowIndex).Cells(5).Value

        Call enable()

    End Sub

    Private Sub btndel_Click(sender As Object, e As EventArgs) Handles btndel.Click
        If lblid2.Text = "" Then
            MsgBox("tidak ada data yang dihapus")
            Exit Sub
        Else
            If MessageBox.Show("Yakin mau hapus ", "konformasi", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                connect()
                CMD = New OleDbCommand("delete from Tcust  where ID_cust= '" & lblid2.Text & "'", Conn)
                CMD.ExecuteNonQuery()
                MsgBox("delete data berhasil")
                Call disable()
                Call empty()
                Call showw()
                Call disconnect()
            Else
                Call disable()
                Call empty()
            End If

        End If
    End Sub



    Private Sub tbnohp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbnohp.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub
#End Region

#Region "Master Jual"
    Sub id_sell()
        connect()
        CMD = New OleDbCommand("select * from Tsell where ID_sell in (select max(ID_sell) from Tsell)", Conn)
        Dim urutanID As String
        Dim hitung As Long
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            urutanID = "0001"
        Else
            hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 3) + 1
            urutanID = Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        idsell2.Text = "SELL" + urutanID
        Exit Sub

    End Sub
    Sub food_autocomplete()
        Try
            CMD = New OleDbCommand("select * FROM Tmenu where type='food'", Conn)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbfood.Items.Add(DR.Item(1))
            Loop
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub
    Sub drink_autocomplete()
        Try
            Conn.Open()
            CMD = New OleDbCommand("select * FROM Tmenu where type ='drink'", Conn)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbdrink.Items.Add(DR.Item(1))
            Loop
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub


    Sub price_food()
        connect()
        Dim str As String

        str = "select price from Tmenu where name_menu = '" & cmbfood.Text & "'"
        CMD = New OleDbCommand(str, Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            lblpricefood2.Text = DR.Item("price")
        Else
        End If
        disconnect()
    End Sub
    Sub price_drink()
        connect()
        Dim str As String

        str = "select price from Tmenu where name_menu = '" & cmbdrink.Text & "'"
        CMD = New OleDbCommand(str, Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            lblpricedrink2.Text = DR.Item("price")
        Else
        End If
        disconnect()
    End Sub
    Sub clean_sell()
        cmbfood.Text = ""
        cmbdrink.Text = ""
        tbfood.Text = ""
        tbdrink.Text = ""
        lblpricefood2.Text = ""
        lblpricedrink2.Text = ""
        lbltotalsell3.Text = ""

    End Sub
    Sub date2()
        strDateTime = strDateTime & Format(Now, "MMMM, dd dddd  yyyy")
        lbldate2.Text = strDateTime
        lbldatebuy2.Text = strDateTime

    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles btnaddsell.Click
        If cmbfood.Text = "" Or tbfood.Text = "" Or cmbdrink.Text = "" Or tbdrink.Text = "" Then
            MessageBox.Show("Tolong masukkan data terlebih dahulu", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Dim row As Integer
            Try
                Dim hargabeli1 As Integer
                Dim hargabeli2 As Integer
                Dim total As Integer

                hargabeli2 = CInt(tbdrink.Text) * CInt(lblpricedrink2.Text)
                hargabeli1 = CInt(tbfood.Text) * CInt(lblpricefood2.Text)
                total = hargabeli1 + hargabeli2
                lbltotalsell3.Text = total
            Catch ex As Exception
                MessageBox.Show("Perhitungan gagal", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            'hitungbeli()
            dgvsell.Rows.Add()
            row = dgvsell.Rows.Count - 2
            dgvsell("idsell3", row).Value = idsell2.Text
            dgvsell("datebuy", row).Value = lbldate2.Text
            dgvsell("namefood", row).Value = cmbfood.Text
            dgvsell("pricefood", row).Value = lblpricefood2.Text
            dgvsell("qtyfood", row).Value = tbfood.Text
            dgvsell("namedrink", row).Value = cmbdrink.Text
            dgvsell("pricedrink", row).Value = lblpricedrink2.Text
            dgvsell("qtydrink", row).Value = tbdrink.Text
            dgvsell("Total", row).Value = lbltotalsell3.Text
            total_sell()

            dgvsell.Sort(dgvsell.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
            cmbfood.Text = ""
            cmbdrink.Text = ""
        End If
        MessageBox.Show("Data berhasil dimasukkan ke keranjang belanja", "PEMBELIAN ONDERDIL", MessageBoxButtons.OK, MessageBoxIcon.Information)

        clean_sell()
    End Sub

    Sub total_sell()
        Dim totalsemua As Integer
        totalsemua = 0
        For t As Integer = 0 To dgvsell.Rows.Count - 2 Step 1
            totalsemua = totalsemua + Val(dgvsell.Rows(t).Cells(8).Value)
        Next
        lbltotalsell2.Text = totalsemua
    End Sub

    Private Sub btntotal_Click(sender As Object, e As EventArgs)
        total_sell()
    End Sub
    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        dgvsell.Rows.Clear()
        clean_sell()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btndelsell.Click
        Try
            Dim index As Integer
            index = dgvsell.CurrentCell.RowIndex
            dgvsell.Rows.RemoveAt(index)
        Catch ex As Exception
            MessageBox.Show("Data pembelian gagal dihapus", "HAPUS ITEM ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub cmbfood_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbfood.SelectedIndexChanged
        price_food()
    End Sub

    Private Sub cmbdrink_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdrink.SelectedIndexChanged
        price_drink()
    End Sub
    Private Sub tbfood_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbfood.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub tbdrink_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbdrink.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub
    Private Sub tbpaysell_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbpaysell.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub
    Private Sub btnpaysell_Click(sender As Object, e As EventArgs) Handles btnpaysell.Click
        Dim change As Integer
        change = CInt(tbpaysell.Text) - CInt(lbltotalsell2.Text)
        lblchange2.Text = change
        tbpaysell.Enabled = False
    End Sub
    Private Sub btnekssell_Click(sender As Object, e As EventArgs) Handles btnekssell.Click
        If dgvsell.Rows(0).Cells(0).Value = "" Then
            MessageBox.Show("Silahkan lakukan proses penjualan ke pembeli", "Sell", MessageBoxButtons.OK, MessageBoxIcon.Information)
            disconnect()
            Exit Sub
        ElseIf lbltotalsell2.Text = "" Then
            MessageBox.Show("Silahkan lakukan perhitungan terlebih dahulu sebelum eksport ke database", "EKSPORT DATA", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Try
                For j As Integer = 0 To dgvsell.Rows.Count - 2 Step 1
                    Dim str As String = "insert into Tsell values('" & dgvsell.Rows(j).Cells(0).Value & "','" & dgvsell.Rows(j).Cells(1).Value & "','" & dgvsell.Rows(j).Cells(2).Value & "','" & dgvsell.Rows(j).Cells(5).Value & "','" & dgvsell.Rows(j).Cells(6).Value & "','" & dgvsell.Rows(j).Cells(3).Value & "','" & dgvsell.Rows(j).Cells(4).Value & "','" & dgvsell.Rows(j).Cells(7).Value & "','" & dgvsell.Rows(j).Cells(8).Value & "')"
                    connect()
                    CMD = New OleDbCommand(str, Conn)
                    CMD.ExecuteNonQuery()
                    disconnect()
                Next j
                MsgBox("Eksport ke database berhasil", MsgBoxStyle.OkOnly, "EKSPORT")
                id_sell()
            Catch ex As Exception
                disconnect()
                MsgBox(ex.Message)
                'MsgBox("Eksport ke database gagal", MsgBoxStyle.OkOnly, "PERINGATAN")
            End Try

            'masukkan ke database total_penjualan
            Try
                If dgvsell.Rows(0).Cells(0).Value = "" Or lbltotalsell2.Text = "" Then
                    Exit Sub
                Else
                    connect()
                    Dim str As String = "insert into Totalsell values('" & dgvsell.Rows(0).Cells(0).Value & "','" & dgvsell.Rows(0).Cells(1).Value & "', '" & lbltotalsell2.Text & "', '" & tbpaysell.Text & "', '" & lblchange2.Text & "')"
                    CMD = New OleDbCommand(str, Conn)
                    CMD.ExecuteNonQuery()
                    disconnect()
                End If
            Catch ex As Exception
                disconnect()
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        Dim dt As New DataTable
        With dt
            .Columns.Add("date_sell")
            .Columns.Add("food")
            .Columns.Add("price_drink")
            .Columns.Add("price_food")
            .Columns.Add("drink")
            .Columns.Add("qty_food")
            .Columns.Add("qty_drink")
            .Columns.Add("total")
        End With

        For Each dgr As DataGridViewRow In Me.dgvsell .Rows
            dt.Rows.Add(dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value, dgr.Cells(6).Value, dgr.Cells(7).Value, dgr.Cells(8).Value)
        Next

        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReportStruck
        reportDocument.SetDataSource(dt)

        Strucksell.Reportstructview.ReportSource = reportDocument
        Strucksell.ShowDialog()
        Strucksell.Dispose()
        tbpaysell.Text = ""
    End Sub

#End Region


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        gbpay.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = True
        posuser_autocomplete_edit()
        showuser()
    End Sub

    Private Sub mastercust_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Are you sure you want to exit?", "Restaurant form", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
        disconnect()
    End Sub

    Private Sub mastercust_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        login.Show()
    End Sub
#Region "Employee"
    Sub emptyemp()
        tbnameemp.Text = ""
        tbid.Text = ""
        tbnohpemp.Text = ""
        tbpay.Text = ""
        cmbgenemp.Text = ""
        tbaddressemp.Text = ""
        cmbpos.Text = ""
        tbid.Focus()
    End Sub
    Sub disableemp()
        tbid.Enabled = False
        tbnameemp.Enabled = False
        tbnohpemp.Enabled = False
        cmbpos.Enabled = False
        tbpay.Enabled = False
        tbaddressemp.Enabled = False
        cmbgenemp.Enabled = False
    End Sub

    Sub enableemp()
        tbid.Enabled = True
        tbnameemp.Enabled = True
        tbnohpemp.Enabled = True
        cmbpos.Enabled = True
        tbpay.Enabled = True
        tbaddressemp.Enabled = True
        cmbgenemp.Enabled = True
    End Sub

    Sub showemp()
        connect()
        DA = New OleDbDataAdapter("select * from Temployee", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvemp.DataSource = DS.Tables(0)
        dgvemp.ReadOnly = True

    End Sub
    Sub pos_autocomplete()
        cmbpos.Items.Clear()
        connect()
        CMD = New OleDbCommand("Select [position] from [Tsetting] ", Conn)
        CMD.ExecuteNonQuery()
        DA = New OleDbDataAdapter(CMD)
        DA.Fill(DT)
        For Each datarw In DT.Rows
            cmbpos.Items.Add(datarw("position").ToString)
        Next
        disconnect()
    End Sub
    Private Sub btnaddemp_Click(sender As Object, e As EventArgs) Handles btnaddemp.Click
        emptyemp()
        enableemp()

    End Sub

    Private Sub btneditemp_Click(sender As Object, e As EventArgs) Handles btneditemp.Click
        If tbid.Text = "" Or tbnameemp.Text = "" Or tbnohpemp.Text = "" Or tbaddressemp.Text = "" Or cmbpos.Text = "" Or tbpay.Text = "" Or cmbgenemp.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()

            CMD = New OleDbCommand("UPDATE Temployee set [name_emp]='" & tbnameemp.Text & "',[HP]='" & tbnohp.Text & "',[position]='" & cmbpos.Text & "',[pay]='" & tbpay.Text & "',[address]='" & tbaddressemp.Text & "',[gender]='" & cmbgenemp.Text & "' where ID_emp='" & tbid.Text & "'", Conn)
            CMD.ExecuteNonQuery()
            MsgBox("update data sukses")

            Call disableemp()
            Call emptyemp()
            Call showemp()
            Call disconnect()

        End If
    End Sub

    Private Sub btndelemp_Click(sender As Object, e As EventArgs) Handles btndelemp.Click
        If tbid.Text = "" Then
            MsgBox("tidak ada data yang dihapus")
            Exit Sub
        Else
            If MessageBox.Show("Yakin mau hapus ", "konformasi", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                connect()
                CMD = New OleDbCommand("delete from Temployee  where ID_emp= '" & tbid.Text & "'", Conn)
                CMD.ExecuteNonQuery()
                MsgBox("delete data berhasil")
                Call disableemp()
                Call emptyemp()
                Call showemp()
                Call disconnect()
            Else
                Call disableemp()
                Call emptyemp()
            End If

        End If
    End Sub

    Private Sub btncanemp_Click(sender As Object, e As EventArgs) Handles btncanemp.Click
        disableemp()
        emptyemp()
    End Sub

    Private Sub btnsaveemp_Click(sender As Object, e As EventArgs) Handles btnsaveemp.Click
        If tbid.Text = "" Or tbnameemp.Text = "" Or tbnohpemp.Text = "" Or tbaddressemp.Text = "" Or cmbpos.Text = "" Or tbpay.Text = "" Or cmbgenemp.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()
            CMD = New OleDbCommand("select * from Temployee where id_emp = '" & tbid.Text & "'", Conn)
            DR = CMD.ExecuteReader
            DR.Read()

            If Not DR.HasRows Then
                connect()
                Dim simpan As String
                simpan = "insert into Temployee values ('" & tbid.Text & "','" & tbnameemp.Text & "','" & tbnohpemp.Text & "','" & cmbpos.Text & "','" & tbpay.Text & "','" & tbaddressemp.Text & "','" & cmbgenemp.Text & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("input data ")

            Else
                MsgBox("kode sudah ada")

            End If
            disableemp()
            emptyemp()
            showemp()
            disconnect()
        End If
    End Sub
    Private Sub dgvemp_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvemp.CellMouseClick
        tbid.Text = dgvemp.Rows(e.RowIndex).Cells(0).Value
        tbnameemp.Text = dgvemp.Rows(e.RowIndex).Cells(1).Value
        tbnohpemp.Text = dgvemp.Rows(e.RowIndex).Cells(2).Value
        cmbpos.Text = dgvemp.Rows(e.RowIndex).Cells(3).Value
        tbpay.Text = dgvemp.Rows(e.RowIndex).Cells(4).Value
        tbaddressemp.Text = dgvemp.Rows(e.RowIndex).Cells(5).Value
        cmbgenemp.Text = dgvemp.Rows(e.RowIndex).Cells(6).Value
        enableemp()
    End Sub
    Private Sub tbnohpemp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbnohpemp.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub
    Private Sub tbpay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbpay.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

#End Region

#Region " user"

    Sub posuser_autocomplete()
        cmbposuser.Items.Clear()
        connect()

        For Each datarw1 In DT.Rows
            cmbposuser.Items.Add(datarw1("position").ToString)
        Next
        disconnect()
    End Sub


    Private Sub btnsaveuser_Click(sender As Object, e As EventArgs) Handles btnsaveuser.Click
        If tbnameuser.Text = "" Or tbpass.Text = "" Or cmbposuser.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()
            Try
                Dim simpan As String
                simpan = "insert into Tuser values ('" & tbnameuser.Text & "','" & tbpass.Text & "','" & cmbposuser.Text & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("input data sukses")

            Catch ex As Exception
                MsgBox("input data gagal ")
            End Try
            Call disable()
            Call empty()
            Call showuser()
            Call disconnect()
        End If
    End Sub

    Private Sub dgvuser_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        tbnameuser.Text = dgvuser.Rows(e.RowIndex).Cells(0).Value
        tbpass.Text = dgvuser.Rows(e.RowIndex).Cells(1).Value
        cmbposuser.Text = dgvuser.Rows(e.RowIndex).Cells(2).Value

        Call enableuser()

    End Sub


#End Region

#Region "Menu"
    Sub emptymenu()
        tbnamemenu.Text = ""
        lbidmenu.Text = ""
        tbprice.Text = ""
        cmbtype.Text = ""
        lblid2.Focus()
    End Sub

    Sub disablemenu()
        tbnamemenu.Enabled = False
        tbprice.Enabled = False
        cmbtype.Enabled = False

    End Sub

    Sub enablemenu()
        tbnamemenu.Enabled = True
        tbprice.Enabled = True
        cmbtype.Enabled = True
    End Sub

    Sub showmenu()
        connect()
        DA = New OleDbDataAdapter("select * from Tmenu", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvmenu.DataSource = DS.Tables(0)
        dgvmenu.ReadOnly = True

    End Sub
    Sub menu_autocomplete()

        CMD = New OleDbCommand("select * FROM [Tfood]", Conn)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        DR = CMD.ExecuteReader
        Do While DR.Read
            cmbtype.Items.Add(DR.Item(0))
        Loop
    End Sub

    Private Sub btnaddmenu_Click(sender As Object, e As EventArgs) Handles btnaddmenu.Click
        enablemenu()
        emptymenu()
        id_menu()
    End Sub
    Sub id_menu()
        connect()
        CMD = New OleDbCommand("select * from Tmenu where ID_menu in (select max(ID_menu) from Tmenu)", Conn)
        Dim urutanID As String
        Dim hitung As Long
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            urutanID = "0001"
        Else
            hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 3) + 1
            urutanID = Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        lbidmenu.Text = "MN" + urutanID
        Exit Sub

    End Sub

    Private Sub btneditmenu_Click(sender As Object, e As EventArgs) Handles btneditmenu.Click
        If tbnamemenu.Text = "" Or tbprice.Text = "" Or cmbtype.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()

            CMD = New OleDbCommand("UPDATE Tmenu set [name_menu]='" & tbnamemenu.Text & "',[price]='" & tbprice.Text & "',[type]='" & cmbtype.Text & "' where ID_menu='" & lbidmenu.Text & "'", Conn)
            CMD.ExecuteNonQuery()
            MsgBox("update data sukses")

            Call disablemenu()
            Call emptymenu()
            Call showmenu()
            Call disconnect()

        End If
    End Sub

    Private Sub btndelmenu_Click(sender As Object, e As EventArgs) Handles btndelmenu.Click
        If lbidmenu.Text = "" Then
            MsgBox("tidak ada data yang dihapus")
            Exit Sub
        Else
            If MessageBox.Show("Yakin mau hapus ", "konformasi", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                connect()
                CMD = New OleDbCommand("delete from Tmenu  where ID_menu= '" & lbidmenu.Text & "'", Conn)
                CMD.ExecuteNonQuery()
                MsgBox("delete data berhasil")
                Call disablemenu()
                Call emptymenu()
                Call showmenu()
                Call disconnect()
            Else
                Call disablemenu()
                Call emptymenu()
            End If

        End If
    End Sub

    Private Sub btncancelmenu_Click(sender As Object, e As EventArgs) Handles btncancelmenu.Click
        disablemenu()
        emptymenu()
    End Sub

    Private Sub btnsavemenu_Click(sender As Object, e As EventArgs) Handles btnsavemenu.Click
        If tbnamemenu.Text = "" Or tbprice.Text = "" Or cmbtype.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()
            Try
                Dim simpan As String
                simpan = "insert into Tmenu values ('" & lbidmenu.Text & "','" & tbnamemenu.Text & "','" & tbprice.Text & "','" & cmbtype.Text & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("input data sukses")

            Catch ex As Exception
                MsgBox("input data gagal ")
            End Try
            Call disablemenu()
            Call emptymenu()
            Call showmenu()
            Call disconnect()
        End If
    End Sub

    Private Sub dgvmenu_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvmenu.CellMouseClick
        lbidmenu.Text = dgvmenu.Rows(e.RowIndex).Cells(0).Value
        tbnamemenu.Text = dgvmenu.Rows(e.RowIndex).Cells(1).Value
        tbprice.Text = dgvmenu.Rows(e.RowIndex).Cells(2).Value
        cmbtype.Text = dgvmenu.Rows(e.RowIndex).Cells(3).Value

        Call enablemenu()
    End Sub
    Private Sub tbprice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbprice.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub


#End Region

#Region "buy"
    Private Sub btnbuy_Click(sender As Object, e As EventArgs) Handles btnbuy.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = True
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False

        clean_buy()
    End Sub

    Sub id_buy()
        connect()
        CMD = New OleDbCommand("select * from [Tbuy] where ID_buy in (select max([ID_buy]) from [Tbuy])", Conn)
        Dim urutanID1 As String
        Dim hitung1 As Long
        DR = CMD.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            urutanID1 = "0001"
        Else
            hitung1 = Microsoft.VisualBasic.Right(DR.GetString(0), 3) + 1
            urutanID1 = Microsoft.VisualBasic.Right("000" & hitung1, 3)
        End If
        lblidbuy.Text = "BY" + urutanID1
        Exit Sub

    End Sub
    Sub clean_buy()
        tbnamebuy.Text = ""
        tbpricebuy.Text = ""
        tbqty.Text = ""
        lbltotalbuy2.Text = ""

    End Sub

    Private Sub btnaddbuy_Click(sender As Object, e As EventArgs) Handles btnaddbuy.Click
        If tbnamebuy.Text = "" Or tbpricebuy.Text = "" Or tbqty.Text = "" Then
            MessageBox.Show("Tolong masukkan data terlebih dahulu", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Dim row As Integer
            Try

                Dim hargabeli2 As Integer

                hargabeli2 = CInt(tbpricebuy.Text) * CInt(tbqty.Text)
                lbltotalbuy2.Text = hargabeli2
            Catch ex As Exception
                MessageBox.Show("Perhitungan gagal", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            'hitungbeli()
            dgvbuy.Rows.Add()
            row = dgvbuy.Rows.Count - 2
            dgvbuy("idbuy", row).Value = lblidbuy.Text
            dgvbuy("datesbuy", row).Value = lbldatebuy2.Text
            dgvbuy("namesbuy", row).Value = tbnamebuy.Text
            dgvbuy("pricesbuy", row).Value = tbpricebuy.Text
            dgvbuy("qtybuy", row).Value = tbqty.Text
            dgvbuy("totalbuy4", row).Value = lbltotalbuy2.Text
            total_buy()

            dgvbuy.Sort(dgvbuy.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

        End If
        MessageBox.Show("Data berhasil dimasukkan ke keranjang belanja", "PEMBELIAN ONDERDIL", MessageBoxButtons.OK, MessageBoxIcon.Information)

        clean_buy()
    End Sub
    Sub total_buy()
        Dim totalsemua As Integer
        totalsemua = 0
        For t As Integer = 0 To dgvbuy.Rows.Count - 2 Step 1
            totalsemua = totalsemua + Val(dgvbuy.Rows(t).Cells(5).Value)
        Next
        lbltotalbuy4.Text = totalsemua
    End Sub

    Private Sub gbbuy_Enter(sender As Object, e As EventArgs) Handles gbbuy.Enter

    End Sub

    Private Sub btntotalbuy_Click(sender As Object, e As EventArgs)
        total_buy()
    End Sub

    Private Sub btnclearbuy_Click(sender As Object, e As EventArgs) Handles btnclearbuy.Click
        dgvbuy.Rows.Clear()
        clean_buy()
    End Sub

    Private Sub btndelbuy_Click(sender As Object, e As EventArgs) Handles btndelbuy.Click
        Try
            Dim index As Integer
            index = dgvbuy.CurrentCell.RowIndex
            dgvbuy.Rows.RemoveAt(index)
        Catch ex As Exception
            MessageBox.Show("Data pembelian gagal dihapus", "HAPUS ITEM ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btneksportbuy_Click(sender As Object, e As EventArgs) Handles btneksportbuy.Click
        'masukkan ke database pembelian
        If dgvbuy.Rows(0).Cells(0).Value = "" Then
            MessageBox.Show("Silahkan lakukan pembelian ", "PEMBELIAN ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            disconnect()
            Exit Sub
        ElseIf lbltotalbuy4.Text = "" Then
            MessageBox.Show("Silahkan lakukan perhitungan terlebih dahulu sebelum eksport ke database", "EKSPORT DATA", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Try
                For i As Integer = 0 To dgvbuy.Rows.Count - 2 Step 1
                    Dim str As String = "insert into Tbuy values('" & dgvbuy.Rows(i).Cells(0).Value & "','" & dgvbuy.Rows(i).Cells(1).Value & "','" & dgvbuy.Rows(i).Cells(2).Value & "','" & dgvbuy.Rows(i).Cells(3).Value & "','" & dgvbuy.Rows(i).Cells(4).Value & "','" & dgvbuy.Rows(i).Cells(5).Value & "')"
                    connect()
                    CMD = New OleDbCommand(str, Conn)
                    CMD.ExecuteNonQuery()
                    disconnect()
                Next i
                disconnect()
            Catch ex As Exception
                disconnect()
                MsgBox(ex.Message)
                'MsgBox("Eksport ke database gagal", MsgBoxStyle.OkOnly, "PERINGATAN")
            End Try
            MsgBox("Eksport ke database berhasil", MsgBoxStyle.OkOnly, "EKSPORT")
            id_buy()
        End If

        'masukkan ke database total_pembelian
        Try
            If dgvbuy.Rows(0).Cells(0).Value = "" Or lbltotalbuy4.Text = "" Then
                Exit Sub
            Else
                connect()
                Dim str As String = "insert into Totalbuy values('" & dgvbuy.Rows(0).Cells(0).Value & "','" & dgvbuy.Rows(0).Cells(1).Value & "', '" & lbltotalbuy4.Text & "')"
                CMD = New OleDbCommand(str, Conn)
                CMD.ExecuteNonQuery()
                disconnect()
            End If
        Catch ex As Exception
            disconnect()
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub tbpricebuy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbpricebuy.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub tbqty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbqty.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub gbsell_Enter(sender As Object, e As EventArgs) Handles gbsell.Enter

    End Sub

#End Region

#Region "Pay "
    Sub emptypay()
        cmbnamepay.Text = ""
        tbdays.Text = ""
        lblgbpay2.Text = ""
        lblidpay2.Text = ""
        lblidpay2.Focus()
    End Sub
    Sub disablepay()
        cmbnamepay.Enabled = False
        tbdays.Enabled = False

    End Sub

    Sub enablepay()
        cmbnamepay.Enabled = True
        tbdays.Enabled = True
    End Sub

    Sub showpay()
        connect()
        DA = New OleDbDataAdapter("select * from Tpay", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvpay.DataSource = DS.Tables(0)
        dgvpay.ReadOnly = True

    End Sub
    Sub name_autocomplete()

        CMD = New OleDbCommand("select [name_emp] FROM [Temployee]", Conn)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        DR = CMD.ExecuteReader
        Do While DR.Read
            cmbnamepay.Items.Add(DR.Item(0))
        Loop

    End Sub
    Sub id_emp()
        connect()
        Dim str As String

        str = "select ID_emp from Temployee where name_emp = '" & cmbnamepay.Text & "'"
        CMD = New OleDbCommand(str, Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            lblidpay2.Text = DR.Item("ID_emp")
        Else
        End If
        disconnect()
    End Sub
    Sub pay()
        connect()
        Dim str As String

        str = "select pay from Temployee where name_emp = '" & cmbnamepay.Text & "'"
        CMD = New OleDbCommand(str, Conn)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            lblgbpay2.Text = DR.Item("pay")
        Else
        End If
        disconnect()
    End Sub

    Private Sub tbdays_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbdays.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub btnaddpay_Click(sender As Object, e As EventArgs) Handles btnaddpay.Click
        enablepay()
        emptypay()
    End Sub

    Private Sub cmbnamepay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbnamepay.SelectedIndexChanged
        pay()
        id_emp()
    End Sub

    Private Sub btneditpay_Click(sender As Object, e As EventArgs) Handles btneditpay.Click
        If cmbnamepay.Text = "" Or tbdays.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()

            CMD = New OleDbCommand("UPDATE Tpay set [name_pay]='" & cmbnamepay.Text & "',[pay_pay]='" & lblgbpay2.Text & "',[date_pay]='" & tbdays.Text & "' where ID_pay='" & lblgbpay2.Text & "'", Conn)
            CMD.ExecuteNonQuery()
            MsgBox("update data sukses")

            Call disablepay()
            Call emptypay()
            Call showpay()
            Call disconnect()

        End If
    End Sub

    Private Sub btndelpay_Click(sender As Object, e As EventArgs) Handles btndelpay.Click
        If lblidpay2.Text = "" Then
            MsgBox("tidak ada data yang dihapus")
            Exit Sub
        Else
            If MessageBox.Show("Yakin mau hapus ", "konformasi", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                connect()
                CMD = New OleDbCommand("delete from Tpay  where ID_pay= '" & lblidpay2.Text & "'", Conn)
                CMD.ExecuteNonQuery()
                MsgBox("delete data berhasil")
                Call disablepay()
                Call emptypay()
                Call showpay()
                Call disconnect()
            Else
                Call disablepay()
                Call emptypay()
            End If

        End If
    End Sub

    Private Sub btncancelpay_Click(sender As Object, e As EventArgs) Handles btncancelpay.Click
        disablepay()
        emptypay()
    End Sub

    Private Sub btnsavepay_Click(sender As Object, e As EventArgs) Handles btnsavepay.Click
        If cmbnamepay.Text = "" Or tbdays.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()
            Dim days As Integer
            Dim totalpay As Integer
            totalpay = (CInt(lblgbpay2.Text) / 30) * CInt(tbdays.Text)
            Try
                Dim simpan As String
                simpan = "insert into Tpay values ('" & lblidpay2.Text & "','" & cmbnamepay.Text & "','" & tbdays.Text & "','" & totalpay & "')"
                CMD = New OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()
                MsgBox("input data sukses")

            Catch ex As Exception
                MsgBox("input data gagal ")
            End Try
            Call disablepay()
            Call emptypay()
            Call showpay()
            Call disconnect()
        End If
    End Sub

    Private Sub dgvpay_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvpay.CellMouseClick
        lblidpay2.Text = dgvpay.Rows(e.RowIndex).Cells(0).Value
        cmbnamepay.Text = dgvpay.Rows(e.RowIndex).Cells(1).Value
        tbdays.Text = dgvpay.Rows(e.RowIndex).Cells(2).Value
        lblgbpay2.Text = dgvpay.Rows(e.RowIndex).Cells(3).Value

        Call enablepay()
    End Sub



#End Region

#Region "Report Buy"
    Private Sub btnbuyreport_Click(sender As Object, e As EventArgs) Handles btnbuyreport.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = True
        gbreportsell.Visible = False
        gbreportprofit.Visible = False
        gbedituser.Visible = False

        showreportbuy()
        reportbuy()
    End Sub
    Sub showreportbuy()
        connect()
        DA = New OleDbDataAdapter("select * from Tbuy", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvreportbuy.DataSource = DS.Tables(0)
        dgvreportbuy.ReadOnly = True

    End Sub

    Private Sub btnfilterbuy_Click(sender As Object, e As EventArgs) Handles btnfilterbuy.Click
        Try
            connect()
            Dim srt As String = "select * from Tbuy where date_buy like '" & cmbdaysbuy.Text & "%'"
            DA = New OleDbDataAdapter(srt, Conn)
            DT = New DataTable
            DA.Fill(DT)
            dgvreportbuy.DataSource = DT
            disconnect()
            reportbuy()
        Catch ex As Exception
            disconnect()
        End Try
    End Sub
    Sub reportbuy()
        Dim totalsemua As Integer
        totalsemua = 0
        For t As Integer = 0 To dgvreportbuy.Rows.Count - 2 Step 1
            totalsemua = totalsemua + Val(dgvreportbuy.Rows(t).Cells(5).Value)
        Next
        lbltotalreportbuy2.Text = totalsemua
    End Sub
    Private Sub btnprintbuy_Click(sender As Object, e As EventArgs) Handles btnprintbuy.Click
        Dim dt As New DataTable
        With dt
            .Columns.Add("ID_buy")
            .Columns.Add("date_buy")
            .Columns.Add("name_buy")
            .Columns.Add("pricebuy")
            .Columns.Add("qty")
            .Columns.Add("price")

        End With

        For Each dgr As DataGridViewRow In Me.dgvreportbuy.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value)
        Next

        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReportbuy
        reportDocument.SetDataSource(dt)

        formReportbuy.Reportbuyview.ReportSource = reportDocument
        formReportbuy.ShowDialog()
        formReportbuy.Dispose()
    End Sub

#End Region

#Region "Report Sell"
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnsellreport.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = True
        gbreportprofit.Visible = False
        gbedituser.Visible = False

        showreportsell()
        reportsell()
    End Sub
    Sub showreportsell()
        connect()
        DA = New OleDbDataAdapter("select * from Tsell", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvreportsell.DataSource = DS.Tables(0)
        dgvreportsell.ReadOnly = True

    End Sub

    Private Sub btnfiltersell_Click(sender As Object, e As EventArgs) Handles btnfiltersell.Click
        Try
            connect()
            Dim srt As String = "select * from Tsell where date_sell like '" & cmbreportsell.Text & "%'"
            DA = New OleDbDataAdapter(srt, Conn)
            DT = New DataTable
            DA.Fill(DT)
            dgvreportsell.DataSource = DT
            disconnect()
            reportsell()
        Catch ex As Exception
            disconnect()
        End Try

    End Sub
    Sub reportsell()
        Dim totalsemua As Integer
        totalsemua = 0
        For t As Integer = 0 To dgvreportsell.Rows.Count - 2 Step 1
            totalsemua = totalsemua + Val(dgvreportsell.Rows(t).Cells(8).Value)
        Next
        lbltotalreportsell2.Text = totalsemua
    End Sub

    Private Sub btnprintsell_Click(sender As Object, e As EventArgs) Handles btnprintsell.Click
        Dim dt As New DataTable
        With dt
            .Columns.Add("ID_sell")
            .Columns.Add("date_sell")
            .Columns.Add("food")
            .Columns.Add("drink")
            .Columns.Add("price_drink")
            .Columns.Add("price_food")
            .Columns.Add("qty_food")
            .Columns.Add("qty_drink")
            .Columns.Add("total")

        End With

        For Each dgr As DataGridViewRow In Me.dgvreportsell.Rows
            dt.Rows.Add(dgr.Cells(0).Value, dgr.Cells(1).Value, dgr.Cells(2).Value, dgr.Cells(3).Value, dgr.Cells(4).Value, dgr.Cells(5).Value, dgr.Cells(6).Value, dgr.Cells(7).Value, dgr.Cells(8).Value)
        Next

        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReportsell
        reportDocument.SetDataSource(dt)

        Formreportsell.Reportsellviewer.ReportSource = reportDocument
        Formreportsell.ShowDialog()
        Formreportsell.Dispose()
    End Sub



#End Region

#Region "Report Profit"

    Private Sub btnfilterprofit_Click(sender As Object, e As EventArgs) Handles btnfilterprofit.Click
        Try
            connect()
            Dim srt As String = "select * from TotalBuy where date_buy like '" & cmbfilterprofit.Text & "%'"
            DA = New OleDbDataAdapter(srt, Conn)
            DT = New DataTable
            DA.Fill(DT)
            dgvbuyprofit.DataSource = DT
            disconnect()
        Catch ex As Exception
            disconnect()
        End Try

        Try
            connect()
            Dim srt As String = "select * from Totalsell where date_sell like '" & cmbfilterprofit.Text & "%'"
            DA = New OleDbDataAdapter(srt, Conn)
            DT = New DataTable
            DA.Fill(DT)
            dgvrsellprofit.DataSource = DT
            disconnect()
        Catch ex As Exception
            disconnect()
        End Try

        countbuy()
        countsell()

    End Sub

    Private Sub btnreportprofit_Click(sender As Object, e As EventArgs) Handles btnreportprofit.Click
        gbcust.Visible = False
        gbsell.Visible = False
        gbbuy.Visible = False
        gbemp.Visible = False
        gbmenu.Visible = False
        gbuser.Visible = False
        Gbreportbuy.Visible = False
        gbreportsell.Visible = False
        gbreportprofit.Visible = True
        gbedituser.Visible = False

        show_buy_profit()
        show_sell_profit()
        countbuy()
        countsell()

        cmbfilterprofit.Text = "All Month"
        profit()
    End Sub
    Sub show_sell_profit()
        connect()
        DA = New OleDbDataAdapter("select * from Totalsell", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvrsellprofit.DataSource = DS.Tables(0)
        dgvrsellprofit.ReadOnly = True

    End Sub
    Sub show_buy_profit()
        connect()
        DA = New OleDbDataAdapter("select * from Totalbuy", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvbuyprofit.DataSource = DS.Tables(0)
        dgvbuyprofit.ReadOnly = True

    End Sub
    Sub countsell()
        Dim totalsell As Integer
        totalsell = 0
        For y As Integer = 0 To dgvrsellprofit.Rows.Count - 2 Step 1
            totalsell = totalsell + Val(dgvrsellprofit.Rows(y).Cells(2).Value)
        Next
        lblreporttotalsell2.Text = totalsell
    End Sub
    Sub countbuy()
        Dim totalbuy As Integer
        totalbuy = 0
        For y As Integer = 0 To dgvbuyprofit.Rows.Count - 2 Step 1
            totalbuy = totalbuy + Val(dgvbuyprofit.Rows(y).Cells(2).Value)
        Next
        lblreporttotalbuy2.Text = totalbuy
    End Sub
    Sub profit()
        Dim profit1 As Integer = CInt(lblreporttotalbuy2.Text) 'pembelian
        Dim profit2 As Integer = CInt(lblreporttotalsell2.Text) 'penjualan
        Dim profit3 As Integer = 0
        Dim loss As Integer = 0

        If profit1 < profit2 Then
            profit3 = profit2 - profit1
            lblprofit2.Text = profit3
            lbllost2.Text = "0"
        ElseIf profit1 = profit2 Then
            lblprofit2.Text = "0"
            lbllost2.Text = "0"
        Else
            profit3 = profit1 - profit2
            lbllost2.Text = profit3
            lblprofit2.Text = "0"
        End If
    End Sub
    Private Sub btnprintprofit_Click(sender As Object, e As EventArgs) Handles btnprintprofit.Click
        Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportDocument = New CrystalReportprofit

        Formreportprofit.reportprofitview.ReportSource = reportDocument
        Formreportprofit.ShowDialog()
        Formreportprofit.Dispose()
    End Sub


#End Region

#Region "Edit user"
    Sub emptyuser()
        tbnamedituser.Text = ""
        tbpassedituser.Text = ""
        cmbposedituser.Text = ""
        tbname.Focus()
    End Sub

    Sub disableuser()
        tbnamedituser.Enabled = False
        cmbposedituser.Enabled = False
        tbpassedituser.Enabled = False
    End Sub

    Sub enableuser()
        tbnamedituser.Enabled = True
        cmbposedituser.Enabled = True
        tbpassedituser.Enabled = True
    End Sub

    Sub showuser()
        connect()
        DA = New OleDbDataAdapter("select * from Tuser", Conn)
        DS = New DataSet
        DA.Fill(DS)
        dgvuser.DataSource = DS.Tables(0)
        dgvuser.ReadOnly = True
    End Sub
    Sub posuser_autocomplete_edit()
        cmbposedituser.Items.Clear()
        connect()

        For Each datarw2 In DT.Rows
            cmbposedituser.Items.Add(datarw2("position").ToString)
        Next
        disconnect()
    End Sub
    Private Sub btnadduser_Click(sender As Object, e As EventArgs) Handles btnadduser.Click
        enableuser()
        emptyuser()
    End Sub

    Private Sub btnedituser_Click_1(sender As Object, e As EventArgs) Handles btnedituser.Click
        If tbnamedituser.Text = "" Or tbpassedituser.Text = "" Or cmbposedituser.Text = "" Then
            MsgBox("data tidak lengkap")
            Exit Sub
        Else
            connect()

            CMD = New OleDbCommand("UPDATE Tuser set [password]='" & tbpassedituser.Text & "',[position]='" & cmbposedituser.Text & "' where [username]='" & tbnamedituser.Text & "'", Conn)
            CMD.ExecuteNonQuery()
            MsgBox("update data sukses")

            Call disableuser()
            Call emptyuser()
            Call showuser()
            Call disconnect()

        End If
    End Sub

    Private Sub btndeluser_Click_1(sender As Object, e As EventArgs) Handles btndeluser.Click
        If tbnamedituser.Text = "" Then
            MsgBox("tidak ada data yang dihapus")
            Exit Sub
        Else
            If MessageBox.Show("Yakin mau hapus ", "konformasi", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                connect()
                CMD = New OleDbCommand("delete from Tuser  where username= '" & tbnamedituser.Text & "'", Conn)
                CMD.ExecuteNonQuery()
                MsgBox("delete data berhasil")
                Call disableuser()
                Call emptyuser()
                Call showuser()
                Call disconnect()
            Else
                Call disable()
                Call emptyuser()
            End If

        End If
    End Sub

    Private Sub btncanceluser_Click_1(sender As Object, e As EventArgs) Handles btncanceluser.Click
        disableuser()
        emptyuser()
    End Sub

    Private Sub btnsavedituser_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvuser_CellMouseClick_1(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvuser.CellMouseClick
        tbnamedituser.Text = dgvuser.Rows(e.RowIndex).Cells(0).Value
        tbpassedituser.Text = dgvuser.Rows(e.RowIndex).Cells(1).Value
        cmbposedituser.Text = dgvuser.Rows(e.RowIndex).Cells(2).Value

        Call enableuser()

    End Sub


#End Region



End Class