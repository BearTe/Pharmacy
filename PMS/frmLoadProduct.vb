Public Class frmLoadProduct

    Private Sub frmLoadProduct_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadProduct_Select(ComboBox1.Text.Replace(" ", ""), TextBox2.Text)
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        LoadProduct_Select(ComboBox1.Text.Replace(" ", ""), TextBox2.Text)
    End Sub

    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If frmAddProductOrder.isAddingProductOrder = True Then
            With frmAddProductOrder
                .txtGenericName.Tag = ListView1.FocusedItem.Text
                .txtGenericName.Text = ListView1.FocusedItem.SubItems(2).Text
                .txtTradeName.Text = ListView1.FocusedItem.SubItems(1).Text
                .txtDrugType.Text = ListView1.FocusedItem.SubItems(3).Text
                .txtCostPrice.Text = FormatNumber(Val(ListView1.FocusedItem.SubItems(4).Text))
            End With
            Me.Close()
        End If

    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class

