Public Class frmAddEditStock


    Public isStock As Boolean
    Public oldStockNo As Integer

    Private Sub frmAddEditStock_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Stock"
            txtMedicine.Tag = frmListProduct.productID
            txtMedicine.Text = frmListProduct.productNameSelected
            dtpStockDate.Value = Date.Now
            txtManufacturer.Tag = ""
            txtManufacturer.Text = ""
            dtpManufacture.Value = Date.Now
            dtpExpiration.Value = Date.Now
            txtPacking.Text = ""
            txtStockQuantity.Text = ""
            oldStockNo = 0
        Else
            lblTitle.Text = "Updating Stock"
            GetStockInfo(frmListProduct.ListView2.FocusedItem.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        isStock = True
        frmLoadCompany.ShowDialog()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            UpdateProductStock_Increasing(frmListProduct.productID, Val(txtStockQuantity.Text))
            AddEditStock(True)
        Else
            UpdateProductStock_Descreasing(frmListProduct.productID, oldStockNo)
            UpdateProductStock_Increasing(frmListProduct.productID, Val(txtStockQuantity.Text))
            AddEditStock(False)
        End If

        LoadStockList(frmListProduct.productID)
        LoadProductList(frmListProduct.cmbFieldname.Text.Replace(" ", ""), frmListProduct.txtFieldvalue.Text)
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

End Class

