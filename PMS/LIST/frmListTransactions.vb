Public Class frmListTransactions

    Public InvoiceNo As String = ""

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        InvoiceNo = InputBox("ENTER INVOICE NUMBER", "SEARCH BY Transaction by Invoice Number")
        LoadTransactionList(InvoiceNo)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadTransactionList(dtpFrom.Value, dtpTo.Value)
    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            InvoiceNo = ListView1.FocusedItem.SubItems(1).Text
            LoadTransactionLineItem(InvoiceNo)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else

                frmUpdateTransactionPayment.ShowDialog()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmListTransactions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadTransactionList(dtpFrom.Value, dtpTo.Value)
    End Sub
End Class