
Imports System.Data.SqlClient
Public Class frmUpdateTransactionPayment

    Private Sub frmUpdateTransactionPayment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With frmListTransactions.ListView1
            lblTransactionDate.Text = .FocusedItem.Text
            lblInvoice.Text = .FocusedItem.SubItems(1).Text
            lblTotalAmount.Text = .FocusedItem.SubItems(2).Text
            lblPaidAmount.Text = .FocusedItem.SubItems(5).Text
            lblBalance.Text = .FocusedItem.SubItems(6).Text
            lblCashier.Text = .FocusedItem.SubItems(7).Text
        End With
    End Sub

    Private Sub UpdateTransactionPayment()
        Try
            sqL = "UPDATE TransactionPayment SET PaidAmount = PaidAmount + " & Val(txtAmount.Text) & ", Balance = Balance - " & Val(txtAmount.Text) & " WHERE InvoiceNo = '" & lblInvoice.Text & "' "
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            Dim i As Integer = cmd.ExecuteNonQuery

            If i > 0 Then
                MsgBox("Payment Updated", MsgBoxStyle.Information, "Payment")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        UpdateTransactionPayment()
        LoadTransactionList(frmListTransactions.dtpFrom.Value, frmListTransactions.dtpTo.Value)
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class