Public Class frmLoadOrder

    Private Sub frmLoadOrder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SelectLoadOrderList("")
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        SelectLoadOrderList(TextBox1.Text)
    End Sub

    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        frmAddEditOrderPayment.txtOrderNo.Text = ListView1.FocusedItem.SubItems(1).Text
        frmAddEditOrderPayment.txtCompany.Text = ListView1.FocusedItem.SubItems(3).Text
        Me.Close()
    End Sub
End Class