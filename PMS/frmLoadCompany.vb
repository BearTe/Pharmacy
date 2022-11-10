Public Class frmLoadCompany

    Private Sub frmLoadCompany_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCompany_Select()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        LoadCompany_Select()
    End Sub

    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If frmAddEditStock.isStock = True Then
            frmAddEditStock.txtManufacturer.Tag = ListView1.FocusedItem.Text
            frmAddEditStock.txtManufacturer.Text = ListView1.FocusedItem.SubItems(1).Text
            frmAddEditStock.isStock = False
        End If

        If frmAddEditOrder.isAddingOrder = True Then
            frmAddEditOrder.txtManufacturer.Tag = ListView1.FocusedItem.Text
            frmAddEditOrder.txtManufacturer.Text = ListView1.FocusedItem.SubItems(1).Text
            frmAddEditOrder.isAddingOrder = False
        End If

        If frmAddEditOrderPayment.isOrderpayment = True Then
            frmAddEditOrderPayment.txtCompany.Tag = ListView1.FocusedItem.Text
            frmAddEditOrderPayment.txtCompany.Text = ListView1.FocusedItem.SubItems(1).Text
            frmAddEditOrderPayment.isOrderpayment = False
        End If

        Me.Close()
    End Sub

   
End Class