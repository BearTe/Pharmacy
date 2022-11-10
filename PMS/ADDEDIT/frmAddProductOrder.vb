Public Class frmAddProductOrder

    Public isAddingProductOrder As Boolean

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        isAddingProductOrder = True
        frmLoadProduct.ShowDialog()
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtQuantity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQuantity.TextChanged
        txtExtendedPrice.Text = FormatNumber(Val(txtCostPrice.Text.Replace(",", "")) * Val(txtQuantity.Text))
        txtTotalCost.Text = FormatNumber(Val(txtExtendedPrice.Text.Replace(",", "")))
    End Sub

    
    Private Sub txtDiscount_TextChanged(sender As System.Object, e As System.EventArgs)
        txtTotalCost.Text = FormatNumber(Val(txtExtendedPrice.Text.Replace(",", "")))
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If txtGenericName.Text = "" Then
            MsgBox("Please select product.", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        If txtQuantity.Text = "" Or Val(txtQuantity.Text.Replace(",", "")) = 0 Then
            MsgBox("Please enter quantity.", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        Dim x As ListViewItem
        With frmAddEditOrder.ListView1
            x = New ListViewItem(txtGenericName.Text)
            x.SubItems.Add(txtTradeName.Text)
            x.SubItems.Add(txtCostPrice.Text)
            x.SubItems.Add(txtQuantity.Text)
            x.SubItems.Add(txtExtendedPrice.Text)
            x.SubItems.Add(txtTotalCost.Text)
            x.SubItems.Add(txtGenericName.Tag)

            .Items.Add(x)
        End With

        frmAddEditOrder.txtTotalQuantity.Text = Val(frmAddEditOrder.txtTotalQuantity.Text.Replace(",", "")) + Val(txtQuantity.Text)
        frmAddEditOrder.txtSubtotal.Text = Format(Val(frmAddEditOrder.txtSubtotal.Text.Replace(",", "")) + Val(txtTotalCost.Text.Replace(",", "")), "N2")
        MsgBox("Added to Order List", MsgBoxStyle.Information, "Order Product")
        clearFields()
    End Sub

    Private Sub clearFields()
        txtTradeName.Text = ""
        txtCostPrice.Text = ""
        txtQuantity.Text = ""
        txtExtendedPrice.Text = ""
        txtTotalCost.Text = ""
        txtGenericName.Tag = ""
        txtGenericName.Text = ""
        txtDrugType.Text = ""
    End Sub
End Class