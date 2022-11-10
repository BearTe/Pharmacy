Public Class frmAddEditProduct
    
    Private Sub frmAddEditProduct_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Medicine"
            txtMedicineCode.Tag = ""
            txtMedicineCode.Text = ""
            txtTradeName.Text = ""
            txtGenericName.Text = ""
            cmbDrugType.SelectedIndex = -1
            txtUnit.Text = ""
            txtUnitvalue.Text = ""
            txtCostPrice.Text = ""
            txtProfitPercent.Text = ""
            txtSellingPrice.Text = ""
            txtInstruction.Text = ""
            txtQuantity.Text = ""
        Else
            lblTitle.Text = "Updating Medicine"
            GetProductInfo(frmListProduct.ListView1.FocusedItem.Text)

            txtMedicineCode.Focus()
        End If

        txtPacking.Visible = False
        lblPacking.Visible = False
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            AddEditProduct(True)
        Else
            AddEditProduct(False)
        End If

        LoadProductList("TradeName", "")
        Me.Close()
    End Sub

    Private Sub txtProfitPercent_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProfitPercent.TextChanged
        Try
            txtSellingPrice.Text = Format((Val(txtCostPrice.Text.Replace(",", "")) * (Val(txtProfitPercent.Text) / 100)) + Val(txtCostPrice.Text.Replace(",", "")), "N2")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

  
    Private Sub txtCostPrice_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCostPrice.TextChanged
        Try
            txtSellingPrice.Text = Format((Val(txtCostPrice.Text.Replace(",", "")) * (Val(txtProfitPercent.Text) / 100)) + Val(txtCostPrice.Text.Replace(",", "")), "N2")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCostPrice_Leave(sender As System.Object, e As System.EventArgs) Handles txtCostPrice.Leave
        txtCostPrice.Text = Format(Val(txtCostPrice.Text.Replace(",", "")), "N2")
    End Sub

    Private Sub cmbDrugType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDrugType.SelectedIndexChanged
       
    End Sub
End Class