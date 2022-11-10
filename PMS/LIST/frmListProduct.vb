Public Class frmListProduct

    Public productID As Integer
    Public productNameSelected As String

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        isAddingData = True
        frmAddEditProduct.ShowDialog()
    End Sub

    Private Sub frmListProduct_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                isAddingData = False
                frmAddEditProduct.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If cmbFieldname.Text = "" Then
            MsgBox("Please select Field Name/Filter", MsgBoxStyle.Exclamation, "Warning")
        Else
            LoadProductList(cmbFieldname.Text.Replace(" ", ""), txtFieldvalue.Text)
        End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        If productID = 0 Then
            MsgBox("Please select product.", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        isAddingData = True
        frmAddEditStock.ShowDialog()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            productID = Val(ListView1.FocusedItem.Text)
            productNameSelected = ListView1.FocusedItem.SubItems(2).Text
            LoadStockList(productID)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        If productID = 0 Then
            MsgBox("Please select product.", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        End If

        If ListView2.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView2.FocusedItem.Text = "" Then

            Else
                isAddingData = False
                frmAddEditStock.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadStockList(productID, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub dtpTo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpTo.ValueChanged
        LoadStockList(productID, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to Delete", MsgBoxStyle.Exclamation, "Delete")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                If MsgBox("Are you sure you want to delete?", MsgBoxStyle.YesNo, "Delete Product") = MsgBoxResult.Yes Then
                    DeleteProduct(ListView1.FocusedItem.Text)
                    LoadProductList(cmbFieldname.Text.Replace(" ", ""), txtFieldvalue.Text)
                    ListView2.Items.Clear()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class