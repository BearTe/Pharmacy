Imports System.Data.SqlClient

Public Class frmAddEditOrder

    Public isAddingOrder As Boolean

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        frmAddProductOrder.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        isAddingOrder = True
        frmLoadCompany.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        txtTotalQuantity.Text = Val(txtTotalQuantity.Text.Replace(",", "")) - Val(ListView1.FocusedItem.SubItems(3).Text.Replace(",", ""))
        txtSubtotal.Text = Format(Val(txtSubtotal.Text.Replace(",", "")) - Val(ListView1.FocusedItem.SubItems(6).Text.Replace(",", "")), "N2")

        For Each i As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(i)
        Next
    End Sub

    Private Sub AddOrder()
        Dim productId As Integer
        Dim Cost As Double
        Dim Quantity As Integer
        Dim ExntedenPrice As Double

        Dim TotalPrice As Double

        For i = 0 To ListView1.Items.Count - 1
            With ListView1
                productId = Val(.Items.Item(i).SubItems(6).Text)
                Cost = Val(.Items.Item(i).SubItems(2).Text.Replace(",", ""))
                Quantity = Val(.Items.Item(i).SubItems(3).Text.Replace(",", ""))
                ExntedenPrice = Val(.Items.Item(i).SubItems(4).Text.Replace(",", ""))
                TotalPrice = Val(.Items.Item(i).SubItems(5).Text.Replace(",", ""))
                AddOrderProduct(productId, Quantity, Cost, ExntedenPrice, TotalPrice, txtOrderNo.Text)
            End With
        Next
    End Sub

    Private Sub GetOrderNo()
        Try
            sqL = "SELECT OrderNo FROM [Order] Order By OrderNo Desc"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtOrderNo.Text = Val(dr(0)) + 1
            Else
                txtOrderNo.Text = 1001001

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            AddOrder()
            AddEditOrder(True)
        Else
            AddEditOrder(False)
        End If
        LoadOrderList("")
        Me.Close()
    End Sub

    Private Sub frmAddEditOrder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Order"
            GetOrderNo()
            txtManufacturer.Text = ""
            txtManufacturer.Tag = ""
            txtSubtotal.Text = ""
            txtTotalQuantity.Text = ""
            dtpOrderDate.Value = Date.Now
            ListView1.Items.Clear()
            btnAdd.Enabled = True
            btnRemove.Enabled = True
            txtCreatedBy.Text = frmMain.lblUser.Text
            txtCreatedBy.Tag = frmMain.lblUser.Tag
        Else
            lblTitle.Text = "Updating Order"
            GetOrderInfo(frmListOrder.selectedOrderNo)
            LoadAddEditOrderProductList(frmListOrder.selectedOrderNo)
            btnAdd.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtDiscount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscount.TextChanged
        txtTotalAmount.Text = Val(txtSubtotal.Text.Replace(",", "")) - Val(txtDiscount.Text)
    End Sub

    Private Sub txtSubtotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubtotal.TextChanged
        txtTotalAmount.Text = txtSubtotal.Text
    End Sub
End Class