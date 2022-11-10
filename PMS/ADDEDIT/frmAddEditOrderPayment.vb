Public Class frmAddEditOrderPayment

    Public isOrderpayment As Boolean


    Private Sub frmAddEditOrderPayment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Order Payment"
            txtOrderNo.Tag = ""
            txtOrderNo.Text = ""
            txtCompany.Text = ""
            txtReceiptNo.Text = ""
            txtPaidAmount.Text = ""
            dtpPaidDate.Value = Date.Now
            txtCompany.Text = frmListOrderPayment.cmbCompany.Text
        Else
            lblTitle.Text = "Adding Order Payment"
            GetOrderPaymentInfo(frmListOrderPayment.ListView1.FocusedItem.Text)
        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            AddEditOrderPayment(True)
        Else
            AddEditOrderPayment(False)
        End If

        LoadOrderListPayment(frmListOrderPayment.cmbCompany.Text)
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        isOrderpayment = True
        ' frmLoadOrder.ShowDialog()
        frmLoadCompany.ShowDialog()
    End Sub
End Class